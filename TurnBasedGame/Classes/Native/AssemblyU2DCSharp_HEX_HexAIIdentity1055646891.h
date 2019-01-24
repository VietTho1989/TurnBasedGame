#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<HEX.HexAI>
struct NetData_1_t355594818;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexAIIdentity
struct  HexAIIdentity_t1055646891  : public DataIdentity_t543951486
{
public:
	// System.Int32 HEX.HexAIIdentity::limitTime
	int32_t ___limitTime_17;
	// System.Boolean HEX.HexAIIdentity::firstMoveCenter
	bool ___firstMoveCenter_18;
	// NetData`1<HEX.HexAI> HEX.HexAIIdentity::netData
	NetData_1_t355594818 * ___netData_19;

public:
	inline static int32_t get_offset_of_limitTime_17() { return static_cast<int32_t>(offsetof(HexAIIdentity_t1055646891, ___limitTime_17)); }
	inline int32_t get_limitTime_17() const { return ___limitTime_17; }
	inline int32_t* get_address_of_limitTime_17() { return &___limitTime_17; }
	inline void set_limitTime_17(int32_t value)
	{
		___limitTime_17 = value;
	}

	inline static int32_t get_offset_of_firstMoveCenter_18() { return static_cast<int32_t>(offsetof(HexAIIdentity_t1055646891, ___firstMoveCenter_18)); }
	inline bool get_firstMoveCenter_18() const { return ___firstMoveCenter_18; }
	inline bool* get_address_of_firstMoveCenter_18() { return &___firstMoveCenter_18; }
	inline void set_firstMoveCenter_18(bool value)
	{
		___firstMoveCenter_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(HexAIIdentity_t1055646891, ___netData_19)); }
	inline NetData_1_t355594818 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t355594818 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t355594818 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
