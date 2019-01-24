#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen455989674.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// Record.SaveRecordUI
struct SaveRecordUI_t1608480274;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.DataRecordTaskUI
struct  DataRecordTaskUI_t677355526  : public UIBehavior_1_t455989674
{
public:
	// UnityEngine.UI.Button Record.DataRecordTaskUI::btnRecord
	Button_t2872111280 * ___btnRecord_6;
	// UnityEngine.UI.Text Record.DataRecordTaskUI::tvRecord
	Text_t356221433 * ___tvRecord_7;
	// Record.SaveRecordUI Record.DataRecordTaskUI::saveRecordUIPrefab
	SaveRecordUI_t1608480274 * ___saveRecordUIPrefab_8;

public:
	inline static int32_t get_offset_of_btnRecord_6() { return static_cast<int32_t>(offsetof(DataRecordTaskUI_t677355526, ___btnRecord_6)); }
	inline Button_t2872111280 * get_btnRecord_6() const { return ___btnRecord_6; }
	inline Button_t2872111280 ** get_address_of_btnRecord_6() { return &___btnRecord_6; }
	inline void set_btnRecord_6(Button_t2872111280 * value)
	{
		___btnRecord_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnRecord_6, value);
	}

	inline static int32_t get_offset_of_tvRecord_7() { return static_cast<int32_t>(offsetof(DataRecordTaskUI_t677355526, ___tvRecord_7)); }
	inline Text_t356221433 * get_tvRecord_7() const { return ___tvRecord_7; }
	inline Text_t356221433 ** get_address_of_tvRecord_7() { return &___tvRecord_7; }
	inline void set_tvRecord_7(Text_t356221433 * value)
	{
		___tvRecord_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvRecord_7, value);
	}

	inline static int32_t get_offset_of_saveRecordUIPrefab_8() { return static_cast<int32_t>(offsetof(DataRecordTaskUI_t677355526, ___saveRecordUIPrefab_8)); }
	inline SaveRecordUI_t1608480274 * get_saveRecordUIPrefab_8() const { return ___saveRecordUIPrefab_8; }
	inline SaveRecordUI_t1608480274 ** get_address_of_saveRecordUIPrefab_8() { return &___saveRecordUIPrefab_8; }
	inline void set_saveRecordUIPrefab_8(SaveRecordUI_t1608480274 * value)
	{
		___saveRecordUIPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___saveRecordUIPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
