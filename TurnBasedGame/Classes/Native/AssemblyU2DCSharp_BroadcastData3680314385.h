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

// BroadcastData
struct  BroadcastData_t3680314385  : public Il2CppObject
{
public:
	// System.Int32 BroadcastData::version
	int32_t ___version_1;
	// System.Int32 BroadcastData::port
	int32_t ___port_2;
	// System.Int32 BroadcastData::player
	int32_t ___player_3;

public:
	inline static int32_t get_offset_of_version_1() { return static_cast<int32_t>(offsetof(BroadcastData_t3680314385, ___version_1)); }
	inline int32_t get_version_1() const { return ___version_1; }
	inline int32_t* get_address_of_version_1() { return &___version_1; }
	inline void set_version_1(int32_t value)
	{
		___version_1 = value;
	}

	inline static int32_t get_offset_of_port_2() { return static_cast<int32_t>(offsetof(BroadcastData_t3680314385, ___port_2)); }
	inline int32_t get_port_2() const { return ___port_2; }
	inline int32_t* get_address_of_port_2() { return &___port_2; }
	inline void set_port_2(int32_t value)
	{
		___port_2 = value;
	}

	inline static int32_t get_offset_of_player_3() { return static_cast<int32_t>(offsetof(BroadcastData_t3680314385, ___player_3)); }
	inline int32_t get_player_3() const { return ___player_3; }
	inline int32_t* get_address_of_player_3() { return &___player_3; }
	inline void set_player_3(int32_t value)
	{
		___player_3 = value;
	}
};

struct BroadcastData_t3680314385_StaticFields
{
public:
	// System.Int32 BroadcastData::VERSION
	int32_t ___VERSION_0;

public:
	inline static int32_t get_offset_of_VERSION_0() { return static_cast<int32_t>(offsetof(BroadcastData_t3680314385_StaticFields, ___VERSION_0)); }
	inline int32_t get_VERSION_0() const { return ___VERSION_0; }
	inline int32_t* get_address_of_VERSION_0() { return &___VERSION_0; }
	inline void set_VERSION_0(int32_t value)
	{
		___VERSION_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
