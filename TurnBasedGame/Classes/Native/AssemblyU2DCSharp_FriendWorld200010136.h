#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<Friend>
struct LP_1_t2292758064;
// FriendHashMap
struct FriendHashMap_t2993852226;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendWorld
struct  FriendWorld_t200010136  : public Data_t3569509720
{
public:
	// LP`1<Friend> FriendWorld::friends
	LP_1_t2292758064 * ___friends_5;
	// FriendHashMap FriendWorld::friendHashMap
	FriendHashMap_t2993852226 * ___friendHashMap_6;

public:
	inline static int32_t get_offset_of_friends_5() { return static_cast<int32_t>(offsetof(FriendWorld_t200010136, ___friends_5)); }
	inline LP_1_t2292758064 * get_friends_5() const { return ___friends_5; }
	inline LP_1_t2292758064 ** get_address_of_friends_5() { return &___friends_5; }
	inline void set_friends_5(LP_1_t2292758064 * value)
	{
		___friends_5 = value;
		Il2CppCodeGenWriteBarrier(&___friends_5, value);
	}

	inline static int32_t get_offset_of_friendHashMap_6() { return static_cast<int32_t>(offsetof(FriendWorld_t200010136, ___friendHashMap_6)); }
	inline FriendHashMap_t2993852226 * get_friendHashMap_6() const { return ___friendHashMap_6; }
	inline FriendHashMap_t2993852226 ** get_address_of_friendHashMap_6() { return &___friendHashMap_6; }
	inline void set_friendHashMap_6(FriendHashMap_t2993852226 * value)
	{
		___friendHashMap_6 = value;
		Il2CppCodeGenWriteBarrier(&___friendHashMap_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
