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
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.IBlockCipher
struct IBlockCipher_t916483717;
// Org.BouncyCastle.Crypto.Tls.TlsMac
struct TlsMac_t4072537602;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsBlockCipher
struct  TlsBlockCipher_t317591639  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::context
	Il2CppObject * ___context_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::randomData
	ByteU5BU5D_t3397334013* ___randomData_1;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::useExplicitIV
	bool ___useExplicitIV_2;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::encryptThenMac
	bool ___encryptThenMac_3;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::encryptCipher
	Il2CppObject * ___encryptCipher_4;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::decryptCipher
	Il2CppObject * ___decryptCipher_5;
	// Org.BouncyCastle.Crypto.Tls.TlsMac Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::mWriteMac
	TlsMac_t4072537602 * ___mWriteMac_6;
	// Org.BouncyCastle.Crypto.Tls.TlsMac Org.BouncyCastle.Crypto.Tls.TlsBlockCipher::mReadMac
	TlsMac_t4072537602 * ___mReadMac_7;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___context_0)); }
	inline Il2CppObject * get_context_0() const { return ___context_0; }
	inline Il2CppObject ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(Il2CppObject * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_randomData_1() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___randomData_1)); }
	inline ByteU5BU5D_t3397334013* get_randomData_1() const { return ___randomData_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_randomData_1() { return &___randomData_1; }
	inline void set_randomData_1(ByteU5BU5D_t3397334013* value)
	{
		___randomData_1 = value;
		Il2CppCodeGenWriteBarrier(&___randomData_1, value);
	}

	inline static int32_t get_offset_of_useExplicitIV_2() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___useExplicitIV_2)); }
	inline bool get_useExplicitIV_2() const { return ___useExplicitIV_2; }
	inline bool* get_address_of_useExplicitIV_2() { return &___useExplicitIV_2; }
	inline void set_useExplicitIV_2(bool value)
	{
		___useExplicitIV_2 = value;
	}

	inline static int32_t get_offset_of_encryptThenMac_3() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___encryptThenMac_3)); }
	inline bool get_encryptThenMac_3() const { return ___encryptThenMac_3; }
	inline bool* get_address_of_encryptThenMac_3() { return &___encryptThenMac_3; }
	inline void set_encryptThenMac_3(bool value)
	{
		___encryptThenMac_3 = value;
	}

	inline static int32_t get_offset_of_encryptCipher_4() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___encryptCipher_4)); }
	inline Il2CppObject * get_encryptCipher_4() const { return ___encryptCipher_4; }
	inline Il2CppObject ** get_address_of_encryptCipher_4() { return &___encryptCipher_4; }
	inline void set_encryptCipher_4(Il2CppObject * value)
	{
		___encryptCipher_4 = value;
		Il2CppCodeGenWriteBarrier(&___encryptCipher_4, value);
	}

	inline static int32_t get_offset_of_decryptCipher_5() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___decryptCipher_5)); }
	inline Il2CppObject * get_decryptCipher_5() const { return ___decryptCipher_5; }
	inline Il2CppObject ** get_address_of_decryptCipher_5() { return &___decryptCipher_5; }
	inline void set_decryptCipher_5(Il2CppObject * value)
	{
		___decryptCipher_5 = value;
		Il2CppCodeGenWriteBarrier(&___decryptCipher_5, value);
	}

	inline static int32_t get_offset_of_mWriteMac_6() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___mWriteMac_6)); }
	inline TlsMac_t4072537602 * get_mWriteMac_6() const { return ___mWriteMac_6; }
	inline TlsMac_t4072537602 ** get_address_of_mWriteMac_6() { return &___mWriteMac_6; }
	inline void set_mWriteMac_6(TlsMac_t4072537602 * value)
	{
		___mWriteMac_6 = value;
		Il2CppCodeGenWriteBarrier(&___mWriteMac_6, value);
	}

	inline static int32_t get_offset_of_mReadMac_7() { return static_cast<int32_t>(offsetof(TlsBlockCipher_t317591639, ___mReadMac_7)); }
	inline TlsMac_t4072537602 * get_mReadMac_7() const { return ___mReadMac_7; }
	inline TlsMac_t4072537602 ** get_address_of_mReadMac_7() { return &___mReadMac_7; }
	inline void set_mReadMac_7(TlsMac_t4072537602 * value)
	{
		___mReadMac_7 = value;
		Il2CppCodeGenWriteBarrier(&___mReadMac_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
