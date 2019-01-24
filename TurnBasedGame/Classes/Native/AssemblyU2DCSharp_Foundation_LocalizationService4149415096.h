#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_ScriptableObject1975622470.h"

// Foundation.LocalizationService
struct LocalizationService_t4149415096;
// System.Action`1<Foundation.LocalizationService>
struct Action_1_t3951214478;
// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.Dictionary`2<System.String,System.String>>
struct Dictionary_2_t1563811461;
// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t3943999495;
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;
// Foundation.LanguageInfo
struct LanguageInfo_t3440310902;
// Foundation.LanguageInfo[]
struct LanguageInfoU5BU5D_t1703603955;
// System.Func`2<System.Reflection.FieldInfo,System.Boolean>
struct Func_2_t472048993;
// System.Func`2<System.Reflection.PropertyInfo,System.Boolean>
struct Func_2_t2083147554;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.LocalizationService
struct  LocalizationService_t4149415096  : public ScriptableObject_t1975622470
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.Dictionary`2<System.String,System.String>> Foundation.LocalizationService::<StringsByFile>k__BackingField
	Dictionary_2_t1563811461 * ___U3CStringsByFileU3Ek__BackingField_4;
	// System.Collections.Generic.Dictionary`2<System.String,System.String> Foundation.LocalizationService::<Strings>k__BackingField
	Dictionary_2_t3943999495 * ___U3CStringsU3Ek__BackingField_5;
	// System.Collections.Generic.List`1<System.String> Foundation.LocalizationService::<Files>k__BackingField
	List_1_t1398341365 * ___U3CFilesU3Ek__BackingField_6;
	// Foundation.LanguageInfo Foundation.LocalizationService::DefaultLanguage
	LanguageInfo_t3440310902 * ___DefaultLanguage_7;
	// Foundation.LanguageInfo Foundation.LocalizationService::_language
	LanguageInfo_t3440310902 * ____language_8;
	// Foundation.LanguageInfo[] Foundation.LocalizationService::Languages
	LanguageInfoU5BU5D_t1703603955* ___Languages_9;

public:
	inline static int32_t get_offset_of_U3CStringsByFileU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096, ___U3CStringsByFileU3Ek__BackingField_4)); }
	inline Dictionary_2_t1563811461 * get_U3CStringsByFileU3Ek__BackingField_4() const { return ___U3CStringsByFileU3Ek__BackingField_4; }
	inline Dictionary_2_t1563811461 ** get_address_of_U3CStringsByFileU3Ek__BackingField_4() { return &___U3CStringsByFileU3Ek__BackingField_4; }
	inline void set_U3CStringsByFileU3Ek__BackingField_4(Dictionary_2_t1563811461 * value)
	{
		___U3CStringsByFileU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CStringsByFileU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CStringsU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096, ___U3CStringsU3Ek__BackingField_5)); }
	inline Dictionary_2_t3943999495 * get_U3CStringsU3Ek__BackingField_5() const { return ___U3CStringsU3Ek__BackingField_5; }
	inline Dictionary_2_t3943999495 ** get_address_of_U3CStringsU3Ek__BackingField_5() { return &___U3CStringsU3Ek__BackingField_5; }
	inline void set_U3CStringsU3Ek__BackingField_5(Dictionary_2_t3943999495 * value)
	{
		___U3CStringsU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CStringsU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CFilesU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096, ___U3CFilesU3Ek__BackingField_6)); }
	inline List_1_t1398341365 * get_U3CFilesU3Ek__BackingField_6() const { return ___U3CFilesU3Ek__BackingField_6; }
	inline List_1_t1398341365 ** get_address_of_U3CFilesU3Ek__BackingField_6() { return &___U3CFilesU3Ek__BackingField_6; }
	inline void set_U3CFilesU3Ek__BackingField_6(List_1_t1398341365 * value)
	{
		___U3CFilesU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CFilesU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_DefaultLanguage_7() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096, ___DefaultLanguage_7)); }
	inline LanguageInfo_t3440310902 * get_DefaultLanguage_7() const { return ___DefaultLanguage_7; }
	inline LanguageInfo_t3440310902 ** get_address_of_DefaultLanguage_7() { return &___DefaultLanguage_7; }
	inline void set_DefaultLanguage_7(LanguageInfo_t3440310902 * value)
	{
		___DefaultLanguage_7 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultLanguage_7, value);
	}

	inline static int32_t get_offset_of__language_8() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096, ____language_8)); }
	inline LanguageInfo_t3440310902 * get__language_8() const { return ____language_8; }
	inline LanguageInfo_t3440310902 ** get_address_of__language_8() { return &____language_8; }
	inline void set__language_8(LanguageInfo_t3440310902 * value)
	{
		____language_8 = value;
		Il2CppCodeGenWriteBarrier(&____language_8, value);
	}

	inline static int32_t get_offset_of_Languages_9() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096, ___Languages_9)); }
	inline LanguageInfoU5BU5D_t1703603955* get_Languages_9() const { return ___Languages_9; }
	inline LanguageInfoU5BU5D_t1703603955** get_address_of_Languages_9() { return &___Languages_9; }
	inline void set_Languages_9(LanguageInfoU5BU5D_t1703603955* value)
	{
		___Languages_9 = value;
		Il2CppCodeGenWriteBarrier(&___Languages_9, value);
	}
};

