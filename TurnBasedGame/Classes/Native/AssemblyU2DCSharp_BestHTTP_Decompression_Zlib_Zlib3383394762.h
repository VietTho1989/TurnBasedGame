#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Zlib3915258526.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Flus1182037460.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_ZlibS953065013.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Comp2282214205.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Comp4151391442.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Comp2530143933.h"
#include "mscorlib_System_DateTime693205669.h"

// BestHTTP.Decompression.Zlib.ZlibCodec
struct ZlibCodec_t1899545627;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.IO.Stream
struct Stream_t3255436806;
// BestHTTP.Decompression.Crc.CRC32
struct CRC32_t2268741539;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.ZlibBaseStream
struct  ZlibBaseStream_t3383394762  : public Stream_t3255436806
{
public:
	// BestHTTP.Decompression.Zlib.ZlibCodec BestHTTP.Decompression.Zlib.ZlibBaseStream::_z
	ZlibCodec_t1899545627 * ____z_2;
	// BestHTTP.Decompression.Zlib.ZlibBaseStream/StreamMode BestHTTP.Decompression.Zlib.ZlibBaseStream::_streamMode
	int32_t ____streamMode_3;
	// BestHTTP.Decompression.Zlib.FlushType BestHTTP.Decompression.Zlib.ZlibBaseStream::_flushMode
	int32_t ____flushMode_4;
	// BestHTTP.Decompression.Zlib.ZlibStreamFlavor BestHTTP.Decompression.Zlib.ZlibBaseStream::_flavor
	int32_t ____flavor_5;
	// BestHTTP.Decompression.Zlib.CompressionMode BestHTTP.Decompression.Zlib.ZlibBaseStream::_compressionMode
	int32_t ____compressionMode_6;
	// BestHTTP.Decompression.Zlib.CompressionLevel BestHTTP.Decompression.Zlib.ZlibBaseStream::_level
	int32_t ____level_7;
	// System.Boolean BestHTTP.Decompression.Zlib.ZlibBaseStream::_leaveOpen
	bool ____leaveOpen_8;
	// System.Byte[] BestHTTP.Decompression.Zlib.ZlibBaseStream::_workingBuffer
	ByteU5BU5D_t3397334013* ____workingBuffer_9;
	// System.Int32 BestHTTP.Decompression.Zlib.ZlibBaseStream::_bufferSize
	int32_t ____bufferSize_10;
	// System.Byte[] BestHTTP.Decompression.Zlib.ZlibBaseStream::_buf1
	ByteU5BU5D_t3397334013* ____buf1_11;
	// System.IO.Stream BestHTTP.Decompression.Zlib.ZlibBaseStream::_stream
	Stream_t3255436806 * ____stream_12;
	// BestHTTP.Decompression.Zlib.CompressionStrategy BestHTTP.Decompression.Zlib.ZlibBaseStream::Strategy
	int32_t ___Strategy_13;
	// BestHTTP.Decompression.Crc.CRC32 BestHTTP.Decompression.Zlib.ZlibBaseStream::crc
	CRC32_t2268741539 * ___crc_14;
	// System.String BestHTTP.Decompression.Zlib.ZlibBaseStream::_GzipFileName
	String_t* ____GzipFileName_15;
	// System.String BestHTTP.Decompression.Zlib.ZlibBaseStream::_GzipComment
	String_t* ____GzipComment_16;
	// System.DateTime BestHTTP.Decompression.Zlib.ZlibBaseStream::_GzipMtime
	DateTime_t693205669  ____GzipMtime_17;
	// System.Int32 BestHTTP.Decompression.Zlib.ZlibBaseStream::_gzipHeaderByteCount
	int32_t ____gzipHeaderByteCount_18;
	// System.Boolean BestHTTP.Decompression.Zlib.ZlibBaseStream::nomoreinput
	bool ___nomoreinput_19;

public:
	inline static int32_t get_offset_of__z_2() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____z_2)); }
	inline ZlibCodec_t1899545627 * get__z_2() const { return ____z_2; }
	inline ZlibCodec_t1899545627 ** get_address_of__z_2() { return &____z_2; }
	inline void set__z_2(ZlibCodec_t1899545627 * value)
	{
		____z_2 = value;
		Il2CppCodeGenWriteBarrier(&____z_2, value);
	}

	inline static int32_t get_offset_of__streamMode_3() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____streamMode_3)); }
	inline int32_t get__streamMode_3() const { return ____streamMode_3; }
	inline int32_t* get_address_of__streamMode_3() { return &____streamMode_3; }
	inline void set__streamMode_3(int32_t value)
	{
		____streamMode_3 = value;
	}

	inline static int32_t get_offset_of__flushMode_4() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____flushMode_4)); }
	inline int32_t get__flushMode_4() const { return ____flushMode_4; }
	inline int32_t* get_address_of__flushMode_4() { return &____flushMode_4; }
	inline void set__flushMode_4(int32_t value)
	{
		____flushMode_4 = value;
	}

	inline static int32_t get_offset_of__flavor_5() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____flavor_5)); }
	inline int32_t get__flavor_5() const { return ____flavor_5; }
	inline int32_t* get_address_of__flavor_5() { return &____flavor_5; }
	inline void set__flavor_5(int32_t value)
	{
		____flavor_5 = value;
	}

	inline static int32_t get_offset_of__compressionMode_6() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____compressionMode_6)); }
	inline int32_t get__compressionMode_6() const { return ____compressionMode_6; }
	inline int32_t* get_address_of__compressionMode_6() { return &____compressionMode_6; }
	inline void set__compressionMode_6(int32_t value)
	{
		____compressionMode_6 = value;
	}

	inline static int32_t get_offset_of__level_7() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____level_7)); }
	inline int32_t get__level_7() const { return ____level_7; }
	inline int32_t* get_address_of__level_7() { return &____level_7; }
	inline void set__level_7(int32_t value)
	{
		____level_7 = value;
	}

	inline static int32_t get_offset_of__leaveOpen_8() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____leaveOpen_8)); }
	inline bool get__leaveOpen_8() const { return ____leaveOpen_8; }
	inline bool* get_address_of__leaveOpen_8() { return &____leaveOpen_8; }
	inline void set__leaveOpen_8(bool value)
	{
		____leaveOpen_8 = value;
	}

	inline static int32_t get_offset_of__workingBuffer_9() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____workingBuffer_9)); }
	inline ByteU5BU5D_t3397334013* get__workingBuffer_9() const { return ____workingBuffer_9; }
	inline ByteU5BU5D_t3397334013** get_address_of__workingBuffer_9() { return &____workingBuffer_9; }
	inline void set__workingBuffer_9(ByteU5BU5D_t3397334013* value)
	{
		____workingBuffer_9 = value;
		Il2CppCodeGenWriteBarrier(&____workingBuffer_9, value);
	}

	inline static int32_t get_offset_of__bufferSize_10() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____bufferSize_10)); }
	inline int32_t get__bufferSize_10() const { return ____bufferSize_10; }
	inline int32_t* get_address_of__bufferSize_10() { return &____bufferSize_10; }
	inline void set__bufferSize_10(int32_t value)
	{
		____bufferSize_10 = value;
	}

	inline static int32_t get_offset_of__buf1_11() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____buf1_11)); }
	inline ByteU5BU5D_t3397334013* get__buf1_11() const { return ____buf1_11; }
	inline ByteU5BU5D_t3397334013** get_address_of__buf1_11() { return &____buf1_11; }
	inline void set__buf1_11(ByteU5BU5D_t3397334013* value)
	{
		____buf1_11 = value;
		Il2CppCodeGenWriteBarrier(&____buf1_11, value);
	}

	inline static int32_t get_offset_of__stream_12() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____stream_12)); }
	inline Stream_t3255436806 * get__stream_12() const { return ____stream_12; }
	inline Stream_t3255436806 ** get_address_of__stream_12() { return &____stream_12; }
	inline void set__stream_12(Stream_t3255436806 * value)
	{
		____stream_12 = value;
		Il2CppCodeGenWriteBarrier(&____stream_12, value);
	}

	inline static int32_t get_offset_of_Strategy_13() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ___Strategy_13)); }
	inline int32_t get_Strategy_13() const { return ___Strategy_13; }
	inline int32_t* get_address_of_Strategy_13() { return &___Strategy_13; }
	inline void set_Strategy_13(int32_t value)
	{
		___Strategy_13 = value;
	}

	inline static int32_t get_offset_of_crc_14() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ___crc_14)); }
	inline CRC32_t2268741539 * get_crc_14() const { return ___crc_14; }
	inline CRC32_t2268741539 ** get_address_of_crc_14() { return &___crc_14; }
	inline void set_crc_14(CRC32_t2268741539 * value)
	{
		___crc_14 = value;
		Il2CppCodeGenWriteBarrier(&___crc_14, value);
	}

	inline static int32_t get_offset_of__GzipFileName_15() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____GzipFileName_15)); }
	inline String_t* get__GzipFileName_15() const { return ____GzipFileName_15; }
	inline String_t** get_address_of__GzipFileName_15() { return &____GzipFileName_15; }
	inline void set__GzipFileName_15(String_t* value)
	{
		____GzipFileName_15 = value;
		Il2CppCodeGenWriteBarrier(&____GzipFileName_15, value);
	}

	inline static int32_t get_offset_of__GzipComment_16() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____GzipComment_16)); }
	inline String_t* get__GzipComment_16() const { return ____GzipComment_16; }
	inline String_t** get_address_of__GzipComment_16() { return &____GzipComment_16; }
	inline void set__GzipComment_16(String_t* value)
	{
		____GzipComment_16 = value;
		Il2CppCodeGenWriteBarrier(&____GzipComment_16, value);
	}

	inline static int32_t get_offset_of__GzipMtime_17() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____GzipMtime_17)); }
	inline DateTime_t693205669  get__GzipMtime_17() const { return ____GzipMtime_17; }
	inline DateTime_t693205669 * get_address_of__GzipMtime_17() { return &____GzipMtime_17; }
	inline void set__GzipMtime_17(DateTime_t693205669  value)
	{
		____GzipMtime_17 = value;
	}

	inline static int32_t get_offset_of__gzipHeaderByteCount_18() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ____gzipHeaderByteCount_18)); }
	inline int32_t get__gzipHeaderByteCount_18() const { return ____gzipHeaderByteCount_18; }
	inline int32_t* get_address_of__gzipHeaderByteCount_18() { return &____gzipHeaderByteCount_18; }
	inline void set__gzipHeaderByteCount_18(int32_t value)
	{
		____gzipHeaderByteCount_18 = value;
	}

	inline static int32_t get_offset_of_nomoreinput_19() { return static_cast<int32_t>(offsetof(ZlibBaseStream_t3383394762, ___nomoreinput_19)); }
	inline bool get_nomoreinput_19() const { return ___nomoreinput_19; }
	inline bool* get_address_of_nomoreinput_19() { return &___nomoreinput_19; }
	inline void set_nomoreinput_19(bool value)
	{
		___nomoreinput_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
