#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen244701851.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;
// Seirawan.NoneRuleInputUI/UIData
struct UIData_t3921195857;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.NoneRule.SetHandHolder
struct  SetHandHolder_t3169561801  : public SriaHolderBehavior_1_t244701851
{
public:
	// UnityEngine.UI.Image Seirawan.NoneRule.SetHandHolder::imgPiece
	Image_t2042527209 * ___imgPiece_16;
	// UnityEngine.UI.Text Seirawan.NoneRule.SetHandHolder::tvSet
	Text_t356221433 * ___tvSet_17;
	// Seirawan.NoneRuleInputUI/UIData Seirawan.NoneRule.SetHandHolder::noneRuleInputUIData
	UIData_t3921195857 * ___noneRuleInputUIData_18;

public:
	inline static int32_t get_offset_of_imgPiece_16() { return static_cast<int32_t>(offsetof(SetHandHolder_t3169561801, ___imgPiece_16)); }
	inline Image_t2042527209 * get_imgPiece_16() const { return ___imgPiece_16; }
	inline Image_t2042527209 ** get_address_of_imgPiece_16() { return &___imgPiece_16; }
	inline void set_imgPiece_16(Image_t2042527209 * value)
	{
		___imgPiece_16 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_16, value);
	}

	inline static int32_t get_offset_of_tvSet_17() { return static_cast<int32_t>(offsetof(SetHandHolder_t3169561801, ___tvSet_17)); }
	inline Text_t356221433 * get_tvSet_17() const { return ___tvSet_17; }
	inline Text_t356221433 ** get_address_of_tvSet_17() { return &___tvSet_17; }
	inline void set_tvSet_17(Text_t356221433 * value)
	{
		___tvSet_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvSet_17, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_18() { return static_cast<int32_t>(offsetof(SetHandHolder_t3169561801, ___noneRuleInputUIData_18)); }
	inline UIData_t3921195857 * get_noneRuleInputUIData_18() const { return ___noneRuleInputUIData_18; }
	inline UIData_t3921195857 ** get_address_of_noneRuleInputUIData_18() { return &___noneRuleInputUIData_18; }
	inline void set_noneRuleInputUIData_18(UIData_t3921195857 * value)
	{
		___noneRuleInputUIData_18 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
