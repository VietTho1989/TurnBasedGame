#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FileSystem_Action3736177836.h"

// VP`1<FileSystem.ActionEdit/Action>
struct VP_1_t3278866502;
// VP`1<FileSystem.ActionEdit/State>
struct VP_1_t826210767;
// LP`1<System.IO.FileSystemInfo>
struct LP_1_t1098735855;
// VP`1<System.IO.DirectoryInfo>
struct VP_1_t2312723459;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionEdit
struct  ActionEdit_t889109624  : public Action_t3736177836
{
public:
	// VP`1<FileSystem.ActionEdit/Action> FileSystem.ActionEdit::action
	VP_1_t3278866502 * ___action_5;
	// VP`1<FileSystem.ActionEdit/State> FileSystem.ActionEdit::state
	VP_1_t826210767 * ___state_6;
	// LP`1<System.IO.FileSystemInfo> FileSystem.ActionEdit::files
	LP_1_t1098735855 * ___files_7;
	// VP`1<System.IO.DirectoryInfo> FileSystem.ActionEdit::destDir
	VP_1_t2312723459 * ___destDir_8;

public:
	inline static int32_t get_offset_of_action_5() { return static_cast<int32_t>(offsetof(ActionEdit_t889109624, ___action_5)); }
	inline VP_1_t3278866502 * get_action_5() const { return ___action_5; }
	inline VP_1_t3278866502 ** get_address_of_action_5() { return &___action_5; }
	inline void set_action_5(VP_1_t3278866502 * value)
	{
		___action_5 = value;
		Il2CppCodeGenWriteBarrier(&___action_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(ActionEdit_t889109624, ___state_6)); }
	inline VP_1_t826210767 * get_state_6() const { return ___state_6; }
	inline VP_1_t826210767 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t826210767 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_files_7() { return static_cast<int32_t>(offsetof(ActionEdit_t889109624, ___files_7)); }
	inline LP_1_t1098735855 * get_files_7() const { return ___files_7; }
	inline LP_1_t1098735855 ** get_address_of_files_7() { return &___files_7; }
	inline void set_files_7(LP_1_t1098735855 * value)
	{
		___files_7 = value;
		Il2CppCodeGenWriteBarrier(&___files_7, value);
	}

	inline static int32_t get_offset_of_destDir_8() { return static_cast<int32_t>(offsetof(ActionEdit_t889109624, ___destDir_8)); }
	inline VP_1_t2312723459 * get_destDir_8() const { return ___destDir_8; }
	inline VP_1_t2312723459 ** get_address_of_destDir_8() { return &___destDir_8; }
	inline void set_destDir_8(VP_1_t2312723459 * value)
	{
		___destDir_8 = value;
		Il2CppCodeGenWriteBarrier(&___destDir_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
