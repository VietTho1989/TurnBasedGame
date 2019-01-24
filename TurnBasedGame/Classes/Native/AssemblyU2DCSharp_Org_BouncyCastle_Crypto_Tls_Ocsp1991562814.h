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
// Org.BouncyCastle.Asn1.X509.X509Extensions
struct X509Extensions_t1384530060;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.OcspStatusRequest
struct  OcspStatusRequest_t1991562814  : public Il2CppObject
{
public:
	// System.Collections.IList Org.BouncyCastle.Crypto.Tls.OcspStatusRequest::mResponderIDList
	Il2CppObject * ___mResponderIDList_0;
	// Org.BouncyCastle.Asn1.X509.X509Extensions Org.BouncyCastle.Crypto.Tls.OcspStatusRequest::mRequestExtensions
	X509Extensions_t1384530060 * ___mRequestExtensions_1;

public:
	inline static int32_t get_offset_of_mResponderIDList_0() { return static_cast<int32_t>(offsetof(OcspStatusRequest_t1991562814, ___mResponderIDList_0)); }
	inline Il2CppObject * get_mResponderIDList_0() const { return ___mResponderIDList_0; }
	inline Il2CppObject ** get_address_of_mResponderIDList_0() { return &___mResponderIDList_0; }
	inline void set_mResponderIDList_0(Il2CppObject * value)
	{
		___mResponderIDList_0 = value;
		Il2CppCodeGenWriteBarrier(&___mResponderIDList_0, value);
	}

	inline static int32_t get_offset_of_mRequestExtensions_1() { return static_cast<int32_t>(offsetof(OcspStatusRequest_t1991562814, ___mRequestExtensions_1)); }
	inline X509Extensions_t1384530060 * get_mRequestExtensions_1() const { return ___mRequestExtensions_1; }
	inline X509Extensions_t1384530060 ** get_address_of_mRequestExtensions_1() { return &___mRequestExtensions_1; }
	inline void set_mRequestExtensions_1(X509Extensions_t1384530060 * value)
	{
		___mRequestExtensions_1 = value;
		Il2CppCodeGenWriteBarrier(&___mRequestExtensions_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
