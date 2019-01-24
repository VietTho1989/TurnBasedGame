#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// Data
struct Data_t3569509720;
// System.Collections.Generic.List`1<Record.Change>
struct List_1_t3763494476;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.DataRecord
struct  DataRecord_t228000813  : public Il2CppObject
{
public:
	// System.Int32 Record.DataRecord::version
	int32_t ___version_1;
	// Data Record.DataRecord::data
	Data_t3569509720 * ___data_2;
	// System.Int64 Record.DataRecord::startTime
	int64_t ___startTime_3;
	// System.Single Record.DataRecord::t
	float ___t_4;
	// System.Collections.Generic.List`1<Record.Change> Record.DataRecord::changes
	List_1_t3763494476 * ___changes_5;
	// System.Int32 Record.DataRecord::pos
	int32_t ___pos_6;

public:
	inline static int32_t get_offset_of_version_1() { return static_cast<int32_t>(offsetof(DataRecord_t228000813, ___version_1)); }
	inline int32_t get_version_1() const { return ___version_1; }
	inline int32_t* get_address_of_version_1() { return &___version_1; }
	inline void set_version_1(int32_t value)
	{
		___version_1 = value;
	}

	inline static int32_t get_offset_of_data_2() { return static_cast<int32_t>(offsetof(DataRecord_t228000813, ___data_2)); }
	inline Data_t3569509720 * get_data_2() const { return ___data_2; }
	inline Data_t3569509720 ** get_address_of_data_2() { return &___data_2; }
	inline void set_data_2(Data_t3569509720 * value)
	{
		___data_2 = value;
		Il2CppCodeGenWriteBarrier(&___data_2, value);
	}

	inline static int32_t get_offset_of_startTime_3() { return static_cast<int32_t>(offsetof(DataRecord_t228000813, ___startTime_3)); }
	inline int64_t get_startTime_3() const { return ___startTime_3; }
	inline int64_t* get_address_of_startTime_3() { return &___startTime_3; }
	inline void set_startTime_3(int64_t value)
	{
		___startTime_3 = value;
	}

	inline static int32_t get_offset_of_t_4() { return static_cast<int32_t>(offsetof(DataRecord_t228000813, ___t_4)); }
	inline float get_t_4() const { return ___t_4; }
	inline float* get_address_of_t_4() { return &___t_4; }
	inline void set_t_4(float value)
	{
		___t_4 = value;
	}

	inline static int32_t get_offset_of_changes_5() { return static_cast<int32_t>(offsetof(DataRecord_t228000813, ___changes_5)); }
	inline List_1_t3763494476 * get_changes_5() const { return ___changes_5; }
	inline List_1_t3763494476 ** get_address_of_changes_5() { return &___changes_5; }
	inline void set_changes_5(List_1_t3763494476 * value)
	{
		___changes_5 = value;
		Il2CppCodeGenWriteBarrier(&___changes_5, value);
	}

	inline static int32_t get_offset_of_pos_6() { return static_cast<int32_t>(offsetof(DataRecord_t228000813, ___pos_6)); }
	inline int32_t get_pos_6() const { return ___pos_6; }
	inline int32_t* get_address_of_pos_6() { return &___pos_6; }
	inline void set_pos_6(int32_t value)
	{
		___pos_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
