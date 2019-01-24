#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameType/Type>
struct VP_1_t2728349165;
// VP`1<System.String>
struct VP_1_t2407497239;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CreateRoom
struct  CreateRoom_t1281961257  : public Data_t3569509720
{
public:
	// VP`1<GameType/Type> CreateRoom::gameType
	VP_1_t2728349165 * ___gameType_5;
	// VP`1<System.String> CreateRoom::roomName
	VP_1_t2407497239 * ___roomName_6;
	// VP`1<System.String> CreateRoom::password
	VP_1_t2407497239 * ___password_7;

public:
	inline static int32_t get_offset_of_gameType_5() { return static_cast<int32_t>(offsetof(CreateRoom_t1281961257, ___gameType_5)); }
	inline VP_1_t2728349165 * get_gameType_5() const { return ___gameType_5; }
	inline VP_1_t2728349165 ** get_address_of_gameType_5() { return &___gameType_5; }
	inline void set_gameType_5(VP_1_t2728349165 * value)
	{
		___gameType_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameType_5, value);
	}

	inline static int32_t get_offset_of_roomName_6() { return static_cast<int32_t>(offsetof(CreateRoom_t1281961257, ___roomName_6)); }
	inline VP_1_t2407497239 * get_roomName_6() const { return ___roomName_6; }
	inline VP_1_t2407497239 ** get_address_of_roomName_6() { return &___roomName_6; }
	inline void set_roomName_6(VP_1_t2407497239 * value)
	{
		___roomName_6 = value;
		Il2CppCodeGenWriteBarrier(&___roomName_6, value);
	}

	inline static int32_t get_offset_of_password_7() { return static_cast<int32_t>(offsetof(CreateRoom_t1281961257, ___password_7)); }
	inline VP_1_t2407497239 * get_password_7() const { return ___password_7; }
	inline VP_1_t2407497239 ** get_address_of_password_7() { return &___password_7; }
	inline void set_password_7(VP_1_t2407497239 * value)
	{
		___password_7 = value;
		Il2CppCodeGenWriteBarrier(&___password_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
