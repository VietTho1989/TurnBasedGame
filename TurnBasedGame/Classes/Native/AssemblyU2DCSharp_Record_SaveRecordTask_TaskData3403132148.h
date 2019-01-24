#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// Record.DataRecord
struct DataRecord_t228000813;
// System.IO.FileInfo
struct FileInfo_t3153503742;
// VP`1<Record.SaveRecordTask/TaskData/State>
struct VP_1_t4149051264;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.SaveRecordTask/TaskData
struct  TaskData_t3403132148  : public Data_t3569509720
{
public:
	// Record.DataRecord Record.SaveRecordTask/TaskData::dataRecord
	DataRecord_t228000813 * ___dataRecord_5;
	// System.IO.FileInfo Record.SaveRecordTask/TaskData::file
	FileInfo_t3153503742 * ___file_6;
	// VP`1<Record.SaveRecordTask/TaskData/State> Record.SaveRecordTask/TaskData::state
	VP_1_t4149051264 * ___state_7;

public:
	inline static int32_t get_offset_of_dataRecord_5() { return static_cast<int32_t>(offsetof(TaskData_t3403132148, ___dataRecord_5)); }
	inline DataRecord_t228000813 * get_dataRecord_5() const { return ___dataRecord_5; }
	inline DataRecord_t228000813 ** get_address_of_dataRecord_5() { return &___dataRecord_5; }
	inline void set_dataRecord_5(DataRecord_t228000813 * value)
	{
		___dataRecord_5 = value;
		Il2CppCodeGenWriteBarrier(&___dataRecord_5, value);
	}

	inline static int32_t get_offset_of_file_6() { return static_cast<int32_t>(offsetof(TaskData_t3403132148, ___file_6)); }
	inline FileInfo_t3153503742 * get_file_6() const { return ___file_6; }
	inline FileInfo_t3153503742 ** get_address_of_file_6() { return &___file_6; }
	inline void set_file_6(FileInfo_t3153503742 * value)
	{
		___file_6 = value;
		Il2CppCodeGenWriteBarrier(&___file_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(TaskData_t3403132148, ___state_7)); }
	inline VP_1_t4149051264 * get_state_7() const { return ___state_7; }
	inline VP_1_t4149051264 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t4149051264 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
