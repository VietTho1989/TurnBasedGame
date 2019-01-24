#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_HEX_Common_Color3026989984.h"

// DataIdentity/SyncListSByte
struct SyncListSByte_t583884747;
// NetData`1<HEX.HexMoveAnimation>
struct NetData_1_t3752152849;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexMoveAnimationIdentity
struct  HexMoveAnimationIdentity_t2359991878  : public DataIdentity_t543951486
{
public:
	// System.UInt16 HEX.HexMoveAnimationIdentity::boardSize
	uint16_t ___boardSize_17;
	// DataIdentity/SyncListSByte HEX.HexMoveAnimationIdentity::board
	SyncListSByte_t583884747 * ___board_18;
	// System.UInt16 HEX.HexMoveAnimationIdentity::move
	uint16_t ___move_19;
	// HEX.Common/Color HEX.HexMoveAnimationIdentity::color
	int32_t ___color_20;
	// NetData`1<HEX.HexMoveAnimation> HEX.HexMoveAnimationIdentity::netData
	NetData_1_t3752152849 * ___netData_21;

public:
	inline static int32_t get_offset_of_boardSize_17() { return static_cast<int32_t>(offsetof(HexMoveAnimationIdentity_t2359991878, ___boardSize_17)); }
	inline uint16_t get_boardSize_17() const { return ___boardSize_17; }
	inline uint16_t* get_address_of_boardSize_17() { return &___boardSize_17; }
	inline void set_boardSize_17(uint16_t value)
	{
		___boardSize_17 = value;
	}

	inline static int32_t get_offset_of_board_18() { return static_cast<int32_t>(offsetof(HexMoveAnimationIdentity_t2359991878, ___board_18)); }
	inline SyncListSByte_t583884747 * get_board_18() const { return ___board_18; }
	inline SyncListSByte_t583884747 ** get_address_of_board_18() { return &___board_18; }
	inline void set_board_18(SyncListSByte_t583884747 * value)
	{
		___board_18 = value;
		Il2CppCodeGenWriteBarrier(&___board_18, value);
	}

	inline static int32_t get_offset_of_move_19() { return static_cast<int32_t>(offsetof(HexMoveAnimationIdentity_t2359991878, ___move_19)); }
	inline uint16_t get_move_19() const { return ___move_19; }
	inline uint16_t* get_address_of_move_19() { return &___move_19; }
	inline void set_move_19(uint16_t value)
	{
		___move_19 = value;
	}

	inline static int32_t get_offset_of_color_20() { return static_cast<int32_t>(offsetof(HexMoveAnimationIdentity_t2359991878, ___color_20)); }
	inline int32_t get_color_20() const { return ___color_20; }
	inline int32_t* get_address_of_color_20() { return &___color_20; }
	inline void set_color_20(int32_t value)
	{
		___color_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(HexMoveAnimationIdentity_t2359991878, ___netData_21)); }
	inline NetData_1_t3752152849 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t3752152849 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t3752152849 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

struct HexMoveAnimationIdentity_t2359991878_StaticFields
{
public:
	// System.Int32 HEX.HexMoveAnimationIdentity::kListboard
	int32_t ___kListboard_22;

public:
	inline static int32_t get_offset_of_kListboard_22() { return static_cast<int32_t>(offsetof(HexMoveAnimationIdentity_t2359991878_StaticFields, ___kListboard_22)); }
	inline int32_t get_kListboard_22() const { return ___kListboard_22; }
	inline int32_t* get_address_of_kListboard_22() { return &___kListboard_22; }
	inline void set_kListboard_22(int32_t value)
	{
		___kListboard_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
