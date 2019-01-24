#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.Group
struct  Group_t2517461663  : public Data_t3569509720
{
public:
	// LP`1<System.Int32> Weiqi.Group::lib
	LP_1_t809621404 * ___lib_8;
	// VP`1<System.Int32> Weiqi.Group::libs
	VP_1_t2450154454 * ___libs_9;

public:
	inline static int32_t get_offset_of_lib_8() { return static_cast<int32_t>(offsetof(Group_t2517461663, ___lib_8)); }
	inline LP_1_t809621404 * get_lib_8() const { return ___lib_8; }
	inline LP_1_t809621404 ** get_address_of_lib_8() { return &___lib_8; }
	inline void set_lib_8(LP_1_t809621404 * value)
	{
		___lib_8 = value;
		Il2CppCodeGenWriteBarrier(&___lib_8, value);
	}

	inline static int32_t get_offset_of_libs_9() { return static_cast<int32_t>(offsetof(Group_t2517461663, ___libs_9)); }
	inline VP_1_t2450154454 * get_libs_9() const { return ___libs_9; }
	inline VP_1_t2450154454 ** get_address_of_libs_9() { return &___libs_9; }
	inline void set_libs_9(VP_1_t2450154454 * value)
	{
		___libs_9 = value;
		Il2CppCodeGenWriteBarrier(&___libs_9, value);
	}
};

struct Group_t2517461663_StaticFields
{
public:
	// System.Boolean Weiqi.Group::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(Group_t2517461663_StaticFields, ___log_5)); }
	inline bool get_log_5() const { return ___log_5; }
	inline bool* get_address_of_log_5() { return &___log_5; }
	inline void set_log_5(bool value)
	{
		___log_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
