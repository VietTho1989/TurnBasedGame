#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Uri
struct Uri_t19570940;
// BestHTTP.Authentication.Credentials
struct Credentials_t3762395084;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.HTTPProxy
struct  HTTPProxy_t2644053826  : public Il2CppObject
{
public:
	// System.Uri BestHTTP.HTTPProxy::<Address>k__BackingField
	Uri_t19570940 * ___U3CAddressU3Ek__BackingField_0;
	// BestHTTP.Authentication.Credentials BestHTTP.HTTPProxy::<Credentials>k__BackingField
	Credentials_t3762395084 * ___U3CCredentialsU3Ek__BackingField_1;
	// System.Boolean BestHTTP.HTTPProxy::<IsTransparent>k__BackingField
	bool ___U3CIsTransparentU3Ek__BackingField_2;
	// System.Boolean BestHTTP.HTTPProxy::<SendWholeUri>k__BackingField
	bool ___U3CSendWholeUriU3Ek__BackingField_3;
	// System.Boolean BestHTTP.HTTPProxy::<NonTransparentForHTTPS>k__BackingField
	bool ___U3CNonTransparentForHTTPSU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_U3CAddressU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(HTTPProxy_t2644053826, ___U3CAddressU3Ek__BackingField_0)); }
	inline Uri_t19570940 * get_U3CAddressU3Ek__BackingField_0() const { return ___U3CAddressU3Ek__BackingField_0; }
	inline Uri_t19570940 ** get_address_of_U3CAddressU3Ek__BackingField_0() { return &___U3CAddressU3Ek__BackingField_0; }
	inline void set_U3CAddressU3Ek__BackingField_0(Uri_t19570940 * value)
	{
		___U3CAddressU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAddressU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CCredentialsU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(HTTPProxy_t2644053826, ___U3CCredentialsU3Ek__BackingField_1)); }
	inline Credentials_t3762395084 * get_U3CCredentialsU3Ek__BackingField_1() const { return ___U3CCredentialsU3Ek__BackingField_1; }
	inline Credentials_t3762395084 ** get_address_of_U3CCredentialsU3Ek__BackingField_1() { return &___U3CCredentialsU3Ek__BackingField_1; }
	inline void set_U3CCredentialsU3Ek__BackingField_1(Credentials_t3762395084 * value)
	{
		___U3CCredentialsU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCredentialsU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CIsTransparentU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(HTTPProxy_t2644053826, ___U3CIsTransparentU3Ek__BackingField_2)); }
	inline bool get_U3CIsTransparentU3Ek__BackingField_2() const { return ___U3CIsTransparentU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CIsTransparentU3Ek__BackingField_2() { return &___U3CIsTransparentU3Ek__BackingField_2; }
	inline void set_U3CIsTransparentU3Ek__BackingField_2(bool value)
	{
		___U3CIsTransparentU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CSendWholeUriU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(HTTPProxy_t2644053826, ___U3CSendWholeUriU3Ek__BackingField_3)); }
	inline bool get_U3CSendWholeUriU3Ek__BackingField_3() const { return ___U3CSendWholeUriU3Ek__BackingField_3; }
	inline bool* get_address_of_U3CSendWholeUriU3Ek__BackingField_3() { return &___U3CSendWholeUriU3Ek__BackingField_3; }
	inline void set_U3CSendWholeUriU3Ek__BackingField_3(bool value)
	{
		___U3CSendWholeUriU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CNonTransparentForHTTPSU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(HTTPProxy_t2644053826, ___U3CNonTransparentForHTTPSU3Ek__BackingField_4)); }
	inline bool get_U3CNonTransparentForHTTPSU3Ek__BackingField_4() const { return ___U3CNonTransparentForHTTPSU3Ek__BackingField_4; }
	inline bool* get_address_of_U3CNonTransparentForHTTPSU3Ek__BackingField_4() { return &___U3CNonTransparentForHTTPSU3Ek__BackingField_4; }
	inline void set_U3CNonTransparentForHTTPSU3Ek__BackingField_4(bool value)
	{
		___U3CNonTransparentForHTTPSU3Ek__BackingField_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
