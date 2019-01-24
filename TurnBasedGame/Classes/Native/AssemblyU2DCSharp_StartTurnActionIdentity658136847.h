#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_StartTurnAction_State4181036581.h"

// NetData`1<StartTurnAction>
struct NetData_1_t4141301230;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// StartTurnActionIdentity
struct  StartTurnActionIdentity_t658136847  : public DataIdentity_t543951486
{
public:
	// StartTurnAction/State StartTurnActionIdentity::state
	int32_t ___state_17;
	// NetData`1<StartTurnAction> StartTurnActionIdentity::netData
	NetData_1_t4141301230 * ___netData_18;

public:
	inline static int32_t get_offset_of_state_17() { return static_cast<int32_t>(offsetof(StartTurnActionIdentity_t658136847, ___state_17)); }
	inline int32_t get_state_17() const { return ___state_17; }
	inline int32_t* get_address_of_state_17() { return &___state_17; }
	inline void set_state_17(int32_t value)
	{
		___state_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(StartTurnActionIdentity_t658136847, ___netData_18)); }
	inline NetData_1_t4141301230 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t4141301230 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t4141301230 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
