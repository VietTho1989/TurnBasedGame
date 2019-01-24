#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Utilities_IO_Base91853118.h"

// Org.BouncyCastle.Crypto.ISigner
struct ISigner_t3640387509;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.SignerInputBuffer/SigStream
struct  SigStream_t2455255744  : public BaseOutputStream_t91853118
{
public:
	// Org.BouncyCastle.Crypto.ISigner Org.BouncyCastle.Crypto.Tls.SignerInputBuffer/SigStream::s
	Il2CppObject * ___s_3;

public:
	inline static int32_t get_offset_of_s_3() { return static_cast<int32_t>(offsetof(SigStream_t2455255744, ___s_3)); }
	inline Il2CppObject * get_s_3() const { return ___s_3; }
	inline Il2CppObject ** get_address_of_s_3() { return &___s_3; }
	inline void set_s_3(Il2CppObject * value)
	{
		___s_3 = value;
		Il2CppCodeGenWriteBarrier(&___s_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
