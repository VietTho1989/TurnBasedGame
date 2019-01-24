#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Utilities_IO_Base91853118.h"

// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.DigestInputBuffer/DigStream
struct  DigStream_t2878944447  : public BaseOutputStream_t91853118
{
public:
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Tls.DigestInputBuffer/DigStream::d
	Il2CppObject * ___d_3;

public:
	inline static int32_t get_offset_of_d_3() { return static_cast<int32_t>(offsetof(DigStream_t2878944447, ___d_3)); }
	inline Il2CppObject * get_d_3() const { return ___d_3; }
	inline Il2CppObject ** get_address_of_d_3() { return &___d_3; }
	inline void set_d_3(Il2CppObject * value)
	{
		___d_3 = value;
		Il2CppCodeGenWriteBarrier(&___d_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
