#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// UnityEngine.Animation[]
struct AnimationU5BU5D_t902708961;
// UnityEngine.AnimationClip
struct AnimationClip_t3510324950;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.AnimatedVisibilityBinder
struct  AnimatedVisibilityBinder_t3228987725  : public BindingBase_t2590300386
{
public:
	// UnityEngine.Animation[] Foundation.Databinding.AnimatedVisibilityBinder::Animators
	AnimationU5BU5D_t902708961* ___Animators_9;
	// UnityEngine.AnimationClip Foundation.Databinding.AnimatedVisibilityBinder::CloseClip
	AnimationClip_t3510324950 * ___CloseClip_10;
	// System.Boolean Foundation.Databinding.AnimatedVisibilityBinder::DeactivateObject
	bool ___DeactivateObject_11;
	// System.Boolean Foundation.Databinding.AnimatedVisibilityBinder::Inverse
	bool ___Inverse_12;
	// System.Boolean Foundation.Databinding.AnimatedVisibilityBinder::IsInit
	bool ___IsInit_13;
	// UnityEngine.AnimationClip Foundation.Databinding.AnimatedVisibilityBinder::OpenClip
	AnimationClip_t3510324950 * ___OpenClip_14;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.AnimatedVisibilityBinder::ValueBinding
	BindingInfo_t2210172430 * ___ValueBinding_15;

public:
	inline static int32_t get_offset_of_Animators_9() { return static_cast<int32_t>(offsetof(AnimatedVisibilityBinder_t3228987725, ___Animators_9)); }
	inline AnimationU5BU5D_t902708961* get_Animators_9() const { return ___Animators_9; }
	inline AnimationU5BU5D_t902708961** get_address_of_Animators_9() { return &___Animators_9; }
	inline void set_Animators_9(AnimationU5BU5D_t902708961* value)
	{
		___Animators_9 = value;
		Il2CppCodeGenWriteBarrier(&___Animators_9, value);
	}

	inline static int32_t get_offset_of_CloseClip_10() { return static_cast<int32_t>(offsetof(AnimatedVisibilityBinder_t3228987725, ___CloseClip_10)); }
	inline AnimationClip_t3510324950 * get_CloseClip_10() const { return ___CloseClip_10; }
	inline AnimationClip_t3510324950 ** get_address_of_CloseClip_10() { return &___CloseClip_10; }
	inline void set_CloseClip_10(AnimationClip_t3510324950 * value)
	{
		___CloseClip_10 = value;
		Il2CppCodeGenWriteBarrier(&___CloseClip_10, value);
	}

	inline static int32_t get_offset_of_DeactivateObject_11() { return static_cast<int32_t>(offsetof(AnimatedVisibilityBinder_t3228987725, ___DeactivateObject_11)); }
	inline bool get_DeactivateObject_11() const { return ___DeactivateObject_11; }
	inline bool* get_address_of_DeactivateObject_11() { return &___DeactivateObject_11; }
	inline void set_DeactivateObject_11(bool value)
	{
		___DeactivateObject_11 = value;
	}

	inline static int32_t get_offset_of_Inverse_12() { return static_cast<int32_t>(offsetof(AnimatedVisibilityBinder_t3228987725, ___Inverse_12)); }
	inline bool get_Inverse_12() const { return ___Inverse_12; }
	inline bool* get_address_of_Inverse_12() { return &___Inverse_12; }
	inline void set_Inverse_12(bool value)
	{
		___Inverse_12 = value;
	}

	inline static int32_t get_offset_of_IsInit_13() { return static_cast<int32_t>(offsetof(AnimatedVisibilityBinder_t3228987725, ___IsInit_13)); }
	inline bool get_IsInit_13() const { return ___IsInit_13; }
	inline bool* get_address_of_IsInit_13() { return &___IsInit_13; }
	inline void set_IsInit_13(bool value)
	{
		___IsInit_13 = value;
	}

	inline static int32_t get_offset_of_OpenClip_14() { return static_cast<int32_t>(offsetof(AnimatedVisibilityBinder_t3228987725, ___OpenClip_14)); }
	inline AnimationClip_t3510324950 * get_OpenClip_14() const { return ___OpenClip_14; }
	inline AnimationClip_t3510324950 ** get_address_of_OpenClip_14() { return &___OpenClip_14; }
	inline void set_OpenClip_14(AnimationClip_t3510324950 * value)
	{
		___OpenClip_14 = value;
		Il2CppCodeGenWriteBarrier(&___OpenClip_14, value);
	}

	inline static int32_t get_offset_of_ValueBinding_15() { return static_cast<int32_t>(offsetof(AnimatedVisibilityBinder_t3228987725, ___ValueBinding_15)); }
	inline BindingInfo_t2210172430 * get_ValueBinding_15() const { return ___ValueBinding_15; }
	inline BindingInfo_t2210172430 ** get_address_of_ValueBinding_15() { return &___ValueBinding_15; }
	inline void set_ValueBinding_15(BindingInfo_t2210172430 * value)
	{
		___ValueBinding_15 = value;
		Il2CppCodeGenWriteBarrier(&___ValueBinding_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
