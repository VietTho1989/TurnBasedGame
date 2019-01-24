#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Xml.XmlNameTable
struct XmlNameTable_t1345805268;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlImplementation
struct  XmlImplementation_t1664517635  : public Il2CppObject
{
public:
	// System.Xml.XmlNameTable System.Xml.XmlImplementation::InternalNameTable
	XmlNameTable_t1345805268 * ___InternalNameTable_0;

public:
	inline static int32_t get_offset_of_InternalNameTable_0() { return static_cast<int32_t>(offsetof(XmlImplementation_t1664517635, ___InternalNameTable_0)); }
	inline XmlNameTable_t1345805268 * get_InternalNameTable_0() const { return ___InternalNameTable_0; }
	inline XmlNameTable_t1345805268 ** get_address_of_InternalNameTable_0() { return &___InternalNameTable_0; }
	inline void set_InternalNameTable_0(XmlNameTable_t1345805268 * value)
	{
		___InternalNameTable_0 = value;
		Il2CppCodeGenWriteBarrier(&___InternalNameTable_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
