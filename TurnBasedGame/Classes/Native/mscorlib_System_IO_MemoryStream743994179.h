﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.MemoryStream
struct  MemoryStream_t743994179  : public Stream_t3255436806
{
public:
	// System.Boolean System.IO.MemoryStream::canWrite
	bool ___canWrite_2;
	// System.Boolean System.IO.MemoryStream::allowGetBuffer
	bool ___allowGetBuffer_3;
	// System.Int32 System.IO.MemoryStream::capacity
	int32_t ___capacity_4;
	// System.Int32 System.IO.MemoryStream::length
	int32_t ___length_5;
	// System.Byte[] System.IO.MemoryStream::internalBuffer
	ByteU5BU5D_t3397334013* ___internalBuffer_6;
	// System.Int32 System.IO.MemoryStream::initialIndex
	int32_t ___initialIndex_7;
	// System.Boolean System.IO.MemoryStream::expandable
	bool ___expandable_8;
	// System.Boolean System.IO.MemoryStream::streamClosed
	bool ___streamClosed_9;
	// System.Int32 System.IO.MemoryStream::position
	int32_t ___position_10;
	// System.Int32 System.IO.MemoryStream::dirty_bytes
	int32_t ___dirty_bytes_11;

public:
	inline static int32_t get_offset_of_canWrite_2() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___canWrite_2)); }
	inline bool get_canWrite_2() const { return ___canWrite_2; }
	inline bool* get_address_of_canWrite_2() { return &___canWrite_2; }
	inline void set_canWrite_2(bool value)
	{
		___canWrite_2 = value;
	}

	inline static int32_t get_offset_of_allowGetBuffer_3() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___allowGetBuffer_3)); }
	inline bool get_allowGetBuffer_3() const { return ___allowGetBuffer_3; }
	inline bool* get_address_of_allowGetBuffer_3() { return &___allowGetBuffer_3; }
	inline void set_allowGetBuffer_3(bool value)
	{
		___allowGetBuffer_3 = value;
	}

	inline static int32_t get_offset_of_capacity_4() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___capacity_4)); }
	inline int32_t get_capacity_4() const { return ___capacity_4; }
	inline int32_t* get_address_of_capacity_4() { return &___capacity_4; }
	inline void set_capacity_4(int32_t value)
	{
		___capacity_4 = value;
	}

	inline static int32_t get_offset_of_length_5() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___length_5)); }
	inline int32_t get_length_5() const { return ___length_5; }
	inline int32_t* get_address_of_length_5() { return &___length_5; }
	inline void set_length_5(int32_t value)
	{
		___length_5 = value;
	}

	inline static int32_t get_offset_of_internalBuffer_6() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___internalBuffer_6)); }
	inline ByteU5BU5D_t3397334013* get_internalBuffer_6() const { return ___internalBuffer_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_internalBuffer_6() { return &___internalBuffer_6; }
	inline void set_internalBuffer_6(ByteU5BU5D_t3397334013* value)
	{
		___internalBuffer_6 = value;
		Il2CppCodeGenWriteBarrier(&___internalBuffer_6, value);
	}

	inline static int32_t get_offset_of_initialIndex_7() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___initialIndex_7)); }
	inline int32_t get_initialIndex_7() const { return ___initialIndex_7; }
	inline int32_t* get_address_of_initialIndex_7() { return &___initialIndex_7; }
	inline void set_initialIndex_7(int32_t value)
	{
		___initialIndex_7 = value;
	}

	inline static int32_t get_offset_of_expandable_8() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___expandable_8)); }
	inline bool get_expandable_8() const { return ___expandable_8; }
	inline bool* get_address_of_expandable_8() { return &___expandable_8; }
	inline void set_expandable_8(bool value)
	{
		___expandable_8 = value;
	}

	inline static int32_t get_offset_of_streamClosed_9() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___streamClosed_9)); }
	inline bool get_streamClosed_9() const { return ___streamClosed_9; }
	inline bool* get_address_of_streamClosed_9() { return &___streamClosed_9; }
	inline void set_streamClosed_9(bool value)
	{
		___streamClosed_9 = value;
	}

	inline static int32_t get_offset_of_position_10() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___position_10)); }
	inline int32_t get_position_10() const { return ___position_10; }
	inline int32_t* get_address_of_position_10() { return &___position_10; }
	inline void set_position_10(int32_t value)
	{
		___position_10 = value;
	}

	inline static int32_t get_offset_of_dirty_bytes_11() { return static_cast<int32_t>(offsetof(MemoryStream_t743994179, ___dirty_bytes_11)); }
	inline int32_t get_dirty_bytes_11() const { return ___dirty_bytes_11; }
	inline int32_t* get_address_of_dirty_bytes_11() { return &___dirty_bytes_11; }
	inline void set_dirty_bytes_11(int32_t value)
	{
		___dirty_bytes_11 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
