#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Stack
struct Stack_t1043988394;
// System.Xml.XmlParserInput/XmlParserInputSource
struct XmlParserInputSource_t25800784;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlParserInput
struct  XmlParserInput_t2366782760  : public Il2CppObject
{
public:
	// System.Collections.Stack System.Xml.XmlParserInput::sourceStack
	Stack_t1043988394 * ___sourceStack_0;
	// System.Xml.XmlParserInput/XmlParserInputSource System.Xml.XmlParserInput::source
	XmlParserInputSource_t25800784 * ___source_1;
	// System.Boolean System.Xml.XmlParserInput::has_peek
	bool ___has_peek_2;
	// System.Int32 System.Xml.XmlParserInput::peek_char
	int32_t ___peek_char_3;
	// System.Boolean System.Xml.XmlParserInput::allowTextDecl
	bool ___allowTextDecl_4;

public:
	inline static int32_t get_offset_of_sourceStack_0() { return static_cast<int32_t>(offsetof(XmlParserInput_t2366782760, ___sourceStack_0)); }
	inline Stack_t1043988394 * get_sourceStack_0() const { return ___sourceStack_0; }
	inline Stack_t1043988394 ** get_address_of_sourceStack_0() { return &___sourceStack_0; }
	inline void set_sourceStack_0(Stack_t1043988394 * value)
	{
		___sourceStack_0 = value;
		Il2CppCodeGenWriteBarrier(&___sourceStack_0, value);
	}

	inline static int32_t get_offset_of_source_1() { return static_cast<int32_t>(offsetof(XmlParserInput_t2366782760, ___source_1)); }
	inline XmlParserInputSource_t25800784 * get_source_1() const { return ___source_1; }
	inline XmlParserInputSource_t25800784 ** get_address_of_source_1() { return &___source_1; }
	inline void set_source_1(XmlParserInputSource_t25800784 * value)
	{
		___source_1 = value;
		Il2CppCodeGenWriteBarrier(&___source_1, value);
	}

	inline static int32_t get_offset_of_has_peek_2() { return static_cast<int32_t>(offsetof(XmlParserInput_t2366782760, ___has_peek_2)); }
	inline bool get_has_peek_2() const { return ___has_peek_2; }
	inline bool* get_address_of_has_peek_2() { return &___has_peek_2; }
	inline void set_has_peek_2(bool value)
	{
		___has_peek_2 = value;
	}

	inline static int32_t get_offset_of_peek_char_3() { return static_cast<int32_t>(offsetof(XmlParserInput_t2366782760, ___peek_char_3)); }
	inline int32_t get_peek_char_3() const { return ___peek_char_3; }
	inline int32_t* get_address_of_peek_char_3() { return &___peek_char_3; }
	inline void set_peek_char_3(int32_t value)
	{
		___peek_char_3 = value;
	}

	inline static int32_t get_offset_of_allowTextDecl_4() { return static_cast<int32_t>(offsetof(XmlParserInput_t2366782760, ___allowTextDecl_4)); }
	inline bool get_allowTextDecl_4() const { return ___allowTextDecl_4; }
	inline bool* get_address_of_allowTextDecl_4() { return &___allowTextDecl_4; }
	inline void set_allowTextDecl_4(bool value)
	{
		___allowTextDecl_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
