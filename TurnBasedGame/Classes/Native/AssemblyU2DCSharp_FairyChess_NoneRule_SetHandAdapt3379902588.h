#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro2591617563.h"

// FairyChess.NoneRule.SetHandHolder
struct SetHandHolder_t2816521467;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// FairyChess.NoneRuleInputUI/UIData
struct UIData_t1139753962;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.NoneRule.SetHandAdapter
struct  SetHandAdapter_t3379902588  : public SRIA_2_t2591617563
{
public:
	// FairyChess.NoneRule.SetHandHolder FairyChess.NoneRule.SetHandAdapter::holderPrefab
	SetHandHolder_t2816521467 * ___holderPrefab_24;
	// UnityEngine.GameObject FairyChess.NoneRule.SetHandAdapter::noPieces
	GameObject_t1756533147 * ___noPieces_25;
	// FairyChess.NoneRuleInputUI/UIData FairyChess.NoneRule.SetHandAdapter::noneRuleInputUIData
	UIData_t1139753962 * ___noneRuleInputUIData_26;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(SetHandAdapter_t3379902588, ___holderPrefab_24)); }
	inline SetHandHolder_t2816521467 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline SetHandHolder_t2816521467 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(SetHandHolder_t2816521467 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noPieces_25() { return static_cast<int32_t>(offsetof(SetHandAdapter_t3379902588, ___noPieces_25)); }
	inline GameObject_t1756533147 * get_noPieces_25() const { return ___noPieces_25; }
	inline GameObject_t1756533147 ** get_address_of_noPieces_25() { return &___noPieces_25; }
	inline void set_noPieces_25(GameObject_t1756533147 * value)
	{
		___noPieces_25 = value;
		Il2CppCodeGenWriteBarrier(&___noPieces_25, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_26() { return static_cast<int32_t>(offsetof(SetHandAdapter_t3379902588, ___noneRuleInputUIData_26)); }
	inline UIData_t1139753962 * get_noneRuleInputUIData_26() const { return ___noneRuleInputUIData_26; }
	inline UIData_t1139753962 ** get_address_of_noneRuleInputUIData_26() { return &___noneRuleInputUIData_26; }
	inline void set_noneRuleInputUIData_26(UIData_t1139753962 * value)
	{
		___noneRuleInputUIData_26 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_26, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
