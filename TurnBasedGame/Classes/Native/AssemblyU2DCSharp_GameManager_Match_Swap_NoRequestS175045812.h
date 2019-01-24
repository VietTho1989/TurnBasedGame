#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3027391312.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameManager.Match.Swap.AdminRequestSwapPlayerUI
struct AdminRequestSwapPlayerUI_t2598849030;
// GameManager.Match.Swap.NormalRequestSwapPlayerUI
struct NormalRequestSwapPlayerUI_t2046564690;
// UnityEngine.Transform
struct Transform_t3275118058;
// RoomCheckChangeAdminChange`1<GameManager.Match.TeamPlayer>
struct RoomCheckChangeAdminChange_1_t3399795144;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.NoRequestSwapPlayerUI
struct  NoRequestSwapPlayerUI_t175045812  : public UIBehavior_1_t3027391312
{
public:
	// UnityEngine.GameObject GameManager.Match.Swap.NoRequestSwapPlayerUI::notAllowSwap
	GameObject_t1756533147 * ___notAllowSwap_6;
	// GameManager.Match.Swap.AdminRequestSwapPlayerUI GameManager.Match.Swap.NoRequestSwapPlayerUI::adminRequestSwapPlayerPrefab
	AdminRequestSwapPlayerUI_t2598849030 * ___adminRequestSwapPlayerPrefab_7;
	// GameManager.Match.Swap.NormalRequestSwapPlayerUI GameManager.Match.Swap.NoRequestSwapPlayerUI::normalRequestSwapPlayerPrefab
	NormalRequestSwapPlayerUI_t2046564690 * ___normalRequestSwapPlayerPrefab_8;
	// UnityEngine.Transform GameManager.Match.Swap.NoRequestSwapPlayerUI::subContainer
	Transform_t3275118058 * ___subContainer_9;
	// RoomCheckChangeAdminChange`1<GameManager.Match.TeamPlayer> GameManager.Match.Swap.NoRequestSwapPlayerUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t3399795144 * ___roomCheckAdminChange_10;
	// Room GameManager.Match.Swap.NoRequestSwapPlayerUI::room
	Room_t1042398373 * ___room_11;

public:
	inline static int32_t get_offset_of_notAllowSwap_6() { return static_cast<int32_t>(offsetof(NoRequestSwapPlayerUI_t175045812, ___notAllowSwap_6)); }
	inline GameObject_t1756533147 * get_notAllowSwap_6() const { return ___notAllowSwap_6; }
	inline GameObject_t1756533147 ** get_address_of_notAllowSwap_6() { return &___notAllowSwap_6; }
	inline void set_notAllowSwap_6(GameObject_t1756533147 * value)
	{
		___notAllowSwap_6 = value;
		Il2CppCodeGenWriteBarrier(&___notAllowSwap_6, value);
	}

	inline static int32_t get_offset_of_adminRequestSwapPlayerPrefab_7() { return static_cast<int32_t>(offsetof(NoRequestSwapPlayerUI_t175045812, ___adminRequestSwapPlayerPrefab_7)); }
	inline AdminRequestSwapPlayerUI_t2598849030 * get_adminRequestSwapPlayerPrefab_7() const { return ___adminRequestSwapPlayerPrefab_7; }
	inline AdminRequestSwapPlayerUI_t2598849030 ** get_address_of_adminRequestSwapPlayerPrefab_7() { return &___adminRequestSwapPlayerPrefab_7; }
	inline void set_adminRequestSwapPlayerPrefab_7(AdminRequestSwapPlayerUI_t2598849030 * value)
	{
		___adminRequestSwapPlayerPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___adminRequestSwapPlayerPrefab_7, value);
	}

	inline static int32_t get_offset_of_normalRequestSwapPlayerPrefab_8() { return static_cast<int32_t>(offsetof(NoRequestSwapPlayerUI_t175045812, ___normalRequestSwapPlayerPrefab_8)); }
	inline NormalRequestSwapPlayerUI_t2046564690 * get_normalRequestSwapPlayerPrefab_8() const { return ___normalRequestSwapPlayerPrefab_8; }
	inline NormalRequestSwapPlayerUI_t2046564690 ** get_address_of_normalRequestSwapPlayerPrefab_8() { return &___normalRequestSwapPlayerPrefab_8; }
	inline void set_normalRequestSwapPlayerPrefab_8(NormalRequestSwapPlayerUI_t2046564690 * value)
	{
		___normalRequestSwapPlayerPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___normalRequestSwapPlayerPrefab_8, value);
	}

	inline static int32_t get_offset_of_subContainer_9() { return static_cast<int32_t>(offsetof(NoRequestSwapPlayerUI_t175045812, ___subContainer_9)); }
	inline Transform_t3275118058 * get_subContainer_9() const { return ___subContainer_9; }
	inline Transform_t3275118058 ** get_address_of_subContainer_9() { return &___subContainer_9; }
	inline void set_subContainer_9(Transform_t3275118058 * value)
	{
		___subContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_9, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_10() { return static_cast<int32_t>(offsetof(NoRequestSwapPlayerUI_t175045812, ___roomCheckAdminChange_10)); }
	inline RoomCheckChangeAdminChange_1_t3399795144 * get_roomCheckAdminChange_10() const { return ___roomCheckAdminChange_10; }
	inline RoomCheckChangeAdminChange_1_t3399795144 ** get_address_of_roomCheckAdminChange_10() { return &___roomCheckAdminChange_10; }
	inline void set_roomCheckAdminChange_10(RoomCheckChangeAdminChange_1_t3399795144 * value)
	{
		___roomCheckAdminChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_10, value);
	}

	inline static int32_t get_offset_of_room_11() { return static_cast<int32_t>(offsetof(NoRequestSwapPlayerUI_t175045812, ___room_11)); }
	inline Room_t1042398373 * get_room_11() const { return ___room_11; }
	inline Room_t1042398373 ** get_address_of_room_11() { return &___room_11; }
	inline void set_room_11(Room_t1042398373 * value)
	{
		___room_11 = value;
		Il2CppCodeGenWriteBarrier(&___room_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
