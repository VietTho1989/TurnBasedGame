#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.String
struct String_t;
// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.TextPic/IconName
struct  IconName_t4224240103 
{
public:
	// System.String UnityEngine.UI.Extensions.TextPic/IconName::name
	String_t* ___name_0;
	// UnityEngine.Sprite UnityEngine.UI.Extensions.TextPic/IconName::sprite
	Sprite_t309593783 * ___sprite_1;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(IconName_t4224240103, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier(&___name_0, value);
	}

	inline static int32_t get_offset_of_sprite_1() { return static_cast<int32_t>(offsetof(IconName_t4224240103, ___sprite_1)); }
	inline Sprite_t309593783 * get_sprite_1() const { return ___sprite_1; }
	inline Sprite_t309593783 ** get_address_of_sprite_1() { return &___sprite_1; }
	inline void set_sprite_1(Sprite_t309593783 * value)
	{
		___sprite_1 = value;
		Il2CppCodeGenWriteBarrier(&___sprite_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.UI.Extensions.TextPic/IconName
struct IconName_t4224240103_marshaled_pinvoke
{
	char* ___name_0;
	Sprite_t309593783 * ___sprite_1;
};
// Native definition for COM marshalling of UnityEngine.UI.Extensions.TextPic/IconName
struct IconName_t4224240103_marshaled_com
{
	Il2CppChar* ___name_0;
	Sprite_t309593783 * ___sprite_1;
};
