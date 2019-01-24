#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen506394999.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.InputField
struct InputField_t1631627530;
// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.Transform
struct Transform_t3275118058;
// MiniGameDataUI
struct MiniGameDataUI_t29488987;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.ChoosePostureHolder
struct  ChoosePostureHolder_t3952098609  : public SriaHolderBehavior_1_t506394999
{
public:
	// UnityEngine.UI.Text Posture.ChoosePostureHolder::tvIndex
	Text_t356221433 * ___tvIndex_16;
	// UnityEngine.UI.InputField Posture.ChoosePostureHolder::tvName
	InputField_t1631627530 * ___tvName_17;
	// UnityEngine.UI.Button Posture.ChoosePostureHolder::btnChoose
	Button_t2872111280 * ___btnChoose_18;
	// UnityEngine.Transform Posture.ChoosePostureHolder::miniGameDataUIContainer
	Transform_t3275118058 * ___miniGameDataUIContainer_19;
	// MiniGameDataUI Posture.ChoosePostureHolder::miniGameDataPrefab
	MiniGameDataUI_t29488987 * ___miniGameDataPrefab_20;

public:
	inline static int32_t get_offset_of_tvIndex_16() { return static_cast<int32_t>(offsetof(ChoosePostureHolder_t3952098609, ___tvIndex_16)); }
	inline Text_t356221433 * get_tvIndex_16() const { return ___tvIndex_16; }
	inline Text_t356221433 ** get_address_of_tvIndex_16() { return &___tvIndex_16; }
	inline void set_tvIndex_16(Text_t356221433 * value)
	{
		___tvIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_16, value);
	}

	inline static int32_t get_offset_of_tvName_17() { return static_cast<int32_t>(offsetof(ChoosePostureHolder_t3952098609, ___tvName_17)); }
	inline InputField_t1631627530 * get_tvName_17() const { return ___tvName_17; }
	inline InputField_t1631627530 ** get_address_of_tvName_17() { return &___tvName_17; }
	inline void set_tvName_17(InputField_t1631627530 * value)
	{
		___tvName_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_17, value);
	}

	inline static int32_t get_offset_of_btnChoose_18() { return static_cast<int32_t>(offsetof(ChoosePostureHolder_t3952098609, ___btnChoose_18)); }
	inline Button_t2872111280 * get_btnChoose_18() const { return ___btnChoose_18; }
	inline Button_t2872111280 ** get_address_of_btnChoose_18() { return &___btnChoose_18; }
	inline void set_btnChoose_18(Button_t2872111280 * value)
	{
		___btnChoose_18 = value;
		Il2CppCodeGenWriteBarrier(&___btnChoose_18, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIContainer_19() { return static_cast<int32_t>(offsetof(ChoosePostureHolder_t3952098609, ___miniGameDataUIContainer_19)); }
	inline Transform_t3275118058 * get_miniGameDataUIContainer_19() const { return ___miniGameDataUIContainer_19; }
	inline Transform_t3275118058 ** get_address_of_miniGameDataUIContainer_19() { return &___miniGameDataUIContainer_19; }
	inline void set_miniGameDataUIContainer_19(Transform_t3275118058 * value)
	{
		___miniGameDataUIContainer_19 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIContainer_19, value);
	}

	inline static int32_t get_offset_of_miniGameDataPrefab_20() { return static_cast<int32_t>(offsetof(ChoosePostureHolder_t3952098609, ___miniGameDataPrefab_20)); }
	inline MiniGameDataUI_t29488987 * get_miniGameDataPrefab_20() const { return ___miniGameDataPrefab_20; }
	inline MiniGameDataUI_t29488987 ** get_address_of_miniGameDataPrefab_20() { return &___miniGameDataPrefab_20; }
	inline void set_miniGameDataPrefab_20(MiniGameDataUI_t29488987 * value)
	{
		___miniGameDataPrefab_20 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataPrefab_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
