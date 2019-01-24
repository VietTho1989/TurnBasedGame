#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_UndoRedoRequest_Operation2689378189.h"

// NetData`1<UndoRedo.RequestLastYourTurn>
struct NetData_1_t4271788362;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.RequestLastYourTurnIdentity
struct  RequestLastYourTurnIdentity_t1981911383  : public DataIdentity_t543951486
{
public:
	// UndoRedoRequest/Operation UndoRedo.RequestLastYourTurnIdentity::operation
	int32_t ___operation_17;
	// System.UInt32 UndoRedo.RequestLastYourTurnIdentity::userId
	uint32_t ___userId_18;
	// NetData`1<UndoRedo.RequestLastYourTurn> UndoRedo.RequestLastYourTurnIdentity::netData
	NetData_1_t4271788362 * ___netData_19;

public:
	inline static int32_t get_offset_of_operation_17() { return static_cast<int32_t>(offsetof(RequestLastYourTurnIdentity_t1981911383, ___operation_17)); }
	inline int32_t get_operation_17() const { return ___operation_17; }
	inline int32_t* get_address_of_operation_17() { return &___operation_17; }
	inline void set_operation_17(int32_t value)
	{
		___operation_17 = value;
	}

	inline static int32_t get_offset_of_userId_18() { return static_cast<int32_t>(offsetof(RequestLastYourTurnIdentity_t1981911383, ___userId_18)); }
	inline uint32_t get_userId_18() const { return ___userId_18; }
	inline uint32_t* get_address_of_userId_18() { return &___userId_18; }
	inline void set_userId_18(uint32_t value)
	{
		___userId_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(RequestLastYourTurnIdentity_t1981911383, ___netData_19)); }
	inline NetData_1_t4271788362 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t4271788362 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t4271788362 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
