#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2468803437.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// ViewSaveDataUI
struct ViewSaveDataUI_t4233183598;
// BtnLoadHistoryUI
struct BtnLoadHistoryUI_t3133618714;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameHistoryUI
struct  GameHistoryUI_t2680091484  : public UIBehavior_1_t2468803437
{
public:
	// UnityEngine.UI.Button GameHistoryUI::btnView
	Button_t2872111280 * ___btnView_6;
	// UnityEngine.UI.Text GameHistoryUI::tvView
	Text_t356221433 * ___tvView_7;
	// ViewSaveDataUI GameHistoryUI::viewSaveDataPrefab
	ViewSaveDataUI_t4233183598 * ___viewSaveDataPrefab_8;
	// BtnLoadHistoryUI GameHistoryUI::btnLoadHistoryPrefab
	BtnLoadHistoryUI_t3133618714 * ___btnLoadHistoryPrefab_9;
	// UnityEngine.Transform GameHistoryUI::btnLoadHistoryContainer
	Transform_t3275118058 * ___btnLoadHistoryContainer_10;

public:
	inline static int32_t get_offset_of_btnView_6() { return static_cast<int32_t>(offsetof(GameHistoryUI_t2680091484, ___btnView_6)); }
	inline Button_t2872111280 * get_btnView_6() const { return ___btnView_6; }
	inline Button_t2872111280 ** get_address_of_btnView_6() { return &___btnView_6; }
	inline void set_btnView_6(Button_t2872111280 * value)
	{
		___btnView_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnView_6, value);
	}

	inline static int32_t get_offset_of_tvView_7() { return static_cast<int32_t>(offsetof(GameHistoryUI_t2680091484, ___tvView_7)); }
	inline Text_t356221433 * get_tvView_7() const { return ___tvView_7; }
	inline Text_t356221433 ** get_address_of_tvView_7() { return &___tvView_7; }
	inline void set_tvView_7(Text_t356221433 * value)
	{
		___tvView_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvView_7, value);
	}

	inline static int32_t get_offset_of_viewSaveDataPrefab_8() { return static_cast<int32_t>(offsetof(GameHistoryUI_t2680091484, ___viewSaveDataPrefab_8)); }
	inline ViewSaveDataUI_t4233183598 * get_viewSaveDataPrefab_8() const { return ___viewSaveDataPrefab_8; }
	inline ViewSaveDataUI_t4233183598 ** get_address_of_viewSaveDataPrefab_8() { return &___viewSaveDataPrefab_8; }
	inline void set_viewSaveDataPrefab_8(ViewSaveDataUI_t4233183598 * value)
	{
		___viewSaveDataPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___viewSaveDataPrefab_8, value);
	}

	inline static int32_t get_offset_of_btnLoadHistoryPrefab_9() { return static_cast<int32_t>(offsetof(GameHistoryUI_t2680091484, ___btnLoadHistoryPrefab_9)); }
	inline BtnLoadHistoryUI_t3133618714 * get_btnLoadHistoryPrefab_9() const { return ___btnLoadHistoryPrefab_9; }
	inline BtnLoadHistoryUI_t3133618714 ** get_address_of_btnLoadHistoryPrefab_9() { return &___btnLoadHistoryPrefab_9; }
	inline void set_btnLoadHistoryPrefab_9(BtnLoadHistoryUI_t3133618714 * value)
	{
		___btnLoadHistoryPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___btnLoadHistoryPrefab_9, value);
	}

	inline static int32_t get_offset_of_btnLoadHistoryContainer_10() { return static_cast<int32_t>(offsetof(GameHistoryUI_t2680091484, ___btnLoadHistoryContainer_10)); }
	inline Transform_t3275118058 * get_btnLoadHistoryContainer_10() const { return ___btnLoadHistoryContainer_10; }
	inline Transform_t3275118058 ** get_address_of_btnLoadHistoryContainer_10() { return &___btnLoadHistoryContainer_10; }
	inline void set_btnLoadHistoryContainer_10(Transform_t3275118058 * value)
	{
		___btnLoadHistoryContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___btnLoadHistoryContainer_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
