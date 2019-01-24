#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.HashSet`1<System.String>
struct HashSet_1_t362681087;
// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsBaseConverter>
struct Dictionary_2_t3179035323;
// System.Collections.Generic.Dictionary`2<System.Type,System.Collections.Generic.List`1<FullSerializer.fsObjectProcessor>>
struct Dictionary_2_t3992733373;
// System.Collections.Generic.List`1<FullSerializer.fsConverter>
struct List_1_t4130846565;
// System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsDirectConverter>
struct Dictionary_2_t2700818715;
// System.Collections.Generic.List`1<FullSerializer.fsObjectProcessor>
struct List_1_t2055375476;
// FullSerializer.Internal.fsCyclicReferenceManager
struct fsCyclicReferenceManager_t1995018378;
// FullSerializer.fsSerializer/fsLazyCycleDefinitionWriter
struct fsLazyCycleDefinitionWriter_t2327014926;
// System.Collections.Generic.Dictionary`2<System.Type,System.Type>
struct Dictionary_2_t3241161123;
// FullSerializer.fsContext
struct fsContext_t2896355488;
// FullSerializer.fsConfig
struct fsConfig_t3026457307;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsSerializer
struct  fsSerializer_t4193731081  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsBaseConverter> FullSerializer.fsSerializer::_cachedConverterTypeInstances
	Dictionary_2_t3179035323 * ____cachedConverterTypeInstances_6;
	// System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsBaseConverter> FullSerializer.fsSerializer::_cachedConverters
	Dictionary_2_t3179035323 * ____cachedConverters_7;
	// System.Collections.Generic.Dictionary`2<System.Type,System.Collections.Generic.List`1<FullSerializer.fsObjectProcessor>> FullSerializer.fsSerializer::_cachedProcessors
	Dictionary_2_t3992733373 * ____cachedProcessors_8;
	// System.Collections.Generic.List`1<FullSerializer.fsConverter> FullSerializer.fsSerializer::_availableConverters
	List_1_t4130846565 * ____availableConverters_9;
	// System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsDirectConverter> FullSerializer.fsSerializer::_availableDirectConverters
	Dictionary_2_t2700818715 * ____availableDirectConverters_10;
	// System.Collections.Generic.List`1<FullSerializer.fsObjectProcessor> FullSerializer.fsSerializer::_processors
	List_1_t2055375476 * ____processors_11;
	// FullSerializer.Internal.fsCyclicReferenceManager FullSerializer.fsSerializer::_references
	fsCyclicReferenceManager_t1995018378 * ____references_12;
	// FullSerializer.fsSerializer/fsLazyCycleDefinitionWriter FullSerializer.fsSerializer::_lazyReferenceWriter
	fsLazyCycleDefinitionWriter_t2327014926 * ____lazyReferenceWriter_13;
	// System.Collections.Generic.Dictionary`2<System.Type,System.Type> FullSerializer.fsSerializer::_abstractTypeRemap
	Dictionary_2_t3241161123 * ____abstractTypeRemap_14;
	// FullSerializer.fsContext FullSerializer.fsSerializer::Context
	fsContext_t2896355488 * ___Context_15;
	// FullSerializer.fsConfig FullSerializer.fsSerializer::Config
	fsConfig_t3026457307 * ___Config_16;

