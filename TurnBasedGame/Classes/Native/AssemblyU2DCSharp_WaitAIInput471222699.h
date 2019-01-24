#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_WaitInputAction_Sub2792249764.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<WaitAIInput/Sub>
struct VP_1_t1376569142;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitAIInput
struct  WaitAIInput_t471222699  : public Sub_t2792249764
{
public:
	// VP`1<System.UInt32> WaitAIInput::userThink
	VP_1_t2527959027 * ___userThink_5;
	// VP`1<System.UInt32> WaitAIInput::rethink
	VP_1_t2527959027 * ___rethink_6;
	// VP`1<WaitAIInput/Sub> WaitAIInput::sub
	VP_1_t1376569142 * ___sub_7;

public:
	inline static int32_t get_offset_of_userThink_5() { return static_cast<int32_t>(offsetof(WaitAIInput_t471222699, ___userThink_5)); }
	inline VP_1_t2527959027 * get_userThink_5() const { return ___userThink_5; }
	inline VP_1_t2527959027 ** get_address_of_userThink_5() { return &___userThink_5; }
	inline void set_userThink_5(VP_1_t2527959027 * value)
	{
		___userThink_5 = value;
		Il2CppCodeGenWriteBarrier(&___userThink_5, value);
	}

	inline static int32_t get_offset_of_rethink_6() { return static_cast<int32_t>(offsetof(WaitAIInput_t471222699, ___rethink_6)); }
	inline VP_1_t2527959027 * get_rethink_6() const { return ___rethink_6; }
	inline VP_1_t2527959027 ** get_address_of_rethink_6() { return &___rethink_6; }
	inline void set_rethink_6(VP_1_t2527959027 * value)
	{
		___rethink_6 = value;
		Il2CppCodeGenWriteBarrier(&___rethink_6, value);
	}

	inline static int32_t get_offset_of_sub_7() { return static_cast<int32_t>(offsetof(WaitAIInput_t471222699, ___sub_7)); }
	inline VP_1_t1376569142 * get_sub_7() const { return ___sub_7; }
	inline VP_1_t1376569142 ** get_address_of_sub_7() { return &___sub_7; }
	inline void set_sub_7(VP_1_t1376569142 * value)
	{
		___sub_7 = value;
		Il2CppCodeGenWriteBarrier(&___sub_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
