#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Game>>
struct VP_1_t1049201283;
// LP`1<GamePlayerUI/UIData>
struct LP_1_t1065117528;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerListUI/UIData
struct  UIData_t2063171092  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Game>> GamePlayerListUI/UIData::game
	VP_1_t1049201283 * ___game_5;
	// LP`1<GamePlayerUI/UIData> GamePlayerListUI/UIData::gamePlayerUIs
	LP_1_t1065117528 * ___gamePlayerUIs_6;

public:
	inline static int32_t get_offset_of_game_5() { return static_cast<int32_t>(offsetof(UIData_t2063171092, ___game_5)); }
	inline VP_1_t1049201283 * get_game_5() const { return ___game_5; }
	inline VP_1_t1049201283 ** get_address_of_game_5() { return &___game_5; }
	inline void set_game_5(VP_1_t1049201283 * value)
	{
		___game_5 = value;
		Il2CppCodeGenWriteBarrier(&___game_5, value);
	}

	inline static int32_t get_offset_of_gamePlayerUIs_6() { return static_cast<int32_t>(offsetof(UIData_t2063171092, ___gamePlayerUIs_6)); }
	inline LP_1_t1065117528 * get_gamePlayerUIs_6() const { return ___gamePlayerUIs_6; }
	inline LP_1_t1065117528 ** get_address_of_gamePlayerUIs_6() { return &___gamePlayerUIs_6; }
	inline void set_gamePlayerUIs_6(LP_1_t1065117528 * value)
	{
		___gamePlayerUIs_6 = value;
		Il2CppCodeGenWriteBarrier(&___gamePlayerUIs_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
