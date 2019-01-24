#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManager2502320201.h"

// VP`1<ReferenceData`1<GameManager.Match.SingleContestContent>>
struct VP_1_t1702265922;
// VP`1<GameManager.Match.ContestUI/UIData>
struct VP_1_t584350433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.SingleContestContentUI/UIData
struct  UIData_t2151494422  : public UIData_t2502320201
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.SingleContestContent>> GameManager.Match.SingleContestContentUI/UIData::singleContestContent
	VP_1_t1702265922 * ___singleContestContent_5;
	// VP`1<GameManager.Match.ContestUI/UIData> GameManager.Match.SingleContestContentUI/UIData::contestUIData
	VP_1_t584350433 * ___contestUIData_6;

public:
	inline static int32_t get_offset_of_singleContestContent_5() { return static_cast<int32_t>(offsetof(UIData_t2151494422, ___singleContestContent_5)); }
	inline VP_1_t1702265922 * get_singleContestContent_5() const { return ___singleContestContent_5; }
	inline VP_1_t1702265922 ** get_address_of_singleContestContent_5() { return &___singleContestContent_5; }
	inline void set_singleContestContent_5(VP_1_t1702265922 * value)
	{
		___singleContestContent_5 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestContent_5, value);
	}

	inline static int32_t get_offset_of_contestUIData_6() { return static_cast<int32_t>(offsetof(UIData_t2151494422, ___contestUIData_6)); }
	inline VP_1_t584350433 * get_contestUIData_6() const { return ___contestUIData_6; }
	inline VP_1_t584350433 ** get_address_of_contestUIData_6() { return &___contestUIData_6; }
	inline void set_contestUIData_6(VP_1_t584350433 * value)
	{
		___contestUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___contestUIData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
