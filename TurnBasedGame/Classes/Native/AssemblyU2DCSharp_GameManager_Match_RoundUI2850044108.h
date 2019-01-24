#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1910288185.h"

// GameManager.Match.RoundGameUI
struct RoundGameUI_t1254864718;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.ChooseRoundGameUI
struct ChooseRoundGameUI_t1849796619;
// RoomUI/UIData
struct UIData_t2598208972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundUI
struct  RoundUI_t2850044108  : public UIBehavior_1_t1910288185
{
public:
	// GameManager.Match.RoundGameUI GameManager.Match.RoundUI::roundGamePrefab
	RoundGameUI_t1254864718 * ___roundGamePrefab_6;
	// UnityEngine.Transform GameManager.Match.RoundUI::roundGameContainer
	Transform_t3275118058 * ___roundGameContainer_7;
	// GameManager.Match.ChooseRoundGameUI GameManager.Match.RoundUI::chooseRoundGamePrefab
	ChooseRoundGameUI_t1849796619 * ___chooseRoundGamePrefab_8;
	// UnityEngine.Transform GameManager.Match.RoundUI::chooseRoundGameContainer
	Transform_t3275118058 * ___chooseRoundGameContainer_9;
	// RoomUI/UIData GameManager.Match.RoundUI::roomUIData
	UIData_t2598208972 * ___roomUIData_10;

public:
	inline static int32_t get_offset_of_roundGamePrefab_6() { return static_cast<int32_t>(offsetof(RoundUI_t2850044108, ___roundGamePrefab_6)); }
	inline RoundGameUI_t1254864718 * get_roundGamePrefab_6() const { return ___roundGamePrefab_6; }
	inline RoundGameUI_t1254864718 ** get_address_of_roundGamePrefab_6() { return &___roundGamePrefab_6; }
	inline void set_roundGamePrefab_6(RoundGameUI_t1254864718 * value)
	{
		___roundGamePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___roundGamePrefab_6, value);
	}

	inline static int32_t get_offset_of_roundGameContainer_7() { return static_cast<int32_t>(offsetof(RoundUI_t2850044108, ___roundGameContainer_7)); }
	inline Transform_t3275118058 * get_roundGameContainer_7() const { return ___roundGameContainer_7; }
	inline Transform_t3275118058 ** get_address_of_roundGameContainer_7() { return &___roundGameContainer_7; }
	inline void set_roundGameContainer_7(Transform_t3275118058 * value)
	{
		___roundGameContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___roundGameContainer_7, value);
	}

	inline static int32_t get_offset_of_chooseRoundGamePrefab_8() { return static_cast<int32_t>(offsetof(RoundUI_t2850044108, ___chooseRoundGamePrefab_8)); }
	inline ChooseRoundGameUI_t1849796619 * get_chooseRoundGamePrefab_8() const { return ___chooseRoundGamePrefab_8; }
	inline ChooseRoundGameUI_t1849796619 ** get_address_of_chooseRoundGamePrefab_8() { return &___chooseRoundGamePrefab_8; }
	inline void set_chooseRoundGamePrefab_8(ChooseRoundGameUI_t1849796619 * value)
	{
		___chooseRoundGamePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundGamePrefab_8, value);
	}

	inline static int32_t get_offset_of_chooseRoundGameContainer_9() { return static_cast<int32_t>(offsetof(RoundUI_t2850044108, ___chooseRoundGameContainer_9)); }
	inline Transform_t3275118058 * get_chooseRoundGameContainer_9() const { return ___chooseRoundGameContainer_9; }
	inline Transform_t3275118058 ** get_address_of_chooseRoundGameContainer_9() { return &___chooseRoundGameContainer_9; }
	inline void set_chooseRoundGameContainer_9(Transform_t3275118058 * value)
	{
		___chooseRoundGameContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundGameContainer_9, value);
	}

	inline static int32_t get_offset_of_roomUIData_10() { return static_cast<int32_t>(offsetof(RoundUI_t2850044108, ___roomUIData_10)); }
	inline UIData_t2598208972 * get_roomUIData_10() const { return ___roomUIData_10; }
	inline UIData_t2598208972 ** get_address_of_roomUIData_10() { return &___roomUIData_10; }
	inline void set_roomUIData_10(UIData_t2598208972 * value)
	{
		___roomUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
