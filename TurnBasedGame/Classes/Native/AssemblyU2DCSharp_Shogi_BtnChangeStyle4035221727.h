#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1883957898.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.BtnChangeStyle
struct  BtnChangeStyle_t4035221727  : public UIBehavior_1_t1883957898
{
public:
	// UnityEngine.UI.Text Shogi.BtnChangeStyle::txtStyle
	Text_t356221433 * ___txtStyle_6;
	// Shogi.ShogiGameDataUI/UIData Shogi.BtnChangeStyle::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_7;

public:
	inline static int32_t get_offset_of_txtStyle_6() { return static_cast<int32_t>(offsetof(BtnChangeStyle_t4035221727, ___txtStyle_6)); }
	inline Text_t356221433 * get_txtStyle_6() const { return ___txtStyle_6; }
	inline Text_t356221433 ** get_address_of_txtStyle_6() { return &___txtStyle_6; }
	inline void set_txtStyle_6(Text_t356221433 * value)
	{
		___txtStyle_6 = value;
		Il2CppCodeGenWriteBarrier(&___txtStyle_6, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_7() { return static_cast<int32_t>(offsetof(BtnChangeStyle_t4035221727, ___shogiGameDataUIData_7)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_7() const { return ___shogiGameDataUIData_7; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_7() { return &___shogiGameDataUIData_7; }
	inline void set_shogiGameDataUIData_7(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
