#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro3356008721.h"

// Shogi.NoneRule.ChoosePieceHolder
struct ChoosePieceHolder_t312252573;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// Shogi.NoneRuleInputUI/UIData
struct UIData_t1907341415;
// Shogi.NoneRule.SetPieceUI/UIData
struct UIData_t78806563;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ChoosePieceAdapter
struct  ChoosePieceAdapter_t1948703674  : public SRIA_2_t3356008721
{
public:
	// Shogi.NoneRule.ChoosePieceHolder Shogi.NoneRule.ChoosePieceAdapter::holderPrefab
	ChoosePieceHolder_t312252573 * ___holderPrefab_24;
	// UnityEngine.GameObject Shogi.NoneRule.ChoosePieceAdapter::noPieces
	GameObject_t1756533147 * ___noPieces_25;
	// Shogi.NoneRuleInputUI/UIData Shogi.NoneRule.ChoosePieceAdapter::noneRuleInputUIData
	UIData_t1907341415 * ___noneRuleInputUIData_26;
	// Shogi.NoneRule.SetPieceUI/UIData Shogi.NoneRule.ChoosePieceAdapter::setPieceUIData
	UIData_t78806563 * ___setPieceUIData_27;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t1948703674, ___holderPrefab_24)); }
	inline ChoosePieceHolder_t312252573 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChoosePieceHolder_t312252573 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChoosePieceHolder_t312252573 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noPieces_25() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t1948703674, ___noPieces_25)); }
	inline GameObject_t1756533147 * get_noPieces_25() const { return ___noPieces_25; }
	inline GameObject_t1756533147 ** get_address_of_noPieces_25() { return &___noPieces_25; }
	inline void set_noPieces_25(GameObject_t1756533147 * value)
	{
		___noPieces_25 = value;
		Il2CppCodeGenWriteBarrier(&___noPieces_25, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_26() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t1948703674, ___noneRuleInputUIData_26)); }
	inline UIData_t1907341415 * get_noneRuleInputUIData_26() const { return ___noneRuleInputUIData_26; }
	inline UIData_t1907341415 ** get_address_of_noneRuleInputUIData_26() { return &___noneRuleInputUIData_26; }
	inline void set_noneRuleInputUIData_26(UIData_t1907341415 * value)
	{
		___noneRuleInputUIData_26 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_26, value);
	}

	inline static int32_t get_offset_of_setPieceUIData_27() { return static_cast<int32_t>(offsetof(ChoosePieceAdapter_t1948703674, ___setPieceUIData_27)); }
	inline UIData_t78806563 * get_setPieceUIData_27() const { return ___setPieceUIData_27; }
	inline UIData_t78806563 ** get_address_of_setPieceUIData_27() { return &___setPieceUIData_27; }
	inline void set_setPieceUIData_27(UIData_t78806563 * value)
	{
		___setPieceUIData_27 = value;
		Il2CppCodeGenWriteBarrier(&___setPieceUIData_27, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
