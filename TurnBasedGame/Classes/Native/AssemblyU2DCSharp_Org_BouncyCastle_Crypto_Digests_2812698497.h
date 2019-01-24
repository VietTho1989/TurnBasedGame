#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.UInt64[]
struct UInt64U5BU5D_t1668688775;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Digests.Sha3Digest
struct  Sha3Digest_t2812698497  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::state
	ByteU5BU5D_t3397334013* ___state_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::dataQueue
	ByteU5BU5D_t3397334013* ___dataQueue_3;
	// System.Int32 Org.BouncyCastle.Crypto.Digests.Sha3Digest::rate
	int32_t ___rate_4;
	// System.Int32 Org.BouncyCastle.Crypto.Digests.Sha3Digest::bitsInQueue
	int32_t ___bitsInQueue_5;
	// System.Int32 Org.BouncyCastle.Crypto.Digests.Sha3Digest::fixedOutputLength
	int32_t ___fixedOutputLength_6;
	// System.Boolean Org.BouncyCastle.Crypto.Digests.Sha3Digest::squeezing
	bool ___squeezing_7;
	// System.Int32 Org.BouncyCastle.Crypto.Digests.Sha3Digest::bitsAvailableForSqueezing
	int32_t ___bitsAvailableForSqueezing_8;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::chunk
	ByteU5BU5D_t3397334013* ___chunk_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::oneByte
	ByteU5BU5D_t3397334013* ___oneByte_10;
	// System.UInt64[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::C
	UInt64U5BU5D_t1668688775* ___C_11;
	// System.UInt64[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::tempA
	UInt64U5BU5D_t1668688775* ___tempA_12;
	// System.UInt64[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::chiC
	UInt64U5BU5D_t1668688775* ___chiC_13;

public:
	inline static int32_t get_offset_of_state_2() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___state_2)); }
	inline ByteU5BU5D_t3397334013* get_state_2() const { return ___state_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_state_2() { return &___state_2; }
	inline void set_state_2(ByteU5BU5D_t3397334013* value)
	{
		___state_2 = value;
		Il2CppCodeGenWriteBarrier(&___state_2, value);
	}

	inline static int32_t get_offset_of_dataQueue_3() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___dataQueue_3)); }
	inline ByteU5BU5D_t3397334013* get_dataQueue_3() const { return ___dataQueue_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_dataQueue_3() { return &___dataQueue_3; }
	inline void set_dataQueue_3(ByteU5BU5D_t3397334013* value)
	{
		___dataQueue_3 = value;
		Il2CppCodeGenWriteBarrier(&___dataQueue_3, value);
	}

	inline static int32_t get_offset_of_rate_4() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___rate_4)); }
	inline int32_t get_rate_4() const { return ___rate_4; }
	inline int32_t* get_address_of_rate_4() { return &___rate_4; }
	inline void set_rate_4(int32_t value)
	{
		___rate_4 = value;
	}

	inline static int32_t get_offset_of_bitsInQueue_5() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___bitsInQueue_5)); }
	inline int32_t get_bitsInQueue_5() const { return ___bitsInQueue_5; }
	inline int32_t* get_address_of_bitsInQueue_5() { return &___bitsInQueue_5; }
	inline void set_bitsInQueue_5(int32_t value)
	{
		___bitsInQueue_5 = value;
	}

	inline static int32_t get_offset_of_fixedOutputLength_6() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___fixedOutputLength_6)); }
	inline int32_t get_fixedOutputLength_6() const { return ___fixedOutputLength_6; }
	inline int32_t* get_address_of_fixedOutputLength_6() { return &___fixedOutputLength_6; }
	inline void set_fixedOutputLength_6(int32_t value)
	{
		___fixedOutputLength_6 = value;
	}

	inline static int32_t get_offset_of_squeezing_7() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___squeezing_7)); }
	inline bool get_squeezing_7() const { return ___squeezing_7; }
	inline bool* get_address_of_squeezing_7() { return &___squeezing_7; }
	inline void set_squeezing_7(bool value)
	{
		___squeezing_7 = value;
	}

	inline static int32_t get_offset_of_bitsAvailableForSqueezing_8() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___bitsAvailableForSqueezing_8)); }
	inline int32_t get_bitsAvailableForSqueezing_8() const { return ___bitsAvailableForSqueezing_8; }
	inline int32_t* get_address_of_bitsAvailableForSqueezing_8() { return &___bitsAvailableForSqueezing_8; }
	inline void set_bitsAvailableForSqueezing_8(int32_t value)
	{
		___bitsAvailableForSqueezing_8 = value;
	}

	inline static int32_t get_offset_of_chunk_9() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___chunk_9)); }
	inline ByteU5BU5D_t3397334013* get_chunk_9() const { return ___chunk_9; }
	inline ByteU5BU5D_t3397334013** get_address_of_chunk_9() { return &___chunk_9; }
	inline void set_chunk_9(ByteU5BU5D_t3397334013* value)
	{
		___chunk_9 = value;
		Il2CppCodeGenWriteBarrier(&___chunk_9, value);
	}

	inline static int32_t get_offset_of_oneByte_10() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___oneByte_10)); }
	inline ByteU5BU5D_t3397334013* get_oneByte_10() const { return ___oneByte_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_oneByte_10() { return &___oneByte_10; }
	inline void set_oneByte_10(ByteU5BU5D_t3397334013* value)
	{
		___oneByte_10 = value;
		Il2CppCodeGenWriteBarrier(&___oneByte_10, value);
	}

	inline static int32_t get_offset_of_C_11() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___C_11)); }
	inline UInt64U5BU5D_t1668688775* get_C_11() const { return ___C_11; }
	inline UInt64U5BU5D_t1668688775** get_address_of_C_11() { return &___C_11; }
	inline void set_C_11(UInt64U5BU5D_t1668688775* value)
	{
		___C_11 = value;
		Il2CppCodeGenWriteBarrier(&___C_11, value);
	}

	inline static int32_t get_offset_of_tempA_12() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___tempA_12)); }
	inline UInt64U5BU5D_t1668688775* get_tempA_12() const { return ___tempA_12; }
	inline UInt64U5BU5D_t1668688775** get_address_of_tempA_12() { return &___tempA_12; }
	inline void set_tempA_12(UInt64U5BU5D_t1668688775* value)
	{
		___tempA_12 = value;
		Il2CppCodeGenWriteBarrier(&___tempA_12, value);
	}

	inline static int32_t get_offset_of_chiC_13() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497, ___chiC_13)); }
	inline UInt64U5BU5D_t1668688775* get_chiC_13() const { return ___chiC_13; }
	inline UInt64U5BU5D_t1668688775** get_address_of_chiC_13() { return &___chiC_13; }
	inline void set_chiC_13(UInt64U5BU5D_t1668688775* value)
	{
		___chiC_13 = value;
		Il2CppCodeGenWriteBarrier(&___chiC_13, value);
	}
};

