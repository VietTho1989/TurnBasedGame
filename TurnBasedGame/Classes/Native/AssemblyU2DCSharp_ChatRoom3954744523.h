#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Topic>
struct VP_1_t3933874121;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// LP`1<Human>
struct LP_1_t4188799745;
// LP`1<ChatMessage>
struct LP_1_t1121972643;
// VP`1<Typing>
struct VP_1_t4055561217;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatRoom
struct  ChatRoom_t3954744523  : public Data_t3569509720
{
public:
	// VP`1<Topic> ChatRoom::topic
	VP_1_t3933874121 * ___topic_5;
	// VP`1<System.Boolean> ChatRoom::isEnable
	VP_1_t4203851724 * ___isEnable_6;
	// LP`1<Human> ChatRoom::players
	LP_1_t4188799745 * ___players_7;
	// LP`1<ChatMessage> ChatRoom::messages
	LP_1_t1121972643 * ___messages_8;
	// VP`1<Typing> ChatRoom::typing
	VP_1_t4055561217 * ___typing_9;

public:
	inline static int32_t get_offset_of_topic_5() { return static_cast<int32_t>(offsetof(ChatRoom_t3954744523, ___topic_5)); }
	inline VP_1_t3933874121 * get_topic_5() const { return ___topic_5; }
	inline VP_1_t3933874121 ** get_address_of_topic_5() { return &___topic_5; }
	inline void set_topic_5(VP_1_t3933874121 * value)
	{
		___topic_5 = value;
		Il2CppCodeGenWriteBarrier(&___topic_5, value);
	}

	inline static int32_t get_offset_of_isEnable_6() { return static_cast<int32_t>(offsetof(ChatRoom_t3954744523, ___isEnable_6)); }
	inline VP_1_t4203851724 * get_isEnable_6() const { return ___isEnable_6; }
	inline VP_1_t4203851724 ** get_address_of_isEnable_6() { return &___isEnable_6; }
	inline void set_isEnable_6(VP_1_t4203851724 * value)
	{
		___isEnable_6 = value;
		Il2CppCodeGenWriteBarrier(&___isEnable_6, value);
	}

	inline static int32_t get_offset_of_players_7() { return static_cast<int32_t>(offsetof(ChatRoom_t3954744523, ___players_7)); }
	inline LP_1_t4188799745 * get_players_7() const { return ___players_7; }
	inline LP_1_t4188799745 ** get_address_of_players_7() { return &___players_7; }
	inline void set_players_7(LP_1_t4188799745 * value)
	{
		___players_7 = value;
		Il2CppCodeGenWriteBarrier(&___players_7, value);
	}

	inline static int32_t get_offset_of_messages_8() { return static_cast<int32_t>(offsetof(ChatRoom_t3954744523, ___messages_8)); }
	inline LP_1_t1121972643 * get_messages_8() const { return ___messages_8; }
	inline LP_1_t1121972643 ** get_address_of_messages_8() { return &___messages_8; }
	inline void set_messages_8(LP_1_t1121972643 * value)
	{
		___messages_8 = value;
		Il2CppCodeGenWriteBarrier(&___messages_8, value);
	}

	inline static int32_t get_offset_of_typing_9() { return static_cast<int32_t>(offsetof(ChatRoom_t3954744523, ___typing_9)); }
	inline VP_1_t4055561217 * get_typing_9() const { return ___typing_9; }
	inline VP_1_t4055561217 ** get_address_of_typing_9() { return &___typing_9; }
	inline void set_typing_9(VP_1_t4055561217 * value)
	{
		___typing_9 = value;
		Il2CppCodeGenWriteBarrier(&___typing_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
