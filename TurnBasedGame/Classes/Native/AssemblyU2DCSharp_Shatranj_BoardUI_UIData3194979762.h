#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Shatranj.Shatranj>>
struct VP_1_t2644303178;
// VP`1<Shatranj.ShatranjFenUI/UIData>
struct VP_1_t3673950612;
// LP`1<Shatranj.PieceUI/UIData>
struct LP_1_t708350048;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.BoardUI/UIData
struct  UIData_t3194979762  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Shatranj.Shatranj>> Shatranj.BoardUI/UIData::shatranj
	VP_1_t2644303178 * ___shatranj_5;
	// VP`1<Shatranj.ShatranjFenUI/UIData> Shatranj.BoardUI/UIData::shatranjFen
	VP_1_t3673950612 * ___shatranjFen_6;
	// LP`1<Shatranj.PieceUI/UIData> Shatranj.BoardUI/UIData::pieces
	LP_1_t708350048 * ___pieces_7;

public:
	inline static int32_t get_offset_of_shatranj_5() { return static_cast<int32_t>(offsetof(UIData_t3194979762, ___shatranj_5)); }
	inline VP_1_t2644303178 * get_shatranj_5() const { return ___shatranj_5; }
	inline VP_1_t2644303178 ** get_address_of_shatranj_5() { return &___shatranj_5; }
	inline void set_shatranj_5(VP_1_t2644303178 * value)
	{
		___shatranj_5 = value;
		Il2CppCodeGenWriteBarrier(&___shatranj_5, value);
	}

	inline static int32_t get_offset_of_shatranjFen_6() { return static_cast<int32_t>(offsetof(UIData_t3194979762, ___shatranjFen_6)); }
	inline VP_1_t3673950612 * get_shatranjFen_6() const { return ___shatranjFen_6; }
	inline VP_1_t3673950612 ** get_address_of_shatranjFen_6() { return &___shatranjFen_6; }
	inline void set_shatranjFen_6(VP_1_t3673950612 * value)
	{
		___shatranjFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t3194979762, ___pieces_7)); }
	inline LP_1_t708350048 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t708350048 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t708350048 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
