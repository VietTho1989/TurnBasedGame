#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlTextReader3514170725.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ConfigXmlTextReader
struct  ConfigXmlTextReader_t3212066157  : public XmlTextReader_t3514170725
{
public:
	// System.String ConfigXmlTextReader::fileName
	String_t* ___fileName_7;

public:
	inline static int32_t get_offset_of_fileName_7() { return static_cast<int32_t>(offsetof(ConfigXmlTextReader_t3212066157, ___fileName_7)); }
	inline String_t* get_fileName_7() const { return ___fileName_7; }
	inline String_t** get_address_of_fileName_7() { return &___fileName_7; }
	inline void set_fileName_7(String_t* value)
	{
		___fileName_7 = value;
		Il2CppCodeGenWriteBarrier(&___fileName_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
