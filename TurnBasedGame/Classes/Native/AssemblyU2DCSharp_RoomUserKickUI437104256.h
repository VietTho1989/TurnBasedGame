#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1592653769.h"

// RoomUserBtnKickUI
struct RoomUserBtnKickUI_t4167404676;
// UnityEngine.Transform
struct Transform_t3275118058;
// RoomUserBtnUnKickUI
struct RoomUserBtnUnKickUI_t745847565;
// RoomCheckChangeAdminChange`1<RoomUser>
struct RoomCheckChangeAdminChange_1_t2103484370;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserKickUI
struct  RoomUserKickUI_t437104256  : public UIBehavior_1_t1592653769
{
public:
	// RoomUserBtnKickUI RoomUserKickUI::btnKickPrefab
	RoomUserBtnKickUI_t4167404676 * ___btnKickPrefab_6;
	// UnityEngine.Transform RoomUserKickUI::btnKickContainer
	Transform_t3275118058 * ___btnKickContainer_7;
	// RoomUserBtnUnKickUI RoomUserKickUI::btnUnKickPrefab
	RoomUserBtnUnKickUI_t745847565 * ___btnUnKickPrefab_8;
	// UnityEngine.Transform RoomUserKickUI::btnUnKickContainer
	Transform_t3275118058 * ___btnUnKickContainer_9;
	// RoomCheckChangeAdminChange`1<RoomUser> RoomUserKickUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t2103484370 * ___roomCheckAdminChange_10;

public:
	inline static int32_t get_offset_of_btnKickPrefab_6() { return static_cast<int32_t>(offsetof(RoomUserKickUI_t437104256, ___btnKickPrefab_6)); }
	inline RoomUserBtnKickUI_t4167404676 * get_btnKickPrefab_6() const { return ___btnKickPrefab_6; }
	inline RoomUserBtnKickUI_t4167404676 ** get_address_of_btnKickPrefab_6() { return &___btnKickPrefab_6; }
	inline void set_btnKickPrefab_6(RoomUserBtnKickUI_t4167404676 * value)
	{
		___btnKickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnKickPrefab_6, value);
	}

	inline static int32_t get_offset_of_btnKickContainer_7() { return static_cast<int32_t>(offsetof(RoomUserKickUI_t437104256, ___btnKickContainer_7)); }
	inline Transform_t3275118058 * get_btnKickContainer_7() const { return ___btnKickContainer_7; }
	inline Transform_t3275118058 ** get_address_of_btnKickContainer_7() { return &___btnKickContainer_7; }
	inline void set_btnKickContainer_7(Transform_t3275118058 * value)
	{
		___btnKickContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnKickContainer_7, value);
	}

	inline static int32_t get_offset_of_btnUnKickPrefab_8() { return static_cast<int32_t>(offsetof(RoomUserKickUI_t437104256, ___btnUnKickPrefab_8)); }
	inline RoomUserBtnUnKickUI_t745847565 * get_btnUnKickPrefab_8() const { return ___btnUnKickPrefab_8; }
	inline RoomUserBtnUnKickUI_t745847565 ** get_address_of_btnUnKickPrefab_8() { return &___btnUnKickPrefab_8; }
	inline void set_btnUnKickPrefab_8(RoomUserBtnUnKickUI_t745847565 * value)
	{
		___btnUnKickPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnUnKickPrefab_8, value);
	}

	inline static int32_t get_offset_of_btnUnKickContainer_9() { return static_cast<int32_t>(offsetof(RoomUserKickUI_t437104256, ___btnUnKickContainer_9)); }
	inline Transform_t3275118058 * get_btnUnKickContainer_9() const { return ___btnUnKickContainer_9; }
	inline Transform_t3275118058 ** get_address_of_btnUnKickContainer_9() { return &___btnUnKickContainer_9; }
	inline void set_btnUnKickContainer_9(Transform_t3275118058 * value)
	{
		___btnUnKickContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___btnUnKickContainer_9, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_10() { return static_cast<int32_t>(offsetof(RoomUserKickUI_t437104256, ___roomCheckAdminChange_10)); }
	inline RoomCheckChangeAdminChange_1_t2103484370 * get_roomCheckAdminChange_10() const { return ___roomCheckAdminChange_10; }
	inline RoomCheckChangeAdminChange_1_t2103484370 ** get_address_of_roomCheckAdminChange_10() { return &___roomCheckAdminChange_10; }
	inline void set_roomCheckAdminChange_10(RoomCheckChangeAdminChange_1_t2103484370 * value)
	{
		___roomCheckAdminChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
