using System;
using ObjCRuntime;

[assembly: LinkWith("libTOCropViewControllerExample.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
//[assembly: LinkWith("libTOCropViewControllerExample.a", LinkTarget.Simulator | LinkTarget.Arm64, ForceLoad = true)]
