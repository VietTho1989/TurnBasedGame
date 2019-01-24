#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// WaitAIInputSearch
struct WaitAIInputSearch_t846335217;
// GameMove
struct GameMove_t1861898997;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitAIInputSearchUpdate/Work
struct  Work_t3291824404  : public Il2CppObject
{
public:
	// WaitAIInputSearch WaitAIInputSearchUpdate/Work::data
	WaitAIInputSearch_t846335217 * ___data_0;
	// GameMove WaitAIInputSearchUpdate/Work::aiMove
	GameMove_t1861898997 * ___aiMove_1;
	// System.Boolean WaitAIInputSearchUpdate/Work::isDone
	bool ___isDone_2;

public:
	inline static int32_t get_offset_of_data_0() { return static_cast<int32_t>(offsetof(Work_t3291824404, ___data_0)); }
	inline WaitAIInputSearch_t846335217 * get_data_0() const { return ___data_0; }
	inline WaitAIInputSearch_t846335217 ** get_address_of_data_0() { return &___data_0; }
	inline void set_data_0(WaitAIInputSearch_t846335217 * value)
	{
		___data_0 = value;
		Il2CppCodeGenWriteBarrier(&___data_0, value);
	}

	inline static int32_t get_offset_of_aiMove_1() { return static_cast<int32_t>(offsetof(Work_t3291824404, ___aiMove_1)); }
	inline GameMove_t1861898997 * get_aiMove_1() const { return ___aiMove_1; }
	inline GameMove_t1861898997 ** get_address_of_aiMove_1() { return &___aiMove_1; }
	inline void set_aiMove_1(GameMove_t1861898997 * value)
	{
		___aiMove_1 = value;
		Il2CppCodeGenWriteBarrier(&___aiMove_1, value);
	}

	inline static int32_t get_offset_of_isDone_2() { return static_cast<int32_t>(offsetof(Work_t3291824404, ___isDone_2)); }
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
