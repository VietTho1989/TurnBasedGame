#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<InternationalDraught.Node>
struct NetData_1_t390752831;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.NodeIdentity
struct  NodeIdentity_t337247756  : public DataIdentity_t543951486
{
public:
	// System.Int32 InternationalDraught.NodeIdentity::p_ply
	int32_t ___p_ply_17;
	// NetData`1<InternationalDraught.Node> InternationalDraught.NodeIdentity::netData
	NetData_1_t390752831 * ___netData_18;

public:
	inline static int32_t get_offset_of_p_ply_17() { return static_cast<int32_t>(offsetof(NodeIdentity_t337247756, ___p_ply_17)); }
	inline int32_t get_p_ply_17() const { return ___p_ply_17; }
	inline int32_t* get_address_of_p_ply_17() { return &___p_ply_17; }
	inline void set_p_ply_17(int32_t value)
	{
		___p_ply_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(NodeIdentity_t337247756, ___netData_18)); }
	inline NetData_1_t390752831 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t390752831 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t390752831 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
