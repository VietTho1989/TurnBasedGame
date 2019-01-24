#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_BufferedB711630611.h"

// Org.BouncyCastle.Crypto.Paddings.IBlockCipherPadding
struct IBlockCipherPadding_t1136805358;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Paddings.PaddedBufferedBlockCipher
struct  PaddedBufferedBlockCipher_t4046604239  : public BufferedBlockCipher_t711630611
{
public:
	// Org.BouncyCastle.Crypto.Paddings.IBlockCipherPadding Org.BouncyCastle.Crypto.Paddings.PaddedBufferedBlockCipher::padding
	Il2CppObject * ___padding_5;

public:
	inline static int32_t get_offset_of_padding_5() { return static_cast<int32_t>(offsetof(PaddedBufferedBlockCipher_t4046604239, ___padding_5)); }
	inline Il2CppObject * get_padding_5() const { return ___padding_5; }
	inline Il2CppObject ** get_address_of_padding_5() { return &___padding_5; }
	inline void set_padding_5(Il2CppObject * value)
	{
		___padding_5 = value;
		Il2CppCodeGenWriteBarrier(&___padding_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
