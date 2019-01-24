#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"
#include "UnityEngine_UnityEngine_KeyCode2283395152.h"
#include "AssemblyU2DCSharp_Foundation_Databinding_KeyBinder4214005154.h"

// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.KeyBinder
struct  KeyBinder_t235539347  : public BindingBase_t2590300386
{
public:
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.KeyBinder::CommandBinding
	BindingInfo_t2210172430 * ___CommandBinding_9;
	// UnityEngine.KeyCode Foundation.Databinding.KeyBinder::Key
	int32_t ___Key_10;
	// System.Single Foundation.Databinding.KeyBinder::lastHit
	float ___lastHit_11;
	// Foundation.Databinding.KeyBinder/PlatformEnum Foundation.Databinding.KeyBinder::Platform
	int32_t ___Platform_12;
	// System.Boolean Foundation.Databinding.KeyBinder::RequireDouble
	bool ___RequireDouble_13;

public:
	inline static int32_t get_offset_of_CommandBinding_9() { return static_cast<int32_t>(offsetof(KeyBinder_t235539347, ___CommandBinding_9)); }
	inline BindingInfo_t2210172430 * get_CommandBinding_9() const { return ___CommandBinding_9; }
	inline BindingInfo_t2210172430 ** get_address_of_CommandBinding_9() { return &___CommandBinding_9; }
	inline void set_CommandBinding_9(BindingInfo_t2210172430 * value)
	{
		___CommandBinding_9 = value;
		Il2CppCodeGenWriteBarrier(&___CommandBinding_9, value);
	}

	inline static int32_t get_offset_of_Key_10() { return static_cast<int32_t>(offsetof(KeyBinder_t235539347, ___Key_10)); }
	inline int32_t get_Key_10() const { return ___Key_10; }
	inline int32_t* get_address_of_Key_10() { return &___Key_10; }
	inline void set_Key_10(int32_t value)
	{
		___Key_10 = value;
	}

	inline static int32_t get_offset_of_lastHit_11() { return static_cast<int32_t>(offsetof(KeyBinder_t235539347, ___lastHit_11)); }
	inline float get_lastHit_11() const { return ___lastHit_11; }
	inline float* get_address_of_lastHit_11() { return &___lastHit_11; }
	inline void set_lastHit_11(float value)
	{
		___lastHit_11 = value;
	}

	inline static int32_t get_offset_of_Platform_12() { return static_cast<int32_t>(offsetof(KeyBinder_t235539347, ___Platform_12)); }
	inline int32_t get_Platform_12() const { return ___Platform_12; }
	inline int32_t* get_address_of_Platform_12() { return &___Platform_12; }
	inline void set_Platform_12(int32_t value)
	{
		___Platform_12 = value;
	}

	inline static int32_t get_offset_of_RequireDouble_13() { return static_cast<int32_t>(offsetof(KeyBinder_t235539347, ___RequireDouble_13)); }
	inline bool get_RequireDouble_13() const { return ___RequireDouble_13; }
	inline bool* get_address_of_RequireDouble_13() { return &___RequireDouble_13; }
	inline void set_RequireDouble_13(bool value)
	{
		___RequireDouble_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
