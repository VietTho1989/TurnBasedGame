#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen3777234022.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// FairyChess.NoneRuleInputUI/UIData
struct UIData_t1139753962;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.NoneRule.ChoosePieceHolder
struct  ChoosePieceHolder_t418920043  : public SriaHolderBehavior_1_t3777234022
{
public:
	// UnityEngine.UI.Image FairyChess.NoneRule.ChoosePieceHolder::imgPiece
	Image_t2042527209 * ___imgPiece_16;
	// FairyChess.NoneRuleInputUI/UIData FairyChess.NoneRule.ChoosePieceHolder::noneRuleInputUIData
	UIData_t1139753962 * ___noneRuleInputUIData_17;

public:
	inline static int32_t get_offset_of_imgPiece_16() { return static_cast<int32_t>(offsetof(ChoosePieceHolder_t418920043, ___imgPiece_16)); }
	inline Image_t2042527209 * get_imgPiece_16() const { return ___imgPiece_16; }
	inline Image_t2042527209 ** get_address_of_imgPiece_16() { return &___imgPiece_16; }
	inline void set_imgPiece_16(Image_t2042527209 * value)
	{
		___imgPiece_16 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_16, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_17() { return static_cast<int32_t>(offsetof(ChoosePieceHolder_t418920043, ___noneRuleInputUIData_17)); }
	inline UIData_t1139753962 * get_noneRuleInputUIData_17() const { return ___noneRuleInputUIData_17; }
	inline UIData_t1139753962 ** get_address_of_noneRuleInputUIData_17() { return &___noneRuleInputUIData_17; }
	inline void set_noneRuleInputUIData_17(UIData_t1139753962 * value)
	{
		___noneRuleInputUIData_17 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
