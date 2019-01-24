#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaContentProcess74226324.h"

// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Xml.Schema.XmlSchemaElement
struct XmlSchemaElement_t2433337156;
// System.Collections.Stack
struct Stack_t1043988394;
// Mono.Xml.Schema.XsdValidationContext
struct XsdValidationContext_t3720679969;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XsdParticleStateManager
struct  XsdParticleStateManager_t4119977941  : public Il2CppObject
{
public:
	// System.Collections.Hashtable Mono.Xml.Schema.XsdParticleStateManager::table
	Hashtable_t909839986 * ___table_0;
	// System.Xml.Schema.XmlSchemaContentProcessing Mono.Xml.Schema.XsdParticleStateManager::processContents
	int32_t ___processContents_1;
	// System.Xml.Schema.XmlSchemaElement Mono.Xml.Schema.XsdParticleStateManager::CurrentElement
	XmlSchemaElement_t2433337156 * ___CurrentElement_2;
	// System.Collections.Stack Mono.Xml.Schema.XsdParticleStateManager::ContextStack
	Stack_t1043988394 * ___ContextStack_3;
	// Mono.Xml.Schema.XsdValidationContext Mono.Xml.Schema.XsdParticleStateManager::Context
	XsdValidationContext_t3720679969 * ___Context_4;

public:
	inline static int32_t get_offset_of_table_0() { return static_cast<int32_t>(offsetof(XsdParticleStateManager_t4119977941, ___table_0)); }
	inline Hashtable_t909839986 * get_table_0() const { return ___table_0; }
	inline Hashtable_t909839986 ** get_address_of_table_0() { return &___table_0; }
	inline void set_table_0(Hashtable_t909839986 * value)
	{
		___table_0 = value;
		Il2CppCodeGenWriteBarrier(&___table_0, value);
	}

	inline static int32_t get_offset_of_processContents_1() { return static_cast<int32_t>(offsetof(XsdParticleStateManager_t4119977941, ___processContents_1)); }
	inline int32_t get_processContents_1() const { return ___processContents_1; }
	inline int32_t* get_address_of_processContents_1() { return &___processContents_1; }
	inline void set_processContents_1(int32_t value)
	{
		___processContents_1 = value;
	}

	inline static int32_t get_offset_of_CurrentElement_2() { return static_cast<int32_t>(offsetof(XsdParticleStateManager_t4119977941, ___CurrentElement_2)); }
	inline XmlSchemaElement_t2433337156 * get_CurrentElement_2() const { return ___CurrentElement_2; }
	inline XmlSchemaElement_t2433337156 ** get_address_of_CurrentElement_2() { return &___CurrentElement_2; }
	inline void set_CurrentElement_2(XmlSchemaElement_t2433337156 * value)
	{
		___CurrentElement_2 = value;
		Il2CppCodeGenWriteBarrier(&___CurrentElement_2, value);
	}

	inline static int32_t get_offset_of_ContextStack_3() { return static_cast<int32_t>(offsetof(XsdParticleStateManager_t4119977941, ___ContextStack_3)); }
	inline Stack_t1043988394 * get_ContextStack_3() const { return ___ContextStack_3; }
	inline Stack_t1043988394 ** get_address_of_ContextStack_3() { return &___ContextStack_3; }
	inline void set_ContextStack_3(Stack_t1043988394 * value)
	{
		___ContextStack_3 = value;
		Il2CppCodeGenWriteBarrier(&___ContextStack_3, value);
	}

	inline static int32_t get_offset_of_Context_4() { return static_cast<int32_t>(offsetof(XsdParticleStateManager_t4119977941, ___Context_4)); }
	inline XsdValidationContext_t3720679969 * get_Context_4() const { return ___Context_4; }
	inline XsdValidationContext_t3720679969 ** get_address_of_Context_4() { return &___Context_4; }
	inline void set_Context_4(XsdValidationContext_t3720679969 * value)
	{
		___Context_4 = value;
		Il2CppCodeGenWriteBarrier(&___Context_4, value);
	}
};

struct XsdParticleStateManager_t4119977941_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Xml.Schema.XsdParticleStateManager::<>f__switch$map2
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map2_5;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map2_5() { return static_cast<int32_t>(offsetof(XsdParticleStateManager_t4119977941_StaticFields, ___U3CU3Ef__switchU24map2_5)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map2_5() const { return ___U3CU3Ef__switchU24map2_5; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map2_5() { return &___U3CU3Ef__switchU24map2_5; }
	inline void set_U3CU3Ef__switchU24map2_5(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map2_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map2_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
