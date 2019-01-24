#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Tls.TlsContext
struct TlsContext_t4077776538;
// Org.BouncyCastle.Crypto.Tls.DigestInputBuffer
struct DigestInputBuffer_t3911248312;
// System.Collections.IDictionary
struct IDictionary_t596158605;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.DeferredHash
struct  DeferredHash_t1571847761  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.DeferredHash::mContext
	Il2CppObject * ___mContext_1;
	// Org.BouncyCastle.Crypto.Tls.DigestInputBuffer Org.BouncyCastle.Crypto.Tls.DeferredHash::mBuf
	DigestInputBuffer_t3911248312 * ___mBuf_2;
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Tls.DeferredHash::mHashes
	Il2CppObject * ___mHashes_3;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.DeferredHash::mPrfHashAlgorithm
	int32_t ___mPrfHashAlgorithm_4;

public:
	inline static int32_t get_offset_of_mContext_1() { return static_cast<int32_t>(offsetof(DeferredHash_t1571847761, ___mContext_1)); }
	inline Il2CppObject * get_mContext_1() const { return ___mContext_1; }
	inline Il2CppObject ** get_address_of_mContext_1() { return &___mContext_1; }
	inline void set_mContext_1(Il2CppObject * value)
	{
		___mContext_1 = value;
		Il2CppCodeGenWriteBarrier(&___mContext_1, value);
	}

	inline static int32_t get_offset_of_mBuf_2() { return static_cast<int32_t>(offsetof(DeferredHash_t1571847761, ___mBuf_2)); }
	inline DigestInputBuffer_t3911248312 * get_mBuf_2() const { return ___mBuf_2; }
	inline DigestInputBuffer_t3911248312 ** get_address_of_mBuf_2() { return &___mBuf_2; }
	inline void set_mBuf_2(DigestInputBuffer_t3911248312 * value)
	{
		___mBuf_2 = value;
		Il2CppCodeGenWriteBarrier(&___mBuf_2, value);
	}

	inline static int32_t get_offset_of_mHashes_3() { return static_cast<int32_t>(offsetof(DeferredHash_t1571847761, ___mHashes_3)); }
	inline Il2CppObject * get_mHashes_3() const { return ___mHashes_3; }
	inline Il2CppObject ** get_address_of_mHashes_3() { return &___mHashes_3; }
	inline void set_mHashes_3(Il2CppObject * value)
	{
		___mHashes_3 = value;
		Il2CppCodeGenWriteBarrier(&___mHashes_3, value);
	}

	inline static int32_t get_offset_of_mPrfHashAlgorithm_4() { return static_cast<int32_t>(offsetof(DeferredHash_t1571847761, ___mPrfHashAlgorithm_4)); }
	inline int32_t get_mPrfHashAlgorithm_4() const { return ___mPrfHashAlgorithm_4; }
	inline int32_t* get_address_of_mPrfHashAlgorithm_4() { return &___mPrfHashAlgorithm_4; }
	inline void set_mPrfHashAlgorithm_4(int32_t value)
	{
		___mPrfHashAlgorithm_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
