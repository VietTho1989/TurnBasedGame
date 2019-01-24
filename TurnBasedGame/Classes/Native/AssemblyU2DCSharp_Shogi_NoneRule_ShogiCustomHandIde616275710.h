#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Shogi_Common_HandPiece2593686321.h"
#include "AssemblyU2DCSharp_Shogi_Common_Color325621841.h"

// NetData`1<Shogi.NoneRule.ShogiCustomHand>
struct NetData_1_t3630801113;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomHandIdentity
struct  ShogiCustomHandIdentity_t616275710  : public DataIdentity_t543951486
{
public:
	// Shogi.Common/HandPiece Shogi.NoneRule.ShogiCustomHandIdentity::handPiece
	int32_t ___handPiece_17;
	// Shogi.Common/Color Shogi.NoneRule.ShogiCustomHandIdentity::color
	int32_t ___color_18;
	// System.Int32 Shogi.NoneRule.ShogiCustomHandIdentity::pieceCount
	int32_t ___pieceCount_19;
	// NetData`1<Shogi.NoneRule.ShogiCustomHand> Shogi.NoneRule.ShogiCustomHandIdentity::netData
	NetData_1_t3630801113 * ___netData_20;

public:
	inline static int32_t get_offset_of_handPiece_17() { return static_cast<int32_t>(offsetof(ShogiCustomHandIdentity_t616275710, ___handPiece_17)); }
	inline int32_t get_handPiece_17() const { return ___handPiece_17; }
	inline int32_t* get_address_of_handPiece_17() { return &___handPiece_17; }
	inline void set_handPiece_17(int32_t value)
	{
		___handPiece_17 = value;
	}

	inline static int32_t get_offset_of_color_18() { return static_cast<int32_t>(offsetof(ShogiCustomHandIdentity_t616275710, ___color_18)); }
	inline int32_t get_color_18() const { return ___color_18; }
	inline int32_t* get_address_of_color_18() { return &___color_18; }
	inline void set_color_18(int32_t value)
	{
		___color_18 = value;
	}

	inline static int32_t get_offset_of_pieceCount_19() { return static_cast<int32_t>(offsetof(ShogiCustomHandIdentity_t616275710, ___pieceCount_19)); }
	inline int32_t get_pieceCount_19() const { return ___pieceCount_19; }
	inline int32_t* get_address_of_pieceCount_19() { return &___pieceCount_19; }
	inline void set_pieceCount_19(int32_t value)
	{
		___pieceCount_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(ShogiCustomHandIdentity_t616275710, ___netData_20)); }
	inline NetData_1_t3630801113 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t3630801113 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t3630801113 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
