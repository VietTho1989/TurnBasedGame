#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.NormalRoundFactory>
struct NetData_1_t198973552;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.NormalRoundFactoryIdentity
struct  NormalRoundFactoryIdentity_t3263417581  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.NormalRoundFactoryIdentity::isChangeSideBetweenRound
	bool ___isChangeSideBetweenRound_17;
	// System.Boolean GameManager.Match.NormalRoundFactoryIdentity::isSwitchPlayer
	bool ___isSwitchPlayer_18;
	// System.Boolean GameManager.Match.NormalRoundFactoryIdentity::isDifferentInTeam
	bool ___isDifferentInTeam_19;
	// NetData`1<GameManager.Match.NormalRoundFactory> GameManager.Match.NormalRoundFactoryIdentity::netData
	NetData_1_t198973552 * ___netData_20;

public:
	inline static int32_t get_offset_of_isChangeSideBetweenRound_17() { return static_cast<int32_t>(offsetof(NormalRoundFactoryIdentity_t3263417581, ___isChangeSideBetweenRound_17)); }
	inline bool get_isChangeSideBetweenRound_17() const { return ___isChangeSideBetweenRound_17; }
	inline bool* get_address_of_isChangeSideBetweenRound_17() { return &___isChangeSideBetweenRound_17; }
	inline void set_isChangeSideBetweenRound_17(bool value)
	{
		___isChangeSideBetweenRound_17 = value;
	}

	inline static int32_t get_offset_of_isSwitchPlayer_18() { return static_cast<int32_t>(offsetof(NormalRoundFactoryIdentity_t3263417581, ___isSwitchPlayer_18)); }
	inline bool get_isSwitchPlayer_18() const { return ___isSwitchPlayer_18; }
	inline bool* get_address_of_isSwitchPlayer_18() { return &___isSwitchPlayer_18; }
	inline void set_isSwitchPlayer_18(bool value)
	{
		___isSwitchPlayer_18 = value;
	}

	inline static int32_t get_offset_of_isDifferentInTeam_19() { return static_cast<int32_t>(offsetof(NormalRoundFactoryIdentity_t3263417581, ___isDifferentInTeam_19)); }
	inline bool get_isDifferentInTeam_19() const { return ___isDifferentInTeam_19; }
	inline bool* get_address_of_isDifferentInTeam_19() { return &___isDifferentInTeam_19; }
	inline void set_isDifferentInTeam_19(bool value)
	{
		___isDifferentInTeam_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(NormalRoundFactoryIdentity_t3263417581, ___netData_20)); }
	inline NetData_1_t198973552 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t198973552 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t198973552 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
