#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3727584846.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketContestTeamUI
struct  ChooseBracketContestTeamUI_t312534778  : public UIBehavior_1_t3727584846
{
public:
	// UnityEngine.UI.Text GameManager.Match.Elimination.ChooseBracketContestTeamUI::tvTeamIndex
	Text_t356221433 * ___tvTeamIndex_6;
	// UnityEngine.UI.Text GameManager.Match.Elimination.ChooseBracketContestTeamUI::tvTeamScore
	Text_t356221433 * ___tvTeamScore_7;

public:
	inline static int32_t get_offset_of_tvTeamIndex_6() { return static_cast<int32_t>(offsetof(ChooseBracketContestTeamUI_t312534778, ___tvTeamIndex_6)); }
	inline Text_t356221433 * get_tvTeamIndex_6() const { return ___tvTeamIndex_6; }
	inline Text_t356221433 ** get_address_of_tvTeamIndex_6() { return &___tvTeamIndex_6; }
	inline void set_tvTeamIndex_6(Text_t356221433 * value)
	{
		___tvTeamIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvTeamIndex_6, value);
	}

	inline static int32_t get_offset_of_tvTeamScore_7() { return static_cast<int32_t>(offsetof(ChooseBracketContestTeamUI_t312534778, ___tvTeamScore_7)); }
	inline Text_t356221433 * get_tvTeamScore_7() const { return ___tvTeamScore_7; }
	inline Text_t356221433 ** get_address_of_tvTeamScore_7() { return &___tvTeamScore_7; }
	inline void set_tvTeamScore_7(Text_t356221433 * value)
	{
		___tvTeamScore_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvTeamScore_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
