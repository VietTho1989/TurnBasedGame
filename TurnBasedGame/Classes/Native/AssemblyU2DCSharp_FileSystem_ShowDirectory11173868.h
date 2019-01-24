#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<FileSystem.ShowDirectory/State>
struct VP_1_t2908124859;
// VP`1<System.IO.DirectoryInfo>
struct VP_1_t2312723459;
// VP`1<FileSystem.DirectoryHistory>
struct VP_1_t371607447;
// LP`1<System.IO.FileSystemInfo>
struct LP_1_t1098735855;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ShowDirectory
struct  ShowDirectory_t11173868  : public Data_t3569509720
{
public:
	// VP`1<FileSystem.ShowDirectory/State> FileSystem.ShowDirectory::state
	VP_1_t2908124859 * ___state_5;
	// VP`1<System.IO.DirectoryInfo> FileSystem.ShowDirectory::directory
	VP_1_t2312723459 * ___directory_6;
	// VP`1<FileSystem.DirectoryHistory> FileSystem.ShowDirectory::directoryHistory
	VP_1_t371607447 * ___directoryHistory_7;
	// LP`1<System.IO.FileSystemInfo> FileSystem.ShowDirectory::files
	LP_1_t1098735855 * ___files_8;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(ShowDirectory_t11173868, ___state_5)); }
	inline VP_1_t2908124859 * get_state_5() const { return ___state_5; }
	inline VP_1_t2908124859 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2908124859 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_directory_6() { return static_cast<int32_t>(offsetof(ShowDirectory_t11173868, ___directory_6)); }
	inline VP_1_t2312723459 * get_directory_6() const { return ___directory_6; }
	inline VP_1_t2312723459 ** get_address_of_directory_6() { return &___directory_6; }
	inline void set_directory_6(VP_1_t2312723459 * value)
	{
		___directory_6 = value;
		Il2CppCodeGenWriteBarrier(&___directory_6, value);
	}

	inline static int32_t get_offset_of_directoryHistory_7() { return static_cast<int32_t>(offsetof(ShowDirectory_t11173868, ___directoryHistory_7)); }
	inline VP_1_t371607447 * get_directoryHistory_7() const { return ___directoryHistory_7; }
	inline VP_1_t371607447 ** get_address_of_directoryHistory_7() { return &___directoryHistory_7; }
	inline void set_directoryHistory_7(VP_1_t371607447 * value)
	{
		___directoryHistory_7 = value;
		Il2CppCodeGenWriteBarrier(&___directoryHistory_7, value);
	}

	inline static int32_t get_offset_of_files_8() { return static_cast<int32_t>(offsetof(ShowDirectory_t11173868, ___files_8)); }
	inline LP_1_t1098735855 * get_files_8() const { return ___files_8; }
	inline LP_1_t1098735855 ** get_address_of_files_8() { return &___files_8; }
	inline void set_files_8(LP_1_t1098735855 * value)
	{
		___files_8 = value;
		Il2CppCodeGenWriteBarrier(&___files_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
