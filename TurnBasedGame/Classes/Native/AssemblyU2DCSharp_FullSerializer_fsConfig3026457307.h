#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_FullSerializer_fsMemberSerializat691367231.h"

// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.Func`3<System.String,System.Reflection.MemberInfo,System.String>
struct Func_3_t3811442442;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsConfig
struct  fsConfig_t3026457307  : public Il2CppObject
{
public:
	// System.Type[] FullSerializer.fsConfig::SerializeAttributes
	TypeU5BU5D_t1664964607* ___SerializeAttributes_0;
	// System.Type[] FullSerializer.fsConfig::IgnoreSerializeAttributes
	TypeU5BU5D_t1664964607* ___IgnoreSerializeAttributes_1;
	// System.Type[] FullSerializer.fsConfig::IgnoreSerializeTypeAttributes
	TypeU5BU5D_t1664964607* ___IgnoreSerializeTypeAttributes_2;
	// FullSerializer.fsMemberSerialization FullSerializer.fsConfig::DefaultMemberSerialization
	int32_t ___DefaultMemberSerialization_3;
	// System.Func`3<System.String,System.Reflection.MemberInfo,System.String> FullSerializer.fsConfig::GetJsonNameFromMemberName
	Func_3_t3811442442 * ___GetJsonNameFromMemberName_4;
	// System.Boolean FullSerializer.fsConfig::EnablePropertySerialization
	bool ___EnablePropertySerialization_5;
	// System.Boolean FullSerializer.fsConfig::SerializeNonAutoProperties
	bool ___SerializeNonAutoProperties_6;
	// System.Boolean FullSerializer.fsConfig::SerializeNonPublicSetProperties
	bool ___SerializeNonPublicSetProperties_7;
	// System.String FullSerializer.fsConfig::CustomDateTimeFormatString
	String_t* ___CustomDateTimeFormatString_8;
	// System.Boolean FullSerializer.fsConfig::Serialize64BitIntegerAsString
	bool ___Serialize64BitIntegerAsString_9;
	// System.Boolean FullSerializer.fsConfig::SerializeEnumsAsInteger
	bool ___SerializeEnumsAsInteger_10;

public:
	inline static int32_t get_offset_of_SerializeAttributes_0() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___SerializeAttributes_0)); }
	inline TypeU5BU5D_t1664964607* get_SerializeAttributes_0() const { return ___SerializeAttributes_0; }
	inline TypeU5BU5D_t1664964607** get_address_of_SerializeAttributes_0() { return &___SerializeAttributes_0; }
	inline void set_SerializeAttributes_0(TypeU5BU5D_t1664964607* value)
	{
		___SerializeAttributes_0 = value;
		Il2CppCodeGenWriteBarrier(&___SerializeAttributes_0, value);
	}

	inline static int32_t get_offset_of_IgnoreSerializeAttributes_1() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___IgnoreSerializeAttributes_1)); }
	inline TypeU5BU5D_t1664964607* get_IgnoreSerializeAttributes_1() const { return ___IgnoreSerializeAttributes_1; }
	inline TypeU5BU5D_t1664964607** get_address_of_IgnoreSerializeAttributes_1() { return &___IgnoreSerializeAttributes_1; }
	inline void set_IgnoreSerializeAttributes_1(TypeU5BU5D_t1664964607* value)
	{
		___IgnoreSerializeAttributes_1 = value;
		Il2CppCodeGenWriteBarrier(&___IgnoreSerializeAttributes_1, value);
	}

	inline static int32_t get_offset_of_IgnoreSerializeTypeAttributes_2() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___IgnoreSerializeTypeAttributes_2)); }
	inline TypeU5BU5D_t1664964607* get_IgnoreSerializeTypeAttributes_2() const { return ___IgnoreSerializeTypeAttributes_2; }
	inline TypeU5BU5D_t1664964607** get_address_of_IgnoreSerializeTypeAttributes_2() { return &___IgnoreSerializeTypeAttributes_2; }
	inline void set_IgnoreSerializeTypeAttributes_2(TypeU5BU5D_t1664964607* value)
	{
		___IgnoreSerializeTypeAttributes_2 = value;
		Il2CppCodeGenWriteBarrier(&___IgnoreSerializeTypeAttributes_2, value);
	}

	inline static int32_t get_offset_of_DefaultMemberSerialization_3() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___DefaultMemberSerialization_3)); }
	inline int32_t get_DefaultMemberSerialization_3() const { return ___DefaultMemberSerialization_3; }
	inline int32_t* get_address_of_DefaultMemberSerialization_3() { return &___DefaultMemberSerialization_3; }
	inline void set_DefaultMemberSerialization_3(int32_t value)
	{
		___DefaultMemberSerialization_3 = value;
	}

	inline static int32_t get_offset_of_GetJsonNameFromMemberName_4() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___GetJsonNameFromMemberName_4)); }
	inline Func_3_t3811442442 * get_GetJsonNameFromMemberName_4() const { return ___GetJsonNameFromMemberName_4; }
	inline Func_3_t3811442442 ** get_address_of_GetJsonNameFromMemberName_4() { return &___GetJsonNameFromMemberName_4; }
	inline void set_GetJsonNameFromMemberName_4(Func_3_t3811442442 * value)
	{
		___GetJsonNameFromMemberName_4 = value;
		Il2CppCodeGenWriteBarrier(&___GetJsonNameFromMemberName_4, value);
	}

	inline static int32_t get_offset_of_EnablePropertySerialization_5() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___EnablePropertySerialization_5)); }
	inline bool get_EnablePropertySerialization_5() const { return ___EnablePropertySerialization_5; }
	inline bool* get_address_of_EnablePropertySerialization_5() { return &___EnablePropertySerialization_5; }
	inline void set_EnablePropertySerialization_5(bool value)
	{
		___EnablePropertySerialization_5 = value;
	}

	inline static int32_t get_offset_of_SerializeNonAutoProperties_6() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___SerializeNonAutoProperties_6)); }
	inline bool get_SerializeNonAutoProperties_6() const { return ___SerializeNonAutoProperties_6; }
	inline bool* get_address_of_SerializeNonAutoProperties_6() { return &___SerializeNonAutoProperties_6; }
	inline void set_SerializeNonAutoProperties_6(bool value)
	{
		___SerializeNonAutoProperties_6 = value;
	}

	inline static int32_t get_offset_of_SerializeNonPublicSetProperties_7() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___SerializeNonPublicSetProperties_7)); }
	inline bool get_SerializeNonPublicSetProperties_7() const { return ___SerializeNonPublicSetProperties_7; }
	inline bool* get_address_of_SerializeNonPublicSetProperties_7() { return &___SerializeNonPublicSetProperties_7; }
	inline void set_SerializeNonPublicSetProperties_7(bool value)
	{
		___SerializeNonPublicSetProperties_7 = value;
	}

	inline static int32_t get_offset_of_CustomDateTimeFormatString_8() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___CustomDateTimeFormatString_8)); }
	inline String_t* get_CustomDateTimeFormatString_8() const { return ___CustomDateTimeFormatString_8; }
	inline String_t** get_address_of_CustomDateTimeFormatString_8() { return &___CustomDateTimeFormatString_8; }
	inline void set_CustomDateTimeFormatString_8(String_t* value)
	{
		___CustomDateTimeFormatString_8 = value;
		Il2CppCodeGenWriteBarrier(&___CustomDateTimeFormatString_8, value);
	}

	inline static int32_t get_offset_of_Serialize64BitIntegerAsString_9() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___Serialize64BitIntegerAsString_9)); }
	inline bool get_Serialize64BitIntegerAsString_9() const { return ___Serialize64BitIntegerAsString_9; }
	inline bool* get_address_of_Serialize64BitIntegerAsString_9() { return &___Serialize64BitIntegerAsString_9; }
	inline void set_Serialize64BitIntegerAsString_9(bool value)
	{
		___Serialize64BitIntegerAsString_9 = value;
	}

	inline static int32_t get_offset_of_SerializeEnumsAsInteger_10() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307, ___SerializeEnumsAsInteger_10)); }
	inline bool get_SerializeEnumsAsInteger_10() const { return ___SerializeEnumsAsInteger_10; }
	inline bool* get_address_of_SerializeEnumsAsInteger_10() { return &___SerializeEnumsAsInteger_10; }
	inline void set_SerializeEnumsAsInteger_10(bool value)
	{
		___SerializeEnumsAsInteger_10 = value;
	}
};

struct fsConfig_t3026457307_StaticFields
{
public:
	// System.Func`3<System.String,System.Reflection.MemberInfo,System.String> FullSerializer.fsConfig::<>f__am$cache0
	Func_3_t3811442442 * ___U3CU3Ef__amU24cache0_11;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_11() { return static_cast<int32_t>(offsetof(fsConfig_t3026457307_StaticFields, ___U3CU3Ef__amU24cache0_11)); }
	inline Func_3_t3811442442 * get_U3CU3Ef__amU24cache0_11() const { return ___U3CU3Ef__amU24cache0_11; }
	inline Func_3_t3811442442 ** get_address_of_U3CU3Ef__amU24cache0_11() { return &___U3CU3Ef__amU24cache0_11; }
	inline void set_U3CU3Ef__amU24cache0_11(Func_3_t3811442442 * value)
	{
		___U3CU3Ef__amU24cache0_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
