#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IDictionaryEnumerator
struct IDictionaryEnumerator_t259680273;
// System.Collections.IEnumerable
struct IEnumerable_t2911409499;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaObjectTable/XmlSchemaObjectTableEnumerator
struct  XmlSchemaObjectTableEnumerator_t2908487920  : public Il2CppObject
{
public:
	// System.Collections.IDictionaryEnumerator System.Xml.Schema.XmlSchemaObjectTable/XmlSchemaObjectTableEnumerator::xenum
	Il2CppObject * ___xenum_0;
	// System.Collections.IEnumerable System.Xml.Schema.XmlSchemaObjectTable/XmlSchemaObjectTableEnumerator::tmp
	Il2CppObject * ___tmp_1;

public:
	inline static int32_t get_offset_of_xenum_0() { return static_cast<int32_t>(offsetof(XmlSchemaObjectTableEnumerator_t2908487920, ___xenum_0)); }
	inline Il2CppObject * get_xenum_0() const { return ___xenum_0; }
	inline Il2CppObject ** get_address_of_xenum_0() { return &___xenum_0; }
	inline void set_xenum_0(Il2CppObject * value)
	{
		___xenum_0 = value;
		Il2CppCodeGenWriteBarrier(&___xenum_0, value);
	}

	inline static int32_t get_offset_of_tmp_1() { return static_cast<int32_t>(offsetof(XmlSchemaObjectTableEnumerator_t2908487920, ___tmp_1)); }
	inline Il2CppObject * get_tmp_1() const { return ___tmp_1; }
	inline Il2CppObject ** get_address_of_tmp_1() { return &___tmp_1; }
	inline void set_tmp_1(Il2CppObject * value)
	{
		___tmp_1 = value;
		Il2CppCodeGenWriteBarrier(&___tmp_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
