#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen735545981.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.RoundStateLoadUI
struct RoundStateLoadUI_t2102089213;
// GameManager.Match.RoundStateStartUI
struct RoundStateStartUI_t56933379;
// GameManager.Match.RoundStatePlayUI
struct RoundStatePlayUI_t1467878843;
// GameManager.Match.RoundStateEndUI
struct RoundStateEndUI_t490629226;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundHolder
struct  ChooseRoundHolder_t1693867089  : public SriaHolderBehavior_1_t735545981
{
public:
	// UnityEngine.UI.Text GameManager.Match.ChooseRoundHolder::tvIndex
	Text_t356221433 * ___tvIndex_16;
	// GameManager.Match.RoundStateLoadUI GameManager.Match.ChooseRoundHolder::loadPrefab
	RoundStateLoadUI_t2102089213 * ___loadPrefab_17;
	// GameManager.Match.RoundStateStartUI GameManager.Match.ChooseRoundHolder::startPrefab
	RoundStateStartUI_t56933379 * ___startPrefab_18;
	// GameManager.Match.RoundStatePlayUI GameManager.Match.ChooseRoundHolder::playPrefab
	RoundStatePlayUI_t1467878843 * ___playPrefab_19;
	// GameManager.Match.RoundStateEndUI GameManager.Match.ChooseRoundHolder::endPrefab
	RoundStateEndUI_t490629226 * ___endPrefab_20;
	// UnityEngine.Transform GameManager.Match.ChooseRoundHolder::roundStateContainer
	Transform_t3275118058 * ___roundStateContainer_21;

public:
	inline static int32_t get_offset_of_tvIndex_16() { return static_cast<int32_t>(offsetof(ChooseRoundHolder_t1693867089, ___tvIndex_16)); }
	inline Text_t356221433 * get_tvIndex_16() const { return ___tvIndex_16; }
	inline Text_t356221433 ** get_address_of_tvIndex_16() { return &___tvIndex_16; }
	inline void set_tvIndex_16(Text_t356221433 * value)
	{
		___tvIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_16, value);
	}

	inline static int32_t get_offset_of_loadPrefab_17() { return static_cast<int32_t>(offsetof(ChooseRoundHolder_t1693867089, ___loadPrefab_17)); }
	inline RoundStateLoadUI_t2102089213 * get_loadPrefab_17() const { return ___loadPrefab_17; }
	inline RoundStateLoadUI_t2102089213 ** get_address_of_loadPrefab_17() { return &___loadPrefab_17; }
	inline void set_loadPrefab_17(RoundStateLoadUI_t2102089213 * value)
	{
		___loadPrefab_17 = value;
		Il2CppCodeGenWriteBarrier(&___loadPrefab_17, value);
	}

	inline static int32_t get_offset_of_startPrefab_18() { return static_cast<int32_t>(offsetof(ChooseRoundHolder_t1693867089, ___startPrefab_18)); }
	inline RoundStateStartUI_t56933379 * get_startPrefab_18() const { return ___startPrefab_18; }
	inline RoundStateStartUI_t56933379 ** get_address_of_startPrefab_18() { return &___startPrefab_18; }
	inline void set_startPrefab_18(RoundStateStartUI_t56933379 * value)
	{
		___startPrefab_18 = value;
		Il2CppCodeGenWriteBarrier(&___startPrefab_18, value);
	}

	inline static int32_t get_offset_of_playPrefab_19() { return static_cast<int32_t>(offsetof(ChooseRoundHolder_t1693867089, ___playPrefab_19)); }
	inline RoundStatePlayUI_t1467878843 * get_playPrefab_19() const { return ___playPrefab_19; }
	inline RoundStatePlayUI_t1467878843 ** get_address_of_playPrefab_19() { return &___playPrefab_19; }
	inline void set_playPrefab_19(RoundStatePlayUI_t1467878843 * value)
	{
		___playPrefab_19 = value;
		Il2CppCodeGenWriteBarrier(&___playPrefab_19, value);
	}

	inline static int32_t get_offset_of_endPrefab_20() { return static_cast<int32_t>(offsetof(ChooseRoundHolder_t1693867089, ___endPrefab_20)); }
	inline RoundStateEndUI_t490629226 * get_endPrefab_20() const { return ___endPrefab_20; }
	inline RoundStateEndUI_t490629226 ** get_address_of_endPrefab_20() { return &___endPrefab_20; }
	inline void set_endPrefab_20(RoundStateEndUI_t490629226 * value)
	{
		___endPrefab_20 = value;
		Il2CppCodeGenWriteBarrier(&___endPrefab_20, value);
	}

	inline static int32_t get_offset_of_roundStateContainer_21() { return static_cast<int32_t>(offsetof(ChooseRoundHolder_t1693867089, ___roundStateContainer_21)); }
	inline Transform_t3275118058 * get_roundStateContainer_21() const { return ___roundStateContainer_21; }
	inline Transform_t3275118058 ** get_address_of_roundStateContainer_21() { return &___roundStateContainer_21; }
	inline void set_roundStateContainer_21(Transform_t3275118058 * value)
	{
		___roundStateContainer_21 = value;
		Il2CppCodeGenWriteBarrier(&___roundStateContainer_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
