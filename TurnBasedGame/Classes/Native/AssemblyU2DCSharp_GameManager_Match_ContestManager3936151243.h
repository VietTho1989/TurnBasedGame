#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2249392004.h"

// GameManager.Match.ContestManagerPlayBtnForceEndUI
struct ContestManagerPlayBtnForceEndUI_t2756429719;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerStatePlayInformUI
struct  ContestManagerStatePlayInformUI_t3936151243  : public UIBehavior_1_t2249392004
{
public:
	// GameManager.Match.ContestManagerPlayBtnForceEndUI GameManager.Match.ContestManagerStatePlayInformUI::btnForceEndPrefab
	ContestManagerPlayBtnForceEndUI_t2756429719 * ___btnForceEndPrefab_6;
	// UnityEngine.Transform GameManager.Match.ContestManagerStatePlayInformUI::btnForceEndContainer
	Transform_t3275118058 * ___btnForceEndContainer_7;

public:
	inline static int32_t get_offset_of_btnForceEndPrefab_6() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayInformUI_t3936151243, ___btnForceEndPrefab_6)); }
	inline ContestManagerPlayBtnForceEndUI_t2756429719 * get_btnForceEndPrefab_6() const { return ___btnForceEndPrefab_6; }
	inline ContestManagerPlayBtnForceEndUI_t2756429719 ** get_address_of_btnForceEndPrefab_6() { return &___btnForceEndPrefab_6; }
	inline void set_btnForceEndPrefab_6(ContestManagerPlayBtnForceEndUI_t2756429719 * value)
	{
		___btnForceEndPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnForceEndPrefab_6, value);
	}

	inline static int32_t get_offset_of_btnForceEndContainer_7() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayInformUI_t3936151243, ___btnForceEndContainer_7)); }
	inline Transform_t3275118058 * get_btnForceEndContainer_7() const { return ___btnForceEndContainer_7; }
	inline Transform_t3275118058 ** get_address_of_btnForceEndContainer_7() { return &___btnForceEndContainer_7; }
	inline void set_btnForceEndContainer_7(Transform_t3275118058 * value)
	{
		___btnForceEndContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnForceEndContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
