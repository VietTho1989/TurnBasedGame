#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2629416068.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LanClientMenuUI
struct  LanClientMenuUI_t1974705819  : public UIBehavior_1_t2629416068
{
public:
	// System.Single LanClientMenuUI::time
	float ___time_6;
	// System.Boolean LanClientMenuUI::alreadyInit
	bool ___alreadyInit_7;
	// UnityEngine.UI.Text LanClientMenuUI::tvState
	Text_t356221433 * ___tvState_8;

public:
	inline static int32_t get_offset_of_time_6() { return static_cast<int32_t>(offsetof(LanClientMenuUI_t1974705819, ___time_6)); }
	inline float get_time_6() const { return ___time_6; }
	inline float* get_address_of_time_6() { return &___time_6; }
	inline void set_time_6(float value)
	{
		___time_6 = value;
	}

	inline static int32_t get_offset_of_alreadyInit_7() { return static_cast<int32_t>(offsetof(LanClientMenuUI_t1974705819, ___alreadyInit_7)); }
	inline bool get_alreadyInit_7() const { return ___alreadyInit_7; }
	inline bool* get_address_of_alreadyInit_7() { return &___alreadyInit_7; }
	inline void set_alreadyInit_7(bool value)
	{
		___alreadyInit_7 = value;
	}

	inline static int32_t get_offset_of_tvState_8() { return static_cast<int32_t>(offsetof(LanClientMenuUI_t1974705819, ___tvState_8)); }
	inline Text_t356221433 * get_tvState_8() const { return ___tvState_8; }
	inline Text_t356221433 ** get_address_of_tvState_8() { return &___tvState_8; }
	inline void set_tvState_8(Text_t356221433 * value)
	{
		___tvState_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
