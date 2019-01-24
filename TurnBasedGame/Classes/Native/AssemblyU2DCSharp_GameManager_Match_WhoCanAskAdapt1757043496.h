#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro2183790033.h"

// GameManager.Match.WhoCanAskHolder
struct WhoCanAskHolder_t1044080743;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.WhoCanAskAdapter
struct  WhoCanAskAdapter_t1757043496  : public SRIA_2_t2183790033
{
public:
	// GameManager.Match.WhoCanAskHolder GameManager.Match.WhoCanAskAdapter::holderPrefab
	WhoCanAskHolder_t1044080743 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.WhoCanAskAdapter::noHumans
	GameObject_t1756533147 * ___noHumans_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(WhoCanAskAdapter_t1757043496, ___holderPrefab_24)); }
	inline WhoCanAskHolder_t1044080743 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline WhoCanAskHolder_t1044080743 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(WhoCanAskHolder_t1044080743 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noHumans_25() { return static_cast<int32_t>(offsetof(WhoCanAskAdapter_t1757043496, ___noHumans_25)); }
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
