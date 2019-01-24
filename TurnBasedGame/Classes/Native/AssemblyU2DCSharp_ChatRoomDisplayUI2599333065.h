#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1327988146.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// ChatMessageMenuUI
struct ChatMessageMenuUI_t4195701444;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatRoomDisplayUI
struct  ChatRoomDisplayUI_t2599333065  : public UIBehavior_1_t1327988146
{
public:
	// UnityEngine.Transform ChatRoomDisplayUI::content
	Transform_t3275118058 * ___content_6;
	// ChatMessageMenuUI ChatRoomDisplayUI::chatMessageMenuPrefab
	ChatMessageMenuUI_t4195701444 * ___chatMessageMenuPrefab_7;

public:
	inline static int32_t get_offset_of_content_6() { return static_cast<int32_t>(offsetof(ChatRoomDisplayUI_t2599333065, ___content_6)); }
	inline Transform_t3275118058 * get_content_6() const { return ___content_6; }
	inline Transform_t3275118058 ** get_address_of_content_6() { return &___content_6; }
	inline void set_content_6(Transform_t3275118058 * value)
	{
		___content_6 = value;
		Il2CppCodeGenWriteBarrier(&___content_6, value);
	}

	inline static int32_t get_offset_of_chatMessageMenuPrefab_7() { return static_cast<int32_t>(offsetof(ChatRoomDisplayUI_t2599333065, ___chatMessageMenuPrefab_7)); }
	inline ChatMessageMenuUI_t4195701444 * get_chatMessageMenuPrefab_7() const { return ___chatMessageMenuPrefab_7; }
	inline ChatMessageMenuUI_t4195701444 ** get_address_of_chatMessageMenuPrefab_7() { return &___chatMessageMenuPrefab_7; }
	inline void set_chatMessageMenuPrefab_7(ChatMessageMenuUI_t4195701444 * value)
	{
		___chatMessageMenuPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___chatMessageMenuPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
