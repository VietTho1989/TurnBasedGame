#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Modes.CbcBlockCipher
struct CbcBlockCipher_t424533760;
// Org.BouncyCastle.Crypto.ICipherParameters
struct ICipherParameters_t3082042576;
// Org.BouncyCastle.Crypto.Parameters.ParametersWithIV
struct ParametersWithIV_t2760900877;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.RC2WrapEngine
struct  RC2WrapEngine_t276302965  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Modes.CbcBlockCipher Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::engine
	CbcBlockCipher_t424533760 * ___engine_0;
	// Org.BouncyCastle.Crypto.ICipherParameters Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::parameters
	Il2CppObject * ___parameters_1;
	// Org.BouncyCastle.Crypto.Parameters.ParametersWithIV Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::paramPlusIV
	ParametersWithIV_t2760900877 * ___paramPlusIV_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::iv
	ByteU5BU5D_t3397334013* ___iv_3;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::forWrapping
	bool ___forWrapping_4;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::sr
	SecureRandom_t3117234712 * ___sr_5;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::sha1
	Il2CppObject * ___sha1_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::digest
	ByteU5BU5D_t3397334013* ___digest_8;

public:
	inline static int32_t get_offset_of_engine_0() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___engine_0)); }
	inline CbcBlockCipher_t424533760 * get_engine_0() const { return ___engine_0; }
	inline CbcBlockCipher_t424533760 ** get_address_of_engine_0() { return &___engine_0; }
	inline void set_engine_0(CbcBlockCipher_t424533760 * value)
	{
		___engine_0 = value;
		Il2CppCodeGenWriteBarrier(&___engine_0, value);
	}

	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___parameters_1)); }
	inline Il2CppObject * get_parameters_1() const { return ___parameters_1; }
	inline Il2CppObject ** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(Il2CppObject * value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}

	inline static int32_t get_offset_of_paramPlusIV_2() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___paramPlusIV_2)); }
	inline ParametersWithIV_t2760900877 * get_paramPlusIV_2() const { return ___paramPlusIV_2; }
	inline ParametersWithIV_t2760900877 ** get_address_of_paramPlusIV_2() { return &___paramPlusIV_2; }
	inline void set_paramPlusIV_2(ParametersWithIV_t2760900877 * value)
	{
		___paramPlusIV_2 = value;
		Il2CppCodeGenWriteBarrier(&___paramPlusIV_2, value);
	}

	inline static int32_t get_offset_of_iv_3() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___iv_3)); }
	inline ByteU5BU5D_t3397334013* get_iv_3() const { return ___iv_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_iv_3() { return &___iv_3; }
	inline void set_iv_3(ByteU5BU5D_t3397334013* value)
	{
		___iv_3 = value;
		Il2CppCodeGenWriteBarrier(&___iv_3, value);
	}

	inline static int32_t get_offset_of_forWrapping_4() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___forWrapping_4)); }
	inline bool get_forWrapping_4() const { return ___forWrapping_4; }
	inline bool* get_address_of_forWrapping_4() { return &___forWrapping_4; }
	inline void set_forWrapping_4(bool value)
	{
		___forWrapping_4 = value;
	}

	inline static int32_t get_offset_of_sr_5() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___sr_5)); }
	inline SecureRandom_t3117234712 * get_sr_5() const { return ___sr_5; }
	inline SecureRandom_t3117234712 ** get_address_of_sr_5() { return &___sr_5; }
	inline void set_sr_5(SecureRandom_t3117234712 * value)
	{
		___sr_5 = value;
		Il2CppCodeGenWriteBarrier(&___sr_5, value);
	}

	inline static int32_t get_offset_of_sha1_7() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___sha1_7)); }
	inline Il2CppObject * get_sha1_7() const { return ___sha1_7; }
	inline Il2CppObject ** get_address_of_sha1_7() { return &___sha1_7; }
	inline void set_sha1_7(Il2CppObject * value)
	{
		___sha1_7 = value;
		Il2CppCodeGenWriteBarrier(&___sha1_7, value);
	}

	inline static int32_t get_offset_of_digest_8() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965, ___digest_8)); }
	inline ByteU5BU5D_t3397334013* get_digest_8() const { return ___digest_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_digest_8() { return &___digest_8; }
	inline void set_digest_8(ByteU5BU5D_t3397334013* value)
	{
		___digest_8 = value;
		Il2CppCodeGenWriteBarrier(&___digest_8, value);
	}
};

struct RC2WrapEngine_t276302965_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RC2WrapEngine::IV2
	ByteU5BU5D_t3397334013* ___IV2_6;

public:
	inline static int32_t get_offset_of_IV2_6() { return static_cast<int32_t>(offsetof(RC2WrapEngine_t276302965_StaticFields, ___IV2_6)); }
	inline ByteU5BU5D_t3397334013* get_IV2_6() const { return ___IV2_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV2_6() { return &___IV2_6; }
	inline void set_IV2_6(ByteU5BU5D_t3397334013* value)
	{
		___IV2_6 = value;
		Il2CppCodeGenWriteBarrier(&___IV2_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
