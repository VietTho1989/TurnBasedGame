#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "Facebook_Unity_Facebook_Unity_FacebookBase2463540723.h"

// System.String
struct String_t;
// Facebook.Unity.Canvas.ICanvasJSWrapper
struct ICanvasJSWrapper_t562769999;
// Facebook.Unity.HideUnityDelegate
struct HideUnityDelegate_t712804158;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Canvas.CanvasFacebook
struct  CanvasFacebook_t1390391306  : public FacebookBase_t2463540723
{
public:
	// System.String Facebook.Unity.Canvas.CanvasFacebook::appId
	String_t* ___appId_3;
	// System.String Facebook.Unity.Canvas.CanvasFacebook::appLinkUrl
	String_t* ___appLinkUrl_4;
	// Facebook.Unity.Canvas.ICanvasJSWrapper Facebook.Unity.Canvas.CanvasFacebook::canvasJSWrapper
	Il2CppObject * ___canvasJSWrapper_5;
	// Facebook.Unity.HideUnityDelegate Facebook.Unity.Canvas.CanvasFacebook::onHideUnityDelegate
	HideUnityDelegate_t712804158 * ___onHideUnityDelegate_6;
	// System.Boolean Facebook.Unity.Canvas.CanvasFacebook::<LimitEventUsage>k__BackingField
	bool ___U3CLimitEventUsageU3Ek__BackingField_7;

public:
	inline static int32_t get_offset_of_appId_3() { return static_cast<int32_t>(offsetof(CanvasFacebook_t1390391306, ___appId_3)); }
	inline String_t* get_appId_3() const { return ___appId_3; }
	inline String_t** get_address_of_appId_3() { return &___appId_3; }
	inline void set_appId_3(String_t* value)
	{
		___appId_3 = value;
		Il2CppCodeGenWriteBarrier(&___appId_3, value);
	}

	inline static int32_t get_offset_of_appLinkUrl_4() { return static_cast<int32_t>(offsetof(CanvasFacebook_t1390391306, ___appLinkUrl_4)); }
	inline String_t* get_appLinkUrl_4() const { return ___appLinkUrl_4; }
	inline String_t** get_address_of_appLinkUrl_4() { return &___appLinkUrl_4; }
	inline void set_appLinkUrl_4(String_t* value)
	{
		___appLinkUrl_4 = value;
		Il2CppCodeGenWriteBarrier(&___appLinkUrl_4, value);
	}

	inline static int32_t get_offset_of_canvasJSWrapper_5() { return static_cast<int32_t>(offsetof(CanvasFacebook_t1390391306, ___canvasJSWrapper_5)); }
	inline Il2CppObject * get_canvasJSWrapper_5() const { return ___canvasJSWrapper_5; }
	inline Il2CppObject ** get_address_of_canvasJSWrapper_5() { return &___canvasJSWrapper_5; }
	inline void set_canvasJSWrapper_5(Il2CppObject * value)
	{
		___canvasJSWrapper_5 = value;
		Il2CppCodeGenWriteBarrier(&___canvasJSWrapper_5, value);
	}

	inline static int32_t get_offset_of_onHideUnityDelegate_6() { return static_cast<int32_t>(offsetof(CanvasFacebook_t1390391306, ___onHideUnityDelegate_6)); }
	inline HideUnityDelegate_t712804158 * get_onHideUnityDelegate_6() const { return ___onHideUnityDelegate_6; }
	inline HideUnityDelegate_t712804158 ** get_address_of_onHideUnityDelegate_6() { return &___onHideUnityDelegate_6; }
	inline void set_onHideUnityDelegate_6(HideUnityDelegate_t712804158 * value)
	{
		___onHideUnityDelegate_6 = value;
		Il2CppCodeGenWriteBarrier(&___onHideUnityDelegate_6, value);
	}

	inline static int32_t get_offset_of_U3CLimitEventUsageU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(CanvasFacebook_t1390391306, ___U3CLimitEventUsageU3Ek__BackingField_7)); }
	inline bool get_U3CLimitEventUsageU3Ek__BackingField_7() const { return ___U3CLimitEventUsageU3Ek__BackingField_7; }
	inline bool* get_address_of_U3CLimitEventUsageU3Ek__BackingField_7() { return &___U3CLimitEventUsageU3Ek__BackingField_7; }
	inline void set_U3CLimitEventUsageU3Ek__BackingField_7(bool value)
	{
		___U3CLimitEventUsageU3Ek__BackingField_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
