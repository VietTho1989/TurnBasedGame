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
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.CombinedHash
struct  CombinedHash_t1177273743  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.CombinedHash::mContext
	Il2CppObject * ___mContext_0;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Tls.CombinedHash::mMd5
	Il2CppObject * ___mMd5_1;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Tls.CombinedHash::mSha1
	Il2CppObject * ___mSha1_2;

public:
	inline static int32_t get_offset_of_mContext_0() { return static_cast<int32_t>(offsetof(CombinedHash_t1177273743, ___mContext_0)); }
	inline Il2CppObject * get_mContext_0() const { return ___mContext_0; }
	inline Il2CppObject ** get_address_of_mContext_0() { return &___mContext_0; }
	inline void set_mContext_0(Il2CppObject * value)
	{
		___mContext_0 = value;
		Il2CppCodeGenWriteBarrier(&___mContext_0, value);
	}

	inline static int32_t get_offset_of_mMd5_1() { return static_cast<int32_t>(offsetof(CombinedHash_t1177273743, ___mMd5_1)); }
	inline Il2CppObject * get_mMd5_1() const { return ___mMd5_1; }
	inline Il2CppObject ** get_address_of_mMd5_1() { return &___mMd5_1; }
	inline void set_mMd5_1(Il2CppObject * value)
	{
		___mMd5_1 = value;
		Il2CppCodeGenWriteBarrier(&___mMd5_1, value);
	}

	inline static int32_t get_offset_of_mSha1_2() { return static_cast<int32_t>(offsetof(CombinedHash_t1177273743, ___mSha1_2)); }
	inline Il2CppObject * get_mSha1_2() const { return ___mSha1_2; }
	inline Il2CppObject ** get_address_of_mSha1_2() { return &___mSha1_2; }
	inline void set_mSha1_2(Il2CppObject * value)
	{
		___mSha1_2 = value;
		Il2CppCodeGenWriteBarrier(&___mSha1_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
