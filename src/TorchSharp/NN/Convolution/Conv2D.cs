// Copyright (c) .NET Foundation and Contributors.  All Rights Reserved.  See LICENSE in the project root for license information.
using System;
using System.Runtime.InteropServices;
using static TorchSharp.torch;

#nullable enable
namespace TorchSharp
{
    using Modules;

    namespace Modules
    {
        public class Conv2d : torch.nn.Module
        {
            internal Conv2d(IntPtr handle, IntPtr boxedHandle) : base(handle, boxedHandle) { }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_Conv2d_forward(torch.nn.Module.HType module, IntPtr tensor);

            public override Tensor forward(Tensor tensor)
            {
                var res = THSNN_Conv2d_forward(handle, tensor.Handle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Tensor(res);
            }

            [DllImport("LibTorchSharp")]
            extern static IntPtr THSNN_Conv2d_bias(torch.nn.Module.HType module);
            [DllImport("LibTorchSharp")]
            extern static void THSNN_Conv2d_set_bias(torch.nn.Module.HType module, IntPtr tensor);

            public Parameter? bias {
                get {
                    var res = THSNN_Conv2d_bias(handle);
                    if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                    return ((res == IntPtr.Zero) ? null : new Parameter(res));
                }
                set {
                    THSNN_Conv2d_set_bias(handle, (value is null ? IntPtr.Zero : value.Handle));
                    torch.CheckForErrors();
                    ConditionallyRegisterParameter("bias", value);
                }
            }
            [DllImport("LibTorchSharp")]
            extern static IntPtr THSNN_Conv2d_weight(torch.nn.Module.HType module);
            [DllImport("LibTorchSharp")]
            extern static void THSNN_Conv2d_set_weight(torch.nn.Module.HType module, IntPtr tensor);

            public Parameter weight {
                get {
                    var res = THSNN_Conv2d_weight(handle);
                    if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                    return new Parameter(res);
                }
                set {
                    THSNN_Conv2d_set_weight(handle, value.Handle);
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
            private static extern IntPtr THSNN_Conv2d_ctor(long inputChannel, long outputChannel, long kernelSize, long stride, long padding, long dilation, long paddingMode, long groups, bool bias, out IntPtr pBoxedModule);

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_Conv2d_ctor_1(long inputChannel, long outputChannel, long kernelSizeX, long kernelSizeY, long strideX, long strideY, long paddingX, long paddingY, long dilationX, long dilationY, long paddingMode, long groups, bool bias, out IntPtr pBoxedModule);

            /// <summary>
            /// Applies a 2D convolution over an input signal composed of several input planes
            /// </summary>
            /// <param name="inputChannel">Number of channels in the input image</param>
            /// <param name="outputChannel">Number of channels produced by the convolution</param>
            /// <param name="kernelSize">Size of the convolving kernel</param>
            /// <param name="stride">Stride of the convolution. Default: 1</param>
            /// <param name="padding">Zero-padding added to both sides of the input. Default: 0</param>
            /// <param name="dilation">Spacing between kernel elements. Default: 1</param>
            /// <param name="paddingMode">'zeros', 'reflect', 'replicate' or 'circular'. Default: 'zeros'</param>
            /// <param name="groups">Number of blocked connections from input channels to output channels. Default: 1</param>
            /// <param name="bias">If true, adds a learnable bias to the output. Default: true</param>
            /// <returns></returns>
            static public Conv2d Conv2d(long inputChannel, long outputChannel, long kernelSize, long stride = 1, long padding = 0, long dilation = 1, PaddingModes paddingMode = PaddingModes.Zeros, long groups = 1, bool bias = true)
            {
                var res = THSNN_Conv2d_ctor(inputChannel, outputChannel, kernelSize, stride, padding, dilation, (long)paddingMode, groups, bias, out var boxedHandle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Conv2d(res, boxedHandle);
            }

            /// <summary>
            /// Applies a 2D convolution over an input signal composed of several input planes
            /// </summary>
            /// <param name="inputChannel">Number of channels in the input image</param>
            /// <param name="outputChannel">Number of channels produced by the convolution</param>
            /// <param name="kernelSize">Size of the convolving kernel</param>
            /// <param name="stride">Stride of the convolution. Default: (1,1)</param>
            /// <param name="padding">Zero-padding added to both sides of the input. Default: (0,0)</param>
            /// <param name="dilation">Spacing between kernel elements. Default: (1,1)</param>
            /// <param name="paddingMode">'zeros', 'reflect', 'replicate' or 'circular'. Default: 'zeros'</param>
            /// <param name="groups">Number of blocked connections from input channels to output channels. Default: 1</param>
            /// <param name="bias">If true, adds a learnable bias to the output. Default: true</param>
            /// <returns></returns>
            static public Conv2d Conv2d(long inputChannel, long outputChannel, (long, long) kernelSize, (long, long)? stride = null, (long, long)? padding = null, (long, long)? dilation = null, PaddingModes paddingMode = PaddingModes.Zeros, long groups = 1, bool bias = true)
            {
                if (stride == null) stride = (1, 1);
                if (padding == null) padding = (0, 0);
                if (dilation == null) dilation = (1, 1);

                var res = THSNN_Conv2d_ctor_1(inputChannel, outputChannel, kernelSize.Item1, kernelSize.Item2, stride.Value.Item1, stride.Value.Item2, padding.Value.Item1, padding.Value.Item2, dilation.Value.Item1, dilation.Value.Item2, (long)paddingMode, groups, bias, out var boxedHandle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Conv2d(res, boxedHandle);
            }

            /// <summary>
            /// Applies a 2D convolution over an input signal composed of several input planes
            /// </summary>
            /// <param name="inputChannel">Number of channels in the input image</param>
            /// <param name="outputChannel">Number of channels produced by the convolution</param>
            /// <param name="kernelSize">Size of the convolving kernel</param>
            /// <param name="stride">Stride of the convolution. Default: 1</param>
            /// <param name="padding">Zero-padding added to both sides of the input. padding=Valid is the same as no padding. padding=Same pads the input so the output has the shape as the input. </param>
            /// <param name="dilation">Spacing between kernel elements. Default: 1</param>
            /// <param name="paddingMode">'zeros', 'reflect', 'replicate' or 'circular'. Default: 'zeros'</param>
            /// <param name="groups">Number of blocked connections from input channels to output channels. Default: 1</param>
            /// <param name="bias">If true, adds a learnable bias to the output. Default: true</param>
            /// <returns></returns>
            static public Conv2d Conv2d(long inputChannel, long outputChannel, long kernelSize, Padding padding, long stride = 1, long dilation = 1, PaddingModes paddingMode = PaddingModes.Zeros, long groups = 1, bool bias = true)
            {
                var res = THSNN_Conv2d_ctor(inputChannel, outputChannel, kernelSize, stride, padding == Padding.Valid ? 0 : -1, dilation, (long)paddingMode, groups, bias, out var boxedHandle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Conv2d(res, boxedHandle);
            }

            /// <summary>
            /// Applies a 2D convolution over an input signal composed of several input planes
            /// </summary>
            /// <param name="inputChannel">Number of channels in the input image</param>
            /// <param name="outputChannel">Number of channels produced by the convolution</param>
            /// <param name="kernelSize">Size of the convolving kernel</param>
            /// <param name="padding">Zero-padding added to both sides of the input. padding=Valid is the same as no padding. padding=Same pads the input so the output has the shape as the input. </param>
            /// <param name="stride">Stride of the convolution. Default: (1,1)</param>
            /// <param name="dilation">Spacing between kernel elements. Default: (1,1)</param>
            /// <param name="paddingMode">'zeros', 'reflect', 'replicate' or 'circular'. Default: 'zeros'</param>
            /// <param name="groups">Number of blocked connections from input channels to output channels. Default: 1</param>
            /// <param name="bias">If true, adds a learnable bias to the output. Default: true</param>
            /// <returns></returns>
            static public Conv2d Conv2d(long inputChannel, long outputChannel, (long, long) kernelSize, Padding padding, (long, long)? stride = null, (long, long)? dilation = null, PaddingModes paddingMode = PaddingModes.Zeros, long groups = 1, bool bias = true)
            {
                if (stride == null) stride = (1, 1);
                if (dilation == null) dilation = (1, 1);

                var res = THSNN_Conv2d_ctor_1(inputChannel, outputChannel, kernelSize.Item1, kernelSize.Item2, stride.Value.Item1, stride.Value.Item2, padding == Padding.Valid ? 0 : -1, 0, dilation.Value.Item1, dilation.Value.Item2, (long)paddingMode, groups, bias, out var boxedHandle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Conv2d(res, boxedHandle);
            }
        }
    }
}
