#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.IO.DirectoryInfo>
struct VP_1_t2312723459;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Int64>
struct VP_1_t1287355043;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DirectoryChange
struct  DirectoryChange_t331442689  : public Data_t3569509720
{
public:
	// VP`1<System.IO.DirectoryInfo> DirectoryChange::oldDir
	VP_1_t2312723459 * ___oldDir_5;
	// VP`1<System.IO.DirectoryInfo> DirectoryChange::newDir
	VP_1_t2312723459 * ___newDir_6;
	// VP`1<System.Int32> DirectoryChange::position
	VP_1_t2450154454 * ___position_7;
	// VP`1<System.Int64> DirectoryChange::time
	VP_1_t1287355043 * ___time_8;

public:
	inline static int32_t get_offset_of_oldDir_5() { return static_cast<int32_t>(offsetof(DirectoryChange_t331442689, ___oldDir_5)); }
	inline VP_1_t2312723459 * get_oldDir_5() const { return ___oldDir_5; }
	inline VP_1_t2312723459 ** get_address_of_oldDir_5() { return &___oldDir_5; }
	inline void set_oldDir_5(VP_1_t2312723459 * value)
	{
		___oldDir_5 = value;
		Il2CppCodeGenWriteBarrier(&___oldDir_5, value);
	}

	inline static int32_t get_offset_of_newDir_6() { return static_cast<int32_t>(offsetof(DirectoryChange_t331442689, ___newDir_6)); }
	inline VP_1_t2312723459 * get_newDir_6() const { return ___newDir_6; }
	inline VP_1_t2312723459 ** get_address_of_newDir_6() { return &___newDir_6; }
	inline void set_newDir_6(VP_1_t2312723459 * value)
	{
		___newDir_6 = value;
		Il2CppCodeGenWriteBarrier(&___newDir_6, value);
	}

	inline static int32_t get_offset_of_position_7() { return static_cast<int32_t>(offsetof(DirectoryChange_t331442689, ___position_7)); }
	inline VP_1_t2450154454 * get_position_7() const { return ___position_7; }
	inline VP_1_t2450154454 ** get_address_of_position_7() { return &___position_7; }
	inline void set_position_7(VP_1_t2450154454 * value)
	{
		___position_7 = value;
		Il2CppCodeGenWriteBarrier(&___position_7, value);
	}

	inline static int32_t get_offset_of_time_8() { return static_cast<int32_t>(offsetof(DirectoryChange_t331442689, ___time_8)); }
	inline VP_1_t1287355043 * get_time_8() const { return ___time_8; }
	inline VP_1_t1287355043 ** get_address_of_time_8() { return &___time_8; }
	inline void set_time_8(VP_1_t1287355043 * value)
	{
		___time_8 = value;
		Il2CppCodeGenWriteBarrier(&___time_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
