#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Nullable_1_gen3467111648.h"

// System.String
struct String_t;
// System.Collections.Generic.IDictionary`2<System.String,System.Object>
struct IDictionary_2_t2603311978;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.ResultBase
struct  ResultBase_t864677574  : public Il2CppObject
{
public:
	// System.String Facebook.Unity.ResultBase::<Error>k__BackingField
	String_t* ___U3CErrorU3Ek__BackingField_0;
	// System.Collections.Generic.IDictionary`2<System.String,System.Object> Facebook.Unity.ResultBase::<ResultDictionary>k__BackingField
	Il2CppObject* ___U3CResultDictionaryU3Ek__BackingField_1;
	// System.String Facebook.Unity.ResultBase::<RawResult>k__BackingField
	String_t* ___U3CRawResultU3Ek__BackingField_2;
	// System.Boolean Facebook.Unity.ResultBase::<Cancelled>k__BackingField
	bool ___U3CCancelledU3Ek__BackingField_3;
	// System.String Facebook.Unity.ResultBase::<CallbackId>k__BackingField
	String_t* ___U3CCallbackIdU3Ek__BackingField_4;
	// System.Nullable`1<System.Int64> Facebook.Unity.ResultBase::<CanvasErrorCode>k__BackingField
	Nullable_1_t3467111648  ___U3CCanvasErrorCodeU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_U3CErrorU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(ResultBase_t864677574, ___U3CErrorU3Ek__BackingField_0)); }
	inline String_t* get_U3CErrorU3Ek__BackingField_0() const { return ___U3CErrorU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CErrorU3Ek__BackingField_0() { return &___U3CErrorU3Ek__BackingField_0; }
	inline void set_U3CErrorU3Ek__BackingField_0(String_t* value)
	{
		___U3CErrorU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CErrorU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CResultDictionaryU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ResultBase_t864677574, ___U3CResultDictionaryU3Ek__BackingField_1)); }
	inline Il2CppObject* get_U3CResultDictionaryU3Ek__BackingField_1() const { return ___U3CResultDictionaryU3Ek__BackingField_1; }
	inline Il2CppObject** get_address_of_U3CResultDictionaryU3Ek__BackingField_1() { return &___U3CResultDictionaryU3Ek__BackingField_1; }
	inline void set_U3CResultDictionaryU3Ek__BackingField_1(Il2CppObject* value)
	{
		___U3CResultDictionaryU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CResultDictionaryU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CRawResultU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(ResultBase_t864677574, ___U3CRawResultU3Ek__BackingField_2)); }
	inline String_t* get_U3CRawResultU3Ek__BackingField_2() const { return ___U3CRawResultU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CRawResultU3Ek__BackingField_2() { return &___U3CRawResultU3Ek__BackingField_2; }
	inline void set_U3CRawResultU3Ek__BackingField_2(String_t* value)
	{
		___U3CRawResultU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRawResultU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CCancelledU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(ResultBase_t864677574, ___U3CCancelledU3Ek__BackingField_3)); }
	inline bool get_U3CCancelledU3Ek__BackingField_3() const { return ___U3CCancelledU3Ek__BackingField_3; }
	inline bool* get_address_of_U3CCancelledU3Ek__BackingField_3() { return &___U3CCancelledU3Ek__BackingField_3; }
	inline void set_U3CCancelledU3Ek__BackingField_3(bool value)
	{
		___U3CCancelledU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CCallbackIdU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(ResultBase_t864677574, ___U3CCallbackIdU3Ek__BackingField_4)); }
	inline String_t* get_U3CCallbackIdU3Ek__BackingField_4() const { return ___U3CCallbackIdU3Ek__BackingField_4; }
	inline String_t** get_address_of_U3CCallbackIdU3Ek__BackingField_4() { return &___U3CCallbackIdU3Ek__BackingField_4; }
	inline void set_U3CCallbackIdU3Ek__BackingField_4(String_t* value)
	{
		___U3CCallbackIdU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCallbackIdU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CCanvasErrorCodeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(ResultBase_t864677574, ___U3CCanvasErrorCodeU3Ek__BackingField_5)); }
	inline Nullable_1_t3467111648  get_U3CCanvasErrorCodeU3Ek__BackingField_5() const { return ___U3CCanvasErrorCodeU3Ek__BackingField_5; }
	inline Nullable_1_t3467111648 * get_address_of_U3CCanvasErrorCodeU3Ek__BackingField_5() { return &___U3CCanvasErrorCodeU3Ek__BackingField_5; }
	inline void set_U3CCanvasErrorCodeU3Ek__BackingField_5(Nullable_1_t3467111648  value)
	{
		___U3CCanvasErrorCodeU3Ek__BackingField_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
