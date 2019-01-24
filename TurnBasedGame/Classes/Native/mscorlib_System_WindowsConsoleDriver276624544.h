#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_IntPtr2504060609.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.WindowsConsoleDriver
struct  WindowsConsoleDriver_t276624544  : public Il2CppObject
{
public:
	// System.IntPtr System.WindowsConsoleDriver::inputHandle
	IntPtr_t ___inputHandle_0;
	// System.IntPtr System.WindowsConsoleDriver::outputHandle
	IntPtr_t ___outputHandle_1;
	// System.Int16 System.WindowsConsoleDriver::defaultAttribute
	int16_t ___defaultAttribute_2;

public:
	inline static int32_t get_offset_of_inputHandle_0() { return static_cast<int32_t>(offsetof(WindowsConsoleDriver_t276624544, ___inputHandle_0)); }
	inline IntPtr_t get_inputHandle_0() const { return ___inputHandle_0; }
	inline IntPtr_t* get_address_of_inputHandle_0() { return &___inputHandle_0; }
	inline void set_inputHandle_0(IntPtr_t value)
	{
		___inputHandle_0 = value;
	}

	inline static int32_t get_offset_of_outputHandle_1() { return static_cast<int32_t>(offsetof(WindowsConsoleDriver_t276624544, ___outputHandle_1)); }
	inline IntPtr_t get_outputHandle_1() const { return ___outputHandle_1; }
	inline IntPtr_t* get_address_of_outputHandle_1() { return &___outputHandle_1; }
	inline void set_outputHandle_1(IntPtr_t value)
	{
		___outputHandle_1 = value;
	}

	inline static int32_t get_offset_of_defaultAttribute_2() { return static_cast<int32_t>(offsetof(WindowsConsoleDriver_t276624544, ___defaultAttribute_2)); }
	inline int16_t get_defaultAttribute_2() const { return ___defaultAttribute_2; }
	inline int16_t* get_address_of_defaultAttribute_2() { return &___defaultAttribute_2; }
	inline void set_defaultAttribute_2(int16_t value)
	{
		___defaultAttribute_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
