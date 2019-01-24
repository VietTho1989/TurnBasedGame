#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_Mono_Xml_DTDNode1758286970.h"

// Mono.Xml.DTDObjectModel
struct DTDObjectModel_t1113953282;
// Mono.Xml.DTDContentModel
struct DTDContentModel_t445576364;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDElementDeclaration
struct  DTDElementDeclaration_t8748002  : public DTDNode_t1758286970
{
public:
	// Mono.Xml.DTDObjectModel Mono.Xml.DTDElementDeclaration::root
	DTDObjectModel_t1113953282 * ___root_5;
	// Mono.Xml.DTDContentModel Mono.Xml.DTDElementDeclaration::contentModel
	DTDContentModel_t445576364 * ___contentModel_6;
	// System.String Mono.Xml.DTDElementDeclaration::name
	String_t* ___name_7;
	// System.Boolean Mono.Xml.DTDElementDeclaration::isEmpty
	bool ___isEmpty_8;
	// System.Boolean Mono.Xml.DTDElementDeclaration::isAny
	bool ___isAny_9;
	// System.Boolean Mono.Xml.DTDElementDeclaration::isMixedContent
	bool ___isMixedContent_10;

public:
	inline static int32_t get_offset_of_root_5() { return static_cast<int32_t>(offsetof(DTDElementDeclaration_t8748002, ___root_5)); }
	inline DTDObjectModel_t1113953282 * get_root_5() const { return ___root_5; }
	inline DTDObjectModel_t1113953282 ** get_address_of_root_5() { return &___root_5; }
	inline void set_root_5(DTDObjectModel_t1113953282 * value)
	{
		___root_5 = value;
		Il2CppCodeGenWriteBarrier(&___root_5, value);
	}

	inline static int32_t get_offset_of_contentModel_6() { return static_cast<int32_t>(offsetof(DTDElementDeclaration_t8748002, ___contentModel_6)); }
	inline DTDContentModel_t445576364 * get_contentModel_6() const { return ___contentModel_6; }
	inline DTDContentModel_t445576364 ** get_address_of_contentModel_6() { return &___contentModel_6; }
	inline void set_contentModel_6(DTDContentModel_t445576364 * value)
	{
		___contentModel_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentModel_6, value);
	}

	inline static int32_t get_offset_of_name_7() { return static_cast<int32_t>(offsetof(DTDElementDeclaration_t8748002, ___name_7)); }
	inline String_t* get_name_7() const { return ___name_7; }
	inline String_t** get_address_of_name_7() { return &___name_7; }
	inline void set_name_7(String_t* value)
	{
		___name_7 = value;
		Il2CppCodeGenWriteBarrier(&___name_7, value);
	}

	inline static int32_t get_offset_of_isEmpty_8() { return static_cast<int32_t>(offsetof(DTDElementDeclaration_t8748002, ___isEmpty_8)); }
	inline bool get_isEmpty_8() const { return ___isEmpty_8; }
	inline bool* get_address_of_isEmpty_8() { return &___isEmpty_8; }
	inline void set_isEmpty_8(bool value)
	{
		___isEmpty_8 = value;
	}

	inline static int32_t get_offset_of_isAny_9() { return static_cast<int32_t>(offsetof(DTDElementDeclaration_t8748002, ___isAny_9)); }
	inline bool get_isAny_9() const { return ___isAny_9; }
	inline bool* get_address_of_isAny_9() { return &___isAny_9; }
	inline void set_isAny_9(bool value)
	{
		___isAny_9 = value;
	}

	inline static int32_t get_offset_of_isMixedContent_10() { return static_cast<int32_t>(offsetof(DTDElementDeclaration_t8748002, ___isMixedContent_10)); }
	inline bool get_isMixedContent_10() const { return ___isMixedContent_10; }
	inline bool* get_address_of_isMixedContent_10() { return &___isMixedContent_10; }
	inline void set_isMixedContent_10(bool value)
	{
		___isMixedContent_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
