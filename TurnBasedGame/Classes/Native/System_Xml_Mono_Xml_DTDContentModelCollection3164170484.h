#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.ArrayList
struct ArrayList_t4252133567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDContentModelCollection
struct  DTDContentModelCollection_t3164170484  : public Il2CppObject
{
public:
	// System.Collections.ArrayList Mono.Xml.DTDContentModelCollection::contentModel
	ArrayList_t4252133567 * ___contentModel_0;

public:
	inline static int32_t get_offset_of_contentModel_0() { return static_cast<int32_t>(offsetof(DTDContentModelCollection_t3164170484, ___contentModel_0)); }
	inline ArrayList_t4252133567 * get_contentModel_0() const { return ___contentModel_0; }
	inline ArrayList_t4252133567 ** get_address_of_contentModel_0() { return &___contentModel_0; }
	inline void set_contentModel_0(ArrayList_t4252133567 * value)
	{
		___contentModel_0 = value;
		Il2CppCodeGenWriteBarrier(&___contentModel_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
