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
// System.Collections.Hashtable
struct Hashtable_t909839986;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDAutomataFactory
struct  DTDAutomataFactory_t3605390810  : public Il2CppObject
{
public:
	// Mono.Xml.DTDObjectModel Mono.Xml.DTDAutomataFactory::root
	DTDObjectModel_t1113953282 * ___root_0;
	// System.Collections.Hashtable Mono.Xml.DTDAutomataFactory::choiceTable
	Hashtable_t909839986 * ___choiceTable_1;
	// System.Collections.Hashtable Mono.Xml.DTDAutomataFactory::sequenceTable
	Hashtable_t909839986 * ___sequenceTable_2;

public:
	inline static int32_t get_offset_of_root_0() { return static_cast<int32_t>(offsetof(DTDAutomataFactory_t3605390810, ___root_0)); }
	inline DTDObjectModel_t1113953282 * get_root_0() const { return ___root_0; }
	inline DTDObjectModel_t1113953282 ** get_address_of_root_0() { return &___root_0; }
	inline void set_root_0(DTDObjectModel_t1113953282 * value)
	{
		___root_0 = value;
		Il2CppCodeGenWriteBarrier(&___root_0, value);
	}

	inline static int32_t get_offset_of_choiceTable_1() { return static_cast<int32_t>(offsetof(DTDAutomataFactory_t3605390810, ___choiceTable_1)); }
	inline Hashtable_t909839986 * get_choiceTable_1() const { return ___choiceTable_1; }
	inline Hashtable_t909839986 ** get_address_of_choiceTable_1() { return &___choiceTable_1; }
	inline void set_choiceTable_1(Hashtable_t909839986 * value)
	{
		___choiceTable_1 = value;
		Il2CppCodeGenWriteBarrier(&___choiceTable_1, value);
	}

	inline static int32_t get_offset_of_sequenceTable_2() { return static_cast<int32_t>(offsetof(DTDAutomataFactory_t3605390810, ___sequenceTable_2)); }
	inline Hashtable_t909839986 * get_sequenceTable_2() const { return ___sequenceTable_2; }
	inline Hashtable_t909839986 ** get_address_of_sequenceTable_2() { return &___sequenceTable_2; }
	inline void set_sequenceTable_2(Hashtable_t909839986 * value)
	{
		___sequenceTable_2 = value;
		Il2CppCodeGenWriteBarrier(&___sequenceTable_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
