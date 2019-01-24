#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlReader3675626668.h"

// System.Xml.XmlReader
struct XmlReader_t3675626668;
// System.Xml.Schema.ValidationEventHandler
struct ValidationEventHandler_t1580700381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaReader
struct  XmlSchemaReader_t3786681597  : public XmlReader_t3675626668
{
public:
	// System.Xml.XmlReader System.Xml.Schema.XmlSchemaReader::reader
	XmlReader_t3675626668 * ___reader_2;
	// System.Xml.Schema.ValidationEventHandler System.Xml.Schema.XmlSchemaReader::handler
	ValidationEventHandler_t1580700381 * ___handler_3;
	// System.Boolean System.Xml.Schema.XmlSchemaReader::hasLineInfo
	bool ___hasLineInfo_4;

public:
	inline static int32_t get_offset_of_reader_2() { return static_cast<int32_t>(offsetof(XmlSchemaReader_t3786681597, ___reader_2)); }
	inline XmlReader_t3675626668 * get_reader_2() const { return ___reader_2; }
	inline XmlReader_t3675626668 ** get_address_of_reader_2() { return &___reader_2; }
	inline void set_reader_2(XmlReader_t3675626668 * value)
	{
		___reader_2 = value;
		Il2CppCodeGenWriteBarrier(&___reader_2, value);
	}

	inline static int32_t get_offset_of_handler_3() { return static_cast<int32_t>(offsetof(XmlSchemaReader_t3786681597, ___handler_3)); }
	inline ValidationEventHandler_t1580700381 * get_handler_3() const { return ___handler_3; }
	inline ValidationEventHandler_t1580700381 ** get_address_of_handler_3() { return &___handler_3; }
	inline void set_handler_3(ValidationEventHandler_t1580700381 * value)
	{
		___handler_3 = value;
		Il2CppCodeGenWriteBarrier(&___handler_3, value);
	}

	inline static int32_t get_offset_of_hasLineInfo_4() { return static_cast<int32_t>(offsetof(XmlSchemaReader_t3786681597, ___hasLineInfo_4)); }
	inline bool get_hasLineInfo_4() const { return ___hasLineInfo_4; }
	inline bool* get_address_of_hasLineInfo_4() { return &___hasLineInfo_4; }
	inline void set_hasLineInfo_4(bool value)
	{
		___hasLineInfo_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