public:
	inline static int32_t get_offset_of__cachedConverterTypeInstances_6() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____cachedConverterTypeInstances_6)); }
	inline Dictionary_2_t3179035323 * get__cachedConverterTypeInstances_6() const { return ____cachedConverterTypeInstances_6; }
	inline Dictionary_2_t3179035323 ** get_address_of__cachedConverterTypeInstances_6() { return &____cachedConverterTypeInstances_6; }
	inline void set__cachedConverterTypeInstances_6(Dictionary_2_t3179035323 * value)
	{
		____cachedConverterTypeInstances_6 = value;
		Il2CppCodeGenWriteBarrier(&____cachedConverterTypeInstances_6, value);
	}

	inline static int32_t get_offset_of__cachedConverters_7() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____cachedConverters_7)); }
	inline Dictionary_2_t3179035323 * get__cachedConverters_7() const { return ____cachedConverters_7; }
	inline Dictionary_2_t3179035323 ** get_address_of__cachedConverters_7() { return &____cachedConverters_7; }
	inline void set__cachedConverters_7(Dictionary_2_t3179035323 * value)
	{
		____cachedConverters_7 = value;
		Il2CppCodeGenWriteBarrier(&____cachedConverters_7, value);
	}

	inline static int32_t get_offset_of__cachedProcessors_8() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____cachedProcessors_8)); }
	inline Dictionary_2_t3992733373 * get__cachedProcessors_8() const { return ____cachedProcessors_8; }
	inline Dictionary_2_t3992733373 ** get_address_of__cachedProcessors_8() { return &____cachedProcessors_8; }
	inline void set__cachedProcessors_8(Dictionary_2_t3992733373 * value)
	{
		____cachedProcessors_8 = value;
		Il2CppCodeGenWriteBarrier(&____cachedProcessors_8, value);
	}

	inline static int32_t get_offset_of__availableConverters_9() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____availableConverters_9)); }
	inline List_1_t4130846565 * get__availableConverters_9() const { return ____availableConverters_9; }
	inline List_1_t4130846565 ** get_address_of__availableConverters_9() { return &____availableConverters_9; }
	inline void set__availableConverters_9(List_1_t4130846565 * value)
	{
		____availableConverters_9 = value;
		Il2CppCodeGenWriteBarrier(&____availableConverters_9, value);
	}

	inline static int32_t get_offset_of__availableDirectConverters_10() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____availableDirectConverters_10)); }
	inline Dictionary_2_t2700818715 * get__availableDirectConverters_10() const { return ____availableDirectConverters_10; }
	inline Dictionary_2_t2700818715 ** get_address_of__availableDirectConverters_10() { return &____availableDirectConverters_10; }
	inline void set__availableDirectConverters_10(Dictionary_2_t2700818715 * value)
	{
		____availableDirectConverters_10 = value;
		Il2CppCodeGenWriteBarrier(&____availableDirectConverters_10, value);
	}

	inline static int32_t get_offset_of__processors_11() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____processors_11)); }
	inline List_1_t2055375476 * get__processors_11() const { return ____processors_11; }
	inline List_1_t2055375476 ** get_address_of__processors_11() { return &____processors_11; }
	inline void set__processors_11(List_1_t2055375476 * value)
	{
		____processors_11 = value;
		Il2CppCodeGenWriteBarrier(&____processors_11, value);
	}

	inline static int32_t get_offset_of__references_12() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____references_12)); }
	inline fsCyclicReferenceManager_t1995018378 * get__references_12() const { return ____references_12; }
	inline fsCyclicReferenceManager_t1995018378 ** get_address_of__references_12() { return &____references_12; }
	inline void set__references_12(fsCyclicReferenceManager_t1995018378 * value)
	{
		____references_12 = value;
		Il2CppCodeGenWriteBarrier(&____references_12, value);
	}

	inline static int32_t get_offset_of__lazyReferenceWriter_13() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____lazyReferenceWriter_13)); }
	inline fsLazyCycleDefinitionWriter_t2327014926 * get__lazyReferenceWriter_13() const { return ____lazyReferenceWriter_13; }
	inline fsLazyCycleDefinitionWriter_t2327014926 ** get_address_of__lazyReferenceWriter_13() { return &____lazyReferenceWriter_13; }
	inline void set__lazyReferenceWriter_13(fsLazyCycleDefinitionWriter_t2327014926 * value)
	{
		____lazyReferenceWriter_13 = value;
		Il2CppCodeGenWriteBarrier(&____lazyReferenceWriter_13, value);
	}

	inline static int32_t get_offset_of__abstractTypeRemap_14() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ____abstractTypeRemap_14)); }
	inline Dictionary_2_t3241161123 * get__abstractTypeRemap_14() const { return ____abstractTypeRemap_14; }
	inline Dictionary_2_t3241161123 ** get_address_of__abstractTypeRemap_14() { return &____abstractTypeRemap_14; }
	inline void set__abstractTypeRemap_14(Dictionary_2_t3241161123 * value)
	{
		____abstractTypeRemap_14 = value;
		Il2CppCodeGenWriteBarrier(&____abstractTypeRemap_14, value);
	}

	inline static int32_t get_offset_of_Context_15() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ___Context_15)); }
	inline fsContext_t2896355488 * get_Context_15() const { return ___Context_15; }
	inline fsContext_t2896355488 ** get_address_of_Context_15() { return &___Context_15; }
	inline void set_Context_15(fsContext_t2896355488 * value)
	{
		___Context_15 = value;
		Il2CppCodeGenWriteBarrier(&___Context_15, value);
	}

	inline static int32_t get_offset_of_Config_16() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081, ___Config_16)); }
	inline fsConfig_t3026457307 * get_Config_16() const { return ___Config_16; }
	inline fsConfig_t3026457307 ** get_address_of_Config_16() { return &___Config_16; }
	inline void set_Config_16(fsConfig_t3026457307 * value)
	{
		___Config_16 = value;
		Il2CppCodeGenWriteBarrier(&___Config_16, value);
	}
};

