// Copyright (c) .NET Foundation and Contributors.  All Rights Reserved.  See LICENSE in the project root for license information.
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TorchSharp.torchvision.Modules;
using static TorchSharp.torch;
using static TorchSharp.torch.nn;
using static TorchSharp.torch.utils.data;

namespace TorchSharp.torchvision
{
    public static partial class models
    {
        /// <summary>
        /// ResNet-18
        /// </summary>
        /// <param name="num_classes">The number of output classes.</param>
        /// <param name="weights_file">The location of a file containing pre-trained weights for the model.</param>
        /// <param name="skipfc">If true, the last linear layer of the classifier will not be loaded from the weights file.</param>
        /// <param name="device">The device to locate the model on.</param>
        /// <remarks>
        /// Pre-trained weights may be retrieved by using Pytorch and saving the model state-dict
        /// using the exportsd.py script, then loading into the .NET instance:
        ///
        /// from torchvision import models
        /// import exportsd
        /// 
        /// model = models.resnet18(pretrained=True)
        /// f = open("model_weights.dat", "wb")
        /// exportsd.save_state_dict(model.state_dict(), f)
        /// f.close()
        ///
        /// See also: https://github.com/dotnet/TorchSharp/blob/main/docfx/articles/saveload.md
        ///
        /// In order for the weights to be loaded, the number of classes has to be the same as
        /// in the pre-trained model, which is 1000.
        ///
        /// It is also possible to skip loading the last linear layer and use it for transfer-learning
        /// with a different number of output classes. To do so, pass skipfc=true.
        ///
        /// All pre-trained models expect input images normalized in the same way, i.e. mini-batches of 3-channel RGB
        /// images of shape (3 x H x W), where H and W are expected to be at least 224. The images have to be loaded
        /// in to a range of [0, 1] and then normalized using mean = [0.485, 0.456, 0.406] and std = [0.229, 0.224, 0.225].
        /// </remarks>
        public static Modules.ResNet resnet18(int num_classes = 1000,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
        {
            return Modules.ResNet.ResNet18(num_classes, weights_file, skipfc, device);
        }

        /// <summary>
        /// ResNet-34
        /// </summary>
        /// <param name="num_classes">The number of output classes.</param>
        /// <param name="weights_file">The location of a file containing pre-trained weights for the model.</param>
        /// <param name="skipfc">If true, the last linear layer of the classifier will not be loaded from the weights file.</param>
        /// <param name="device">The device to locate the model on.</param>
        /// <remarks>
        /// Pre-trained weights may be retrieved by using Pytorch and saving the model state-dict
        /// using the exportsd.py script, then loading into the .NET instance:
        ///
        /// from torchvision import models
        /// import exportsd
        /// 
        /// model = models.resnet34(pretrained=True)
        /// f = open("model_weights.dat", "wb")
        /// exportsd.save_state_dict(model.state_dict(), f)
        /// f.close()
        ///
        /// See also: https://github.com/dotnet/TorchSharp/blob/main/docfx/articles/saveload.md
        ///
        /// In order for the weights to be loaded, the number of classes has to be the same as
        /// in the pre-trained model, which is 1000.
        ///
        /// It is also possible to skip loading the last linear layer and use it for transfer-learning
        /// with a different number of output classes. To do so, pass skipfc=true.
        ///
        /// All pre-trained models expect input images normalized in the same way, i.e. mini-batches of 3-channel RGB
        /// images of shape (3 x H x W), where H and W are expected to be at least 224. The images have to be loaded
        /// in to a range of [0, 1] and then normalized using mean = [0.485, 0.456, 0.406] and std = [0.229, 0.224, 0.225].
        /// </remarks>
        public static Modules.ResNet resnet34(int num_classes = 1000,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
        {
            return Modules.ResNet.ResNet34(num_classes, weights_file, skipfc, device);
        }

        /// <summary>
        /// ResNet-50
        /// </summary>
        /// <param name="num_classes">The number of output classes.</param>
        /// <param name="weights_file">The location of a file containing pre-trained weights for the model.</param>
        /// <param name="skipfc">If true, the last linear layer of the classifier will not be loaded from the weights file.</param>
        /// <param name="device">The device to locate the model on.</param>
        /// <remarks>
        /// Pre-trained weights may be retrieved by using Pytorch and saving the model state-dict
        /// using the exportsd.py script, then loading into the .NET instance:
        ///
        /// from torchvision import models
        /// import exportsd
        /// 
        /// model = models.resnet50(pretrained=True)
        /// f = open("model_weights.dat", "wb")
        /// exportsd.save_state_dict(model.state_dict(), f)
        /// f.close()
        ///
        /// See also: https://github.com/dotnet/TorchSharp/blob/main/docfx/articles/saveload.md
        ///
        /// In order for the weights to be loaded, the number of classes has to be the same as
        /// in the pre-trained model, which is 1000.
        ///
        /// It is also possible to skip loading the last linear layer and use it for transfer-learning
        /// with a different number of output classes. To do so, pass skipfc=true.
        ///
        /// All pre-trained models expect input images normalized in the same way, i.e. mini-batches of 3-channel RGB
        /// images of shape (3 x H x W), where H and W are expected to be at least 224. The images have to be loaded
        /// in to a range of [0, 1] and then normalized using mean = [0.485, 0.456, 0.406] and std = [0.229, 0.224, 0.225].
        /// </remarks>
        public static Modules.ResNet resnet50(int num_classes = 1000,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
        {
            return Modules.ResNet.ResNet50(num_classes, weights_file, skipfc, device);
        }

        /// <summary>
        /// ResNet-101
        /// </summary>
        /// <param name="num_classes">The number of output classes.</param>
        /// <param name="weights_file">The location of a file containing pre-trained weights for the model.</param>
        /// <param name="skipfc">If true, the last linear layer of the classifier will not be loaded from the weights file.</param>
        /// <param name="device">The device to locate the model on.</param>
        /// <remarks>
        /// Pre-trained weights may be retrieved by using Pytorch and saving the model state-dict
        /// using the exportsd.py script, then loading into the .NET instance:
        ///
        /// from torchvision import models
        /// import exportsd
        /// 
        /// model = models.resnet101(pretrained=True)
        /// f = open("model_weights.dat", "wb")
        /// exportsd.save_state_dict(model.state_dict(), f)
        /// f.close()
        ///
        /// See also: https://github.com/dotnet/TorchSharp/blob/main/docfx/articles/saveload.md
        ///
        /// In order for the weights to be loaded, the number of classes has to be the same as
        /// in the pre-trained model, which is 1000.
        ///
        /// It is also possible to skip loading the last linear layer and use it for transfer-learning
        /// with a different number of output classes. To do so, pass skipfc=true.
        ///
        /// All pre-trained models expect input images normalized in the same way, i.e. mini-batches of 3-channel RGB
        /// images of shape (3 x H x W), where H and W are expected to be at least 224. The images have to be loaded
        /// in to a range of [0, 1] and then normalized using mean = [0.485, 0.456, 0.406] and std = [0.229, 0.224, 0.225].
        /// </remarks>
        public static Modules.ResNet resnet101(int num_classes = 1000,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
        {
            return Modules.ResNet.ResNet101(num_classes, weights_file, skipfc, device);
        }

        /// <summary>
        /// ResNet-152
        /// </summary>
        /// <param name="num_classes">The number of output classes.</param>
        /// <param name="weights_file">The location of a file containing pre-trained weights for the model.</param>
        /// <param name="skipfc">If true, the last linear layer of the classifier will not be loaded from the weights file.</param>
        /// <param name="device">The device to locate the model on.</param>
        /// <remarks>
        /// Pre-trained weights may be retrieved by using Pytorch and saving the model state-dict
        /// using the exportsd.py script, then loading into the .NET instance:
        ///
        /// from torchvision import models
        /// import exportsd
        /// 
        /// model = models.resnet152(pretrained=True)
        /// f = open("model_weights.dat", "wb")
        /// exportsd.save_state_dict(model.state_dict(), f)
        /// f.close()
        ///
        /// See also: https://github.com/dotnet/TorchSharp/blob/main/docfx/articles/saveload.md
        ///
        /// In order for the weights to be loaded, the number of classes has to be the same as
        /// in the pre-trained model, which is 1000.
        ///
        /// It is also possible to skip loading the last linear layer and use it for transfer-learning
        /// with a different number of output classes. To do so, pass skipfc=true.
        ///
        /// All pre-trained models expect input images normalized in the same way, i.e. mini-batches of 3-channel RGB
        /// images of shape (3 x H x W), where H and W are expected to be at least 224. The images have to be loaded
        /// in to a range of [0, 1] and then normalized using mean = [0.485, 0.456, 0.406] and std = [0.229, 0.224, 0.225].
        /// </remarks>
        public static Modules.ResNet resnet152(int num_classes = 1000,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
        {
            return Modules.ResNet.ResNet152(num_classes, weights_file, skipfc, device);
        }
    }

    namespace Modules
    {
        public class ResNet : Module
        {
            // The code here is based on
            // https://github.com/pytorch/vision/blob/main/torchvision/models/resnet.py
            // Licence and copypright notice at: https://github.com/pytorch/vision/blob/main/LICENSE

            private readonly Module conv1;
            private readonly Module bn1;
            private readonly Module relu1;

            private readonly TorchSharp.Modules.ModuleList layer1 = new TorchSharp.Modules.ModuleList();
            private readonly TorchSharp.Modules.ModuleList layer2 = new TorchSharp.Modules.ModuleList();
            private readonly TorchSharp.Modules.ModuleList layer3 = new TorchSharp.Modules.ModuleList();
            private readonly TorchSharp.Modules.ModuleList layer4 = new TorchSharp.Modules.ModuleList();

            private readonly Module avgpool;
            private readonly Module maxpool;
            private readonly Module flatten;
            private readonly Module fc;


            private int in_planes = 64;

            public static ResNet ResNet18(int numClasses,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
            {
                return new ResNet(
                    "ResNet18",
                    (in_planes, planes, stride) => new BasicBlock(in_planes, planes, stride),
                    BasicBlock.expansion, new int[] { 2, 2, 2, 2 },
                    numClasses,
                    weights_file,
                    skipfc,
                    device);
            }

            public static ResNet ResNet34(int numClasses,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
            {
                return new ResNet(
                    "ResNet34",
                    (in_planes, planes, stride) => new BasicBlock(in_planes, planes, stride),
                    BasicBlock.expansion, new int[] { 3, 4, 6, 3 },
                    numClasses,
                    weights_file,
                    skipfc,
                    device);
            }

            public static ResNet ResNet50(int numClasses,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
            {
                return new ResNet(
                    "ResNet50",
                    (in_planes, planes, stride) => new Bottleneck(in_planes, planes, stride),
                    Bottleneck.expansion, new int[] { 3, 4, 6, 3 },
                    numClasses,
                    weights_file,
                    skipfc,
                    device);
            }

            public static ResNet ResNet101(int numClasses,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
            {
                return new ResNet(
                    "ResNet101",
                    (in_planes, planes, stride) => new Bottleneck(in_planes, planes, stride),
                    Bottleneck.expansion, new int[] { 3, 4, 23, 3 },
                    numClasses,
                    weights_file,
                    skipfc,
                    device);
            }

            public static ResNet ResNet152(int numClasses,
                string weights_file = null,
                bool skipfc = true,
                Device device = null)
            {
                return new ResNet(
                    "ResNet152",
                    (in_planes, planes, stride) => new Bottleneck(in_planes, planes, stride),
                    Bottleneck.expansion, new int[] { 3, 8, 36, 3 },
                    numClasses,
                    weights_file,
                    skipfc,
                    device);
            }

            public ResNet(string name,
                Func<int, int, int, Module> block,
                int expansion, IList<int> num_blocks,
                int numClasses,
                string weights_file = null,
                bool skipfc = true,
                Device device = null) : base(name)
            {
                var modules = new List<(string, Module)>();

                conv1 = Conv2d(3, 64, kernelSize: 7, stride: 2, padding: 3, bias: false);
                bn1 = BatchNorm2d(64);
                relu1 = ReLU(inPlace: true);
                maxpool = MaxPool2d(kernelSize: 2, stride: 2, padding: 1);
                MakeLayer(layer1, block, expansion, 64, num_blocks[0], 1);
                MakeLayer(layer2, block, expansion, 128, num_blocks[1], 2);
                MakeLayer(layer3, block, expansion, 256, num_blocks[2], 2);
                MakeLayer(layer4, block, expansion, 512, num_blocks[3], 2);
                avgpool = nn.AdaptiveAvgPool2d(new long[] { 1, 1 });
                flatten = Flatten();
                fc = Linear(512 * expansion, numClasses);

                RegisterComponents();

                if (string.IsNullOrEmpty(weights_file)) {

                    foreach (var (_, m) in named_modules()) {
                        switch (m) {
                        // This test must come before the Tensor test
                        case TorchSharp.Modules.Conv2d conv:
                            torch.nn.init.kaiming_normal_(conv.weight, mode: init.FanInOut.FanOut, nonlinearity: init.NonlinearityType.ReLU);
                            break;
                        case TorchSharp.Modules.BatchNorm2d bn:
                            torch.nn.init.constant_(bn.weight, 1);
                            torch.nn.init.constant_(bn.bias, 0);
                            break;
                        }
                    }
                }
                else {

                    this.load(weights_file, skip: skipfc ? new[] { "fc.weight", "fc.bias" } : null);
                }

                if (device != null && device.type == DeviceType.CUDA)
                    this.to(device);
            }

            private void MakeLayer(TorchSharp.Modules.ModuleList modules, Func<int, int, int, Module> block, int expansion, int planes, int num_blocks, int stride)
            {
                var strides = new List<int>();
                strides.Add(stride);
                for (var i = 0; i < num_blocks - 1; i++) { strides.Add(1); }

                for (var i = 0; i < strides.Count; i++) {
                    var s = strides[i];
                    modules.Add(block(in_planes, planes, s));
                    in_planes = planes * expansion;
                }
            }

            public override Tensor forward(Tensor input)
            {
                using (var scope = NewDisposeScope()) {

                    var x = maxpool.forward(relu1.forward(bn1.forward(conv1.forward(input))));

                    foreach (var m in layer1) x = m.forward(x);
                    foreach (var m in layer2) x = m.forward(x);
                    foreach (var m in layer3) x = m.forward(x);
                    foreach (var m in layer4) x = m.forward(x);

                    var res = fc.forward(flatten.forward(avgpool.forward(x)));
                    scope.MoveToOuter(res);
                    return res;
                }
            }

            class BasicBlock : Module
            {
                public BasicBlock(int in_planes, int planes, int stride) : base("BasicBlock")
                {
                    var modules = new List<(string, Module)>();

                    conv1 = Conv2d(in_planes, planes, kernelSize: 3, stride: stride, padding: 1, bias: false);
                    bn1 = BatchNorm2d(planes);
                    relu1 = ReLU(inPlace: true);
                    conv2 = Conv2d(planes, planes, kernelSize: 3, stride: 1, padding: 1, bias: false);
                    bn2 = BatchNorm2d(planes);

                    if (stride != 1 || in_planes != expansion * planes) {
                        downsample.Add(Conv2d(in_planes, expansion * planes, kernelSize: 1, stride: stride, bias: false));
                        downsample.Add(BatchNorm2d(expansion * planes));
                    }

                    torch.nn.init.constant_(bn2.weight, 1);

                    RegisterComponents();
                }

                public override Tensor forward(Tensor input)
                {
                    var x = relu1.forward(bn1.forward(conv1.forward(input)));
                    x = bn2.forward(conv2.forward(x));

                    var y = input;
                    foreach (var m in downsample) y = m.forward(y);
                    return x.add_(y).relu_();
                }

                public static int expansion = 1;

                private readonly Module conv1;
                private readonly Module bn1;
                private readonly Module conv2;
                private readonly TorchSharp.Modules.BatchNorm2d bn2;
                private readonly Module relu1;
                private readonly TorchSharp.Modules.ModuleList downsample = new TorchSharp.Modules.ModuleList();
            }

            class Bottleneck : Module
            {
                public Bottleneck(int in_planes, int planes, int stride) : base("Bottleneck")
                {
                    var modules = new List<(string, Module)>();

                    conv1 = Conv2d(in_planes, planes, kernelSize: 1, bias: false);
                    bn1 = BatchNorm2d(planes);
                    relu1 = ReLU(inPlace: true);
                    conv2 = Conv2d(planes, planes, kernelSize: 3, stride: stride, padding: 1, bias: false);
                    bn2 = BatchNorm2d(planes);
                    relu2 = ReLU(inPlace: true);
                    conv3 = Conv2d(planes, expansion * planes, kernelSize: 1, bias: false);
                    bn3 = BatchNorm2d(expansion * planes);

                    if (stride != 1 || in_planes != expansion * planes) {
                        downsample.Add(Conv2d(in_planes, expansion * planes, kernelSize: 1, stride: stride, bias: false));
                        downsample.Add(BatchNorm2d(expansion * planes));
                    }

                    torch.nn.init.constant_(bn3.weight, 1);

                    RegisterComponents();
                }

                public override Tensor forward(Tensor input)
                {
                    var x = relu1.forward(bn1.forward(conv1.forward(input)));
                    x = relu2.forward(bn2.forward(conv2.forward(input)));
                    x = bn3.forward(conv3.forward(x));

                    var y = input;
                    foreach (var m in downsample) y = m.forward(y);

                    return x.add_(y).relu_();
                }

                public static int expansion = 4;

                private readonly Module conv1;
                private readonly Module bn1;
                private readonly Module conv2;
                private readonly Module bn2;
                private readonly Module conv3;
                private readonly TorchSharp.Modules.BatchNorm2d bn3;
                private readonly Module relu1;
                private readonly Module relu2;

                private readonly TorchSharp.Modules.ModuleList downsample = new TorchSharp.Modules.ModuleList();
            }
        }
    }
}
