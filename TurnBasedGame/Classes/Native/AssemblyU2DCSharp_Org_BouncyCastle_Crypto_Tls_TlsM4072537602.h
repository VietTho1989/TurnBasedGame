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
// Org.BouncyCastle.Crypto.IMac
struct IMac_t2321756708;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.TlsMac
struct  TlsMac_t4072537602  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsContext Org.BouncyCastle.Crypto.Tls.TlsMac::context
	Il2CppObject * ___context_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.TlsMac::secret
	ByteU5BU5D_t3397334013* ___secret_1;
	// Org.BouncyCastle.Crypto.IMac Org.BouncyCastle.Crypto.Tls.TlsMac::mac
	Il2CppObject * ___mac_2;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.TlsMac::digestBlockSize
	int32_t ___digestBlockSize_3;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.TlsMac::digestOverhead
	int32_t ___digestOverhead_4;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.TlsMac::macLength
	int32_t ___macLength_5;

public:
	inline static int32_t get_offset_of_context_0() { return static_cast<int32_t>(offsetof(TlsMac_t4072537602, ___context_0)); }
	inline Il2CppObject * get_context_0() const { return ___context_0; }
	inline Il2CppObject ** get_address_of_context_0() { return &___context_0; }
	inline void set_context_0(Il2CppObject * value)
	{
		___context_0 = value;
		Il2CppCodeGenWriteBarrier(&___context_0, value);
	}

	inline static int32_t get_offset_of_secret_1() { return static_cast<int32_t>(offsetof(TlsMac_t4072537602, ___secret_1)); }
	inline ByteU5BU5D_t3397334013* get_secret_1() const { return ___secret_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_secret_1() { return &___secret_1; }
	inline void set_secret_1(ByteU5BU5D_t3397334013* value)
	{
		___secret_1 = value;
		Il2CppCodeGenWriteBarrier(&___secret_1, value);
	}

	inline static int32_t get_offset_of_mac_2() { return static_cast<int32_t>(offsetof(TlsMac_t4072537602, ___mac_2)); }
	inline Il2CppObject * get_mac_2() const { return ___mac_2; }
	inline Il2CppObject ** get_address_of_mac_2() { return &___mac_2; }
	inline void set_mac_2(Il2CppObject * value)
	{
		___mac_2 = value;
		Il2CppCodeGenWriteBarrier(&___mac_2, value);
	}

	inline static int32_t get_offset_of_digestBlockSize_3() { return static_cast<int32_t>(offsetof(TlsMac_t4072537602, ___digestBlockSize_3)); }
	inline int32_t get_digestBlockSize_3() const { return ___digestBlockSize_3; }
	inline int32_t* get_address_of_digestBlockSize_3() { return &___digestBlockSize_3; }
	inline void set_digestBlockSize_3(int32_t value)
	{
		___digestBlockSize_3 = value;
	}

	inline static int32_t get_offset_of_digestOverhead_4() { return static_cast<int32_t>(offsetof(TlsMac_t4072537602, ___digestOverhead_4)); }
	inline int32_t get_digestOverhead_4() const { return ___digestOverhead_4; }
	inline int32_t* get_address_of_digestOverhead_4() { return &___digestOverhead_4; }
	inline void set_digestOverhead_4(int32_t value)
	{
		___digestOverhead_4 = value;
	}

	inline static int32_t get_offset_of_macLength_5() { return static_cast<int32_t>(offsetof(TlsMac_t4072537602, ___macLength_5)); }
	inline int32_t get_macLength_5() const { return ___macLength_5; }
	inline int32_t* get_address_of_macLength_5() { return &___macLength_5; }
	inline void set_macLength_5(int32_t value)
	{
		___macLength_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
