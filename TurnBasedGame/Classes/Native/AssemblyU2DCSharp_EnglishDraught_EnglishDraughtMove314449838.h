#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// DataIdentity/SyncListByte
struct SyncListByte_t230810734;
// NetData`1<EnglishDraught.EnglishDraughtMove>
struct NetData_1_t1564393505;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.EnglishDraughtMoveIdentity
struct  EnglishDraughtMoveIdentity_t314449838  : public DataIdentity_t543951486
{
public:
	// System.UInt64 EnglishDraught.EnglishDraughtMoveIdentity::SrcDst
	uint64_t ___SrcDst_17;
	// DataIdentity/SyncListByte EnglishDraught.EnglishDraughtMoveIdentity::cPath
	SyncListByte_t230810734 * ___cPath_18;
	// NetData`1<EnglishDraught.EnglishDraughtMove> EnglishDraught.EnglishDraughtMoveIdentity::netData
	NetData_1_t1564393505 * ___netData_19;

public:
	inline static int32_t get_offset_of_SrcDst_17() { return static_cast<int32_t>(offsetof(EnglishDraughtMoveIdentity_t314449838, ___SrcDst_17)); }
	inline uint64_t get_SrcDst_17() const { return ___SrcDst_17; }
	inline uint64_t* get_address_of_SrcDst_17() { return &___SrcDst_17; }
	inline void set_SrcDst_17(uint64_t value)
	{
		___SrcDst_17 = value;
	}

	inline static int32_t get_offset_of_cPath_18() { return static_cast<int32_t>(offsetof(EnglishDraughtMoveIdentity_t314449838, ___cPath_18)); }
	inline SyncListByte_t230810734 * get_cPath_18() const { return ___cPath_18; }
	inline SyncListByte_t230810734 ** get_address_of_cPath_18() { return &___cPath_18; }
	inline void set_cPath_18(SyncListByte_t230810734 * value)
	{
		___cPath_18 = value;
		Il2CppCodeGenWriteBarrier(&___cPath_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(EnglishDraughtMoveIdentity_t314449838, ___netData_19)); }
	inline NetData_1_t1564393505 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1564393505 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1564393505 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct EnglishDraughtMoveIdentity_t314449838_StaticFields
{
public:
	// System.Int32 EnglishDraught.EnglishDraughtMoveIdentity::kListcPath
	int32_t ___kListcPath_20;

public:
	inline static int32_t get_offset_of_kListcPath_20() { return static_cast<int32_t>(offsetof(EnglishDraughtMoveIdentity_t314449838_StaticFields, ___kListcPath_20)); }
	inline int32_t get_kListcPath_20() const { return ___kListcPath_20; }
	inline int32_t* get_address_of_kListcPath_20() { return &___kListcPath_20; }
	inline void set_kListcPath_20(int32_t value)
	{
		___kListcPath_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
