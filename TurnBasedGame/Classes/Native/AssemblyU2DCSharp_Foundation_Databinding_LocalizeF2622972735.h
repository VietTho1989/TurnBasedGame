#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.LocalizeFormatString
struct  LocalizeFormatString_t2622972735  : public MonoBehaviour_t1158329972
{
public:
	// System.String Foundation.Databinding.LocalizeFormatString::File
	String_t* ___File_2;
	// System.String Foundation.Databinding.LocalizeFormatString::Key
	String_t* ___Key_3;
	// System.String Foundation.Databinding.LocalizeFormatString::Fallback
	String_t* ___Fallback_4;
	// System.String Foundation.Databinding.LocalizeFormatString::Value
	String_t* ___Value_5;

public:
	inline static int32_t get_offset_of_File_2() { return static_cast<int32_t>(offsetof(LocalizeFormatString_t2622972735, ___File_2)); }
	inline String_t* get_File_2() const { return ___File_2; }
	inline String_t** get_address_of_File_2() { return &___File_2; }
	inline void set_File_2(String_t* value)
	{
		___File_2 = value;
		Il2CppCodeGenWriteBarrier(&___File_2, value);
	}

	inline static int32_t get_offset_of_Key_3() { return static_cast<int32_t>(offsetof(LocalizeFormatString_t2622972735, ___Key_3)); }
	inline String_t* get_Key_3() const { return ___Key_3; }
	inline String_t** get_address_of_Key_3() { return &___Key_3; }
	inline void set_Key_3(String_t* value)
	{
		___Key_3 = value;
		Il2CppCodeGenWriteBarrier(&___Key_3, value);
	}

	inline static int32_t get_offset_of_Fallback_4() { return static_cast<int32_t>(offsetof(LocalizeFormatString_t2622972735, ___Fallback_4)); }
	inline String_t* get_Fallback_4() const { return ___Fallback_4; }
	inline String_t** get_address_of_Fallback_4() { return &___Fallback_4; }
	inline void set_Fallback_4(String_t* value)
	{
		___Fallback_4 = value;
		Il2CppCodeGenWriteBarrier(&___Fallback_4, value);
	}

	inline static int32_t get_offset_of_Value_5() { return static_cast<int32_t>(offsetof(LocalizeFormatString_t2622972735, ___Value_5)); }
	inline String_t* get_Value_5() const { return ___Value_5; }
	inline String_t** get_address_of_Value_5() { return &___Value_5; }
	inline void set_Value_5(String_t* value)
	{
		___Value_5 = value;
		Il2CppCodeGenWriteBarrier(&___Value_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
