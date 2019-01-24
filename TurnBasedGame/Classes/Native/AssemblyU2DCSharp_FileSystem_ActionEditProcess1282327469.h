#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FileSystem_ActionEdit_State447933761.h"

// VP`1<FileSystem.ActionEditProcess/State>
struct VP_1_t1789933210;
// LP`1<System.IO.FileSystemInfo>
struct LP_1_t1098735855;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionEditProcess
struct  ActionEditProcess_t1282327469  : public State_t447933761
{
public:
	// VP`1<FileSystem.ActionEditProcess/State> FileSystem.ActionEditProcess::state
	VP_1_t1789933210 * ___state_5;
	// LP`1<System.IO.FileSystemInfo> FileSystem.ActionEditProcess::files
	LP_1_t1098735855 * ___files_6;
	// LP`1<System.IO.FileSystemInfo> FileSystem.ActionEditProcess::successFiles
	LP_1_t1098735855 * ___successFiles_7;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(ActionEditProcess_t1282327469, ___state_5)); }
	inline VP_1_t1789933210 * get_state_5() const { return ___state_5; }
	inline VP_1_t1789933210 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t1789933210 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_files_6() { return static_cast<int32_t>(offsetof(ActionEditProcess_t1282327469, ___files_6)); }
	inline LP_1_t1098735855 * get_files_6() const { return ___files_6; }
	inline LP_1_t1098735855 ** get_address_of_files_6() { return &___files_6; }
	inline void set_files_6(LP_1_t1098735855 * value)
	{
		___files_6 = value;
		Il2CppCodeGenWriteBarrier(&___files_6, value);
	}

	inline static int32_t get_offset_of_successFiles_7() { return static_cast<int32_t>(offsetof(ActionEditProcess_t1282327469, ___successFiles_7)); }
	inline LP_1_t1098735855 * get_successFiles_7() const { return ___successFiles_7; }
	inline LP_1_t1098735855 ** get_address_of_successFiles_7() { return &___successFiles_7; }
	inline void set_successFiles_7(LP_1_t1098735855 * value)
	{
		___successFiles_7 = value;
		Il2CppCodeGenWriteBarrier(&___successFiles_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
