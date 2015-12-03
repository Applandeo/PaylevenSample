//
//  PLVPaymentTask.h
//  PaylevenSDK
//
//  Created by Alexei Kuznetsov on 22/10/14.
//  Copyright (c) 2014 payleven Holding GmbH. All rights reserved.
//

@import CoreGraphics;
@import Foundation;

@class PLVPaymentRequest, PLVPaymentResult;
@protocol PLVPaymentTaskDelegate;

/** 
 @brief PLVPaymentTask instance is used to make payments. 
 It contains a PLVPaymentRequest, PLVPaymentResult and PLVPaymentTaskDelegate.
 The delegate is a required delegate which needs the methods implement on
 adoption.
 */
@interface PLVPaymentTask : NSObject

/** The receiver's payment request. */
@property(nonatomic, readonly, strong) PLVPaymentRequest *paymentRequest;

/** The receiver's delegate. */
@property(nonatomic, readonly, weak) id <PLVPaymentTaskDelegate> delegate;

/** Payment result. */
@property(nonatomic, readonly, strong) PLVPaymentResult *result;

/** Starts the payment task. */
- (void)start;

/**
 @brief Cancels the payment task. Calling this method doesn't cancel the task immediately. 
 When the task finishes or fails after the cancellation, the corresponding delegate methods will be called. 
 The `result` will be `nil` afterwards.
 */
- (void)cancel;

@end

/** 
 The PLVPaymentTaskDelegate is a required protocol for the  PLVPaymentTask.
 */
@protocol PLVPaymentTaskDelegate <NSObject>

@required

/**
 @brief PLVPaymentTaskDelegate method for signature. This is called when a card requires signning
 The signature image has to be provided and the attendant has to compare the signature in the image with the
 signature on the card.
 
 @warning The image must be provided regardless of the signature confirmation.
 
 @param paymentTask Payment task that needs a signature.
 
 @param completionHandler A handler that your delegate method must call. The block takes two parameters:
 `confirmed` A Boolean value indicating if the signature has been confirmed or denied by an attendant.
 `image`     Signature image. Must not be `NULL`.
 
 */
- (void)paymentTask:(PLVPaymentTask *)paymentTask
        needsSignatureWithCompletionHandler:(void (^)(BOOL confirmed, CGImageRef image))completionHandler;

/**
 @brief Called when payment task finishes. Check the `result` property for the result.
 
 @param paymentTask The finished payment task.
 */
- (void)paymentTaskDidFinish:(PLVPaymentTask *)paymentTask;

/**
 @brief Called when payment task fails.
 
 @param paymentTask The failed payment task.
 
 @param error Error object containing information about the failure.
 */
- (void)paymentTask:(PLVPaymentTask *)paymentTask didFailWithError:(NSError *)error;

@end
