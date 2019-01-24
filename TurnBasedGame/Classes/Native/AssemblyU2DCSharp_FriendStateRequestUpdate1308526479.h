#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen4125649771.h"

// Friend
struct Friend_t3555014108;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateRequestUpdate
struct  FriendStateRequestUpdate_t1308526479  : public UpdateBehavior_1_t4125649771
{
public:
	// Friend FriendStateRequestUpdate::friend
	Friend_t3555014108 * ___friend_4;

public:
	inline static int32_t get_offset_of_friend_4() { return static_cast<int32_t>(offsetof(FriendStateRequestUpdate_t1308526479, ___friend_4)); }
	inline Friend_t3555014108 * get_friend_4() const { return ___friend_4; }
	inline Friend_t3555014108 ** get_address_of_friend_4() { return &___friend_4; }
	inline void set_friend_4(Friend_t3555014108 * value)
	{
		___friend_4 = value;
		Il2CppCodeGenWriteBarrier(&___friend_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
