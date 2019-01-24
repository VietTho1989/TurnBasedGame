#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.String>
struct VP_1_t2407497239;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ToastMessage
struct  ToastMessage_t3503515534  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> ToastMessage::toastIndex
	VP_1_t2450154454 * ___toastIndex_5;
	// VP`1<System.String> ToastMessage::message
	VP_1_t2407497239 * ___message_6;
	// VP`1<System.Single> ToastMessage::time
	VP_1_t2454786938 * ___time_7;
	// VP`1<System.Single> ToastMessage::duration
	VP_1_t2454786938 * ___duration_9;

public:
	inline static int32_t get_offset_of_toastIndex_5() { return static_cast<int32_t>(offsetof(ToastMessage_t3503515534, ___toastIndex_5)); }
	inline VP_1_t2450154454 * get_toastIndex_5() const { return ___toastIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_toastIndex_5() { return &___toastIndex_5; }
	inline void set_toastIndex_5(VP_1_t2450154454 * value)
	{
		___toastIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___toastIndex_5, value);
	}

	inline static int32_t get_offset_of_message_6() { return static_cast<int32_t>(offsetof(ToastMessage_t3503515534, ___message_6)); }
	inline VP_1_t2407497239 * get_message_6() const { return ___message_6; }
	inline VP_1_t2407497239 ** get_address_of_message_6() { return &___message_6; }
	inline void set_message_6(VP_1_t2407497239 * value)
	{
		___message_6 = value;
		Il2CppCodeGenWriteBarrier(&___message_6, value);
	}

	inline static int32_t get_offset_of_time_7() { return static_cast<int32_t>(offsetof(ToastMessage_t3503515534, ___time_7)); }
	inline VP_1_t2454786938 * get_time_7() const { return ___time_7; }
	inline VP_1_t2454786938 ** get_address_of_time_7() { return &___time_7; }
	inline void set_time_7(VP_1_t2454786938 * value)
	{
		___time_7 = value;
		Il2CppCodeGenWriteBarrier(&___time_7, value);
	}

	inline static int32_t get_offset_of_duration_9() { return static_cast<int32_t>(offsetof(ToastMessage_t3503515534, ___duration_9)); }
	inline VP_1_t2454786938 * get_duration_9() const { return ___duration_9; }
	inline VP_1_t2454786938 ** get_address_of_duration_9() { return &___duration_9; }
	inline void set_duration_9(VP_1_t2454786938 * value)
	{
		___duration_9 = value;
		Il2CppCodeGenWriteBarrier(&___duration_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
