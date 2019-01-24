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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.X509.PemParser
struct  PemParser_t1487846991  : public Il2CppObject
{
public:
	// System.String Org.BouncyCastle.X509.PemParser::_header1
	String_t* ____header1_0;
	// System.String Org.BouncyCastle.X509.PemParser::_header2
	String_t* ____header2_1;
	// System.String Org.BouncyCastle.X509.PemParser::_footer1
	String_t* ____footer1_2;
	// System.String Org.BouncyCastle.X509.PemParser::_footer2
	String_t* ____footer2_3;

public:
	inline static int32_t get_offset_of__header1_0() { return static_cast<int32_t>(offsetof(PemParser_t1487846991, ____header1_0)); }
	inline String_t* get__header1_0() const { return ____header1_0; }
	inline String_t** get_address_of__header1_0() { return &____header1_0; }
	inline void set__header1_0(String_t* value)
	{
		____header1_0 = value;
		Il2CppCodeGenWriteBarrier(&____header1_0, value);
	}

	inline static int32_t get_offset_of__header2_1() { return static_cast<int32_t>(offsetof(PemParser_t1487846991, ____header2_1)); }
	inline String_t* get__header2_1() const { return ____header2_1; }
	inline String_t** get_address_of__header2_1() { return &____header2_1; }
	inline void set__header2_1(String_t* value)
	{
		____header2_1 = value;
		Il2CppCodeGenWriteBarrier(&____header2_1, value);
	}

	inline static int32_t get_offset_of__footer1_2() { return static_cast<int32_t>(offsetof(PemParser_t1487846991, ____footer1_2)); }
	inline String_t* get__footer1_2() const { return ____footer1_2; }
	inline String_t** get_address_of__footer1_2() { return &____footer1_2; }
	inline void set__footer1_2(String_t* value)
	{
		____footer1_2 = value;
		Il2CppCodeGenWriteBarrier(&____footer1_2, value);
	}

	inline static int32_t get_offset_of__footer2_3() { return static_cast<int32_t>(offsetof(PemParser_t1487846991, ____footer2_3)); }
	inline String_t* get__footer2_3() const { return ____footer2_3; }
	inline String_t** get_address_of__footer2_3() { return &____footer2_3; }
	inline void set__footer2_3(String_t* value)
	{
		____footer2_3 = value;
		Il2CppCodeGenWriteBarrier(&____footer2_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
