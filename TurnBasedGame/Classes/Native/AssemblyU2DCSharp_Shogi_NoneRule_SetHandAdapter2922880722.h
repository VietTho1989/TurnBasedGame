#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scrol771087135.h"

// Shogi.NoneRule.SetHandHolder
struct SetHandHolder_t3463322887;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.SetHandAdapter
struct  SetHandAdapter_t2922880722  : public SRIA_2_t771087135
{
public:
	// Shogi.NoneRule.SetHandHolder Shogi.NoneRule.SetHandAdapter::holderPrefab
	SetHandHolder_t3463322887 * ___holderPrefab_24;
	// UnityEngine.GameObject Shogi.NoneRule.SetHandAdapter::noPieces
	GameObject_t1756533147 * ___noPieces_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(SetHandAdapter_t2922880722, ___holderPrefab_24)); }
	inline SetHandHolder_t3463322887 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline SetHandHolder_t3463322887 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(SetHandHolder_t3463322887 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noPieces_25() { return static_cast<int32_t>(offsetof(SetHandAdapter_t2922880722, ___noPieces_25)); }
	inline GameObject_t1756533147 * get_noPieces_25() const { return ___noPieces_25; }
	inline GameObject_t1756533147 ** get_address_of_noPieces_25() { return &___noPieces_25; }
	inline void set_noPieces_25(GameObject_t1756533147 * value)
	{
		___noPieces_25 = value;
		Il2CppCodeGenWriteBarrier(&___noPieces_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
