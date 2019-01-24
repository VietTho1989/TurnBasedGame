#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<Weiqi.Group>
struct NetData_1_t2763810188;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.GroupIdentity
struct  GroupIdentity_t2631380401  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Weiqi.GroupIdentity::lib
	SyncListInt_t3316705628 * ___lib_17;
	// System.Int32 Weiqi.GroupIdentity::libs
	int32_t ___libs_18;
	// NetData`1<Weiqi.Group> Weiqi.GroupIdentity::netData
	NetData_1_t2763810188 * ___netData_19;

public:
	inline static int32_t get_offset_of_lib_17() { return static_cast<int32_t>(offsetof(GroupIdentity_t2631380401, ___lib_17)); }
	inline SyncListInt_t3316705628 * get_lib_17() const { return ___lib_17; }
	inline SyncListInt_t3316705628 ** get_address_of_lib_17() { return &___lib_17; }
	inline void set_lib_17(SyncListInt_t3316705628 * value)
	{
		___lib_17 = value;
		Il2CppCodeGenWriteBarrier(&___lib_17, value);
	}

	inline static int32_t get_offset_of_libs_18() { return static_cast<int32_t>(offsetof(GroupIdentity_t2631380401, ___libs_18)); }
	inline int32_t get_libs_18() const { return ___libs_18; }
	inline int32_t* get_address_of_libs_18() { return &___libs_18; }
	inline void set_libs_18(int32_t value)
	{
		___libs_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(GroupIdentity_t2631380401, ___netData_19)); }
	inline NetData_1_t2763810188 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2763810188 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2763810188 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct GroupIdentity_t2631380401_StaticFields
{
public:
	// System.Int32 Weiqi.GroupIdentity::kListlib
	int32_t ___kListlib_20;

public:
	inline static int32_t get_offset_of_kListlib_20() { return static_cast<int32_t>(offsetof(GroupIdentity_t2631380401_StaticFields, ___kListlib_20)); }
	inline int32_t get_kListlib_20() const { return ___kListlib_20; }
	inline int32_t* get_address_of_kListlib_20() { return &___kListlib_20; }
	inline void set_kListlib_20(int32_t value)
	{
		___kListlib_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
