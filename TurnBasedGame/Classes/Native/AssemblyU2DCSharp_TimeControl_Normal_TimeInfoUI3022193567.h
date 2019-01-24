#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1611409123.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// TimeControl.Normal.TimePerTurnInfoUI
struct TimePerTurnInfoUI_t2928067843;
// TimeControl.Normal.TotalTimeInfoUI
struct TotalTimeInfoUI_t1026484747;
// RequestChangeFloatUI
struct RequestChangeFloatUI_t3993257673;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimeInfoUI
struct  TimeInfoUI_t3022193567  : public UIBehavior_1_t1611409123
{
public:
	// System.Boolean TimeControl.Normal.TimeInfoUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject TimeControl.Normal.TimeInfoUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// TimeControl.Normal.TimePerTurnInfoUI TimeControl.Normal.TimeInfoUI::timePerTurnPrefab
	TimePerTurnInfoUI_t2928067843 * ___timePerTurnPrefab_8;
	// TimeControl.Normal.TotalTimeInfoUI TimeControl.Normal.TimeInfoUI::totalTimePrefab
	TotalTimeInfoUI_t1026484747 * ___totalTimePrefab_9;
	// RequestChangeFloatUI TimeControl.Normal.TimeInfoUI::requestFloatPrefab
	RequestChangeFloatUI_t3993257673 * ___requestFloatPrefab_10;
	// RequestChangeEnumUI TimeControl.Normal.TimeInfoUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_11;
	// UnityEngine.Transform TimeControl.Normal.TimeInfoUI::timePerTurnTypeContainer
	Transform_t3275118058 * ___timePerTurnTypeContainer_12;
	// UnityEngine.Transform TimeControl.Normal.TimeInfoUI::timePerTurnContainer
	Transform_t3275118058 * ___timePerTurnContainer_13;
	// UnityEngine.Transform TimeControl.Normal.TimeInfoUI::totalTimeTypeContainer
	Transform_t3275118058 * ___totalTimeTypeContainer_14;
	// UnityEngine.Transform TimeControl.Normal.TimeInfoUI::totalTimeContainer
	Transform_t3275118058 * ___totalTimeContainer_15;
	// UnityEngine.Transform TimeControl.Normal.TimeInfoUI::overTimePerTurnTypeContainer
	Transform_t3275118058 * ___overTimePerTurnTypeContainer_16;
	// UnityEngine.Transform TimeControl.Normal.TimeInfoUI::overTimePerTurnContainer
	Transform_t3275118058 * ___overTimePerTurnContainer_17;
	// UnityEngine.Transform TimeControl.Normal.TimeInfoUI::lagCompensationContainer
	Transform_t3275118058 * ___lagCompensationContainer_18;
	// Server TimeControl.Normal.TimeInfoUI::server
	Server_t2724320767 * ___server_19;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_timePerTurnPrefab_8() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___timePerTurnPrefab_8)); }
	inline TimePerTurnInfoUI_t2928067843 * get_timePerTurnPrefab_8() const { return ___timePerTurnPrefab_8; }
	inline TimePerTurnInfoUI_t2928067843 ** get_address_of_timePerTurnPrefab_8() { return &___timePerTurnPrefab_8; }
	inline void set_timePerTurnPrefab_8(TimePerTurnInfoUI_t2928067843 * value)
	{
		___timePerTurnPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___timePerTurnPrefab_8, value);
	}

	inline static int32_t get_offset_of_totalTimePrefab_9() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___totalTimePrefab_9)); }
	inline TotalTimeInfoUI_t1026484747 * get_totalTimePrefab_9() const { return ___totalTimePrefab_9; }
	inline TotalTimeInfoUI_t1026484747 ** get_address_of_totalTimePrefab_9() { return &___totalTimePrefab_9; }
	inline void set_totalTimePrefab_9(TotalTimeInfoUI_t1026484747 * value)
	{
		___totalTimePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___totalTimePrefab_9, value);
	}

	inline static int32_t get_offset_of_requestFloatPrefab_10() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___requestFloatPrefab_10)); }
	inline RequestChangeFloatUI_t3993257673 * get_requestFloatPrefab_10() const { return ___requestFloatPrefab_10; }
	inline RequestChangeFloatUI_t3993257673 ** get_address_of_requestFloatPrefab_10() { return &___requestFloatPrefab_10; }
	inline void set_requestFloatPrefab_10(RequestChangeFloatUI_t3993257673 * value)
	{
		___requestFloatPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestFloatPrefab_10, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_11() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___requestEnumPrefab_11)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_11() const { return ___requestEnumPrefab_11; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_11() { return &___requestEnumPrefab_11; }
	inline void set_requestEnumPrefab_11(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_11, value);
	}

	inline static int32_t get_offset_of_timePerTurnTypeContainer_12() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___timePerTurnTypeContainer_12)); }
	inline Transform_t3275118058 * get_timePerTurnTypeContainer_12() const { return ___timePerTurnTypeContainer_12; }
	inline Transform_t3275118058 ** get_address_of_timePerTurnTypeContainer_12() { return &___timePerTurnTypeContainer_12; }
	inline void set_timePerTurnTypeContainer_12(Transform_t3275118058 * value)
	{
		___timePerTurnTypeContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___timePerTurnTypeContainer_12, value);
	}

	inline static int32_t get_offset_of_timePerTurnContainer_13() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___timePerTurnContainer_13)); }
	inline Transform_t3275118058 * get_timePerTurnContainer_13() const { return ___timePerTurnContainer_13; }
	inline Transform_t3275118058 ** get_address_of_timePerTurnContainer_13() { return &___timePerTurnContainer_13; }
	inline void set_timePerTurnContainer_13(Transform_t3275118058 * value)
	{
		___timePerTurnContainer_13 = value;
		Il2CppCodeGenWriteBarrier(&___timePerTurnContainer_13, value);
	}

	inline static int32_t get_offset_of_totalTimeTypeContainer_14() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___totalTimeTypeContainer_14)); }
	inline Transform_t3275118058 * get_totalTimeTypeContainer_14() const { return ___totalTimeTypeContainer_14; }
	inline Transform_t3275118058 ** get_address_of_totalTimeTypeContainer_14() { return &___totalTimeTypeContainer_14; }
	inline void set_totalTimeTypeContainer_14(Transform_t3275118058 * value)
	{
		___totalTimeTypeContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___totalTimeTypeContainer_14, value);
	}

	inline static int32_t get_offset_of_totalTimeContainer_15() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___totalTimeContainer_15)); }
	inline Transform_t3275118058 * get_totalTimeContainer_15() const { return ___totalTimeContainer_15; }
	inline Transform_t3275118058 ** get_address_of_totalTimeContainer_15() { return &___totalTimeContainer_15; }
	inline void set_totalTimeContainer_15(Transform_t3275118058 * value)
	{
		___totalTimeContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___totalTimeContainer_15, value);
	}

	inline static int32_t get_offset_of_overTimePerTurnTypeContainer_16() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___overTimePerTurnTypeContainer_16)); }
	inline Transform_t3275118058 * get_overTimePerTurnTypeContainer_16() const { return ___overTimePerTurnTypeContainer_16; }
	inline Transform_t3275118058 ** get_address_of_overTimePerTurnTypeContainer_16() { return &___overTimePerTurnTypeContainer_16; }
	inline void set_overTimePerTurnTypeContainer_16(Transform_t3275118058 * value)
	{
		___overTimePerTurnTypeContainer_16 = value;
		Il2CppCodeGenWriteBarrier(&___overTimePerTurnTypeContainer_16, value);
	}

	inline static int32_t get_offset_of_overTimePerTurnContainer_17() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___overTimePerTurnContainer_17)); }
	inline Transform_t3275118058 * get_overTimePerTurnContainer_17() const { return ___overTimePerTurnContainer_17; }
	inline Transform_t3275118058 ** get_address_of_overTimePerTurnContainer_17() { return &___overTimePerTurnContainer_17; }
	inline void set_overTimePerTurnContainer_17(Transform_t3275118058 * value)
	{
		___overTimePerTurnContainer_17 = value;
		Il2CppCodeGenWriteBarrier(&___overTimePerTurnContainer_17, value);
	}

	inline static int32_t get_offset_of_lagCompensationContainer_18() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___lagCompensationContainer_18)); }
	inline Transform_t3275118058 * get_lagCompensationContainer_18() const { return ___lagCompensationContainer_18; }
	inline Transform_t3275118058 ** get_address_of_lagCompensationContainer_18() { return &___lagCompensationContainer_18; }
	inline void set_lagCompensationContainer_18(Transform_t3275118058 * value)
	{
		___lagCompensationContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___lagCompensationContainer_18, value);
	}

	inline static int32_t get_offset_of_server_19() { return static_cast<int32_t>(offsetof(TimeInfoUI_t3022193567, ___server_19)); }
	inline Server_t2724320767 * get_server_19() const { return ___server_19; }
	inline Server_t2724320767 ** get_address_of_server_19() { return &___server_19; }
	inline void set_server_19(Server_t2724320767 * value)
	{
		___server_19 = value;
		Il2CppCodeGenWriteBarrier(&___server_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
