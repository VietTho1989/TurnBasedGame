#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameObserver_CheckChange811089867.h"

// HumanConnection
struct HumanConnection_t3632757279;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanConnectionObserver
struct  HumanConnectionObserver_t61494367  : public CheckChange_t811089867
{
public:
	// HumanConnection HumanConnectionObserver::data
	HumanConnection_t3632757279 * ___data_1;

public:
	inline static int32_t get_offset_of_data_1() { return static_cast<int32_t>(offsetof(HumanConnectionObserver_t61494367, ___data_1)); }
	inline HumanConnection_t3632757279 * get_data_1() const { return ___data_1; }
	inline HumanConnection_t3632757279 ** get_address_of_data_1() { return &___data_1; }
	inline void set_data_1(HumanConnection_t3632757279 * value)
	{
		___data_1 = value;
		Il2CppCodeGenWriteBarrier(&___data_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
