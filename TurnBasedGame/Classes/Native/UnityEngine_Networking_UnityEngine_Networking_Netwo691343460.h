#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkConnection/PacketStat
struct  PacketStat_t691343460  : public Il2CppObject
{
public:
	// System.Int16 UnityEngine.Networking.NetworkConnection/PacketStat::msgType
	int16_t ___msgType_0;
	// System.Int32 UnityEngine.Networking.NetworkConnection/PacketStat::count
	int32_t ___count_1;
	// System.Int32 UnityEngine.Networking.NetworkConnection/PacketStat::bytes
	int32_t ___bytes_2;

public:
	inline static int32_t get_offset_of_msgType_0() { return static_cast<int32_t>(offsetof(PacketStat_t691343460, ___msgType_0)); }
	inline int16_t get_msgType_0() const { return ___msgType_0; }
	inline int16_t* get_address_of_msgType_0() { return &___msgType_0; }
	inline void set_msgType_0(int16_t value)
	{
		___msgType_0 = value;
	}

	inline static int32_t get_offset_of_count_1() { return static_cast<int32_t>(offsetof(PacketStat_t691343460, ___count_1)); }
	inline int32_t get_count_1() const { return ___count_1; }
	inline int32_t* get_address_of_count_1() { return &___count_1; }
	inline void set_count_1(int32_t value)
	{
		___count_1 = value;
	}

	inline static int32_t get_offset_of_bytes_2() { return static_cast<int32_t>(offsetof(PacketStat_t691343460, ___bytes_2)); }
	inline int32_t get_bytes_2() const { return ___bytes_2; }
	inline int32_t* get_address_of_bytes_2() { return &___bytes_2; }
	inline void set_bytes_2(int32_t value)
	{
		___bytes_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
