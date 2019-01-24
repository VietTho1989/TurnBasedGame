#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<FileSystem.ShowDirectory>>
struct VP_1_t3755201233;
// VP`1<SortDataUI/UIData>
struct VP_1_t706396857;
// LP`1<FileSystem.FileHolder/UIData>
struct LP_1_t811043078;
// System.Collections.Generic.List`1<System.IO.FileSystemInfo>
struct List_1_t1730113031;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.FileAdapter/UIData
struct  UIData_t1902045001  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<FileSystem.ShowDirectory>> FileSystem.FileAdapter/UIData::showDirectory
	VP_1_t3755201233 * ___showDirectory_20;
	// VP`1<SortDataUI/UIData> FileSystem.FileAdapter/UIData::sortData
	VP_1_t706396857 * ___sortData_21;
	// LP`1<FileSystem.FileHolder/UIData> FileSystem.FileAdapter/UIData::holders
	LP_1_t811043078 * ___holders_22;
	// System.Collections.Generic.List`1<System.IO.FileSystemInfo> FileSystem.FileAdapter/UIData::files
	List_1_t1730113031 * ___files_23;

public:
	inline static int32_t get_offset_of_showDirectory_20() { return static_cast<int32_t>(offsetof(UIData_t1902045001, ___showDirectory_20)); }
	inline VP_1_t3755201233 * get_showDirectory_20() const { return ___showDirectory_20; }
	inline VP_1_t3755201233 ** get_address_of_showDirectory_20() { return &___showDirectory_20; }
	inline void set_showDirectory_20(VP_1_t3755201233 * value)
	{
		___showDirectory_20 = value;
		Il2CppCodeGenWriteBarrier(&___showDirectory_20, value);
	}

	inline static int32_t get_offset_of_sortData_21() { return static_cast<int32_t>(offsetof(UIData_t1902045001, ___sortData_21)); }
	inline VP_1_t706396857 * get_sortData_21() const { return ___sortData_21; }
	inline VP_1_t706396857 ** get_address_of_sortData_21() { return &___sortData_21; }
	inline void set_sortData_21(VP_1_t706396857 * value)
	{
		___sortData_21 = value;
		Il2CppCodeGenWriteBarrier(&___sortData_21, value);
	}

	inline static int32_t get_offset_of_holders_22() { return static_cast<int32_t>(offsetof(UIData_t1902045001, ___holders_22)); }
	inline LP_1_t811043078 * get_holders_22() const { return ___holders_22; }
	inline LP_1_t811043078 ** get_address_of_holders_22() { return &___holders_22; }
	inline void set_holders_22(LP_1_t811043078 * value)
	{
		___holders_22 = value;
		Il2CppCodeGenWriteBarrier(&___holders_22, value);
	}

	inline static int32_t get_offset_of_files_23() { return static_cast<int32_t>(offsetof(UIData_t1902045001, ___files_23)); }
	inline List_1_t1730113031 * get_files_23() const { return ___files_23; }
	inline List_1_t1730113031 ** get_address_of_files_23() { return &___files_23; }
	inline void set_files_23(List_1_t1730113031 * value)
	{
		___files_23 = value;
		Il2CppCodeGenWriteBarrier(&___files_23, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
