#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<FriendAdapter/UIData>
struct VP_1_t1466383364;
// VP`1<FriendDetailUI/UIData>
struct VP_1_t3677463584;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalFriendsUI/UIData
struct  UIData_t2096897087  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Server>> GlobalFriendsUI/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<FriendAdapter/UIData> GlobalFriendsUI/UIData::friendAdapter
	VP_1_t1466383364 * ___friendAdapter_6;
	// VP`1<FriendDetailUI/UIData> GlobalFriendsUI/UIData::friendDetail
	VP_1_t3677463584 * ___friendDetail_7;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t2096897087, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_friendAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t2096897087, ___friendAdapter_6)); }
	inline VP_1_t1466383364 * get_friendAdapter_6() const { return ___friendAdapter_6; }
	inline VP_1_t1466383364 ** get_address_of_friendAdapter_6() { return &___friendAdapter_6; }
	inline void set_friendAdapter_6(VP_1_t1466383364 * value)
	{
		___friendAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___friendAdapter_6, value);
	}

	inline static int32_t get_offset_of_friendDetail_7() { return static_cast<int32_t>(offsetof(UIData_t2096897087, ___friendDetail_7)); }
	inline VP_1_t3677463584 * get_friendDetail_7() const { return ___friendDetail_7; }
	inline VP_1_t3677463584 ** get_address_of_friendDetail_7() { return &___friendDetail_7; }
	inline void set_friendDetail_7(VP_1_t3677463584 * value)
	{
		___friendDetail_7 = value;
		Il2CppCodeGenWriteBarrier(&___friendDetail_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
