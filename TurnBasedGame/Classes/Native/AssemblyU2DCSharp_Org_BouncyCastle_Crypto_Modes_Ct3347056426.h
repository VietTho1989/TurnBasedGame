#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_BufferedB711630611.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.CtsBlockCipher
struct  CtsBlockCipher_t3347056426  : public BufferedBlockCipher_t711630611
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Modes.CtsBlockCipher::blockSize
	int32_t ___blockSize_5;

public:
	inline static int32_t get_offset_of_blockSize_5() { return static_cast<int32_t>(offsetof(CtsBlockCipher_t3347056426, ___blockSize_5)); }
	inline int32_t get_blockSize_5() const { return ___blockSize_5; }
	inline int32_t* get_address_of_blockSize_5() { return &___blockSize_5; }
	inline void set_blockSize_5(int32_t value)
	{
		___blockSize_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