struct LocalizationService_t4149415096_StaticFields
{
public:
	// Foundation.LocalizationService Foundation.LocalizationService::_instance
	LocalizationService_t4149415096 * ____instance_2;
	// System.Action`1<Foundation.LocalizationService> Foundation.LocalizationService::OnLanguageChanged
	Action_1_t3951214478 * ___OnLanguageChanged_3;
	// System.Func`2<System.Reflection.FieldInfo,System.Boolean> Foundation.LocalizationService::<>f__am$cache0
	Func_2_t472048993 * ___U3CU3Ef__amU24cache0_10;
	// System.Func`2<System.Reflection.PropertyInfo,System.Boolean> Foundation.LocalizationService::<>f__am$cache1
	Func_2_t2083147554 * ___U3CU3Ef__amU24cache1_11;

public:
	inline static int32_t get_offset_of__instance_2() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096_StaticFields, ____instance_2)); }
	inline LocalizationService_t4149415096 * get__instance_2() const { return ____instance_2; }
	inline LocalizationService_t4149415096 ** get_address_of__instance_2() { return &____instance_2; }
	inline void set__instance_2(LocalizationService_t4149415096 * value)
	{
		____instance_2 = value;
		Il2CppCodeGenWriteBarrier(&____instance_2, value);
	}

	inline static int32_t get_offset_of_OnLanguageChanged_3() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096_StaticFields, ___OnLanguageChanged_3)); }
	inline Action_1_t3951214478 * get_OnLanguageChanged_3() const { return ___OnLanguageChanged_3; }
	inline Action_1_t3951214478 ** get_address_of_OnLanguageChanged_3() { return &___OnLanguageChanged_3; }
	inline void set_OnLanguageChanged_3(Action_1_t3951214478 * value)
	{
		___OnLanguageChanged_3 = value;
		Il2CppCodeGenWriteBarrier(&___OnLanguageChanged_3, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_10() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096_StaticFields, ___U3CU3Ef__amU24cache0_10)); }
	inline Func_2_t472048993 * get_U3CU3Ef__amU24cache0_10() const { return ___U3CU3Ef__amU24cache0_10; }
	inline Func_2_t472048993 ** get_address_of_U3CU3Ef__amU24cache0_10() { return &___U3CU3Ef__amU24cache0_10; }
	inline void set_U3CU3Ef__amU24cache0_10(Func_2_t472048993 * value)
	{
		___U3CU3Ef__amU24cache0_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_10, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_11() { return static_cast<int32_t>(offsetof(LocalizationService_t4149415096_StaticFields, ___U3CU3Ef__amU24cache1_11)); }
	inline Func_2_t2083147554 * get_U3CU3Ef__amU24cache1_11() const { return ___U3CU3Ef__amU24cache1_11; }
	inline Func_2_t2083147554 ** get_address_of_U3CU3Ef__amU24cache1_11() { return &___U3CU3Ef__amU24cache1_11; }
	inline void set_U3CU3Ef__amU24cache1_11(Func_2_t2083147554 * value)
	{
		___U3CU3Ef__amU24cache1_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
