#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameObserver_CheckChange811089867.h"

// HistoryChange
struct HistoryChange_t53216192;
// History
struct History_t3838840324;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HistoryChangeObserver
struct  HistoryChangeObserver_t3801600806  : public CheckChange_t811089867
{
public:
	// HistoryChange HistoryChangeObserver::data
	HistoryChange_t53216192 * ___data_1;
	// History HistoryChangeObserver::history
	History_t3838840324 * ___history_2;

public:
	inline static int32_t get_offset_of_data_1() { return static_cast<int32_t>(offsetof(HistoryChangeObserver_t3801600806, ___data_1)); }
	inline HistoryChange_t53216192 * get_data_1() const { return ___data_1; }
	inline HistoryChange_t53216192 ** get_address_of_data_1() { return &___data_1; }
	inline void set_data_1(HistoryChange_t53216192 * value)
	{
		___data_1 = value;
		Il2CppCodeGenWriteBarrier(&___data_1, value);
	}

	inline static int32_t get_offset_of_history_2() { return static_cast<int32_t>(offsetof(HistoryChangeObserver_t3801600806, ___history_2)); }
	inline History_t3838840324 * get_history_2() const { return ___history_2; }
	inline History_t3838840324 ** get_address_of_history_2() { return &___history_2; }
	inline void set_history_2(History_t3838840324 * value)
	{
		___history_2 = value;
		Il2CppCodeGenWriteBarrier(&___history_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
