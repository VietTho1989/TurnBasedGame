#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_ChatRoomDisplayUI_UIData_Sub1807388605.h"

// VP`1<ReferenceData`1<ChatMessage>>
struct VP_1_t1833288756;
// VP`1<ChatMessageMenuUI/UIData/Sub>
struct VP_1_t384438464;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatMessageMenuUI/UIData
struct  UIData_t3880142435  : public Sub_t1807388605
{
public:
	// VP`1<ReferenceData`1<ChatMessage>> ChatMessageMenuUI/UIData::chatMessage
	VP_1_t1833288756 * ___chatMessage_5;
	// VP`1<ChatMessageMenuUI/UIData/Sub> ChatMessageMenuUI/UIData::sub
	VP_1_t384438464 * ___sub_6;

public:
	inline static int32_t get_offset_of_chatMessage_5() { return static_cast<int32_t>(offsetof(UIData_t3880142435, ___chatMessage_5)); }
	inline VP_1_t1833288756 * get_chatMessage_5() const { return ___chatMessage_5; }
	inline VP_1_t1833288756 ** get_address_of_chatMessage_5() { return &___chatMessage_5; }
	inline void set_chatMessage_5(VP_1_t1833288756 * value)
	{
		___chatMessage_5 = value;
		Il2CppCodeGenWriteBarrier(&___chatMessage_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t3880142435, ___sub_6)); }
	inline VP_1_t384438464 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t384438464 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t384438464 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
