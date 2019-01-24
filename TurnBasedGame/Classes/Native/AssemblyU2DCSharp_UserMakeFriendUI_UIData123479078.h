#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Human>>
struct VP_1_t605148562;
// VP`1<UserMakeFriendUI/UIData/State>
struct VP_1_t1099609694;
// VP`1<FriendStateUI/UIData>
struct VP_1_t1144328976;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserMakeFriendUI/UIData
struct  UIData_t123479078  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Human>> UserMakeFriendUI/UIData::human
	VP_1_t605148562 * ___human_5;
	// VP`1<UserMakeFriendUI/UIData/State> UserMakeFriendUI/UIData::state
	VP_1_t1099609694 * ___state_6;
	// VP`1<FriendStateUI/UIData> UserMakeFriendUI/UIData::friendStateUIData
	VP_1_t1144328976 * ___friendStateUIData_7;

public:
	inline static int32_t get_offset_of_human_5() { return static_cast<int32_t>(offsetof(UIData_t123479078, ___human_5)); }
	inline VP_1_t605148562 * get_human_5() const { return ___human_5; }
	inline VP_1_t605148562 ** get_address_of_human_5() { return &___human_5; }
	inline void set_human_5(VP_1_t605148562 * value)
	{
		___human_5 = value;
		Il2CppCodeGenWriteBarrier(&___human_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t123479078, ___state_6)); }
	inline VP_1_t1099609694 * get_state_6() const { return ___state_6; }
	inline VP_1_t1099609694 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t1099609694 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_friendStateUIData_7() { return static_cast<int32_t>(offsetof(UIData_t123479078, ___friendStateUIData_7)); }
	inline VP_1_t1144328976 * get_friendStateUIData_7() const { return ___friendStateUIData_7; }
	inline VP_1_t1144328976 ** get_address_of_friendStateUIData_7() { return &___friendStateUIData_7; }
	inline void set_friendStateUIData_7(VP_1_t1144328976 * value)
	{
		___friendStateUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___friendStateUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
