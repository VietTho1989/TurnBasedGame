#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Xml.XmlParserInput
struct XmlParserInput_t2366782760;
// System.Collections.Stack
struct Stack_t1043988394;
// System.Char[]
struct CharU5BU5D_t1328083999;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;
// System.String
struct String_t;
// Mono.Xml.DTDObjectModel
struct DTDObjectModel_t1113953282;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.DTDReader
struct  DTDReader_t2453137441  : public Il2CppObject
{
public:
	// System.Xml.XmlParserInput System.Xml.DTDReader::currentInput
	XmlParserInput_t2366782760 * ___currentInput_0;
	// System.Collections.Stack System.Xml.DTDReader::parserInputStack
	Stack_t1043988394 * ___parserInputStack_1;
	// System.Char[] System.Xml.DTDReader::nameBuffer
	CharU5BU5D_t1328083999* ___nameBuffer_2;
	// System.Int32 System.Xml.DTDReader::nameLength
	int32_t ___nameLength_3;
	// System.Int32 System.Xml.DTDReader::nameCapacity
	int32_t ___nameCapacity_4;
	// System.Text.StringBuilder System.Xml.DTDReader::valueBuffer
	StringBuilder_t1221177846 * ___valueBuffer_5;
	// System.Int32 System.Xml.DTDReader::currentLinkedNodeLineNumber
	int32_t ___currentLinkedNodeLineNumber_6;
	// System.Int32 System.Xml.DTDReader::currentLinkedNodeLinePosition
	int32_t ___currentLinkedNodeLinePosition_7;
	// System.Int32 System.Xml.DTDReader::dtdIncludeSect
	int32_t ___dtdIncludeSect_8;
	// System.Boolean System.Xml.DTDReader::normalization
	bool ___normalization_9;
	// System.Boolean System.Xml.DTDReader::processingInternalSubset
	bool ___processingInternalSubset_10;
	// System.String System.Xml.DTDReader::cachedPublicId
	String_t* ___cachedPublicId_11;
	// System.String System.Xml.DTDReader::cachedSystemId
	String_t* ___cachedSystemId_12;
	// Mono.Xml.DTDObjectModel System.Xml.DTDReader::DTD
	DTDObjectModel_t1113953282 * ___DTD_13;

public:
	inline static int32_t get_offset_of_currentInput_0() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___currentInput_0)); }
	inline XmlParserInput_t2366782760 * get_currentInput_0() const { return ___currentInput_0; }
	inline XmlParserInput_t2366782760 ** get_address_of_currentInput_0() { return &___currentInput_0; }
	inline void set_currentInput_0(XmlParserInput_t2366782760 * value)
	{
		___currentInput_0 = value;
		Il2CppCodeGenWriteBarrier(&___currentInput_0, value);
	}

	inline static int32_t get_offset_of_parserInputStack_1() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___parserInputStack_1)); }
	inline Stack_t1043988394 * get_parserInputStack_1() const { return ___parserInputStack_1; }
	inline Stack_t1043988394 ** get_address_of_parserInputStack_1() { return &___parserInputStack_1; }
	inline void set_parserInputStack_1(Stack_t1043988394 * value)
	{
		___parserInputStack_1 = value;
		Il2CppCodeGenWriteBarrier(&___parserInputStack_1, value);
	}

	inline static int32_t get_offset_of_nameBuffer_2() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___nameBuffer_2)); }
	inline CharU5BU5D_t1328083999* get_nameBuffer_2() const { return ___nameBuffer_2; }
	inline CharU5BU5D_t1328083999** get_address_of_nameBuffer_2() { return &___nameBuffer_2; }
	inline void set_nameBuffer_2(CharU5BU5D_t1328083999* value)
	{
		___nameBuffer_2 = value;
		Il2CppCodeGenWriteBarrier(&___nameBuffer_2, value);
	}

	inline static int32_t get_offset_of_nameLength_3() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___nameLength_3)); }
	inline int32_t get_nameLength_3() const { return ___nameLength_3; }
	inline int32_t* get_address_of_nameLength_3() { return &___nameLength_3; }
	inline void set_nameLength_3(int32_t value)
	{
		___nameLength_3 = value;
	}

	inline static int32_t get_offset_of_nameCapacity_4() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___nameCapacity_4)); }
	inline int32_t get_nameCapacity_4() const { return ___nameCapacity_4; }
	inline int32_t* get_address_of_nameCapacity_4() { return &___nameCapacity_4; }
	inline void set_nameCapacity_4(int32_t value)
	{
		___nameCapacity_4 = value;
	}

	inline static int32_t get_offset_of_valueBuffer_5() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___valueBuffer_5)); }
	inline StringBuilder_t1221177846 * get_valueBuffer_5() const { return ___valueBuffer_5; }
	inline StringBuilder_t1221177846 ** get_address_of_valueBuffer_5() { return &___valueBuffer_5; }
	inline void set_valueBuffer_5(StringBuilder_t1221177846 * value)
	{
		___valueBuffer_5 = value;
		Il2CppCodeGenWriteBarrier(&___valueBuffer_5, value);
	}

	inline static int32_t get_offset_of_currentLinkedNodeLineNumber_6() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___currentLinkedNodeLineNumber_6)); }
	inline int32_t get_currentLinkedNodeLineNumber_6() const { return ___currentLinkedNodeLineNumber_6; }
	inline int32_t* get_address_of_currentLinkedNodeLineNumber_6() { return &___currentLinkedNodeLineNumber_6; }
	inline void set_currentLinkedNodeLineNumber_6(int32_t value)
	{
		___currentLinkedNodeLineNumber_6 = value;
	}

	inline static int32_t get_offset_of_currentLinkedNodeLinePosition_7() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___currentLinkedNodeLinePosition_7)); }
	inline int32_t get_currentLinkedNodeLinePosition_7() const { return ___currentLinkedNodeLinePosition_7; }
	inline int32_t* get_address_of_currentLinkedNodeLinePosition_7() { return &___currentLinkedNodeLinePosition_7; }
	inline void set_currentLinkedNodeLinePosition_7(int32_t value)
	{
		___currentLinkedNodeLinePosition_7 = value;
	}

	inline static int32_t get_offset_of_dtdIncludeSect_8() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___dtdIncludeSect_8)); }
	inline int32_t get_dtdIncludeSect_8() const { return ___dtdIncludeSect_8; }
	inline int32_t* get_address_of_dtdIncludeSect_8() { return &___dtdIncludeSect_8; }
	inline void set_dtdIncludeSect_8(int32_t value)
	{
		___dtdIncludeSect_8 = value;
	}

	inline static int32_t get_offset_of_normalization_9() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___normalization_9)); }
	inline bool get_normalization_9() const { return ___normalization_9; }
	inline bool* get_address_of_normalization_9() { return &___normalization_9; }
	inline void set_normalization_9(bool value)
	{
		___normalization_9 = value;
	}

	inline static int32_t get_offset_of_processingInternalSubset_10() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___processingInternalSubset_10)); }
	inline bool get_processingInternalSubset_10() const { return ___processingInternalSubset_10; }
	inline bool* get_address_of_processingInternalSubset_10() { return &___processingInternalSubset_10; }
	inline void set_processingInternalSubset_10(bool value)
	{
		___processingInternalSubset_10 = value;
	}

	inline static int32_t get_offset_of_cachedPublicId_11() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___cachedPublicId_11)); }
	inline String_t* get_cachedPublicId_11() const { return ___cachedPublicId_11; }
	inline String_t** get_address_of_cachedPublicId_11() { return &___cachedPublicId_11; }
	inline void set_cachedPublicId_11(String_t* value)
	{
		___cachedPublicId_11 = value;
		Il2CppCodeGenWriteBarrier(&___cachedPublicId_11, value);
	}

	inline static int32_t get_offset_of_cachedSystemId_12() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___cachedSystemId_12)); }
	inline String_t* get_cachedSystemId_12() const { return ___cachedSystemId_12; }
	inline String_t** get_address_of_cachedSystemId_12() { return &___cachedSystemId_12; }
	inline void set_cachedSystemId_12(String_t* value)
	{
		___cachedSystemId_12 = value;
		Il2CppCodeGenWriteBarrier(&___cachedSystemId_12, value);
	}

	inline static int32_t get_offset_of_DTD_13() { return static_cast<int32_t>(offsetof(DTDReader_t2453137441, ___DTD_13)); }
	inline DTDObjectModel_t1113953282 * get_DTD_13() const { return ___DTD_13; }
	inline DTDObjectModel_t1113953282 ** get_address_of_DTD_13() { return &___DTD_13; }
	inline void set_DTD_13(DTDObjectModel_t1113953282 * value)
	{
		___DTD_13 = value;
		Il2CppCodeGenWriteBarrier(&___DTD_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
