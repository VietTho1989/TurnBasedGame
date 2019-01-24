#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen461080670.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI
struct AdminRequestSwapPlayerHumanUI_t4084821379;
// GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI
struct AdminRequestSwapPlayerComputerUI_t1703686241;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.AdminRequestSwapPlayerUI
struct  AdminRequestSwapPlayerUI_t2598849030  : public UIBehavior_1_t461080670
{
public:
	// UnityEngine.UI.Button GameManager.Match.Swap.AdminRequestSwapPlayerUI::btnHuman
	Button_t2872111280 * ___btnHuman_6;
	// UnityEngine.UI.Button GameManager.Match.Swap.AdminRequestSwapPlayerUI::btnComputer
	Button_t2872111280 * ___btnComputer_7;
	// GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI GameManager.Match.Swap.AdminRequestSwapPlayerUI::humanPrefab
	AdminRequestSwapPlayerHumanUI_t4084821379 * ___humanPrefab_8;
	// GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI GameManager.Match.Swap.AdminRequestSwapPlayerUI::computerPrefab
	AdminRequestSwapPlayerComputerUI_t1703686241 * ___computerPrefab_9;
	// UnityEngine.Transform GameManager.Match.Swap.AdminRequestSwapPlayerUI::humanContainer
	Transform_t3275118058 * ___humanContainer_10;
	// UnityEngine.Transform GameManager.Match.Swap.AdminRequestSwapPlayerUI::computerContainer
	Transform_t3275118058 * ___computerContainer_11;

public:
	inline static int32_t get_offset_of_btnHuman_6() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerUI_t2598849030, ___btnHuman_6)); }
	inline Button_t2872111280 * get_btnHuman_6() const { return ___btnHuman_6; }
	inline Button_t2872111280 ** get_address_of_btnHuman_6() { return &___btnHuman_6; }
	inline void set_btnHuman_6(Button_t2872111280 * value)
	{
		___btnHuman_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnHuman_6, value);
	}

	inline static int32_t get_offset_of_btnComputer_7() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerUI_t2598849030, ___btnComputer_7)); }
	inline Button_t2872111280 * get_btnComputer_7() const { return ___btnComputer_7; }
	inline Button_t2872111280 ** get_address_of_btnComputer_7() { return &___btnComputer_7; }
	inline void set_btnComputer_7(Button_t2872111280 * value)
	{
		___btnComputer_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnComputer_7, value);
	}

	inline static int32_t get_offset_of_humanPrefab_8() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerUI_t2598849030, ___humanPrefab_8)); }
	inline AdminRequestSwapPlayerHumanUI_t4084821379 * get_humanPrefab_8() const { return ___humanPrefab_8; }
	inline AdminRequestSwapPlayerHumanUI_t4084821379 ** get_address_of_humanPrefab_8() { return &___humanPrefab_8; }
	inline void set_humanPrefab_8(AdminRequestSwapPlayerHumanUI_t4084821379 * value)
	{
		___humanPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___humanPrefab_8, value);
	}

	inline static int32_t get_offset_of_computerPrefab_9() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerUI_t2598849030, ___computerPrefab_9)); }
	inline AdminRequestSwapPlayerComputerUI_t1703686241 * get_computerPrefab_9() const { return ___computerPrefab_9; }
	inline AdminRequestSwapPlayerComputerUI_t1703686241 ** get_address_of_computerPrefab_9() { return &___computerPrefab_9; }
	inline void set_computerPrefab_9(AdminRequestSwapPlayerComputerUI_t1703686241 * value)
	{
		___computerPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___computerPrefab_9, value);
	}

	inline static int32_t get_offset_of_humanContainer_10() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerUI_t2598849030, ___humanContainer_10)); }
	inline Transform_t3275118058 * get_humanContainer_10() const { return ___humanContainer_10; }
	inline Transform_t3275118058 ** get_address_of_humanContainer_10() { return &___humanContainer_10; }
	inline void set_humanContainer_10(Transform_t3275118058 * value)
	{
		___humanContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___humanContainer_10, value);
	}

	inline static int32_t get_offset_of_computerContainer_11() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerUI_t2598849030, ___computerContainer_11)); }
	inline Transform_t3275118058 * get_computerContainer_11() const { return ___computerContainer_11; }
	inline Transform_t3275118058 ** get_address_of_computerContainer_11() { return &___computerContainer_11; }
	inline void set_computerContainer_11(Transform_t3275118058 * value)
	{
		___computerContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___computerContainer_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
