#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<BestHTTP.Cookies.Cookie>
struct List_1_t3531925514;
// System.String
struct String_t;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Cookies.CookieJar
struct  CookieJar_t756201495  : public Il2CppObject
{
public:

public:
};

struct CookieJar_t756201495_StaticFields
{
public:
	// System.Collections.Generic.List`1<BestHTTP.Cookies.Cookie> BestHTTP.Cookies.CookieJar::Cookies
	List_1_t3531925514 * ___Cookies_1;
	// System.String BestHTTP.Cookies.CookieJar::<CookieFolder>k__BackingField
	String_t* ___U3CCookieFolderU3Ek__BackingField_2;
	// System.String BestHTTP.Cookies.CookieJar::<LibraryPath>k__BackingField
	String_t* ___U3CLibraryPathU3Ek__BackingField_3;
	// System.Object BestHTTP.Cookies.CookieJar::Locker
	Il2CppObject * ___Locker_4;
	// System.Boolean BestHTTP.Cookies.CookieJar::_isSavingSupported
	bool ____isSavingSupported_5;
	// System.Boolean BestHTTP.Cookies.CookieJar::IsSupportCheckDone
	bool ___IsSupportCheckDone_6;
	// System.Boolean BestHTTP.Cookies.CookieJar::Loaded
	bool ___Loaded_7;

public:
	inline static int32_t get_offset_of_Cookies_1() { return static_cast<int32_t>(offsetof(CookieJar_t756201495_StaticFields, ___Cookies_1)); }
	inline List_1_t3531925514 * get_Cookies_1() const { return ___Cookies_1; }
	inline List_1_t3531925514 ** get_address_of_Cookies_1() { return &___Cookies_1; }
	inline void set_Cookies_1(List_1_t3531925514 * value)
	{
		___Cookies_1 = value;
		Il2CppCodeGenWriteBarrier(&___Cookies_1, value);
	}

	inline static int32_t get_offset_of_U3CCookieFolderU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(CookieJar_t756201495_StaticFields, ___U3CCookieFolderU3Ek__BackingField_2)); }
	inline String_t* get_U3CCookieFolderU3Ek__BackingField_2() const { return ___U3CCookieFolderU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CCookieFolderU3Ek__BackingField_2() { return &___U3CCookieFolderU3Ek__BackingField_2; }
	inline void set_U3CCookieFolderU3Ek__BackingField_2(String_t* value)
	{
		___U3CCookieFolderU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCookieFolderU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CLibraryPathU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(CookieJar_t756201495_StaticFields, ___U3CLibraryPathU3Ek__BackingField_3)); }
	inline String_t* get_U3CLibraryPathU3Ek__BackingField_3() const { return ___U3CLibraryPathU3Ek__BackingField_3; }
	inline String_t** get_address_of_U3CLibraryPathU3Ek__BackingField_3() { return &___U3CLibraryPathU3Ek__BackingField_3; }
	inline void set_U3CLibraryPathU3Ek__BackingField_3(String_t* value)
	{
		___U3CLibraryPathU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CLibraryPathU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_Locker_4() { return static_cast<int32_t>(offsetof(CookieJar_t756201495_StaticFields, ___Locker_4)); }
	inline Il2CppObject * get_Locker_4() const { return ___Locker_4; }
	inline Il2CppObject ** get_address_of_Locker_4() { return &___Locker_4; }
	inline void set_Locker_4(Il2CppObject * value)
	{
		___Locker_4 = value;
		Il2CppCodeGenWriteBarrier(&___Locker_4, value);
	}

	inline static int32_t get_offset_of__isSavingSupported_5() { return static_cast<int32_t>(offsetof(CookieJar_t756201495_StaticFields, ____isSavingSupported_5)); }
	inline bool get__isSavingSupported_5() const { return ____isSavingSupported_5; }
	inline bool* get_address_of__isSavingSupported_5() { return &____isSavingSupported_5; }
	inline void set__isSavingSupported_5(bool value)
	{
		____isSavingSupported_5 = value;
	}

	inline static int32_t get_offset_of_IsSupportCheckDone_6() { return static_cast<int32_t>(offsetof(CookieJar_t756201495_StaticFields, ___IsSupportCheckDone_6)); }
	inline bool get_IsSupportCheckDone_6() const { return ___IsSupportCheckDone_6; }
	inline bool* get_address_of_IsSupportCheckDone_6() { return &___IsSupportCheckDone_6; }
	inline void set_IsSupportCheckDone_6(bool value)
	{
		___IsSupportCheckDone_6 = value;
	}

	inline static int32_t get_offset_of_Loaded_7() { return static_cast<int32_t>(offsetof(CookieJar_t756201495_StaticFields, ___Loaded_7)); }
	inline bool get_Loaded_7() const { return ___Loaded_7; }
	inline bool* get_address_of_Loaded_7() { return &___Loaded_7; }
	inline void set_Loaded_7(bool value)
	{
		___Loaded_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
