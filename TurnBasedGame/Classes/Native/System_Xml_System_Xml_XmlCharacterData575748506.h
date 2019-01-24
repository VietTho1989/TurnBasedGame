#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlLinkedNode1287616130.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlCharacterData
struct  XmlCharacterData_t575748506  : public XmlLinkedNode_t1287616130
{
public:
	// System.String System.Xml.XmlCharacterData::data
	String_t* ___data_6;

public:
	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(XmlCharacterData_t575748506, ___data_6)); }
	inline String_t* get_data_6() const { return ___data_6; }
	inline String_t** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(String_t* value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
