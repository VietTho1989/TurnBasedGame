#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3953749953.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// HEX.HexMoveUI
struct HexMoveUI_t4156509014;
// HEX.HexSwitchUI
struct HexSwitchUI_t904873761;
// HEX.NoneRule.HexCustomSetUI
struct HexCustomSetUI_t290838366;
// HEX.NoneRule.HexCustomMoveUI
struct HexCustomMoveUI_t2846194653;
// LastMoveCheckChange`1<HEX.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t3557117870;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.LastMoveUI
struct  LastMoveUI_t2989320947  : public UIBehavior_1_t3953749953
{
public:
	// UnityEngine.Transform HEX.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// HEX.HexMoveUI HEX.LastMoveUI::hexMovePrefab
	HexMoveUI_t4156509014 * ___hexMovePrefab_7;
	// HEX.HexSwitchUI HEX.LastMoveUI::hexSwitchPrefab
	HexSwitchUI_t904873761 * ___hexSwitchPrefab_8;
	// HEX.NoneRule.HexCustomSetUI HEX.LastMoveUI::hexCustomSetPrefab
	HexCustomSetUI_t290838366 * ___hexCustomSetPrefab_9;
	// HEX.NoneRule.HexCustomMoveUI HEX.LastMoveUI::hexCustomMovePrefab
	HexCustomMoveUI_t2846194653 * ___hexCustomMovePrefab_10;
	// LastMoveCheckChange`1<HEX.LastMoveUI/UIData> HEX.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t3557117870 * ___lastMoveCheckChange_11;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t2989320947, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_hexMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t2989320947, ___hexMovePrefab_7)); }
	inline HexMoveUI_t4156509014 * get_hexMovePrefab_7() const { return ___hexMovePrefab_7; }
	inline HexMoveUI_t4156509014 ** get_address_of_hexMovePrefab_7() { return &___hexMovePrefab_7; }
	inline void set_hexMovePrefab_7(HexMoveUI_t4156509014 * value)
	{
		___hexMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___hexMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_hexSwitchPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t2989320947, ___hexSwitchPrefab_8)); }
	inline HexSwitchUI_t904873761 * get_hexSwitchPrefab_8() const { return ___hexSwitchPrefab_8; }
	inline HexSwitchUI_t904873761 ** get_address_of_hexSwitchPrefab_8() { return &___hexSwitchPrefab_8; }
	inline void set_hexSwitchPrefab_8(HexSwitchUI_t904873761 * value)
	{
		___hexSwitchPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___hexSwitchPrefab_8, value);
	}

	inline static int32_t get_offset_of_hexCustomSetPrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t2989320947, ___hexCustomSetPrefab_9)); }
	inline HexCustomSetUI_t290838366 * get_hexCustomSetPrefab_9() const { return ___hexCustomSetPrefab_9; }
	inline HexCustomSetUI_t290838366 ** get_address_of_hexCustomSetPrefab_9() { return &___hexCustomSetPrefab_9; }
	inline void set_hexCustomSetPrefab_9(HexCustomSetUI_t290838366 * value)
	{
		___hexCustomSetPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___hexCustomSetPrefab_9, value);
	}

	inline static int32_t get_offset_of_hexCustomMovePrefab_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t2989320947, ___hexCustomMovePrefab_10)); }
	inline HexCustomMoveUI_t2846194653 * get_hexCustomMovePrefab_10() const { return ___hexCustomMovePrefab_10; }
	inline HexCustomMoveUI_t2846194653 ** get_address_of_hexCustomMovePrefab_10() { return &___hexCustomMovePrefab_10; }
	inline void set_hexCustomMovePrefab_10(HexCustomMoveUI_t2846194653 * value)
	{
		___hexCustomMovePrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___hexCustomMovePrefab_10, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_11() { return static_cast<int32_t>(offsetof(LastMoveUI_t2989320947, ___lastMoveCheckChange_11)); }
	inline LastMoveCheckChange_1_t3557117870 * get_lastMoveCheckChange_11() const { return ___lastMoveCheckChange_11; }
	inline LastMoveCheckChange_1_t3557117870 ** get_address_of_lastMoveCheckChange_11() { return &___lastMoveCheckChange_11; }
	inline void set_lastMoveCheckChange_11(LastMoveCheckChange_1_t3557117870 * value)
	{
		___lastMoveCheckChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
