#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameType/Type>
struct VP_1_t2728349165;
// VP`1<FileSystem.FileSystemBrowserUI/UIData>
struct VP_1_t2919154865;
// VP`1<LoadDataTask/TaskData>
struct VP_1_t3102662641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.LoadPostureUI/UIData
struct  UIData_t1972336781  : public Data_t3569509720
{
public:
	// VP`1<GameType/Type> Posture.LoadPostureUI/UIData::gameType
	VP_1_t2728349165 * ___gameType_5;
	// VP`1<FileSystem.FileSystemBrowserUI/UIData> Posture.LoadPostureUI/UIData::fileSystemBrowser
	VP_1_t2919154865 * ___fileSystemBrowser_6;
	// VP`1<LoadDataTask/TaskData> Posture.LoadPostureUI/UIData::loadDataTask
	VP_1_t3102662641 * ___loadDataTask_7;

public:
	inline static int32_t get_offset_of_gameType_5() { return static_cast<int32_t>(offsetof(UIData_t1972336781, ___gameType_5)); }
	inline VP_1_t2728349165 * get_gameType_5() const { return ___gameType_5; }
	inline VP_1_t2728349165 ** get_address_of_gameType_5() { return &___gameType_5; }
	inline void set_gameType_5(VP_1_t2728349165 * value)
	{
		___gameType_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameType_5, value);
	}

	inline static int32_t get_offset_of_fileSystemBrowser_6() { return static_cast<int32_t>(offsetof(UIData_t1972336781, ___fileSystemBrowser_6)); }
	inline VP_1_t2919154865 * get_fileSystemBrowser_6() const { return ___fileSystemBrowser_6; }
	inline VP_1_t2919154865 ** get_address_of_fileSystemBrowser_6() { return &___fileSystemBrowser_6; }
	inline void set_fileSystemBrowser_6(VP_1_t2919154865 * value)
	{
		___fileSystemBrowser_6 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowser_6, value);
	}

	inline static int32_t get_offset_of_loadDataTask_7() { return static_cast<int32_t>(offsetof(UIData_t1972336781, ___loadDataTask_7)); }
	inline VP_1_t3102662641 * get_loadDataTask_7() const { return ___loadDataTask_7; }
	inline VP_1_t3102662641 ** get_address_of_loadDataTask_7() { return &___loadDataTask_7; }
	inline void set_loadDataTask_7(VP_1_t3102662641 * value)
	{
		___loadDataTask_7 = value;
		Il2CppCodeGenWriteBarrier(&___loadDataTask_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
