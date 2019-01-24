#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1875180513.h"

// EmptyInformAvatarUI
struct EmptyInformAvatarUI_t4114158639;
// HumanAvatarUI
struct HumanAvatarUI_t705612314;
// ComputerAvatarUI
struct ComputerAvatarUI_t2672989554;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InformAvatarUI
struct  InformAvatarUI_t2288633734  : public UIBehavior_1_t1875180513
{
public:
	// EmptyInformAvatarUI InformAvatarUI::emptyInformPrefab
	EmptyInformAvatarUI_t4114158639 * ___emptyInformPrefab_6;
	// HumanAvatarUI InformAvatarUI::humanPrefab
	HumanAvatarUI_t705612314 * ___humanPrefab_7;
	// ComputerAvatarUI InformAvatarUI::computerPrefab
	ComputerAvatarUI_t2672989554 * ___computerPrefab_8;

public:
	inline static int32_t get_offset_of_emptyInformPrefab_6() { return static_cast<int32_t>(offsetof(InformAvatarUI_t2288633734, ___emptyInformPrefab_6)); }
	inline EmptyInformAvatarUI_t4114158639 * get_emptyInformPrefab_6() const { return ___emptyInformPrefab_6; }
	inline EmptyInformAvatarUI_t4114158639 ** get_address_of_emptyInformPrefab_6() { return &___emptyInformPrefab_6; }
	inline void set_emptyInformPrefab_6(EmptyInformAvatarUI_t4114158639 * value)
	{
		___emptyInformPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___emptyInformPrefab_6, value);
	}

	inline static int32_t get_offset_of_humanPrefab_7() { return static_cast<int32_t>(offsetof(InformAvatarUI_t2288633734, ___humanPrefab_7)); }
	inline HumanAvatarUI_t705612314 * get_humanPrefab_7() const { return ___humanPrefab_7; }
	inline HumanAvatarUI_t705612314 ** get_address_of_humanPrefab_7() { return &___humanPrefab_7; }
	inline void set_humanPrefab_7(HumanAvatarUI_t705612314 * value)
	{
		___humanPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___humanPrefab_7, value);
	}

	inline static int32_t get_offset_of_computerPrefab_8() { return static_cast<int32_t>(offsetof(InformAvatarUI_t2288633734, ___computerPrefab_8)); }
	inline ComputerAvatarUI_t2672989554 * get_computerPrefab_8() const { return ___computerPrefab_8; }
	inline ComputerAvatarUI_t2672989554 ** get_address_of_computerPrefab_8() { return &___computerPrefab_8; }
	inline void set_computerPrefab_8(ComputerAvatarUI_t2672989554 * value)
	{
		___computerPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___computerPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
