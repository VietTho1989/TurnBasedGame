#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.ServerTests/DemoObject
struct  DemoObject_t3602767900  : public Il2CppObject
{
public:
	// System.String Foundation.Example.ServerTests/DemoObject::<Id>k__BackingField
	String_t* ___U3CIdU3Ek__BackingField_0;
	// System.String Foundation.Example.ServerTests/DemoObject::<String>k__BackingField
	String_t* ___U3CStringU3Ek__BackingField_1;
	// System.Int32 Foundation.Example.ServerTests/DemoObject::<Number>k__BackingField
	int32_t ___U3CNumberU3Ek__BackingField_2;
	// UnityEngine.Color Foundation.Example.ServerTests/DemoObject::<Color>k__BackingField
	Color_t2020392075  ___U3CColorU3Ek__BackingField_3;
	// UnityEngine.Vector3 Foundation.Example.ServerTests/DemoObject::<Vector>k__BackingField
	Vector3_t2243707580  ___U3CVectorU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_U3CIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(DemoObject_t3602767900, ___U3CIdU3Ek__BackingField_0)); }
	inline String_t* get_U3CIdU3Ek__BackingField_0() const { return ___U3CIdU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CIdU3Ek__BackingField_0() { return &___U3CIdU3Ek__BackingField_0; }
	inline void set_U3CIdU3Ek__BackingField_0(String_t* value)
	{
		___U3CIdU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CIdU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CStringU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(DemoObject_t3602767900, ___U3CStringU3Ek__BackingField_1)); }
	inline String_t* get_U3CStringU3Ek__BackingField_1() const { return ___U3CStringU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CStringU3Ek__BackingField_1() { return &___U3CStringU3Ek__BackingField_1; }
	inline void set_U3CStringU3Ek__BackingField_1(String_t* value)
	{
		___U3CStringU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CStringU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CNumberU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(DemoObject_t3602767900, ___U3CNumberU3Ek__BackingField_2)); }
	inline int32_t get_U3CNumberU3Ek__BackingField_2() const { return ___U3CNumberU3Ek__BackingField_2; }
	inline int32_t* get_address_of_U3CNumberU3Ek__BackingField_2() { return &___U3CNumberU3Ek__BackingField_2; }
	inline void set_U3CNumberU3Ek__BackingField_2(int32_t value)
	{
		___U3CNumberU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CColorU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(DemoObject_t3602767900, ___U3CColorU3Ek__BackingField_3)); }
	inline Color_t2020392075  get_U3CColorU3Ek__BackingField_3() const { return ___U3CColorU3Ek__BackingField_3; }
	inline Color_t2020392075 * get_address_of_U3CColorU3Ek__BackingField_3() { return &___U3CColorU3Ek__BackingField_3; }
	inline void set_U3CColorU3Ek__BackingField_3(Color_t2020392075  value)
	{
		___U3CColorU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CVectorU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(DemoObject_t3602767900, ___U3CVectorU3Ek__BackingField_4)); }
	inline Vector3_t2243707580  get_U3CVectorU3Ek__BackingField_4() const { return ___U3CVectorU3Ek__BackingField_4; }
	inline Vector3_t2243707580 * get_address_of_U3CVectorU3Ek__BackingField_4() { return &___U3CVectorU3Ek__BackingField_4; }
	inline void set_U3CVectorU3Ek__BackingField_4(Vector3_t2243707580  value)
	{
		___U3CVectorU3Ek__BackingField_4 = value;
	}
};

struct DemoObject_t3602767900_StaticFields
{
public:
	// System.Int32 Foundation.Example.ServerTests/DemoObject::Counter
	int32_t ___Counter_5;

public:
	inline static int32_t get_offset_of_Counter_5() { return static_cast<int32_t>(offsetof(DemoObject_t3602767900_StaticFields, ___Counter_5)); }
	inline int32_t get_Counter_5() const { return ___Counter_5; }
	inline int32_t* get_address_of_Counter_5() { return &___Counter_5; }
	inline void set_Counter_5(int32_t value)
	{
		___Counter_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
