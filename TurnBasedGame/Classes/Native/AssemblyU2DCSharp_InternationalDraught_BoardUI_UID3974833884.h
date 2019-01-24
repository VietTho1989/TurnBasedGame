#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<InternationalDraught.InternationalDraught>>
struct VP_1_t4090574100;
// VP`1<InternationalDraught.InternationalDraughtFenUI/UIData>
struct VP_1_t3879871488;
// LP`1<InternationalDraught.PieceUI/UIData>
struct LP_1_t3154618982;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.BoardUI/UIData
struct  UIData_t3974833884  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<InternationalDraught.InternationalDraught>> InternationalDraught.BoardUI/UIData::internationalDraught
	VP_1_t4090574100 * ___internationalDraught_5;
	// VP`1<InternationalDraught.InternationalDraughtFenUI/UIData> InternationalDraught.BoardUI/UIData::internationalDraughtFen
	VP_1_t3879871488 * ___internationalDraughtFen_6;
	// LP`1<InternationalDraught.PieceUI/UIData> InternationalDraught.BoardUI/UIData::pieces
	LP_1_t3154618982 * ___pieces_7;

public:
	inline static int32_t get_offset_of_internationalDraught_5() { return static_cast<int32_t>(offsetof(UIData_t3974833884, ___internationalDraught_5)); }
	inline VP_1_t4090574100 * get_internationalDraught_5() const { return ___internationalDraught_5; }
	inline VP_1_t4090574100 ** get_address_of_internationalDraught_5() { return &___internationalDraught_5; }
	inline void set_internationalDraught_5(VP_1_t4090574100 * value)
	{
		___internationalDraught_5 = value;
		Il2CppCodeGenWriteBarrier(&___internationalDraught_5, value);
	}

	inline static int32_t get_offset_of_internationalDraughtFen_6() { return static_cast<int32_t>(offsetof(UIData_t3974833884, ___internationalDraughtFen_6)); }
	inline VP_1_t3879871488 * get_internationalDraughtFen_6() const { return ___internationalDraughtFen_6; }
	inline VP_1_t3879871488 ** get_address_of_internationalDraughtFen_6() { return &___internationalDraughtFen_6; }
	inline void set_internationalDraughtFen_6(VP_1_t3879871488 * value)
	{
		___internationalDraughtFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___internationalDraughtFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t3974833884, ___pieces_7)); }
	inline LP_1_t3154618982 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t3154618982 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t3154618982 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
