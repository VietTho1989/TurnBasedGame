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
// System.String
struct String_t;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.VisualStateBinder
struct  VisualStateBinder_t1157980763  : public BindingBase_t2590300386
{
public:
	// System.Boolean Foundation.Databinding.VisualStateBinder::IsInit
	bool ___IsInit_9;
	// UnityEngine.GameObject[] Foundation.Databinding.VisualStateBinder::Targets
	GameObjectU5BU5D_t3057952154* ___Targets_10;
	// System.String Foundation.Databinding.VisualStateBinder::ValidState
	String_t* ___ValidState_11;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.VisualStateBinder::ValueBinding
	BindingInfo_t2210172430 * ___ValueBinding_12;

public:
	inline static int32_t get_offset_of_IsInit_9() { return static_cast<int32_t>(offsetof(VisualStateBinder_t1157980763, ___IsInit_9)); }
	inline bool get_IsInit_9() const { return ___IsInit_9; }
	inline bool* get_address_of_IsInit_9() { return &___IsInit_9; }
	inline void set_IsInit_9(bool value)
	{
		___IsInit_9 = value;
	}

	inline static int32_t get_offset_of_Targets_10() { return static_cast<int32_t>(offsetof(VisualStateBinder_t1157980763, ___Targets_10)); }
	inline GameObjectU5BU5D_t3057952154* get_Targets_10() const { return ___Targets_10; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_Targets_10() { return &___Targets_10; }
	inline void set_Targets_10(GameObjectU5BU5D_t3057952154* value)
	{
		___Targets_10 = value;
		Il2CppCodeGenWriteBarrier(&___Targets_10, value);
	}

	inline static int32_t get_offset_of_ValidState_11() { return static_cast<int32_t>(offsetof(VisualStateBinder_t1157980763, ___ValidState_11)); }
	inline String_t* get_ValidState_11() const { return ___ValidState_11; }
	inline String_t** get_address_of_ValidState_11() { return &___ValidState_11; }
	inline void set_ValidState_11(String_t* value)
	{
		___ValidState_11 = value;
		Il2CppCodeGenWriteBarrier(&___ValidState_11, value);
	}

	inline static int32_t get_offset_of_ValueBinding_12() { return static_cast<int32_t>(offsetof(VisualStateBinder_t1157980763, ___ValueBinding_12)); }
	inline BindingInfo_t2210172430 * get_ValueBinding_12() const { return ___ValueBinding_12; }
	inline BindingInfo_t2210172430 ** get_address_of_ValueBinding_12() { return &___ValueBinding_12; }
	inline void set_ValueBinding_12(BindingInfo_t2210172430 * value)
	{
		___ValueBinding_12 = value;
		Il2CppCodeGenWriteBarrier(&___ValueBinding_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
