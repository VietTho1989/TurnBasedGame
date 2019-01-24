#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Human>
struct VP_1_t1534365499;
// VP`1<User/Role>
struct VP_1_t2449882442;
// VP`1<System.String>
struct VP_1_t2407497239;
// VP`1<System.Int64>
struct VP_1_t1287355043;
// VP`1<ChatRoom>
struct VP_1_t38054233;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// User
struct  User_t719925459  : public Data_t3569509720
{
public:
	// VP`1<Human> User::human
	VP_1_t1534365499 * ___human_5;
	// VP`1<User/Role> User::role
	VP_1_t2449882442 * ___role_7;
	// VP`1<System.String> User::ipAddress
	VP_1_t2407497239 * ___ipAddress_8;
	// VP`1<System.Int64> User::registerTime
	VP_1_t1287355043 * ___registerTime_9;
	// VP`1<ChatRoom> User::chatRoom
	VP_1_t38054233 * ___chatRoom_10;

public:
	inline static int32_t get_offset_of_human_5() { return static_cast<int32_t>(offsetof(User_t719925459, ___human_5)); }
	inline VP_1_t1534365499 * get_human_5() const { return ___human_5; }
	inline VP_1_t1534365499 ** get_address_of_human_5() { return &___human_5; }
	inline void set_human_5(VP_1_t1534365499 * value)
	{
		___human_5 = value;
		Il2CppCodeGenWriteBarrier(&___human_5, value);
	}

	inline static int32_t get_offset_of_role_7() { return static_cast<int32_t>(offsetof(User_t719925459, ___role_7)); }
	inline VP_1_t2449882442 * get_role_7() const { return ___role_7; }
	inline VP_1_t2449882442 ** get_address_of_role_7() { return &___role_7; }
	inline void set_role_7(VP_1_t2449882442 * value)
	{
		___role_7 = value;
		Il2CppCodeGenWriteBarrier(&___role_7, value);
	}

	inline static int32_t get_offset_of_ipAddress_8() { return static_cast<int32_t>(offsetof(User_t719925459, ___ipAddress_8)); }
	inline VP_1_t2407497239 * get_ipAddress_8() const { return ___ipAddress_8; }
	inline VP_1_t2407497239 ** get_address_of_ipAddress_8() { return &___ipAddress_8; }
	inline void set_ipAddress_8(VP_1_t2407497239 * value)
	{
		___ipAddress_8 = value;
		Il2CppCodeGenWriteBarrier(&___ipAddress_8, value);
	}

	inline static int32_t get_offset_of_registerTime_9() { return static_cast<int32_t>(offsetof(User_t719925459, ___registerTime_9)); }
	inline VP_1_t1287355043 * get_registerTime_9() const { return ___registerTime_9; }
	inline VP_1_t1287355043 ** get_address_of_registerTime_9() { return &___registerTime_9; }
	inline void set_registerTime_9(VP_1_t1287355043 * value)
	{
		___registerTime_9 = value;
		Il2CppCodeGenWriteBarrier(&___registerTime_9, value);
	}

	inline static int32_t get_offset_of_chatRoom_10() { return static_cast<int32_t>(offsetof(User_t719925459, ___chatRoom_10)); }
	inline VP_1_t38054233 * get_chatRoom_10() const { return ___chatRoom_10; }
	inline VP_1_t38054233 ** get_address_of_chatRoom_10() { return &___chatRoom_10; }
	inline void set_chatRoom_10(VP_1_t38054233 * value)
	{
		___chatRoom_10 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoom_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
