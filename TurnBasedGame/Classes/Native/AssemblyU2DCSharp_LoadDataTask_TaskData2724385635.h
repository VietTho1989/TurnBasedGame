#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// Save
struct Save_t1600141839;
// System.IO.FileInfo
struct FileInfo_t3153503742;
// VP`1<LoadDataTask/TaskData/State>
struct VP_1_t1935561361;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoadDataTask/TaskData
struct  TaskData_t2724385635  : public Data_t3569509720
{
public:
	// Save LoadDataTask/TaskData::save
	Save_t1600141839 * ___save_5;
	// System.IO.FileInfo LoadDataTask/TaskData::file
	FileInfo_t3153503742 * ___file_6;
	// VP`1<LoadDataTask/TaskData/State> LoadDataTask/TaskData::state
	VP_1_t1935561361 * ___state_7;

public:
	inline static int32_t get_offset_of_save_5() { return static_cast<int32_t>(offsetof(TaskData_t2724385635, ___save_5)); }
	inline Save_t1600141839 * get_save_5() const { return ___save_5; }
	inline Save_t1600141839 ** get_address_of_save_5() { return &___save_5; }
	inline void set_save_5(Save_t1600141839 * value)
	{
		___save_5 = value;
		Il2CppCodeGenWriteBarrier(&___save_5, value);
	}

	inline static int32_t get_offset_of_file_6() { return static_cast<int32_t>(offsetof(TaskData_t2724385635, ___file_6)); }
	inline FileInfo_t3153503742 * get_file_6() const { return ___file_6; }
	inline FileInfo_t3153503742 ** get_address_of_file_6() { return &___file_6; }
	inline void set_file_6(FileInfo_t3153503742 * value)
	{
		___file_6 = value;
		Il2CppCodeGenWriteBarrier(&___file_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(TaskData_t2724385635, ___state_7)); }
	inline VP_1_t1935561361 * get_state_7() const { return ___state_7; }
	inline VP_1_t1935561361 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t1935561361 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
