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
// Org.BouncyCastle.Crypto.Parameters.KeyParameter
struct KeyParameter_t215653120;
// Org.BouncyCastle.Crypto.Parameters.ParametersWithIV
struct ParametersWithIV_t2760900877;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine
struct  DesEdeWrapEngine_t4248411376  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Modes.CbcBlockCipher Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::engine
	CbcBlockCipher_t424533760 * ___engine_0;
	// Org.BouncyCastle.Crypto.Parameters.KeyParameter Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::param
	KeyParameter_t215653120 * ___param_1;
	// Org.BouncyCastle.Crypto.Parameters.ParametersWithIV Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::paramPlusIV
	ParametersWithIV_t2760900877 * ___paramPlusIV_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::iv
	ByteU5BU5D_t3397334013* ___iv_3;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::forWrapping
	bool ___forWrapping_4;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::sha1
	Il2CppObject * ___sha1_6;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::digest
	ByteU5BU5D_t3397334013* ___digest_7;

public:
	inline static int32_t get_offset_of_engine_0() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376, ___engine_0)); }
	inline CbcBlockCipher_t424533760 * get_engine_0() const { return ___engine_0; }
	inline CbcBlockCipher_t424533760 ** get_address_of_engine_0() { return &___engine_0; }
	inline void set_engine_0(CbcBlockCipher_t424533760 * value)
	{
		___engine_0 = value;
		Il2CppCodeGenWriteBarrier(&___engine_0, value);
	}

	inline static int32_t get_offset_of_param_1() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376, ___param_1)); }
	inline KeyParameter_t215653120 * get_param_1() const { return ___param_1; }
	inline KeyParameter_t215653120 ** get_address_of_param_1() { return &___param_1; }
	inline void set_param_1(KeyParameter_t215653120 * value)
	{
		___param_1 = value;
		Il2CppCodeGenWriteBarrier(&___param_1, value);
	}

	inline static int32_t get_offset_of_paramPlusIV_2() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376, ___paramPlusIV_2)); }
	inline ParametersWithIV_t2760900877 * get_paramPlusIV_2() const { return ___paramPlusIV_2; }
	inline ParametersWithIV_t2760900877 ** get_address_of_paramPlusIV_2() { return &___paramPlusIV_2; }
	inline void set_paramPlusIV_2(ParametersWithIV_t2760900877 * value)
	{
		___paramPlusIV_2 = value;
		Il2CppCodeGenWriteBarrier(&___paramPlusIV_2, value);
	}

	inline static int32_t get_offset_of_iv_3() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376, ___iv_3)); }
	inline ByteU5BU5D_t3397334013* get_iv_3() const { return ___iv_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_iv_3() { return &___iv_3; }
	inline void set_iv_3(ByteU5BU5D_t3397334013* value)
	{
		___iv_3 = value;
		Il2CppCodeGenWriteBarrier(&___iv_3, value);
	}

	inline static int32_t get_offset_of_forWrapping_4() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376, ___forWrapping_4)); }
	inline bool get_forWrapping_4() const { return ___forWrapping_4; }
	inline bool* get_address_of_forWrapping_4() { return &___forWrapping_4; }
	inline void set_forWrapping_4(bool value)
	{
		___forWrapping_4 = value;
	}

	inline static int32_t get_offset_of_sha1_6() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376, ___sha1_6)); }
	inline Il2CppObject * get_sha1_6() const { return ___sha1_6; }
	inline Il2CppObject ** get_address_of_sha1_6() { return &___sha1_6; }
	inline void set_sha1_6(Il2CppObject * value)
	{
		___sha1_6 = value;
		Il2CppCodeGenWriteBarrier(&___sha1_6, value);
	}

	inline static int32_t get_offset_of_digest_7() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376, ___digest_7)); }
	inline ByteU5BU5D_t3397334013* get_digest_7() const { return ___digest_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_digest_7() { return &___digest_7; }
	inline void set_digest_7(ByteU5BU5D_t3397334013* value)
	{
		___digest_7 = value;
		Il2CppCodeGenWriteBarrier(&___digest_7, value);
	}
};

struct DesEdeWrapEngine_t4248411376_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine::IV2
	ByteU5BU5D_t3397334013* ___IV2_5;

public:
	inline static int32_t get_offset_of_IV2_5() { return static_cast<int32_t>(offsetof(DesEdeWrapEngine_t4248411376_StaticFields, ___IV2_5)); }
	inline ByteU5BU5D_t3397334013* get_IV2_5() const { return ___IV2_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV2_5() { return &___IV2_5; }
	inline void set_IV2_5(ByteU5BU5D_t3397334013* value)
	{
		___IV2_5 = value;
		Il2CppCodeGenWriteBarrier(&___IV2_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
