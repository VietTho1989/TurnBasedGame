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
// VP`1<FriendStateChangeContent/Action>
struct VP_1_t2858989103;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateChangeContent
struct  FriendStateChangeContent_t4189388890  : public Content_t2083754853
{
public:
	// VP`1<System.UInt32> FriendStateChangeContent::userId
	VP_1_t2527959027 * ___userId_5;
	// VP`1<FriendStateChangeContent/Action> FriendStateChangeContent::action
	VP_1_t2858989103 * ___action_6;

public:
	inline static int32_t get_offset_of_userId_5() { return static_cast<int32_t>(offsetof(FriendStateChangeContent_t4189388890, ___userId_5)); }
	inline VP_1_t2527959027 * get_userId_5() const { return ___userId_5; }
	inline VP_1_t2527959027 ** get_address_of_userId_5() { return &___userId_5; }
	inline void set_userId_5(VP_1_t2527959027 * value)
	{
		___userId_5 = value;
		Il2CppCodeGenWriteBarrier(&___userId_5, value);
	}

	inline static int32_t get_offset_of_action_6() { return static_cast<int32_t>(offsetof(FriendStateChangeContent_t4189388890, ___action_6)); }
	inline VP_1_t2858989103 * get_action_6() const { return ___action_6; }
	inline VP_1_t2858989103 ** get_address_of_action_6() { return &___action_6; }
	inline void set_action_6(VP_1_t2858989103 * value)
	{
		___action_6 = value;
		Il2CppCodeGenWriteBarrier(&___action_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
