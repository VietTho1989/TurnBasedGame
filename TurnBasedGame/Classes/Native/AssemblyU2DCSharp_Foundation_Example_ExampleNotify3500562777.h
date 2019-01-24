#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;
// System.ComponentModel.PropertyChangedEventHandler
struct PropertyChangedEventHandler_t3042952059;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.ExampleNotifyChanged
struct  ExampleNotifyChanged_t3500562777  : public MonoBehaviour_t1158329972
{
public:
	// System.String Foundation.Example.ExampleNotifyChanged::_time
	String_t* ____time_2;
	// System.ComponentModel.PropertyChangedEventHandler Foundation.Example.ExampleNotifyChanged::PropertyChanged
	PropertyChangedEventHandler_t3042952059 * ___PropertyChanged_3;

public:
	inline static int32_t get_offset_of__time_2() { return static_cast<int32_t>(offsetof(ExampleNotifyChanged_t3500562777, ____time_2)); }
	inline String_t* get__time_2() const { return ____time_2; }
	inline String_t** get_address_of__time_2() { return &____time_2; }
	inline void set__time_2(String_t* value)
	{
		____time_2 = value;
		Il2CppCodeGenWriteBarrier(&____time_2, value);
	}

	inline static int32_t get_offset_of_PropertyChanged_3() { return static_cast<int32_t>(offsetof(ExampleNotifyChanged_t3500562777, ___PropertyChanged_3)); }
	inline PropertyChangedEventHandler_t3042952059 * get_PropertyChanged_3() const { return ___PropertyChanged_3; }
	inline PropertyChangedEventHandler_t3042952059 ** get_address_of_PropertyChanged_3() { return &___PropertyChanged_3; }
	inline void set_PropertyChanged_3(PropertyChangedEventHandler_t3042952059 * value)
	{
		___PropertyChanged_3 = value;
		Il2CppCodeGenWriteBarrier(&___PropertyChanged_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
