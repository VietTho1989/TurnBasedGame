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
// System.Uri
struct Uri_t19570940;
// System.Xml.XmlResolver
struct XmlResolver_t2024571559;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDEntityBase
struct  DTDEntityBase_t2353758560  : public DTDNode_t1758286970
{
public:
	// System.String Mono.Xml.DTDEntityBase::name
	String_t* ___name_5;
	// System.String Mono.Xml.DTDEntityBase::publicId
	String_t* ___publicId_6;
	// System.String Mono.Xml.DTDEntityBase::systemId
	String_t* ___systemId_7;
	// System.String Mono.Xml.DTDEntityBase::literalValue
	String_t* ___literalValue_8;
	// System.String Mono.Xml.DTDEntityBase::replacementText
	String_t* ___replacementText_9;
	// System.String Mono.Xml.DTDEntityBase::uriString
	String_t* ___uriString_10;
	// System.Uri Mono.Xml.DTDEntityBase::absUri
	Uri_t19570940 * ___absUri_11;
	// System.Boolean Mono.Xml.DTDEntityBase::isInvalid
	bool ___isInvalid_12;
	// System.Boolean Mono.Xml.DTDEntityBase::loadFailed
	bool ___loadFailed_13;
	// System.Xml.XmlResolver Mono.Xml.DTDEntityBase::resolver
	XmlResolver_t2024571559 * ___resolver_14;

public:
	inline static int32_t get_offset_of_name_5() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___name_5)); }
	inline String_t* get_name_5() const { return ___name_5; }
	inline String_t** get_address_of_name_5() { return &___name_5; }
	inline void set_name_5(String_t* value)
	{
		___name_5 = value;
		Il2CppCodeGenWriteBarrier(&___name_5, value);
	}

	inline static int32_t get_offset_of_publicId_6() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___publicId_6)); }
	inline String_t* get_publicId_6() const { return ___publicId_6; }
	inline String_t** get_address_of_publicId_6() { return &___publicId_6; }
	inline void set_publicId_6(String_t* value)
	{
		___publicId_6 = value;
		Il2CppCodeGenWriteBarrier(&___publicId_6, value);
	}

	inline static int32_t get_offset_of_systemId_7() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___systemId_7)); }
	inline String_t* get_systemId_7() const { return ___systemId_7; }
	inline String_t** get_address_of_systemId_7() { return &___systemId_7; }
	inline void set_systemId_7(String_t* value)
	{
		___systemId_7 = value;
		Il2CppCodeGenWriteBarrier(&___systemId_7, value);
	}

	inline static int32_t get_offset_of_literalValue_8() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___literalValue_8)); }
	inline String_t* get_literalValue_8() const { return ___literalValue_8; }
	inline String_t** get_address_of_literalValue_8() { return &___literalValue_8; }
	inline void set_literalValue_8(String_t* value)
	{
		___literalValue_8 = value;
		Il2CppCodeGenWriteBarrier(&___literalValue_8, value);
	}

	inline static int32_t get_offset_of_replacementText_9() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___replacementText_9)); }
	inline String_t* get_replacementText_9() const { return ___replacementText_9; }
	inline String_t** get_address_of_replacementText_9() { return &___replacementText_9; }
	inline void set_replacementText_9(String_t* value)
	{
		___replacementText_9 = value;
		Il2CppCodeGenWriteBarrier(&___replacementText_9, value);
	}

	inline static int32_t get_offset_of_uriString_10() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___uriString_10)); }
	inline String_t* get_uriString_10() const { return ___uriString_10; }
	inline String_t** get_address_of_uriString_10() { return &___uriString_10; }
	inline void set_uriString_10(String_t* value)
	{
		___uriString_10 = value;
		Il2CppCodeGenWriteBarrier(&___uriString_10, value);
	}

	inline static int32_t get_offset_of_absUri_11() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___absUri_11)); }
	inline Uri_t19570940 * get_absUri_11() const { return ___absUri_11; }
	inline Uri_t19570940 ** get_address_of_absUri_11() { return &___absUri_11; }
	inline void set_absUri_11(Uri_t19570940 * value)
	{
		___absUri_11 = value;
		Il2CppCodeGenWriteBarrier(&___absUri_11, value);
	}

	inline static int32_t get_offset_of_isInvalid_12() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___isInvalid_12)); }
	inline bool get_isInvalid_12() const { return ___isInvalid_12; }
	inline bool* get_address_of_isInvalid_12() { return &___isInvalid_12; }
	inline void set_isInvalid_12(bool value)
	{
		___isInvalid_12 = value;
	}

	inline static int32_t get_offset_of_loadFailed_13() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___loadFailed_13)); }
	inline bool get_loadFailed_13() const { return ___loadFailed_13; }
	inline bool* get_address_of_loadFailed_13() { return &___loadFailed_13; }
	inline void set_loadFailed_13(bool value)
	{
		___loadFailed_13 = value;
	}

	inline static int32_t get_offset_of_resolver_14() { return static_cast<int32_t>(offsetof(DTDEntityBase_t2353758560, ___resolver_14)); }
	inline XmlResolver_t2024571559 * get_resolver_14() const { return ___resolver_14; }
	inline XmlResolver_t2024571559 ** get_address_of_resolver_14() { return &___resolver_14; }
	inline void set_resolver_14(XmlResolver_t2024571559 * value)
	{
		___resolver_14 = value;
		Il2CppCodeGenWriteBarrier(&___resolver_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
