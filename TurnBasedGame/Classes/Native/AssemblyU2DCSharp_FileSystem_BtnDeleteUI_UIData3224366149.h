#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<FileSystem.FileSystemBrowser>>
struct VP_1_t4194337164;
// VP`1<FileSystem.BtnDeleteConfirmUI/UIData>
struct VP_1_t4265415305;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnDeleteUI/UIData
struct  UIData_t3224366149  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<FileSystem.FileSystemBrowser>> FileSystem.BtnDeleteUI/UIData::fileSystemBrowser
	VP_1_t4194337164 * ___fileSystemBrowser_5;
	// VP`1<FileSystem.BtnDeleteConfirmUI/UIData> FileSystem.BtnDeleteUI/UIData::btnDeleteConfirm
	VP_1_t4265415305 * ___btnDeleteConfirm_6;

public:
	inline static int32_t get_offset_of_fileSystemBrowser_5() { return static_cast<int32_t>(offsetof(UIData_t3224366149, ___fileSystemBrowser_5)); }
	inline VP_1_t4194337164 * get_fileSystemBrowser_5() const { return ___fileSystemBrowser_5; }
	inline VP_1_t4194337164 ** get_address_of_fileSystemBrowser_5() { return &___fileSystemBrowser_5; }
	inline void set_fileSystemBrowser_5(VP_1_t4194337164 * value)
	{
		___fileSystemBrowser_5 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowser_5, value);
	}

	inline static int32_t get_offset_of_btnDeleteConfirm_6() { return static_cast<int32_t>(offsetof(UIData_t3224366149, ___btnDeleteConfirm_6)); }
	inline VP_1_t4265415305 * get_btnDeleteConfirm_6() const { return ___btnDeleteConfirm_6; }
	inline VP_1_t4265415305 ** get_address_of_btnDeleteConfirm_6() { return &___btnDeleteConfirm_6; }
	inline void set_btnDeleteConfirm_6(VP_1_t4265415305 * value)
	{
		___btnDeleteConfirm_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnDeleteConfirm_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
