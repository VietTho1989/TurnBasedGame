#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<FileSystem.FileSystemBrowserUI/UIData>
struct VP_1_t2919154865;
// VP`1<Record.SaveRecordTask/TaskData>
struct VP_1_t3781409154;
// VP`1<Record.ConfirmSaveRecordUI/UIData>
struct VP_1_t2707626226;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.SaveRecordUI/UIData
struct  UIData_t934483118  : public Data_t3569509720
{
public:
	// VP`1<FileSystem.FileSystemBrowserUI/UIData> Record.SaveRecordUI/UIData::fileSystemBrowser
	VP_1_t2919154865 * ___fileSystemBrowser_5;
	// VP`1<Record.SaveRecordTask/TaskData> Record.SaveRecordUI/UIData::saveTask
	VP_1_t3781409154 * ___saveTask_6;
	// VP`1<Record.ConfirmSaveRecordUI/UIData> Record.SaveRecordUI/UIData::confirmSave
	VP_1_t2707626226 * ___confirmSave_7;

public:
	inline static int32_t get_offset_of_fileSystemBrowser_5() { return static_cast<int32_t>(offsetof(UIData_t934483118, ___fileSystemBrowser_5)); }
	inline VP_1_t2919154865 * get_fileSystemBrowser_5() const { return ___fileSystemBrowser_5; }
	inline VP_1_t2919154865 ** get_address_of_fileSystemBrowser_5() { return &___fileSystemBrowser_5; }
	inline void set_fileSystemBrowser_5(VP_1_t2919154865 * value)
	{
		___fileSystemBrowser_5 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowser_5, value);
	}

	inline static int32_t get_offset_of_saveTask_6() { return static_cast<int32_t>(offsetof(UIData_t934483118, ___saveTask_6)); }
	inline VP_1_t3781409154 * get_saveTask_6() const { return ___saveTask_6; }
	inline VP_1_t3781409154 ** get_address_of_saveTask_6() { return &___saveTask_6; }
	inline void set_saveTask_6(VP_1_t3781409154 * value)
	{
		___saveTask_6 = value;
		Il2CppCodeGenWriteBarrier(&___saveTask_6, value);
	}

	inline static int32_t get_offset_of_confirmSave_7() { return static_cast<int32_t>(offsetof(UIData_t934483118, ___confirmSave_7)); }
	inline VP_1_t2707626226 * get_confirmSave_7() const { return ___confirmSave_7; }
	inline VP_1_t2707626226 ** get_address_of_confirmSave_7() { return &___confirmSave_7; }
	inline void set_confirmSave_7(VP_1_t2707626226 * value)
	{
		___confirmSave_7 = value;
		Il2CppCodeGenWriteBarrier(&___confirmSave_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
