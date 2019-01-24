#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<Room>>
struct VP_1_t491458442;
// LP`1<GameManager.Match.ChooseContestManagerHolder/UIData>
struct LP_1_t1643300613;
// System.Collections.Generic.List`1<GameManager.Match.ContestManager>
struct List_1_t1059372165;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerAdapter/UIData
struct  UIData_t2613184216  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<Room>> GameManager.Match.ChooseContestManagerAdapter/UIData::room
	VP_1_t491458442 * ___room_20;
	// LP`1<GameManager.Match.ChooseContestManagerHolder/UIData> GameManager.Match.ChooseContestManagerAdapter/UIData::holders
	LP_1_t1643300613 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.ContestManager> GameManager.Match.ChooseContestManagerAdapter/UIData::contestManagers
	List_1_t1059372165 * ___contestManagers_22;

public:
	inline static int32_t get_offset_of_room_20() { return static_cast<int32_t>(offsetof(UIData_t2613184216, ___room_20)); }
	inline VP_1_t491458442 * get_room_20() const { return ___room_20; }
	inline VP_1_t491458442 ** get_address_of_room_20() { return &___room_20; }
	inline void set_room_20(VP_1_t491458442 * value)
	{
		___room_20 = value;
		Il2CppCodeGenWriteBarrier(&___room_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t2613184216, ___holders_21)); }
	inline LP_1_t1643300613 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t1643300613 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t1643300613 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_contestManagers_22() { return static_cast<int32_t>(offsetof(UIData_t2613184216, ___contestManagers_22)); }
	inline List_1_t1059372165 * get_contestManagers_22() const { return ___contestManagers_22; }
	inline List_1_t1059372165 ** get_address_of_contestManagers_22() { return &___contestManagers_22; }
	inline void set_contestManagers_22(List_1_t1059372165 * value)
	{
		___contestManagers_22 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagers_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
