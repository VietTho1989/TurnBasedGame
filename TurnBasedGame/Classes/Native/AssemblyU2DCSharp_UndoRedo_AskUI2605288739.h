#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1647859746.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// UndoRedo.AskHumanUI
struct AskHumanUI_t1248202190;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;
// UndoRedo.CheckWhoCanAskChange`1<UndoRedo.Ask>
struct CheckWhoCanAskChange_1_t825461294;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.AskUI
struct  AskUI_t2605288739  : public UIBehavior_1_t1647859746
{
public:
	// UnityEngine.UI.Button UndoRedo.AskUI::btnAccept
	Button_t2872111280 * ___btnAccept_6;
	// UnityEngine.UI.Text UndoRedo.AskUI::tvAccept
	Text_t356221433 * ___tvAccept_7;
	// UnityEngine.UI.Button UndoRedo.AskUI::btnCancel
	Button_t2872111280 * ___btnCancel_8;
	// UnityEngine.UI.Text UndoRedo.AskUI::tvCancel
	Text_t356221433 * ___tvCancel_9;
	// UnityEngine.GameObject UndoRedo.AskUI::answerContainer
	GameObject_t1756533147 * ___answerContainer_10;
	// UnityEngine.UI.Text UndoRedo.AskUI::tvRequestInform
	Text_t356221433 * ___tvRequestInform_11;
	// AdvancedCoroutines.Routine UndoRedo.AskUI::wait
	Routine_t2502590640 * ___wait_12;
	// UndoRedo.AskHumanUI UndoRedo.AskUI::askHumanPrefab
	AskHumanUI_t1248202190 * ___askHumanPrefab_13;
	// UnityEngine.Transform UndoRedo.AskUI::askHumanContainer
	Transform_t3275118058 * ___askHumanContainer_14;
	// Server UndoRedo.AskUI::server
	Server_t2724320767 * ___server_15;
	// UndoRedo.CheckWhoCanAskChange`1<UndoRedo.Ask> UndoRedo.AskUI::checkWhoCanAnswer
	CheckWhoCanAskChange_1_t825461294 * ___checkWhoCanAnswer_16;

public:
	inline static int32_t get_offset_of_btnAccept_6() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___btnAccept_6)); }
	inline Button_t2872111280 * get_btnAccept_6() const { return ___btnAccept_6; }
	inline Button_t2872111280 ** get_address_of_btnAccept_6() { return &___btnAccept_6; }
	inline void set_btnAccept_6(Button_t2872111280 * value)
	{
		___btnAccept_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnAccept_6, value);
	}

	inline static int32_t get_offset_of_tvAccept_7() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___tvAccept_7)); }
	inline Text_t356221433 * get_tvAccept_7() const { return ___tvAccept_7; }
	inline Text_t356221433 ** get_address_of_tvAccept_7() { return &___tvAccept_7; }
	inline void set_tvAccept_7(Text_t356221433 * value)
	{
		___tvAccept_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvAccept_7, value);
	}

	inline static int32_t get_offset_of_btnCancel_8() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___btnCancel_8)); }
	inline Button_t2872111280 * get_btnCancel_8() const { return ___btnCancel_8; }
	inline Button_t2872111280 ** get_address_of_btnCancel_8() { return &___btnCancel_8; }
	inline void set_btnCancel_8(Button_t2872111280 * value)
	{
		___btnCancel_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnCancel_8, value);
	}

	inline static int32_t get_offset_of_tvCancel_9() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___tvCancel_9)); }
	inline Text_t356221433 * get_tvCancel_9() const { return ___tvCancel_9; }
	inline Text_t356221433 ** get_address_of_tvCancel_9() { return &___tvCancel_9; }
	inline void set_tvCancel_9(Text_t356221433 * value)
	{
		___tvCancel_9 = value;
		Il2CppCodeGenWriteBarrier(&___tvCancel_9, value);
	}

	inline static int32_t get_offset_of_answerContainer_10() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___answerContainer_10)); }
	inline GameObject_t1756533147 * get_answerContainer_10() const { return ___answerContainer_10; }
	inline GameObject_t1756533147 ** get_address_of_answerContainer_10() { return &___answerContainer_10; }
	inline void set_answerContainer_10(GameObject_t1756533147 * value)
	{
		___answerContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___answerContainer_10, value);
	}

	inline static int32_t get_offset_of_tvRequestInform_11() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___tvRequestInform_11)); }
	inline Text_t356221433 * get_tvRequestInform_11() const { return ___tvRequestInform_11; }
	inline Text_t356221433 ** get_address_of_tvRequestInform_11() { return &___tvRequestInform_11; }
	inline void set_tvRequestInform_11(Text_t356221433 * value)
	{
		___tvRequestInform_11 = value;
		Il2CppCodeGenWriteBarrier(&___tvRequestInform_11, value);
	}

	inline static int32_t get_offset_of_wait_12() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___wait_12)); }
	inline Routine_t2502590640 * get_wait_12() const { return ___wait_12; }
	inline Routine_t2502590640 ** get_address_of_wait_12() { return &___wait_12; }
	inline void set_wait_12(Routine_t2502590640 * value)
	{
		___wait_12 = value;
		Il2CppCodeGenWriteBarrier(&___wait_12, value);
	}

	inline static int32_t get_offset_of_askHumanPrefab_13() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___askHumanPrefab_13)); }
	inline AskHumanUI_t1248202190 * get_askHumanPrefab_13() const { return ___askHumanPrefab_13; }
	inline AskHumanUI_t1248202190 ** get_address_of_askHumanPrefab_13() { return &___askHumanPrefab_13; }
	inline void set_askHumanPrefab_13(AskHumanUI_t1248202190 * value)
	{
		___askHumanPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___askHumanPrefab_13, value);
	}

	inline static int32_t get_offset_of_askHumanContainer_14() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___askHumanContainer_14)); }
	inline Transform_t3275118058 * get_askHumanContainer_14() const { return ___askHumanContainer_14; }
	inline Transform_t3275118058 ** get_address_of_askHumanContainer_14() { return &___askHumanContainer_14; }
	inline void set_askHumanContainer_14(Transform_t3275118058 * value)
	{
		___askHumanContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___askHumanContainer_14, value);
	}

	inline static int32_t get_offset_of_server_15() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___server_15)); }
	inline Server_t2724320767 * get_server_15() const { return ___server_15; }
	inline Server_t2724320767 ** get_address_of_server_15() { return &___server_15; }
	inline void set_server_15(Server_t2724320767 * value)
	{
		___server_15 = value;
		Il2CppCodeGenWriteBarrier(&___server_15, value);
	}

	inline static int32_t get_offset_of_checkWhoCanAnswer_16() { return static_cast<int32_t>(offsetof(AskUI_t2605288739, ___checkWhoCanAnswer_16)); }
	inline CheckWhoCanAskChange_1_t825461294 * get_checkWhoCanAnswer_16() const { return ___checkWhoCanAnswer_16; }
	inline CheckWhoCanAskChange_1_t825461294 ** get_address_of_checkWhoCanAnswer_16() { return &___checkWhoCanAnswer_16; }
	inline void set_checkWhoCanAnswer_16(CheckWhoCanAskChange_1_t825461294 * value)
	{
		___checkWhoCanAnswer_16 = value;
		Il2CppCodeGenWriteBarrier(&___checkWhoCanAnswer_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
