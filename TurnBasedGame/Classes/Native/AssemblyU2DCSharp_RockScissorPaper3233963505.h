#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<RockScissorPaper/Player>
struct LP_1_t1223205785;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RockScissorPaper
struct  RockScissorPaper_t3233963505  : public Data_t3569509720
{
public:
	// LP`1<RockScissorPaper/Player> RockScissorPaper::players
	LP_1_t1223205785 * ___players_5;

public:
	inline static int32_t get_offset_of_players_5() { return static_cast<int32_t>(offsetof(RockScissorPaper_t3233963505, ___players_5)); }
	inline LP_1_t1223205785 * get_players_5() const { return ___players_5; }
	inline LP_1_t1223205785 ** get_address_of_players_5() { return &___players_5; }
	inline void set_players_5(LP_1_t1223205785 * value)
	{
		___players_5 = value;
		Il2CppCodeGenWriteBarrier(&___players_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