struct Sha3Digest_t2812698497_StaticFields
{
public:
	// System.UInt64[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::KeccakRoundConstants
	UInt64U5BU5D_t1668688775* ___KeccakRoundConstants_0;
	// System.Int32[] Org.BouncyCastle.Crypto.Digests.Sha3Digest::KeccakRhoOffsets
	Int32U5BU5D_t3030399641* ___KeccakRhoOffsets_1;

public:
	inline static int32_t get_offset_of_KeccakRoundConstants_0() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497_StaticFields, ___KeccakRoundConstants_0)); }
	inline UInt64U5BU5D_t1668688775* get_KeccakRoundConstants_0() const { return ___KeccakRoundConstants_0; }
	inline UInt64U5BU5D_t1668688775** get_address_of_KeccakRoundConstants_0() { return &___KeccakRoundConstants_0; }
	inline void set_KeccakRoundConstants_0(UInt64U5BU5D_t1668688775* value)
	{
		___KeccakRoundConstants_0 = value;
		Il2CppCodeGenWriteBarrier(&___KeccakRoundConstants_0, value);
	}

	inline static int32_t get_offset_of_KeccakRhoOffsets_1() { return static_cast<int32_t>(offsetof(Sha3Digest_t2812698497_StaticFields, ___KeccakRhoOffsets_1)); }
	inline Int32U5BU5D_t3030399641* get_KeccakRhoOffsets_1() const { return ___KeccakRhoOffsets_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_KeccakRhoOffsets_1() { return &___KeccakRhoOffsets_1; }
	inline void set_KeccakRhoOffsets_1(Int32U5BU5D_t3030399641* value)
	{
		___KeccakRhoOffsets_1 = value;
		Il2CppCodeGenWriteBarrier(&___KeccakRhoOffsets_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
