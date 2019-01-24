#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_ProcessMoveAction_State4148807084.h"

// NetData`1<ProcessMoveAction>
struct NetData_1_t3491591191;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ProcessMoveActionIdentity
struct  ProcessMoveActionIdentity_t3705603700  : public DataIdentity_t543951486
{
public:
	// ProcessMoveAction/State ProcessMoveActionIdentity::state
	int32_t ___state_17;
	// NetData`1<ProcessMoveAction> ProcessMoveActionIdentity::netData
	NetData_1_t3491591191 * ___netData_18;

public:
	inline static int32_t get_offset_of_state_17() { return static_cast<int32_t>(offsetof(ProcessMoveActionIdentity_t3705603700, ___state_17)); }
	inline int32_t get_state_17() const { return ___state_17; }
	inline int32_t* get_address_of_state_17() { return &___state_17; }
	inline void set_state_17(int32_t value)
	{
		___state_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(ProcessMoveActionIdentity_t3705603700, ___netData_18)); }
	inline NetData_1_t3491591191 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3491591191 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3491591191 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
