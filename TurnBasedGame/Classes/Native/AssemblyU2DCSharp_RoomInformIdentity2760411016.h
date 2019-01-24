#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_GameManager_Match_ContestManager2798645038.h"
#include "AssemblyU2DCSharp_GameType_Type2350072159.h"

// NetData`1<RoomInform>
struct NetData_1_t58450995;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomInformIdentity
struct  RoomInformIdentity_t2760411016  : public DataIdentity_t543951486
{
public:
	// System.UInt32 RoomInformIdentity::userCount
	uint32_t ___userCount_17;
	// System.Boolean RoomInformIdentity::isHavePassword
	bool ___isHavePassword_18;
	// GameManager.Match.ContestManager/State/Type RoomInformIdentity::contestStateType
	int32_t ___contestStateType_19;
	// GameType/Type RoomInformIdentity::gameType
	int32_t ___gameType_20;
	// NetData`1<RoomInform> RoomInformIdentity::netData
	NetData_1_t58450995 * ___netData_21;

public:
	inline static int32_t get_offset_of_userCount_17() { return static_cast<int32_t>(offsetof(RoomInformIdentity_t2760411016, ___userCount_17)); }
	inline uint32_t get_userCount_17() const { return ___userCount_17; }
	inline uint32_t* get_address_of_userCount_17() { return &___userCount_17; }
	inline void set_userCount_17(uint32_t value)
	{
		___userCount_17 = value;
	}

	inline static int32_t get_offset_of_isHavePassword_18() { return static_cast<int32_t>(offsetof(RoomInformIdentity_t2760411016, ___isHavePassword_18)); }
	inline bool get_isHavePassword_18() const { return ___isHavePassword_18; }
	inline bool* get_address_of_isHavePassword_18() { return &___isHavePassword_18; }
	inline void set_isHavePassword_18(bool value)
	{
		___isHavePassword_18 = value;
	}

	inline static int32_t get_offset_of_contestStateType_19() { return static_cast<int32_t>(offsetof(RoomInformIdentity_t2760411016, ___contestStateType_19)); }
	inline int32_t get_contestStateType_19() const { return ___contestStateType_19; }
	inline int32_t* get_address_of_contestStateType_19() { return &___contestStateType_19; }
	inline void set_contestStateType_19(int32_t value)
	{
		___contestStateType_19 = value;
	}

	inline static int32_t get_offset_of_gameType_20() { return static_cast<int32_t>(offsetof(RoomInformIdentity_t2760411016, ___gameType_20)); }
	inline int32_t get_gameType_20() const { return ___gameType_20; }
	inline int32_t* get_address_of_gameType_20() { return &___gameType_20; }
	inline void set_gameType_20(int32_t value)
	{
		___gameType_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(RoomInformIdentity_t2760411016, ___netData_21)); }
	inline NetData_1_t58450995 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t58450995 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t58450995 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
