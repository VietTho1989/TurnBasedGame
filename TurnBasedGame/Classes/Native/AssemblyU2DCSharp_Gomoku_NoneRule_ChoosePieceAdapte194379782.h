#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1491065281.h"

// Gomoku.NoneRule.ChoosePieceHolder
struct ChoosePieceHolder_t2609302149;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// Gomoku.NoneRuleInputUI/UIData
struct UIData_t4109331981;
// Gomoku.NoneRule.SetPieceUI/UIData
struct UIData_t1129684821;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.NoneRule.ChoosePieceAdapter
struct  ChoosePieceAdapter_t194379782  : public SRIA_2_t1491065281
{
public:
	// Gomoku.NoneRule.ChoosePieceHolder Gomoku.NoneRule.ChoosePieceAdapter::holderPrefab
	ChoosePieceHolder_t2609302149 * ___holderPrefab_24;
	// UnityEngine.GameObject Gomoku.NoneRule.ChoosePieceAdapter::noPieces
	GameObject_t1756533147 * ___noPieces_25;
	// Gomoku.NoneRuleInputUI/UIData Gomoku.NoneRule.ChoosePieceAdapter::noneRuleInputUIData
	UIData_t4109331981 * ___noneRuleInputUIData_26;
	// Gomoku.NoneRule.SetPieceUI/UIData Gomoku.NoneRule.ChoosePieceAdapter::setPieceUIData
	UIData_t1129684821 * ___setPieceUIData_27;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t194379782, ___holderPrefab_24)); }
	inline ChoosePieceHolder_t2609302149 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChoosePieceHolder_t2609302149 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChoosePieceHolder_t2609302149 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noPieces_25() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t194379782, ___noPieces_25)); }
	inline GameObject_t1756533147 * get_noPieces_25() const { return ___noPieces_25; }
	inline GameObject_t1756533147 ** get_address_of_noPieces_25() { return &___noPieces_25; }
	inline void set_noPieces_25(GameObject_t1756533147 * value)
	{
		___noPieces_25 = value;
		Il2CppCodeGenWriteBarrier(&___noPieces_25, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_26() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t194379782, ___noneRuleInputUIData_26)); }
	inline UIData_t4109331981 * get_noneRuleInputUIData_26() const { return ___noneRuleInputUIData_26; }
	inline UIData_t4109331981 ** get_address_of_noneRuleInputUIData_26() { return &___noneRuleInputUIData_26; }
	inline void set_noneRuleInputUIData_26(UIData_t4109331981 * value)
	{
		___noneRuleInputUIData_26 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_26, value);
	}

	inline static int32_t get_offset_of_setPieceUIData_27() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t194379782, ___setPieceUIData_27)); }
	inline UIData_t1129684821 * get_setPieceUIData_27() const { return ___setPieceUIData_27; }
	inline UIData_t1129684821 ** get_address_of_setPieceUIData_27() { return &___setPieceUIData_27; }
	inline void set_setPieceUIData_27(UIData_t1129684821 * value)
	{
		___setPieceUIData_27 = value;
		Il2CppCodeGenWriteBarrier(&___setPieceUIData_27, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
