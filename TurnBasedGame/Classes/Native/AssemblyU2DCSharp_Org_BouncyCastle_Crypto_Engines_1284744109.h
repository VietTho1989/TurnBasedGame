#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.IBasicAgreement
struct IBasicAgreement_t1732109445;
// Org.BouncyCastle.Crypto.IDerivationFunction
struct IDerivationFunction_t1910850828;
// Org.BouncyCastle.Crypto.IMac
struct IMac_t2321756708;
// Org.BouncyCastle.Crypto.BufferedBlockCipher
struct BufferedBlockCipher_t711630611;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.ICipherParameters
struct ICipherParameters_t3082042576;
// Org.BouncyCastle.Crypto.Parameters.IesParameters
struct IesParameters_t4148998567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.IesEngine
struct  IesEngine_t1284744109  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IBasicAgreement Org.BouncyCastle.Crypto.Engines.IesEngine::agree
	Il2CppObject * ___agree_0;
	// Org.BouncyCastle.Crypto.IDerivationFunction Org.BouncyCastle.Crypto.Engines.IesEngine::kdf
	Il2CppObject * ___kdf_1;
	// Org.BouncyCastle.Crypto.IMac Org.BouncyCastle.Crypto.Engines.IesEngine::mac
	Il2CppObject * ___mac_2;
	// Org.BouncyCastle.Crypto.BufferedBlockCipher Org.BouncyCastle.Crypto.Engines.IesEngine::cipher
	BufferedBlockCipher_t711630611 * ___cipher_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.IesEngine::macBuf
	ByteU5BU5D_t3397334013* ___macBuf_4;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.IesEngine::forEncryption
	bool ___forEncryption_5;
	// Org.BouncyCastle.Crypto.ICipherParameters Org.BouncyCastle.Crypto.Engines.IesEngine::privParam
	Il2CppObject * ___privParam_6;
	// Org.BouncyCastle.Crypto.ICipherParameters Org.BouncyCastle.Crypto.Engines.IesEngine::pubParam
	Il2CppObject * ___pubParam_7;
	// Org.BouncyCastle.Crypto.Parameters.IesParameters Org.BouncyCastle.Crypto.Engines.IesEngine::param
	IesParameters_t4148998567 * ___param_8;

public:
	inline static int32_t get_offset_of_agree_0() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___agree_0)); }
	inline Il2CppObject * get_agree_0() const { return ___agree_0; }
	inline Il2CppObject ** get_address_of_agree_0() { return &___agree_0; }
	inline void set_agree_0(Il2CppObject * value)
	{
		___agree_0 = value;
		Il2CppCodeGenWriteBarrier(&___agree_0, value);
	}

	inline static int32_t get_offset_of_kdf_1() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___kdf_1)); }
	inline Il2CppObject * get_kdf_1() const { return ___kdf_1; }
	inline Il2CppObject ** get_address_of_kdf_1() { return &___kdf_1; }
	inline void set_kdf_1(Il2CppObject * value)
	{
		___kdf_1 = value;
		Il2CppCodeGenWriteBarrier(&___kdf_1, value);
	}

	inline static int32_t get_offset_of_mac_2() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___mac_2)); }
	inline Il2CppObject * get_mac_2() const { return ___mac_2; }
	inline Il2CppObject ** get_address_of_mac_2() { return &___mac_2; }
	inline void set_mac_2(Il2CppObject * value)
	{
		___mac_2 = value;
		Il2CppCodeGenWriteBarrier(&___mac_2, value);
	}

	inline static int32_t get_offset_of_cipher_3() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___cipher_3)); }
	inline BufferedBlockCipher_t711630611 * get_cipher_3() const { return ___cipher_3; }
	inline BufferedBlockCipher_t711630611 ** get_address_of_cipher_3() { return &___cipher_3; }
	inline void set_cipher_3(BufferedBlockCipher_t711630611 * value)
	{
		___cipher_3 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_3, value);
	}

	inline static int32_t get_offset_of_macBuf_4() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___macBuf_4)); }
	inline ByteU5BU5D_t3397334013* get_macBuf_4() const { return ___macBuf_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_macBuf_4() { return &___macBuf_4; }
	inline void set_macBuf_4(ByteU5BU5D_t3397334013* value)
	{
		___macBuf_4 = value;
		Il2CppCodeGenWriteBarrier(&___macBuf_4, value);
	}

	inline static int32_t get_offset_of_forEncryption_5() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___forEncryption_5)); }
	inline bool get_forEncryption_5() const { return ___forEncryption_5; }
	inline bool* get_address_of_forEncryption_5() { return &___forEncryption_5; }
	inline void set_forEncryption_5(bool value)
	{
		___forEncryption_5 = value;
	}

	inline static int32_t get_offset_of_privParam_6() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___privParam_6)); }
	inline Il2CppObject * get_privParam_6() const { return ___privParam_6; }
	inline Il2CppObject ** get_address_of_privParam_6() { return &___privParam_6; }
	inline void set_privParam_6(Il2CppObject * value)
	{
		___privParam_6 = value;
		Il2CppCodeGenWriteBarrier(&___privParam_6, value);
	}

	inline static int32_t get_offset_of_pubParam_7() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___pubParam_7)); }
	inline Il2CppObject * get_pubParam_7() const { return ___pubParam_7; }
	inline Il2CppObject ** get_address_of_pubParam_7() { return &___pubParam_7; }
	inline void set_pubParam_7(Il2CppObject * value)
	{
		___pubParam_7 = value;
		Il2CppCodeGenWriteBarrier(&___pubParam_7, value);
	}

	inline static int32_t get_offset_of_param_8() { return static_cast<int32_t>(offsetof(IesEngine_t1284744109, ___param_8)); }
	inline IesParameters_t4148998567 * get_param_8() const { return ___param_8; }
	inline IesParameters_t4148998567 ** get_address_of_param_8() { return &___param_8; }
	inline void set_param_8(IesParameters_t4148998567 * value)
	{
		___param_8 = value;
		Il2CppCodeGenWriteBarrier(&___param_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
