#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_ChatMessageHolder_UIData_Sub186776795.h"

// VP`1<ReferenceData`1<FriendStateChangeContent>>
struct VP_1_t3638448959;
// VP`1<AccountAvatarUI/UIData>
struct VP_1_t3547432187;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateChangeContentUI/UIData
struct  UIData_t4037736175  : public Sub_t186776795
{
public:
	// VP`1<ReferenceData`1<FriendStateChangeContent>> FriendStateChangeContentUI/UIData::friendStateChangeContent
	VP_1_t3638448959 * ___friendStateChangeContent_5;
	// VP`1<AccountAvatarUI/UIData> FriendStateChangeContentUI/UIData::avatar
	VP_1_t3547432187 * ___avatar_6;
	// VP`1<RequestChangeStringUI/UIData> FriendStateChangeContentUI/UIData::content
	VP_1_t1525575381 * ___content_7;
	// VP`1<RequestChangeStringUI/UIData> FriendStateChangeContentUI/UIData::time
	VP_1_t1525575381 * ___time_8;

public:
	inline static int32_t get_offset_of_friendStateChangeContent_5() { return static_cast<int32_t>(offsetof(UIData_t4037736175, ___friendStateChangeContent_5)); }
	inline VP_1_t3638448959 * get_friendStateChangeContent_5() const { return ___friendStateChangeContent_5; }
	inline VP_1_t3638448959 ** get_address_of_friendStateChangeContent_5() { return &___friendStateChangeContent_5; }
	inline void set_friendStateChangeContent_5(VP_1_t3638448959 * value)
	{
		___friendStateChangeContent_5 = value;
		Il2CppCodeGenWriteBarrier(&___friendStateChangeContent_5, value);
	}

	inline static int32_t get_offset_of_avatar_6() { return static_cast<int32_t>(offsetof(UIData_t4037736175, ___avatar_6)); }
	inline VP_1_t3547432187 * get_avatar_6() const { return ___avatar_6; }
	inline VP_1_t3547432187 ** get_address_of_avatar_6() { return &___avatar_6; }
	inline void set_avatar_6(VP_1_t3547432187 * value)
	{
		___avatar_6 = value;
		Il2CppCodeGenWriteBarrier(&___avatar_6, value);
	}

	inline static int32_t get_offset_of_content_7() { return static_cast<int32_t>(offsetof(UIData_t4037736175, ___content_7)); }
	inline VP_1_t1525575381 * get_content_7() const { return ___content_7; }
	inline VP_1_t1525575381 ** get_address_of_content_7() { return &___content_7; }
	inline void set_content_7(VP_1_t1525575381 * value)
	{
		___content_7 = value;
		Il2CppCodeGenWriteBarrier(&___content_7, value);
	}

	inline static int32_t get_offset_of_time_8() { return static_cast<int32_t>(offsetof(UIData_t4037736175, ___time_8)); }
	inline VP_1_t1525575381 * get_time_8() const { return ___time_8; }
	inline VP_1_t1525575381 ** get_address_of_time_8() { return &___time_8; }
	inline void set_time_8(VP_1_t1525575381 * value)
	{
		___time_8 = value;
		Il2CppCodeGenWriteBarrier(&___time_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
