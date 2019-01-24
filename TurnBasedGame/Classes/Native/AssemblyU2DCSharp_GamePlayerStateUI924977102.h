#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen903751767.h"

// GamePlayerStateNormalUI
struct GamePlayerStateNormalUI_t1024152315;
// GamePlayerStateSurrenderUI
struct GamePlayerStateSurrenderUI_t1579862384;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerStateUI
struct  GamePlayerStateUI_t924977102  : public UIBehavior_1_t903751767
{
public:
	// GamePlayerStateNormalUI GamePlayerStateUI::normalPrefab
	GamePlayerStateNormalUI_t1024152315 * ___normalPrefab_6;
	// GamePlayerStateSurrenderUI GamePlayerStateUI::surrenderPrefab
	GamePlayerStateSurrenderUI_t1579862384 * ___surrenderPrefab_7;

public:
	inline static int32_t get_offset_of_normalPrefab_6() { return static_cast<int32_t>(offsetof(GamePlayerStateUI_t924977102, ___normalPrefab_6)); }
	inline GamePlayerStateNormalUI_t1024152315 * get_normalPrefab_6() const { return ___normalPrefab_6; }
	inline GamePlayerStateNormalUI_t1024152315 ** get_address_of_normalPrefab_6() { return &___normalPrefab_6; }
	inline void set_normalPrefab_6(GamePlayerStateNormalUI_t1024152315 * value)
	{
		___normalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___normalPrefab_6, value);
	}

	inline static int32_t get_offset_of_surrenderPrefab_7() { return static_cast<int32_t>(offsetof(GamePlayerStateUI_t924977102, ___surrenderPrefab_7)); }
	inline GamePlayerStateSurrenderUI_t1579862384 * get_surrenderPrefab_7() const { return ___surrenderPrefab_7; }
	inline GamePlayerStateSurrenderUI_t1579862384 ** get_address_of_surrenderPrefab_7() { return &___surrenderPrefab_7; }
	inline void set_surrenderPrefab_7(GamePlayerStateSurrenderUI_t1579862384 * value)
	{
		___surrenderPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___surrenderPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
