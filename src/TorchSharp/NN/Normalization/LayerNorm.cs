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
        /// This class is used to represent a LayerNorm module.
        /// </summary>
        public class LayerNorm : torch.nn.Module
        {
            internal LayerNorm(IntPtr handle, IntPtr boxedHandle) : base(handle, boxedHandle)
            {
            }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_LayerNorm_forward(IntPtr module, IntPtr tensor);

            public override Tensor forward(Tensor tensor)
            {
                var res = THSNN_LayerNorm_forward(handle.DangerousGetHandle(), tensor.Handle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Tensor(res);
            }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_LayerNorm_bias(torch.nn.Module.HType module);
            [DllImport("LibTorchSharp")]
            private static extern void THSNN_LayerNorm_set_bias(torch.nn.Module.HType module, IntPtr bias);
            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_LayerNorm_weight(torch.nn.Module.HType module);
            [DllImport("LibTorchSharp")]
            private static extern void THSNN_LayerNorm_set_weight(torch.nn.Module.HType module, IntPtr weight);

            public Parameter bias {
                get {
                    var res = THSNN_LayerNorm_bias(handle);
                    if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                    return new Parameter(res);
                }
                set {
                    THSNN_LayerNorm_set_bias(handle, (value is null ? IntPtr.Zero : value.Handle));
                    torch.CheckForErrors();
                    ConditionallyRegisterParameter("bias", value);
                }
            }

            public Parameter weight {
                get {
                    var res = THSNN_LayerNorm_weight(handle);
                    if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                    return new Parameter(res);
                }
                set {
                    THSNN_LayerNorm_set_weight(handle, value.Handle);
                    torch.CheckForErrors();
                    ConditionallyRegisterParameter("weight", value);
                }
            }
        }
    }

    public static partial class torch
    {
        public static partial class nn
        {
            [DllImport("LibTorchSharp")]
            extern static IntPtr THSNN_LayerNorm_ctor(IntPtr norm_shape, long norm_shape_len, double eps, [MarshalAs(UnmanagedType.U1)] bool elementwise_affine, out IntPtr pBoxedModule);

            /// <summary>
            /// Applies Layer Normalization over a mini-batch of inputs as described in the paper Layer Normalization
            /// </summary>
            /// <returns></returns>
            static public LayerNorm LayerNorm(long[] normalizedShape, double eps = 1e-05, bool elementwiseAffine = true)
            {
                unsafe {
                    fixed (long* pNormShape = normalizedShape) {
                        var handle = THSNN_LayerNorm_ctor((IntPtr)pNormShape, normalizedShape.Length, eps, elementwiseAffine, out var boxedHandle);
                        if (handle == IntPtr.Zero) { torch.CheckForErrors(); }
                        return new LayerNorm(handle, boxedHandle);
                    }
                }
            }
        }
    }
}
