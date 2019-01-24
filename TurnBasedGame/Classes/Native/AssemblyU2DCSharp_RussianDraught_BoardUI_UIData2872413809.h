#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<RussianDraught.RussianDraught>>
struct VP_1_t2849039769;
// VP`1<RussianDraught.RussianDraughtFenUI/UIData>
struct VP_1_t696758426;
// LP`1<RussianDraught.PieceUI/UIData>
struct LP_1_t3700742049;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.BoardUI/UIData
struct  UIData_t2872413809  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<RussianDraught.RussianDraught>> RussianDraught.BoardUI/UIData::russianDraught
	VP_1_t2849039769 * ___russianDraught_5;
	// VP`1<RussianDraught.RussianDraughtFenUI/UIData> RussianDraught.BoardUI/UIData::russianDraughtFen
	VP_1_t696758426 * ___russianDraughtFen_6;
	// LP`1<RussianDraught.PieceUI/UIData> RussianDraught.BoardUI/UIData::pieces
	LP_1_t3700742049 * ___pieces_7;

public:
	inline static int32_t get_offset_of_russianDraught_5() { return static_cast<int32_t>(offsetof(UIData_t2872413809, ___russianDraught_5)); }
	inline VP_1_t2849039769 * get_russianDraught_5() const { return ___russianDraught_5; }
	inline VP_1_t2849039769 ** get_address_of_russianDraught_5() { return &___russianDraught_5; }
	inline void set_russianDraught_5(VP_1_t2849039769 * value)
	{
		___russianDraught_5 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraught_5, value);
	}

	inline static int32_t get_offset_of_russianDraughtFen_6() { return static_cast<int32_t>(offsetof(UIData_t2872413809, ___russianDraughtFen_6)); }
	inline VP_1_t696758426 * get_russianDraughtFen_6() const { return ___russianDraughtFen_6; }
	inline VP_1_t696758426 ** get_address_of_russianDraughtFen_6() { return &___russianDraughtFen_6; }
	inline void set_russianDraughtFen_6(VP_1_t696758426 * value)
	{
		___russianDraughtFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t2872413809, ___pieces_7)); }
	inline LP_1_t3700742049 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t3700742049 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t3700742049 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
