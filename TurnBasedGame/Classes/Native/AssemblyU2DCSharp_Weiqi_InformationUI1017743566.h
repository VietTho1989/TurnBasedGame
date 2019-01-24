#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3460735386.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Button
struct Button_t2872111280;
// Weiqi.WeiqiGameDataUI/UIData
struct UIData_t3165614177;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.InformationUI
struct  InformationUI_t1017743566  : public UIBehavior_1_t3460735386
{
public:
	// UnityEngine.UI.Text Weiqi.InformationUI::tvScore
	Text_t356221433 * ___tvScore_6;
	// UnityEngine.UI.Button Weiqi.InformationUI::btnToggleScore
	Button_t2872111280 * ___btnToggleScore_7;
	// Weiqi.WeiqiGameDataUI/UIData Weiqi.InformationUI::weiqiGameDataUIData
	UIData_t3165614177 * ___weiqiGameDataUIData_8;

public:
	inline static int32_t get_offset_of_tvScore_6() { return static_cast<int32_t>(offsetof(InformationUI_t1017743566, ___tvScore_6)); }
	inline Text_t356221433 * get_tvScore_6() const { return ___tvScore_6; }
	inline Text_t356221433 ** get_address_of_tvScore_6() { return &___tvScore_6; }
	inline void set_tvScore_6(Text_t356221433 * value)
	{
		___tvScore_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvScore_6, value);
	}

	inline static int32_t get_offset_of_btnToggleScore_7() { return static_cast<int32_t>(offsetof(InformationUI_t1017743566, ___btnToggleScore_7)); }
	inline Button_t2872111280 * get_btnToggleScore_7() const { return ___btnToggleScore_7; }
	inline Button_t2872111280 ** get_address_of_btnToggleScore_7() { return &___btnToggleScore_7; }
	inline void set_btnToggleScore_7(Button_t2872111280 * value)
	{
		___btnToggleScore_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnToggleScore_7, value);
	}

	inline static int32_t get_offset_of_weiqiGameDataUIData_8() { return static_cast<int32_t>(offsetof(InformationUI_t1017743566, ___weiqiGameDataUIData_8)); }
	inline UIData_t3165614177 * get_weiqiGameDataUIData_8() const { return ___weiqiGameDataUIData_8; }
	inline UIData_t3165614177 ** get_address_of_weiqiGameDataUIData_8() { return &___weiqiGameDataUIData_8; }
	inline void set_weiqiGameDataUIData_8(UIData_t3165614177 * value)
	{
		___weiqiGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
