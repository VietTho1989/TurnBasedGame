#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Mono.Xml.DTDObjectModel
struct DTDObjectModel_t1113953282;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDNode
struct  DTDNode_t1758286970  : public Il2CppObject
{
public:
	// Mono.Xml.DTDObjectModel Mono.Xml.DTDNode::root
	DTDObjectModel_t1113953282 * ___root_0;
	// System.Boolean Mono.Xml.DTDNode::isInternalSubset
	bool ___isInternalSubset_1;
	// System.String Mono.Xml.DTDNode::baseURI
	String_t* ___baseURI_2;
	// System.Int32 Mono.Xml.DTDNode::lineNumber
	int32_t ___lineNumber_3;
	// System.Int32 Mono.Xml.DTDNode::linePosition
	int32_t ___linePosition_4;

public:
	inline static int32_t get_offset_of_root_0() { return static_cast<int32_t>(offsetof(DTDNode_t1758286970, ___root_0)); }
	inline DTDObjectModel_t1113953282 * get_root_0() const { return ___root_0; }
	inline DTDObjectModel_t1113953282 ** get_address_of_root_0() { return &___root_0; }
	inline void set_root_0(DTDObjectModel_t1113953282 * value)
	{
		___root_0 = value;
		Il2CppCodeGenWriteBarrier(&___root_0, value);
	}

	inline static int32_t get_offset_of_isInternalSubset_1() { return static_cast<int32_t>(offsetof(DTDNode_t1758286970, ___isInternalSubset_1)); }
	inline bool get_isInternalSubset_1() const { return ___isInternalSubset_1; }
	inline bool* get_address_of_isInternalSubset_1() { return &___isInternalSubset_1; }
	inline void set_isInternalSubset_1(bool value)
	{
		___isInternalSubset_1 = value;
	}

	inline static int32_t get_offset_of_baseURI_2() { return static_cast<int32_t>(offsetof(DTDNode_t1758286970, ___baseURI_2)); }
	inline String_t* get_baseURI_2() const { return ___baseURI_2; }
	inline String_t** get_address_of_baseURI_2() { return &___baseURI_2; }
	inline void set_baseURI_2(String_t* value)
	{
		___baseURI_2 = value;
		Il2CppCodeGenWriteBarrier(&___baseURI_2, value);
	}

	inline static int32_t get_offset_of_lineNumber_3() { return static_cast<int32_t>(offsetof(DTDNode_t1758286970, ___lineNumber_3)); }
	inline int32_t get_lineNumber_3() const { return ___lineNumber_3; }
	inline int32_t* get_address_of_lineNumber_3() { return &___lineNumber_3; }
	inline void set_lineNumber_3(int32_t value)
	{
		___lineNumber_3 = value;
	}

	inline static int32_t get_offset_of_linePosition_4() { return static_cast<int32_t>(offsetof(DTDNode_t1758286970, ___linePosition_4)); }
	inline int32_t get_linePosition_4() const { return ___linePosition_4; }
	inline int32_t* get_address_of_linePosition_4() { return &___linePosition_4; }
	inline void set_linePosition_4(int32_t value)
	{
		___linePosition_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
