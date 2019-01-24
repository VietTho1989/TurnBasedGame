#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_DateTime693205669.h"
#include "Foundation_Server_Unity3d_Foundation_Server_Api_St1550279825.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.Api.StorageRequest
struct  StorageRequest_t639770576  : public Il2CppObject
{
public:
	// System.String Foundation.Server.Api.StorageRequest::<ObjectId>k__BackingField
	String_t* ___U3CObjectIdU3Ek__BackingField_0;
	// System.String Foundation.Server.Api.StorageRequest::<ObjectType>k__BackingField
	String_t* ___U3CObjectTypeU3Ek__BackingField_1;
	// System.Single Foundation.Server.Api.StorageRequest::<ObjectScore>k__BackingField
	float ___U3CObjectScoreU3Ek__BackingField_2;
	// System.String Foundation.Server.Api.StorageRequest::<ObjectData>k__BackingField
	String_t* ___U3CObjectDataU3Ek__BackingField_3;
	// System.DateTime Foundation.Server.Api.StorageRequest::<ModifiedOn>k__BackingField
	DateTime_t693205669  ___U3CModifiedOnU3Ek__BackingField_4;
	// Foundation.Server.Api.StorageACLType Foundation.Server.Api.StorageRequest::<AclType>k__BackingField
	int32_t ___U3CAclTypeU3Ek__BackingField_5;
	// System.String Foundation.Server.Api.StorageRequest::<AclParam>k__BackingField
	String_t* ___U3CAclParamU3Ek__BackingField_6;

public:
	inline static int32_t get_offset_of_U3CObjectIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(StorageRequest_t639770576, ___U3CObjectIdU3Ek__BackingField_0)); }
	inline String_t* get_U3CObjectIdU3Ek__BackingField_0() const { return ___U3CObjectIdU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CObjectIdU3Ek__BackingField_0() { return &___U3CObjectIdU3Ek__BackingField_0; }
	inline void set_U3CObjectIdU3Ek__BackingField_0(String_t* value)
	{
		___U3CObjectIdU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CObjectIdU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CObjectTypeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(StorageRequest_t639770576, ___U3CObjectTypeU3Ek__BackingField_1)); }
	inline String_t* get_U3CObjectTypeU3Ek__BackingField_1() const { return ___U3CObjectTypeU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CObjectTypeU3Ek__BackingField_1() { return &___U3CObjectTypeU3Ek__BackingField_1; }
	inline void set_U3CObjectTypeU3Ek__BackingField_1(String_t* value)
	{
		___U3CObjectTypeU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CObjectTypeU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CObjectScoreU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(StorageRequest_t639770576, ___U3CObjectScoreU3Ek__BackingField_2)); }
	inline float get_U3CObjectScoreU3Ek__BackingField_2() const { return ___U3CObjectScoreU3Ek__BackingField_2; }
	inline float* get_address_of_U3CObjectScoreU3Ek__BackingField_2() { return &___U3CObjectScoreU3Ek__BackingField_2; }
	inline void set_U3CObjectScoreU3Ek__BackingField_2(float value)
	{
		___U3CObjectScoreU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CObjectDataU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(StorageRequest_t639770576, ___U3CObjectDataU3Ek__BackingField_3)); }
	inline String_t* get_U3CObjectDataU3Ek__BackingField_3() const { return ___U3CObjectDataU3Ek__BackingField_3; }
	inline String_t** get_address_of_U3CObjectDataU3Ek__BackingField_3() { return &___U3CObjectDataU3Ek__BackingField_3; }
	inline void set_U3CObjectDataU3Ek__BackingField_3(String_t* value)
	{
		___U3CObjectDataU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CObjectDataU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CModifiedOnU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(StorageRequest_t639770576, ___U3CModifiedOnU3Ek__BackingField_4)); }
	inline DateTime_t693205669  get_U3CModifiedOnU3Ek__BackingField_4() const { return ___U3CModifiedOnU3Ek__BackingField_4; }
	inline DateTime_t693205669 * get_address_of_U3CModifiedOnU3Ek__BackingField_4() { return &___U3CModifiedOnU3Ek__BackingField_4; }
	inline void set_U3CModifiedOnU3Ek__BackingField_4(DateTime_t693205669  value)
	{
		___U3CModifiedOnU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CAclTypeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(StorageRequest_t639770576, ___U3CAclTypeU3Ek__BackingField_5)); }
	inline int32_t get_U3CAclTypeU3Ek__BackingField_5() const { return ___U3CAclTypeU3Ek__BackingField_5; }
	inline int32_t* get_address_of_U3CAclTypeU3Ek__BackingField_5() { return &___U3CAclTypeU3Ek__BackingField_5; }
	inline void set_U3CAclTypeU3Ek__BackingField_5(int32_t value)
	{
		___U3CAclTypeU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CAclParamU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(StorageRequest_t639770576, ___U3CAclParamU3Ek__BackingField_6)); }
	inline String_t* get_U3CAclParamU3Ek__BackingField_6() const { return ___U3CAclParamU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CAclParamU3Ek__BackingField_6() { return &___U3CAclParamU3Ek__BackingField_6; }
	inline void set_U3CAclParamU3Ek__BackingField_6(String_t* value)
	{
		___U3CAclParamU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAclParamU3Ek__BackingField_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
