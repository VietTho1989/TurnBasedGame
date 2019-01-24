#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2508441001.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// FileSystem.BtnDeleteConfirmUI
struct BtnDeleteConfirmUI_t3181475839;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnDeleteUI
struct  BtnDeleteUI_t2328607507  : public UIBehavior_1_t2508441001
{
public:
	// UnityEngine.UI.Button FileSystem.BtnDeleteUI::btnDelete
	Button_t2872111280 * ___btnDelete_6;
	// UnityEngine.UI.Text FileSystem.BtnDeleteUI::tvDelete
	Text_t356221433 * ___tvDelete_7;
	// FileSystem.BtnDeleteConfirmUI FileSystem.BtnDeleteUI::btnDeleteConfirmPrefab
	BtnDeleteConfirmUI_t3181475839 * ___btnDeleteConfirmPrefab_8;

public:
	inline static int32_t get_offset_of_btnDelete_6() { return static_cast<int32_t>(offsetof(BtnDeleteUI_t2328607507, ___btnDelete_6)); }
	inline Button_t2872111280 * get_btnDelete_6() const { return ___btnDelete_6; }
	inline Button_t2872111280 ** get_address_of_btnDelete_6() { return &___btnDelete_6; }
	inline void set_btnDelete_6(Button_t2872111280 * value)
	{
		___btnDelete_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnDelete_6, value);
	}

	inline static int32_t get_offset_of_tvDelete_7() { return static_cast<int32_t>(offsetof(BtnDeleteUI_t2328607507, ___tvDelete_7)); }
	inline Text_t356221433 * get_tvDelete_7() const { return ___tvDelete_7; }
	inline Text_t356221433 ** get_address_of_tvDelete_7() { return &___tvDelete_7; }
	inline void set_tvDelete_7(Text_t356221433 * value)
	{
		___tvDelete_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvDelete_7, value);
	}

	inline static int32_t get_offset_of_btnDeleteConfirmPrefab_8() { return static_cast<int32_t>(offsetof(BtnDeleteUI_t2328607507, ___btnDeleteConfirmPrefab_8)); }
	inline BtnDeleteConfirmUI_t3181475839 * get_btnDeleteConfirmPrefab_8() const { return ___btnDeleteConfirmPrefab_8; }
	inline BtnDeleteConfirmUI_t3181475839 ** get_address_of_btnDeleteConfirmPrefab_8() { return &___btnDeleteConfirmPrefab_8; }
	inline void set_btnDeleteConfirmPrefab_8(BtnDeleteConfirmUI_t3181475839 * value)
	{
		___btnDeleteConfirmPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnDeleteConfirmPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
