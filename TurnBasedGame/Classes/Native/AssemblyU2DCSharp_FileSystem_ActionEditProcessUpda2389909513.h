#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_FileSystem_ActionEdit_Action2900589496.h"
#include "AssemblyU2DCSharp_FileSystem_ActionEditProcessUpdat544763133.h"

// System.IO.FileSystemInfo
struct FileSystemInfo_t2360991899;
// System.IO.DirectoryInfo
struct DirectoryInfo_t1934446453;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionEditProcessUpdate/Work
struct  Work_t2389909513  : public Il2CppObject
{
public:
	// System.IO.FileSystemInfo FileSystem.ActionEditProcessUpdate/Work::file
	FileSystemInfo_t2360991899 * ___file_0;
	// System.IO.DirectoryInfo FileSystem.ActionEditProcessUpdate/Work::destDir
	DirectoryInfo_t1934446453 * ___destDir_1;
	// FileSystem.ActionEdit/Action FileSystem.ActionEditProcessUpdate/Work::action
	int32_t ___action_2;
	// FileSystem.ActionEditProcessUpdate/Work/State FileSystem.ActionEditProcessUpdate/Work::state
	int32_t ___state_3;

public:
	inline static int32_t get_offset_of_file_0() { return static_cast<int32_t>(offsetof(Work_t2389909513, ___file_0)); }
	inline FileSystemInfo_t2360991899 * get_file_0() const { return ___file_0; }
	inline FileSystemInfo_t2360991899 ** get_address_of_file_0() { return &___file_0; }
	inline void set_file_0(FileSystemInfo_t2360991899 * value)
	{
		___file_0 = value;
		Il2CppCodeGenWriteBarrier(&___file_0, value);
	}

	inline static int32_t get_offset_of_destDir_1() { return static_cast<int32_t>(offsetof(Work_t2389909513, ___destDir_1)); }
	inline DirectoryInfo_t1934446453 * get_destDir_1() const { return ___destDir_1; }
	inline DirectoryInfo_t1934446453 ** get_address_of_destDir_1() { return &___destDir_1; }
	inline void set_destDir_1(DirectoryInfo_t1934446453 * value)
	{
		___destDir_1 = value;
		Il2CppCodeGenWriteBarrier(&___destDir_1, value);
	}

	inline static int32_t get_offset_of_action_2() { return static_cast<int32_t>(offsetof(Work_t2389909513, ___action_2)); }
	inline int32_t get_action_2() const { return ___action_2; }
	inline int32_t* get_address_of_action_2() { return &___action_2; }
	inline void set_action_2(int32_t value)
	{
		___action_2 = value;
	}

	inline static int32_t get_offset_of_state_3() { return static_cast<int32_t>(offsetof(Work_t2389909513, ___state_3)); }
	inline int32_t get_state_3() const { return ___state_3; }
	inline int32_t* get_address_of_state_3() { return &___state_3; }
	inline void set_state_3(int32_t value)
	{
		___state_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
