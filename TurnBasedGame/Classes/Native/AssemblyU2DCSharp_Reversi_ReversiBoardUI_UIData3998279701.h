#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Reversi.Reversi>>
struct VP_1_t2036835161;
// LP`1<Reversi.ReversiPieceUI/UIData>
struct LP_1_t3011085741;
// LP`1<Reversi.ReversiLegalUI/UIData>
struct LP_1_t4064687184;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiBoardUI/UIData
struct  UIData_t3998279701  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Reversi.Reversi>> Reversi.ReversiBoardUI/UIData::reversi
	VP_1_t2036835161 * ___reversi_5;
	// LP`1<Reversi.ReversiPieceUI/UIData> Reversi.ReversiBoardUI/UIData::pieces
	LP_1_t3011085741 * ___pieces_6;
	// LP`1<Reversi.ReversiLegalUI/UIData> Reversi.ReversiBoardUI/UIData::legals
	LP_1_t4064687184 * ___legals_7;

public:
	inline static int32_t get_offset_of_reversi_5() { return static_cast<int32_t>(offsetof(UIData_t3998279701, ___reversi_5)); }
	inline VP_1_t2036835161 * get_reversi_5() const { return ___reversi_5; }
	inline VP_1_t2036835161 ** get_address_of_reversi_5() { return &___reversi_5; }
	inline void set_reversi_5(VP_1_t2036835161 * value)
	{
		___reversi_5 = value;
		Il2CppCodeGenWriteBarrier(&___reversi_5, value);
	}

	inline static int32_t get_offset_of_pieces_6() { return static_cast<int32_t>(offsetof(UIData_t3998279701, ___pieces_6)); }
	inline LP_1_t3011085741 * get_pieces_6() const { return ___pieces_6; }
	inline LP_1_t3011085741 ** get_address_of_pieces_6() { return &___pieces_6; }
	inline void set_pieces_6(LP_1_t3011085741 * value)
	{
		___pieces_6 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_6, value);
	}

	inline static int32_t get_offset_of_legals_7() { return static_cast<int32_t>(offsetof(UIData_t3998279701, ___legals_7)); }
	inline LP_1_t4064687184 * get_legals_7() const { return ___legals_7; }
	inline LP_1_t4064687184 ** get_address_of_legals_7() { return &___legals_7; }
	inline void set_legals_7(LP_1_t4064687184 * value)
	{
		___legals_7 = value;
		Il2CppCodeGenWriteBarrier(&___legals_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
