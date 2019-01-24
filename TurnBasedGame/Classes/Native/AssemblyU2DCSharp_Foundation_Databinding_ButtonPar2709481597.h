#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"
#include "AssemblyU2DCSharp_Foundation_Databinding_ButtonPar3027703926.h"

// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ButtonParamater
struct  ButtonParamater_t2709481597  : public BindingBase_t2590300386
{
public:
	// System.Boolean Foundation.Databinding.ButtonParamater::IsInit
	bool ___IsInit_9;
	// Foundation.Databinding.ButtonParamater/ParamaterTypeEnum Foundation.Databinding.ButtonParamater::ParamaterType
	int32_t ___ParamaterType_10;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ButtonParamater::ParameterBinding
	BindingInfo_t2210172430 * ___ParameterBinding_11;
	// System.String Foundation.Databinding.ButtonParamater::StaticParamater
	String_t* ___StaticParamater_12;

public:
	inline static int32_t get_offset_of_IsInit_9() { return static_cast<int32_t>(offsetof(ButtonParamater_t2709481597, ___IsInit_9)); }
	inline bool get_IsInit_9() const { return ___IsInit_9; }
	inline bool* get_address_of_IsInit_9() { return &___IsInit_9; }
	inline void set_IsInit_9(bool value)
	{
		___IsInit_9 = value;
	}

	inline static int32_t get_offset_of_ParamaterType_10() { return static_cast<int32_t>(offsetof(ButtonParamater_t2709481597, ___ParamaterType_10)); }
	inline int32_t get_ParamaterType_10() const { return ___ParamaterType_10; }
	inline int32_t* get_address_of_ParamaterType_10() { return &___ParamaterType_10; }
	inline void set_ParamaterType_10(int32_t value)
	{
		___ParamaterType_10 = value;
	}

	inline static int32_t get_offset_of_ParameterBinding_11() { return static_cast<int32_t>(offsetof(ButtonParamater_t2709481597, ___ParameterBinding_11)); }
	inline BindingInfo_t2210172430 * get_ParameterBinding_11() const { return ___ParameterBinding_11; }
	inline BindingInfo_t2210172430 ** get_address_of_ParameterBinding_11() { return &___ParameterBinding_11; }
	inline void set_ParameterBinding_11(BindingInfo_t2210172430 * value)
	{
		___ParameterBinding_11 = value;
		Il2CppCodeGenWriteBarrier(&___ParameterBinding_11, value);
	}

	inline static int32_t get_offset_of_StaticParamater_12() { return static_cast<int32_t>(offsetof(ButtonParamater_t2709481597, ___StaticParamater_12)); }
	inline String_t* get_StaticParamater_12() const { return ___StaticParamater_12; }
	inline String_t** get_address_of_StaticParamater_12() { return &___StaticParamater_12; }
	inline void set_StaticParamater_12(String_t* value)
	{
		___StaticParamater_12 = value;
		Il2CppCodeGenWriteBarrier(&___StaticParamater_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
