#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Friend>>
struct VP_1_t3004074177;
// VP`1<FriendStateUI/UIData/Sub>
struct VP_1_t2063588673;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateUI/UIData
struct  UIData_t766051970  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Friend>> FriendStateUI/UIData::friend
	VP_1_t3004074177 * ___friend_5;
	// VP`1<FriendStateUI/UIData/Sub> FriendStateUI/UIData::sub
	VP_1_t2063588673 * ___sub_6;

public:
	inline static int32_t get_offset_of_friend_5() { return static_cast<int32_t>(offsetof(UIData_t766051970, ___friend_5)); }
	inline VP_1_t3004074177 * get_friend_5() const { return ___friend_5; }
	inline VP_1_t3004074177 ** get_address_of_friend_5() { return &___friend_5; }
	inline void set_friend_5(VP_1_t3004074177 * value)
	{
		___friend_5 = value;
		Il2CppCodeGenWriteBarrier(&___friend_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t766051970, ___sub_6)); }
	inline VP_1_t2063588673 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2063588673 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2063588673 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
