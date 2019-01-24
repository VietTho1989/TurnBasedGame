#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Turn
struct  Turn_t4147714979  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Turn::turn
	VP_1_t2450154454 * ___turn_5;
	// VP`1<System.Int32> Turn::playerIndex
	VP_1_t2450154454 * ___playerIndex_6;
	// VP`1<System.Int32> Turn::gameTurn
	VP_1_t2450154454 * ___gameTurn_7;

public:
	inline static int32_t get_offset_of_turn_5() { return static_cast<int32_t>(offsetof(Turn_t4147714979, ___turn_5)); }
	inline VP_1_t2450154454 * get_turn_5() const { return ___turn_5; }
	inline VP_1_t2450154454 ** get_address_of_turn_5() { return &___turn_5; }
	inline void set_turn_5(VP_1_t2450154454 * value)
	{
		___turn_5 = value;
		Il2CppCodeGenWriteBarrier(&___turn_5, value);
	}

	inline static int32_t get_offset_of_playerIndex_6() { return static_cast<int32_t>(offsetof(Turn_t4147714979, ___playerIndex_6)); }
	inline VP_1_t2450154454 * get_playerIndex_6() const { return ___playerIndex_6; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_6() { return &___playerIndex_6; }
	inline void set_playerIndex_6(VP_1_t2450154454 * value)
	{
		___playerIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_6, value);
	}

	inline static int32_t get_offset_of_gameTurn_7() { return static_cast<int32_t>(offsetof(Turn_t4147714979, ___gameTurn_7)); }
	inline VP_1_t2450154454 * get_gameTurn_7() const { return ___gameTurn_7; }
	inline VP_1_t2450154454 ** get_address_of_gameTurn_7() { return &___gameTurn_7; }
	inline void set_gameTurn_7(VP_1_t2450154454 * value)
	{
		___gameTurn_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameTurn_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
