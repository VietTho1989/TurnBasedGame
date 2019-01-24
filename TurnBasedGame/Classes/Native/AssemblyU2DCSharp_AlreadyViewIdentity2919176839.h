#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<AlreadyView>
struct NetData_1_t1052446510;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AlreadyViewIdentity
struct  AlreadyViewIdentity_t2919176839  : public DataIdentity_t543951486
{
public:
	// System.Boolean AlreadyViewIdentity::isEnable
	bool ___isEnable_17;
	// NetData`1<AlreadyView> AlreadyViewIdentity::netData
	NetData_1_t1052446510 * ___netData_18;

public:
	inline static int32_t get_offset_of_isEnable_17() { return static_cast<int32_t>(offsetof(AlreadyViewIdentity_t2919176839, ___isEnable_17)); }
	inline bool get_isEnable_17() const { return ___isEnable_17; }
	inline bool* get_address_of_isEnable_17() { return &___isEnable_17; }
	inline void set_isEnable_17(bool value)
	{
		___isEnable_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(AlreadyViewIdentity_t2919176839, ___netData_18)); }
	inline NetData_1_t1052446510 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1052446510 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1052446510 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
