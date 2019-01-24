#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<History>
struct NetData_1_t4085188849;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HistoryIdentity
struct  HistoryIdentity_t3033687130  : public DataIdentity_t543951486
{
public:
	// System.Boolean HistoryIdentity::isActive
	bool ___isActive_17;
	// System.Int32 HistoryIdentity::position
	int32_t ___position_18;
	// System.UInt32 HistoryIdentity::changeCount
	uint32_t ___changeCount_19;
	// NetData`1<History> HistoryIdentity::netData
	NetData_1_t4085188849 * ___netData_20;

public:
	inline static int32_t get_offset_of_isActive_17() { return static_cast<int32_t>(offsetof(HistoryIdentity_t3033687130, ___isActive_17)); }
	inline bool get_isActive_17() const { return ___isActive_17; }
	inline bool* get_address_of_isActive_17() { return &___isActive_17; }
	inline void set_isActive_17(bool value)
	{
		___isActive_17 = value;
	}

	inline static int32_t get_offset_of_position_18() { return static_cast<int32_t>(offsetof(HistoryIdentity_t3033687130, ___position_18)); }
	inline int32_t get_position_18() const { return ___position_18; }
	inline int32_t* get_address_of_position_18() { return &___position_18; }
	inline void set_position_18(int32_t value)
	{
		___position_18 = value;
	}

	inline static int32_t get_offset_of_changeCount_19() { return static_cast<int32_t>(offsetof(HistoryIdentity_t3033687130, ___changeCount_19)); }
	inline uint32_t get_changeCount_19() const { return ___changeCount_19; }
	inline uint32_t* get_address_of_changeCount_19() { return &___changeCount_19; }
	inline void set_changeCount_19(uint32_t value)
	{
		___changeCount_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(HistoryIdentity_t3033687130, ___netData_20)); }
	inline NetData_1_t4085188849 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t4085188849 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t4085188849 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
