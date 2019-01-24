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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.AbstractTlsSigner
struct  AbstractTlsSigner_t463031607  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.AbstractTlsSigner::mContext
	Il2CppObject * ___mContext_0;

public:
	inline static int32_t get_offset_of_mContext_0() { return static_cast<int32_t>(offsetof(AbstractTlsSigner_t463031607, ___mContext_0)); }
	inline Il2CppObject * get_mContext_0() const { return ___mContext_0; }
	inline Il2CppObject ** get_address_of_mContext_0() { return &___mContext_0; }
	inline void set_mContext_0(Il2CppObject * value)
	{
		___mContext_0 = value;
		Il2CppCodeGenWriteBarrier(&___mContext_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
