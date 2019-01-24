#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen952329220.h"

// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// UnityEngine.Transform
struct Transform_t3275118058;
// RoomCheckChangeAdminChange`1<GameManager.Match.ContestManagerStatePlay>
struct RoomCheckChangeAdminChange_1_t3278867282;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerPlayBtnForceEndUI
struct  ContestManagerPlayBtnForceEndUI_t2756429719  : public UIBehavior_1_t952329220
{
public:
	// System.Boolean GameManager.Match.ContestManagerPlayBtnForceEndUI::needReset
	bool ___needReset_6;
	// RequestChangeBoolUI GameManager.Match.ContestManagerPlayBtnForceEndUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_7;
	// UnityEngine.Transform GameManager.Match.ContestManagerPlayBtnForceEndUI::isForceEndContainer
	Transform_t3275118058 * ___isForceEndContainer_8;
	// RoomCheckChangeAdminChange`1<GameManager.Match.ContestManagerStatePlay> GameManager.Match.ContestManagerPlayBtnForceEndUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t3278867282 * ___roomCheckAdminChange_9;
	// Server GameManager.Match.ContestManagerPlayBtnForceEndUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(ContestManagerPlayBtnForceEndUI_t2756429719, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_requestBoolPrefab_7() { return static_cast<int32_t>(offsetof(ContestManagerPlayBtnForceEndUI_t2756429719, ___requestBoolPrefab_7)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_7() const { return ___requestBoolPrefab_7; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_7() { return &___requestBoolPrefab_7; }
	inline void set_requestBoolPrefab_7(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_7, value);
	}

	inline static int32_t get_offset_of_isForceEndContainer_8() { return static_cast<int32_t>(offsetof(ContestManagerPlayBtnForceEndUI_t2756429719, ___isForceEndContainer_8)); }
	inline Transform_t3275118058 * get_isForceEndContainer_8() const { return ___isForceEndContainer_8; }
	inline Transform_t3275118058 ** get_address_of_isForceEndContainer_8() { return &___isForceEndContainer_8; }
	inline void set_isForceEndContainer_8(Transform_t3275118058 * value)
	{
		___isForceEndContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___isForceEndContainer_8, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_9() { return static_cast<int32_t>(offsetof(ContestManagerPlayBtnForceEndUI_t2756429719, ___roomCheckAdminChange_9)); }
	inline RoomCheckChangeAdminChange_1_t3278867282 * get_roomCheckAdminChange_9() const { return ___roomCheckAdminChange_9; }
	inline RoomCheckChangeAdminChange_1_t3278867282 ** get_address_of_roomCheckAdminChange_9() { return &___roomCheckAdminChange_9; }
	inline void set_roomCheckAdminChange_9(RoomCheckChangeAdminChange_1_t3278867282 * value)
	{
		___roomCheckAdminChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(ContestManagerPlayBtnForceEndUI_t2756429719, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
