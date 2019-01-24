#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<RequestDraw>>
struct VP_1_t3343447856;
// VP`1<RequestDrawUI/UIData/Sub>
struct VP_1_t2761687713;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDrawUI/UIData
struct  UIData_t2668097912  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<RequestDraw>> RequestDrawUI/UIData::requestDraw
	VP_1_t3343447856 * ___requestDraw_5;
	// VP`1<RequestDrawUI/UIData/Sub> RequestDrawUI/UIData::sub
	VP_1_t2761687713 * ___sub_6;

public:
	inline static int32_t get_offset_of_requestDraw_5() { return static_cast<int32_t>(offsetof(UIData_t2668097912, ___requestDraw_5)); }
	inline VP_1_t3343447856 * get_requestDraw_5() const { return ___requestDraw_5; }
	inline VP_1_t3343447856 ** get_address_of_requestDraw_5() { return &___requestDraw_5; }
	inline void set_requestDraw_5(VP_1_t3343447856 * value)
	{
		___requestDraw_5 = value;
		Il2CppCodeGenWriteBarrier(&___requestDraw_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2668097912, ___sub_6)); }
	inline VP_1_t2761687713 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2761687713 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2761687713 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
