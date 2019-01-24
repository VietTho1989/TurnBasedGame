#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<ChatRoomUI/UIData>
struct VP_1_t1240506260;
// LP`1<BtnChooseChatUI/UIData>
struct LP_1_t4146902676;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalChatUI/UIData
struct  UIData_t3777883418  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Server>> GlobalChatUI/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<ChatRoomUI/UIData> GlobalChatUI/UIData::chatRoomUIData
	VP_1_t1240506260 * ___chatRoomUIData_6;
	// LP`1<BtnChooseChatUI/UIData> GlobalChatUI/UIData::btnChooseChatUIDatas
	LP_1_t4146902676 * ___btnChooseChatUIDatas_7;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t3777883418, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_chatRoomUIData_6() { return static_cast<int32_t>(offsetof(UIData_t3777883418, ___chatRoomUIData_6)); }
	inline VP_1_t1240506260 * get_chatRoomUIData_6() const { return ___chatRoomUIData_6; }
	inline VP_1_t1240506260 ** get_address_of_chatRoomUIData_6() { return &___chatRoomUIData_6; }
	inline void set_chatRoomUIData_6(VP_1_t1240506260 * value)
	{
		___chatRoomUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoomUIData_6, value);
	}

	inline static int32_t get_offset_of_btnChooseChatUIDatas_7() { return static_cast<int32_t>(offsetof(UIData_t3777883418, ___btnChooseChatUIDatas_7)); }
	inline LP_1_t4146902676 * get_btnChooseChatUIDatas_7() const { return ___btnChooseChatUIDatas_7; }
	inline LP_1_t4146902676 ** get_address_of_btnChooseChatUIDatas_7() { return &___btnChooseChatUIDatas_7; }
	inline void set_btnChooseChatUIDatas_7(LP_1_t4146902676 * value)
	{
		___btnChooseChatUIDatas_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnChooseChatUIDatas_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
