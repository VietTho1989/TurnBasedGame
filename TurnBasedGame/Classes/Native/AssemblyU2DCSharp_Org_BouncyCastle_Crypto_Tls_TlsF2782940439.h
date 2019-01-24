#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_IOException2458421087.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsFatalAlert
struct  TlsFatalAlert_t2782940439  : public IOException_t2458421087
{
public:
	// System.Byte Org.BouncyCastle.Crypto.Tls.TlsFatalAlert::alertDescription
	uint8_t ___alertDescription_11;

public:
	inline static int32_t get_offset_of_alertDescription_11() { return static_cast<int32_t>(offsetof(TlsFatalAlert_t2782940439, ___alertDescription_11)); }
	inline uint8_t get_alertDescription_11() const { return ___alertDescription_11; }
	inline uint8_t* get_address_of_alertDescription_11() { return &___alertDescription_11; }
	inline void set_alertDescription_11(uint8_t value)
	{
		___alertDescription_11 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
