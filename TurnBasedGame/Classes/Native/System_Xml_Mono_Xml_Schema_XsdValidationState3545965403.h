#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Mono.Xml.Schema.XsdInvalidValidationState
struct XsdInvalidValidationState_t1112885736;
// Mono.Xml.Schema.XsdParticleStateManager
struct XsdParticleStateManager_t4119977941;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XsdValidationState
struct  XsdValidationState_t3545965403  : public Il2CppObject
{
public:
	// System.Int32 Mono.Xml.Schema.XsdValidationState::occured
	int32_t ___occured_1;
	// Mono.Xml.Schema.XsdParticleStateManager Mono.Xml.Schema.XsdValidationState::manager
	XsdParticleStateManager_t4119977941 * ___manager_2;

public:
	inline static int32_t get_offset_of_occured_1() { return static_cast<int32_t>(offsetof(XsdValidationState_t3545965403, ___occured_1)); }
	inline int32_t get_occured_1() const { return ___occured_1; }
	inline int32_t* get_address_of_occured_1() { return &___occured_1; }
	inline void set_occured_1(int32_t value)
	{
		___occured_1 = value;
	}

	inline static int32_t get_offset_of_manager_2() { return static_cast<int32_t>(offsetof(XsdValidationState_t3545965403, ___manager_2)); }
	inline XsdParticleStateManager_t4119977941 * get_manager_2() const { return ___manager_2; }
	inline XsdParticleStateManager_t4119977941 ** get_address_of_manager_2() { return &___manager_2; }
	inline void set_manager_2(XsdParticleStateManager_t4119977941 * value)
	{
		___manager_2 = value;
		Il2CppCodeGenWriteBarrier(&___manager_2, value);
	}
};

struct XsdValidationState_t3545965403_StaticFields
{
public:
	// Mono.Xml.Schema.XsdInvalidValidationState Mono.Xml.Schema.XsdValidationState::invalid
	XsdInvalidValidationState_t1112885736 * ___invalid_0;

public:
	inline static int32_t get_offset_of_invalid_0() { return static_cast<int32_t>(offsetof(XsdValidationState_t3545965403_StaticFields, ___invalid_0)); }
	inline XsdInvalidValidationState_t1112885736 * get_invalid_0() const { return ___invalid_0; }
	inline XsdInvalidValidationState_t1112885736 ** get_address_of_invalid_0() { return &___invalid_0; }
	inline void set_invalid_0(XsdInvalidValidationState_t1112885736 * value)
	{
		___invalid_0 = value;
		Il2CppCodeGenWriteBarrier(&___invalid_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
