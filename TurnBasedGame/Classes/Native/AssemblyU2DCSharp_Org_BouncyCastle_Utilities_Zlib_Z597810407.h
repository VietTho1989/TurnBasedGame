#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"

// Org.BouncyCastle.Utilities.Zlib.ZStream
struct ZStream_t708755204;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Zlib.ZOutputStream
struct  ZOutputStream_t597810407  : public Stream_t3255436806
{
public:
	// Org.BouncyCastle.Utilities.Zlib.ZStream Org.BouncyCastle.Utilities.Zlib.ZOutputStream::z
	ZStream_t708755204 * ___z_3;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.ZOutputStream::flushLevel
	int32_t ___flushLevel_4;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.ZOutputStream::buf
	ByteU5BU5D_t3397334013* ___buf_5;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.ZOutputStream::buf1
	ByteU5BU5D_t3397334013* ___buf1_6;
	// System.Boolean Org.BouncyCastle.Utilities.Zlib.ZOutputStream::compress
	bool ___compress_7;
	// System.IO.Stream Org.BouncyCastle.Utilities.Zlib.ZOutputStream::output
	Stream_t3255436806 * ___output_8;
	// System.Boolean Org.BouncyCastle.Utilities.Zlib.ZOutputStream::closed
	bool ___closed_9;

public:
	inline static int32_t get_offset_of_z_3() { return static_cast<int32_t>(offsetof(ZOutputStream_t597810407, ___z_3)); }
	inline ZStream_t708755204 * get_z_3() const { return ___z_3; }
	inline ZStream_t708755204 ** get_address_of_z_3() { return &___z_3; }
	inline void set_z_3(ZStream_t708755204 * value)
	{
		___z_3 = value;
		Il2CppCodeGenWriteBarrier(&___z_3, value);
	}

	inline static int32_t get_offset_of_flushLevel_4() { return static_cast<int32_t>(offsetof(ZOutputStream_t597810407, ___flushLevel_4)); }
	inline int32_t get_flushLevel_4() const { return ___flushLevel_4; }
	inline int32_t* get_address_of_flushLevel_4() { return &___flushLevel_4; }
	inline void set_flushLevel_4(int32_t value)
	{
		___flushLevel_4 = value;
	}

	inline static int32_t get_offset_of_buf_5() { return static_cast<int32_t>(offsetof(ZOutputStream_t597810407, ___buf_5)); }
	inline ByteU5BU5D_t3397334013* get_buf_5() const { return ___buf_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf_5() { return &___buf_5; }
	inline void set_buf_5(ByteU5BU5D_t3397334013* value)
	{
		___buf_5 = value;
		Il2CppCodeGenWriteBarrier(&___buf_5, value);
	}

	inline static int32_t get_offset_of_buf1_6() { return static_cast<int32_t>(offsetof(ZOutputStream_t597810407, ___buf1_6)); }
	inline ByteU5BU5D_t3397334013* get_buf1_6() const { return ___buf1_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf1_6() { return &___buf1_6; }
	inline void set_buf1_6(ByteU5BU5D_t3397334013* value)
	{
		___buf1_6 = value;
		Il2CppCodeGenWriteBarrier(&___buf1_6, value);
	}

	inline static int32_t get_offset_of_compress_7() { return static_cast<int32_t>(offsetof(ZOutputStream_t597810407, ___compress_7)); }
	inline bool get_compress_7() const { return ___compress_7; }
	inline bool* get_address_of_compress_7() { return &___compress_7; }
	inline void set_compress_7(bool value)
	{
		___compress_7 = value;
	}

	inline static int32_t get_offset_of_output_8() { return static_cast<int32_t>(offsetof(ZOutputStream_t597810407, ___output_8)); }
	inline Stream_t3255436806 * get_output_8() const { return ___output_8; }
	inline Stream_t3255436806 ** get_address_of_output_8() { return &___output_8; }
	inline void set_output_8(Stream_t3255436806 * value)
	{
		___output_8 = value;
		Il2CppCodeGenWriteBarrier(&___output_8, value);
	}

	inline static int32_t get_offset_of_closed_9() { return static_cast<int32_t>(offsetof(ZOutputStream_t597810407, ___closed_9)); }
	inline bool get_closed_9() const { return ___closed_9; }
	inline bool* get_address_of_closed_9() { return &___closed_9; }
	inline void set_closed_9(bool value)
	{
		___closed_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
