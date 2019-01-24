#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen508956134.h"

// FileSystem.ShowDirectory
struct ShowDirectory_t11173868;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.DirectoryHistoryUpdate
struct  DirectoryHistoryUpdate_t2027735908  : public UpdateBehavior_1_t508956134
{
public:
	// FileSystem.ShowDirectory FileSystem.DirectoryHistoryUpdate::showDirectory
	ShowDirectory_t11173868 * ___showDirectory_4;

public:
	inline static int32_t get_offset_of_showDirectory_4() { return static_cast<int32_t>(offsetof(DirectoryHistoryUpdate_t2027735908, ___showDirectory_4)); }
	inline ShowDirectory_t11173868 * get_showDirectory_4() const { return ___showDirectory_4; }
	inline ShowDirectory_t11173868 ** get_address_of_showDirectory_4() { return &___showDirectory_4; }
	inline void set_showDirectory_4(ShowDirectory_t11173868 * value)
	{
		___showDirectory_4 = value;
		Il2CppCodeGenWriteBarrier(&___showDirectory_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
