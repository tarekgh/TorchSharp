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
        /// This class is used to represent a MaxUnpool1D module.
        /// </summary>
        public class MaxUnpool1d : torch.nn.Module
        {
            internal MaxUnpool1d(IntPtr handle, IntPtr boxedHandle) : base(handle, boxedHandle)
            {
            }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_MaxUnpool1d_forward(torch.nn.Module.HType module, IntPtr tensor, IntPtr indices, IntPtr outSize);

            public Tensor forward(Tensor tensor, Tensor indices, long[] output_size = null)
            {
                unsafe {
                    fixed (long* pOutSize = output_size) {
                        var res = THSNN_MaxUnpool1d_forward(handle, tensor.Handle, indices.Handle, (IntPtr)pOutSize);
                        if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                        return new Tensor(res);
                    }
                }
            }
        }
    }

    public static partial class torch
    {
        public static partial class nn
        {
            [DllImport("LibTorchSharp")]
            extern static IntPtr THSNN_MaxUnpool1d_ctor(IntPtr pkernelSize, IntPtr pStrides, IntPtr pPadding, out IntPtr pBoxedModule);

            /// <summary>
            /// Applies a 1D max pooling over an input signal composed of several input planes.
            /// </summary>
            /// <param name="kernelSize">The size of the sliding window, must be > 0.</param>
            /// <param name="stride">The stride of the sliding window, must be > 0. Default value is kernel_size.</param>
            /// <param name="padding">Implicit negative infinity padding to be added on both sides, must be >= 0 and less than or equal to kernel_size / 2</param>
            /// <returns></returns>
            static public MaxUnpool1d MaxUnpool1d(long kernelSize, long? stride = null, long? padding = null)
            {
                var pStride = stride.HasValue ? new long[] { stride.Value } : null;
                var pPadding = padding.HasValue ? new long[] { padding.Value } : null;
                return MaxUnpool1d(new long[] { kernelSize }, pStride, pPadding);
            }

            static private MaxUnpool1d MaxUnpool1d(long[] kernelSize, long[] strides = null, long[] padding = null)
            {
                unsafe {
                    fixed (long* pkernelSize = kernelSize, pstrides = strides, pPadding = padding) {
                        var handle = THSNN_MaxUnpool1d_ctor((IntPtr)pkernelSize, (IntPtr)pstrides, (IntPtr)pPadding, out var boxedHandle);
                        if (handle == IntPtr.Zero) { torch.CheckForErrors(); }
                        return new MaxUnpool1d(handle, boxedHandle);
                    }
                }
            }
        }
    }
}
