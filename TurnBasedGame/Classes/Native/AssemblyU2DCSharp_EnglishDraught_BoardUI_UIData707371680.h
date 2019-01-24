#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<EnglishDraught.EnglishDraught>>
struct VP_1_t2071334316;
// VP`1<EnglishDraught.EnglishDraughtFenUI/UIData>
struct VP_1_t2068828736;
// LP`1<EnglishDraught.PieceUI/UIData>
struct LP_1_t1073644018;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.BoardUI/UIData
struct  UIData_t707371680  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<EnglishDraught.EnglishDraught>> EnglishDraught.BoardUI/UIData::englishDraught
	VP_1_t2071334316 * ___englishDraught_5;
	// VP`1<EnglishDraught.EnglishDraughtFenUI/UIData> EnglishDraught.BoardUI/UIData::englishDraughtFen
	VP_1_t2068828736 * ___englishDraughtFen_6;
	// LP`1<EnglishDraught.PieceUI/UIData> EnglishDraught.BoardUI/UIData::pieces
	LP_1_t1073644018 * ___pieces_7;

public:
	inline static int32_t get_offset_of_englishDraught_5() { return static_cast<int32_t>(offsetof(UIData_t707371680, ___englishDraught_5)); }
	inline VP_1_t2071334316 * get_englishDraught_5() const { return ___englishDraught_5; }
	inline VP_1_t2071334316 ** get_address_of_englishDraught_5() { return &___englishDraught_5; }
	inline void set_englishDraught_5(VP_1_t2071334316 * value)
	{
		___englishDraught_5 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraught_5, value);
	}

	inline static int32_t get_offset_of_englishDraughtFen_6() { return static_cast<int32_t>(offsetof(UIData_t707371680, ___englishDraughtFen_6)); }
	inline VP_1_t2068828736 * get_englishDraughtFen_6() const { return ___englishDraughtFen_6; }
	inline VP_1_t2068828736 ** get_address_of_englishDraughtFen_6() { return &___englishDraughtFen_6; }
	inline void set_englishDraughtFen_6(VP_1_t2068828736 * value)
	{
		___englishDraughtFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraughtFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t707371680, ___pieces_7)); }
	inline LP_1_t1073644018 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t1073644018 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t1073644018 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
