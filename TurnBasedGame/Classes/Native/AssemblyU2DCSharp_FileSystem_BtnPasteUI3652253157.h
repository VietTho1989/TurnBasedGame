#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2313062263.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// FileSystem.FileSystemBrowser
struct FileSystemBrowser_t450309799;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnPasteUI
struct  BtnPasteUI_t3652253157  : public UIBehavior_1_t2313062263
{
public:
	// UnityEngine.UI.Button FileSystem.BtnPasteUI::btnPaste
	Button_t2872111280 * ___btnPaste_6;
	// UnityEngine.UI.Text FileSystem.BtnPasteUI::tvPaste
	Text_t356221433 * ___tvPaste_7;
	// FileSystem.FileSystemBrowser FileSystem.BtnPasteUI::fileSystemBrowser
	FileSystemBrowser_t450309799 * ___fileSystemBrowser_8;

public:
	inline static int32_t get_offset_of_btnPaste_6() { return static_cast<int32_t>(offsetof(BtnPasteUI_t3652253157, ___btnPaste_6)); }
	inline Button_t2872111280 * get_btnPaste_6() const { return ___btnPaste_6; }
	inline Button_t2872111280 ** get_address_of_btnPaste_6() { return &___btnPaste_6; }
	inline void set_btnPaste_6(Button_t2872111280 * value)
	{
		___btnPaste_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnPaste_6, value);
	}

	inline static int32_t get_offset_of_tvPaste_7() { return static_cast<int32_t>(offsetof(BtnPasteUI_t3652253157, ___tvPaste_7)); }
	inline Text_t356221433 * get_tvPaste_7() const { return ___tvPaste_7; }
	inline Text_t356221433 ** get_address_of_tvPaste_7() { return &___tvPaste_7; }
	inline void set_tvPaste_7(Text_t356221433 * value)
	{
		___tvPaste_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvPaste_7, value);
	}

	inline static int32_t get_offset_of_fileSystemBrowser_8() { return static_cast<int32_t>(offsetof(BtnPasteUI_t3652253157, ___fileSystemBrowser_8)); }
	inline FileSystemBrowser_t450309799 * get_fileSystemBrowser_8() const { return ___fileSystemBrowser_8; }
	inline FileSystemBrowser_t450309799 ** get_address_of_fileSystemBrowser_8() { return &___fileSystemBrowser_8; }
	inline void set_fileSystemBrowser_8(FileSystemBrowser_t450309799 * value)
	{
		___fileSystemBrowser_8 = value;
		Il2CppCodeGenWriteBarrier(&___fileSystemBrowser_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
