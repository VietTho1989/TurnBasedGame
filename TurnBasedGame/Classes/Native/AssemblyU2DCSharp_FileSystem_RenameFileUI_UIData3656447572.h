#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.IO.FileSystemInfo>
struct VP_1_t2739268905;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.RenameFileUI/UIData
struct  UIData_t3656447572  : public Data_t3569509720
{
public:
	// VP`1<System.IO.FileSystemInfo> FileSystem.RenameFileUI/UIData::file
	VP_1_t2739268905 * ___file_5;
	// VP`1<RequestChangeStringUI/UIData> FileSystem.RenameFileUI/UIData::name
	VP_1_t1525575381 * ___name_6;

public:
	inline static int32_t get_offset_of_file_5() { return static_cast<int32_t>(offsetof(UIData_t3656447572, ___file_5)); }
	inline VP_1_t2739268905 * get_file_5() const { return ___file_5; }
	inline VP_1_t2739268905 ** get_address_of_file_5() { return &___file_5; }
	inline void set_file_5(VP_1_t2739268905 * value)
	{
		___file_5 = value;
		Il2CppCodeGenWriteBarrier(&___file_5, value);
	}

	inline static int32_t get_offset_of_name_6() { return static_cast<int32_t>(offsetof(UIData_t3656447572, ___name_6)); }
	inline VP_1_t1525575381 * get_name_6() const { return ___name_6; }
	inline VP_1_t1525575381 ** get_address_of_name_6() { return &___name_6; }
	inline void set_name_6(VP_1_t1525575381 * value)
	{
		___name_6 = value;
		Il2CppCodeGenWriteBarrier(&___name_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
