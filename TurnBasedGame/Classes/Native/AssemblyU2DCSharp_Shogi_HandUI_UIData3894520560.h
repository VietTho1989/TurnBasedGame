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
// LP`1<Shogi.HandPieceUI/UIData>
struct LP_1_t325137216;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.HandUI/UIData
struct  UIData_t3894520560  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Shogi.Shogi>> Shogi.HandUI/UIData::shogi
	VP_1_t1424602871 * ___shogi_5;
	// LP`1<Shogi.HandPieceUI/UIData> Shogi.HandUI/UIData::handPieces
	LP_1_t325137216 * ___handPieces_6;

public:
	inline static int32_t get_offset_of_shogi_5() { return static_cast<int32_t>(offsetof(UIData_t3894520560, ___shogi_5)); }
	inline VP_1_t1424602871 * get_shogi_5() const { return ___shogi_5; }
	inline VP_1_t1424602871 ** get_address_of_shogi_5() { return &___shogi_5; }
	inline void set_shogi_5(VP_1_t1424602871 * value)
	{
		___shogi_5 = value;
		Il2CppCodeGenWriteBarrier(&___shogi_5, value);
	}

	inline static int32_t get_offset_of_handPieces_6() { return static_cast<int32_t>(offsetof(UIData_t3894520560, ___handPieces_6)); }
	inline LP_1_t325137216 * get_handPieces_6() const { return ___handPieces_6; }
	inline LP_1_t325137216 ** get_address_of_handPieces_6() { return &___handPieces_6; }
	inline void set_handPieces_6(LP_1_t325137216 * value)
	{
		___handPieces_6 = value;
		Il2CppCodeGenWriteBarrier(&___handPieces_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
