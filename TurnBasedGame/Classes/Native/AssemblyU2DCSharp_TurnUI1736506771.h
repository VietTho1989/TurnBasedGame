#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2310783960.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TurnUI
struct  TurnUI_t1736506771  : public UIBehavior_1_t2310783960
{
public:
	// UnityEngine.UI.Text TurnUI::tvTurn
	Text_t356221433 * ___tvTurn_6;
	// UnityEngine.UI.Text TurnUI::tvWho
	Text_t356221433 * ___tvWho_7;

public:
	inline static int32_t get_offset_of_tvTurn_6() { return static_cast<int32_t>(offsetof(TurnUI_t1736506771, ___tvTurn_6)); }
	inline Text_t356221433 * get_tvTurn_6() const { return ___tvTurn_6; }
	inline Text_t356221433 ** get_address_of_tvTurn_6() { return &___tvTurn_6; }
	inline void set_tvTurn_6(Text_t356221433 * value)
	{
		___tvTurn_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvTurn_6, value);
	}

	inline static int32_t get_offset_of_tvWho_7() { return static_cast<int32_t>(offsetof(TurnUI_t1736506771, ___tvWho_7)); }
	inline Text_t356221433 * get_tvWho_7() const { return ___tvWho_7; }
	inline Text_t356221433 ** get_address_of_tvWho_7() { return &___tvWho_7; }
	inline void set_tvWho_7(Text_t356221433 * value)
	{
		___tvWho_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvWho_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
