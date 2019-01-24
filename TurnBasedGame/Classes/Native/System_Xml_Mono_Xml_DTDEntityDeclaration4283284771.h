#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_Mono_Xml_DTDEntityBase2353758560.h"

// System.String
struct String_t;
// System.Collections.ArrayList
struct ArrayList_t4252133567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDEntityDeclaration
struct  DTDEntityDeclaration_t4283284771  : public DTDEntityBase_t2353758560
{
public:
	// System.String Mono.Xml.DTDEntityDeclaration::entityValue
	String_t* ___entityValue_15;
	// System.String Mono.Xml.DTDEntityDeclaration::notationName
	String_t* ___notationName_16;
	// System.Collections.ArrayList Mono.Xml.DTDEntityDeclaration::ReferencingEntities
	ArrayList_t4252133567 * ___ReferencingEntities_17;
	// System.Boolean Mono.Xml.DTDEntityDeclaration::scanned
	bool ___scanned_18;
	// System.Boolean Mono.Xml.DTDEntityDeclaration::recursed
	bool ___recursed_19;
	// System.Boolean Mono.Xml.DTDEntityDeclaration::hasExternalReference
	bool ___hasExternalReference_20;

public:
	inline static int32_t get_offset_of_entityValue_15() { return static_cast<int32_t>(offsetof(DTDEntityDeclaration_t4283284771, ___entityValue_15)); }
	inline String_t* get_entityValue_15() const { return ___entityValue_15; }
	inline String_t** get_address_of_entityValue_15() { return &___entityValue_15; }
	inline void set_entityValue_15(String_t* value)
	{
		___entityValue_15 = value;
		Il2CppCodeGenWriteBarrier(&___entityValue_15, value);
	}

	inline static int32_t get_offset_of_notationName_16() { return static_cast<int32_t>(offsetof(DTDEntityDeclaration_t4283284771, ___notationName_16)); }
	inline String_t* get_notationName_16() const { return ___notationName_16; }
	inline String_t** get_address_of_notationName_16() { return &___notationName_16; }
	inline void set_notationName_16(String_t* value)
	{
		___notationName_16 = value;
		Il2CppCodeGenWriteBarrier(&___notationName_16, value);
	}

	inline static int32_t get_offset_of_ReferencingEntities_17() { return static_cast<int32_t>(offsetof(DTDEntityDeclaration_t4283284771, ___ReferencingEntities_17)); }
	inline ArrayList_t4252133567 * get_ReferencingEntities_17() const { return ___ReferencingEntities_17; }
	inline ArrayList_t4252133567 ** get_address_of_ReferencingEntities_17() { return &___ReferencingEntities_17; }
	inline void set_ReferencingEntities_17(ArrayList_t4252133567 * value)
	{
		___ReferencingEntities_17 = value;
		Il2CppCodeGenWriteBarrier(&___ReferencingEntities_17, value);
	}

	inline static int32_t get_offset_of_scanned_18() { return static_cast<int32_t>(offsetof(DTDEntityDeclaration_t4283284771, ___scanned_18)); }
	inline bool get_scanned_18() const { return ___scanned_18; }
	inline bool* get_address_of_scanned_18() { return &___scanned_18; }
	inline void set_scanned_18(bool value)
	{
		___scanned_18 = value;
	}

	inline static int32_t get_offset_of_recursed_19() { return static_cast<int32_t>(offsetof(DTDEntityDeclaration_t4283284771, ___recursed_19)); }
	inline bool get_recursed_19() const { return ___recursed_19; }
	inline bool* get_address_of_recursed_19() { return &___recursed_19; }
	inline void set_recursed_19(bool value)
	{
		___recursed_19 = value;
	}

	inline static int32_t get_offset_of_hasExternalReference_20() { return static_cast<int32_t>(offsetof(DTDEntityDeclaration_t4283284771, ___hasExternalReference_20)); }
	inline bool get_hasExternalReference_20() const { return ___hasExternalReference_20; }
	inline bool* get_address_of_hasExternalReference_20() { return &___hasExternalReference_20; }
	inline void set_hasExternalReference_20(bool value)
	{
		___hasExternalReference_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
