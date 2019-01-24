#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_ChatMessage_Content2083754853.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// LP`1<ChatNormalContent/Message>
struct LP_1_t101796294;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatNormalContent
struct  ChatNormalContent_t1262347322  : public Content_t2083754853
{
public:
	// VP`1<System.UInt32> ChatNormalContent::owner
	VP_1_t2527959027 * ___owner_7;
	// LP`1<ChatNormalContent/Message> ChatNormalContent::messages
	LP_1_t101796294 * ___messages_8;
	// VP`1<System.Int32> ChatNormalContent::editMax
	VP_1_t2450154454 * ___editMax_9;

public:
	inline static int32_t get_offset_of_owner_7() { return static_cast<int32_t>(offsetof(ChatNormalContent_t1262347322, ___owner_7)); }
	inline VP_1_t2527959027 * get_owner_7() const { return ___owner_7; }
	inline VP_1_t2527959027 ** get_address_of_owner_7() { return &___owner_7; }
	inline void set_owner_7(VP_1_t2527959027 * value)
	{
		___owner_7 = value;
		Il2CppCodeGenWriteBarrier(&___owner_7, value);
	}

	inline static int32_t get_offset_of_messages_8() { return static_cast<int32_t>(offsetof(ChatNormalContent_t1262347322, ___messages_8)); }
	inline LP_1_t101796294 * get_messages_8() const { return ___messages_8; }
	inline LP_1_t101796294 ** get_address_of_messages_8() { return &___messages_8; }
	inline void set_messages_8(LP_1_t101796294 * value)
	{
		___messages_8 = value;
		Il2CppCodeGenWriteBarrier(&___messages_8, value);
	}

	inline static int32_t get_offset_of_editMax_9() { return static_cast<int32_t>(offsetof(ChatNormalContent_t1262347322, ___editMax_9)); }
	inline VP_1_t2450154454 * get_editMax_9() const { return ___editMax_9; }
	inline VP_1_t2450154454 ** get_address_of_editMax_9() { return &___editMax_9; }
	inline void set_editMax_9(VP_1_t2450154454 * value)
	{
		___editMax_9 = value;
		Il2CppCodeGenWriteBarrier(&___editMax_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
