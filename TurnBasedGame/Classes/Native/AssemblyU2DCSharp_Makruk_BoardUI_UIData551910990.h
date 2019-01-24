#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Makruk.Makruk>>
struct VP_1_t2401907368;
// VP`1<Makruk.MakrukFenUI/UIData>
struct VP_1_t2694886560;
// LP`1<Makruk.PieceUI/UIData>
struct LP_1_t3149967012;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.BoardUI/UIData
struct  UIData_t551910990  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Makruk.Makruk>> Makruk.BoardUI/UIData::makruk
	VP_1_t2401907368 * ___makruk_5;
	// VP`1<Makruk.MakrukFenUI/UIData> Makruk.BoardUI/UIData::makrukFen
	VP_1_t2694886560 * ___makrukFen_6;
	// LP`1<Makruk.PieceUI/UIData> Makruk.BoardUI/UIData::pieces
	LP_1_t3149967012 * ___pieces_7;

public:
	inline static int32_t get_offset_of_makruk_5() { return static_cast<int32_t>(offsetof(UIData_t551910990, ___makruk_5)); }
	inline VP_1_t2401907368 * get_makruk_5() const { return ___makruk_5; }
	inline VP_1_t2401907368 ** get_address_of_makruk_5() { return &___makruk_5; }
	inline void set_makruk_5(VP_1_t2401907368 * value)
	{
		___makruk_5 = value;
		Il2CppCodeGenWriteBarrier(&___makruk_5, value);
	}

	inline static int32_t get_offset_of_makrukFen_6() { return static_cast<int32_t>(offsetof(UIData_t551910990, ___makrukFen_6)); }
	inline VP_1_t2694886560 * get_makrukFen_6() const { return ___makrukFen_6; }
	inline VP_1_t2694886560 ** get_address_of_makrukFen_6() { return &___makrukFen_6; }
	inline void set_makrukFen_6(VP_1_t2694886560 * value)
	{
		___makrukFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___makrukFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t551910990, ___pieces_7)); }
	inline LP_1_t3149967012 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t3149967012 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t3149967012 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
