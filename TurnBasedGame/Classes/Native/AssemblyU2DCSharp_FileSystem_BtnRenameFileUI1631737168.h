#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3588198170.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// FileSystem.RenameFileUI
struct RenameFileUI_t1579783440;
// FileSystem.FileSystemBrowser
struct FileSystemBrowser_t450309799;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnRenameFileUI
struct  BtnRenameFileUI_t1631737168  : public UIBehavior_1_t3588198170
{
public:
	// UnityEngine.UI.Button FileSystem.BtnRenameFileUI::btnRename
	Button_t2872111280 * ___btnRename_6;
	// UnityEngine.UI.Text FileSystem.BtnRenameFileUI::tvRename
	Text_t356221433 * ___tvRename_7;
	// FileSystem.RenameFileUI FileSystem.BtnRenameFileUI::renameFilePrefab
	RenameFileUI_t1579783440 * ___renameFilePrefab_8;
	// FileSystem.FileSystemBrowser FileSystem.BtnRenameFileUI::fileSystemBrowser
	FileSystemBrowser_t450309799 * ___fileSystemBrowser_9;

public:
	inline static int32_t get_offset_of_btnRename_6() { return static_cast<int32_t>(offsetof(BtnRenameFileUI_t1631737168, ___btnRename_6)); }
	inline Button_t2872111280 * get_btnRename_6() const { return ___btnRename_6; }
	inline Button_t2872111280 ** get_address_of_btnRename_6() { return &___btnRename_6; }
	inline void set_btnRename_6(Button_t2872111280 * value)
	{
		___btnRename_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnRename_6, value);
	}

	inline static int32_t get_offset_of_tvRename_7() { return static_cast<int32_t>(offsetof(BtnRenameFileUI_t1631737168, ___tvRename_7)); }
	inline Text_t356221433 * get_tvRename_7() const { return ___tvRename_7; }
	inline Text_t356221433 ** get_address_of_tvRename_7() { return &___tvRename_7; }
	inline void set_tvRename_7(Text_t356221433 * value)
	{
		___tvRename_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvRename_7, value);
	}

	inline static int32_t get_offset_of_renameFilePrefab_8() { return static_cast<int32_t>(offsetof(BtnRenameFileUI_t1631737168, ___renameFilePrefab_8)); }
	inline RenameFileUI_t1579783440 * get_renameFilePrefab_8() const { return ___renameFilePrefab_8; }
	inline RenameFileUI_t1579783440 ** get_address_of_renameFilePrefab_8() { return &___renameFilePrefab_8; }
	inline void set_renameFilePrefab_8(RenameFileUI_t1579783440 * value)
	{
		___renameFilePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___renameFilePrefab_8, value);
	}

	inline static int32_t get_offset_of_fileSystemBrowser_9() { return static_cast<int32_t>(offsetof(BtnRenameFileUI_t1631737168, ___fileSystemBrowser_9)); }
	inline FileSystemBrowser_t450309799 * get_fileSystemBrowser_9() const { return ___fileSystemBrowser_9; }
	inline FileSystemBrowser_t450309799 ** get_address_of_fileSystemBrowser_9() { return &___fileSystemBrowser_9; }
	inline void set_fileSystemBrowser_9(FileSystemBrowser_t450309799 * value)
	{
		___fileSystemBrowser_9 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowser_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
