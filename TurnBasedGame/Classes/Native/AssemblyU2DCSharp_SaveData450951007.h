#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Save_Content2583047541.h"

// Data
struct Data_t3569509720;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SaveData
struct  SaveData_t450951007  : public Content_t2583047541
{
public:
	// Data SaveData::data
	Data_t3569509720 * ___data_0;

public:
	inline static int32_t get_offset_of_data_0() { return static_cast<int32_t>(offsetof(SaveData_t450951007, ___data_0)); }
	inline Data_t3569509720 * get_data_0() const { return ___data_0; }
	inline Data_t3569509720 ** get_address_of_data_0() { return &___data_0; }
	inline void set_data_0(Data_t3569509720 * value)
	{
		___data_0 = value;
		Il2CppCodeGenWriteBarrier(&___data_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
