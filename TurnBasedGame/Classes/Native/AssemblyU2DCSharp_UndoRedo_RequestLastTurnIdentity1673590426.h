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

// NetData`1<UndoRedo.RequestLastTurn>
struct NetData_1_t58456853;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.RequestLastTurnIdentity
struct  RequestLastTurnIdentity_t1673590426  : public DataIdentity_t543951486
{
public:
	// UndoRedoRequest/Operation UndoRedo.RequestLastTurnIdentity::operation
	int32_t ___operation_17;
	// NetData`1<UndoRedo.RequestLastTurn> UndoRedo.RequestLastTurnIdentity::netData
	NetData_1_t58456853 * ___netData_18;

public:
	inline static int32_t get_offset_of_operation_17() { return static_cast<int32_t>(offsetof(RequestLastTurnIdentity_t1673590426, ___operation_17)); }
	inline int32_t get_operation_17() const { return ___operation_17; }
	inline int32_t* get_address_of_operation_17() { return &___operation_17; }
	inline void set_operation_17(int32_t value)
	{
		___operation_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(RequestLastTurnIdentity_t1673590426, ___netData_18)); }
	inline NetData_1_t58456853 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t58456853 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t58456853 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
