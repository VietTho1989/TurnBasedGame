#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_Mono_Xml_DTDNode1758286970.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDNotationDeclaration
struct  DTDNotationDeclaration_t1758408116  : public DTDNode_t1758286970
{
public:
	// System.String Mono.Xml.DTDNotationDeclaration::name
	String_t* ___name_5;
	// System.String Mono.Xml.DTDNotationDeclaration::localName
	String_t* ___localName_6;
	// System.String Mono.Xml.DTDNotationDeclaration::prefix
	String_t* ___prefix_7;
	// System.String Mono.Xml.DTDNotationDeclaration::publicId
	String_t* ___publicId_8;
	// System.String Mono.Xml.DTDNotationDeclaration::systemId
	String_t* ___systemId_9;

public:
	inline static int32_t get_offset_of_name_5() { return static_cast<int32_t>(offsetof(DTDNotationDeclaration_t1758408116, ___name_5)); }
	inline String_t* get_name_5() const { return ___name_5; }
	inline String_t** get_address_of_name_5() { return &___name_5; }
	inline void set_name_5(String_t* value)
	{
		___name_5 = value;
		Il2CppCodeGenWriteBarrier(&___name_5, value);
	}

	inline static int32_t get_offset_of_localName_6() { return static_cast<int32_t>(offsetof(DTDNotationDeclaration_t1758408116, ___localName_6)); }
	inline String_t* get_localName_6() const { return ___localName_6; }
	inline String_t** get_address_of_localName_6() { return &___localName_6; }
	inline void set_localName_6(String_t* value)
	{
		___localName_6 = value;
		Il2CppCodeGenWriteBarrier(&___localName_6, value);
	}

	inline static int32_t get_offset_of_prefix_7() { return static_cast<int32_t>(offsetof(DTDNotationDeclaration_t1758408116, ___prefix_7)); }
	inline String_t* get_prefix_7() const { return ___prefix_7; }
	inline String_t** get_address_of_prefix_7() { return &___prefix_7; }
	inline void set_prefix_7(String_t* value)
	{
		___prefix_7 = value;
		Il2CppCodeGenWriteBarrier(&___prefix_7, value);
	}

	inline static int32_t get_offset_of_publicId_8() { return static_cast<int32_t>(offsetof(DTDNotationDeclaration_t1758408116, ___publicId_8)); }
	inline String_t* get_publicId_8() const { return ___publicId_8; }
	inline String_t** get_address_of_publicId_8() { return &___publicId_8; }
	inline void set_publicId_8(String_t* value)
	{
		___publicId_8 = value;
		Il2CppCodeGenWriteBarrier(&___publicId_8, value);
	}

	inline static int32_t get_offset_of_systemId_9() { return static_cast<int32_t>(offsetof(DTDNotationDeclaration_t1758408116, ___systemId_9)); }
	inline String_t* get_systemId_9() const { return ___systemId_9; }
	inline String_t** get_address_of_systemId_9() { return &___systemId_9; }
	inline void set_systemId_9(String_t* value)
	{
		___systemId_9 = value;
		Il2CppCodeGenWriteBarrier(&___systemId_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
