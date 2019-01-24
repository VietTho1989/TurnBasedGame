#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen327523020.h"

// LanMenuUI
struct LanMenuUI_t102455554;
// LanHostUI
struct LanHostUI_t3136202577;
// LanClientUI
struct LanClientUI_t2473971654;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LanUI
struct  LanUI_t2500194061  : public UIBehavior_1_t327523020
{
public:
	// LanMenuUI LanUI::menuPrefab
	LanMenuUI_t102455554 * ___menuPrefab_7;
	// LanHostUI LanUI::hostPrefab
	LanHostUI_t3136202577 * ___hostPrefab_8;
	// LanClientUI LanUI::clientPrefab
	LanClientUI_t2473971654 * ___clientPrefab_9;

public:
	inline static int32_t get_offset_of_menuPrefab_7() { return static_cast<int32_t>(offsetof(LanUI_t2500194061, ___menuPrefab_7)); }
	inline LanMenuUI_t102455554 * get_menuPrefab_7() const { return ___menuPrefab_7; }
	inline LanMenuUI_t102455554 ** get_address_of_menuPrefab_7() { return &___menuPrefab_7; }
	inline void set_menuPrefab_7(LanMenuUI_t102455554 * value)
	{
		___menuPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___menuPrefab_7, value);
	}

	inline static int32_t get_offset_of_hostPrefab_8() { return static_cast<int32_t>(offsetof(LanUI_t2500194061, ___hostPrefab_8)); }
	inline LanHostUI_t3136202577 * get_hostPrefab_8() const { return ___hostPrefab_8; }
	inline LanHostUI_t3136202577 ** get_address_of_hostPrefab_8() { return &___hostPrefab_8; }
	inline void set_hostPrefab_8(LanHostUI_t3136202577 * value)
	{
		___hostPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___hostPrefab_8, value);
	}

	inline static int32_t get_offset_of_clientPrefab_9() { return static_cast<int32_t>(offsetof(LanUI_t2500194061, ___clientPrefab_9)); }
	inline LanClientUI_t2473971654 * get_clientPrefab_9() const { return ___clientPrefab_9; }
	inline LanClientUI_t2473971654 ** get_address_of_clientPrefab_9() { return &___clientPrefab_9; }
	inline void set_clientPrefab_9(LanClientUI_t2473971654 * value)
	{
		___clientPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___clientPrefab_9, value);
	}
};

struct LanUI_t2500194061_StaticFields
{
public:
	// System.Boolean LanUI::log
	bool ___log_6;

public:
	inline static int32_t get_offset_of_log_6() { return static_cast<int32_t>(offsetof(LanUI_t2500194061_StaticFields, ___log_6)); }
	inline bool get_log_6() const { return ___log_6; }
	inline bool* get_address_of_log_6() { return &___log_6; }
	inline void set_log_6(bool value)
	{
		___log_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
