#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Type,Foundation.Server.StorageMetadata>
struct Dictionary_2_t1632926415;
// System.Type
struct Type_t;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.StorageMetadata
struct  StorageMetadata_t3990535814  : public Il2CppObject
{
public:
	// System.Type Foundation.Server.StorageMetadata::ObjectType
	Type_t * ___ObjectType_1;
	// System.String Foundation.Server.StorageMetadata::TableName
	String_t* ___TableName_2;
	// System.String Foundation.Server.StorageMetadata::IdPropertyName
	String_t* ___IdPropertyName_3;
	// System.String Foundation.Server.StorageMetadata::ModifiedPropertyName
	String_t* ___ModifiedPropertyName_4;
	// System.String Foundation.Server.StorageMetadata::ScorePropertyName
	String_t* ___ScorePropertyName_5;

public:
	inline static int32_t get_offset_of_ObjectType_1() { return static_cast<int32_t>(offsetof(StorageMetadata_t3990535814, ___ObjectType_1)); }
	inline Type_t * get_ObjectType_1() const { return ___ObjectType_1; }
	inline Type_t ** get_address_of_ObjectType_1() { return &___ObjectType_1; }
	inline void set_ObjectType_1(Type_t * value)
	{
		___ObjectType_1 = value;
		Il2CppCodeGenWriteBarrier(&___ObjectType_1, value);
	}

	inline static int32_t get_offset_of_TableName_2() { return static_cast<int32_t>(offsetof(StorageMetadata_t3990535814, ___TableName_2)); }
	inline String_t* get_TableName_2() const { return ___TableName_2; }
	inline String_t** get_address_of_TableName_2() { return &___TableName_2; }
	inline void set_TableName_2(String_t* value)
	{
		___TableName_2 = value;
		Il2CppCodeGenWriteBarrier(&___TableName_2, value);
	}

	inline static int32_t get_offset_of_IdPropertyName_3() { return static_cast<int32_t>(offsetof(StorageMetadata_t3990535814, ___IdPropertyName_3)); }
	inline String_t* get_IdPropertyName_3() const { return ___IdPropertyName_3; }
	inline String_t** get_address_of_IdPropertyName_3() { return &___IdPropertyName_3; }
	inline void set_IdPropertyName_3(String_t* value)
	{
		___IdPropertyName_3 = value;
		Il2CppCodeGenWriteBarrier(&___IdPropertyName_3, value);
	}

	inline static int32_t get_offset_of_ModifiedPropertyName_4() { return static_cast<int32_t>(offsetof(StorageMetadata_t3990535814, ___ModifiedPropertyName_4)); }
	inline String_t* get_ModifiedPropertyName_4() const { return ___ModifiedPropertyName_4; }
	inline String_t** get_address_of_ModifiedPropertyName_4() { return &___ModifiedPropertyName_4; }
	inline void set_ModifiedPropertyName_4(String_t* value)
	{
		___ModifiedPropertyName_4 = value;
		Il2CppCodeGenWriteBarrier(&___ModifiedPropertyName_4, value);
	}

	inline static int32_t get_offset_of_ScorePropertyName_5() { return static_cast<int32_t>(offsetof(StorageMetadata_t3990535814, ___ScorePropertyName_5)); }
	inline String_t* get_ScorePropertyName_5() const { return ___ScorePropertyName_5; }
	inline String_t** get_address_of_ScorePropertyName_5() { return &___ScorePropertyName_5; }
	inline void set_ScorePropertyName_5(String_t* value)
	{
		___ScorePropertyName_5 = value;
		Il2CppCodeGenWriteBarrier(&___ScorePropertyName_5, value);
	}
};

struct StorageMetadata_t3990535814_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.Type,Foundation.Server.StorageMetadata> Foundation.Server.StorageMetadata::KnowenReflections
	Dictionary_2_t1632926415 * ___KnowenReflections_0;

public:
	inline static int32_t get_offset_of_KnowenReflections_0() { return static_cast<int32_t>(offsetof(StorageMetadata_t3990535814_StaticFields, ___KnowenReflections_0)); }
	inline Dictionary_2_t1632926415 * get_KnowenReflections_0() const { return ___KnowenReflections_0; }
	inline Dictionary_2_t1632926415 ** get_address_of_KnowenReflections_0() { return &___KnowenReflections_0; }
	inline void set_KnowenReflections_0(Dictionary_2_t1632926415 * value)
	{
		___KnowenReflections_0 = value;
		Il2CppCodeGenWriteBarrier(&___KnowenReflections_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
