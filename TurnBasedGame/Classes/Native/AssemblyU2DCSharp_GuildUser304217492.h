#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GuildUser/Role>
struct VP_1_t3399883093;
// VP`1<GuildUser/State>
struct VP_1_t4283637920;
// VP`1<Human>
struct VP_1_t1534365499;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GuildUser
struct  GuildUser_t304217492  : public Data_t3569509720
{
public:
	// VP`1<GuildUser/Role> GuildUser::role
	VP_1_t3399883093 * ___role_5;
	// VP`1<GuildUser/State> GuildUser::state
	VP_1_t4283637920 * ___state_6;
	// VP`1<Human> GuildUser::human
	VP_1_t1534365499 * ___human_7;

public:
	inline static int32_t get_offset_of_role_5() { return static_cast<int32_t>(offsetof(GuildUser_t304217492, ___role_5)); }
	inline VP_1_t3399883093 * get_role_5() const { return ___role_5; }
	inline VP_1_t3399883093 ** get_address_of_role_5() { return &___role_5; }
	inline void set_role_5(VP_1_t3399883093 * value)
	{
		___role_5 = value;
		Il2CppCodeGenWriteBarrier(&___role_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(GuildUser_t304217492, ___state_6)); }
	inline VP_1_t4283637920 * get_state_6() const { return ___state_6; }
	inline VP_1_t4283637920 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t4283637920 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_human_7() { return static_cast<int32_t>(offsetof(GuildUser_t304217492, ___human_7)); }
	inline VP_1_t1534365499 * get_human_7() const { return ___human_7; }
	inline VP_1_t1534365499 ** get_address_of_human_7() { return &___human_7; }
	inline void set_human_7(VP_1_t1534365499 * value)
	{
		___human_7 = value;
		Il2CppCodeGenWriteBarrier(&___human_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
