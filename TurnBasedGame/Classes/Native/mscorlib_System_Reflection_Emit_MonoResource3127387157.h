#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "mscorlib_System_Reflection_ResourceAttributes2389678029.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.String
struct String_t;
// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Emit.MonoResource
struct  MonoResource_t3127387157 
{
public:
	// System.Byte[] System.Reflection.Emit.MonoResource::data
	ByteU5BU5D_t3397334013* ___data_0;
	// System.String System.Reflection.Emit.MonoResource::name
	String_t* ___name_1;
	// System.String System.Reflection.Emit.MonoResource::filename
	String_t* ___filename_2;
	// System.Reflection.ResourceAttributes System.Reflection.Emit.MonoResource::attrs
	int32_t ___attrs_3;
	// System.Int32 System.Reflection.Emit.MonoResource::offset
	int32_t ___offset_4;
	// System.IO.Stream System.Reflection.Emit.MonoResource::stream
	Stream_t3255436806 * ___stream_5;

public:
	inline static int32_t get_offset_of_data_0() { return static_cast<int32_t>(offsetof(MonoResource_t3127387157, ___data_0)); }
	inline ByteU5BU5D_t3397334013* get_data_0() const { return ___data_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_data_0() { return &___data_0; }
	inline void set_data_0(ByteU5BU5D_t3397334013* value)
	{
		___data_0 = value;
		Il2CppCodeGenWriteBarrier(&___data_0, value);
	}

	inline static int32_t get_offset_of_name_1() { return static_cast<int32_t>(offsetof(MonoResource_t3127387157, ___name_1)); }
	inline String_t* get_name_1() const { return ___name_1; }
	inline String_t** get_address_of_name_1() { return &___name_1; }
	inline void set_name_1(String_t* value)
	{
		___name_1 = value;
		Il2CppCodeGenWriteBarrier(&___name_1, value);
	}

	inline static int32_t get_offset_of_filename_2() { return static_cast<int32_t>(offsetof(MonoResource_t3127387157, ___filename_2)); }
	inline String_t* get_filename_2() const { return ___filename_2; }
	inline String_t** get_address_of_filename_2() { return &___filename_2; }
	inline void set_filename_2(String_t* value)
	{
		___filename_2 = value;
		Il2CppCodeGenWriteBarrier(&___filename_2, value);
	}

	inline static int32_t get_offset_of_attrs_3() { return static_cast<int32_t>(offsetof(MonoResource_t3127387157, ___attrs_3)); }
	inline int32_t get_attrs_3() const { return ___attrs_3; }
	inline int32_t* get_address_of_attrs_3() { return &___attrs_3; }
	inline void set_attrs_3(int32_t value)
	{
		___attrs_3 = value;
	}

	inline static int32_t get_offset_of_offset_4() { return static_cast<int32_t>(offsetof(MonoResource_t3127387157, ___offset_4)); }
	inline int32_t get_offset_4() const { return ___offset_4; }
	inline int32_t* get_address_of_offset_4() { return &___offset_4; }
	inline void set_offset_4(int32_t value)
	{
		___offset_4 = value;
	}

	inline static int32_t get_offset_of_stream_5() { return static_cast<int32_t>(offsetof(MonoResource_t3127387157, ___stream_5)); }
	inline Stream_t3255436806 * get_stream_5() const { return ___stream_5; }
	inline Stream_t3255436806 ** get_address_of_stream_5() { return &___stream_5; }
	inline void set_stream_5(Stream_t3255436806 * value)
	{
		___stream_5 = value;
		Il2CppCodeGenWriteBarrier(&___stream_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Reflection.Emit.MonoResource
struct MonoResource_t3127387157_marshaled_pinvoke
{
	uint8_t* ___data_0;
	char* ___name_1;
	char* ___filename_2;
	int32_t ___attrs_3;
	int32_t ___offset_4;
	Stream_t3255436806 * ___stream_5;
};
// Native definition for COM marshalling of System.Reflection.Emit.MonoResource
struct MonoResource_t3127387157_marshaled_com
{
	uint8_t* ___data_0;
	Il2CppChar* ___name_1;
	Il2CppChar* ___filename_2;
	int32_t ___attrs_3;
	int32_t ___offset_4;
	Stream_t3255436806 * ___stream_5;
};
