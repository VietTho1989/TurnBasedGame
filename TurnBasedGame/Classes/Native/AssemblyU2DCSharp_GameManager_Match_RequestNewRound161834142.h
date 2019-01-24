#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3894504896.h"

// GameManager.Match.CheckCanMakeNewRoundChange`1<GameManager.Match.RequestNewRoundStateAsk>
struct CheckCanMakeNewRoundChange_1_t506379599;
// RoomCheckChangeAdminChange`1<GameManager.Match.RequestNewRoundStateAsk>
struct RoomCheckChangeAdminChange_1_t2568834917;
// GameManager.Match.CheckContestTeamChange`1<GameManager.Match.RequestNewRoundStateAsk>
struct CheckContestTeamChange_1_t418038572;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundStateAskUpdate
struct  RequestNewRoundStateAskUpdate_t161834142  : public UpdateBehavior_1_t3894504896
{
public:
	// GameManager.Match.CheckCanMakeNewRoundChange`1<GameManager.Match.RequestNewRoundStateAsk> GameManager.Match.RequestNewRoundStateAskUpdate::checkCanMakeNewRoundChange
	CheckCanMakeNewRoundChange_1_t506379599 * ___checkCanMakeNewRoundChange_4;
	// RoomCheckChangeAdminChange`1<GameManager.Match.RequestNewRoundStateAsk> GameManager.Match.RequestNewRoundStateAskUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t2568834917 * ___roomCheckAdminChange_5;
	// GameManager.Match.CheckContestTeamChange`1<GameManager.Match.RequestNewRoundStateAsk> GameManager.Match.RequestNewRoundStateAskUpdate::checkContestTeamChange
	CheckContestTeamChange_1_t418038572 * ___checkContestTeamChange_6;

public:
	inline static int32_t get_offset_of_checkCanMakeNewRoundChange_4() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUpdate_t161834142, ___checkCanMakeNewRoundChange_4)); }
	inline CheckCanMakeNewRoundChange_1_t506379599 * get_checkCanMakeNewRoundChange_4() const { return ___checkCanMakeNewRoundChange_4; }
	inline CheckCanMakeNewRoundChange_1_t506379599 ** get_address_of_checkCanMakeNewRoundChange_4() { return &___checkCanMakeNewRoundChange_4; }
	inline void set_checkCanMakeNewRoundChange_4(CheckCanMakeNewRoundChange_1_t506379599 * value)
	{
		___checkCanMakeNewRoundChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___checkCanMakeNewRoundChange_4, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_5() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUpdate_t161834142, ___roomCheckAdminChange_5)); }
	inline RoomCheckChangeAdminChange_1_t2568834917 * get_roomCheckAdminChange_5() const { return ___roomCheckAdminChange_5; }
	inline RoomCheckChangeAdminChange_1_t2568834917 ** get_address_of_roomCheckAdminChange_5() { return &___roomCheckAdminChange_5; }
	inline void set_roomCheckAdminChange_5(RoomCheckChangeAdminChange_1_t2568834917 * value)
	{
		___roomCheckAdminChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_5, value);
	}

	inline static int32_t get_offset_of_checkContestTeamChange_6() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskUpdate_t161834142, ___checkContestTeamChange_6)); }
	inline CheckContestTeamChange_1_t418038572 * get_checkContestTeamChange_6() const { return ___checkContestTeamChange_6; }
	inline CheckContestTeamChange_1_t418038572 ** get_address_of_checkContestTeamChange_6() { return &___checkContestTeamChange_6; }
	inline void set_checkContestTeamChange_6(CheckContestTeamChange_1_t418038572 * value)
	{
		___checkContestTeamChange_6 = value;
		Il2CppCodeGenWriteBarrier(&___checkContestTeamChange_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
