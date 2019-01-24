#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro3602099207.h"

// GameManager.Match.Elimination.WhoCanAskHolder
struct WhoCanAskHolder_t2671457311;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.WhoCanAskAdapter
struct  WhoCanAskAdapter_t484093772  : public SRIA_2_t3602099207
{
public:
	// GameManager.Match.Elimination.WhoCanAskHolder GameManager.Match.Elimination.WhoCanAskAdapter::holderPrefab
	WhoCanAskHolder_t2671457311 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.Elimination.WhoCanAskAdapter::noHumans
	GameObject_t1756533147 * ___noHumans_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(WhoCanAskAdapter_t484093772, ___holderPrefab_24)); }
	inline WhoCanAskHolder_t2671457311 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline WhoCanAskHolder_t2671457311 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(WhoCanAskHolder_t2671457311 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noHumans_25() { return static_cast<int32_t>(offsetof(WhoCanAskAdapter_t484093772, ___noHumans_25)); }
	inline GameObject_t1756533147 * get_noHumans_25() const { return ___noHumans_25; }
	inline GameObject_t1756533147 ** get_address_of_noHumans_25() { return &___noHumans_25; }
	inline void set_noHumans_25(GameObject_t1756533147 * value)
	{
		___noHumans_25 = value;
		Il2CppCodeGenWriteBarrier(&___noHumans_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
