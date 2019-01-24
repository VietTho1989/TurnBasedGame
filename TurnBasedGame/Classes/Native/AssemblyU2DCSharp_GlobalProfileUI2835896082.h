#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2909570877.h"

// UserAdapter
struct UserAdapter_t1274506406;
// UnityEngine.Transform
struct Transform_t3275118058;
// UserUI
struct UserUI_t3871108971;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalProfileUI
struct  GlobalProfileUI_t2835896082  : public UIBehavior_1_t2909570877
{
public:
	// UserAdapter GlobalProfileUI::userAdapterPrefab
	UserAdapter_t1274506406 * ___userAdapterPrefab_6;
	// UnityEngine.Transform GlobalProfileUI::userAdapterContainer
	Transform_t3275118058 * ___userAdapterContainer_7;
	// UserUI GlobalProfileUI::userUIPrefab
	UserUI_t3871108971 * ___userUIPrefab_8;
	// UnityEngine.Transform GlobalProfileUI::userUIContainer
	Transform_t3275118058 * ___userUIContainer_9;

public:
	inline static int32_t get_offset_of_userAdapterPrefab_6() { return static_cast<int32_t>(offsetof(GlobalProfileUI_t2835896082, ___userAdapterPrefab_6)); }
	inline UserAdapter_t1274506406 * get_userAdapterPrefab_6() const { return ___userAdapterPrefab_6; }
	inline UserAdapter_t1274506406 ** get_address_of_userAdapterPrefab_6() { return &___userAdapterPrefab_6; }
	inline void set_userAdapterPrefab_6(UserAdapter_t1274506406 * value)
	{
		___userAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___userAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_userAdapterContainer_7() { return static_cast<int32_t>(offsetof(GlobalProfileUI_t2835896082, ___userAdapterContainer_7)); }
	inline Transform_t3275118058 * get_userAdapterContainer_7() const { return ___userAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_userAdapterContainer_7() { return &___userAdapterContainer_7; }
	inline void set_userAdapterContainer_7(Transform_t3275118058 * value)
	{
		___userAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___userAdapterContainer_7, value);
	}

	inline static int32_t get_offset_of_userUIPrefab_8() { return static_cast<int32_t>(offsetof(GlobalProfileUI_t2835896082, ___userUIPrefab_8)); }
	inline UserUI_t3871108971 * get_userUIPrefab_8() const { return ___userUIPrefab_8; }
	inline UserUI_t3871108971 ** get_address_of_userUIPrefab_8() { return &___userUIPrefab_8; }
	inline void set_userUIPrefab_8(UserUI_t3871108971 * value)
	{
		___userUIPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___userUIPrefab_8, value);
	}

	inline static int32_t get_offset_of_userUIContainer_9() { return static_cast<int32_t>(offsetof(GlobalProfileUI_t2835896082, ___userUIContainer_9)); }
	inline Transform_t3275118058 * get_userUIContainer_9() const { return ___userUIContainer_9; }
	inline Transform_t3275118058 ** get_address_of_userUIContainer_9() { return &___userUIContainer_9; }
	inline void set_userUIContainer_9(Transform_t3275118058 * value)
	{
		___userUIContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___userUIContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
