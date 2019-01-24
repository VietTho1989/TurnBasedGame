#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1085151874.h"

// GameManager.Match.RoundRobin.RequestNewRoundRobinCheckChange`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk>
struct RequestNewRoundRobinCheckChange_1_t361883860;
// RoomCheckChangeAdminChange`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk>
struct RoomCheckChangeAdminChange_1_t4054449191;
// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk>
struct ContestManagerStatePlayTeamCheckChange_1_t1047353502;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RequestNewRoundRobinStateAskUpdate
struct  RequestNewRoundRobinStateAskUpdate_t2726013016  : public UpdateBehavior_1_t1085151874
{
public:
	// GameManager.Match.RoundRobin.RequestNewRoundRobinCheckChange`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk> GameManager.Match.RoundRobin.RequestNewRoundRobinStateAskUpdate::requestNewRoundRobinCheckChange
	RequestNewRoundRobinCheckChange_1_t361883860 * ___requestNewRoundRobinCheckChange_4;
	// RoomCheckChangeAdminChange`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk> GameManager.Match.RoundRobin.RequestNewRoundRobinStateAskUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t4054449191 * ___roomCheckAdminChange_5;
	// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.RoundRobin.RequestNewRoundRobinStateAsk> GameManager.Match.RoundRobin.RequestNewRoundRobinStateAskUpdate::contestManagerStatePlayTeamCheckChange
	ContestManagerStatePlayTeamCheckChange_1_t1047353502 * ___contestManagerStatePlayTeamCheckChange_6;

public:
	inline static int32_t get_offset_of_requestNewRoundRobinCheckChange_4() { return static_cast<int32_t>(offsetof(RequestNewRoundRobinStateAskUpdate_t2726013016, ___requestNewRoundRobinCheckChange_4)); }
	inline RequestNewRoundRobinCheckChange_1_t361883860 * get_requestNewRoundRobinCheckChange_4() const { return ___requestNewRoundRobinCheckChange_4; }
	inline RequestNewRoundRobinCheckChange_1_t361883860 ** get_address_of_requestNewRoundRobinCheckChange_4() { return &___requestNewRoundRobinCheckChange_4; }
	inline void set_requestNewRoundRobinCheckChange_4(RequestNewRoundRobinCheckChange_1_t361883860 * value)
	{
		___requestNewRoundRobinCheckChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundRobinCheckChange_4, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_5() { return static_cast<int32_t>(offsetof(RequestNewRoundRobinStateAskUpdate_t2726013016, ___roomCheckAdminChange_5)); }
	inline RoomCheckChangeAdminChange_1_t4054449191 * get_roomCheckAdminChange_5() const { return ___roomCheckAdminChange_5; }
	inline RoomCheckChangeAdminChange_1_t4054449191 ** get_address_of_roomCheckAdminChange_5() { return &___roomCheckAdminChange_5; }
	inline void set_roomCheckAdminChange_5(RoomCheckChangeAdminChange_1_t4054449191 * value)
	{
		___roomCheckAdminChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_5, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlayTeamCheckChange_6() { return static_cast<int32_t>(offsetof(RequestNewRoundRobinStateAskUpdate_t2726013016, ___contestManagerStatePlayTeamCheckChange_6)); }
	inline ContestManagerStatePlayTeamCheckChange_1_t1047353502 * get_contestManagerStatePlayTeamCheckChange_6() const { return ___contestManagerStatePlayTeamCheckChange_6; }
	inline ContestManagerStatePlayTeamCheckChange_1_t1047353502 ** get_address_of_contestManagerStatePlayTeamCheckChange_6() { return &___contestManagerStatePlayTeamCheckChange_6; }
	inline void set_contestManagerStatePlayTeamCheckChange_6(ContestManagerStatePlayTeamCheckChange_1_t1047353502 * value)
	{
		___contestManagerStatePlayTeamCheckChange_6 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlayTeamCheckChange_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
