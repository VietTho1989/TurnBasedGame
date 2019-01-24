#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Gomoku.Gomoku>>
struct VP_1_t2098049877;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<Weiqi.BoardBackgroundUI/UIData>
struct VP_1_t1644906614;
// LP`1<Gomoku.PieceUI/UIData>
struct LP_1_t2008156813;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.BoardUI/UIData
struct  UIData_t2020820277  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Gomoku.Gomoku>> Gomoku.BoardUI/UIData::gomoku
	VP_1_t2098049877 * ___gomoku_5;
	// VP`1<System.Int32> Gomoku.BoardUI/UIData::boardSize
	VP_1_t2450154454 * ___boardSize_6;
	// VP`1<Weiqi.BoardBackgroundUI/UIData> Gomoku.BoardUI/UIData::background
	VP_1_t1644906614 * ___background_7;
	// LP`1<Gomoku.PieceUI/UIData> Gomoku.BoardUI/UIData::pieces
	LP_1_t2008156813 * ___pieces_8;

public:
	inline static int32_t get_offset_of_gomoku_5() { return static_cast<int32_t>(offsetof(UIData_t2020820277, ___gomoku_5)); }
	inline VP_1_t2098049877 * get_gomoku_5() const { return ___gomoku_5; }
	inline VP_1_t2098049877 ** get_address_of_gomoku_5() { return &___gomoku_5; }
	inline void set_gomoku_5(VP_1_t2098049877 * value)
	{
		___gomoku_5 = value;
		Il2CppCodeGenWriteBarrier(&___gomoku_5, value);
	}

	inline static int32_t get_offset_of_boardSize_6() { return static_cast<int32_t>(offsetof(UIData_t2020820277, ___boardSize_6)); }
	inline VP_1_t2450154454 * get_boardSize_6() const { return ___boardSize_6; }
	inline VP_1_t2450154454 ** get_address_of_boardSize_6() { return &___boardSize_6; }
	inline void set_boardSize_6(VP_1_t2450154454 * value)
	{
		___boardSize_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_6, value);
	}

	inline static int32_t get_offset_of_background_7() { return static_cast<int32_t>(offsetof(UIData_t2020820277, ___background_7)); }
	inline VP_1_t1644906614 * get_background_7() const { return ___background_7; }
	inline VP_1_t1644906614 ** get_address_of_background_7() { return &___background_7; }
	inline void set_background_7(VP_1_t1644906614 * value)
	{
		___background_7 = value;
		Il2CppCodeGenWriteBarrier(&___background_7, value);
	}

	inline static int32_t get_offset_of_pieces_8() { return static_cast<int32_t>(offsetof(UIData_t2020820277, ___pieces_8)); }
	inline LP_1_t2008156813 * get_pieces_8() const { return ___pieces_8; }
	inline LP_1_t2008156813 ** get_address_of_pieces_8() { return &___pieces_8; }
	inline void set_pieces_8(LP_1_t2008156813 * value)
	{
		___pieces_8 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
