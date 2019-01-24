#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1309173106.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// Rights.NoLimitUI
struct NoLimitUI_t3249898134;
// Rights.HaveLimitUI
struct HaveLimitUI_t2404248209;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.UndoRedoRightUI
struct  UndoRedoRightUI_t3980360378  : public UIBehavior_1_t1309173106
{
public:
	// System.Boolean Rights.UndoRedoRightUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject Rights.UndoRedoRightUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform Rights.UndoRedoRightUI::needAcceptContainer
	Transform_t3275118058 * ___needAcceptContainer_8;
	// UnityEngine.Transform Rights.UndoRedoRightUI::needAdminContainer
	Transform_t3275118058 * ___needAdminContainer_9;
	// UnityEngine.Transform Rights.UndoRedoRightUI::limitTypeContainer
	Transform_t3275118058 * ___limitTypeContainer_10;
	// UnityEngine.Transform Rights.UndoRedoRightUI::limitUIDataContainer
	Transform_t3275118058 * ___limitUIDataContainer_11;
	// RequestChangeBoolUI Rights.UndoRedoRightUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_12;
	// RequestChangeEnumUI Rights.UndoRedoRightUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_13;
	// Rights.NoLimitUI Rights.UndoRedoRightUI::noLimitPrefab
	NoLimitUI_t3249898134 * ___noLimitPrefab_14;
	// Rights.HaveLimitUI Rights.UndoRedoRightUI::haveLimitPrefab
	HaveLimitUI_t2404248209 * ___haveLimitPrefab_15;
	// Server Rights.UndoRedoRightUI::server
	Server_t2724320767 * ___server_16;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_needAcceptContainer_8() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___needAcceptContainer_8)); }
	inline Transform_t3275118058 * get_needAcceptContainer_8() const { return ___needAcceptContainer_8; }
	inline Transform_t3275118058 ** get_address_of_needAcceptContainer_8() { return &___needAcceptContainer_8; }
	inline void set_needAcceptContainer_8(Transform_t3275118058 * value)
	{
		___needAcceptContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___needAcceptContainer_8, value);
	}

	inline static int32_t get_offset_of_needAdminContainer_9() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___needAdminContainer_9)); }
	inline Transform_t3275118058 * get_needAdminContainer_9() const { return ___needAdminContainer_9; }
	inline Transform_t3275118058 ** get_address_of_needAdminContainer_9() { return &___needAdminContainer_9; }
	inline void set_needAdminContainer_9(Transform_t3275118058 * value)
	{
		___needAdminContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___needAdminContainer_9, value);
	}

	inline static int32_t get_offset_of_limitTypeContainer_10() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___limitTypeContainer_10)); }
	inline Transform_t3275118058 * get_limitTypeContainer_10() const { return ___limitTypeContainer_10; }
	inline Transform_t3275118058 ** get_address_of_limitTypeContainer_10() { return &___limitTypeContainer_10; }
	inline void set_limitTypeContainer_10(Transform_t3275118058 * value)
	{
		___limitTypeContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___limitTypeContainer_10, value);
	}

	inline static int32_t get_offset_of_limitUIDataContainer_11() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___limitUIDataContainer_11)); }
	inline Transform_t3275118058 * get_limitUIDataContainer_11() const { return ___limitUIDataContainer_11; }
	inline Transform_t3275118058 ** get_address_of_limitUIDataContainer_11() { return &___limitUIDataContainer_11; }
	inline void set_limitUIDataContainer_11(Transform_t3275118058 * value)
	{
		___limitUIDataContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___limitUIDataContainer_11, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_12() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___requestBoolPrefab_12)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_12() const { return ___requestBoolPrefab_12; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_12() { return &___requestBoolPrefab_12; }
	inline void set_requestBoolPrefab_12(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_12, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_13() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___requestEnumPrefab_13)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_13() const { return ___requestEnumPrefab_13; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_13() { return &___requestEnumPrefab_13; }
	inline void set_requestEnumPrefab_13(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_13, value);
	}

	inline static int32_t get_offset_of_noLimitPrefab_14() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___noLimitPrefab_14)); }
	inline NoLimitUI_t3249898134 * get_noLimitPrefab_14() const { return ___noLimitPrefab_14; }
	inline NoLimitUI_t3249898134 ** get_address_of_noLimitPrefab_14() { return &___noLimitPrefab_14; }
	inline void set_noLimitPrefab_14(NoLimitUI_t3249898134 * value)
	{
		___noLimitPrefab_14 = value;
		Il2CppCodeGenWriteBarrier(&___noLimitPrefab_14, value);
	}

	inline static int32_t get_offset_of_haveLimitPrefab_15() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___haveLimitPrefab_15)); }
	inline HaveLimitUI_t2404248209 * get_haveLimitPrefab_15() const { return ___haveLimitPrefab_15; }
	inline HaveLimitUI_t2404248209 ** get_address_of_haveLimitPrefab_15() { return &___haveLimitPrefab_15; }
	inline void set_haveLimitPrefab_15(HaveLimitUI_t2404248209 * value)
	{
		___haveLimitPrefab_15 = value;
		Il2CppCodeGenWriteBarrier(&___haveLimitPrefab_15, value);
	}

	inline static int32_t get_offset_of_server_16() { return static_cast<int32_t>(offsetof(UndoRedoRightUI_t3980360378, ___server_16)); }
	inline Server_t2724320767 * get_server_16() const { return ___server_16; }
	inline Server_t2724320767 ** get_address_of_server_16() { return &___server_16; }
	inline void set_server_16(Server_t2724320767 * value)
	{
		___server_16 = value;
		Il2CppCodeGenWriteBarrier(&___server_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
