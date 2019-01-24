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

// ObserverController/ConnectionInfo
struct  ConnectionInfo_t900544717  : public Il2CppObject
{
public:
	// System.Int32 ObserverController/ConnectionInfo::dataSize
	int32_t ___dataSize_0;
	// System.Boolean ObserverController/ConnectionInfo::allow
	bool ___allow_1;
	// System.Single ObserverController/ConnectionInfo::time
	float ___time_2;
	// System.Int32 ObserverController/ConnectionInfo::outPacket
	int32_t ___outPacket_3;

public:
	inline static int32_t get_offset_of_dataSize_0() { return static_cast<int32_t>(offsetof(ConnectionInfo_t900544717, ___dataSize_0)); }
	inline int32_t get_dataSize_0() const { return ___dataSize_0; }
	inline int32_t* get_address_of_dataSize_0() { return &___dataSize_0; }
	inline void set_dataSize_0(int32_t value)
	{
		___dataSize_0 = value;
	}

	inline static int32_t get_offset_of_allow_1() { return static_cast<int32_t>(offsetof(ConnectionInfo_t900544717, ___allow_1)); }
	inline bool get_allow_1() const { return ___allow_1; }
	inline bool* get_address_of_allow_1() { return &___allow_1; }
	inline void set_allow_1(bool value)
	{
		___allow_1 = value;
	}

	inline static int32_t get_offset_of_time_2() { return static_cast<int32_t>(offsetof(ConnectionInfo_t900544717, ___time_2)); }
	inline float get_time_2() const { return ___time_2; }
	inline float* get_address_of_time_2() { return &___time_2; }
	inline void set_time_2(float value)
	{
		___time_2 = value;
	}

	inline static int32_t get_offset_of_outPacket_3() { return static_cast<int32_t>(offsetof(ConnectionInfo_t900544717, ___outPacket_3)); }
	inline int32_t get_outPacket_3() const { return ___outPacket_3; }
	inline int32_t* get_address_of_outPacket_3() { return &___outPacket_3; }
	inline void set_outPacket_3(int32_t value)
	{
		___outPacket_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
