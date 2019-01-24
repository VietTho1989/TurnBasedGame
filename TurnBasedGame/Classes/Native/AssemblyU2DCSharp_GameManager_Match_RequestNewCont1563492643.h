#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3030807383.h"

// GameManager.Match.CheckCanMakeNewContestManagerChange`1<GameManager.Match.RequestNewContestManagerStateAsk>
struct CheckCanMakeNewContestManagerChange_1_t191952535;
// RoomCheckChangeAdminChange`1<GameManager.Match.RequestNewContestManagerStateAsk>
struct RoomCheckChangeAdminChange_1_t1705137404;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewContestManagerStateAskUpdate
struct  RequestNewContestManagerStateAskUpdate_t1563492643  : public UpdateBehavior_1_t3030807383
{
public:
	// GameManager.Match.CheckCanMakeNewContestManagerChange`1<GameManager.Match.RequestNewContestManagerStateAsk> GameManager.Match.RequestNewContestManagerStateAskUpdate::checkCanMakeNewContestManagerChange
	CheckCanMakeNewContestManagerChange_1_t191952535 * ___checkCanMakeNewContestManagerChange_4;
	// RoomCheckChangeAdminChange`1<GameManager.Match.RequestNewContestManagerStateAsk> GameManager.Match.RequestNewContestManagerStateAskUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t1705137404 * ___roomCheckAdminChange_5;

public:
	inline static int32_t get_offset_of_checkCanMakeNewContestManagerChange_4() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUpdate_t1563492643, ___checkCanMakeNewContestManagerChange_4)); }
	inline CheckCanMakeNewContestManagerChange_1_t191952535 * get_checkCanMakeNewContestManagerChange_4() const { return ___checkCanMakeNewContestManagerChange_4; }
	inline CheckCanMakeNewContestManagerChange_1_t191952535 ** get_address_of_checkCanMakeNewContestManagerChange_4() { return &___checkCanMakeNewContestManagerChange_4; }
	inline void set_checkCanMakeNewContestManagerChange_4(CheckCanMakeNewContestManagerChange_1_t191952535 * value)
	{
		___checkCanMakeNewContestManagerChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___checkCanMakeNewContestManagerChange_4, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_5() { return static_cast<int32_t>(offsetof(RequestNewContestManagerStateAskUpdate_t1563492643, ___roomCheckAdminChange_5)); }
	inline RoomCheckChangeAdminChange_1_t1705137404 * get_roomCheckAdminChange_5() const { return ___roomCheckAdminChange_5; }
	inline RoomCheckChangeAdminChange_1_t1705137404 ** get_address_of_roomCheckAdminChange_5() { return &___roomCheckAdminChange_5; }
	inline void set_roomCheckAdminChange_5(RoomCheckChangeAdminChange_1_t1705137404 * value)
	{
		___roomCheckAdminChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
