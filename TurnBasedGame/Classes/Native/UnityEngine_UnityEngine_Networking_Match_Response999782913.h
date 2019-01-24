#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_Networking_Match_ResponseB1952642056.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.Response
struct  Response_t999782913  : public ResponseBase_t1952642056
{
public:
	// System.Boolean UnityEngine.Networking.Match.Response::<success>k__BackingField
	bool ___U3CsuccessU3Ek__BackingField_0;
	// System.String UnityEngine.Networking.Match.Response::<extendedInfo>k__BackingField
	String_t* ___U3CextendedInfoU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CsuccessU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Response_t999782913, ___U3CsuccessU3Ek__BackingField_0)); }
	inline bool get_U3CsuccessU3Ek__BackingField_0() const { return ___U3CsuccessU3Ek__BackingField_0; }
	inline bool* get_address_of_U3CsuccessU3Ek__BackingField_0() { return &___U3CsuccessU3Ek__BackingField_0; }
	inline void set_U3CsuccessU3Ek__BackingField_0(bool value)
	{
		___U3CsuccessU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CextendedInfoU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Response_t999782913, ___U3CextendedInfoU3Ek__BackingField_1)); }
	inline String_t* get_U3CextendedInfoU3Ek__BackingField_1() const { return ___U3CextendedInfoU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CextendedInfoU3Ek__BackingField_1() { return &___U3CextendedInfoU3Ek__BackingField_1; }
	inline void set_U3CextendedInfoU3Ek__BackingField_1(String_t* value)
	{
		___U3CextendedInfoU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CextendedInfoU3Ek__BackingField_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
