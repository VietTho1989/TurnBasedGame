#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Uri,BestHTTP.Caching.HTTPCacheFileInfo>
struct Dictionary_2_t2047352005;
// System.Collections.Generic.Dictionary`2<System.UInt64,BestHTTP.Caching.HTTPCacheFileInfo>
struct Dictionary_2_t504305847;
// System.String
struct String_t;
// System.Predicate`1<System.String>
struct Predicate_1_t472190348;
// System.Threading.ParameterizedThreadStart
struct ParameterizedThreadStart_t2412552885;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Caching.HTTPCacheService
struct  HTTPCacheService_t1690789871  : public Il2CppObject
{
public:

public:
};

struct HTTPCacheService_t1690789871_StaticFields
{
public:
	// System.Boolean BestHTTP.Caching.HTTPCacheService::isSupported
	bool ___isSupported_1;
	// System.Boolean BestHTTP.Caching.HTTPCacheService::IsSupportCheckDone
	bool ___IsSupportCheckDone_2;
	// System.Collections.Generic.Dictionary`2<System.Uri,BestHTTP.Caching.HTTPCacheFileInfo> BestHTTP.Caching.HTTPCacheService::library
	Dictionary_2_t2047352005 * ___library_3;
	// System.Collections.Generic.Dictionary`2<System.UInt64,BestHTTP.Caching.HTTPCacheFileInfo> BestHTTP.Caching.HTTPCacheService::UsedIndexes
	Dictionary_2_t504305847 * ___UsedIndexes_4;
	// System.String BestHTTP.Caching.HTTPCacheService::<CacheFolder>k__BackingField
	String_t* ___U3CCacheFolderU3Ek__BackingField_5;
	// System.String BestHTTP.Caching.HTTPCacheService::<LibraryPath>k__BackingField
	String_t* ___U3CLibraryPathU3Ek__BackingField_6;
	// System.Boolean BestHTTP.Caching.HTTPCacheService::InClearThread
	bool ___InClearThread_7;
	// System.Boolean BestHTTP.Caching.HTTPCacheService::InMaintainenceThread
	bool ___InMaintainenceThread_8;
	// System.UInt64 BestHTTP.Caching.HTTPCacheService::NextNameIDX
	uint64_t ___NextNameIDX_9;
	// System.Predicate`1<System.String> BestHTTP.Caching.HTTPCacheService::<>f__am$cache0
	Predicate_1_t472190348 * ___U3CU3Ef__amU24cache0_10;
	// System.Predicate`1<System.String> BestHTTP.Caching.HTTPCacheService::<>f__am$cache1
	Predicate_1_t472190348 * ___U3CU3Ef__amU24cache1_11;
	// System.Threading.ParameterizedThreadStart BestHTTP.Caching.HTTPCacheService::<>f__mg$cache0
	ParameterizedThreadStart_t2412552885 * ___U3CU3Ef__mgU24cache0_12;

public:
	inline static int32_t get_offset_of_isSupported_1() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___isSupported_1)); }
	inline bool get_isSupported_1() const { return ___isSupported_1; }
	inline bool* get_address_of_isSupported_1() { return &___isSupported_1; }
	inline void set_isSupported_1(bool value)
	{
		___isSupported_1 = value;
	}

	inline static int32_t get_offset_of_IsSupportCheckDone_2() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___IsSupportCheckDone_2)); }
	inline bool get_IsSupportCheckDone_2() const { return ___IsSupportCheckDone_2; }
	inline bool* get_address_of_IsSupportCheckDone_2() { return &___IsSupportCheckDone_2; }
	inline void set_IsSupportCheckDone_2(bool value)
	{
		___IsSupportCheckDone_2 = value;
	}

	inline static int32_t get_offset_of_library_3() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___library_3)); }
	inline Dictionary_2_t2047352005 * get_library_3() const { return ___library_3; }
	inline Dictionary_2_t2047352005 ** get_address_of_library_3() { return &___library_3; }
	inline void set_library_3(Dictionary_2_t2047352005 * value)
	{
		___library_3 = value;
		Il2CppCodeGenWriteBarrier(&___library_3, value);
	}

	inline static int32_t get_offset_of_UsedIndexes_4() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___UsedIndexes_4)); }
	inline Dictionary_2_t504305847 * get_UsedIndexes_4() const { return ___UsedIndexes_4; }
	inline Dictionary_2_t504305847 ** get_address_of_UsedIndexes_4() { return &___UsedIndexes_4; }
	inline void set_UsedIndexes_4(Dictionary_2_t504305847 * value)
	{
		___UsedIndexes_4 = value;
		Il2CppCodeGenWriteBarrier(&___UsedIndexes_4, value);
	}

	inline static int32_t get_offset_of_U3CCacheFolderU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___U3CCacheFolderU3Ek__BackingField_5)); }
	inline String_t* get_U3CCacheFolderU3Ek__BackingField_5() const { return ___U3CCacheFolderU3Ek__BackingField_5; }
	inline String_t** get_address_of_U3CCacheFolderU3Ek__BackingField_5() { return &___U3CCacheFolderU3Ek__BackingField_5; }
	inline void set_U3CCacheFolderU3Ek__BackingField_5(String_t* value)
	{
		___U3CCacheFolderU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCacheFolderU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CLibraryPathU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___U3CLibraryPathU3Ek__BackingField_6)); }
	inline String_t* get_U3CLibraryPathU3Ek__BackingField_6() const { return ___U3CLibraryPathU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CLibraryPathU3Ek__BackingField_6() { return &___U3CLibraryPathU3Ek__BackingField_6; }
	inline void set_U3CLibraryPathU3Ek__BackingField_6(String_t* value)
	{
		___U3CLibraryPathU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CLibraryPathU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_InClearThread_7() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___InClearThread_7)); }
	inline bool get_InClearThread_7() const { return ___InClearThread_7; }
	inline bool* get_address_of_InClearThread_7() { return &___InClearThread_7; }
	inline void set_InClearThread_7(bool value)
	{
		___InClearThread_7 = value;
	}

	inline static int32_t get_offset_of_InMaintainenceThread_8() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___InMaintainenceThread_8)); }
	inline bool get_InMaintainenceThread_8() const { return ___InMaintainenceThread_8; }
	inline bool* get_address_of_InMaintainenceThread_8() { return &___InMaintainenceThread_8; }
	inline void set_InMaintainenceThread_8(bool value)
	{
		___InMaintainenceThread_8 = value;
	}

	inline static int32_t get_offset_of_NextNameIDX_9() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___NextNameIDX_9)); }
	inline uint64_t get_NextNameIDX_9() const { return ___NextNameIDX_9; }
	inline uint64_t* get_address_of_NextNameIDX_9() { return &___NextNameIDX_9; }
	inline void set_NextNameIDX_9(uint64_t value)
	{
		___NextNameIDX_9 = value;
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_10() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___U3CU3Ef__amU24cache0_10)); }
	inline Predicate_1_t472190348 * get_U3CU3Ef__amU24cache0_10() const { return ___U3CU3Ef__amU24cache0_10; }
	inline Predicate_1_t472190348 ** get_address_of_U3CU3Ef__amU24cache0_10() { return &___U3CU3Ef__amU24cache0_10; }
	inline void set_U3CU3Ef__amU24cache0_10(Predicate_1_t472190348 * value)
	{
		___U3CU3Ef__amU24cache0_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_10, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_11() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___U3CU3Ef__amU24cache1_11)); }
	inline Predicate_1_t472190348 * get_U3CU3Ef__amU24cache1_11() const { return ___U3CU3Ef__amU24cache1_11; }
	inline Predicate_1_t472190348 ** get_address_of_U3CU3Ef__amU24cache1_11() { return &___U3CU3Ef__amU24cache1_11; }
	inline void set_U3CU3Ef__amU24cache1_11(Predicate_1_t472190348 * value)
	{
		___U3CU3Ef__amU24cache1_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_11, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_12() { return static_cast<int32_t>(offsetof(HTTPCacheService_t1690789871_StaticFields, ___U3CU3Ef__mgU24cache0_12)); }
	inline ParameterizedThreadStart_t2412552885 * get_U3CU3Ef__mgU24cache0_12() const { return ___U3CU3Ef__mgU24cache0_12; }
	inline ParameterizedThreadStart_t2412552885 ** get_address_of_U3CU3Ef__mgU24cache0_12() { return &___U3CU3Ef__mgU24cache0_12; }
	inline void set_U3CU3Ef__mgU24cache0_12(ParameterizedThreadStart_t2412552885 * value)
	{
		___U3CU3Ef__mgU24cache0_12 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache0_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
