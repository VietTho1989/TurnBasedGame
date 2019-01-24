#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<EditData`1<Computer/AI>>
struct VP_1_t1242305994;
// VP`1<AIUI/UIData/Sub>
struct VP_1_t3615281248;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AIUI/UIData
struct  UIData_t4294452609  : public Data_t3569509720
{
public:
	// VP`1<EditData`1<Computer/AI>> AIUI/UIData::editAI
	VP_1_t1242305994 * ___editAI_5;
	// VP`1<AIUI/UIData/Sub> AIUI/UIData::sub
	VP_1_t3615281248 * ___sub_6;

public:
	inline static int32_t get_offset_of_editAI_5() { return static_cast<int32_t>(offsetof(UIData_t4294452609, ___editAI_5)); }
	inline VP_1_t1242305994 * get_editAI_5() const { return ___editAI_5; }
	inline VP_1_t1242305994 ** get_address_of_editAI_5() { return &___editAI_5; }
	inline void set_editAI_5(VP_1_t1242305994 * value)
	{
		___editAI_5 = value;
		Il2CppCodeGenWriteBarrier(&___editAI_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t4294452609, ___sub_6)); }
	inline VP_1_t3615281248 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t3615281248 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t3615281248 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
