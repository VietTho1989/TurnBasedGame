#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.VisibilityBinder
struct  VisibilityBinder_t3569509510  : public BindingBase_t2590300386
{
public:
	// UnityEngine.GameObject[] Foundation.Databinding.VisibilityBinder::InverseTargets
	GameObjectU5BU5D_t3057952154* ___InverseTargets_9;
	// System.Boolean Foundation.Databinding.VisibilityBinder::IsInit
	bool ___IsInit_10;
	// UnityEngine.GameObject[] Foundation.Databinding.VisibilityBinder::Targets
	GameObjectU5BU5D_t3057952154* ___Targets_11;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.VisibilityBinder::ValueBinding
	BindingInfo_t2210172430 * ___ValueBinding_12;
	// System.Boolean Foundation.Databinding.VisibilityBinder::WaitFrame
	bool ___WaitFrame_13;

public:
	inline static int32_t get_offset_of_InverseTargets_9() { return static_cast<int32_t>(offsetof(VisibilityBinder_t3569509510, ___InverseTargets_9)); }
	inline GameObjectU5BU5D_t3057952154* get_InverseTargets_9() const { return ___InverseTargets_9; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_InverseTargets_9() { return &___InverseTargets_9; }
	inline void set_InverseTargets_9(GameObjectU5BU5D_t3057952154* value)
	{
		___InverseTargets_9 = value;
		Il2CppCodeGenWriteBarrier(&___InverseTargets_9, value);
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(VisibilityBinder_t3569509510, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_Targets_11() { return static_cast<int32_t>(offsetof(VisibilityBinder_t3569509510, ___Targets_11)); }
	inline GameObjectU5BU5D_t3057952154* get_Targets_11() const { return ___Targets_11; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_Targets_11() { return &___Targets_11; }
	inline void set_Targets_11(GameObjectU5BU5D_t3057952154* value)
	{
		___Targets_11 = value;
		Il2CppCodeGenWriteBarrier(&___Targets_11, value);
	}

	inline static int32_t get_offset_of_ValueBinding_12() { return static_cast<int32_t>(offsetof(VisibilityBinder_t3569509510, ___ValueBinding_12)); }
	inline BindingInfo_t2210172430 * get_ValueBinding_12() const { return ___ValueBinding_12; }
	inline BindingInfo_t2210172430 ** get_address_of_ValueBinding_12() { return &___ValueBinding_12; }
	inline void set_ValueBinding_12(BindingInfo_t2210172430 * value)
	{
		___ValueBinding_12 = value;
		Il2CppCodeGenWriteBarrier(&___ValueBinding_12, value);
	}

	inline static int32_t get_offset_of_WaitFrame_13() { return static_cast<int32_t>(offsetof(VisibilityBinder_t3569509510, ___WaitFrame_13)); }
	inline bool get_WaitFrame_13() const { return ___WaitFrame_13; }
	inline bool* get_address_of_WaitFrame_13() { return &___WaitFrame_13; }
	inline void set_WaitFrame_13(bool value)
	{
		___WaitFrame_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
