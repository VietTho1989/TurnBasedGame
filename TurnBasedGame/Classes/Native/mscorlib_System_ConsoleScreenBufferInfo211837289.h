#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "mscorlib_System_Coord151819767.h"
#include "mscorlib_System_SmallRect2523714067.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ConsoleScreenBufferInfo
struct  ConsoleScreenBufferInfo_t211837289 
{
public:
	// System.Coord System.ConsoleScreenBufferInfo::Size
	Coord_t151819767  ___Size_0;
	// System.Coord System.ConsoleScreenBufferInfo::CursorPosition
	Coord_t151819767  ___CursorPosition_1;
	// System.Int16 System.ConsoleScreenBufferInfo::Attribute
	int16_t ___Attribute_2;
	// System.SmallRect System.ConsoleScreenBufferInfo::Window
	SmallRect_t2523714067  ___Window_3;
	// System.Coord System.ConsoleScreenBufferInfo::MaxWindowSize
	Coord_t151819767  ___MaxWindowSize_4;

public:
	inline static int32_t get_offset_of_Size_0() { return static_cast<int32_t>(offsetof(ConsoleScreenBufferInfo_t211837289, ___Size_0)); }
	inline Coord_t151819767  get_Size_0() const { return ___Size_0; }
	inline Coord_t151819767 * get_address_of_Size_0() { return &___Size_0; }
	inline void set_Size_0(Coord_t151819767  value)
	{
		___Size_0 = value;
	}

	inline static int32_t get_offset_of_CursorPosition_1() { return static_cast<int32_t>(offsetof(ConsoleScreenBufferInfo_t211837289, ___CursorPosition_1)); }
	inline Coord_t151819767  get_CursorPosition_1() const { return ___CursorPosition_1; }
	inline Coord_t151819767 * get_address_of_CursorPosition_1() { return &___CursorPosition_1; }
	inline void set_CursorPosition_1(Coord_t151819767  value)
	{
		___CursorPosition_1 = value;
	}

	inline static int32_t get_offset_of_Attribute_2() { return static_cast<int32_t>(offsetof(ConsoleScreenBufferInfo_t211837289, ___Attribute_2)); }
	inline int16_t get_Attribute_2() const { return ___Attribute_2; }
	inline int16_t* get_address_of_Attribute_2() { return &___Attribute_2; }
	inline void set_Attribute_2(int16_t value)
	{
		___Attribute_2 = value;
	}

	inline static int32_t get_offset_of_Window_3() { return static_cast<int32_t>(offsetof(ConsoleScreenBufferInfo_t211837289, ___Window_3)); }
	inline SmallRect_t2523714067  get_Window_3() const { return ___Window_3; }
	inline SmallRect_t2523714067 * get_address_of_Window_3() { return &___Window_3; }
	inline void set_Window_3(SmallRect_t2523714067  value)
	{
		___Window_3 = value;
	}

	inline static int32_t get_offset_of_MaxWindowSize_4() { return static_cast<int32_t>(offsetof(ConsoleScreenBufferInfo_t211837289, ___MaxWindowSize_4)); }
	inline Coord_t151819767  get_MaxWindowSize_4() const { return ___MaxWindowSize_4; }
	inline Coord_t151819767 * get_address_of_MaxWindowSize_4() { return &___MaxWindowSize_4; }
	inline void set_MaxWindowSize_4(Coord_t151819767  value)
	{
		___MaxWindowSize_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
