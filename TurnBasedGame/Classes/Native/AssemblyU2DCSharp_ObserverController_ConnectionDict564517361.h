#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<UnityEngine.Networking.NetworkConnection,ObserverController/ConnectionInfo>
struct Dictionary_2_t1386993294;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ObserverController/ConnectionDict
struct  ConnectionDict_t564517361  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<UnityEngine.Networking.NetworkConnection,ObserverController/ConnectionInfo> ObserverController/ConnectionDict::dict
	Dictionary_2_t1386993294 * ___dict_0;
	// System.Int32 ObserverController/ConnectionDict::checkPerUpdate
	int32_t ___checkPerUpdate_1;
	// System.Boolean ObserverController/ConnectionDict::allow
	bool ___allow_2;

public:
	inline static int32_t get_offset_of_dict_0() { return static_cast<int32_t>(offsetof(ConnectionDict_t564517361, ___dict_0)); }
	inline Dictionary_2_t1386993294 * get_dict_0() const { return ___dict_0; }
	inline Dictionary_2_t1386993294 ** get_address_of_dict_0() { return &___dict_0; }
	inline void set_dict_0(Dictionary_2_t1386993294 * value)
	{
		___dict_0 = value;
		Il2CppCodeGenWriteBarrier(&___dict_0, value);
	}

	inline static int32_t get_offset_of_checkPerUpdate_1() { return static_cast<int32_t>(offsetof(ConnectionDict_t564517361, ___checkPerUpdate_1)); }
	inline int32_t get_checkPerUpdate_1() const { return ___checkPerUpdate_1; }
	inline int32_t* get_address_of_checkPerUpdate_1() { return &___checkPerUpdate_1; }
	inline void set_checkPerUpdate_1(int32_t value)
	{
		___checkPerUpdate_1 = value;
	}

	inline static int32_t get_offset_of_allow_2() { return static_cast<int32_t>(offsetof(ConnectionDict_t564517361, ___allow_2)); }
	inline bool get_allow_2() const { return ___allow_2; }
	inline bool* get_address_of_allow_2() { return &___allow_2; }
	inline void set_allow_2(bool value)
	{
		___allow_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
