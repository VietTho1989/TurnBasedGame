#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1805715313.h"

// ChatMessageHolder
struct ChatMessageHolder_t3555852635;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatRoomAdapter
struct  ChatRoomAdapter_t554468504  : public SRIA_2_t1805715313
{
public:
	// ChatMessageHolder ChatRoomAdapter::holderPrefab
	ChatMessageHolder_t3555852635 * ___holderPrefab_24;
	// UnityEngine.GameObject ChatRoomAdapter::noMessages
	GameObject_t1756533147 * ___noMessages_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChatRoomAdapter_t554468504, ___holderPrefab_24)); }
	inline ChatMessageHolder_t3555852635 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChatMessageHolder_t3555852635 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChatMessageHolder_t3555852635 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noMessages_25() { return static_cast<int32_t>(offsetof(ChatRoomAdapter_t554468504, ___noMessages_25)); }
	inline GameObject_t1756533147 * get_noMessages_25() const { return ___noMessages_25; }
	inline GameObject_t1756533147 ** get_address_of_noMessages_25() { return &___noMessages_25; }
	inline void set_noMessages_25(GameObject_t1756533147 * value)
	{
		___noMessages_25 = value;
		Il2CppCodeGenWriteBarrier(&___noMessages_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
