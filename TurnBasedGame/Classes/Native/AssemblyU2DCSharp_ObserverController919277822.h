#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Int32,ObserverController/ConnectionDict>
struct Dictionary_2_t3867310292;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ObserverController
struct  ObserverController_t919277822  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.Int32,ObserverController/ConnectionDict> ObserverController::dictChannels
	Dictionary_2_t3867310292 * ___dictChannels_3;

public:
	inline static int32_t get_offset_of_dictChannels_3() { return static_cast<int32_t>(offsetof(ObserverController_t919277822, ___dictChannels_3)); }
	inline Dictionary_2_t3867310292 * get_dictChannels_3() const { return ___dictChannels_3; }
	inline Dictionary_2_t3867310292 ** get_address_of_dictChannels_3() { return &___dictChannels_3; }
	inline void set_dictChannels_3(Dictionary_2_t3867310292 * value)
	{
		___dictChannels_3 = value;
		Il2CppCodeGenWriteBarrier(&___dictChannels_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
