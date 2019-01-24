#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// NetData`1<UndoRedo.Ask>
struct NetData_1_t982121656;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.AskIdentity
struct  AskIdentity_t3100509345  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListUInt UndoRedo.AskIdentity::accepts
	SyncListUInt_t2190275715 * ___accepts_17;
	// UnityEngine.Networking.SyncListUInt UndoRedo.AskIdentity::cancels
	SyncListUInt_t2190275715 * ___cancels_18;
	// NetData`1<UndoRedo.Ask> UndoRedo.AskIdentity::netData
	NetData_1_t982121656 * ___netData_19;

public:
	inline static int32_t get_offset_of_accepts_17() { return static_cast<int32_t>(offsetof(AskIdentity_t3100509345, ___accepts_17)); }
	inline SyncListUInt_t2190275715 * get_accepts_17() const { return ___accepts_17; }
	inline SyncListUInt_t2190275715 ** get_address_of_accepts_17() { return &___accepts_17; }
	inline void set_accepts_17(SyncListUInt_t2190275715 * value)
	{
		___accepts_17 = value;
		Il2CppCodeGenWriteBarrier(&___accepts_17, value);
	}

	inline static int32_t get_offset_of_cancels_18() { return static_cast<int32_t>(offsetof(AskIdentity_t3100509345, ___cancels_18)); }
	inline SyncListUInt_t2190275715 * get_cancels_18() const { return ___cancels_18; }
	inline SyncListUInt_t2190275715 ** get_address_of_cancels_18() { return &___cancels_18; }
	inline void set_cancels_18(SyncListUInt_t2190275715 * value)
	{
		___cancels_18 = value;
		Il2CppCodeGenWriteBarrier(&___cancels_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(AskIdentity_t3100509345, ___netData_19)); }
	inline NetData_1_t982121656 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t982121656 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t982121656 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct AskIdentity_t3100509345_StaticFields
{
public:
	// System.Int32 UndoRedo.AskIdentity::kListaccepts
	int32_t ___kListaccepts_20;
	// System.Int32 UndoRedo.AskIdentity::kListcancels
	int32_t ___kListcancels_21;

public:
	inline static int32_t get_offset_of_kListaccepts_20() { return static_cast<int32_t>(offsetof(AskIdentity_t3100509345_StaticFields, ___kListaccepts_20)); }
	inline int32_t get_kListaccepts_20() const { return ___kListaccepts_20; }
	inline int32_t* get_address_of_kListaccepts_20() { return &___kListaccepts_20; }
	inline void set_kListaccepts_20(int32_t value)
	{
		___kListaccepts_20 = value;
	}

	inline static int32_t get_offset_of_kListcancels_21() { return static_cast<int32_t>(offsetof(AskIdentity_t3100509345_StaticFields, ___kListcancels_21)); }
	inline int32_t get_kListcancels_21() const { return ___kListcancels_21; }
	inline int32_t* get_address_of_kListcancels_21() { return &___kListcancels_21; }
	inline void set_kListcancels_21(int32_t value)
	{
		___kListcancels_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
