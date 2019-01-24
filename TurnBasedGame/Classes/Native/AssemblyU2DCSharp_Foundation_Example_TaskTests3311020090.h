#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.TaskTests
struct  TaskTests_t3311020090  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Text Foundation.Example.TaskTests::Output
	Text_t356221433 * ___Output_2;
	// System.Int32 Foundation.Example.TaskTests::Counter
	int32_t ___Counter_3;
	// System.String Foundation.Example.TaskTests::log
	String_t* ___log_4;

public:
	inline static int32_t get_offset_of_Output_2() { return static_cast<int32_t>(offsetof(TaskTests_t3311020090, ___Output_2)); }
	inline Text_t356221433 * get_Output_2() const { return ___Output_2; }
	inline Text_t356221433 ** get_address_of_Output_2() { return &___Output_2; }
	inline void set_Output_2(Text_t356221433 * value)
	{
		___Output_2 = value;
		Il2CppCodeGenWriteBarrier(&___Output_2, value);
	}

	inline static int32_t get_offset_of_Counter_3() { return static_cast<int32_t>(offsetof(TaskTests_t3311020090, ___Counter_3)); }
	inline int32_t get_Counter_3() const { return ___Counter_3; }
	inline int32_t* get_address_of_Counter_3() { return &___Counter_3; }
	inline void set_Counter_3(int32_t value)
	{
		___Counter_3 = value;
	}

	inline static int32_t get_offset_of_log_4() { return static_cast<int32_t>(offsetof(TaskTests_t3311020090, ___log_4)); }
	inline String_t* get_log_4() const { return ___log_4; }
	inline String_t** get_address_of_log_4() { return &___log_4; }
	inline void set_log_4(String_t* value)
	{
		___log_4 = value;
		Il2CppCodeGenWriteBarrier(&___log_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
