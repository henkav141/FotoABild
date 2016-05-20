using System;
using ObjCRuntime;

namespace CropBindingiOS
{
    [Native]
    public enum TOCropViewControllerAspectRatio : long
    {
        TOCropViewControllerAspectRatio15x10,
        TOCropViewControllerAspectRatio15x11,
        TOCropViewControllerAspectRatio18x13,
        TOCropViewControllerAspectRatio21x15,
        TOCropViewControllerAspectRatio24x18,
        TOCropViewControllerAspectRatio30x20,
        TOCropViewControllerAspectRatio30x24,
        TOCropViewControllerAspectRatio38x25
    }

    [Native]
    public enum TOCropViewControllerToolbarPosition : long
    {
        Top,
        Bottom
    }
}