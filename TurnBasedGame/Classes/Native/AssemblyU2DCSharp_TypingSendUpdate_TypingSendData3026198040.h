#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Typing>>
struct VP_1_t3126344280;
// VP`1<TypingSendUpdate/TypingSendData/State>
struct VP_1_t1085265948;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TypingSendUpdate/TypingSendData
struct  TypingSendData_t3026198040  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Typing>> TypingSendUpdate/TypingSendData::typing
	VP_1_t3126344280 * ___typing_5;
	// VP`1<TypingSendUpdate/TypingSendData/State> TypingSendUpdate/TypingSendData::state
	VP_1_t1085265948 * ___state_6;

public:
	inline static int32_t get_offset_of_typing_5() { return static_cast<int32_t>(offsetof(TypingSendData_t3026198040, ___typing_5)); }
	inline VP_1_t3126344280 * get_typing_5() const { return ___typing_5; }
	inline VP_1_t3126344280 ** get_address_of_typing_5() { return &___typing_5; }
	inline void set_typing_5(VP_1_t3126344280 * value)
	{
		___typing_5 = value;
		Il2CppCodeGenWriteBarrier(&___typing_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(TypingSendData_t3026198040, ___state_6)); }
	inline VP_1_t1085265948 * get_state_6() const { return ___state_6; }
	inline VP_1_t1085265948 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t1085265948 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
