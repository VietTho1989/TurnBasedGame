#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManager3115183765.h"

// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>>
struct VP_1_t3537971637;
// VP`1<GameManager.Match.ContestManagerPlayBtnForceEndUI/UIData>
struct VP_1_t2046531374;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerStatePlayInformUI/UIData
struct  UIData_t2965317152  : public StateUI_t3115183765
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>> GameManager.Match.ContestManagerStatePlayInformUI/UIData::contestManagerStatePlay
	VP_1_t3537971637 * ___contestManagerStatePlay_5;
	// VP`1<GameManager.Match.ContestManagerPlayBtnForceEndUI/UIData> GameManager.Match.ContestManagerStatePlayInformUI/UIData::btnForceEnd
	VP_1_t2046531374 * ___btnForceEnd_6;

public:
	inline static int32_t get_offset_of_contestManagerStatePlay_5() { return static_cast<int32_t>(offsetof(UIData_t2965317152, ___contestManagerStatePlay_5)); }
	inline VP_1_t3537971637 * get_contestManagerStatePlay_5() const { return ___contestManagerStatePlay_5; }
	inline VP_1_t3537971637 ** get_address_of_contestManagerStatePlay_5() { return &___contestManagerStatePlay_5; }
	inline void set_contestManagerStatePlay_5(VP_1_t3537971637 * value)
	{
		___contestManagerStatePlay_5 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_5, value);
	}

	inline static int32_t get_offset_of_btnForceEnd_6() { return static_cast<int32_t>(offsetof(UIData_t2965317152, ___btnForceEnd_6)); }
	inline VP_1_t2046531374 * get_btnForceEnd_6() const { return ___btnForceEnd_6; }
	inline VP_1_t2046531374 ** get_address_of_btnForceEnd_6() { return &___btnForceEnd_6; }
	inline void set_btnForceEnd_6(VP_1_t2046531374 * value)
	{
		___btnForceEnd_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnForceEnd_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
