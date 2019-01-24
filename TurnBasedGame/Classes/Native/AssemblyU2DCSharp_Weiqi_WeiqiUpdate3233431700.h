#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1359581430.h"

// Weiqi.WeiqiUpdate/UpdateData
struct UpdateData_t124194839;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.WeiqiUpdate
struct  WeiqiUpdate_t3233431700  : public UpdateBehavior_1_t1359581430
{
public:
	// Weiqi.WeiqiUpdate/UpdateData Weiqi.WeiqiUpdate::updateData
	UpdateData_t124194839 * ___updateData_4;
	// AdvancedCoroutines.Routine Weiqi.WeiqiUpdate::updateScoreRoutine
	Routine_t2502590640 * ___updateScoreRoutine_5;
	// System.Boolean Weiqi.WeiqiUpdate::haveChange
	bool ___haveChange_6;

public:
	inline static int32_t get_offset_of_updateData_4() { return static_cast<int32_t>(offsetof(WeiqiUpdate_t3233431700, ___updateData_4)); }
	inline UpdateData_t124194839 * get_updateData_4() const { return ___updateData_4; }
	inline UpdateData_t124194839 ** get_address_of_updateData_4() { return &___updateData_4; }
	inline void set_updateData_4(UpdateData_t124194839 * value)
	{
		___updateData_4 = value;
		Il2CppCodeGenWriteBarrier(&___updateData_4, value);
	}

	inline static int32_t get_offset_of_updateScoreRoutine_5() { return static_cast<int32_t>(offsetof(WeiqiUpdate_t3233431700, ___updateScoreRoutine_5)); }
	inline Routine_t2502590640 * get_updateScoreRoutine_5() const { return ___updateScoreRoutine_5; }
	inline Routine_t2502590640 ** get_address_of_updateScoreRoutine_5() { return &___updateScoreRoutine_5; }
	inline void set_updateScoreRoutine_5(Routine_t2502590640 * value)
	{
		___updateScoreRoutine_5 = value;
		Il2CppCodeGenWriteBarrier(&___updateScoreRoutine_5, value);
	}

	inline static int32_t get_offset_of_haveChange_6() { return static_cast<int32_t>(offsetof(WeiqiUpdate_t3233431700, ___haveChange_6)); }
	inline bool get_haveChange_6() const { return ___haveChange_6; }
	inline bool* get_address_of_haveChange_6() { return &___haveChange_6; }
	inline void set_haveChange_6(bool value)
	{
		___haveChange_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
