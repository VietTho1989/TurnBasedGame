﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FileSystem_ActionEdit_State447933761.h"

// VP`1<System.Single>
struct VP_1_t2454786938;
// LP`1<System.IO.FileSystemInfo>
struct LP_1_t1098735855;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionEditSuccess
struct  ActionEditSuccess_t2214860991  : public State_t447933761
{
public:
	// VP`1<System.Single> FileSystem.ActionEditSuccess::time
	VP_1_t2454786938 * ___time_5;
	// VP`1<System.Single> FileSystem.ActionEditSuccess::duration
	VP_1_t2454786938 * ___duration_6;
	// LP`1<System.IO.FileSystemInfo> FileSystem.ActionEditSuccess::successFiles
	LP_1_t1098735855 * ___successFiles_7;

public:
	inline static int32_t get_offset_of_time_5() { return static_cast<int32_t>(offsetof(ActionEditSuccess_t2214860991, ___time_5)); }
	inline VP_1_t2454786938 * get_time_5() const { return ___time_5; }
	inline VP_1_t2454786938 ** get_address_of_time_5() { return &___time_5; }
	inline void set_time_5(VP_1_t2454786938 * value)
	{
		___time_5 = value;
		Il2CppCodeGenWriteBarrier(&___time_5, value);
	}

	inline static int32_t get_offset_of_duration_6() { return static_cast<int32_t>(offsetof(ActionEditSuccess_t2214860991, ___duration_6)); }
	inline VP_1_t2454786938 * get_duration_6() const { return ___duration_6; }
	inline VP_1_t2454786938 ** get_address_of_duration_6() { return &___duration_6; }
	inline void set_duration_6(VP_1_t2454786938 * value)
	{
		___duration_6 = value;
		Il2CppCodeGenWriteBarrier(&___duration_6, value);
	}

	inline static int32_t get_offset_of_successFiles_7() { return static_cast<int32_t>(offsetof(ActionEditSuccess_t2214860991, ___successFiles_7)); }
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
