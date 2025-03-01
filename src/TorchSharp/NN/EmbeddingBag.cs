// Copyright (c) .NET Foundation and Contributors.  All Rights Reserved.  See LICENSE in the project root for license information.
using System;
using System.Runtime.InteropServices;
using static TorchSharp.torch;

namespace TorchSharp
{
    using Modules;

    public enum EmbeddingBagMode
    {
        Sum = 0,
        Mean = 1,
        Max = 2
    }

    namespace Modules
    {
        public class EmbeddingBag : torch.nn.Module
        {
            internal EmbeddingBag(IntPtr handle, IntPtr boxedHandle) : base(handle, boxedHandle) { }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_EmbeddingBag_forward(torch.nn.Module.HType module, IntPtr tensor, IntPtr offsets, IntPtr per_sample_weights);

            /// <summary>
            /// Forward pass of EmbeddingBag.
            /// </summary>
            /// <param name="input">Tensor containing bags of indices into the embedding matrix.</param>
            /// <param name="offsets">Only used when input is 1D. offsets determines the starting index position of each bag (sequence) in input.</param>
            /// <param name="perSampleWeights">a tensor of float / double weights, or None to indicate all weights should be taken to be 1.
            /// If specified, per_sample_weights must have exactly the same shape as input and is treated as having the same offsets, if those are not None.
            /// Only supported for mode='sum'.</param>
            /// <returns></returns>
            public override Tensor forward(Tensor input, Tensor offsets, Tensor perSampleWeights)
            {
                if (!input.IsIntegral()) throw new ArgumentException("Embedding input must be an integral tensor.");
                if (!(offsets is null) && input.dtype != offsets.dtype) throw new ArgumentException("input and offsets must have the same element type.");
                if (input.Dimensions == 1 && offsets is null) throw new ArgumentException("'offsets' must be non-null for a 1-D input.");
                if (input.Dimensions == 2 && !(offsets is null)) throw new ArgumentException("'offsets' must be null for a 2-D input.");

                if (input.Dimensions == 2 && input.dtype == ScalarType.Int32) throw new NotImplementedException("EmbeddingBag for 32-bit integers -- there's some issue in the native runtime that prevents this from working.");

                var res = THSNN_EmbeddingBag_forward(handle, input.Handle, (offsets is null) ? IntPtr.Zero : offsets.Handle, (perSampleWeights is null) ? IntPtr.Zero : perSampleWeights.Handle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Tensor(res);
            }

            /// <summary>
            /// Forward pass of EmbeddingBag.
            /// </summary>
            /// <param name="input">Tensor containing bags of indices into the embedding matrix.</param>
            /// <param name="offsets">Only used when input is 1D. offsets determines the starting index position of each bag (sequence) in input.</param>
            /// <returns></returns>
            public override Tensor forward(Tensor input, Tensor offsets)
            {
                if (!input.IsIntegral()) throw new ArgumentException("Embedding input must be an integral tensor.");
                if (!(offsets is null) && input.dtype != offsets.dtype) throw new ArgumentException("input and offsets must have the same element type.");
                if (input.Dimensions == 1 && offsets is null) throw new ArgumentException("'offsets' must be non-null for a 1-D input.");
                if (input.Dimensions == 2 && !(offsets is null)) throw new ArgumentException("'offsets' must be null for a 2-D input.");

                if (input.Dimensions == 2 && input.dtype == ScalarType.Int32) throw new NotImplementedException("EmbeddingBag for 32-bit integers -- there's some issue in the native runtime that prevents this from working.");

                var res = THSNN_EmbeddingBag_forward(handle, input.Handle, (offsets is null) ? IntPtr.Zero : offsets.Handle, IntPtr.Zero);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Tensor(res);
            }

            /// <summary>
            /// Forward pass of EmbeddingBag.
            /// </summary>
            /// <param name="input">Tensor containing bags of indices into the embedding matrix.</param>
            /// <returns></returns>
            public override Tensor forward(Tensor input)
            {
                if (!input.IsIntegral()) throw new ArgumentException("Embedding input must be an integral tensor.");
                if (input.Dimensions == 1) throw new ArgumentException("'offsets' must be non-null for a 1-D input.");

                if (input.Dimensions == 2 && input.dtype == ScalarType.Int32) throw new NotImplementedException("EmbeddingBag for 32-bit integers -- there's some issue in the native runtime that prevents this from working.");

                var res = THSNN_EmbeddingBag_forward(handle, input.Handle, IntPtr.Zero, IntPtr.Zero);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Tensor(res);
            }

            [DllImport("LibTorchSharp")]
            extern static IntPtr THSNN_EmbeddingBag_weight(torch.nn.Module.HType module);

            [DllImport("LibTorchSharp")]
            extern static void THSNN_EmbeddingBag_set_weight(torch.nn.Module.HType module, IntPtr tensor);

            public Parameter weight {
                get {
                    var res = THSNN_EmbeddingBag_weight(handle);
                    if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                    return new Parameter(res);
                }
                set {
                    THSNN_EmbeddingBag_set_weight(handle, value.Handle);
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
            private static extern IntPtr THSNN_EmbeddingBag_ctor(long num_embeddings, long embedding_dims, double max_norm, bool hasMN, double norm_type, bool scale_grad_by_freq, long mode, bool sparse, bool include_last_offset, long padding_idx, out IntPtr pBoxedModule);

            /// <summary>
            /// A simple lookup table that stores embeddings of a fixed dictionary and size.
            /// This module is often used to store word embeddings and retrieve them using indices. The input to the module is a list of indices, and the output is the corresponding word embeddings.
            /// </summary>
            /// <param name="num_embeddings">Size of the dictionary of embeddings, the vocabulary size.</param>
            /// <param name="embedding_dims">The size of each embedding vector</param>
            /// <param name="max_norm">If given, each embedding vector with norm larger than max_norm is renormalized to have norm max_norm.</param>
            /// <param name="norm_type">The p of the p-norm to compute for the max_norm option. Default 2.</param>
            /// <param name="scale_grad_by_freq">If given, this will scale gradients by the inverse of frequency of the words in the mini-batch. Default: false.</param>
            /// <param name="mode">"sum", "mean" or "max". Specifies the way to reduce the bag.
            /// "sum" computes the weighted sum, taking per_sample_weights into consideration.
            /// "mean" computes the average of the values in the bag, "max" computes the max value over each bag. Default: "mean"</param>
            /// <param name="sparse">If true, gradient w.r.t. weight matrix will be a sparse tensor. Default: false</param>
            /// <param name="include_last_offset">If true, offsets has one additional element, where the last element is equivalent to the size of indices. This matches the CSR format.</param>
            /// <param name="padding_index"> If specified, the entries at padding_idx do not contribute to the gradient; therefore, the embedding vector at padding_idx is not updated during training, i.e. it remains as a fixed “pad”. For a newly constructed EmbeddingBag, the embedding vector at padding_idx will default to all zeros, but can be updated to another value to be used as the padding vector. Note that the embedding vector at padding_idx is excluded from the reduction.</param>
            /// <returns></returns>
            /// <remarks>Keep in mind that only a limited number of optimizers support sparse gradients: currently it’s optim.SGD (CUDA and CPU), optim.SparseAdam (CUDA and CPU) and optim.Adagrad (CPU)</remarks>
            static public EmbeddingBag EmbeddingBag(long num_embeddings, long embedding_dims, double? max_norm = null, double norm_type = 2.0, bool scale_grad_by_freq = false, EmbeddingBagMode mode = EmbeddingBagMode.Mean, bool sparse = false, bool include_last_offset = false, long padding_index = -1)
            {
                var res = THSNN_EmbeddingBag_ctor(num_embeddings, embedding_dims,
                    max_norm.HasValue ? max_norm.Value : 0.0, max_norm.HasValue,
                    norm_type, scale_grad_by_freq, (long)mode, sparse, include_last_offset, padding_index, out var boxedHandle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new EmbeddingBag(res, boxedHandle);
            }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_EmbeddingBag_from_pretrained(IntPtr embeddings, bool freeze, double max_norm, bool hasMN, double norm_type, bool scale_grad_by_freq, long mode, bool sparse, bool include_last_offset, long padding_idx, out IntPtr pBoxedModule);

            /// <summary>
            /// A simple lookup table that stores embeddings of a fixed dictionary and size.
            /// This module is often used to store word embeddings and retrieve them using indices. The input to the module is a list of indices, and the output is the corresponding word embeddings.
            /// </summary>
            /// <param name="embeddings">FloatTensor containing weights for the EmbeddingBag in two dimensions. First dimension is being passed to EmbeddingBag as num_embeddings, second as embedding_dim.</param>
            /// <param name="freeze">If true (the default), the tensor does not get updated in the learning</param>
            /// <param name="max_norm">If given, each embedding vector with norm larger than max_norm is renormalized to have norm max_norm.</param>
            /// <param name="norm_type">The p of the p-norm to compute for the max_norm option. Default 2.</param>
            /// <param name="scale_grad_by_freq">If given, this will scale gradients by the inverse of frequency of the words in the mini-batch. Default: false.</param>
            /// <param name="mode"></param>
            /// <param name="sparse">If true, gradient w.r.t. weight matrix will be a sparse tensor. Default: false</param>
            /// <param name="include_last_offset">If true, offsets has one additional element, where the last element is equivalent to the size of indices. This matches the CSR format.</param>
            /// <param name="padding_index"> If specified, the entries at padding_idx do not contribute to the gradient; therefore, the embedding vector at padding_idx is not updated during training, i.e. it remains as a fixed “pad”. For a newly constructed EmbeddingBag, the embedding vector at padding_idx will default to all zeros, but can be updated to another value to be used as the padding vector. Note that the embedding vector at padding_idx is excluded from the reduction.</param>
            /// <returns></returns>
            /// <remarks>Keep in mind that only a limited number of optimizers support sparse gradients: currently it’s optim.SGD (CUDA and CPU), optim.SparseAdam (CUDA and CPU) and optim.Adagrad (CPU)</remarks>
            public static EmbeddingBag EmbeddingBag_from_pretrained(Tensor embeddings, bool freeze = true, double? max_norm = null, double norm_type = 2.0, bool scale_grad_by_freq = false, EmbeddingBagMode mode = EmbeddingBagMode.Mean, bool sparse = false, bool include_last_offset = false, long padding_index = -1)
            {
                var res = THSNN_EmbeddingBag_from_pretrained(embeddings.Handle, freeze,
                    max_norm.HasValue ? max_norm.Value : 0.0, max_norm.HasValue,
                    norm_type, scale_grad_by_freq, (long)mode, sparse, include_last_offset, padding_index, out var boxedHandle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new EmbeddingBag(res, boxedHandle);

            }
        }
    }
}
