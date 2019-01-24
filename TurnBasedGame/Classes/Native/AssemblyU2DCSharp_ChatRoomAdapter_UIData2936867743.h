#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<ChatRoom>>
struct VP_1_t3403804592;
// LP`1<ChatMessageHolder/UIData>
struct LP_1_t874916298;
// System.Collections.Generic.List`1<ChatMessage>
struct List_1_t1753349819;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatRoomAdapter/UIData
struct  UIData_t2936867743  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<ChatRoom>> ChatRoomAdapter/UIData::chatRoom
	VP_1_t3403804592 * ___chatRoom_20;
	// LP`1<ChatMessageHolder/UIData> ChatRoomAdapter/UIData::holders
	LP_1_t874916298 * ___holders_21;
	// System.Collections.Generic.List`1<ChatMessage> ChatRoomAdapter/UIData::chatMessages
	List_1_t1753349819 * ___chatMessages_22;

public:
	inline static int32_t get_offset_of_chatRoom_20() { return static_cast<int32_t>(offsetof(UIData_t2936867743, ___chatRoom_20)); }
	inline VP_1_t3403804592 * get_chatRoom_20() const { return ___chatRoom_20; }
	inline VP_1_t3403804592 ** get_address_of_chatRoom_20() { return &___chatRoom_20; }
	inline void set_chatRoom_20(VP_1_t3403804592 * value)
	{
		___chatRoom_20 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoom_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t2936867743, ___holders_21)); }
	inline LP_1_t874916298 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t874916298 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t874916298 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_chatMessages_22() { return static_cast<int32_t>(offsetof(UIData_t2936867743, ___chatMessages_22)); }
	inline List_1_t1753349819 * get_chatMessages_22() const { return ___chatMessages_22; }
	inline List_1_t1753349819 ** get_address_of_chatMessages_22() { return &___chatMessages_22; }
	inline void set_chatMessages_22(List_1_t1753349819 * value)
	{
		___chatMessages_22 = value;
		Il2CppCodeGenWriteBarrier(&___chatMessages_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
