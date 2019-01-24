#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IConsoleDriver
struct IConsoleDriver_t31582726;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ConsoleDriver
struct  ConsoleDriver_t2410871357  : public Il2CppObject
{
public:

public:
};

struct ConsoleDriver_t2410871357_StaticFields
{
public:
	// System.IConsoleDriver System.ConsoleDriver::driver
	Il2CppObject * ___driver_0;
	// System.Boolean System.ConsoleDriver::is_console
	bool ___is_console_1;
	// System.Boolean System.ConsoleDriver::called_isatty
	bool ___called_isatty_2;

public:
	inline static int32_t get_offset_of_driver_0() { return static_cast<int32_t>(offsetof(ConsoleDriver_t2410871357_StaticFields, ___driver_0)); }
	inline Il2CppObject * get_driver_0() const { return ___driver_0; }
	inline Il2CppObject ** get_address_of_driver_0() { return &___driver_0; }
	inline void set_driver_0(Il2CppObject * value)
	{
		___driver_0 = value;
		Il2CppCodeGenWriteBarrier(&___driver_0, value);
	}

	inline static int32_t get_offset_of_is_console_1() { return static_cast<int32_t>(offsetof(ConsoleDriver_t2410871357_StaticFields, ___is_console_1)); }
	inline bool get_is_console_1() const { return ___is_console_1; }
	inline bool* get_address_of_is_console_1() { return &___is_console_1; }
	inline void set_is_console_1(bool value)
	{
		___is_console_1 = value;
	}

	inline static int32_t get_offset_of_called_isatty_2() { return static_cast<int32_t>(offsetof(ConsoleDriver_t2410871357_StaticFields, ___called_isatty_2)); }
	inline bool get_called_isatty_2() const { return ___called_isatty_2; }
	inline bool* get_address_of_called_isatty_2() { return &___called_isatty_2; }
	inline void set_called_isatty_2(bool value)
	{
		___called_isatty_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
