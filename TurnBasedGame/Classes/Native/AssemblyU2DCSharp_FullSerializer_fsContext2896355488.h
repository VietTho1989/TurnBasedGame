#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Type,System.Object>
struct Dictionary_2_t331839896;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsContext
struct  fsContext_t2896355488  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.Type,System.Object> FullSerializer.fsContext::_contextObjects
	Dictionary_2_t331839896 * ____contextObjects_0;

public:
	inline static int32_t get_offset_of__contextObjects_0() { return static_cast<int32_t>(offsetof(fsContext_t2896355488, ____contextObjects_0)); }
	inline Dictionary_2_t331839896 * get__contextObjects_0() const { return ____contextObjects_0; }
	inline Dictionary_2_t331839896 ** get_address_of__contextObjects_0() { return &____contextObjects_0; }
	inline void set__contextObjects_0(Dictionary_2_t331839896 * value)
	{
		____contextObjects_0 = value;
		Il2CppCodeGenWriteBarrier(&____contextObjects_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
