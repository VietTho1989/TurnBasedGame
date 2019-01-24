#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IList
struct IList_t3321498491;
// Org.BouncyCastle.Crypto.Tls.TlsContext
struct TlsContext_t4077776538;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.AbstractTlsKeyExchange
struct  AbstractTlsKeyExchange_t3351798479  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Tls.AbstractTlsKeyExchange::mKeyExchange
	int32_t ___mKeyExchange_0;
	// System.Collections.IList Org.BouncyCastle.Crypto.Tls.AbstractTlsKeyExchange::mSupportedSignatureAlgorithms
	Il2CppObject * ___mSupportedSignatureAlgorithms_1;
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.AbstractTlsKeyExchange::mContext
	Il2CppObject * ___mContext_2;

public:
	inline static int32_t get_offset_of_mKeyExchange_0() { return static_cast<int32_t>(offsetof(AbstractTlsKeyExchange_t3351798479, ___mKeyExchange_0)); }
	inline int32_t get_mKeyExchange_0() const { return ___mKeyExchange_0; }
	inline int32_t* get_address_of_mKeyExchange_0() { return &___mKeyExchange_0; }
	inline void set_mKeyExchange_0(int32_t value)
	{
		___mKeyExchange_0 = value;
	}

	inline static int32_t get_offset_of_mSupportedSignatureAlgorithms_1() { return static_cast<int32_t>(offsetof(AbstractTlsKeyExchange_t3351798479, ___mSupportedSignatureAlgorithms_1)); }
	inline Il2CppObject * get_mSupportedSignatureAlgorithms_1() const { return ___mSupportedSignatureAlgorithms_1; }
	inline Il2CppObject ** get_address_of_mSupportedSignatureAlgorithms_1() { return &___mSupportedSignatureAlgorithms_1; }
	inline void set_mSupportedSignatureAlgorithms_1(Il2CppObject * value)
	{
		___mSupportedSignatureAlgorithms_1 = value;
		Il2CppCodeGenWriteBarrier(&___mSupportedSignatureAlgorithms_1, value);
	}

	inline static int32_t get_offset_of_mContext_2() { return static_cast<int32_t>(offsetof(AbstractTlsKeyExchange_t3351798479, ___mContext_2)); }
	inline Il2CppObject * get_mContext_2() const { return ___mContext_2; }
	inline Il2CppObject ** get_address_of_mContext_2() { return &___mContext_2; }
	inline void set_mContext_2(Il2CppObject * value)
	{
		___mContext_2 = value;
		Il2CppCodeGenWriteBarrier(&___mContext_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
