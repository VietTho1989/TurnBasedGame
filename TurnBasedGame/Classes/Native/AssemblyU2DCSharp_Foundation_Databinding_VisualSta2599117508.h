#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// Foundation.Databinding.VisualStatesBinder/StateValue[]
struct StateValueU5BU5D_t3788177500;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.VisualStatesBinder
struct  VisualStatesBinder_t2599117508  : public BindingBase_t2590300386
{
public:
	// System.Boolean Foundation.Databinding.VisualStatesBinder::IntConvert
	bool ___IntConvert_9;
	// System.Boolean Foundation.Databinding.VisualStatesBinder::IsInit
	bool ___IsInit_10;
	// Foundation.Databinding.VisualStatesBinder/StateValue[] Foundation.Databinding.VisualStatesBinder::Targets
	StateValueU5BU5D_t3788177500* ___Targets_11;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.VisualStatesBinder::ValueBinding
	BindingInfo_t2210172430 * ___ValueBinding_12;

public:
	inline static int32_t get_offset_of_IntConvert_9() { return static_cast<int32_t>(offsetof(VisualStatesBinder_t2599117508, ___IntConvert_9)); }
	inline bool get_IntConvert_9() const { return ___IntConvert_9; }
	inline bool* get_address_of_IntConvert_9() { return &___IntConvert_9; }
	inline void set_IntConvert_9(bool value)
	{
		___IntConvert_9 = value;
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(VisualStatesBinder_t2599117508, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_Targets_11() { return static_cast<int32_t>(offsetof(VisualStatesBinder_t2599117508, ___Targets_11)); }
	inline StateValueU5BU5D_t3788177500* get_Targets_11() const { return ___Targets_11; }
	inline StateValueU5BU5D_t3788177500** get_address_of_Targets_11() { return &___Targets_11; }
	inline void set_Targets_11(StateValueU5BU5D_t3788177500* value)
	{
		___Targets_11 = value;
		Il2CppCodeGenWriteBarrier(&___Targets_11, value);
	}

	inline static int32_t get_offset_of_ValueBinding_12() { return static_cast<int32_t>(offsetof(VisualStatesBinder_t2599117508, ___ValueBinding_12)); }
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
