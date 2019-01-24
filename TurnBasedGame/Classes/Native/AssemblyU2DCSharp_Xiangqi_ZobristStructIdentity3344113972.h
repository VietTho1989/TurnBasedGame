#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Xiangqi.ZobristStruct>
struct NetData_1_t4098430767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.ZobristStructIdentity
struct  ZobristStructIdentity_t3344113972  : public DataIdentity_t543951486
{
public:
	// System.UInt32 Xiangqi.ZobristStructIdentity::dwKey
	uint32_t ___dwKey_17;
	// System.UInt32 Xiangqi.ZobristStructIdentity::dwLock0
	uint32_t ___dwLock0_18;
	// System.UInt32 Xiangqi.ZobristStructIdentity::dwLock1
	uint32_t ___dwLock1_19;
	// NetData`1<Xiangqi.ZobristStruct> Xiangqi.ZobristStructIdentity::netData
	NetData_1_t4098430767 * ___netData_20;

public:
	inline static int32_t get_offset_of_dwKey_17() { return static_cast<int32_t>(offsetof(ZobristStructIdentity_t3344113972, ___dwKey_17)); }
	inline uint32_t get_dwKey_17() const { return ___dwKey_17; }
	inline uint32_t* get_address_of_dwKey_17() { return &___dwKey_17; }
	inline void set_dwKey_17(uint32_t value)
	{
		___dwKey_17 = value;
	}

	inline static int32_t get_offset_of_dwLock0_18() { return static_cast<int32_t>(offsetof(ZobristStructIdentity_t3344113972, ___dwLock0_18)); }
	inline uint32_t get_dwLock0_18() const { return ___dwLock0_18; }
	inline uint32_t* get_address_of_dwLock0_18() { return &___dwLock0_18; }
	inline void set_dwLock0_18(uint32_t value)
	{
		___dwLock0_18 = value;
	}

	inline static int32_t get_offset_of_dwLock1_19() { return static_cast<int32_t>(offsetof(ZobristStructIdentity_t3344113972, ___dwLock1_19)); }
	inline uint32_t get_dwLock1_19() const { return ___dwLock1_19; }
	inline uint32_t* get_address_of_dwLock1_19() { return &___dwLock1_19; }
	inline void set_dwLock1_19(uint32_t value)
	{
		___dwLock1_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(ZobristStructIdentity_t3344113972, ___netData_20)); }
	inline NetData_1_t4098430767 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t4098430767 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t4098430767 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
