﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2901936939.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.CoTuongUpAIUI
struct  CoTuongUpAIUI_t2221999114  : public UIBehavior_1_t2901936939
{
public:
	// System.Boolean CoTuongUp.CoTuongUpAIUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject CoTuongUp.CoTuongUpAIUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// Server CoTuongUp.CoTuongUpAIUI::server
	Server_t2724320767 * ___server_8;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(CoTuongUpAIUI_t2221999114, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(CoTuongUpAIUI_t2221999114, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_server_8() { return static_cast<int32_t>(offsetof(CoTuongUpAIUI_t2221999114, ___server_8)); }
	inline Server_t2724320767 * get_server_8() const { return ___server_8; }
	inline Server_t2724320767 ** get_address_of_server_8() { return &___server_8; }
	inline void set_server_8(Server_t2724320767 * value)
	{
		___server_8 = value;
		Il2CppCodeGenWriteBarrier(&___server_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
