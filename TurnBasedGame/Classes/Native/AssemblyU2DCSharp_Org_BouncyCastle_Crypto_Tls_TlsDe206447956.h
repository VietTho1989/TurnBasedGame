#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Utilities.Zlib.ZStream
struct ZStream_t708755204;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsDeflateCompression
struct  TlsDeflateCompression_t206447956  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Utilities.Zlib.ZStream Org.BouncyCastle.Crypto.Tls.TlsDeflateCompression::zIn
	ZStream_t708755204 * ___zIn_4;
	// Org.BouncyCastle.Utilities.Zlib.ZStream Org.BouncyCastle.Crypto.Tls.TlsDeflateCompression::zOut
	ZStream_t708755204 * ___zOut_5;

public:
	inline static int32_t get_offset_of_zIn_4() { return static_cast<int32_t>(offsetof(TlsDeflateCompression_t206447956, ___zIn_4)); }
	inline ZStream_t708755204 * get_zIn_4() const { return ___zIn_4; }
	inline ZStream_t708755204 ** get_address_of_zIn_4() { return &___zIn_4; }
	inline void set_zIn_4(ZStream_t708755204 * value)
	{
		___zIn_4 = value;
		Il2CppCodeGenWriteBarrier(&___zIn_4, value);
	}

	inline static int32_t get_offset_of_zOut_5() { return static_cast<int32_t>(offsetof(TlsDeflateCompression_t206447956, ___zOut_5)); }
	inline ZStream_t708755204 * get_zOut_5() const { return ___zOut_5; }
	inline ZStream_t708755204 ** get_address_of_zOut_5() { return &___zOut_5; }
	inline void set_zOut_5(ZStream_t708755204 * value)
	{
		___zOut_5 = value;
		Il2CppCodeGenWriteBarrier(&___zOut_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
