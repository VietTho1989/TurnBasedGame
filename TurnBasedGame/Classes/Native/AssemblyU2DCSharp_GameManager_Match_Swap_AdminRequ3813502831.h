#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro3621011707.h"

// GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanHolder
struct AdminRequestSwapPlayerChooseHumanHolder_t2768701816;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// RoomCheckChangeAdminChange`1<GameManager.Match.TeamPlayer>
struct RoomCheckChangeAdminChange_1_t3399795144;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter
struct  AdminRequestSwapPlayerChooseHumanAdapter_t3813502831  : public SRIA_2_t3621011707
{
public:
	// GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanHolder GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter::holderPrefab
	AdminRequestSwapPlayerChooseHumanHolder_t2768701816 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter::noHumans
	GameObject_t1756533147 * ___noHumans_25;
	// RoomCheckChangeAdminChange`1<GameManager.Match.TeamPlayer> GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t3399795144 * ___roomCheckAdminChange_26;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerChooseHumanAdapter_t3813502831, ___holderPrefab_24)); }
	inline AdminRequestSwapPlayerChooseHumanHolder_t2768701816 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline AdminRequestSwapPlayerChooseHumanHolder_t2768701816 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(AdminRequestSwapPlayerChooseHumanHolder_t2768701816 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noHumans_25() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerChooseHumanAdapter_t3813502831, ___noHumans_25)); }
	inline GameObject_t1756533147 * get_noHumans_25() const { return ___noHumans_25; }
	inline GameObject_t1756533147 ** get_address_of_noHumans_25() { return &___noHumans_25; }
	inline void set_noHumans_25(GameObject_t1756533147 * value)
	{
		___noHumans_25 = value;
		Il2CppCodeGenWriteBarrier(&___noHumans_25, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_26() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerChooseHumanAdapter_t3813502831, ___roomCheckAdminChange_26)); }
	inline RoomCheckChangeAdminChange_1_t3399795144 * get_roomCheckAdminChange_26() const { return ___roomCheckAdminChange_26; }
	inline RoomCheckChangeAdminChange_1_t3399795144 ** get_address_of_roomCheckAdminChange_26() { return &___roomCheckAdminChange_26; }
	inline void set_roomCheckAdminChange_26(RoomCheckChangeAdminChange_1_t3399795144 * value)
	{
		___roomCheckAdminChange_26 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_26, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
