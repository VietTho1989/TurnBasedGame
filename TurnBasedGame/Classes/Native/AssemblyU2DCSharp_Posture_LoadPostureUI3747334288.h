#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1256411633.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// FileSystem.FileSystemBrowserUI
struct FileSystemBrowserUI_t3162117433;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.LoadPostureUI
struct  LoadPostureUI_t3747334288  : public UIBehavior_1_t1256411633
{
public:
	// UnityEngine.UI.Button Posture.LoadPostureUI::btnLoad
	Button_t2872111280 * ___btnLoad_6;
	// UnityEngine.UI.Text Posture.LoadPostureUI::tvLoad
	Text_t356221433 * ___tvLoad_7;
	// FileSystem.FileSystemBrowserUI Posture.LoadPostureUI::fileSystemBrowserPrefab
	FileSystemBrowserUI_t3162117433 * ___fileSystemBrowserPrefab_8;
	// UnityEngine.Transform Posture.LoadPostureUI::fileSystemBrowserContainer
	Transform_t3275118058 * ___fileSystemBrowserContainer_9;

public:
	inline static int32_t get_offset_of_btnLoad_6() { return static_cast<int32_t>(offsetof(LoadPostureUI_t3747334288, ___btnLoad_6)); }
	inline Button_t2872111280 * get_btnLoad_6() const { return ___btnLoad_6; }
	inline Button_t2872111280 ** get_address_of_btnLoad_6() { return &___btnLoad_6; }
	inline void set_btnLoad_6(Button_t2872111280 * value)
	{
		___btnLoad_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnLoad_6, value);
	}

	inline static int32_t get_offset_of_tvLoad_7() { return static_cast<int32_t>(offsetof(LoadPostureUI_t3747334288, ___tvLoad_7)); }
	inline Text_t356221433 * get_tvLoad_7() const { return ___tvLoad_7; }
	inline Text_t356221433 ** get_address_of_tvLoad_7() { return &___tvLoad_7; }
	inline void set_tvLoad_7(Text_t356221433 * value)
	{
		___tvLoad_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvLoad_7, value);
	}

	inline static int32_t get_offset_of_fileSystemBrowserPrefab_8() { return static_cast<int32_t>(offsetof(LoadPostureUI_t3747334288, ___fileSystemBrowserPrefab_8)); }
	inline FileSystemBrowserUI_t3162117433 * get_fileSystemBrowserPrefab_8() const { return ___fileSystemBrowserPrefab_8; }
	inline FileSystemBrowserUI_t3162117433 ** get_address_of_fileSystemBrowserPrefab_8() { return &___fileSystemBrowserPrefab_8; }
	inline void set_fileSystemBrowserPrefab_8(FileSystemBrowserUI_t3162117433 * value)
	{
		___fileSystemBrowserPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowserPrefab_8, value);
	}

	inline static int32_t get_offset_of_fileSystemBrowserContainer_9() { return static_cast<int32_t>(offsetof(LoadPostureUI_t3747334288, ___fileSystemBrowserContainer_9)); }
	inline Transform_t3275118058 * get_fileSystemBrowserContainer_9() const { return ___fileSystemBrowserContainer_9; }
	inline Transform_t3275118058 ** get_address_of_fileSystemBrowserContainer_9() { return &___fileSystemBrowserContainer_9; }
	inline void set_fileSystemBrowserContainer_9(Transform_t3275118058 * value)
	{
		___fileSystemBrowserContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowserContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
