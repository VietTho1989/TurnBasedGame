﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<InternationalDraught.DefaultInternationalDraught>
struct NetData_1_t2534926903;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.DefaultInternationalDraughtIdentity
struct  DefaultInternationalDraughtIdentity_t1768219300  : public DataIdentity_t543951486
{
public:
	// System.Int32 InternationalDraught.DefaultInternationalDraughtIdentity::variant
	int32_t ___variant_17;
	// NetData`1<InternationalDraught.DefaultInternationalDraught> InternationalDraught.DefaultInternationalDraughtIdentity::netData
	NetData_1_t2534926903 * ___netData_18;

public:
	inline static int32_t get_offset_of_variant_17() { return static_cast<int32_t>(offsetof(DefaultInternationalDraughtIdentity_t1768219300, ___variant_17)); }
	inline int32_t get_variant_17() const { return ___variant_17; }
	inline int32_t* get_address_of_variant_17() { return &___variant_17; }
	inline void set_variant_17(int32_t value)
	{
		___variant_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(DefaultInternationalDraughtIdentity_t1768219300, ___netData_18)); }
	inline NetData_1_t2534926903 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t2534926903 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t2534926903 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif