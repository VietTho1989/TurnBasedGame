#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameType1512575910.h"

// VP`1<System.UInt16>
struct VP_1_t1365159617;
// LP`1<System.SByte>
struct LP_1_t3487128801;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.Hex
struct  Hex_t1415188659  : public GameType_t1512575910
{
public:
	// VP`1<System.UInt16> HEX.Hex::boardSize
	VP_1_t1365159617 * ___boardSize_12;
	// LP`1<System.SByte> HEX.Hex::board
	LP_1_t3487128801 * ___board_13;
	// VP`1<System.Boolean> HEX.Hex::isSwitch
	VP_1_t4203851724 * ___isSwitch_14;
	// VP`1<System.Boolean> HEX.Hex::isCustom
	VP_1_t4203851724 * ___isCustom_15;
	// VP`1<System.Int32> HEX.Hex::playerIndex
	VP_1_t2450154454 * ___playerIndex_16;

public:
	inline static int32_t get_offset_of_boardSize_12() { return static_cast<int32_t>(offsetof(Hex_t1415188659, ___boardSize_12)); }
	inline VP_1_t1365159617 * get_boardSize_12() const { return ___boardSize_12; }
	inline VP_1_t1365159617 ** get_address_of_boardSize_12() { return &___boardSize_12; }
	inline void set_boardSize_12(VP_1_t1365159617 * value)
	{
		___boardSize_12 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_12, value);
	}

	inline static int32_t get_offset_of_board_13() { return static_cast<int32_t>(offsetof(Hex_t1415188659, ___board_13)); }
	inline LP_1_t3487128801 * get_board_13() const { return ___board_13; }
	inline LP_1_t3487128801 ** get_address_of_board_13() { return &___board_13; }
	inline void set_board_13(LP_1_t3487128801 * value)
	{
		___board_13 = value;
		Il2CppCodeGenWriteBarrier(&___board_13, value);
	}

	inline static int32_t get_offset_of_isSwitch_14() { return static_cast<int32_t>(offsetof(Hex_t1415188659, ___isSwitch_14)); }
	inline VP_1_t4203851724 * get_isSwitch_14() const { return ___isSwitch_14; }
	inline VP_1_t4203851724 ** get_address_of_isSwitch_14() { return &___isSwitch_14; }
	inline void set_isSwitch_14(VP_1_t4203851724 * value)
	{
		___isSwitch_14 = value;
		Il2CppCodeGenWriteBarrier(&___isSwitch_14, value);
	}

	inline static int32_t get_offset_of_isCustom_15() { return static_cast<int32_t>(offsetof(Hex_t1415188659, ___isCustom_15)); }
	inline VP_1_t4203851724 * get_isCustom_15() const { return ___isCustom_15; }
	inline VP_1_t4203851724 ** get_address_of_isCustom_15() { return &___isCustom_15; }
	inline void set_isCustom_15(VP_1_t4203851724 * value)
	{
		___isCustom_15 = value;
		Il2CppCodeGenWriteBarrier(&___isCustom_15, value);
	}

	inline static int32_t get_offset_of_playerIndex_16() { return static_cast<int32_t>(offsetof(Hex_t1415188659, ___playerIndex_16)); }
	inline VP_1_t2450154454 * get_playerIndex_16() const { return ___playerIndex_16; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_16() { return &___playerIndex_16; }
	inline void set_playerIndex_16(VP_1_t2450154454 * value)
	{
		___playerIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_16, value);
	}
};

struct Hex_t1415188659_StaticFields
{
public:
	// System.Collections.Generic.List`1<System.Byte> HEX.Hex::AllowNames
	List_1_t3052225568 * ___AllowNames_17;

public:
	inline static int32_t get_offset_of_AllowNames_17() { return static_cast<int32_t>(offsetof(Hex_t1415188659_StaticFields, ___AllowNames_17)); }
	inline List_1_t3052225568 * get_AllowNames_17() const { return ___AllowNames_17; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_17() { return &___AllowNames_17; }
	inline void set_AllowNames_17(List_1_t3052225568 * value)
	{
		___AllowNames_17 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
