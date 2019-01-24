#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3651869160.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// JoinRoomUI
struct  JoinRoomUI_t2332888483  : public UIBehavior_1_t3651869160
{
public:
	// UnityEngine.GameObject JoinRoomUI::cannotJoinIndicator
	GameObject_t1756533147 * ___cannotJoinIndicator_6;
	// UnityEngine.UI.Button JoinRoomUI::btnJoin
	Button_t2872111280 * ___btnJoin_7;
	// UnityEngine.GameObject JoinRoomUI::requestingIndicator
	GameObject_t1756533147 * ___requestingIndicator_8;
	// AdvancedCoroutines.Routine JoinRoomUI::wait
	Routine_t2502590640 * ___wait_9;
	// RequestChangeStringUI JoinRoomUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_10;
	// RequestChangeEnumUI JoinRoomUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_11;
	// UnityEngine.Transform JoinRoomUI::idContainer
	Transform_t3275118058 * ___idContainer_12;
	// UnityEngine.Transform JoinRoomUI::nameContainer
	Transform_t3275118058 * ___nameContainer_13;
	// UnityEngine.Transform JoinRoomUI::playersContainer
	Transform_t3275118058 * ___playersContainer_14;
	// UnityEngine.Transform JoinRoomUI::stateContainer
	Transform_t3275118058 * ___stateContainer_15;
	// UnityEngine.Transform JoinRoomUI::timeContainer
	Transform_t3275118058 * ___timeContainer_16;
	// UnityEngine.Transform JoinRoomUI::passwordContainer
	Transform_t3275118058 * ___passwordContainer_17;
	// Server JoinRoomUI::server
	Server_t2724320767 * ___server_18;

public:
	inline static int32_t get_offset_of_cannotJoinIndicator_6() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___cannotJoinIndicator_6)); }
	inline GameObject_t1756533147 * get_cannotJoinIndicator_6() const { return ___cannotJoinIndicator_6; }
	inline GameObject_t1756533147 ** get_address_of_cannotJoinIndicator_6() { return &___cannotJoinIndicator_6; }
	inline void set_cannotJoinIndicator_6(GameObject_t1756533147 * value)
	{
		___cannotJoinIndicator_6 = value;
		Il2CppCodeGenWriteBarrier(&___cannotJoinIndicator_6, value);
	}

	inline static int32_t get_offset_of_btnJoin_7() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___btnJoin_7)); }
	inline Button_t2872111280 * get_btnJoin_7() const { return ___btnJoin_7; }
	inline Button_t2872111280 ** get_address_of_btnJoin_7() { return &___btnJoin_7; }
	inline void set_btnJoin_7(Button_t2872111280 * value)
	{
		___btnJoin_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnJoin_7, value);
	}

	inline static int32_t get_offset_of_requestingIndicator_8() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___requestingIndicator_8)); }
	inline GameObject_t1756533147 * get_requestingIndicator_8() const { return ___requestingIndicator_8; }
	inline GameObject_t1756533147 ** get_address_of_requestingIndicator_8() { return &___requestingIndicator_8; }
	inline void set_requestingIndicator_8(GameObject_t1756533147 * value)
	{
		___requestingIndicator_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestingIndicator_8, value);
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_10() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___requestStringPrefab_10)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_10() const { return ___requestStringPrefab_10; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_10() { return &___requestStringPrefab_10; }
	inline void set_requestStringPrefab_10(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_10, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_11() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___requestEnumPrefab_11)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_11() const { return ___requestEnumPrefab_11; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_11() { return &___requestEnumPrefab_11; }
	inline void set_requestEnumPrefab_11(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_11, value);
	}

	inline static int32_t get_offset_of_idContainer_12() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___idContainer_12)); }
	inline Transform_t3275118058 * get_idContainer_12() const { return ___idContainer_12; }
	inline Transform_t3275118058 ** get_address_of_idContainer_12() { return &___idContainer_12; }
	inline void set_idContainer_12(Transform_t3275118058 * value)
	{
		___idContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___idContainer_12, value);
	}

	inline static int32_t get_offset_of_nameContainer_13() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___nameContainer_13)); }
	inline Transform_t3275118058 * get_nameContainer_13() const { return ___nameContainer_13; }
	inline Transform_t3275118058 ** get_address_of_nameContainer_13() { return &___nameContainer_13; }
	inline void set_nameContainer_13(Transform_t3275118058 * value)
	{
		___nameContainer_13 = value;
		Il2CppCodeGenWriteBarrier(&___nameContainer_13, value);
	}

	inline static int32_t get_offset_of_playersContainer_14() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___playersContainer_14)); }
	inline Transform_t3275118058 * get_playersContainer_14() const { return ___playersContainer_14; }
	inline Transform_t3275118058 ** get_address_of_playersContainer_14() { return &___playersContainer_14; }
	inline void set_playersContainer_14(Transform_t3275118058 * value)
	{
		___playersContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___playersContainer_14, value);
	}

	inline static int32_t get_offset_of_stateContainer_15() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___stateContainer_15)); }
	inline Transform_t3275118058 * get_stateContainer_15() const { return ___stateContainer_15; }
	inline Transform_t3275118058 ** get_address_of_stateContainer_15() { return &___stateContainer_15; }
	inline void set_stateContainer_15(Transform_t3275118058 * value)
	{
		___stateContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___stateContainer_15, value);
	}

	inline static int32_t get_offset_of_timeContainer_16() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___timeContainer_16)); }
	inline Transform_t3275118058 * get_timeContainer_16() const { return ___timeContainer_16; }
	inline Transform_t3275118058 ** get_address_of_timeContainer_16() { return &___timeContainer_16; }
	inline void set_timeContainer_16(Transform_t3275118058 * value)
	{
		___timeContainer_16 = value;
		Il2CppCodeGenWriteBarrier(&___timeContainer_16, value);
	}

	inline static int32_t get_offset_of_passwordContainer_17() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___passwordContainer_17)); }
	inline Transform_t3275118058 * get_passwordContainer_17() const { return ___passwordContainer_17; }
	inline Transform_t3275118058 ** get_address_of_passwordContainer_17() { return &___passwordContainer_17; }
	inline void set_passwordContainer_17(Transform_t3275118058 * value)
	{
		___passwordContainer_17 = value;
		Il2CppCodeGenWriteBarrier(&___passwordContainer_17, value);
	}

	inline static int32_t get_offset_of_server_18() { return static_cast<int32_t>(offsetof(JoinRoomUI_t2332888483, ___server_18)); }
	inline Server_t2724320767 * get_server_18() const { return ___server_18; }
	inline Server_t2724320767 ** get_address_of_server_18() { return &___server_18; }
	inline void set_server_18(Server_t2724320767 * value)
	{
		___server_18 = value;
		Il2CppCodeGenWriteBarrier(&___server_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
