using System;
using ObjCRuntime;

[assembly: LinkWith ("libPaylevenSDK.a", 
	LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, 
	Frameworks = "CoreFoundation CoreText UIKit Foundation CoreData CoreLocation ExternalAccessory SystemConfiguration", 
	LinkerFlags = "-lz -lsqlite3")]