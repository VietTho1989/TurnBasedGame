#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Prng.IRandomGenerator
struct IRandomGenerator_t860704147;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;
// Org.BouncyCastle.Crypto.Tls.SecurityParameters
struct SecurityParameters_t3985528004;
// Org.BouncyCastle.Crypto.Tls.ProtocolVersion
struct ProtocolVersion_t3273908466;
// Org.BouncyCastle.Crypto.Tls.TlsSession
struct TlsSession_t3695793821;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.AbstractTlsContext
struct  AbstractTlsContext_t1662285836  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Prng.IRandomGenerator Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::mNonceRandom
	Il2CppObject * ___mNonceRandom_1;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::mSecureRandom
	SecureRandom_t3117234712 * ___mSecureRandom_2;
	// Org.BouncyCastle.Crypto.Tls.SecurityParameters Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::mSecurityParameters
	SecurityParameters_t3985528004 * ___mSecurityParameters_3;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::mClientVersion
	ProtocolVersion_t3273908466 * ___mClientVersion_4;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::mServerVersion
	ProtocolVersion_t3273908466 * ___mServerVersion_5;
	// Org.BouncyCastle.Crypto.Tls.TlsSession Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::mSession
	Il2CppObject * ___mSession_6;
	// System.Object Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::mUserObject
	Il2CppObject * ___mUserObject_7;

public:
	inline static int32_t get_offset_of_mNonceRandom_1() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836, ___mNonceRandom_1)); }
	inline Il2CppObject * get_mNonceRandom_1() const { return ___mNonceRandom_1; }
	inline Il2CppObject ** get_address_of_mNonceRandom_1() { return &___mNonceRandom_1; }
	inline void set_mNonceRandom_1(Il2CppObject * value)
	{
		___mNonceRandom_1 = value;
		Il2CppCodeGenWriteBarrier(&___mNonceRandom_1, value);
	}

	inline static int32_t get_offset_of_mSecureRandom_2() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836, ___mSecureRandom_2)); }
	inline SecureRandom_t3117234712 * get_mSecureRandom_2() const { return ___mSecureRandom_2; }
	inline SecureRandom_t3117234712 ** get_address_of_mSecureRandom_2() { return &___mSecureRandom_2; }
	inline void set_mSecureRandom_2(SecureRandom_t3117234712 * value)
	{
		___mSecureRandom_2 = value;
		Il2CppCodeGenWriteBarrier(&___mSecureRandom_2, value);
	}

	inline static int32_t get_offset_of_mSecurityParameters_3() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836, ___mSecurityParameters_3)); }
	inline SecurityParameters_t3985528004 * get_mSecurityParameters_3() const { return ___mSecurityParameters_3; }
	inline SecurityParameters_t3985528004 ** get_address_of_mSecurityParameters_3() { return &___mSecurityParameters_3; }
	inline void set_mSecurityParameters_3(SecurityParameters_t3985528004 * value)
	{
		___mSecurityParameters_3 = value;
		Il2CppCodeGenWriteBarrier(&___mSecurityParameters_3, value);
	}

	inline static int32_t get_offset_of_mClientVersion_4() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836, ___mClientVersion_4)); }
	inline ProtocolVersion_t3273908466 * get_mClientVersion_4() const { return ___mClientVersion_4; }
	inline ProtocolVersion_t3273908466 ** get_address_of_mClientVersion_4() { return &___mClientVersion_4; }
	inline void set_mClientVersion_4(ProtocolVersion_t3273908466 * value)
	{
		___mClientVersion_4 = value;
		Il2CppCodeGenWriteBarrier(&___mClientVersion_4, value);
	}

	inline static int32_t get_offset_of_mServerVersion_5() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836, ___mServerVersion_5)); }
	inline ProtocolVersion_t3273908466 * get_mServerVersion_5() const { return ___mServerVersion_5; }
	inline ProtocolVersion_t3273908466 ** get_address_of_mServerVersion_5() { return &___mServerVersion_5; }
	inline void set_mServerVersion_5(ProtocolVersion_t3273908466 * value)
	{
		___mServerVersion_5 = value;
		Il2CppCodeGenWriteBarrier(&___mServerVersion_5, value);
	}

	inline static int32_t get_offset_of_mSession_6() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836, ___mSession_6)); }
	inline Il2CppObject * get_mSession_6() const { return ___mSession_6; }
	inline Il2CppObject ** get_address_of_mSession_6() { return &___mSession_6; }
	inline void set_mSession_6(Il2CppObject * value)
	{
		___mSession_6 = value;
		Il2CppCodeGenWriteBarrier(&___mSession_6, value);
	}

	inline static int32_t get_offset_of_mUserObject_7() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836, ___mUserObject_7)); }
	inline Il2CppObject * get_mUserObject_7() const { return ___mUserObject_7; }
	inline Il2CppObject ** get_address_of_mUserObject_7() { return &___mUserObject_7; }
	inline void set_mUserObject_7(Il2CppObject * value)
	{
		___mUserObject_7 = value;
		Il2CppCodeGenWriteBarrier(&___mUserObject_7, value);
	}
};

struct AbstractTlsContext_t1662285836_StaticFields
{
public:
	// System.Int64 Org.BouncyCastle.Crypto.Tls.AbstractTlsContext::counter
	int64_t ___counter_0;

public:
	inline static int32_t get_offset_of_counter_0() { return static_cast<int32_t>(offsetof(AbstractTlsContext_t1662285836_StaticFields, ___counter_0)); }
	inline int64_t get_counter_0() const { return ___counter_0; }
	inline int64_t* get_address_of_counter_0() { return &___counter_0; }
	inline void set_counter_0(int64_t value)
	{
		___counter_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
