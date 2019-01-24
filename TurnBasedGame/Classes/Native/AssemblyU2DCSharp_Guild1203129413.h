#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.String>
struct VP_1_t2407497239;
// LP`1<GuildUser>
struct LP_1_t3336928744;
// VP`1<ChatRoom>
struct VP_1_t38054233;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Guild
struct  Guild_t1203129413  : public Data_t3569509720
{
public:
	// VP`1<System.String> Guild::guildName
	VP_1_t2407497239 * ___guildName_5;
	// LP`1<GuildUser> Guild::users
	LP_1_t3336928744 * ___users_6;
	// VP`1<ChatRoom> Guild::chatRoom
	VP_1_t38054233 * ___chatRoom_7;

public:
	inline static int32_t get_offset_of_guildName_5() { return static_cast<int32_t>(offsetof(Guild_t1203129413, ___guildName_5)); }
	inline VP_1_t2407497239 * get_guildName_5() const { return ___guildName_5; }
	inline VP_1_t2407497239 ** get_address_of_guildName_5() { return &___guildName_5; }
	inline void set_guildName_5(VP_1_t2407497239 * value)
	{
		___guildName_5 = value;
		Il2CppCodeGenWriteBarrier(&___guildName_5, value);
	}

	inline static int32_t get_offset_of_users_6() { return static_cast<int32_t>(offsetof(Guild_t1203129413, ___users_6)); }
	inline LP_1_t3336928744 * get_users_6() const { return ___users_6; }
	inline LP_1_t3336928744 ** get_address_of_users_6() { return &___users_6; }
	inline void set_users_6(LP_1_t3336928744 * value)
	{
		___users_6 = value;
		Il2CppCodeGenWriteBarrier(&___users_6, value);
	}

	inline static int32_t get_offset_of_chatRoom_7() { return static_cast<int32_t>(offsetof(Guild_t1203129413, ___chatRoom_7)); }
	inline VP_1_t38054233 * get_chatRoom_7() const { return ___chatRoom_7; }
	inline VP_1_t38054233 ** get_address_of_chatRoom_7() { return &___chatRoom_7; }
	inline void set_chatRoom_7(VP_1_t38054233 * value)
	{
		___chatRoom_7 = value;
		Il2CppCodeGenWriteBarrier(&___chatRoom_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
