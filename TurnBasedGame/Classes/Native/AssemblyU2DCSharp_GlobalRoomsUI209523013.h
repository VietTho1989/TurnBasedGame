#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3114717418.h"

// RoomListUI
struct RoomListUI_t263987451;
// RoomUI
struct RoomUI_t2790612669;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalRoomsUI
struct  GlobalRoomsUI_t209523013  : public UIBehavior_1_t3114717418
{
public:
	// RoomListUI GlobalRoomsUI::roomListPrefab
	RoomListUI_t263987451 * ___roomListPrefab_6;
	// RoomUI GlobalRoomsUI::roomUIPrefab
	RoomUI_t2790612669 * ___roomUIPrefab_7;

public:
	inline static int32_t get_offset_of_roomListPrefab_6() { return static_cast<int32_t>(offsetof(GlobalRoomsUI_t209523013, ___roomListPrefab_6)); }
	inline RoomListUI_t263987451 * get_roomListPrefab_6() const { return ___roomListPrefab_6; }
	inline RoomListUI_t263987451 ** get_address_of_roomListPrefab_6() { return &___roomListPrefab_6; }
	inline void set_roomListPrefab_6(RoomListUI_t263987451 * value)
	{
		___roomListPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___roomListPrefab_6, value);
	}

	inline static int32_t get_offset_of_roomUIPrefab_7() { return static_cast<int32_t>(offsetof(GlobalRoomsUI_t209523013, ___roomUIPrefab_7)); }
	inline RoomUI_t2790612669 * get_roomUIPrefab_7() const { return ___roomUIPrefab_7; }
	inline RoomUI_t2790612669 ** get_address_of_roomUIPrefab_7() { return &___roomUIPrefab_7; }
	inline void set_roomUIPrefab_7(RoomUI_t2790612669 * value)
	{
		___roomUIPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___roomUIPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
