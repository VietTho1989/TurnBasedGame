#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.TermInfoReader
struct  TermInfoReader_t3840788697  : public Il2CppObject
{
public:
	// System.Int16 System.TermInfoReader::boolSize
	int16_t ___boolSize_0;
	// System.Int16 System.TermInfoReader::numSize
	int16_t ___numSize_1;
	// System.Int16 System.TermInfoReader::strOffsets
	int16_t ___strOffsets_2;
	// System.Byte[] System.TermInfoReader::buffer
	ByteU5BU5D_t3397334013* ___buffer_3;
	// System.Int32 System.TermInfoReader::booleansOffset
	int32_t ___booleansOffset_4;

public:
	inline static int32_t get_offset_of_boolSize_0() { return static_cast<int32_t>(offsetof(TermInfoReader_t3840788697, ___boolSize_0)); }
	inline int16_t get_boolSize_0() const { return ___boolSize_0; }
	inline int16_t* get_address_of_boolSize_0() { return &___boolSize_0; }
	inline void set_boolSize_0(int16_t value)
	{
		___boolSize_0 = value;
	}

	inline static int32_t get_offset_of_numSize_1() { return static_cast<int32_t>(offsetof(TermInfoReader_t3840788697, ___numSize_1)); }
	inline int16_t get_numSize_1() const { return ___numSize_1; }
	inline int16_t* get_address_of_numSize_1() { return &___numSize_1; }
	inline void set_numSize_1(int16_t value)
	{
		___numSize_1 = value;
	}

	inline static int32_t get_offset_of_strOffsets_2() { return static_cast<int32_t>(offsetof(TermInfoReader_t3840788697, ___strOffsets_2)); }
	inline int16_t get_strOffsets_2() const { return ___strOffsets_2; }
	inline int16_t* get_address_of_strOffsets_2() { return &___strOffsets_2; }
	inline void set_strOffsets_2(int16_t value)
	{
		___strOffsets_2 = value;
	}

	inline static int32_t get_offset_of_buffer_3() { return static_cast<int32_t>(offsetof(TermInfoReader_t3840788697, ___buffer_3)); }
	inline ByteU5BU5D_t3397334013* get_buffer_3() const { return ___buffer_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_buffer_3() { return &___buffer_3; }
	inline void set_buffer_3(ByteU5BU5D_t3397334013* value)
	{
		___buffer_3 = value;
		Il2CppCodeGenWriteBarrier(&___buffer_3, value);
	}

	inline static int32_t get_offset_of_booleansOffset_4() { return static_cast<int32_t>(offsetof(TermInfoReader_t3840788697, ___booleansOffset_4)); }
	inline int32_t get_booleansOffset_4() const { return ___booleansOffset_4; }
	inline int32_t* get_address_of_booleansOffset_4() { return &___booleansOffset_4; }
	inline void set_booleansOffset_4(int32_t value)
	{
		___booleansOffset_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
