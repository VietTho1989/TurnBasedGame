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
// NetData`1<CoTuongUp.Node>
struct NetData_1_t1286637431;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.NodeIdentity
struct  NodeIdentity_t2290777656  : public DataIdentity_t543951486
{
public:
	// System.Int32 CoTuongUp.NodeIdentity::ply
	int32_t ___ply_17;
	// DataIdentity/SyncListByte CoTuongUp.NodeIdentity::pieces
	SyncListByte_t230810734 * ___pieces_18;
	// DataIdentity/SyncListByte CoTuongUp.NodeIdentity::captures
	SyncListByte_t230810734 * ___captures_19;
	// NetData`1<CoTuongUp.Node> CoTuongUp.NodeIdentity::netData
	NetData_1_t1286637431 * ___netData_20;

public:
	inline static int32_t get_offset_of_ply_17() { return static_cast<int32_t>(offsetof(NodeIdentity_t2290777656, ___ply_17)); }
	inline int32_t get_ply_17() const { return ___ply_17; }
	inline int32_t* get_address_of_ply_17() { return &___ply_17; }
	inline void set_ply_17(int32_t value)
	{
		___ply_17 = value;
	}

	inline static int32_t get_offset_of_pieces_18() { return static_cast<int32_t>(offsetof(NodeIdentity_t2290777656, ___pieces_18)); }
	inline SyncListByte_t230810734 * get_pieces_18() const { return ___pieces_18; }
	inline SyncListByte_t230810734 ** get_address_of_pieces_18() { return &___pieces_18; }
	inline void set_pieces_18(SyncListByte_t230810734 * value)
	{
		___pieces_18 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_18, value);
	}

	inline static int32_t get_offset_of_captures_19() { return static_cast<int32_t>(offsetof(NodeIdentity_t2290777656, ___captures_19)); }
	inline SyncListByte_t230810734 * get_captures_19() const { return ___captures_19; }
	inline SyncListByte_t230810734 ** get_address_of_captures_19() { return &___captures_19; }
	inline void set_captures_19(SyncListByte_t230810734 * value)
	{
		___captures_19 = value;
		Il2CppCodeGenWriteBarrier(&___captures_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(NodeIdentity_t2290777656, ___netData_20)); }
	inline NetData_1_t1286637431 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t1286637431 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t1286637431 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

struct NodeIdentity_t2290777656_StaticFields
{
public:
	// System.Int32 CoTuongUp.NodeIdentity::kListpieces
	int32_t ___kListpieces_21;
	// System.Int32 CoTuongUp.NodeIdentity::kListcaptures
	int32_t ___kListcaptures_22;

public:
	inline static int32_t get_offset_of_kListpieces_21() { return static_cast<int32_t>(offsetof(NodeIdentity_t2290777656_StaticFields, ___kListpieces_21)); }
	inline int32_t get_kListpieces_21() const { return ___kListpieces_21; }
	inline int32_t* get_address_of_kListpieces_21() { return &___kListpieces_21; }
	inline void set_kListpieces_21(int32_t value)
	{
		___kListpieces_21 = value;
	}

	inline static int32_t get_offset_of_kListcaptures_22() { return static_cast<int32_t>(offsetof(NodeIdentity_t2290777656_StaticFields, ___kListcaptures_22)); }
	inline int32_t get_kListcaptures_22() const { return ___kListcaptures_22; }
	inline int32_t* get_address_of_kListcaptures_22() { return &___kListcaptures_22; }
	inline void set_kListcaptures_22(int32_t value)
	{
		___kListcaptures_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
