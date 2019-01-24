#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2220296617.h"

// GameManager.Match.LobbyPlayerHolder
struct LobbyPlayerHolder_t712587207;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyPlayerAdapter
struct  LobbyPlayerAdapter_t1090902582  : public UIBehavior_1_t2220296617
{
public:
	// GameManager.Match.LobbyPlayerHolder GameManager.Match.LobbyPlayerAdapter::holderPrefab
	LobbyPlayerHolder_t712587207 * ___holderPrefab_6;
	// UnityEngine.Transform GameManager.Match.LobbyPlayerAdapter::holderContainer
	Transform_t3275118058 * ___holderContainer_7;

public:
	inline static int32_t get_offset_of_holderPrefab_6() { return static_cast<int32_t>(offsetof(LobbyPlayerAdapter_t1090902582, ___holderPrefab_6)); }
	inline LobbyPlayerHolder_t712587207 * get_holderPrefab_6() const { return ___holderPrefab_6; }
	inline LobbyPlayerHolder_t712587207 ** get_address_of_holderPrefab_6() { return &___holderPrefab_6; }
	inline void set_holderPrefab_6(LobbyPlayerHolder_t712587207 * value)
	{
		___holderPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_6, value);
	}

	inline static int32_t get_offset_of_holderContainer_7() { return static_cast<int32_t>(offsetof(LobbyPlayerAdapter_t1090902582, ___holderContainer_7)); }
	inline Transform_t3275118058 * get_holderContainer_7() const { return ___holderContainer_7; }
	inline Transform_t3275118058 ** get_address_of_holderContainer_7() { return &___holderContainer_7; }
	inline void set_holderContainer_7(Transform_t3275118058 * value)
	{
		___holderContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___holderContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
