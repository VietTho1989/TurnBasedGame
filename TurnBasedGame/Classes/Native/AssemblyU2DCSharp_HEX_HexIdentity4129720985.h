#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// DataIdentity/SyncListSByte
struct SyncListSByte_t583884747;
// NetData`1<HEX.Hex>
struct NetData_1_t1661537184;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexIdentity
struct  HexIdentity_t4129720985  : public DataIdentity_t543951486
{
public:
	// System.UInt16 HEX.HexIdentity::boardSize
	uint16_t ___boardSize_17;
	// DataIdentity/SyncListSByte HEX.HexIdentity::board
	SyncListSByte_t583884747 * ___board_18;
	// System.Boolean HEX.HexIdentity::isSwitch
	bool ___isSwitch_19;
	// System.Boolean HEX.HexIdentity::isCustom
	bool ___isCustom_20;
	// System.Int32 HEX.HexIdentity::playerIndex
	int32_t ___playerIndex_21;
	// NetData`1<HEX.Hex> HEX.HexIdentity::netData
	NetData_1_t1661537184 * ___netData_22;

public:
	inline static int32_t get_offset_of_boardSize_17() { return static_cast<int32_t>(offsetof(HexIdentity_t4129720985, ___boardSize_17)); }
	inline uint16_t get_boardSize_17() const { return ___boardSize_17; }
	inline uint16_t* get_address_of_boardSize_17() { return &___boardSize_17; }
	inline void set_boardSize_17(uint16_t value)
	{
		___boardSize_17 = value;
	}

	inline static int32_t get_offset_of_board_18() { return static_cast<int32_t>(offsetof(HexIdentity_t4129720985, ___board_18)); }
	inline SyncListSByte_t583884747 * get_board_18() const { return ___board_18; }
	inline SyncListSByte_t583884747 ** get_address_of_board_18() { return &___board_18; }
	inline void set_board_18(SyncListSByte_t583884747 * value)
	{
		___board_18 = value;
		Il2CppCodeGenWriteBarrier(&___board_18, value);
	}

	inline static int32_t get_offset_of_isSwitch_19() { return static_cast<int32_t>(offsetof(HexIdentity_t4129720985, ___isSwitch_19)); }
	inline bool get_isSwitch_19() const { return ___isSwitch_19; }
	inline bool* get_address_of_isSwitch_19() { return &___isSwitch_19; }
	inline void set_isSwitch_19(bool value)
	{
		___isSwitch_19 = value;
	}

	inline static int32_t get_offset_of_isCustom_20() { return static_cast<int32_t>(offsetof(HexIdentity_t4129720985, ___isCustom_20)); }
	inline bool get_isCustom_20() const { return ___isCustom_20; }
	inline bool* get_address_of_isCustom_20() { return &___isCustom_20; }
	inline void set_isCustom_20(bool value)
	{
		___isCustom_20 = value;
	}

	inline static int32_t get_offset_of_playerIndex_21() { return static_cast<int32_t>(offsetof(HexIdentity_t4129720985, ___playerIndex_21)); }
	inline int32_t get_playerIndex_21() const { return ___playerIndex_21; }
	inline int32_t* get_address_of_playerIndex_21() { return &___playerIndex_21; }
	inline void set_playerIndex_21(int32_t value)
	{
		___playerIndex_21 = value;
	}

	inline static int32_t get_offset_of_netData_22() { return static_cast<int32_t>(offsetof(HexIdentity_t4129720985, ___netData_22)); }
	inline NetData_1_t1661537184 * get_netData_22() const { return ___netData_22; }
	inline NetData_1_t1661537184 ** get_address_of_netData_22() { return &___netData_22; }
	inline void set_netData_22(NetData_1_t1661537184 * value)
	{
		___netData_22 = value;
		Il2CppCodeGenWriteBarrier(&___netData_22, value);
	}
};

struct HexIdentity_t4129720985_StaticFields
{
public:
	// System.Int32 HEX.HexIdentity::kListboard
	int32_t ___kListboard_23;

public:
	inline static int32_t get_offset_of_kListboard_23() { return static_cast<int32_t>(offsetof(HexIdentity_t4129720985_StaticFields, ___kListboard_23)); }
	inline int32_t get_kListboard_23() const { return ___kListboard_23; }
	inline int32_t* get_address_of_kListboard_23() { return &___kListboard_23; }
	inline void set_kListboard_23(int32_t value)
	{
		___kListboard_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
