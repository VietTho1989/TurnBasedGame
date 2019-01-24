#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"
#include "AssemblyU2DCSharp_FullSerializer_fsMemberSerializat691367231.h"

// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.String
struct String_t;
// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsObjectAttribute
struct  fsObjectAttribute_t2382840370  : public Attribute_t542643598
{
public:
	// System.Type[] FullSerializer.fsObjectAttribute::PreviousModels
	TypeU5BU5D_t1664964607* ___PreviousModels_0;
	// System.String FullSerializer.fsObjectAttribute::VersionString
	String_t* ___VersionString_1;
	// FullSerializer.fsMemberSerialization FullSerializer.fsObjectAttribute::MemberSerialization
	int32_t ___MemberSerialization_2;
	// System.Type FullSerializer.fsObjectAttribute::Converter
	Type_t * ___Converter_3;
	// System.Type FullSerializer.fsObjectAttribute::Processor
	Type_t * ___Processor_4;

public:
	inline static int32_t get_offset_of_PreviousModels_0() { return static_cast<int32_t>(offsetof(fsObjectAttribute_t2382840370, ___PreviousModels_0)); }
	inline TypeU5BU5D_t1664964607* get_PreviousModels_0() const { return ___PreviousModels_0; }
	inline TypeU5BU5D_t1664964607** get_address_of_PreviousModels_0() { return &___PreviousModels_0; }
	inline void set_PreviousModels_0(TypeU5BU5D_t1664964607* value)
	{
		___PreviousModels_0 = value;
		Il2CppCodeGenWriteBarrier(&___PreviousModels_0, value);
	}

	inline static int32_t get_offset_of_VersionString_1() { return static_cast<int32_t>(offsetof(fsObjectAttribute_t2382840370, ___VersionString_1)); }
	inline String_t* get_VersionString_1() const { return ___VersionString_1; }
	inline String_t** get_address_of_VersionString_1() { return &___VersionString_1; }
	inline void set_VersionString_1(String_t* value)
	{
		___VersionString_1 = value;
		Il2CppCodeGenWriteBarrier(&___VersionString_1, value);
	}

	inline static int32_t get_offset_of_MemberSerialization_2() { return static_cast<int32_t>(offsetof(fsObjectAttribute_t2382840370, ___MemberSerialization_2)); }
	inline int32_t get_MemberSerialization_2() const { return ___MemberSerialization_2; }
	inline int32_t* get_address_of_MemberSerialization_2() { return &___MemberSerialization_2; }
	inline void set_MemberSerialization_2(int32_t value)
	{
		___MemberSerialization_2 = value;
	}

	inline static int32_t get_offset_of_Converter_3() { return static_cast<int32_t>(offsetof(fsObjectAttribute_t2382840370, ___Converter_3)); }
	inline Type_t * get_Converter_3() const { return ___Converter_3; }
	inline Type_t ** get_address_of_Converter_3() { return &___Converter_3; }
	inline void set_Converter_3(Type_t * value)
	{
		___Converter_3 = value;
		Il2CppCodeGenWriteBarrier(&___Converter_3, value);
	}

	inline static int32_t get_offset_of_Processor_4() { return static_cast<int32_t>(offsetof(fsObjectAttribute_t2382840370, ___Processor_4)); }
	inline Type_t * get_Processor_4() const { return ___Processor_4; }
	inline Type_t ** get_address_of_Processor_4() { return &___Processor_4; }
	inline void set_Processor_4(Type_t * value)
	{
		___Processor_4 = value;
		Il2CppCodeGenWriteBarrier(&___Processor_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
