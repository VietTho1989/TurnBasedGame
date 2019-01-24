#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1626887024.h"

// RoomAdapter
struct RoomAdapter_t2592187798;
// UnityEngine.Transform
struct Transform_t3275118058;
// CreateRoomUI
struct CreateRoomUI_t2106253281;
// JoinRoomUI
struct JoinRoomUI_t2332888483;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomListUI
struct  RoomListUI_t263987451  : public UIBehavior_1_t1626887024
{
public:
	// RoomAdapter RoomListUI::roomAdapterPrefab
	RoomAdapter_t2592187798 * ___roomAdapterPrefab_6;
	// UnityEngine.Transform RoomListUI::roomAdapterContainer
	Transform_t3275118058 * ___roomAdapterContainer_7;
	// UnityEngine.Transform RoomListUI::subContainer
	Transform_t3275118058 * ___subContainer_8;
	// CreateRoomUI RoomListUI::createRoomPrefab
	CreateRoomUI_t2106253281 * ___createRoomPrefab_9;
	// JoinRoomUI RoomListUI::joinRoomPrefab
	JoinRoomUI_t2332888483 * ___joinRoomPrefab_10;

public:
	inline static int32_t get_offset_of_roomAdapterPrefab_6() { return static_cast<int32_t>(offsetof(RoomListUI_t263987451, ___roomAdapterPrefab_6)); }
	inline RoomAdapter_t2592187798 * get_roomAdapterPrefab_6() const { return ___roomAdapterPrefab_6; }
	inline RoomAdapter_t2592187798 ** get_address_of_roomAdapterPrefab_6() { return &___roomAdapterPrefab_6; }
	inline void set_roomAdapterPrefab_6(RoomAdapter_t2592187798 * value)
	{
		___roomAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___roomAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_roomAdapterContainer_7() { return static_cast<int32_t>(offsetof(RoomListUI_t263987451, ___roomAdapterContainer_7)); }
	inline Transform_t3275118058 * get_roomAdapterContainer_7() const { return ___roomAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_roomAdapterContainer_7() { return &___roomAdapterContainer_7; }
	inline void set_roomAdapterContainer_7(Transform_t3275118058 * value)
	{
		___roomAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___roomAdapterContainer_7, value);
	}

	inline static int32_t get_offset_of_subContainer_8() { return static_cast<int32_t>(offsetof(RoomListUI_t263987451, ___subContainer_8)); }
	inline Transform_t3275118058 * get_subContainer_8() const { return ___subContainer_8; }
	inline Transform_t3275118058 ** get_address_of_subContainer_8() { return &___subContainer_8; }
	inline void set_subContainer_8(Transform_t3275118058 * value)
	{
		___subContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_8, value);
	}

	inline static int32_t get_offset_of_createRoomPrefab_9() { return static_cast<int32_t>(offsetof(RoomListUI_t263987451, ___createRoomPrefab_9)); }
	inline CreateRoomUI_t2106253281 * get_createRoomPrefab_9() const { return ___createRoomPrefab_9; }
	inline CreateRoomUI_t2106253281 ** get_address_of_createRoomPrefab_9() { return &___createRoomPrefab_9; }
	inline void set_createRoomPrefab_9(CreateRoomUI_t2106253281 * value)
	{
		___createRoomPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___createRoomPrefab_9, value);
	}

	inline static int32_t get_offset_of_joinRoomPrefab_10() { return static_cast<int32_t>(offsetof(RoomListUI_t263987451, ___joinRoomPrefab_10)); }
	inline JoinRoomUI_t2332888483 * get_joinRoomPrefab_10() const { return ___joinRoomPrefab_10; }
	inline JoinRoomUI_t2332888483 ** get_address_of_joinRoomPrefab_10() { return &___joinRoomPrefab_10; }
	inline void set_joinRoomPrefab_10(JoinRoomUI_t2332888483 * value)
	{
		___joinRoomPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___joinRoomPrefab_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
