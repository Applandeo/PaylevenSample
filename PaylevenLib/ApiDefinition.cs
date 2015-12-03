using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreLocation;

namespace PaylevenLib
{
	#region PLVPaymentRequest
	[BaseType(typeof(NSObject))]
	public interface PLVPaymentRequest
	{
		[Export("identifier")]
		NSString Identifier { get; }

		[Export("amount", ArgumentSemantic.Copy)]
		NSDecimalNumber Amount { get; }

		[Export("currency")]
		NSString Currency { get; }

		[Export("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; }

		[Export("initWithIdentifier:amount:currency:coordinate:")]
		IntPtr Constructor(NSString identifier, NSDecimalNumber amount, NSString currency, CLLocationCoordinate2D coordinate);
	}

	[BaseType(typeof(NSObject))]
	public interface PLVPaymentResultAdditionalData
	{
		[Export("primaryAccountNumber")]
		string PrimaryAccountNumber { get; }

		[Export("maximumPrimaryAccountNumberLength", ArgumentSemantic.Assign)]
		nuint MaximumPrimaryAccountNumberLength { get; }

		[Export("primaryAccountNumberSequenceNumber")]
		NSString PrimaryAccountNumberSequenceNumber { get; }

		[Export("pointOfSaleEntryMode", ArgumentSemantic.Assign)]
		PLVPointOfSaleEntryMode PointOfSaleEntryMode { get; }

		[Export("cardholderVerificationMethod", ArgumentSemantic.Assign)]
		PLVCardholderVerificationMethod CardholderVerificationMethod { get; }

		[Export("applicationIdentifier")]
		NSString ApplicationIdentifier { get; }

		[Export("authorizationCode")]
		NSString AuthorizationCode { get; }

		[Export("cardBrandIdentifier")]
		NSString CardBrandIdentifier { get; }

		[Export("cardBrandName")]
		NSString CardBrandName { get; }
	}

	[BaseType(typeof(NSObject))]
	public interface PLVPaymentTask
	{
		[Export("paymentRequest", ArgumentSemantic.Strong)]
		PLVPaymentRequest PaymentRequest { get; }

		[Wrap("WeakDelegate")]
		PLVPaymentTaskDelegate Delegate { get; }

		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		[Export("result", ArgumentSemantic.Strong)]
		PLVPaymentResult Result { get; }

		[Export("start")]
		void Start();

		[Export("cancel")]
		void Cancel();
	}

	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	public interface PLVPaymentTaskDelegate
	{
		[Abstract]
		[Export("paymentTask:needsSignatureWithCompletionHandler:")]
		void PLVPaymentTask(PLVPaymentTask paymentTask, Action<bool, CGImage> completionHandler);

		[Abstract]
		[Export("paymentTaskDidFinish:")]
		void PaymentTaskDidFinish(PLVPaymentTask paymentTask);

		[Abstract]
		[Export("paymentTask:didFailWithError:")]
		void PLVPaymentTask(PLVPaymentTask paymentTask, NSError error);
	}

	[BaseType(typeof(NSObject))]
	public interface PLVPaymentResult
	{
		[Export("identifier")]
		NSString Identifier { get; }

		[Export("state", ArgumentSemantic.Assign)]
		PLVPaymentResultState State { get; }

		[Export("amount", ArgumentSemantic.Copy)]
		NSDecimalNumber Amount { get; }

		[Export("currency")]
		NSString Currency { get; }

		[Export("date", ArgumentSemantic.Strong)]
		NSDate Date { get; }

		[Export("additionalData", ArgumentSemantic.Strong)]
		PLVPaymentResultAdditionalData AdditionalData { get; }
	}
	#endregion
		
	#region Device
	[BaseType(typeof(NSObject))]
	public interface PLVDevice
	{
		[Export("name")]
		NSString Name { get; }

		[Export("ready")]
		bool Ready { [Bind ("isReady")] get; }

		[Export("prepareWithCompletionHandler:")]
		void PrepareWithCompletionHandler(Action<NSError> completionHandler);
	}
	#endregion

	#region Payleven
	[BaseType(typeof(NSObject))]
	public interface PLVPayleven
	{
		[Static]
		[Export("SDKVersion")]
		NSString SDKVersion { get; }

		[Export("loginState", ArgumentSemantic.Assign)]
		PLVPaylevenLoginState LoginState { get; }

		[Export("devices", ArgumentSemantic.Strong)]
		PLVDevice [] Devices { get; }

		[Export("loginWithUsername:password:APIKey:completionHandler:")]
		void LoginWithUsername(NSString username, NSString password, NSString APIKey, Action<NSError> completionHandler);

		[Export("logoutWithCompletionHandler:")]
		void LogoutWithCompletionHandler(Action<NSError> completionHandler);

		[Export("paymentTaskWithRequest:device:delegate:")]
		PLVPaymentTask PaymentTaskWithRequest(PLVPaymentRequest request, PLVDevice device, PLVPaymentTaskDelegate @delegate);
	}

	public delegate void CompletionHandler(NSError error);
	#endregion
}

