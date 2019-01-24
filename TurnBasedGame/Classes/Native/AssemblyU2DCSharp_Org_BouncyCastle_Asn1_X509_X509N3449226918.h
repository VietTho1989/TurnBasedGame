#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.X509NameTokenizer
struct  X509NameTokenizer_t3449226918  : public Il2CppObject
{
public:
	// System.String Org.BouncyCastle.Asn1.X509.X509NameTokenizer::value
	String_t* ___value_0;
	// System.Int32 Org.BouncyCastle.Asn1.X509.X509NameTokenizer::index
	int32_t ___index_1;
	// System.Char Org.BouncyCastle.Asn1.X509.X509NameTokenizer::separator
	Il2CppChar ___separator_2;
	// System.Text.StringBuilder Org.BouncyCastle.Asn1.X509.X509NameTokenizer::buffer
	StringBuilder_t1221177846 * ___buffer_3;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(X509NameTokenizer_t3449226918, ___value_0)); }
	inline String_t* get_value_0() const { return ___value_0; }
	inline String_t** get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(String_t* value)
	{
		___value_0 = value;
		Il2CppCodeGenWriteBarrier(&___value_0, value);
	}

	inline static int32_t get_offset_of_index_1() { return static_cast<int32_t>(offsetof(X509NameTokenizer_t3449226918, ___index_1)); }
	inline int32_t get_index_1() const { return ___index_1; }
	inline int32_t* get_address_of_index_1() { return &___index_1; }
	inline void set_index_1(int32_t value)
	{
		___index_1 = value;
	}

	inline static int32_t get_offset_of_separator_2() { return static_cast<int32_t>(offsetof(X509NameTokenizer_t3449226918, ___separator_2)); }
	inline Il2CppChar get_separator_2() const { return ___separator_2; }
	inline Il2CppChar* get_address_of_separator_2() { return &___separator_2; }
	inline void set_separator_2(Il2CppChar value)
	{
		___separator_2 = value;
	}

	inline static int32_t get_offset_of_buffer_3() { return static_cast<int32_t>(offsetof(X509NameTokenizer_t3449226918, ___buffer_3)); }
	inline StringBuilder_t1221177846 * get_buffer_3() const { return ___buffer_3; }
	inline StringBuilder_t1221177846 ** get_address_of_buffer_3() { return &___buffer_3; }
	inline void set_buffer_3(StringBuilder_t1221177846 * value)
	{
		___buffer_3 = value;
		Il2CppCodeGenWriteBarrier(&___buffer_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
