#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen626562405.h"

// GameManager.Match.Elimination.EliminationRoundCheckChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk>
struct EliminationRoundCheckChange_1_t2666629811;
// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk>
struct ContestManagerStatePlayTeamCheckChange_1_t588764033;
// RoomCheckChangeAdminChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk>
struct RoomCheckChangeAdminChange_1_t3595859722;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.RequestNewEliminationRoundStateAskUpdate
struct  RequestNewEliminationRoundStateAskUpdate_t3883732465  : public UpdateBehavior_1_t626562405
{
public:
	// GameManager.Match.Elimination.EliminationRoundCheckChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk> GameManager.Match.Elimination.RequestNewEliminationRoundStateAskUpdate::eliminationRoundCheckChange
	EliminationRoundCheckChange_1_t2666629811 * ___eliminationRoundCheckChange_4;
	// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk> GameManager.Match.Elimination.RequestNewEliminationRoundStateAskUpdate::contestManagerStatePlayTeamCheckChange
	ContestManagerStatePlayTeamCheckChange_1_t588764033 * ___contestManagerStatePlayTeamCheckChange_5;
	// RoomCheckChangeAdminChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAsk> GameManager.Match.Elimination.RequestNewEliminationRoundStateAskUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t3595859722 * ___roomCheckAdminChange_6;

public:
	inline static int32_t get_offset_of_eliminationRoundCheckChange_4() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundStateAskUpdate_t3883732465, ___eliminationRoundCheckChange_4)); }
	inline EliminationRoundCheckChange_1_t2666629811 * get_eliminationRoundCheckChange_4() const { return ___eliminationRoundCheckChange_4; }
	inline EliminationRoundCheckChange_1_t2666629811 ** get_address_of_eliminationRoundCheckChange_4() { return &___eliminationRoundCheckChange_4; }
	inline void set_eliminationRoundCheckChange_4(EliminationRoundCheckChange_1_t2666629811 * value)
	{
		___eliminationRoundCheckChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRoundCheckChange_4, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlayTeamCheckChange_5() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundStateAskUpdate_t3883732465, ___contestManagerStatePlayTeamCheckChange_5)); }
	inline ContestManagerStatePlayTeamCheckChange_1_t588764033 * get_contestManagerStatePlayTeamCheckChange_5() const { return ___contestManagerStatePlayTeamCheckChange_5; }
	inline ContestManagerStatePlayTeamCheckChange_1_t588764033 ** get_address_of_contestManagerStatePlayTeamCheckChange_5() { return &___contestManagerStatePlayTeamCheckChange_5; }
	inline void set_contestManagerStatePlayTeamCheckChange_5(ContestManagerStatePlayTeamCheckChange_1_t588764033 * value)
	{
		___contestManagerStatePlayTeamCheckChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlayTeamCheckChange_5, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_6() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundStateAskUpdate_t3883732465, ___roomCheckAdminChange_6)); }
	inline RoomCheckChangeAdminChange_1_t3595859722 * get_roomCheckAdminChange_6() const { return ___roomCheckAdminChange_6; }
	inline RoomCheckChangeAdminChange_1_t3595859722 ** get_address_of_roomCheckAdminChange_6() { return &___roomCheckAdminChange_6; }
	inline void set_roomCheckAdminChange_6(RoomCheckChangeAdminChange_1_t3595859722 * value)
	{
		___roomCheckAdminChange_6 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
