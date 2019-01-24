#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<FileSystem.ShowDirectory>>
struct VP_1_t3755201233;
// VP`1<FileSystem.RenameFileUI/UIData>
struct VP_1_t4034724578;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnRenameFileUI/UIData
struct  UIData_t9156022  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<FileSystem.ShowDirectory>> FileSystem.BtnRenameFileUI/UIData::showDirectory
	VP_1_t3755201233 * ___showDirectory_5;
	// VP`1<FileSystem.RenameFileUI/UIData> FileSystem.BtnRenameFileUI/UIData::renameFile
	VP_1_t4034724578 * ___renameFile_6;

public:
	inline static int32_t get_offset_of_showDirectory_5() { return static_cast<int32_t>(offsetof(UIData_t9156022, ___showDirectory_5)); }
	inline VP_1_t3755201233 * get_showDirectory_5() const { return ___showDirectory_5; }
	inline VP_1_t3755201233 ** get_address_of_showDirectory_5() { return &___showDirectory_5; }
	inline void set_showDirectory_5(VP_1_t3755201233 * value)
	{
		___showDirectory_5 = value;
		Il2CppCodeGenWriteBarrier(&___showDirectory_5, value);
	}

	inline static int32_t get_offset_of_renameFile_6() { return static_cast<int32_t>(offsetof(UIData_t9156022, ___renameFile_6)); }
	inline VP_1_t4034724578 * get_renameFile_6() const { return ___renameFile_6; }
	inline VP_1_t4034724578 ** get_address_of_renameFile_6() { return &___renameFile_6; }
	inline void set_renameFile_6(VP_1_t4034724578 * value)
	{
		___renameFile_6 = value;
		Il2CppCodeGenWriteBarrier(&___renameFile_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
