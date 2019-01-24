#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GamePlayer>>
struct VP_1_t2203324776;
// VP`1<InformAvatarUI/UIData>
struct VP_1_t2969382667;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundGamePlayerUI/UIData
struct  UIData_t938951776  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GamePlayer>> GameManager.Match.RoundGamePlayerUI/UIData::gamePlayer
	VP_1_t2203324776 * ___gamePlayer_5;
	// VP`1<InformAvatarUI/UIData> GameManager.Match.RoundGamePlayerUI/UIData::avatar
	VP_1_t2969382667 * ___avatar_6;

public:
	inline static int32_t get_offset_of_gamePlayer_5() { return static_cast<int32_t>(offsetof(UIData_t938951776, ___gamePlayer_5)); }
	inline VP_1_t2203324776 * get_gamePlayer_5() const { return ___gamePlayer_5; }
	inline VP_1_t2203324776 ** get_address_of_gamePlayer_5() { return &___gamePlayer_5; }
	inline void set_gamePlayer_5(VP_1_t2203324776 * value)
	{
		___gamePlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___gamePlayer_5, value);
	}

	inline static int32_t get_offset_of_avatar_6() { return static_cast<int32_t>(offsetof(UIData_t938951776, ___avatar_6)); }
	inline VP_1_t2969382667 * get_avatar_6() const { return ___avatar_6; }
	inline VP_1_t2969382667 ** get_address_of_avatar_6() { return &___avatar_6; }
	inline void set_avatar_6(VP_1_t2969382667 * value)
	{
		___avatar_6 = value;
		Il2CppCodeGenWriteBarrier(&___avatar_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