struct fsSerializer_t4193731081_StaticFields
{
public:
	// System.Collections.Generic.HashSet`1<System.String> FullSerializer.fsSerializer::_reservedKeywords
	HashSet_1_t362681087 * ____reservedKeywords_0;
	// System.String FullSerializer.fsSerializer::Key_ObjectReference
	String_t* ___Key_ObjectReference_1;
	// System.String FullSerializer.fsSerializer::Key_ObjectDefinition
	String_t* ___Key_ObjectDefinition_2;
	// System.String FullSerializer.fsSerializer::Key_InstanceType
	String_t* ___Key_InstanceType_3;
	// System.String FullSerializer.fsSerializer::Key_Version
	String_t* ___Key_Version_4;
	// System.String FullSerializer.fsSerializer::Key_Content
	String_t* ___Key_Content_5;

public:
	inline static int32_t get_offset_of__reservedKeywords_0() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081_StaticFields, ____reservedKeywords_0)); }
	inline HashSet_1_t362681087 * get__reservedKeywords_0() const { return ____reservedKeywords_0; }
	inline HashSet_1_t362681087 ** get_address_of__reservedKeywords_0() { return &____reservedKeywords_0; }
	inline void set__reservedKeywords_0(HashSet_1_t362681087 * value)
	{
		____reservedKeywords_0 = value;
		Il2CppCodeGenWriteBarrier(&____reservedKeywords_0, value);
	}

	inline static int32_t get_offset_of_Key_ObjectReference_1() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081_StaticFields, ___Key_ObjectReference_1)); }
	inline String_t* get_Key_ObjectReference_1() const { return ___Key_ObjectReference_1; }
	inline String_t** get_address_of_Key_ObjectReference_1() { return &___Key_ObjectReference_1; }
	inline void set_Key_ObjectReference_1(String_t* value)
	{
		___Key_ObjectReference_1 = value;
		Il2CppCodeGenWriteBarrier(&___Key_ObjectReference_1, value);
	}

	inline static int32_t get_offset_of_Key_ObjectDefinition_2() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081_StaticFields, ___Key_ObjectDefinition_2)); }
	inline String_t* get_Key_ObjectDefinition_2() const { return ___Key_ObjectDefinition_2; }
	inline String_t** get_address_of_Key_ObjectDefinition_2() { return &___Key_ObjectDefinition_2; }
	inline void set_Key_ObjectDefinition_2(String_t* value)
	{
		___Key_ObjectDefinition_2 = value;
		Il2CppCodeGenWriteBarrier(&___Key_ObjectDefinition_2, value);
	}

	inline static int32_t get_offset_of_Key_InstanceType_3() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081_StaticFields, ___Key_InstanceType_3)); }
	inline String_t* get_Key_InstanceType_3() const { return ___Key_InstanceType_3; }
	inline String_t** get_address_of_Key_InstanceType_3() { return &___Key_InstanceType_3; }
	inline void set_Key_InstanceType_3(String_t* value)
	{
		___Key_InstanceType_3 = value;
		Il2CppCodeGenWriteBarrier(&___Key_InstanceType_3, value);
	}

	inline static int32_t get_offset_of_Key_Version_4() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081_StaticFields, ___Key_Version_4)); }
	inline String_t* get_Key_Version_4() const { return ___Key_Version_4; }
	inline String_t** get_address_of_Key_Version_4() { return &___Key_Version_4; }
	inline void set_Key_Version_4(String_t* value)
	{
		___Key_Version_4 = value;
		Il2CppCodeGenWriteBarrier(&___Key_Version_4, value);
	}

	inline static int32_t get_offset_of_Key_Content_5() { return static_cast<int32_t>(offsetof(fsSerializer_t4193731081_StaticFields, ___Key_Content_5)); }
	inline String_t* get_Key_Content_5() const { return ___Key_Content_5; }
	inline String_t** get_address_of_Key_Content_5() { return &___Key_Content_5; }
	inline void set_Key_Content_5(String_t* value)
	{
		___Key_Content_5 = value;
		Il2CppCodeGenWriteBarrier(&___Key_Content_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
