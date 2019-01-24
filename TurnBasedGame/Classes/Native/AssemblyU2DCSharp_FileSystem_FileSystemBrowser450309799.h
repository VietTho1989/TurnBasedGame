#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// System.String
struct String_t;
// VP`1<FileSystem.Action>
struct VP_1_t4114454842;
// VP`1<FileSystem.Show>
struct VP_1_t3955516479;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.FileSystemBrowser
struct  FileSystemBrowser_t450309799  : public Data_t3569509720
{
public:
	// VP`1<FileSystem.Action> FileSystem.FileSystemBrowser::action
	VP_1_t4114454842 * ___action_6;
	// VP`1<FileSystem.Show> FileSystem.FileSystemBrowser::show
	VP_1_t3955516479 * ___show_7;

public:
	inline static int32_t get_offset_of_action_6() { return static_cast<int32_t>(offsetof(FileSystemBrowser_t450309799, ___action_6)); }
	inline VP_1_t4114454842 * get_action_6() const { return ___action_6; }
	inline VP_1_t4114454842 ** get_address_of_action_6() { return &___action_6; }
	inline void set_action_6(VP_1_t4114454842 * value)
	{
		___action_6 = value;
		Il2CppCodeGenWriteBarrier(&___action_6, value);
	}

	inline static int32_t get_offset_of_show_7() { return static_cast<int32_t>(offsetof(FileSystemBrowser_t450309799, ___show_7)); }
	inline VP_1_t3955516479 * get_show_7() const { return ___show_7; }
	inline VP_1_t3955516479 ** get_address_of_show_7() { return &___show_7; }
	inline void set_show_7(VP_1_t3955516479 * value)
	{
		___show_7 = value;
		Il2CppCodeGenWriteBarrier(&___show_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
