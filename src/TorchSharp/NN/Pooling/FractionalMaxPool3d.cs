// Copyright (c) .NET Foundation and Contributors.  All Rights Reserved.  See LICENSE in the project root for license information.
using System;
using System.Runtime.InteropServices;
using static TorchSharp.torch;

namespace TorchSharp
{
    using Modules;

    namespace Modules
    {
        /// <summary>
        /// This class is used to represent a FractionalMaxPool3d module.
        /// </summary>
        public class FractionalMaxPool3d : torch.nn.Module
        {
            internal FractionalMaxPool3d(IntPtr handle, IntPtr boxedHandle, bool ratio) : base(handle, boxedHandle)
            {
                _used_ratio = ratio;
            }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_FractionalMaxPool3d_forward(torch.nn.Module.HType module, IntPtr tensor);

            public override Tensor forward(Tensor tensor)
            {
                if (_used_ratio && tensor.ndim != 5)
                    // Not sure why this is the case, but there's an exception in the native runtime
                    // unless there's both a batch dimension and a channel dimension.
                    throw new ArgumentException("FractionalMaxPool3d: input tensor must have 5 dimensions: [N, C, D, H, W]");
                var res = THSNN_FractionalMaxPool3d_forward(handle, tensor.Handle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Tensor(res);
            }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_FractionalMaxPool3d_forward_with_indices(torch.nn.Module.HType module, IntPtr tensor, out IntPtr indices);

            public (Tensor Values, Tensor Indices) forward_with_indices(Tensor tensor)
            {
                if (_used_ratio && tensor.ndim != 5)
                    // Not sure why this is the case, but there's an exception in the native runtime
                    // unless there's both a batch dimension and a channel dimension.
                    throw new ArgumentException("FractionalMaxPool3d: input tensor must have 5 dimensions: [N, C, D, H, W]");
                var res = THSNN_FractionalMaxPool3d_forward_with_indices(handle, tensor.Handle, out var indices);
                if (res == IntPtr.Zero || indices == IntPtr.Zero) { torch.CheckForErrors(); }
                return (new Tensor(res), new Tensor(indices));
            }

            private bool _used_ratio = false;
        }
    }

    public static partial class torch
    {
        public static partial class nn
        {
            [DllImport("LibTorchSharp")]
            extern static IntPtr THSNN_FractionalMaxPool3d_ctor(IntPtr pkernelSize, int kernelSizeLength, IntPtr pOutputSize, int sizeLength, IntPtr pOutputRatio, int ratioLength, out IntPtr pBoxedModule);

            /// <summary>
            /// Applies a 3d fractional max pooling over an input signal composed of several input planes.
            ///
            /// Fractional MaxPooling is described in detail in the paper Fractional MaxPooling by Ben Graham,
            /// see: https://arxiv.org/abs/1412.6071
            /// </summary>
            /// <param name="kernel_size">The size of the sliding window, must be > 0.</param>
            /// <param name="output_size">The target output size of the image of the form oH x oW. Can be a tuple (oH, oW) or a single number oH for a square image oH x oH</param>
            /// <param name="output_ratio">If one wants to have an output size as a ratio of the input size, this option can be given. This has to be a number or tuple in the range (0, 1)</param>
            /// <returns></returns>
            static public FractionalMaxPool3d FractionalMaxPool3d(long kernel_size, long? output_size = null, double? output_ratio = null)
            {
                var pSize = output_size.HasValue ? new long[] { output_size.Value, output_size.Value, output_size.Value } : null;
                var pRatio = output_ratio.HasValue ? new double[] { output_ratio.Value, output_ratio.Value, output_ratio.Value } : null;
                return FractionalMaxPool3d(new long[] { kernel_size, kernel_size, kernel_size }, pSize, pRatio);
            }

            /// <summary>
            /// Applies a 3d fractional max pooling over an input signal composed of several input planes.
            ///
            /// Fractional MaxPooling is described in detail in the paper Fractional MaxPooling by Ben Graham,
            /// see: https://arxiv.org/abs/1412.6071
            /// </summary>
            /// <param name="kernel_size">The size of the sliding window, must be > 0.</param>
            /// <param name="output_size">The target output size of the image of the form oH x oW. Can be a tuple (oH, oW) or a single number oH for a square image oH x oH</param>
            /// <param name="output_ratio">If one wants to have an output size as a ratio of the input size, this option can be given. This has to be a number or tuple in the range (0, 1)</param>
            /// <returns></returns>
            static public FractionalMaxPool3d FractionalMaxPool3d((long, long, long) kernel_size, (long, long, long)? output_size = null, (double, double, double)? output_ratio = null)
            {
                var pSize = output_size.HasValue ? new long[] { output_size.Value.Item1, output_size.Value.Item2, output_size.Value.Item3 } : null;
                var pRatio = output_ratio.HasValue ? new double[] { output_ratio.Value.Item1, output_ratio.Value.Item2, output_ratio.Value.Item3 } : null;
                return FractionalMaxPool3d(new long[] { kernel_size.Item1, kernel_size.Item2, kernel_size.Item3 }, pSize, pRatio);
            }

            /// <summary>
            /// Applies a 3d fractional max pooling over an input signal composed of several input planes.
            ///
            /// Fractional MaxPooling is described in detail in the paper Fractional MaxPooling by Ben Graham,
            /// see: https://arxiv.org/abs/1412.6071
            /// </summary>
            /// <param name="kernel_size">The size of the sliding window, must be > 0.</param>
            /// <param name="output_size">The target output size of the image of the form oH x oW. Can be a tuple (oH, oW) or a single number oH for a square image oH x oH</param>
            /// <param name="output_ratio">If one wants to have an output size as a ratio of the input size, this option can be given. This has to be a number or tuple in the range (0, 1)</param>
            /// <returns></returns>
            static public FractionalMaxPool3d FractionalMaxPool3d(long[] kernel_size, long[] output_size = null, double[] output_ratio = null)
            {
                if (kernel_size == null || kernel_size.Length != 3)
                    throw new ArgumentException("Kernel size must contain three elements.");
                if (output_size != null && output_size.Length != 3)
                    throw new ArgumentException("output_size must contain three elements.");
                if (output_ratio != null && output_ratio.Length != 3)
                    throw new ArgumentException("output_ratio must contain three elements.");
                if (output_size == null && output_ratio == null)
                    throw new ArgumentNullException("Only one of output_size and output_ratio may be specified.");
                if (output_size != null && output_ratio != null)
                    throw new ArgumentNullException("FractionalMaxPool3d requires specifying either an output size, or a pooling ratio.");

                unsafe {
                    fixed (long* pkernelSize = kernel_size, pSize = output_size) {
                        fixed (double* pRatio = output_ratio) {
                            var handle = THSNN_FractionalMaxPool3d_ctor(
                                (IntPtr)pkernelSize, kernel_size.Length,
                                (IntPtr)pSize, (output_size == null ? 0 : output_size.Length),
                                (IntPtr)pRatio, (output_ratio == null ? 0 : output_ratio.Length),
                                out var boxedHandle);
                            if (handle == IntPtr.Zero) { torch.CheckForErrors(); }
                            return new FractionalMaxPool3d(handle, boxedHandle, output_ratio != null);
                        }
                    }
                }
            }
        }
    }
}
