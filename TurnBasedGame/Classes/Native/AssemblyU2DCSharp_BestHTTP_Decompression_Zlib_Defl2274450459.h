#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"

// BestHTTP.Decompression.Zlib.ZlibBaseStream
struct ZlibBaseStream_t3383394762;
// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.DeflateStream
struct  DeflateStream_t2274450459  : public Stream_t3255436806
{
public:
	// BestHTTP.Decompression.Zlib.ZlibBaseStream BestHTTP.Decompression.Zlib.DeflateStream::_baseStream
	ZlibBaseStream_t3383394762 * ____baseStream_2;
	// System.IO.Stream BestHTTP.Decompression.Zlib.DeflateStream::_innerStream
	Stream_t3255436806 * ____innerStream_3;
	// System.Boolean BestHTTP.Decompression.Zlib.DeflateStream::_disposed
	bool ____disposed_4;

public:
	inline static int32_t get_offset_of__baseStream_2() { return static_cast<int32_t>(offsetof(DeflateStream_t2274450459, ____baseStream_2)); }
	inline ZlibBaseStream_t3383394762 * get__baseStream_2() const { return ____baseStream_2; }
	inline ZlibBaseStream_t3383394762 ** get_address_of__baseStream_2() { return &____baseStream_2; }
	inline void set__baseStream_2(ZlibBaseStream_t3383394762 * value)
	{
		____baseStream_2 = value;
		Il2CppCodeGenWriteBarrier(&____baseStream_2, value);
	}

	inline static int32_t get_offset_of__innerStream_3() { return static_cast<int32_t>(offsetof(DeflateStream_t2274450459, ____innerStream_3)); }
	inline Stream_t3255436806 * get__innerStream_3() const { return ____innerStream_3; }
	inline Stream_t3255436806 ** get_address_of__innerStream_3() { return &____innerStream_3; }
	inline void set__innerStream_3(Stream_t3255436806 * value)
	{
		____innerStream_3 = value;
		Il2CppCodeGenWriteBarrier(&____innerStream_3, value);
	}

	inline static int32_t get_offset_of__disposed_4() { return static_cast<int32_t>(offsetof(DeflateStream_t2274450459, ____disposed_4)); }
	inline bool get__disposed_4() const { return ____disposed_4; }
	inline bool* get_address_of__disposed_4() { return &____disposed_4; }
	inline void set__disposed_4(bool value)
	{
		____disposed_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
