#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<ChatRoom>>
struct VP_1_t3403804592;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// NewChatMessageNumberUI/UIData
struct  UIData_t574046051  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<ChatRoom>> NewChatMessageNumberUI/UIData::chatRoom
	VP_1_t3403804592 * ___chatRoom_5;
	// VP`1<RequestChangeStringUI/UIData> NewChatMessageNumberUI/UIData::newCount
	VP_1_t1525575381 * ___newCount_6;

public:
	inline static int32_t get_offset_of_chatRoom_5() { return static_cast<int32_t>(offsetof(UIData_t574046051, ___chatRoom_5)); }
	inline VP_1_t3403804592 * get_chatRoom_5() const { return ___chatRoom_5; }
	inline VP_1_t3403804592 ** get_address_of_chatRoom_5() { return &___chatRoom_5; }
	inline void set_chatRoom_5(VP_1_t3403804592 * value)
	{
		___chatRoom_5 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoom_5, value);
	}

	inline static int32_t get_offset_of_newCount_6() { return static_cast<int32_t>(offsetof(UIData_t574046051, ___newCount_6)); }
	inline VP_1_t1525575381 * get_newCount_6() const { return ___newCount_6; }
	inline VP_1_t1525575381 ** get_address_of_newCount_6() { return &___newCount_6; }
	inline void set_newCount_6(VP_1_t1525575381 * value)
	{
		___newCount_6 = value;
		Il2CppCodeGenWriteBarrier(&___newCount_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
