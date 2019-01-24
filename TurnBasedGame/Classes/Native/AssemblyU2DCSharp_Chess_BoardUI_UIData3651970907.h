#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Chess.Chess>>
struct VP_1_t1603404227;
// VP`1<Chess.ChessFenUI/UIData>
struct VP_1_t3387180438;
// LP`1<Chess.PieceUI/UIData>
struct LP_1_t3709371575;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.BoardUI/UIData
struct  UIData_t3651970907  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Chess.Chess>> Chess.BoardUI/UIData::chess
	VP_1_t1603404227 * ___chess_5;
	// VP`1<Chess.ChessFenUI/UIData> Chess.BoardUI/UIData::chessFen
	VP_1_t3387180438 * ___chessFen_6;
	// LP`1<Chess.PieceUI/UIData> Chess.BoardUI/UIData::pieces
	LP_1_t3709371575 * ___pieces_7;

public:
	inline static int32_t get_offset_of_chess_5() { return static_cast<int32_t>(offsetof(UIData_t3651970907, ___chess_5)); }
	inline VP_1_t1603404227 * get_chess_5() const { return ___chess_5; }
	inline VP_1_t1603404227 ** get_address_of_chess_5() { return &___chess_5; }
	inline void set_chess_5(VP_1_t1603404227 * value)
	{
		___chess_5 = value;
		Il2CppCodeGenWriteBarrier(&___chess_5, value);
	}

	inline static int32_t get_offset_of_chessFen_6() { return static_cast<int32_t>(offsetof(UIData_t3651970907, ___chessFen_6)); }
	inline VP_1_t3387180438 * get_chessFen_6() const { return ___chessFen_6; }
	inline VP_1_t3387180438 ** get_address_of_chessFen_6() { return &___chessFen_6; }
	inline void set_chessFen_6(VP_1_t3387180438 * value)
	{
		___chessFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___chessFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t3651970907, ___pieces_7)); }
	inline LP_1_t3709371575 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t3709371575 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t3709371575 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
