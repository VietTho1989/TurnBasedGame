#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.Ssl3Mac
struct  Ssl3Mac_t1535524432  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Tls.Ssl3Mac::digest
	Il2CppObject * ___digest_4;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.Ssl3Mac::padLength
	int32_t ___padLength_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.Ssl3Mac::secret
	ByteU5BU5D_t3397334013* ___secret_6;

public:
	inline static int32_t get_offset_of_digest_4() { return static_cast<int32_t>(offsetof(Ssl3Mac_t1535524432, ___digest_4)); }
	inline Il2CppObject * get_digest_4() const { return ___digest_4; }
	inline Il2CppObject ** get_address_of_digest_4() { return &___digest_4; }
	inline void set_digest_4(Il2CppObject * value)
	{
		___digest_4 = value;
		Il2CppCodeGenWriteBarrier(&___digest_4, value);
	}

	inline static int32_t get_offset_of_padLength_5() { return static_cast<int32_t>(offsetof(Ssl3Mac_t1535524432, ___padLength_5)); }
	inline int32_t get_padLength_5() const { return ___padLength_5; }
	inline int32_t* get_address_of_padLength_5() { return &___padLength_5; }
	inline void set_padLength_5(int32_t value)
	{
		___padLength_5 = value;
	}

	inline static int32_t get_offset_of_secret_6() { return static_cast<int32_t>(offsetof(Ssl3Mac_t1535524432, ___secret_6)); }
	inline ByteU5BU5D_t3397334013* get_secret_6() const { return ___secret_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_secret_6() { return &___secret_6; }
	inline void set_secret_6(ByteU5BU5D_t3397334013* value)
	{
		___secret_6 = value;
		Il2CppCodeGenWriteBarrier(&___secret_6, value);
	}
};

struct Ssl3Mac_t1535524432_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.Ssl3Mac::IPAD
	ByteU5BU5D_t3397334013* ___IPAD_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.Ssl3Mac::OPAD
	ByteU5BU5D_t3397334013* ___OPAD_3;

public:
	inline static int32_t get_offset_of_IPAD_2() { return static_cast<int32_t>(offsetof(Ssl3Mac_t1535524432_StaticFields, ___IPAD_2)); }
	inline ByteU5BU5D_t3397334013* get_IPAD_2() const { return ___IPAD_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_IPAD_2() { return &___IPAD_2; }
	inline void set_IPAD_2(ByteU5BU5D_t3397334013* value)
	{
		___IPAD_2 = value;
		Il2CppCodeGenWriteBarrier(&___IPAD_2, value);
	}

	inline static int32_t get_offset_of_OPAD_3() { return static_cast<int32_t>(offsetof(Ssl3Mac_t1535524432_StaticFields, ___OPAD_3)); }
	inline ByteU5BU5D_t3397334013* get_OPAD_3() const { return ___OPAD_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_OPAD_3() { return &___OPAD_3; }
	inline void set_OPAD_3(ByteU5BU5D_t3397334013* value)
	{
		___OPAD_3 = value;
		Il2CppCodeGenWriteBarrier(&___OPAD_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
