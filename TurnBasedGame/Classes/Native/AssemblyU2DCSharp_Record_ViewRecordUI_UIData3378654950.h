#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Record.DataRecord>
struct VP_1_t606277819;
// VP`1<Record.ViewRecordUI/UIData/Sub>
struct VP_1_t4242615811;
// VP`1<Record.ViewRecordControllerUI/UIData>
struct VP_1_t705221292;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.ViewRecordUI/UIData
struct  UIData_t3378654950  : public Data_t3569509720
{
public:
	// VP`1<Record.DataRecord> Record.ViewRecordUI/UIData::dataRecord
	VP_1_t606277819 * ___dataRecord_5;
	// VP`1<Record.ViewRecordUI/UIData/Sub> Record.ViewRecordUI/UIData::sub
	VP_1_t4242615811 * ___sub_6;
	// VP`1<Record.ViewRecordControllerUI/UIData> Record.ViewRecordUI/UIData::controller
	VP_1_t705221292 * ___controller_7;

public:
	inline static int32_t get_offset_of_dataRecord_5() { return static_cast<int32_t>(offsetof(UIData_t3378654950, ___dataRecord_5)); }
	inline VP_1_t606277819 * get_dataRecord_5() const { return ___dataRecord_5; }
	inline VP_1_t606277819 ** get_address_of_dataRecord_5() { return &___dataRecord_5; }
	inline void set_dataRecord_5(VP_1_t606277819 * value)
	{
		___dataRecord_5 = value;
		Il2CppCodeGenWriteBarrier(&___dataRecord_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t3378654950, ___sub_6)); }
	inline VP_1_t4242615811 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t4242615811 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t4242615811 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}

	inline static int32_t get_offset_of_controller_7() { return static_cast<int32_t>(offsetof(UIData_t3378654950, ___controller_7)); }
	inline VP_1_t705221292 * get_controller_7() const { return ___controller_7; }
	inline VP_1_t705221292 ** get_address_of_controller_7() { return &___controller_7; }
	inline void set_controller_7(VP_1_t705221292 * value)
	{
		___controller_7 = value;
		Il2CppCodeGenWriteBarrier(&___controller_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
