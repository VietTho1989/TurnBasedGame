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
// NetData`1<HEX.HexSwitchAnimation>
struct NetData_1_t699742822;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexSwitchAnimationIdentity
struct  HexSwitchAnimationIdentity_t1852349935  : public DataIdentity_t543951486
{
public:
	// System.UInt16 HEX.HexSwitchAnimationIdentity::boardSize
	uint16_t ___boardSize_17;
	// DataIdentity/SyncListSByte HEX.HexSwitchAnimationIdentity::board
	SyncListSByte_t583884747 * ___board_18;
	// NetData`1<HEX.HexSwitchAnimation> HEX.HexSwitchAnimationIdentity::netData
	NetData_1_t699742822 * ___netData_19;

public:
	inline static int32_t get_offset_of_boardSize_17() { return static_cast<int32_t>(offsetof(HexSwitchAnimationIdentity_t1852349935, ___boardSize_17)); }
	inline uint16_t get_boardSize_17() const { return ___boardSize_17; }
	inline uint16_t* get_address_of_boardSize_17() { return &___boardSize_17; }
	inline void set_boardSize_17(uint16_t value)
	{
		___boardSize_17 = value;
	}

	inline static int32_t get_offset_of_board_18() { return static_cast<int32_t>(offsetof(HexSwitchAnimationIdentity_t1852349935, ___board_18)); }
	inline SyncListSByte_t583884747 * get_board_18() const { return ___board_18; }
	inline SyncListSByte_t583884747 ** get_address_of_board_18() { return &___board_18; }
	inline void set_board_18(SyncListSByte_t583884747 * value)
	{
		___board_18 = value;
		Il2CppCodeGenWriteBarrier(&___board_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(HexSwitchAnimationIdentity_t1852349935, ___netData_19)); }
	inline NetData_1_t699742822 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t699742822 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t699742822 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct HexSwitchAnimationIdentity_t1852349935_StaticFields
{
public:
	// System.Int32 HEX.HexSwitchAnimationIdentity::kListboard
	int32_t ___kListboard_20;

public:
	inline static int32_t get_offset_of_kListboard_20() { return static_cast<int32_t>(offsetof(HexSwitchAnimationIdentity_t1852349935_StaticFields, ___kListboard_20)); }
	inline int32_t get_kListboard_20() const { return ___kListboard_20; }
	inline int32_t* get_address_of_kListboard_20() { return &___kListboard_20; }
	inline void set_kListboard_20(int32_t value)
	{
		___kListboard_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
