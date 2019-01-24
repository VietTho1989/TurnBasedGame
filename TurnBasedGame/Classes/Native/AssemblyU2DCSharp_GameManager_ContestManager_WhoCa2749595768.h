#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro4137098845.h"

// GameManager.ContestManager.WhoCanAskHolder
struct WhoCanAskHolder_t3556453275;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.ContestManager.WhoCanAskAdapter
struct  WhoCanAskAdapter_t2749595768  : public SRIA_2_t4137098845
{
public:
	// GameManager.ContestManager.WhoCanAskHolder GameManager.ContestManager.WhoCanAskAdapter::holderPrefab
	WhoCanAskHolder_t3556453275 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.ContestManager.WhoCanAskAdapter::noHumans
	GameObject_t1756533147 * ___noHumans_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(WhoCanAskAdapter_t2749595768, ___holderPrefab_24)); }
	inline WhoCanAskHolder_t3556453275 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline WhoCanAskHolder_t3556453275 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(WhoCanAskHolder_t3556453275 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noHumans_25() { return static_cast<int32_t>(offsetof(WhoCanAskAdapter_t2749595768, ___noHumans_25)); }
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
