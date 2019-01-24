#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<SortDataUI/UIData>
struct VP_1_t706396857;
// LP`1<FriendHolder/UIData>
struct LP_1_t4080887091;
// System.Collections.Generic.List`1<Friend>
struct List_1_t2924135240;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendAdapter/UIData
struct  UIData_t1088106358  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<Server>> FriendAdapter/UIData::server
	VP_1_t2173380836 * ___server_20;
	// VP`1<SortDataUI/UIData> FriendAdapter/UIData::sortData
	VP_1_t706396857 * ___sortData_21;
	// LP`1<FriendHolder/UIData> FriendAdapter/UIData::holders
	LP_1_t4080887091 * ___holders_22;
	// System.Collections.Generic.List`1<Friend> FriendAdapter/UIData::friends
	List_1_t2924135240 * ___friends_23;

public:
	inline static int32_t get_offset_of_server_20() { return static_cast<int32_t>(offsetof(UIData_t1088106358, ___server_20)); }
	inline VP_1_t2173380836 * get_server_20() const { return ___server_20; }
	inline VP_1_t2173380836 ** get_address_of_server_20() { return &___server_20; }
	inline void set_server_20(VP_1_t2173380836 * value)
	{
		___server_20 = value;
		Il2CppCodeGenWriteBarrier(&___server_20, value);
	}

	inline static int32_t get_offset_of_sortData_21() { return static_cast<int32_t>(offsetof(UIData_t1088106358, ___sortData_21)); }
	inline VP_1_t706396857 * get_sortData_21() const { return ___sortData_21; }
	inline VP_1_t706396857 ** get_address_of_sortData_21() { return &___sortData_21; }
	inline void set_sortData_21(VP_1_t706396857 * value)
	{
		___sortData_21 = value;
		Il2CppCodeGenWriteBarrier(&___sortData_21, value);
	}

	inline static int32_t get_offset_of_holders_22() { return static_cast<int32_t>(offsetof(UIData_t1088106358, ___holders_22)); }
	inline LP_1_t4080887091 * get_holders_22() const { return ___holders_22; }
	inline LP_1_t4080887091 ** get_address_of_holders_22() { return &___holders_22; }
	inline void set_holders_22(LP_1_t4080887091 * value)
	{
		___holders_22 = value;
		Il2CppCodeGenWriteBarrier(&___holders_22, value);
	}

	inline static int32_t get_offset_of_friends_23() { return static_cast<int32_t>(offsetof(UIData_t1088106358, ___friends_23)); }
	inline List_1_t2924135240 * get_friends_23() const { return ___friends_23; }
	inline List_1_t2924135240 ** get_address_of_friends_23() { return &___friends_23; }
	inline void set_friends_23(List_1_t2924135240 * value)
	{
		___friends_23 = value;
		Il2CppCodeGenWriteBarrier(&___friends_23, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
