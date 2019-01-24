#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Networking.NetworkIdentity
struct NetworkIdentity_t1766639790;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.PlayerController
struct  PlayerController_t612925521  : public Il2CppObject
{
public:
	// System.Int16 UnityEngine.Networking.PlayerController::playerControllerId
	int16_t ___playerControllerId_1;
	// UnityEngine.Networking.NetworkIdentity UnityEngine.Networking.PlayerController::unetView
	NetworkIdentity_t1766639790 * ___unetView_2;
	// UnityEngine.GameObject UnityEngine.Networking.PlayerController::gameObject
	GameObject_t1756533147 * ___gameObject_3;

public:
	inline static int32_t get_offset_of_playerControllerId_1() { return static_cast<int32_t>(offsetof(PlayerController_t612925521, ___playerControllerId_1)); }
	inline int16_t get_playerControllerId_1() const { return ___playerControllerId_1; }
	inline int16_t* get_address_of_playerControllerId_1() { return &___playerControllerId_1; }
	inline void set_playerControllerId_1(int16_t value)
	{
		___playerControllerId_1 = value;
	}

	inline static int32_t get_offset_of_unetView_2() { return static_cast<int32_t>(offsetof(PlayerController_t612925521, ___unetView_2)); }
	inline NetworkIdentity_t1766639790 * get_unetView_2() const { return ___unetView_2; }
	inline NetworkIdentity_t1766639790 ** get_address_of_unetView_2() { return &___unetView_2; }
	inline void set_unetView_2(NetworkIdentity_t1766639790 * value)
	{
		___unetView_2 = value;
		Il2CppCodeGenWriteBarrier(&___unetView_2, value);
	}

	inline static int32_t get_offset_of_gameObject_3() { return static_cast<int32_t>(offsetof(PlayerController_t612925521, ___gameObject_3)); }
	inline GameObject_t1756533147 * get_gameObject_3() const { return ___gameObject_3; }
	inline GameObject_t1756533147 ** get_address_of_gameObject_3() { return &___gameObject_3; }
	inline void set_gameObject_3(GameObject_t1756533147 * value)
	{
		___gameObject_3 = value;
		Il2CppCodeGenWriteBarrier(&___gameObject_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
