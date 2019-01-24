#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// FullSerializer.Internal.fsVersionedType[]
struct fsVersionedTypeU5BU5D_t1849274963;
// System.String
struct String_t;
// System.Type
struct Type_t;
struct fsVersionedType_t654750358_marshaled_pinvoke;
struct fsVersionedType_t654750358_marshaled_com;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsVersionedType
struct  fsVersionedType_t654750358 
{
public:
	// FullSerializer.Internal.fsVersionedType[] FullSerializer.Internal.fsVersionedType::Ancestors
	fsVersionedTypeU5BU5D_t1849274963* ___Ancestors_0;
	// System.String FullSerializer.Internal.fsVersionedType::VersionString
	String_t* ___VersionString_1;
	// System.Type FullSerializer.Internal.fsVersionedType::ModelType
	Type_t * ___ModelType_2;

public:
	inline static int32_t get_offset_of_Ancestors_0() { return static_cast<int32_t>(offsetof(fsVersionedType_t654750358, ___Ancestors_0)); }
	inline fsVersionedTypeU5BU5D_t1849274963* get_Ancestors_0() const { return ___Ancestors_0; }
	inline fsVersionedTypeU5BU5D_t1849274963** get_address_of_Ancestors_0() { return &___Ancestors_0; }
	inline void set_Ancestors_0(fsVersionedTypeU5BU5D_t1849274963* value)
	{
		___Ancestors_0 = value;
		Il2CppCodeGenWriteBarrier(&___Ancestors_0, value);
	}

	inline static int32_t get_offset_of_VersionString_1() { return static_cast<int32_t>(offsetof(fsVersionedType_t654750358, ___VersionString_1)); }
	inline String_t* get_VersionString_1() const { return ___VersionString_1; }
	inline String_t** get_address_of_VersionString_1() { return &___VersionString_1; }
	inline void set_VersionString_1(String_t* value)
	{
		___VersionString_1 = value;
		Il2CppCodeGenWriteBarrier(&___VersionString_1, value);
	}

	inline static int32_t get_offset_of_ModelType_2() { return static_cast<int32_t>(offsetof(fsVersionedType_t654750358, ___ModelType_2)); }
	inline Type_t * get_ModelType_2() const { return ___ModelType_2; }
	inline Type_t ** get_address_of_ModelType_2() { return &___ModelType_2; }
	inline void set_ModelType_2(Type_t * value)
	{
		___ModelType_2 = value;
		Il2CppCodeGenWriteBarrier(&___ModelType_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of FullSerializer.Internal.fsVersionedType
struct fsVersionedType_t654750358_marshaled_pinvoke
{
	fsVersionedType_t654750358_marshaled_pinvoke* ___Ancestors_0;
	char* ___VersionString_1;
	Type_t * ___ModelType_2;
};
// Native definition for COM marshalling of FullSerializer.Internal.fsVersionedType
struct fsVersionedType_t654750358_marshaled_com
{
	fsVersionedType_t654750358_marshaled_com* ___Ancestors_0;
	Il2CppChar* ___VersionString_1;
	Type_t * ___ModelType_2;
};
