#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<Posture.PostureGameData>>
struct VP_1_t261246817;
// VP`1<MiniGameDataUI/UIData>
struct VP_1_t1885838056;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.ChoosePostureHolder/UIData
struct  UIData_t430305686  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<Posture.PostureGameData>> Posture.ChoosePostureHolder/UIData::postureGameData
	VP_1_t261246817 * ___postureGameData_8;
	// VP`1<MiniGameDataUI/UIData> Posture.ChoosePostureHolder/UIData::miniGameDataUI
	VP_1_t1885838056 * ___miniGameDataUI_9;

public:
	inline static int32_t get_offset_of_postureGameData_8() { return static_cast<int32_t>(offsetof(UIData_t430305686, ___postureGameData_8)); }
	inline VP_1_t261246817 * get_postureGameData_8() const { return ___postureGameData_8; }
	inline VP_1_t261246817 ** get_address_of_postureGameData_8() { return &___postureGameData_8; }
	inline void set_postureGameData_8(VP_1_t261246817 * value)
	{
		___postureGameData_8 = value;
		Il2CppCodeGenWriteBarrier(&___postureGameData_8, value);
	}

	inline static int32_t get_offset_of_miniGameDataUI_9() { return static_cast<int32_t>(offsetof(UIData_t430305686, ___miniGameDataUI_9)); }
	inline VP_1_t1885838056 * get_miniGameDataUI_9() const { return ___miniGameDataUI_9; }
	inline VP_1_t1885838056 ** get_address_of_miniGameDataUI_9() { return &___miniGameDataUI_9; }
	inline void set_miniGameDataUI_9(VP_1_t1885838056 * value)
	{
		___miniGameDataUI_9 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUI_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
