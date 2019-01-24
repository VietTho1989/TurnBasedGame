#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4023653039.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// TimeControl.Normal.TimeControlNormalUI
struct TimeControlNormalUI_t789601165;
// TimeControl.HourGlass.TimeControlHourGlassUI
struct TimeControlHourGlassUI_t1205974444;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.TimeControlUI
struct  TimeControlUI_t1817415138  : public UIBehavior_1_t4023653039
{
public:
	// System.Boolean TimeControl.TimeControlUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject TimeControl.TimeControlUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeBoolUI TimeControl.TimeControlUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_8;
	// RequestChangeEnumUI TimeControl.TimeControlUI::requestEnumPrefeb
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefeb_9;
	// TimeControl.Normal.TimeControlNormalUI TimeControl.TimeControlUI::timeControlNormalPrefab
	TimeControlNormalUI_t789601165 * ___timeControlNormalPrefab_10;
	// TimeControl.HourGlass.TimeControlHourGlassUI TimeControl.TimeControlUI::timeControlHourGlassPrefab
	TimeControlHourGlassUI_t1205974444 * ___timeControlHourGlassPrefab_11;
	// UnityEngine.Transform TimeControl.TimeControlUI::isEnableContainer
	Transform_t3275118058 * ___isEnableContainer_12;
	// UnityEngine.Transform TimeControl.TimeControlUI::aiCanTimeOutContainer
	Transform_t3275118058 * ___aiCanTimeOutContainer_13;
	// UnityEngine.Transform TimeControl.TimeControlUI::useContainer
	Transform_t3275118058 * ___useContainer_14;
	// UnityEngine.Transform TimeControl.TimeControlUI::subTypeContainer
	Transform_t3275118058 * ___subTypeContainer_15;
	// UnityEngine.Transform TimeControl.TimeControlUI::subContainer
	Transform_t3275118058 * ___subContainer_16;
	// Server TimeControl.TimeControlUI::server
	Server_t2724320767 * ___server_17;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_8() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___requestBoolPrefab_8)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_8() const { return ___requestBoolPrefab_8; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_8() { return &___requestBoolPrefab_8; }
	inline void set_requestBoolPrefab_8(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefeb_9() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___requestEnumPrefeb_9)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefeb_9() const { return ___requestEnumPrefeb_9; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefeb_9() { return &___requestEnumPrefeb_9; }
	inline void set_requestEnumPrefeb_9(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefeb_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefeb_9, value);
	}

	inline static int32_t get_offset_of_timeControlNormalPrefab_10() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___timeControlNormalPrefab_10)); }
	inline TimeControlNormalUI_t789601165 * get_timeControlNormalPrefab_10() const { return ___timeControlNormalPrefab_10; }
	inline TimeControlNormalUI_t789601165 ** get_address_of_timeControlNormalPrefab_10() { return &___timeControlNormalPrefab_10; }
	inline void set_timeControlNormalPrefab_10(TimeControlNormalUI_t789601165 * value)
	{
		___timeControlNormalPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___timeControlNormalPrefab_10, value);
	}

	inline static int32_t get_offset_of_timeControlHourGlassPrefab_11() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___timeControlHourGlassPrefab_11)); }
	inline TimeControlHourGlassUI_t1205974444 * get_timeControlHourGlassPrefab_11() const { return ___timeControlHourGlassPrefab_11; }
	inline TimeControlHourGlassUI_t1205974444 ** get_address_of_timeControlHourGlassPrefab_11() { return &___timeControlHourGlassPrefab_11; }
	inline void set_timeControlHourGlassPrefab_11(TimeControlHourGlassUI_t1205974444 * value)
	{
		___timeControlHourGlassPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___timeControlHourGlassPrefab_11, value);
	}

	inline static int32_t get_offset_of_isEnableContainer_12() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___isEnableContainer_12)); }
	inline Transform_t3275118058 * get_isEnableContainer_12() const { return ___isEnableContainer_12; }
	inline Transform_t3275118058 ** get_address_of_isEnableContainer_12() { return &___isEnableContainer_12; }
	inline void set_isEnableContainer_12(Transform_t3275118058 * value)
	{
		___isEnableContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___isEnableContainer_12, value);
	}

	inline static int32_t get_offset_of_aiCanTimeOutContainer_13() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___aiCanTimeOutContainer_13)); }
	inline Transform_t3275118058 * get_aiCanTimeOutContainer_13() const { return ___aiCanTimeOutContainer_13; }
	inline Transform_t3275118058 ** get_address_of_aiCanTimeOutContainer_13() { return &___aiCanTimeOutContainer_13; }
	inline void set_aiCanTimeOutContainer_13(Transform_t3275118058 * value)
	{
		___aiCanTimeOutContainer_13 = value;
		Il2CppCodeGenWriteBarrier(&___aiCanTimeOutContainer_13, value);
	}

	inline static int32_t get_offset_of_useContainer_14() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___useContainer_14)); }
	inline Transform_t3275118058 * get_useContainer_14() const { return ___useContainer_14; }
	inline Transform_t3275118058 ** get_address_of_useContainer_14() { return &___useContainer_14; }
	inline void set_useContainer_14(Transform_t3275118058 * value)
	{
		___useContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___useContainer_14, value);
	}

	inline static int32_t get_offset_of_subTypeContainer_15() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___subTypeContainer_15)); }
	inline Transform_t3275118058 * get_subTypeContainer_15() const { return ___subTypeContainer_15; }
	inline Transform_t3275118058 ** get_address_of_subTypeContainer_15() { return &___subTypeContainer_15; }
	inline void set_subTypeContainer_15(Transform_t3275118058 * value)
	{
		___subTypeContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___subTypeContainer_15, value);
	}

	inline static int32_t get_offset_of_subContainer_16() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___subContainer_16)); }
	inline Transform_t3275118058 * get_subContainer_16() const { return ___subContainer_16; }
	inline Transform_t3275118058 ** get_address_of_subContainer_16() { return &___subContainer_16; }
	inline void set_subContainer_16(Transform_t3275118058 * value)
	{
		___subContainer_16 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_16, value);
	}

	inline static int32_t get_offset_of_server_17() { return static_cast<int32_t>(offsetof(TimeControlUI_t1817415138, ___server_17)); }
	inline Server_t2724320767 * get_server_17() const { return ___server_17; }
	inline Server_t2724320767 ** get_address_of_server_17() { return &___server_17; }
	inline void set_server_17(Server_t2724320767 * value)
	{
		___server_17 = value;
		Il2CppCodeGenWriteBarrier(&___server_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
