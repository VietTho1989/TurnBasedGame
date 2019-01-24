#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<ToastMessage>
struct LP_1_t2241259490;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<ToastData/State>
struct VP_1_t4239389193;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ToastData
struct  ToastData_t3292254139  : public Data_t3569509720
{
public:
	// LP`1<ToastMessage> ToastData::messages
	LP_1_t2241259490 * ___messages_5;
	// VP`1<System.Int32> ToastData::maxIndex
	VP_1_t2450154454 * ___maxIndex_6;
	// VP`1<ToastData/State> ToastData::state
	VP_1_t4239389193 * ___state_7;

public:
	inline static int32_t get_offset_of_messages_5() { return static_cast<int32_t>(offsetof(ToastData_t3292254139, ___messages_5)); }
	inline LP_1_t2241259490 * get_messages_5() const { return ___messages_5; }
	inline LP_1_t2241259490 ** get_address_of_messages_5() { return &___messages_5; }
	inline void set_messages_5(LP_1_t2241259490 * value)
	{
		___messages_5 = value;
		Il2CppCodeGenWriteBarrier(&___messages_5, value);
	}

	inline static int32_t get_offset_of_maxIndex_6() { return static_cast<int32_t>(offsetof(ToastData_t3292254139, ___maxIndex_6)); }
	inline VP_1_t2450154454 * get_maxIndex_6() const { return ___maxIndex_6; }
	inline VP_1_t2450154454 ** get_address_of_maxIndex_6() { return &___maxIndex_6; }
	inline void set_maxIndex_6(VP_1_t2450154454 * value)
	{
		___maxIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___maxIndex_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(ToastData_t3292254139, ___state_7)); }
	inline VP_1_t4239389193 * get_state_7() const { return ___state_7; }
	inline VP_1_t4239389193 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t4239389193 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
