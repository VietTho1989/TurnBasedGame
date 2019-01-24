#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3905986434.h"

// RequestChangeFloatUI
struct RequestChangeFloatUI_t3993257673;
// UnityEngine.Transform
struct Transform_t3275118058;
// Record.ViewRecordControllerStatePlayUI
struct ViewRecordControllerStatePlayUI_t3666890915;
// Record.ViewRecordControllerStatePickUI
struct ViewRecordControllerStatePickUI_t2663390136;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.ViewRecordControllerUI
struct  ViewRecordControllerUI_t4200726210  : public UIBehavior_1_t3905986434
{
public:
	// System.Boolean Record.ViewRecordControllerUI::needReset
	bool ___needReset_6;
	// RequestChangeFloatUI Record.ViewRecordControllerUI::requestFloatPrefab
	RequestChangeFloatUI_t3993257673 * ___requestFloatPrefab_7;
	// UnityEngine.Transform Record.ViewRecordControllerUI::requestSpeedContainer
	Transform_t3275118058 * ___requestSpeedContainer_8;
	// UnityEngine.Transform Record.ViewRecordControllerUI::timeContainer
	Transform_t3275118058 * ___timeContainer_9;
	// Record.ViewRecordControllerStatePlayUI Record.ViewRecordControllerUI::playPrefab
	ViewRecordControllerStatePlayUI_t3666890915 * ___playPrefab_10;
	// Record.ViewRecordControllerStatePickUI Record.ViewRecordControllerUI::pickPrefab
	ViewRecordControllerStatePickUI_t2663390136 * ___pickPrefab_11;
	// UnityEngine.Transform Record.ViewRecordControllerUI::stateUIContainer
	Transform_t3275118058 * ___stateUIContainer_12;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(ViewRecordControllerUI_t4200726210, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_requestFloatPrefab_7() { return static_cast<int32_t>(offsetof(ViewRecordControllerUI_t4200726210, ___requestFloatPrefab_7)); }
	inline RequestChangeFloatUI_t3993257673 * get_requestFloatPrefab_7() const { return ___requestFloatPrefab_7; }
	inline RequestChangeFloatUI_t3993257673 ** get_address_of_requestFloatPrefab_7() { return &___requestFloatPrefab_7; }
	inline void set_requestFloatPrefab_7(RequestChangeFloatUI_t3993257673 * value)
	{
		___requestFloatPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestFloatPrefab_7, value);
	}

	inline static int32_t get_offset_of_requestSpeedContainer_8() { return static_cast<int32_t>(offsetof(ViewRecordControllerUI_t4200726210, ___requestSpeedContainer_8)); }
	inline Transform_t3275118058 * get_requestSpeedContainer_8() const { return ___requestSpeedContainer_8; }
	inline Transform_t3275118058 ** get_address_of_requestSpeedContainer_8() { return &___requestSpeedContainer_8; }
	inline void set_requestSpeedContainer_8(Transform_t3275118058 * value)
	{
		___requestSpeedContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestSpeedContainer_8, value);
	}

	inline static int32_t get_offset_of_timeContainer_9() { return static_cast<int32_t>(offsetof(ViewRecordControllerUI_t4200726210, ___timeContainer_9)); }
	inline Transform_t3275118058 * get_timeContainer_9() const { return ___timeContainer_9; }
	inline Transform_t3275118058 ** get_address_of_timeContainer_9() { return &___timeContainer_9; }
	inline void set_timeContainer_9(Transform_t3275118058 * value)
	{
		___timeContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___timeContainer_9, value);
	}

	inline static int32_t get_offset_of_playPrefab_10() { return static_cast<int32_t>(offsetof(ViewRecordControllerUI_t4200726210, ___playPrefab_10)); }
	inline ViewRecordControllerStatePlayUI_t3666890915 * get_playPrefab_10() const { return ___playPrefab_10; }
	inline ViewRecordControllerStatePlayUI_t3666890915 ** get_address_of_playPrefab_10() { return &___playPrefab_10; }
	inline void set_playPrefab_10(ViewRecordControllerStatePlayUI_t3666890915 * value)
	{
		___playPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___playPrefab_10, value);
	}

	inline static int32_t get_offset_of_pickPrefab_11() { return static_cast<int32_t>(offsetof(ViewRecordControllerUI_t4200726210, ___pickPrefab_11)); }
	inline ViewRecordControllerStatePickUI_t2663390136 * get_pickPrefab_11() const { return ___pickPrefab_11; }
	inline ViewRecordControllerStatePickUI_t2663390136 ** get_address_of_pickPrefab_11() { return &___pickPrefab_11; }
	inline void set_pickPrefab_11(ViewRecordControllerStatePickUI_t2663390136 * value)
	{
		___pickPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___pickPrefab_11, value);
	}

	inline static int32_t get_offset_of_stateUIContainer_12() { return static_cast<int32_t>(offsetof(ViewRecordControllerUI_t4200726210, ___stateUIContainer_12)); }
	inline Transform_t3275118058 * get_stateUIContainer_12() const { return ___stateUIContainer_12; }
	inline Transform_t3275118058 ** get_address_of_stateUIContainer_12() { return &___stateUIContainer_12; }
	inline void set_stateUIContainer_12(Transform_t3275118058 * value)
	{
		___stateUIContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___stateUIContainer_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
