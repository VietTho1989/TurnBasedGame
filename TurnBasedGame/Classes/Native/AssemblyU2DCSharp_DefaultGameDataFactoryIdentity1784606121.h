#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<DefaultGameDataFactory>
struct NetData_1_t1866848432;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DefaultGameDataFactoryIdentity
struct  DefaultGameDataFactoryIdentity_t1784606121  : public DataIdentity_t543951486
{
public:
	// System.Boolean DefaultGameDataFactoryIdentity::useRule
	bool ___useRule_17;
	// NetData`1<DefaultGameDataFactory> DefaultGameDataFactoryIdentity::netData
	NetData_1_t1866848432 * ___netData_18;

public:
	inline static int32_t get_offset_of_useRule_17() { return static_cast<int32_t>(offsetof(DefaultGameDataFactoryIdentity_t1784606121, ___useRule_17)); }
	inline bool get_useRule_17() const { return ___useRule_17; }
	inline bool* get_address_of_useRule_17() { return &___useRule_17; }
	inline void set_useRule_17(bool value)
	{
		___useRule_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(DefaultGameDataFactoryIdentity_t1784606121, ___netData_18)); }
	inline NetData_1_t1866848432 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1866848432 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1866848432 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
