#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Reflection.MemberInfo
struct MemberInfo_t;
// System.Type
struct Type_t;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsMetaProperty
struct  fsMetaProperty_t2249223145  : public Il2CppObject
{
public:
	// System.Reflection.MemberInfo FullSerializer.Internal.fsMetaProperty::_memberInfo
	MemberInfo_t * ____memberInfo_0;
	// System.Type FullSerializer.Internal.fsMetaProperty::<StorageType>k__BackingField
	Type_t * ___U3CStorageTypeU3Ek__BackingField_1;
	// System.Type FullSerializer.Internal.fsMetaProperty::<OverrideConverterType>k__BackingField
	Type_t * ___U3COverrideConverterTypeU3Ek__BackingField_2;
	// System.Boolean FullSerializer.Internal.fsMetaProperty::<CanRead>k__BackingField
	bool ___U3CCanReadU3Ek__BackingField_3;
	// System.Boolean FullSerializer.Internal.fsMetaProperty::<CanWrite>k__BackingField
	bool ___U3CCanWriteU3Ek__BackingField_4;
	// System.String FullSerializer.Internal.fsMetaProperty::<JsonName>k__BackingField
	String_t* ___U3CJsonNameU3Ek__BackingField_5;
	// System.String FullSerializer.Internal.fsMetaProperty::<MemberName>k__BackingField
	String_t* ___U3CMemberNameU3Ek__BackingField_6;
	// System.Boolean FullSerializer.Internal.fsMetaProperty::<IsPublic>k__BackingField
	bool ___U3CIsPublicU3Ek__BackingField_7;
	// System.Boolean FullSerializer.Internal.fsMetaProperty::<IsReadOnly>k__BackingField
	bool ___U3CIsReadOnlyU3Ek__BackingField_8;

public:
	inline static int32_t get_offset_of__memberInfo_0() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ____memberInfo_0)); }
	inline MemberInfo_t * get__memberInfo_0() const { return ____memberInfo_0; }
	inline MemberInfo_t ** get_address_of__memberInfo_0() { return &____memberInfo_0; }
	inline void set__memberInfo_0(MemberInfo_t * value)
	{
		____memberInfo_0 = value;
		Il2CppCodeGenWriteBarrier(&____memberInfo_0, value);
	}

	inline static int32_t get_offset_of_U3CStorageTypeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3CStorageTypeU3Ek__BackingField_1)); }
	inline Type_t * get_U3CStorageTypeU3Ek__BackingField_1() const { return ___U3CStorageTypeU3Ek__BackingField_1; }
	inline Type_t ** get_address_of_U3CStorageTypeU3Ek__BackingField_1() { return &___U3CStorageTypeU3Ek__BackingField_1; }
	inline void set_U3CStorageTypeU3Ek__BackingField_1(Type_t * value)
	{
		___U3CStorageTypeU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CStorageTypeU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3COverrideConverterTypeU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3COverrideConverterTypeU3Ek__BackingField_2)); }
	inline Type_t * get_U3COverrideConverterTypeU3Ek__BackingField_2() const { return ___U3COverrideConverterTypeU3Ek__BackingField_2; }
	inline Type_t ** get_address_of_U3COverrideConverterTypeU3Ek__BackingField_2() { return &___U3COverrideConverterTypeU3Ek__BackingField_2; }
	inline void set_U3COverrideConverterTypeU3Ek__BackingField_2(Type_t * value)
	{
		___U3COverrideConverterTypeU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3COverrideConverterTypeU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CCanReadU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3CCanReadU3Ek__BackingField_3)); }
	inline bool get_U3CCanReadU3Ek__BackingField_3() const { return ___U3CCanReadU3Ek__BackingField_3; }
	inline bool* get_address_of_U3CCanReadU3Ek__BackingField_3() { return &___U3CCanReadU3Ek__BackingField_3; }
	inline void set_U3CCanReadU3Ek__BackingField_3(bool value)
	{
		___U3CCanReadU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CCanWriteU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3CCanWriteU3Ek__BackingField_4)); }
	inline bool get_U3CCanWriteU3Ek__BackingField_4() const { return ___U3CCanWriteU3Ek__BackingField_4; }
	inline bool* get_address_of_U3CCanWriteU3Ek__BackingField_4() { return &___U3CCanWriteU3Ek__BackingField_4; }
	inline void set_U3CCanWriteU3Ek__BackingField_4(bool value)
	{
		___U3CCanWriteU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CJsonNameU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3CJsonNameU3Ek__BackingField_5)); }
	inline String_t* get_U3CJsonNameU3Ek__BackingField_5() const { return ___U3CJsonNameU3Ek__BackingField_5; }
	inline String_t** get_address_of_U3CJsonNameU3Ek__BackingField_5() { return &___U3CJsonNameU3Ek__BackingField_5; }
	inline void set_U3CJsonNameU3Ek__BackingField_5(String_t* value)
	{
		___U3CJsonNameU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CJsonNameU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CMemberNameU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3CMemberNameU3Ek__BackingField_6)); }
	inline String_t* get_U3CMemberNameU3Ek__BackingField_6() const { return ___U3CMemberNameU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CMemberNameU3Ek__BackingField_6() { return &___U3CMemberNameU3Ek__BackingField_6; }
	inline void set_U3CMemberNameU3Ek__BackingField_6(String_t* value)
	{
		___U3CMemberNameU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMemberNameU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CIsPublicU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3CIsPublicU3Ek__BackingField_7)); }
	inline bool get_U3CIsPublicU3Ek__BackingField_7() const { return ___U3CIsPublicU3Ek__BackingField_7; }
	inline bool* get_address_of_U3CIsPublicU3Ek__BackingField_7() { return &___U3CIsPublicU3Ek__BackingField_7; }
	inline void set_U3CIsPublicU3Ek__BackingField_7(bool value)
	{
		___U3CIsPublicU3Ek__BackingField_7 = value;
	}

	inline static int32_t get_offset_of_U3CIsReadOnlyU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(fsMetaProperty_t2249223145, ___U3CIsReadOnlyU3Ek__BackingField_8)); }
	inline bool get_U3CIsReadOnlyU3Ek__BackingField_8() const { return ___U3CIsReadOnlyU3Ek__BackingField_8; }
	inline bool* get_address_of_U3CIsReadOnlyU3Ek__BackingField_8() { return &___U3CIsReadOnlyU3Ek__BackingField_8; }
	inline void set_U3CIsReadOnlyU3Ek__BackingField_8(bool value)
	{
		___U3CIsReadOnlyU3Ek__BackingField_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
