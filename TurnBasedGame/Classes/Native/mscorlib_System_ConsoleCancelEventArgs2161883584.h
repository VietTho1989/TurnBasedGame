#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"
#include "mscorlib_System_ConsoleSpecialKey2502349621.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ConsoleCancelEventArgs
struct  ConsoleCancelEventArgs_t2161883584  : public EventArgs_t3289624707
{
public:
	// System.Boolean System.ConsoleCancelEventArgs::cancel
	bool ___cancel_1;
	// System.ConsoleSpecialKey System.ConsoleCancelEventArgs::specialKey
	int32_t ___specialKey_2;

public:
	inline static int32_t get_offset_of_cancel_1() { return static_cast<int32_t>(offsetof(ConsoleCancelEventArgs_t2161883584, ___cancel_1)); }
	inline bool get_cancel_1() const { return ___cancel_1; }
	inline bool* get_address_of_cancel_1() { return &___cancel_1; }
	inline void set_cancel_1(bool value)
	{
		___cancel_1 = value;
	}

	inline static int32_t get_offset_of_specialKey_2() { return static_cast<int32_t>(offsetof(ConsoleCancelEventArgs_t2161883584, ___specialKey_2)); }
	inline int32_t get_specialKey_2() const { return ___specialKey_2; }
	inline int32_t* get_address_of_specialKey_2() { return &___specialKey_2; }
	inline void set_specialKey_2(int32_t value)
	{
		___specialKey_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
