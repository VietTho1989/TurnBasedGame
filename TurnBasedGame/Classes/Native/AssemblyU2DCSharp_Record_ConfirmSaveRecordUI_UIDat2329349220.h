#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.IO.FileInfo>
struct VP_1_t3531780748;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.ConfirmSaveRecordUI/UIData
struct  UIData_t2329349220  : public Data_t3569509720
{
public:
	// VP`1<System.IO.FileInfo> Record.ConfirmSaveRecordUI/UIData::fileInfo
	VP_1_t3531780748 * ___fileInfo_5;

public:
	inline static int32_t get_offset_of_fileInfo_5() { return static_cast<int32_t>(offsetof(UIData_t2329349220, ___fileInfo_5)); }
	inline VP_1_t3531780748 * get_fileInfo_5() const { return ___fileInfo_5; }
	inline VP_1_t3531780748 ** get_address_of_fileInfo_5() { return &___fileInfo_5; }
	inline void set_fileInfo_5(VP_1_t3531780748 * value)
	{
		___fileInfo_5 = value;
		Il2CppCodeGenWriteBarrier(&___fileInfo_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
