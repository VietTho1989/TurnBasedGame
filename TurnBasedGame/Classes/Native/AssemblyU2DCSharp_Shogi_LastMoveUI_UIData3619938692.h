#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameData>>
struct VP_1_t4194301587;
// VP`1<LastMoveSub>
struct VP_1_t227399123;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.LastMoveUI/UIData
struct  UIData_t3619938692  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameData>> Shogi.LastMoveUI/UIData::gameData
	VP_1_t4194301587 * ___gameData_5;
	// VP`1<LastMoveSub> Shogi.LastMoveUI/UIData::sub
	VP_1_t227399123 * ___sub_6;

public:
	inline static int32_t get_offset_of_gameData_5() { return static_cast<int32_t>(offsetof(UIData_t3619938692, ___gameData_5)); }
	inline VP_1_t4194301587 * get_gameData_5() const { return ___gameData_5; }
	inline VP_1_t4194301587 ** get_address_of_gameData_5() { return &___gameData_5; }
	inline void set_gameData_5(VP_1_t4194301587 * value)
	{
		___gameData_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t3619938692, ___sub_6)); }
	inline VP_1_t227399123 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t227399123 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t227399123 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
