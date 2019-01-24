#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4251107084.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerTeamUI
struct  ChooseContestManagerTeamUI_t4165925413  : public UIBehavior_1_t4251107084
{
public:
	// UnityEngine.UI.Text GameManager.Match.ChooseContestManagerTeamUI::tvIndex
	Text_t356221433 * ___tvIndex_6;
	// UnityEngine.UI.Text GameManager.Match.ChooseContestManagerTeamUI::tvScore
	Text_t356221433 * ___tvScore_7;
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.ChooseContestManagerTeamUI::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_8;

public:
	inline static int32_t get_offset_of_tvIndex_6() { return static_cast<int32_t>(offsetof(ChooseContestManagerTeamUI_t4165925413, ___tvIndex_6)); }
	inline Text_t356221433 * get_tvIndex_6() const { return ___tvIndex_6; }
	inline Text_t356221433 ** get_address_of_tvIndex_6() { return &___tvIndex_6; }
	inline void set_tvIndex_6(Text_t356221433 * value)
	{
		___tvIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_6, value);
	}

	inline static int32_t get_offset_of_tvScore_7() { return static_cast<int32_t>(offsetof(ChooseContestManagerTeamUI_t4165925413, ___tvScore_7)); }
	inline Text_t356221433 * get_tvScore_7() const { return ___tvScore_7; }
	inline Text_t356221433 ** get_address_of_tvScore_7() { return &___tvScore_7; }
	inline void set_tvScore_7(Text_t356221433 * value)
	{
		___tvScore_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvScore_7, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlay_8() { return static_cast<int32_t>(offsetof(ChooseContestManagerTeamUI_t4165925413, ___contestManagerStatePlay_8)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_8() const { return ___contestManagerStatePlay_8; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_8() { return &___contestManagerStatePlay_8; }
	inline void set_contestManagerStatePlay_8(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_8 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
