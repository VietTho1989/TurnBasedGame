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
// DataIdentity/SyncListByte
struct SyncListByte_t230810734;
// NetData`1<WrapChange>
struct NetData_1_t3318347809;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WrapChangeIdentity
struct  WrapChangeIdentity_t2614725338  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListUInt WrapChangeIdentity::parentInfor
	SyncListUInt_t2190275715 * ___parentInfor_17;
	// System.Byte WrapChangeIdentity::variableName
	uint8_t ___variableName_18;
	// DataIdentity/SyncListByte WrapChangeIdentity::syncs
	SyncListByte_t230810734 * ___syncs_19;
	// NetData`1<WrapChange> WrapChangeIdentity::netData
	NetData_1_t3318347809 * ___netData_20;
	// System.Boolean WrapChangeIdentity::alreadyRefresh
	bool ___alreadyRefresh_21;

public:
	inline static int32_t get_offset_of_parentInfor_17() { return static_cast<int32_t>(offsetof(WrapChangeIdentity_t2614725338, ___parentInfor_17)); }
	inline SyncListUInt_t2190275715 * get_parentInfor_17() const { return ___parentInfor_17; }
	inline SyncListUInt_t2190275715 ** get_address_of_parentInfor_17() { return &___parentInfor_17; }
	inline void set_parentInfor_17(SyncListUInt_t2190275715 * value)
	{
		___parentInfor_17 = value;
		Il2CppCodeGenWriteBarrier(&___parentInfor_17, value);
	}

	inline static int32_t get_offset_of_variableName_18() { return static_cast<int32_t>(offsetof(WrapChangeIdentity_t2614725338, ___variableName_18)); }
	inline uint8_t get_variableName_18() const { return ___variableName_18; }
	inline uint8_t* get_address_of_variableName_18() { return &___variableName_18; }
	inline void set_variableName_18(uint8_t value)
	{
		___variableName_18 = value;
	}

	inline static int32_t get_offset_of_syncs_19() { return static_cast<int32_t>(offsetof(WrapChangeIdentity_t2614725338, ___syncs_19)); }
	inline SyncListByte_t230810734 * get_syncs_19() const { return ___syncs_19; }
	inline SyncListByte_t230810734 ** get_address_of_syncs_19() { return &___syncs_19; }
	inline void set_syncs_19(SyncListByte_t230810734 * value)
	{
		___syncs_19 = value;
		Il2CppCodeGenWriteBarrier(&___syncs_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(WrapChangeIdentity_t2614725338, ___netData_20)); }
	inline NetData_1_t3318347809 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t3318347809 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t3318347809 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}

	inline static int32_t get_offset_of_alreadyRefresh_21() { return static_cast<int32_t>(offsetof(WrapChangeIdentity_t2614725338, ___alreadyRefresh_21)); }
	inline bool get_alreadyRefresh_21() const { return ___alreadyRefresh_21; }
	inline bool* get_address_of_alreadyRefresh_21() { return &___alreadyRefresh_21; }
	inline void set_alreadyRefresh_21(bool value)
	{
		___alreadyRefresh_21 = value;
	}
};

struct WrapChangeIdentity_t2614725338_StaticFields
{
public:
	// System.Int32 WrapChangeIdentity::kListparentInfor
	int32_t ___kListparentInfor_22;
	// System.Int32 WrapChangeIdentity::kListsyncs
	int32_t ___kListsyncs_23;

public:
	inline static int32_t get_offset_of_kListparentInfor_22() { return static_cast<int32_t>(offsetof(WrapChangeIdentity_t2614725338_StaticFields, ___kListparentInfor_22)); }
	inline int32_t get_kListparentInfor_22() const { return ___kListparentInfor_22; }
	inline int32_t* get_address_of_kListparentInfor_22() { return &___kListparentInfor_22; }
	inline void set_kListparentInfor_22(int32_t value)
	{
		___kListparentInfor_22 = value;
	}

	inline static int32_t get_offset_of_kListsyncs_23() { return static_cast<int32_t>(offsetof(WrapChangeIdentity_t2614725338_StaticFields, ___kListsyncs_23)); }
	inline int32_t get_kListsyncs_23() const { return ___kListsyncs_23; }
	inline int32_t* get_address_of_kListsyncs_23() { return &___kListsyncs_23; }
	inline void set_kListsyncs_23(int32_t value)
	{
		___kListsyncs_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
