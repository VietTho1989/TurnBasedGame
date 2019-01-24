#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Hint.HintUI/UIData
struct UIData_t3227164199;
// GameMove
struct GameMove_t1861898997;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Hint.HintUpdate/Work
struct  Work_t471323003  : public Il2CppObject
{
public:
	// Hint.HintUI/UIData Hint.HintUpdate/Work::data
	UIData_t3227164199 * ___data_0;
	// GameMove Hint.HintUpdate/Work::hintMove
	GameMove_t1861898997 * ___hintMove_1;
	// System.Boolean Hint.HintUpdate/Work::isDone
	bool ___isDone_2;

public:
	inline static int32_t get_offset_of_data_0() { return static_cast<int32_t>(offsetof(Work_t471323003, ___data_0)); }
	inline UIData_t3227164199 * get_data_0() const { return ___data_0; }
	inline UIData_t3227164199 ** get_address_of_data_0() { return &___data_0; }
	inline void set_data_0(UIData_t3227164199 * value)
	{
		___data_0 = value;
		Il2CppCodeGenWriteBarrier(&___data_0, value);
	}

	inline static int32_t get_offset_of_hintMove_1() { return static_cast<int32_t>(offsetof(Work_t471323003, ___hintMove_1)); }
	inline GameMove_t1861898997 * get_hintMove_1() const { return ___hintMove_1; }
	inline GameMove_t1861898997 ** get_address_of_hintMove_1() { return &___hintMove_1; }
	inline void set_hintMove_1(GameMove_t1861898997 * value)
	{
		___hintMove_1 = value;
		Il2CppCodeGenWriteBarrier(&___hintMove_1, value);
	}

	inline static int32_t get_offset_of_isDone_2() { return static_cast<int32_t>(offsetof(Work_t471323003, ___isDone_2)); }
	inline bool get_isDone_2() const { return ___isDone_2; }
	inline bool* get_address_of_isDone_2() { return &___isDone_2; }
	inline void set_isDone_2(bool value)
	{
		___isDone_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
