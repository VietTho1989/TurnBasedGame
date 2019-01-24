#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<RockScissorPaper/Player/State>
struct VP_1_t208557151;
// VP`1<RockScissorPaper/Player/Result>
struct VP_1_t165624229;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RockScissorPaper/Player
struct  Player_t2485461829  : public Data_t3569509720
{
public:
	// VP`1<RockScissorPaper/Player/State> RockScissorPaper/Player::state
	VP_1_t208557151 * ___state_5;
	// VP`1<RockScissorPaper/Player/Result> RockScissorPaper/Player::result
	VP_1_t165624229 * ___result_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(Player_t2485461829, ___state_5)); }
	inline VP_1_t208557151 * get_state_5() const { return ___state_5; }
	inline VP_1_t208557151 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t208557151 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_result_6() { return static_cast<int32_t>(offsetof(Player_t2485461829, ___result_6)); }
	inline VP_1_t165624229 * get_result_6() const { return ___result_6; }
	inline VP_1_t165624229 ** get_address_of_result_6() { return &___result_6; }
	inline void set_result_6(VP_1_t165624229 * value)
	{
		___result_6 = value;
		Il2CppCodeGenWriteBarrier(&___result_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
