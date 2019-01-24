#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Room>>
struct VP_1_t491458442;
// VP`1<GameManager.Match.ChooseContestManagerAdapter/UIData>
struct VP_1_t2991461222;
// VP`1<GameManager.Match.ContestManagerInformUI/UIData>
struct VP_1_t2665399855;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerUI/UIData
struct  UIData_t2217132405  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Room>> GameManager.Match.ChooseContestManagerUI/UIData::room
	VP_1_t491458442 * ___room_5;
	// VP`1<GameManager.Match.ChooseContestManagerAdapter/UIData> GameManager.Match.ChooseContestManagerUI/UIData::chooseContestManagerAdapter
	VP_1_t2991461222 * ___chooseContestManagerAdapter_6;
	// VP`1<GameManager.Match.ContestManagerInformUI/UIData> GameManager.Match.ChooseContestManagerUI/UIData::currentContestManagerInform
	VP_1_t2665399855 * ___currentContestManagerInform_7;

public:
	inline static int32_t get_offset_of_room_5() { return static_cast<int32_t>(offsetof(UIData_t2217132405, ___room_5)); }
	inline VP_1_t491458442 * get_room_5() const { return ___room_5; }
	inline VP_1_t491458442 ** get_address_of_room_5() { return &___room_5; }
	inline void set_room_5(VP_1_t491458442 * value)
	{
		___room_5 = value;
		Il2CppCodeGenWriteBarrier(&___room_5, value);
	}

	inline static int32_t get_offset_of_chooseContestManagerAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t2217132405, ___chooseContestManagerAdapter_6)); }
	inline VP_1_t2991461222 * get_chooseContestManagerAdapter_6() const { return ___chooseContestManagerAdapter_6; }
	inline VP_1_t2991461222 ** get_address_of_chooseContestManagerAdapter_6() { return &___chooseContestManagerAdapter_6; }
	inline void set_chooseContestManagerAdapter_6(VP_1_t2991461222 * value)
	{
		___chooseContestManagerAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseContestManagerAdapter_6, value);
	}

	inline static int32_t get_offset_of_currentContestManagerInform_7() { return static_cast<int32_t>(offsetof(UIData_t2217132405, ___currentContestManagerInform_7)); }
	inline VP_1_t2665399855 * get_currentContestManagerInform_7() const { return ___currentContestManagerInform_7; }
	inline VP_1_t2665399855 ** get_address_of_currentContestManagerInform_7() { return &___currentContestManagerInform_7; }
	inline void set_currentContestManagerInform_7(VP_1_t2665399855 * value)
	{
		___currentContestManagerInform_7 = value;
		Il2CppCodeGenWriteBarrier(&___currentContestManagerInform_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
