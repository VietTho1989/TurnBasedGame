#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UndoRedoRequest_State122743035.h"

// VP`1<UndoRedo.RequestInform>
struct VP_1_t3389450696;
// LP`1<Human>
struct LP_1_t4188799745;
// LP`1<System.UInt32>
struct LP_1_t887425977;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.Ask
struct  Ask_t735773131  : public State_t122743035
{
public:
	// VP`1<UndoRedo.RequestInform> UndoRedo.Ask::requestInform
	VP_1_t3389450696 * ___requestInform_5;
	// LP`1<Human> UndoRedo.Ask::whoCanAsks
	LP_1_t4188799745 * ___whoCanAsks_6;
	// LP`1<System.UInt32> UndoRedo.Ask::accepts
	LP_1_t887425977 * ___accepts_7;
	// LP`1<System.UInt32> UndoRedo.Ask::cancels
	LP_1_t887425977 * ___cancels_8;

public:
	inline static int32_t get_offset_of_requestInform_5() { return static_cast<int32_t>(offsetof(Ask_t735773131, ___requestInform_5)); }
	inline VP_1_t3389450696 * get_requestInform_5() const { return ___requestInform_5; }
	inline VP_1_t3389450696 ** get_address_of_requestInform_5() { return &___requestInform_5; }
	inline void set_requestInform_5(VP_1_t3389450696 * value)
	{
		___requestInform_5 = value;
		Il2CppCodeGenWriteBarrier(&___requestInform_5, value);
	}

	inline static int32_t get_offset_of_whoCanAsks_6() { return static_cast<int32_t>(offsetof(Ask_t735773131, ___whoCanAsks_6)); }
	inline LP_1_t4188799745 * get_whoCanAsks_6() const { return ___whoCanAsks_6; }
	inline LP_1_t4188799745 ** get_address_of_whoCanAsks_6() { return &___whoCanAsks_6; }
	inline void set_whoCanAsks_6(LP_1_t4188799745 * value)
	{
		___whoCanAsks_6 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAsks_6, value);
	}

	inline static int32_t get_offset_of_accepts_7() { return static_cast<int32_t>(offsetof(Ask_t735773131, ___accepts_7)); }
	inline LP_1_t887425977 * get_accepts_7() const { return ___accepts_7; }
	inline LP_1_t887425977 ** get_address_of_accepts_7() { return &___accepts_7; }
	inline void set_accepts_7(LP_1_t887425977 * value)
	{
		___accepts_7 = value;
		Il2CppCodeGenWriteBarrier(&___accepts_7, value);
	}

	inline static int32_t get_offset_of_cancels_8() { return static_cast<int32_t>(offsetof(Ask_t735773131, ___cancels_8)); }
	inline LP_1_t887425977 * get_cancels_8() const { return ___cancels_8; }
	inline LP_1_t887425977 ** get_address_of_cancels_8() { return &___cancels_8; }
	inline void set_cancels_8(LP_1_t887425977 * value)
	{
		___cancels_8 = value;
		Il2CppCodeGenWriteBarrier(&___cancels_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
