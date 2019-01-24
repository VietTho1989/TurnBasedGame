#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.CertificateStatusRequest
struct  CertificateStatusRequest_t2118695048  : public Il2CppObject
{
public:
	// System.Byte Org.BouncyCastle.Crypto.Tls.CertificateStatusRequest::mStatusType
	uint8_t ___mStatusType_0;
	// System.Object Org.BouncyCastle.Crypto.Tls.CertificateStatusRequest::mRequest
	Il2CppObject * ___mRequest_1;

public:
	inline static int32_t get_offset_of_mStatusType_0() { return static_cast<int32_t>(offsetof(CertificateStatusRequest_t2118695048, ___mStatusType_0)); }
	inline uint8_t get_mStatusType_0() const { return ___mStatusType_0; }
	inline uint8_t* get_address_of_mStatusType_0() { return &___mStatusType_0; }
	inline void set_mStatusType_0(uint8_t value)
	{
		___mStatusType_0 = value;
	}

	inline static int32_t get_offset_of_mRequest_1() { return static_cast<int32_t>(offsetof(CertificateStatusRequest_t2118695048, ___mRequest_1)); }
	inline Il2CppObject * get_mRequest_1() const { return ___mRequest_1; }
	inline Il2CppObject ** get_address_of_mRequest_1() { return &___mRequest_1; }
	inline void set_mRequest_1(Il2CppObject * value)
	{
		___mRequest_1 = value;
		Il2CppCodeGenWriteBarrier(&___mRequest_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
