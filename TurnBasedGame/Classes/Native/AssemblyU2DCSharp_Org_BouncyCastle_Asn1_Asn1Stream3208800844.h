#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IO.Stream
struct Stream_t3255436806;
// System.Byte[][]
struct ByteU5BU5DU5BU5D_t717853552;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Asn1StreamParser
struct  Asn1StreamParser_t3208800844  : public Il2CppObject
{
public:
	// System.IO.Stream Org.BouncyCastle.Asn1.Asn1StreamParser::_in
	Stream_t3255436806 * ____in_0;
	// System.Int32 Org.BouncyCastle.Asn1.Asn1StreamParser::_limit
	int32_t ____limit_1;
	// System.Byte[][] Org.BouncyCastle.Asn1.Asn1StreamParser::tmpBuffers
	ByteU5BU5DU5BU5D_t717853552* ___tmpBuffers_2;

public:
	inline static int32_t get_offset_of__in_0() { return static_cast<int32_t>(offsetof(Asn1StreamParser_t3208800844, ____in_0)); }
	inline Stream_t3255436806 * get__in_0() const { return ____in_0; }
	inline Stream_t3255436806 ** get_address_of__in_0() { return &____in_0; }
	inline void set__in_0(Stream_t3255436806 * value)
	{
		____in_0 = value;
		Il2CppCodeGenWriteBarrier(&____in_0, value);
	}

	inline static int32_t get_offset_of__limit_1() { return static_cast<int32_t>(offsetof(Asn1StreamParser_t3208800844, ____limit_1)); }
	inline int32_t get__limit_1() const { return ____limit_1; }
	inline int32_t* get_address_of__limit_1() { return &____limit_1; }
	inline void set__limit_1(int32_t value)
	{
		____limit_1 = value;
	}

	inline static int32_t get_offset_of_tmpBuffers_2() { return static_cast<int32_t>(offsetof(Asn1StreamParser_t3208800844, ___tmpBuffers_2)); }
	inline ByteU5BU5DU5BU5D_t717853552* get_tmpBuffers_2() const { return ___tmpBuffers_2; }
	inline ByteU5BU5DU5BU5D_t717853552** get_address_of_tmpBuffers_2() { return &___tmpBuffers_2; }
	inline void set_tmpBuffers_2(ByteU5BU5DU5BU5D_t717853552* value)
	{
		___tmpBuffers_2 = value;
		Il2CppCodeGenWriteBarrier(&___tmpBuffers_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
