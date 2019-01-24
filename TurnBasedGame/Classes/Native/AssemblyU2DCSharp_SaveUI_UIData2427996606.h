#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Data>>
struct VP_1_t3018569789;
// VP`1<FileSystem.FileSystemBrowserUI/UIData>
struct VP_1_t2919154865;
// VP`1<BtnSaveDataUI/UIData>
struct VP_1_t3915015436;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SaveUI/UIData
struct  UIData_t2427996606  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Data>> SaveUI/UIData::needSaveData
	VP_1_t3018569789 * ___needSaveData_5;
	// VP`1<FileSystem.FileSystemBrowserUI/UIData> SaveUI/UIData::fileSystemBrowser
	VP_1_t2919154865 * ___fileSystemBrowser_6;
	// VP`1<BtnSaveDataUI/UIData> SaveUI/UIData::btnSaveData
	VP_1_t3915015436 * ___btnSaveData_7;

public:
	inline static int32_t get_offset_of_needSaveData_5() { return static_cast<int32_t>(offsetof(UIData_t2427996606, ___needSaveData_5)); }
	inline VP_1_t3018569789 * get_needSaveData_5() const { return ___needSaveData_5; }
	inline VP_1_t3018569789 ** get_address_of_needSaveData_5() { return &___needSaveData_5; }
	inline void set_needSaveData_5(VP_1_t3018569789 * value)
	{
		___needSaveData_5 = value;
		Il2CppCodeGenWriteBarrier(&___needSaveData_5, value);
	}

	inline static int32_t get_offset_of_fileSystemBrowser_6() { return static_cast<int32_t>(offsetof(UIData_t2427996606, ___fileSystemBrowser_6)); }
	inline VP_1_t2919154865 * get_fileSystemBrowser_6() const { return ___fileSystemBrowser_6; }
	inline VP_1_t2919154865 ** get_address_of_fileSystemBrowser_6() { return &___fileSystemBrowser_6; }
	inline void set_fileSystemBrowser_6(VP_1_t2919154865 * value)
	{
		___fileSystemBrowser_6 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowser_6, value);
	}

	inline static int32_t get_offset_of_btnSaveData_7() { return static_cast<int32_t>(offsetof(UIData_t2427996606, ___btnSaveData_7)); }
	inline VP_1_t3915015436 * get_btnSaveData_7() const { return ___btnSaveData_7; }
	inline VP_1_t3915015436 ** get_address_of_btnSaveData_7() { return &___btnSaveData_7; }
	inline void set_btnSaveData_7(VP_1_t3915015436 * value)
	{
		___btnSaveData_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnSaveData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
