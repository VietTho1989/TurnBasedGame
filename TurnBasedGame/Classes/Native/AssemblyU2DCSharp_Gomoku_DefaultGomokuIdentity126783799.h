#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Gomoku.DefaultGomoku>
struct NetData_1_t677131018;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.DefaultGomokuIdentity
struct  DefaultGomokuIdentity_t126783799  : public DataIdentity_t543951486
{
public:
	// System.Int32 Gomoku.DefaultGomokuIdentity::boardSize
	int32_t ___boardSize_17;
	// NetData`1<Gomoku.DefaultGomoku> Gomoku.DefaultGomokuIdentity::netData
	NetData_1_t677131018 * ___netData_18;

public:
	inline static int32_t get_offset_of_boardSize_17() { return static_cast<int32_t>(offsetof(DefaultGomokuIdentity_t126783799, ___boardSize_17)); }
	inline int32_t get_boardSize_17() const { return ___boardSize_17; }
	inline int32_t* get_address_of_boardSize_17() { return &___boardSize_17; }
	inline void set_boardSize_17(int32_t value)
	{
		___boardSize_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(DefaultGomokuIdentity_t126783799, ___netData_18)); }
	inline NetData_1_t677131018 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t677131018 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t677131018 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
