#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Shogi.Shogi>>
struct VP_1_t1424602871;
// VP`1<Shogi.ShogiFenUI/UIData>
struct VP_1_t3465622550;
// LP`1<Shogi.PieceUI/UIData>
struct LP_1_t2958016347;
// VP`1<Shogi.HandUI/UIData>
struct VP_1_t4272797566;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.BoardUI/UIData
struct  UIData_t1464986423  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Shogi.Shogi>> Shogi.BoardUI/UIData::shogi
	VP_1_t1424602871 * ___shogi_5;
	// VP`1<Shogi.ShogiFenUI/UIData> Shogi.BoardUI/UIData::shogiFen
	VP_1_t3465622550 * ___shogiFen_6;
	// LP`1<Shogi.PieceUI/UIData> Shogi.BoardUI/UIData::pieces
	LP_1_t2958016347 * ___pieces_7;
	// VP`1<Shogi.HandUI/UIData> Shogi.BoardUI/UIData::hand
	VP_1_t4272797566 * ___hand_8;

public:
	inline static int32_t get_offset_of_shogi_5() { return static_cast<int32_t>(offsetof(UIData_t1464986423, ___shogi_5)); }
	inline VP_1_t1424602871 * get_shogi_5() const { return ___shogi_5; }
	inline VP_1_t1424602871 ** get_address_of_shogi_5() { return &___shogi_5; }
	inline void set_shogi_5(VP_1_t1424602871 * value)
	{
		___shogi_5 = value;
		Il2CppCodeGenWriteBarrier(&___shogi_5, value);
	}

	inline static int32_t get_offset_of_shogiFen_6() { return static_cast<int32_t>(offsetof(UIData_t1464986423, ___shogiFen_6)); }
	inline VP_1_t3465622550 * get_shogiFen_6() const { return ___shogiFen_6; }
	inline VP_1_t3465622550 ** get_address_of_shogiFen_6() { return &___shogiFen_6; }
	inline void set_shogiFen_6(VP_1_t3465622550 * value)
	{
		___shogiFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___shogiFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t1464986423, ___pieces_7)); }
	inline LP_1_t2958016347 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t2958016347 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t2958016347 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}

	inline static int32_t get_offset_of_hand_8() { return static_cast<int32_t>(offsetof(UIData_t1464986423, ___hand_8)); }
	inline VP_1_t4272797566 * get_hand_8() const { return ___hand_8; }
	inline VP_1_t4272797566 ** get_address_of_hand_8() { return &___hand_8; }
	inline void set_hand_8(VP_1_t4272797566 * value)
	{
		___hand_8 = value;
		Il2CppCodeGenWriteBarrier(&___hand_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
