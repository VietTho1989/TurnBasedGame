#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2820813282.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// ConfirmSaveDataUI
struct ConfirmSaveDataUI_t1758719233;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BtnSaveDataUI
struct  BtnSaveDataUI_t2899471139  : public UIBehavior_1_t2820813282
{
public:
	// UnityEngine.UI.Button BtnSaveDataUI::btnSaveData
	Button_t2872111280 * ___btnSaveData_6;
	// UnityEngine.UI.Text BtnSaveDataUI::tvSaveData
	Text_t356221433 * ___tvSaveData_7;
	// ConfirmSaveDataUI BtnSaveDataUI::confirmSaveDataPrefab
	ConfirmSaveDataUI_t1758719233 * ___confirmSaveDataPrefab_8;

public:
	inline static int32_t get_offset_of_btnSaveData_6() { return static_cast<int32_t>(offsetof(BtnSaveDataUI_t2899471139, ___btnSaveData_6)); }
	inline Button_t2872111280 * get_btnSaveData_6() const { return ___btnSaveData_6; }
	inline Button_t2872111280 ** get_address_of_btnSaveData_6() { return &___btnSaveData_6; }
	inline void set_btnSaveData_6(Button_t2872111280 * value)
	{
		___btnSaveData_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnSaveData_6, value);
	}

	inline static int32_t get_offset_of_tvSaveData_7() { return static_cast<int32_t>(offsetof(BtnSaveDataUI_t2899471139, ___tvSaveData_7)); }
	inline Text_t356221433 * get_tvSaveData_7() const { return ___tvSaveData_7; }
	inline Text_t356221433 ** get_address_of_tvSaveData_7() { return &___tvSaveData_7; }
	inline void set_tvSaveData_7(Text_t356221433 * value)
	{
		___tvSaveData_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvSaveData_7, value);
	}

	inline static int32_t get_offset_of_confirmSaveDataPrefab_8() { return static_cast<int32_t>(offsetof(BtnSaveDataUI_t2899471139, ___confirmSaveDataPrefab_8)); }
	inline ConfirmSaveDataUI_t1758719233 * get_confirmSaveDataPrefab_8() const { return ___confirmSaveDataPrefab_8; }
	inline ConfirmSaveDataUI_t1758719233 ** get_address_of_confirmSaveDataPrefab_8() { return &___confirmSaveDataPrefab_8; }
	inline void set_confirmSaveDataPrefab_8(ConfirmSaveDataUI_t1758719233 * value)
	{
		___confirmSaveDataPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___confirmSaveDataPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
