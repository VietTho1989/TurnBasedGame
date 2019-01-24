#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen3938354479.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// Shogi.NoneRuleInputUI/UIData
struct UIData_t1907341415;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;
// Shogi.NoneRule.SetHandAdapter/UIData
struct UIData_t3347612673;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.SetHandHolder
struct  SetHandHolder_t3463322887  : public SriaHolderBehavior_1_t3938354479
{
public:
	// UnityEngine.UI.Image Shogi.NoneRule.SetHandHolder::imgPiece
	Image_t2042527209 * ___imgPiece_16;
	// UnityEngine.UI.Text Shogi.NoneRule.SetHandHolder::tvPieceCount
	Text_t356221433 * ___tvPieceCount_17;
	// UnityEngine.GameObject Shogi.NoneRule.SetHandHolder::chosenIndicator
	GameObject_t1756533147 * ___chosenIndicator_18;
	// Shogi.NoneRuleInputUI/UIData Shogi.NoneRule.SetHandHolder::noneRuleInputUIData
	UIData_t1907341415 * ___noneRuleInputUIData_19;
	// Shogi.ShogiGameDataUI/UIData Shogi.NoneRule.SetHandHolder::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_20;
	// Shogi.NoneRule.SetHandAdapter/UIData Shogi.NoneRule.SetHandHolder::setHandAdapterUIData
	UIData_t3347612673 * ___setHandAdapterUIData_21;

public:
	inline static int32_t get_offset_of_imgPiece_16() { return static_cast<int32_t>(offsetof(SetHandHolder_t3463322887, ___imgPiece_16)); }
	inline Image_t2042527209 * get_imgPiece_16() const { return ___imgPiece_16; }
	inline Image_t2042527209 ** get_address_of_imgPiece_16() { return &___imgPiece_16; }
	inline void set_imgPiece_16(Image_t2042527209 * value)
	{
		___imgPiece_16 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_16, value);
	}

	inline static int32_t get_offset_of_tvPieceCount_17() { return static_cast<int32_t>(offsetof(SetHandHolder_t3463322887, ___tvPieceCount_17)); }
	inline Text_t356221433 * get_tvPieceCount_17() const { return ___tvPieceCount_17; }
	inline Text_t356221433 ** get_address_of_tvPieceCount_17() { return &___tvPieceCount_17; }
	inline void set_tvPieceCount_17(Text_t356221433 * value)
	{
		___tvPieceCount_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvPieceCount_17, value);
	}

	inline static int32_t get_offset_of_chosenIndicator_18() { return static_cast<int32_t>(offsetof(SetHandHolder_t3463322887, ___chosenIndicator_18)); }
	inline GameObject_t1756533147 * get_chosenIndicator_18() const { return ___chosenIndicator_18; }
	inline GameObject_t1756533147 ** get_address_of_chosenIndicator_18() { return &___chosenIndicator_18; }
	inline void set_chosenIndicator_18(GameObject_t1756533147 * value)
	{
		___chosenIndicator_18 = value;
		Il2CppCodeGenWriteBarrier(&___chosenIndicator_18, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_19() { return static_cast<int32_t>(offsetof(SetHandHolder_t3463322887, ___noneRuleInputUIData_19)); }
	inline UIData_t1907341415 * get_noneRuleInputUIData_19() const { return ___noneRuleInputUIData_19; }
	inline UIData_t1907341415 ** get_address_of_noneRuleInputUIData_19() { return &___noneRuleInputUIData_19; }
	inline void set_noneRuleInputUIData_19(UIData_t1907341415 * value)
	{
		___noneRuleInputUIData_19 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_19, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_20() { return static_cast<int32_t>(offsetof(SetHandHolder_t3463322887, ___shogiGameDataUIData_20)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_20() const { return ___shogiGameDataUIData_20; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_20() { return &___shogiGameDataUIData_20; }
	inline void set_shogiGameDataUIData_20(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_20 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_20, value);
	}

	inline static int32_t get_offset_of_setHandAdapterUIData_21() { return static_cast<int32_t>(offsetof(SetHandHolder_t3463322887, ___setHandAdapterUIData_21)); }
	inline UIData_t3347612673 * get_setHandAdapterUIData_21() const { return ___setHandAdapterUIData_21; }
	inline UIData_t3347612673 ** get_address_of_setHandAdapterUIData_21() { return &___setHandAdapterUIData_21; }
	inline void set_setHandAdapterUIData_21(UIData_t3347612673 * value)
	{
		___setHandAdapterUIData_21 = value;
		Il2CppCodeGenWriteBarrier(&___setHandAdapterUIData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
