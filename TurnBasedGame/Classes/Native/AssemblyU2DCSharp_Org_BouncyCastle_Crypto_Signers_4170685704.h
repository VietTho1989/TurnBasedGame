#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Macs.HMac
struct HMac_t2564819335;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.HMacDsaKCalculator
struct  HMacDsaKCalculator_t4170685704  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Macs.HMac Org.BouncyCastle.Crypto.Signers.HMacDsaKCalculator::hMac
	HMac_t2564819335 * ___hMac_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.HMacDsaKCalculator::K
	ByteU5BU5D_t3397334013* ___K_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.HMacDsaKCalculator::V
	ByteU5BU5D_t3397334013* ___V_2;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Signers.HMacDsaKCalculator::n
	BigInteger_t4268922522 * ___n_3;

public:
	inline static int32_t get_offset_of_hMac_0() { return static_cast<int32_t>(offsetof(HMacDsaKCalculator_t4170685704, ___hMac_0)); }
	inline HMac_t2564819335 * get_hMac_0() const { return ___hMac_0; }
	inline HMac_t2564819335 ** get_address_of_hMac_0() { return &___hMac_0; }
	inline void set_hMac_0(HMac_t2564819335 * value)
	{
		___hMac_0 = value;
		Il2CppCodeGenWriteBarrier(&___hMac_0, value);
	}

	inline static int32_t get_offset_of_K_1() { return static_cast<int32_t>(offsetof(HMacDsaKCalculator_t4170685704, ___K_1)); }
	inline ByteU5BU5D_t3397334013* get_K_1() const { return ___K_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_K_1() { return &___K_1; }
	inline void set_K_1(ByteU5BU5D_t3397334013* value)
	{
		___K_1 = value;
		Il2CppCodeGenWriteBarrier(&___K_1, value);
	}

	inline static int32_t get_offset_of_V_2() { return static_cast<int32_t>(offsetof(HMacDsaKCalculator_t4170685704, ___V_2)); }
	inline ByteU5BU5D_t3397334013* get_V_2() const { return ___V_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_V_2() { return &___V_2; }
	inline void set_V_2(ByteU5BU5D_t3397334013* value)
	{
		___V_2 = value;
		Il2CppCodeGenWriteBarrier(&___V_2, value);
	}

	inline static int32_t get_offset_of_n_3() { return static_cast<int32_t>(offsetof(HMacDsaKCalculator_t4170685704, ___n_3)); }
	inline BigInteger_t4268922522 * get_n_3() const { return ___n_3; }
	inline BigInteger_t4268922522 ** get_address_of_n_3() { return &___n_3; }
	inline void set_n_3(BigInteger_t4268922522 * value)
	{
		___n_3 = value;
		Il2CppCodeGenWriteBarrier(&___n_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
