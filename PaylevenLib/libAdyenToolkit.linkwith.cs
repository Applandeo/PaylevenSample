using System;
using ObjCRuntime;

[assembly: LinkWith ("libAdyenToolkit.a", 
	LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true,
	Frameworks = "CoreFoundation CoreText UIKit Foundation CoreLocation ExternalAccessory SystemConfiguration CoreGraphics", 
	LinkerFlags = "-lz -lsqlite3")]