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
// Facebook.Unity.Gameroom.IGameroomWrapper
struct IGameroomWrapper_t888299303;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Gameroom.GameroomFacebook
struct  GameroomFacebook_t1231904629  : public FacebookBase_t2463540723
{
public:
	// System.String Facebook.Unity.Gameroom.GameroomFacebook::appId
	String_t* ___appId_3;
	// Facebook.Unity.Gameroom.IGameroomWrapper Facebook.Unity.Gameroom.GameroomFacebook::gameroomWrapper
	Il2CppObject * ___gameroomWrapper_4;
	// System.Boolean Facebook.Unity.Gameroom.GameroomFacebook::<LimitEventUsage>k__BackingField
	bool ___U3CLimitEventUsageU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_appId_3() { return static_cast<int32_t>(offsetof(GameroomFacebook_t1231904629, ___appId_3)); }
	inline String_t* get_appId_3() const { return ___appId_3; }
	inline String_t** get_address_of_appId_3() { return &___appId_3; }
	inline void set_appId_3(String_t* value)
	{
		___appId_3 = value;
		Il2CppCodeGenWriteBarrier(&___appId_3, value);
	}

	inline static int32_t get_offset_of_gameroomWrapper_4() { return static_cast<int32_t>(offsetof(GameroomFacebook_t1231904629, ___gameroomWrapper_4)); }
	inline Il2CppObject * get_gameroomWrapper_4() const { return ___gameroomWrapper_4; }
	inline Il2CppObject ** get_address_of_gameroomWrapper_4() { return &___gameroomWrapper_4; }
	inline void set_gameroomWrapper_4(Il2CppObject * value)
	{
		___gameroomWrapper_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameroomWrapper_4, value);
	}

	inline static int32_t get_offset_of_U3CLimitEventUsageU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(GameroomFacebook_t1231904629, ___U3CLimitEventUsageU3Ek__BackingField_5)); }
	inline bool get_U3CLimitEventUsageU3Ek__BackingField_5() const { return ___U3CLimitEventUsageU3Ek__BackingField_5; }
	inline bool* get_address_of_U3CLimitEventUsageU3Ek__BackingField_5() { return &___U3CLimitEventUsageU3Ek__BackingField_5; }
	inline void set_U3CLimitEventUsageU3Ek__BackingField_5(bool value)
	{
		___U3CLimitEventUsageU3Ek__BackingField_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
