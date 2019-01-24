#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Xiangqi.RollbackStruct>
struct NetData_1_t3588629228;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.RollbackStructIdentity
struct  RollbackStructIdentity_t180255701  : public DataIdentity_t543951486
{
public:
	// System.Int32 Xiangqi.RollbackStructIdentity::vlWhite
	int32_t ___vlWhite_17;
	// System.Int32 Xiangqi.RollbackStructIdentity::vlBlack
	int32_t ___vlBlack_18;
	// System.UInt32 Xiangqi.RollbackStructIdentity::mvs
	uint32_t ___mvs_19;
	// NetData`1<Xiangqi.RollbackStruct> Xiangqi.RollbackStructIdentity::netData
	NetData_1_t3588629228 * ___netData_20;

public:
	inline static int32_t get_offset_of_vlWhite_17() { return static_cast<int32_t>(offsetof(RollbackStructIdentity_t180255701, ___vlWhite_17)); }
	inline int32_t get_vlWhite_17() const { return ___vlWhite_17; }
	inline int32_t* get_address_of_vlWhite_17() { return &___vlWhite_17; }
	inline void set_vlWhite_17(int32_t value)
	{
		___vlWhite_17 = value;
	}

	inline static int32_t get_offset_of_vlBlack_18() { return static_cast<int32_t>(offsetof(RollbackStructIdentity_t180255701, ___vlBlack_18)); }
	inline int32_t get_vlBlack_18() const { return ___vlBlack_18; }
	inline int32_t* get_address_of_vlBlack_18() { return &___vlBlack_18; }
	inline void set_vlBlack_18(int32_t value)
	{
		___vlBlack_18 = value;
	}

	inline static int32_t get_offset_of_mvs_19() { return static_cast<int32_t>(offsetof(RollbackStructIdentity_t180255701, ___mvs_19)); }
	inline uint32_t get_mvs_19() const { return ___mvs_19; }
	inline uint32_t* get_address_of_mvs_19() { return &___mvs_19; }
	inline void set_mvs_19(uint32_t value)
	{
		___mvs_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(RollbackStructIdentity_t180255701, ___netData_20)); }
	inline NetData_1_t3588629228 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t3588629228 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t3588629228 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
