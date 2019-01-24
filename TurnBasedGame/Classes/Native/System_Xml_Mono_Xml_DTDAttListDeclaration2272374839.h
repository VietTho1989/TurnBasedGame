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
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Collections.ArrayList
struct ArrayList_t4252133567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDAttListDeclaration
struct  DTDAttListDeclaration_t2272374839  : public DTDNode_t1758286970
{
public:
	// System.String Mono.Xml.DTDAttListDeclaration::name
	String_t* ___name_5;
	// System.Collections.Hashtable Mono.Xml.DTDAttListDeclaration::attributeOrders
	Hashtable_t909839986 * ___attributeOrders_6;
	// System.Collections.ArrayList Mono.Xml.DTDAttListDeclaration::attributes
	ArrayList_t4252133567 * ___attributes_7;

public:
	inline static int32_t get_offset_of_name_5() { return static_cast<int32_t>(offsetof(DTDAttListDeclaration_t2272374839, ___name_5)); }
	inline String_t* get_name_5() const { return ___name_5; }
	inline String_t** get_address_of_name_5() { return &___name_5; }
	inline void set_name_5(String_t* value)
	{
		___name_5 = value;
		Il2CppCodeGenWriteBarrier(&___name_5, value);
	}

	inline static int32_t get_offset_of_attributeOrders_6() { return static_cast<int32_t>(offsetof(DTDAttListDeclaration_t2272374839, ___attributeOrders_6)); }
	inline Hashtable_t909839986 * get_attributeOrders_6() const { return ___attributeOrders_6; }
	inline Hashtable_t909839986 ** get_address_of_attributeOrders_6() { return &___attributeOrders_6; }
	inline void set_attributeOrders_6(Hashtable_t909839986 * value)
	{
		___attributeOrders_6 = value;
		Il2CppCodeGenWriteBarrier(&___attributeOrders_6, value);
	}

	inline static int32_t get_offset_of_attributes_7() { return static_cast<int32_t>(offsetof(DTDAttListDeclaration_t2272374839, ___attributes_7)); }
	inline ArrayList_t4252133567 * get_attributes_7() const { return ___attributes_7; }
	inline ArrayList_t4252133567 ** get_address_of_attributes_7() { return &___attributes_7; }
	inline void set_attributes_7(ArrayList_t4252133567 * value)
	{
		___attributes_7 = value;
		Il2CppCodeGenWriteBarrier(&___attributes_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
