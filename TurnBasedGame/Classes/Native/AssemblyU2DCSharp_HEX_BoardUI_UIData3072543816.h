#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<HEX.Hex>>
struct VP_1_t864248728;
// VP`1<System.UInt16>
struct VP_1_t1365159617;
// LP`1<HEX.PieceUI/UIData>
struct LP_1_t3671135098;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.BoardUI/UIData
struct  UIData_t3072543816  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<HEX.Hex>> HEX.BoardUI/UIData::hex
	VP_1_t864248728 * ___hex_5;
	// VP`1<System.UInt16> HEX.BoardUI/UIData::boardSize
	VP_1_t1365159617 * ___boardSize_6;
	// LP`1<HEX.PieceUI/UIData> HEX.BoardUI/UIData::pieces
	LP_1_t3671135098 * ___pieces_7;

public:
	inline static int32_t get_offset_of_hex_5() { return static_cast<int32_t>(offsetof(UIData_t3072543816, ___hex_5)); }
	inline VP_1_t864248728 * get_hex_5() const { return ___hex_5; }
	inline VP_1_t864248728 ** get_address_of_hex_5() { return &___hex_5; }
	inline void set_hex_5(VP_1_t864248728 * value)
	{
		___hex_5 = value;
		Il2CppCodeGenWriteBarrier(&___hex_5, value);
	}

	inline static int32_t get_offset_of_boardSize_6() { return static_cast<int32_t>(offsetof(UIData_t3072543816, ___boardSize_6)); }
	inline VP_1_t1365159617 * get_boardSize_6() const { return ___boardSize_6; }
	inline VP_1_t1365159617 ** get_address_of_boardSize_6() { return &___boardSize_6; }
	inline void set_boardSize_6(VP_1_t1365159617 * value)
	{
		___boardSize_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t3072543816, ___pieces_7)); }
	inline LP_1_t3671135098 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t3671135098 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t3671135098 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
