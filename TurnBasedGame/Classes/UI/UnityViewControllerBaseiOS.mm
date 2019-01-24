#if UNITY_IOS

#include "UnityViewControllerBaseiOS.h"
#include "OrientationSupport.h"
#include "Keyboard.h"
#include "UnityView.h"
#include "PluginBase/UnityViewControllerListener.h"
#include "UnityAppController.h"
#include "UnityAppController+ViewHandling.h"
#include "Unity/ObjCRuntime.h"

#include <math.h>

typedef id (*WillRotateToInterfaceOrientationSendFunc)(struct objc_super*, SEL, UIInterfaceOrientation, NSTimeInterval);
static void WillRotateToInterfaceOrientation_DefaultImpl(id self_, SEL _cmd, UIInterfaceOrientation toInterfaceOrientation, NSTimeInterval duration);

typedef id (*DidRotateFromInterfaceOrientationSendFunc)(struct objc_super*, SEL, UIInterfaceOrientation);
static void DidRotateFromInterfaceOrientation_DefaultImpl(id self_, SEL _cmd, UIInterfaceOrientation fromInterfaceOrientation);

typedef id (*ViewWillTransitionToSizeSendFunc)(struct objc_super*, SEL, CGSize, id<UIViewControllerTransitionCoordinator>);
static void ViewWillTransitionToSize_DefaultImpl(id self_, SEL _cmd, CGSize size, id<UIViewControllerTransitionCoordinator> coordinator);


// when returning from presenting UIViewController we might need to update app orientation to "correct" one, as we wont get rotation notification
@interface UnityAppController ()
- (void)updateAppOrientation:(UIInterfaceOrientation)orientation;
@end


@implementation UnityViewControllerBase

- (id)init
{
    if ((self = [super init]))
        AddViewControllerDefaultRotationHandling([UnityViewControllerBase class]);

    return self;
}

- (BOOL)shouldAutorotate
{
    return YES;
}

- (BOOL)prefersStatusBarHidden
{
    static bool _PrefersStatusBarHidden = true;

    static bool _PrefersStatusBarHiddenInited = false;
    if (!_PrefersStatusBarHiddenInited)
    {
        NSNumber* hidden = [[[NSBundle mainBundle] infoDictionary] objectForKey: @"UIStatusBarHidden"];
        _PrefersStatusBarHidden = hidden ? [hidden boolValue] : YES;

        _PrefersStatusBarHiddenInited = true;
    }
    return _PrefersStatusBarHidden;
}

- (UIStatusBarStyle)preferredStatusBarStyle
{
    static UIStatusBarStyle _PreferredStatusBarStyle = UIStatusBarStyleDefault;

    static bool _PreferredStatusBarStyleInited = false;
    if (!_PreferredStatusBarStyleInited)
    {
        NSString* style = [[[NSBundle mainBundle] infoDictionary] objectForKey: @"UIStatusBarStyle"];
        if (style && ([style isEqualToString: @"UIStatusBarStyleBlackOpaque"] || [style isEqualToString: @"UIStatusBarStyleBlackTranslucent"]))
            _PreferredStatusBarStyle = UIStatusBarStyleLightContent;

        _PreferredStatusBarStyleInited = true;
    }

    return _PreferredStatusBarStyle;
}

- (void)viewWillLayoutSubviews
{
    [super viewWillLayoutSubviews];
    AppController_SendUnityViewControllerNotification(kUnityViewWillLayoutSubviews);
}

- (void)viewDidLayoutSubviews
{
    [super viewDidLayoutSubviews];
    AppController_SendUnityViewControllerNotification(kUnityViewDidLayoutSubviews);
}

- (void)viewDidDisappear:(BOOL)animated
{
    [super viewDidDisappear: animated];
    AppController_SendUnityViewControllerNotification(kUnityViewDidDisappear);
}

- (void)viewWillDisappear:(BOOL)animated
{
    [super viewWillDisappear: animated];
    AppController_SendUnityViewControllerNotification(kUnityViewWillDisappear);
}

- (void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear: animated];
    AppController_SendUnityViewControllerNotification(kUnityViewDidAppear);
}

- (void)viewWillAppear:(BOOL)animated
{
    [super viewWillAppear: animated];
    AppController_SendUnityViewControllerNotification(kUnityViewWillAppear);
}

@end

@implementation UnityDefaultViewController
- (NSUInteger)supportedInterfaceOrientations
{
    NSAssert(UnityShouldAutorotate(), @"UnityDefaultViewController should be used only if unity is set to autorotate");

    NSUInteger ret = 0;

    if (UnityIsOrientationEnabled(portrait))
        ret |= (1 << UIInterfaceOrientationPortrait);
    if (UnityIsOrientationEnabled(portraitUpsideDown))
        ret |= (1 << UIInterfaceOrientationPortraitUpsideDown);
    if (UnityIsOrientationEnabled(landscapeLeft))
        ret |= (1 << UIInterfaceOrientationLandscapeRight);
    if (UnityIsOrientationEnabled(landscapeRight))
        ret |= (1 << UIInterfaceOrientationLandscapeLeft);

    return ret;
}

@end

@implementation UnityPortraitOnlyViewController
- (NSUInteger)supportedInterfaceOrientations
{
    return 1 << UIInterfaceOrientationPortrait;
}

- (void)viewWillAppear:(BOOL)animated
{
    [GetAppController() updateAppOrientation: UIInterfaceOrientationPortrait];
    [super viewWillAppear: animated];
}

@end
@implementation UnityPortraitUpsideDownOnlyViewController
- (NSUInteger)supportedInterfaceOrientations
{
    return 1 << UIInterfaceOrientationPortraitUpsideDown;
}

