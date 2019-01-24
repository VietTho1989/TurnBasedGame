#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro2083869865.h"

// GameManager.Match.MatchTeamHolder
struct MatchTeamHolder_t670987720;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.MatchTeamAdapter
struct  MatchTeamAdapter_t688344035  : public SRIA_2_t2083869865
{
public:
	// GameManager.Match.MatchTeamHolder GameManager.Match.MatchTeamAdapter::holderPrefab
	MatchTeamHolder_t670987720 * ___holderPrefab_24;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(MatchTeamAdapter_t688344035, ___holderPrefab_24)); }
	inline MatchTeamHolder_t670987720 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline MatchTeamHolder_t670987720 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(MatchTeamHolder_t670987720 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
