#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FileSystem_ActionEdit_State447933761.h"

// VP`1<System.IO.FileSystemInfo>
struct VP_1_t2739268905;
// LP`1<System.IO.FileSystemInfo>
struct LP_1_t1098735855;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionEditFail
struct  ActionEditFail_t3448136602  : public State_t447933761
{
public:
	// VP`1<System.IO.FileSystemInfo> FileSystem.ActionEditFail::failFile
	VP_1_t2739268905 * ___failFile_5;
	// LP`1<System.IO.FileSystemInfo> FileSystem.ActionEditFail::successFiles
	LP_1_t1098735855 * ___successFiles_6;
	// VP`1<System.Single> FileSystem.ActionEditFail::time
	VP_1_t2454786938 * ___time_7;
	// VP`1<System.Single> FileSystem.ActionEditFail::duration
	VP_1_t2454786938 * ___duration_8;

public:
	inline static int32_t get_offset_of_failFile_5() { return static_cast<int32_t>(offsetof(ActionEditFail_t3448136602, ___failFile_5)); }
	inline VP_1_t2739268905 * get_failFile_5() const { return ___failFile_5; }
	inline VP_1_t2739268905 ** get_address_of_failFile_5() { return &___failFile_5; }
	inline void set_failFile_5(VP_1_t2739268905 * value)
	{
		___failFile_5 = value;
		Il2CppCodeGenWriteBarrier(&___failFile_5, value);
	}

	inline static int32_t get_offset_of_successFiles_6() { return static_cast<int32_t>(offsetof(ActionEditFail_t3448136602, ___successFiles_6)); }
	inline LP_1_t1098735855 * get_successFiles_6() const { return ___successFiles_6; }
	inline LP_1_t1098735855 ** get_address_of_successFiles_6() { return &___successFiles_6; }
	inline void set_successFiles_6(LP_1_t1098735855 * value)
	{
		___successFiles_6 = value;
		Il2CppCodeGenWriteBarrier(&___successFiles_6, value);
	}

	inline static int32_t get_offset_of_time_7() { return static_cast<int32_t>(offsetof(ActionEditFail_t3448136602, ___time_7)); }
	inline VP_1_t2454786938 * get_time_7() const { return ___time_7; }
	inline VP_1_t2454786938 ** get_address_of_time_7() { return &___time_7; }
	inline void set_time_7(VP_1_t2454786938 * value)
	{
		___time_7 = value;
		Il2CppCodeGenWriteBarrier(&___time_7, value);
	}

	inline static int32_t get_offset_of_duration_8() { return static_cast<int32_t>(offsetof(ActionEditFail_t3448136602, ___duration_8)); }
	inline VP_1_t2454786938 * get_duration_8() const { return ___duration_8; }
	inline VP_1_t2454786938 ** get_address_of_duration_8() { return &___duration_8; }
	inline void set_duration_8(VP_1_t2454786938 * value)
	{
		___duration_8 = value;
		Il2CppCodeGenWriteBarrier(&___duration_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