- (void)viewWillAppear:(BOOL)animated
{
    [GetAppController() updateAppOrientation: UIInterfaceOrientationPortraitUpsideDown];
    [super viewWillAppear: animated];
}

@end
@implementation UnityLandscapeLeftOnlyViewController
- (NSUInteger)supportedInterfaceOrientations
{
    return 1 << UIInterfaceOrientationLandscapeLeft;
}

- (void)viewWillAppear:(BOOL)animated
{
    [GetAppController() updateAppOrientation: UIInterfaceOrientationLandscapeLeft];
    [super viewWillAppear: animated];
}

@end
@implementation UnityLandscapeRightOnlyViewController
- (NSUInteger)supportedInterfaceOrientations
{
    return 1 << UIInterfaceOrientationLandscapeRight;
}

- (void)viewWillAppear:(BOOL)animated
{
    [GetAppController() updateAppOrientation: UIInterfaceOrientationLandscapeRight];
    [super viewWillAppear: animated];
}

@end

extern "C" void UnityNotifyAutoOrientationChange()
{
    [UIViewController attemptRotationToDeviceOrientation];
}

// ios8 changed the way ViewController should handle rotation, so pick correct implementation at runtime
//

static void WillRotateToInterfaceOrientation_DefaultImpl(id self_, SEL _cmd, UIInterfaceOrientation toInterfaceOrientation, NSTimeInterval duration)
{
    [UIView setAnimationsEnabled: UnityUseAnimatedAutorotation() ? YES : NO];
    [GetAppController() interfaceWillChangeOrientationTo: toInterfaceOrientation];

    [KeyboardDelegate StartReorientation];

    AppController_SendUnityViewControllerNotification(kUnityInterfaceWillChangeOrientation);
    UNITY_OBJC_FORWARD_TO_SUPER(self_, [UIViewController class], @selector(willRotateToInterfaceOrientation:duration:), WillRotateToInterfaceOrientationSendFunc, toInterfaceOrientation, duration);
}

static void DidRotateFromInterfaceOrientation_DefaultImpl(id self_, SEL _cmd, UIInterfaceOrientation fromInterfaceOrientation)
{
    UIViewController* self = (UIViewController*)self_;

    [self.view layoutSubviews];
    [GetAppController() interfaceDidChangeOrientationFrom: fromInterfaceOrientation];

    [KeyboardDelegate FinishReorientation];
    [UIView setAnimationsEnabled: YES];

    AppController_SendUnityViewControllerNotification(kUnityInterfaceDidChangeOrientation);
    UNITY_OBJC_FORWARD_TO_SUPER(self_, [UIViewController class], @selector(didRotateFromInterfaceOrientation:), DidRotateFromInterfaceOrientationSendFunc, fromInterfaceOrientation);
}

static void ViewWillTransitionToSize_DefaultImpl(id self_, SEL _cmd, CGSize size, id<UIViewControllerTransitionCoordinator> coordinator)
{
    UIViewController* self = (UIViewController*)self_;

    ScreenOrientation curOrient = ConvertToUnityScreenOrientation(self.interfaceOrientation);
    ScreenOrientation newOrient = OrientationAfterTransform(curOrient, [coordinator targetTransform]);

    // in case of presentation controller it will take control over orientations
    // so to avoid crazy corner cases, make default view controller to ignore "wrong" orientations
    // as they will come only in case of presentation view controller and will be reverted anyway
    // NB: we still want to pass message to super, we just want to skip unity-specific magic
    NSUInteger targetMask = 1 << ConvertToIosScreenOrientation(newOrient);
    if (([self supportedInterfaceOrientations] & targetMask) != 0)
    {
        [UIView setAnimationsEnabled: UnityUseAnimatedAutorotation() ? YES : NO];
        [KeyboardDelegate StartReorientation];

        [GetAppController() interfaceWillChangeOrientationTo: ConvertToIosScreenOrientation(newOrient)];

        [coordinator animateAlongsideTransition: nil completion:^(id < UIViewControllerTransitionCoordinatorContext > context) {
            [self.view setNeedsLayout];
            [GetAppController() interfaceDidChangeOrientationFrom: ConvertToIosScreenOrientation(curOrient)];

            [KeyboardDelegate FinishReorientation];
            [UIView setAnimationsEnabled: YES];
        }];
    }
    UNITY_OBJC_FORWARD_TO_SUPER(self_, [UIViewController class], @selector(viewWillTransitionToSize:withTransitionCoordinator:), ViewWillTransitionToSizeSendFunc, size, coordinator);
}

extern "C" void AddViewControllerRotationHandling(Class class_, IMP willRotateToInterfaceOrientation, IMP didRotateFromInterfaceOrientation, IMP viewWillTransitionToSize)
{
    if (_ios80orNewer && viewWillTransitionToSize)
    {
        ObjCSetKnownInstanceMethod(class_, @selector(viewWillTransitionToSize:withTransitionCoordinator:), viewWillTransitionToSize);
    }
    else
    {
        ObjCSetKnownInstanceMethod(class_, @selector(willRotateToInterfaceOrientation:duration:), willRotateToInterfaceOrientation);
        ObjCSetKnownInstanceMethod(class_, @selector(didRotateFromInterfaceOrientation:), didRotateFromInterfaceOrientation);
    }
}

extern "C" void AddViewControllerDefaultRotationHandling(Class class_)
{
    AddViewControllerRotationHandling(
        class_,
        (IMP)&WillRotateToInterfaceOrientation_DefaultImpl, (IMP)&DidRotateFromInterfaceOrientation_DefaultImpl,
        (IMP)&ViewWillTransitionToSize_DefaultImpl
        );
}

#endif // UNITY_IOS
