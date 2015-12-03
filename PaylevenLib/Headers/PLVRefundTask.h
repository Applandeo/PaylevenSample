//
//  PLVRefundTask.h
//  PaylevenSDK
//
//  Created by Bob Obi on 7/23/15.
//  Copyright (c) 2015 payleven Holding GmbH. All rights reserved.
//

#import <Foundation/Foundation.h>

@class PLVRefundRequest, PLVRefundResult;

/**
 @brief PLVRefundTask instance is used to trigger
 and start the refund task. Contains 2 readonly properties
 the PLVRefundRequest and the PLVRefundResult with a start method.
 */
@interface PLVRefundTask : NSObject
/** 
 * The receiver's payment request. 
 */
@property(nonatomic, readonly) PLVRefundRequest *refundRequest;
/** 
 * Refund result.
 */
@property(nonatomic, readonly) PLVRefundResult *result;

/** 
 * Starts the refund task. 
 */
- (void)start;

@end
