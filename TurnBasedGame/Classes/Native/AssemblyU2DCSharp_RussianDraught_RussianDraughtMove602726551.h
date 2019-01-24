#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<RussianDraught.RussianDraughtMoveAnimation>
struct NetData_1_t1064190438;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtMoveAnimationIdentity
struct  RussianDraughtMoveAnimationIdentity_t602726551  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt RussianDraught.RussianDraughtMoveAnimationIdentity::Board
	SyncListInt_t3316705628 * ___Board_17;
	// NetData`1<RussianDraught.RussianDraughtMoveAnimation> RussianDraught.RussianDraughtMoveAnimationIdentity::netData
	NetData_1_t1064190438 * ___netData_18;

public:
	inline static int32_t get_offset_of_Board_17() { return static_cast<int32_t>(offsetof(RussianDraughtMoveAnimationIdentity_t602726551, ___Board_17)); }
	inline SyncListInt_t3316705628 * get_Board_17() const { return ___Board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_Board_17() { return &___Board_17; }
	inline void set_Board_17(SyncListInt_t3316705628 * value)
	{
		___Board_17 = value;
		Il2CppCodeGenWriteBarrier(&___Board_17, value);
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(RussianDraughtMoveAnimationIdentity_t602726551, ___netData_18)); }
	inline NetData_1_t1064190438 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1064190438 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1064190438 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

struct RussianDraughtMoveAnimationIdentity_t602726551_StaticFields
{
public:
	// System.Int32 RussianDraught.RussianDraughtMoveAnimationIdentity::kListBoard
	int32_t ___kListBoard_19;

public:
	inline static int32_t get_offset_of_kListBoard_19() { return static_cast<int32_t>(offsetof(RussianDraughtMoveAnimationIdentity_t602726551_StaticFields, ___kListBoard_19)); }
	inline int32_t get_kListBoard_19() const { return ___kListBoard_19; }
	inline int32_t* get_address_of_kListBoard_19() { return &___kListBoard_19; }
	inline void set_kListBoard_19(int32_t value)
	{
		___kListBoard_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
