#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4051964099.h"

// LanClientMenuUI
struct LanClientMenuUI_t1974705819;
// LanClientPlayUI
struct LanClientPlayUI_t3304478500;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LanClientUI
struct  LanClientUI_t2473971654  : public UIBehavior_1_t4051964099
{
public:
	// LanClientMenuUI LanClientUI::lanClientMenuPrefab
	LanClientMenuUI_t1974705819 * ___lanClientMenuPrefab_6;
	// LanClientPlayUI LanClientUI::lanClientPlayPrefab
	LanClientPlayUI_t3304478500 * ___lanClientPlayPrefab_7;

public:
	inline static int32_t get_offset_of_lanClientMenuPrefab_6() { return static_cast<int32_t>(offsetof(LanClientUI_t2473971654, ___lanClientMenuPrefab_6)); }
	inline LanClientMenuUI_t1974705819 * get_lanClientMenuPrefab_6() const { return ___lanClientMenuPrefab_6; }
	inline LanClientMenuUI_t1974705819 ** get_address_of_lanClientMenuPrefab_6() { return &___lanClientMenuPrefab_6; }
	inline void set_lanClientMenuPrefab_6(LanClientMenuUI_t1974705819 * value)
	{
		___lanClientMenuPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___lanClientMenuPrefab_6, value);
	}

	inline static int32_t get_offset_of_lanClientPlayPrefab_7() { return static_cast<int32_t>(offsetof(LanClientUI_t2473971654, ___lanClientPlayPrefab_7)); }
	inline LanClientPlayUI_t3304478500 * get_lanClientPlayPrefab_7() const { return ___lanClientPlayPrefab_7; }
	inline LanClientPlayUI_t3304478500 ** get_address_of_lanClientPlayPrefab_7() { return &___lanClientPlayPrefab_7; }
	inline void set_lanClientPlayPrefab_7(LanClientPlayUI_t3304478500 * value)
	{
		___lanClientPlayPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___lanClientPlayPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
