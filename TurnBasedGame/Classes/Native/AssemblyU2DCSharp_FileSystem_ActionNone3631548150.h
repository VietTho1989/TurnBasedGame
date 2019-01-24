#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FileSystem_Action3736177836.h"

// VP`1<FileSystem.ActionNone/State>
struct VP_1_t2947655009;
// LP`1<System.IO.FileSystemInfo>
struct LP_1_t1098735855;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionNone
struct  ActionNone_t3631548150  : public Action_t3736177836
{
public:
	// VP`1<FileSystem.ActionNone/State> FileSystem.ActionNone::state
	VP_1_t2947655009 * ___state_5;
	// LP`1<System.IO.FileSystemInfo> FileSystem.ActionNone::selectFiles
	LP_1_t1098735855 * ___selectFiles_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(ActionNone_t3631548150, ___state_5)); }
	inline VP_1_t2947655009 * get_state_5() const { return ___state_5; }
	inline VP_1_t2947655009 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2947655009 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_selectFiles_6() { return static_cast<int32_t>(offsetof(ActionNone_t3631548150, ___selectFiles_6)); }
	inline LP_1_t1098735855 * get_selectFiles_6() const { return ___selectFiles_6; }
	inline LP_1_t1098735855 ** get_address_of_selectFiles_6() { return &___selectFiles_6; }
	inline void set_selectFiles_6(LP_1_t1098735855 * value)
	{
		___selectFiles_6 = value;
		Il2CppCodeGenWriteBarrier(&___selectFiles_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
