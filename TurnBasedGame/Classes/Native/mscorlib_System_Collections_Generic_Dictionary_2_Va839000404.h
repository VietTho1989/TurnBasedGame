#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<UnityEngine.RectTransform/Edge,System.Action`4<UnityEngine.RectTransform,UnityEngine.RectTransform,System.Single,System.Single>>
struct Dictionary_2_t2135940561;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2/ValueCollection<UnityEngine.RectTransform/Edge,System.Action`4<UnityEngine.RectTransform,UnityEngine.RectTransform,System.Single,System.Single>>
struct  ValueCollection_t839000404  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/ValueCollection::dictionary
	Dictionary_2_t2135940561 * ___dictionary_0;

public:
	inline static int32_t get_offset_of_dictionary_0() { return static_cast<int32_t>(offsetof(ValueCollection_t839000404, ___dictionary_0)); }
	inline Dictionary_2_t2135940561 * get_dictionary_0() const { return ___dictionary_0; }
	inline Dictionary_2_t2135940561 ** get_address_of_dictionary_0() { return &___dictionary_0; }
	inline void set_dictionary_0(Dictionary_2_t2135940561 * value)
	{
		___dictionary_0 = value;
		Il2CppCodeGenWriteBarrier(&___dictionary_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
