#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Color1267941922.h"
#include "AssemblyU2DCSharp_FairyChess_Common_PieceType2850651519.h"

// NetData`1<FairyChess.NoneRule.FairyChessCustomHand>
struct NetData_1_t1350216768;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.NoneRule.FairyChessCustomHandIdentity
struct  FairyChessCustomHandIdentity_t487438273  : public DataIdentity_t543951486
{
public:
	// FairyChess.Common/Color FairyChess.NoneRule.FairyChessCustomHandIdentity::color
	int32_t ___color_17;
	// FairyChess.Common/PieceType FairyChess.NoneRule.FairyChessCustomHandIdentity::pieceType
	int32_t ___pieceType_18;
	// System.Int32 FairyChess.NoneRule.FairyChessCustomHandIdentity::pieceCount
	int32_t ___pieceCount_19;
	// NetData`1<FairyChess.NoneRule.FairyChessCustomHand> FairyChess.NoneRule.FairyChessCustomHandIdentity::netData
	NetData_1_t1350216768 * ___netData_20;

public:
	inline static int32_t get_offset_of_color_17() { return static_cast<int32_t>(offsetof(FairyChessCustomHandIdentity_t487438273, ___color_17)); }
	inline int32_t get_color_17() const { return ___color_17; }
	inline int32_t* get_address_of_color_17() { return &___color_17; }
	inline void set_color_17(int32_t value)
	{
		___color_17 = value;
	}

	inline static int32_t get_offset_of_pieceType_18() { return static_cast<int32_t>(offsetof(FairyChessCustomHandIdentity_t487438273, ___pieceType_18)); }
	inline int32_t get_pieceType_18() const { return ___pieceType_18; }
	inline int32_t* get_address_of_pieceType_18() { return &___pieceType_18; }
	inline void set_pieceType_18(int32_t value)
	{
		___pieceType_18 = value;
	}

	inline static int32_t get_offset_of_pieceCount_19() { return static_cast<int32_t>(offsetof(FairyChessCustomHandIdentity_t487438273, ___pieceCount_19)); }
	inline int32_t get_pieceCount_19() const { return ___pieceCount_19; }
	inline int32_t* get_address_of_pieceCount_19() { return &___pieceCount_19; }
	inline void set_pieceCount_19(int32_t value)
	{
		___pieceCount_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(FairyChessCustomHandIdentity_t487438273, ___netData_20)); }
	inline NetData_1_t1350216768 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t1350216768 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t1350216768 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
