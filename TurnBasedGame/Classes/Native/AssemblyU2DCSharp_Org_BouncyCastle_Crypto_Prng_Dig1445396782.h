#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Prng.DigestRandomGenerator
struct  DigestRandomGenerator_t1445396782  : public Il2CppObject
{
public:
	// System.Int64 Org.BouncyCastle.Crypto.Prng.DigestRandomGenerator::stateCounter
	int64_t ___stateCounter_1;
	// System.Int64 Org.BouncyCastle.Crypto.Prng.DigestRandomGenerator::seedCounter
	int64_t ___seedCounter_2;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Prng.DigestRandomGenerator::digest
	Il2CppObject * ___digest_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Prng.DigestRandomGenerator::state
	ByteU5BU5D_t3397334013* ___state_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Prng.DigestRandomGenerator::seed
	ByteU5BU5D_t3397334013* ___seed_5;

public:
	inline static int32_t get_offset_of_stateCounter_1() { return static_cast<int32_t>(offsetof(DigestRandomGenerator_t1445396782, ___stateCounter_1)); }
	inline int64_t get_stateCounter_1() const { return ___stateCounter_1; }
	inline int64_t* get_address_of_stateCounter_1() { return &___stateCounter_1; }
	inline void set_stateCounter_1(int64_t value)
	{
		___stateCounter_1 = value;
	}

	inline static int32_t get_offset_of_seedCounter_2() { return static_cast<int32_t>(offsetof(DigestRandomGenerator_t1445396782, ___seedCounter_2)); }
	inline int64_t get_seedCounter_2() const { return ___seedCounter_2; }
	inline int64_t* get_address_of_seedCounter_2() { return &___seedCounter_2; }
	inline void set_seedCounter_2(int64_t value)
	{
		___seedCounter_2 = value;
	}

	inline static int32_t get_offset_of_digest_3() { return static_cast<int32_t>(offsetof(DigestRandomGenerator_t1445396782, ___digest_3)); }
	inline Il2CppObject * get_digest_3() const { return ___digest_3; }
	inline Il2CppObject ** get_address_of_digest_3() { return &___digest_3; }
	inline void set_digest_3(Il2CppObject * value)
	{
		___digest_3 = value;
		Il2CppCodeGenWriteBarrier(&___digest_3, value);
	}

	inline static int32_t get_offset_of_state_4() { return static_cast<int32_t>(offsetof(DigestRandomGenerator_t1445396782, ___state_4)); }
	inline ByteU5BU5D_t3397334013* get_state_4() const { return ___state_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_state_4() { return &___state_4; }
	inline void set_state_4(ByteU5BU5D_t3397334013* value)
	{
		___state_4 = value;
		Il2CppCodeGenWriteBarrier(&___state_4, value);
	}

	inline static int32_t get_offset_of_seed_5() { return static_cast<int32_t>(offsetof(DigestRandomGenerator_t1445396782, ___seed_5)); }
	inline ByteU5BU5D_t3397334013* get_seed_5() const { return ___seed_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_seed_5() { return &___seed_5; }
	inline void set_seed_5(ByteU5BU5D_t3397334013* value)
	{
		___seed_5 = value;
		Il2CppCodeGenWriteBarrier(&___seed_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
