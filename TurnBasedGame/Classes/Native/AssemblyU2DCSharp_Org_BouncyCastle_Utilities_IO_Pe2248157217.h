#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IO.TextWriter
struct TextWriter_t4027217640;
// System.Char[]
struct CharU5BU5D_t1328083999;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.IO.Pem.PemWriter
struct  PemWriter_t2248157217  : public Il2CppObject
{
public:
	// System.IO.TextWriter Org.BouncyCastle.Utilities.IO.Pem.PemWriter::writer
	TextWriter_t4027217640 * ___writer_1;
	// System.Int32 Org.BouncyCastle.Utilities.IO.Pem.PemWriter::nlLength
	int32_t ___nlLength_2;
	// System.Char[] Org.BouncyCastle.Utilities.IO.Pem.PemWriter::buf
	CharU5BU5D_t1328083999* ___buf_3;

public:
	inline static int32_t get_offset_of_writer_1() { return static_cast<int32_t>(offsetof(PemWriter_t2248157217, ___writer_1)); }
	inline TextWriter_t4027217640 * get_writer_1() const { return ___writer_1; }
	inline TextWriter_t4027217640 ** get_address_of_writer_1() { return &___writer_1; }
	inline void set_writer_1(TextWriter_t4027217640 * value)
	{
		___writer_1 = value;
		Il2CppCodeGenWriteBarrier(&___writer_1, value);
	}

	inline static int32_t get_offset_of_nlLength_2() { return static_cast<int32_t>(offsetof(PemWriter_t2248157217, ___nlLength_2)); }
	inline int32_t get_nlLength_2() const { return ___nlLength_2; }
	inline int32_t* get_address_of_nlLength_2() { return &___nlLength_2; }
	inline void set_nlLength_2(int32_t value)
	{
		___nlLength_2 = value;
	}

	inline static int32_t get_offset_of_buf_3() { return static_cast<int32_t>(offsetof(PemWriter_t2248157217, ___buf_3)); }
	inline CharU5BU5D_t1328083999* get_buf_3() const { return ___buf_3; }
	inline CharU5BU5D_t1328083999** get_address_of_buf_3() { return &___buf_3; }
	inline void set_buf_3(CharU5BU5D_t1328083999* value)
	{
		___buf_3 = value;
		Il2CppCodeGenWriteBarrier(&___buf_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
