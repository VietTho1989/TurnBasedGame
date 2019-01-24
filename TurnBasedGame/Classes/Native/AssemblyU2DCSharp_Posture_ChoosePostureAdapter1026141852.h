#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scrol906942559.h"

// Posture.ChoosePostureHolder
struct ChoosePostureHolder_t3952098609;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.ChoosePostureAdapter
struct  ChoosePostureAdapter_t1026141852  : public SRIA_2_t906942559
{
public:
	// Posture.ChoosePostureHolder Posture.ChoosePostureAdapter::holderPrefab
	ChoosePostureHolder_t3952098609 * ___holderPrefab_24;
	// UnityEngine.GameObject Posture.ChoosePostureAdapter::noPostures
	GameObject_t1756533147 * ___noPostures_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChoosePostureAdapter_t1026141852, ___holderPrefab_24)); }
	inline ChoosePostureHolder_t3952098609 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChoosePostureHolder_t3952098609 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChoosePostureHolder_t3952098609 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noPostures_25() { return static_cast<int32_t>(offsetof(ChoosePostureAdapter_t1026141852, ___noPostures_25)); }
	inline GameObject_t1756533147 * get_noPostures_25() const { return ___noPostures_25; }
	inline GameObject_t1756533147 ** get_address_of_noPostures_25() { return &___noPostures_25; }
	inline void set_noPostures_25(GameObject_t1756533147 * value)
	{
		___noPostures_25 = value;
		Il2CppCodeGenWriteBarrier(&___noPostures_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
