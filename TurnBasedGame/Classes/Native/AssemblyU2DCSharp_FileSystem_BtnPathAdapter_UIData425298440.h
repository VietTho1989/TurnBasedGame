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
// LP`1<FileSystem.BtnPathHolder/UIData>
struct LP_1_t3927940769;
// System.Collections.Generic.List`1<System.IO.DirectoryInfo>
struct List_1_t1303567585;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnPathAdapter/UIData
struct  UIData_t425298440  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<FileSystem.ShowDirectory>> FileSystem.BtnPathAdapter/UIData::showDirectory
	VP_1_t3755201233 * ___showDirectory_20;
	// LP`1<FileSystem.BtnPathHolder/UIData> FileSystem.BtnPathAdapter/UIData::holders
	LP_1_t3927940769 * ___holders_21;
	// System.Collections.Generic.List`1<System.IO.DirectoryInfo> FileSystem.BtnPathAdapter/UIData::dirs
	List_1_t1303567585 * ___dirs_22;

public:
	inline static int32_t get_offset_of_showDirectory_20() { return static_cast<int32_t>(offsetof(UIData_t425298440, ___showDirectory_20)); }
	inline VP_1_t3755201233 * get_showDirectory_20() const { return ___showDirectory_20; }
	inline VP_1_t3755201233 ** get_address_of_showDirectory_20() { return &___showDirectory_20; }
	inline void set_showDirectory_20(VP_1_t3755201233 * value)
	{
		___showDirectory_20 = value;
		Il2CppCodeGenWriteBarrier(&___showDirectory_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t425298440, ___holders_21)); }
	inline LP_1_t3927940769 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3927940769 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3927940769 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_dirs_22() { return static_cast<int32_t>(offsetof(UIData_t425298440, ___dirs_22)); }
	inline List_1_t1303567585 * get_dirs_22() const { return ___dirs_22; }
	inline List_1_t1303567585 ** get_address_of_dirs_22() { return &___dirs_22; }
	inline void set_dirs_22(List_1_t1303567585 * value)
	{
		___dirs_22 = value;
		Il2CppCodeGenWriteBarrier(&___dirs_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
