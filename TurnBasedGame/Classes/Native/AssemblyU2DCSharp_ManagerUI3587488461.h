#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3564669612.h"

// LoadingUI
struct LoadingUI_t3472210146;
// NormalUI
struct NormalUI_t3753177153;
// StartFailUI
struct StartFailUI_t3175139438;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ManagerUI
struct  ManagerUI_t3587488461  : public UIBehavior_1_t3564669612
{
public:
	// LoadingUI ManagerUI::loadPrefab
	LoadingUI_t3472210146 * ___loadPrefab_6;
	// NormalUI ManagerUI::normalPrefab
	NormalUI_t3753177153 * ___normalPrefab_7;
	// StartFailUI ManagerUI::startFailPrefab
	StartFailUI_t3175139438 * ___startFailPrefab_8;

public:
	inline static int32_t get_offset_of_loadPrefab_6() { return static_cast<int32_t>(offsetof(ManagerUI_t3587488461, ___loadPrefab_6)); }
	inline LoadingUI_t3472210146 * get_loadPrefab_6() const { return ___loadPrefab_6; }
	inline LoadingUI_t3472210146 ** get_address_of_loadPrefab_6() { return &___loadPrefab_6; }
	inline void set_loadPrefab_6(LoadingUI_t3472210146 * value)
	{
		___loadPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___loadPrefab_6, value);
	}

	inline static int32_t get_offset_of_normalPrefab_7() { return static_cast<int32_t>(offsetof(ManagerUI_t3587488461, ___normalPrefab_7)); }
	inline NormalUI_t3753177153 * get_normalPrefab_7() const { return ___normalPrefab_7; }
	inline NormalUI_t3753177153 ** get_address_of_normalPrefab_7() { return &___normalPrefab_7; }
	inline void set_normalPrefab_7(NormalUI_t3753177153 * value)
	{
		___normalPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___normalPrefab_7, value);
	}

	inline static int32_t get_offset_of_startFailPrefab_8() { return static_cast<int32_t>(offsetof(ManagerUI_t3587488461, ___startFailPrefab_8)); }
	inline StartFailUI_t3175139438 * get_startFailPrefab_8() const { return ___startFailPrefab_8; }
	inline StartFailUI_t3175139438 ** get_address_of_startFailPrefab_8() { return &___startFailPrefab_8; }
	inline void set_startFailPrefab_8(StartFailUI_t3175139438 * value)
	{
		___startFailPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___startFailPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
