#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Hashtable
struct Hashtable_t909839986;
// Mono.Xml.DTDObjectModel
struct DTDObjectModel_t1113953282;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDParameterEntityDeclarationCollection
struct  DTDParameterEntityDeclarationCollection_t3496720022  : public Il2CppObject
{
public:
	// System.Collections.Hashtable Mono.Xml.DTDParameterEntityDeclarationCollection::peDecls
	Hashtable_t909839986 * ___peDecls_0;
	// Mono.Xml.DTDObjectModel Mono.Xml.DTDParameterEntityDeclarationCollection::root
	DTDObjectModel_t1113953282 * ___root_1;

public:
	inline static int32_t get_offset_of_peDecls_0() { return static_cast<int32_t>(offsetof(DTDParameterEntityDeclarationCollection_t3496720022, ___peDecls_0)); }
	inline Hashtable_t909839986 * get_peDecls_0() const { return ___peDecls_0; }
	inline Hashtable_t909839986 ** get_address_of_peDecls_0() { return &___peDecls_0; }
	inline void set_peDecls_0(Hashtable_t909839986 * value)
	{
		___peDecls_0 = value;
		Il2CppCodeGenWriteBarrier(&___peDecls_0, value);
	}

	inline static int32_t get_offset_of_root_1() { return static_cast<int32_t>(offsetof(DTDParameterEntityDeclarationCollection_t3496720022, ___root_1)); }
	inline DTDObjectModel_t1113953282 * get_root_1() const { return ___root_1; }
	inline DTDObjectModel_t1113953282 ** get_address_of_root_1() { return &___root_1; }
	inline void set_root_1(DTDObjectModel_t1113953282 * value)
	{
		___root_1 = value;
		Il2CppCodeGenWriteBarrier(&___root_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
