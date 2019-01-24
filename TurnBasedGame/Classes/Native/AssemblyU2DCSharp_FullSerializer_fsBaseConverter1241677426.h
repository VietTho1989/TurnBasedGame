#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// FullSerializer.fsSerializer
struct fsSerializer_t4193731081;
// System.Func`2<FullSerializer.fsDataType,System.String>
struct Func_2_t1180654441;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsBaseConverter
struct  fsBaseConverter_t1241677426  : public Il2CppObject
{
public:
	// FullSerializer.fsSerializer FullSerializer.fsBaseConverter::Serializer
	fsSerializer_t4193731081 * ___Serializer_0;

public:
	inline static int32_t get_offset_of_Serializer_0() { return static_cast<int32_t>(offsetof(fsBaseConverter_t1241677426, ___Serializer_0)); }
	inline fsSerializer_t4193731081 * get_Serializer_0() const { return ___Serializer_0; }
	inline fsSerializer_t4193731081 ** get_address_of_Serializer_0() { return &___Serializer_0; }
	inline void set_Serializer_0(fsSerializer_t4193731081 * value)
	{
		___Serializer_0 = value;
		Il2CppCodeGenWriteBarrier(&___Serializer_0, value);
	}
};

struct fsBaseConverter_t1241677426_StaticFields
{
public:
	// System.Func`2<FullSerializer.fsDataType,System.String> FullSerializer.fsBaseConverter::<>f__am$cache0
	Func_2_t1180654441 * ___U3CU3Ef__amU24cache0_1;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_1() { return static_cast<int32_t>(offsetof(fsBaseConverter_t1241677426_StaticFields, ___U3CU3Ef__amU24cache0_1)); }
	inline Func_2_t1180654441 * get_U3CU3Ef__amU24cache0_1() const { return ___U3CU3Ef__amU24cache0_1; }
	inline Func_2_t1180654441 ** get_address_of_U3CU3Ef__amU24cache0_1() { return &___U3CU3Ef__amU24cache0_1; }
	inline void set_U3CU3Ef__amU24cache0_1(Func_2_t1180654441 * value)
	{
		___U3CU3Ef__amU24cache0_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
