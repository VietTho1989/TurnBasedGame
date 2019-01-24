#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatRoomUITest
struct  ChatRoomUITest_t3258803681  : public MonoBehaviour_t1158329972
{
public:
	// AdvancedCoroutines.Routine ChatRoomUITest::checkSendMessage
	Routine_t2502590640 * ___checkSendMessage_2;

public:
	inline static int32_t get_offset_of_checkSendMessage_2() { return static_cast<int32_t>(offsetof(ChatRoomUITest_t3258803681, ___checkSendMessage_2)); }
	inline Routine_t2502590640 * get_checkSendMessage_2() const { return ___checkSendMessage_2; }
	inline Routine_t2502590640 ** get_address_of_checkSendMessage_2() { return &___checkSendMessage_2; }
	inline void set_checkSendMessage_2(Routine_t2502590640 * value)
	{
		___checkSendMessage_2 = value;
		Il2CppCodeGenWriteBarrier(&___checkSendMessage_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
