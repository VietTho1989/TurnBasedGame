#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Data>>
struct VP_1_t3018569789;
// VP`1<Record.DataRecordTask/State>
struct VP_1_t2636461027;
// Record.DataRecord
struct DataRecord_t228000813;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.DataRecordTask
struct  DataRecordTask_t1813021942  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Data>> Record.DataRecordTask::needRecordData
	VP_1_t3018569789 * ___needRecordData_5;
	// VP`1<Record.DataRecordTask/State> Record.DataRecordTask::state
	VP_1_t2636461027 * ___state_6;
	// Record.DataRecord Record.DataRecordTask::record
	DataRecord_t228000813 * ___record_7;

public:
	inline static int32_t get_offset_of_needRecordData_5() { return static_cast<int32_t>(offsetof(DataRecordTask_t1813021942, ___needRecordData_5)); }
	inline VP_1_t3018569789 * get_needRecordData_5() const { return ___needRecordData_5; }
	inline VP_1_t3018569789 ** get_address_of_needRecordData_5() { return &___needRecordData_5; }
	inline void set_needRecordData_5(VP_1_t3018569789 * value)
	{
		___needRecordData_5 = value;
		Il2CppCodeGenWriteBarrier(&___needRecordData_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(DataRecordTask_t1813021942, ___state_6)); }
	inline VP_1_t2636461027 * get_state_6() const { return ___state_6; }
	inline VP_1_t2636461027 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2636461027 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_record_7() { return static_cast<int32_t>(offsetof(DataRecordTask_t1813021942, ___record_7)); }
	inline DataRecord_t228000813 * get_record_7() const { return ___record_7; }
	inline DataRecord_t228000813 ** get_address_of_record_7() { return &___record_7; }
	inline void set_record_7(DataRecord_t228000813 * value)
	{
		___record_7 = value;
		Il2CppCodeGenWriteBarrier(&___record_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
