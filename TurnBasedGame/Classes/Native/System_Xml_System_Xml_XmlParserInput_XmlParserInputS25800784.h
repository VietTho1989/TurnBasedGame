#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.IO.TextReader
struct TextReader_t1561828458;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlParserInput/XmlParserInputSource
struct  XmlParserInputSource_t25800784  : public Il2CppObject
{
public:
	// System.String System.Xml.XmlParserInput/XmlParserInputSource::BaseURI
	String_t* ___BaseURI_0;
	// System.IO.TextReader System.Xml.XmlParserInput/XmlParserInputSource::reader
	TextReader_t1561828458 * ___reader_1;
	// System.Int32 System.Xml.XmlParserInput/XmlParserInputSource::state
	int32_t ___state_2;
	// System.Boolean System.Xml.XmlParserInput/XmlParserInputSource::isPE
	bool ___isPE_3;
	// System.Int32 System.Xml.XmlParserInput/XmlParserInputSource::line
	int32_t ___line_4;
	// System.Int32 System.Xml.XmlParserInput/XmlParserInputSource::column
	int32_t ___column_5;

public:
	inline static int32_t get_offset_of_BaseURI_0() { return static_cast<int32_t>(offsetof(XmlParserInputSource_t25800784, ___BaseURI_0)); }
	inline String_t* get_BaseURI_0() const { return ___BaseURI_0; }
	inline String_t** get_address_of_BaseURI_0() { return &___BaseURI_0; }
	inline void set_BaseURI_0(String_t* value)
	{
		___BaseURI_0 = value;
		Il2CppCodeGenWriteBarrier(&___BaseURI_0, value);
	}

	inline static int32_t get_offset_of_reader_1() { return static_cast<int32_t>(offsetof(XmlParserInputSource_t25800784, ___reader_1)); }
	inline TextReader_t1561828458 * get_reader_1() const { return ___reader_1; }
	inline TextReader_t1561828458 ** get_address_of_reader_1() { return &___reader_1; }
	inline void set_reader_1(TextReader_t1561828458 * value)
	{
		___reader_1 = value;
		Il2CppCodeGenWriteBarrier(&___reader_1, value);
	}

	inline static int32_t get_offset_of_state_2() { return static_cast<int32_t>(offsetof(XmlParserInputSource_t25800784, ___state_2)); }
	inline int32_t get_state_2() const { return ___state_2; }
	inline int32_t* get_address_of_state_2() { return &___state_2; }
	inline void set_state_2(int32_t value)
	{
		___state_2 = value;
	}

	inline static int32_t get_offset_of_isPE_3() { return static_cast<int32_t>(offsetof(XmlParserInputSource_t25800784, ___isPE_3)); }
	inline bool get_isPE_3() const { return ___isPE_3; }
	inline bool* get_address_of_isPE_3() { return &___isPE_3; }
	inline void set_isPE_3(bool value)
	{
		___isPE_3 = value;
	}

	inline static int32_t get_offset_of_line_4() { return static_cast<int32_t>(offsetof(XmlParserInputSource_t25800784, ___line_4)); }
	inline int32_t get_line_4() const { return ___line_4; }
	inline int32_t* get_address_of_line_4() { return &___line_4; }
	inline void set_line_4(int32_t value)
	{
		___line_4 = value;
	}

	inline static int32_t get_offset_of_column_5() { return static_cast<int32_t>(offsetof(XmlParserInputSource_t25800784, ___column_5)); }
	inline int32_t get_column_5() const { return ___column_5; }
	inline int32_t* get_address_of_column_5() { return &___column_5; }
	inline void set_column_5(int32_t value)
	{
		___column_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
