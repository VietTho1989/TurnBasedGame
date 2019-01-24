#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<ChatMessage>>
struct VP_1_t1833288756;
// VP`1<ChatMessageHolder/UIData/Sub>
struct VP_1_t565053801;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatMessageHolder/UIData
struct  UIData_t2137172342  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<ChatMessage>> ChatMessageHolder/UIData::chatMessage
	VP_1_t1833288756 * ___chatMessage_8;
	// VP`1<ChatMessageHolder/UIData/Sub> ChatMessageHolder/UIData::sub
	VP_1_t565053801 * ___sub_9;

public:
	inline static int32_t get_offset_of_chatMessage_8() { return static_cast<int32_t>(offsetof(UIData_t2137172342, ___chatMessage_8)); }
	inline VP_1_t1833288756 * get_chatMessage_8() const { return ___chatMessage_8; }
	inline VP_1_t1833288756 ** get_address_of_chatMessage_8() { return &___chatMessage_8; }
	inline void set_chatMessage_8(VP_1_t1833288756 * value)
	{
		___chatMessage_8 = value;
		Il2CppCodeGenWriteBarrier(&___chatMessage_8, value);
	}

	inline static int32_t get_offset_of_sub_9() { return static_cast<int32_t>(offsetof(UIData_t2137172342, ___sub_9)); }
	inline VP_1_t565053801 * get_sub_9() const { return ___sub_9; }
	inline VP_1_t565053801 ** get_address_of_sub_9() { return &___sub_9; }
	inline void set_sub_9(VP_1_t565053801 * value)
	{
		___sub_9 = value;
		Il2CppCodeGenWriteBarrier(&___sub_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
