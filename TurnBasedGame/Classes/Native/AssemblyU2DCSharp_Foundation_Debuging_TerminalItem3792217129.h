#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AssemblyU2DCSharp_Foundation_Debuging_TerminalType1526967962.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Debuging.TerminalItem
struct  TerminalItem_t3792217129 
{
public:
	// System.String Foundation.Debuging.TerminalItem::_text
	String_t* ____text_0;
	// System.String Foundation.Debuging.TerminalItem::_formatted
	String_t* ____formatted_1;
	// Foundation.Debuging.TerminalType Foundation.Debuging.TerminalItem::_type
	int32_t ____type_2;
	// UnityEngine.Color Foundation.Debuging.TerminalItem::_color
	Color_t2020392075  ____color_3;

public:
	inline static int32_t get_offset_of__text_0() { return static_cast<int32_t>(offsetof(TerminalItem_t3792217129, ____text_0)); }
	inline String_t* get__text_0() const { return ____text_0; }
	inline String_t** get_address_of__text_0() { return &____text_0; }
	inline void set__text_0(String_t* value)
	{
		____text_0 = value;
		Il2CppCodeGenWriteBarrier(&____text_0, value);
	}

	inline static int32_t get_offset_of__formatted_1() { return static_cast<int32_t>(offsetof(TerminalItem_t3792217129, ____formatted_1)); }
	inline String_t* get__formatted_1() const { return ____formatted_1; }
	inline String_t** get_address_of__formatted_1() { return &____formatted_1; }
	inline void set__formatted_1(String_t* value)
	{
		____formatted_1 = value;
		Il2CppCodeGenWriteBarrier(&____formatted_1, value);
	}

	inline static int32_t get_offset_of__type_2() { return static_cast<int32_t>(offsetof(TerminalItem_t3792217129, ____type_2)); }
	inline int32_t get__type_2() const { return ____type_2; }
	inline int32_t* get_address_of__type_2() { return &____type_2; }
	inline void set__type_2(int32_t value)
	{
		____type_2 = value;
	}

	inline static int32_t get_offset_of__color_3() { return static_cast<int32_t>(offsetof(TerminalItem_t3792217129, ____color_3)); }
	inline Color_t2020392075  get__color_3() const { return ____color_3; }
	inline Color_t2020392075 * get_address_of__color_3() { return &____color_3; }
	inline void set__color_3(Color_t2020392075  value)
	{
		____color_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of Foundation.Debuging.TerminalItem
struct TerminalItem_t3792217129_marshaled_pinvoke
{
	char* ____text_0;
	char* ____formatted_1;
	int32_t ____type_2;
	Color_t2020392075  ____color_3;
};
// Native definition for COM marshalling of Foundation.Debuging.TerminalItem
struct TerminalItem_t3792217129_marshaled_com
{
	Il2CppChar* ____text_0;
	Il2CppChar* ____formatted_1;
	int32_t ____type_2;
	Color_t2020392075  ____color_3;
};
