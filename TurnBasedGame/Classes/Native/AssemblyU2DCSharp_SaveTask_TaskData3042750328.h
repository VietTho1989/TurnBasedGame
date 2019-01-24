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
// VP`1<SaveTask/TaskData/State>
struct VP_1_t3192190284;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SaveTask/TaskData
struct  TaskData_t3042750328  : public Data_t3569509720
{
public:
	// Save SaveTask/TaskData::save
	Save_t1600141839 * ___save_5;
	// System.IO.FileInfo SaveTask/TaskData::file
	FileInfo_t3153503742 * ___file_6;
	// VP`1<SaveTask/TaskData/State> SaveTask/TaskData::state
	VP_1_t3192190284 * ___state_7;

public:
	inline static int32_t get_offset_of_save_5() { return static_cast<int32_t>(offsetof(TaskData_t3042750328, ___save_5)); }
	inline Save_t1600141839 * get_save_5() const { return ___save_5; }
	inline Save_t1600141839 ** get_address_of_save_5() { return &___save_5; }
	inline void set_save_5(Save_t1600141839 * value)
	{
		___save_5 = value;
		Il2CppCodeGenWriteBarrier(&___save_5, value);
	}

	inline static int32_t get_offset_of_file_6() { return static_cast<int32_t>(offsetof(TaskData_t3042750328, ___file_6)); }
	inline FileInfo_t3153503742 * get_file_6() const { return ___file_6; }
	inline FileInfo_t3153503742 ** get_address_of_file_6() { return &___file_6; }
	inline void set_file_6(FileInfo_t3153503742 * value)
	{
		___file_6 = value;
		Il2CppCodeGenWriteBarrier(&___file_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(TaskData_t3042750328, ___state_7)); }
	inline VP_1_t3192190284 * get_state_7() const { return ___state_7; }
	inline VP_1_t3192190284 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t3192190284 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
