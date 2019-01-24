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
// System.UInt32[]
struct UInt32U5BU5D_t59386216;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.Salsa20Engine
struct  Salsa20Engine_t3896743154  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.Salsa20Engine::rounds
	int32_t ___rounds_4;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.Salsa20Engine::index
	int32_t ___index_5;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Salsa20Engine::engineState
	UInt32U5BU5D_t59386216* ___engineState_6;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Salsa20Engine::x
	UInt32U5BU5D_t59386216* ___x_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Salsa20Engine::keyStream
	ByteU5BU5D_t3397334013* ___keyStream_8;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.Salsa20Engine::initialised
	bool ___initialised_9;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.Salsa20Engine::cW0
	uint32_t ___cW0_10;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.Salsa20Engine::cW1
	uint32_t ___cW1_11;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.Salsa20Engine::cW2
	uint32_t ___cW2_12;

public:
	inline static int32_t get_offset_of_rounds_4() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___rounds_4)); }
	inline int32_t get_rounds_4() const { return ___rounds_4; }
	inline int32_t* get_address_of_rounds_4() { return &___rounds_4; }
	inline void set_rounds_4(int32_t value)
	{
		___rounds_4 = value;
	}

	inline static int32_t get_offset_of_index_5() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___index_5)); }
	inline int32_t get_index_5() const { return ___index_5; }
	inline int32_t* get_address_of_index_5() { return &___index_5; }
	inline void set_index_5(int32_t value)
	{
		___index_5 = value;
	}

	inline static int32_t get_offset_of_engineState_6() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___engineState_6)); }
	inline UInt32U5BU5D_t59386216* get_engineState_6() const { return ___engineState_6; }
	inline UInt32U5BU5D_t59386216** get_address_of_engineState_6() { return &___engineState_6; }
	inline void set_engineState_6(UInt32U5BU5D_t59386216* value)
	{
		___engineState_6 = value;
		Il2CppCodeGenWriteBarrier(&___engineState_6, value);
	}

	inline static int32_t get_offset_of_x_7() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___x_7)); }
	inline UInt32U5BU5D_t59386216* get_x_7() const { return ___x_7; }
	inline UInt32U5BU5D_t59386216** get_address_of_x_7() { return &___x_7; }
	inline void set_x_7(UInt32U5BU5D_t59386216* value)
	{
		___x_7 = value;
		Il2CppCodeGenWriteBarrier(&___x_7, value);
	}

	inline static int32_t get_offset_of_keyStream_8() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___keyStream_8)); }
	inline ByteU5BU5D_t3397334013* get_keyStream_8() const { return ___keyStream_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_keyStream_8() { return &___keyStream_8; }
	inline void set_keyStream_8(ByteU5BU5D_t3397334013* value)
	{
		___keyStream_8 = value;
		Il2CppCodeGenWriteBarrier(&___keyStream_8, value);
	}

	inline static int32_t get_offset_of_initialised_9() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___initialised_9)); }
	inline bool get_initialised_9() const { return ___initialised_9; }
	inline bool* get_address_of_initialised_9() { return &___initialised_9; }
	inline void set_initialised_9(bool value)
	{
		___initialised_9 = value;
	}

	inline static int32_t get_offset_of_cW0_10() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___cW0_10)); }
	inline uint32_t get_cW0_10() const { return ___cW0_10; }
	inline uint32_t* get_address_of_cW0_10() { return &___cW0_10; }
	inline void set_cW0_10(uint32_t value)
	{
		___cW0_10 = value;
	}

	inline static int32_t get_offset_of_cW1_11() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___cW1_11)); }
	inline uint32_t get_cW1_11() const { return ___cW1_11; }
	inline uint32_t* get_address_of_cW1_11() { return &___cW1_11; }
	inline void set_cW1_11(uint32_t value)
	{
		___cW1_11 = value;
	}

	inline static int32_t get_offset_of_cW2_12() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154, ___cW2_12)); }
	inline uint32_t get_cW2_12() const { return ___cW2_12; }
	inline uint32_t* get_address_of_cW2_12() { return &___cW2_12; }
	inline void set_cW2_12(uint32_t value)
	{
		___cW2_12 = value;
	}
};

struct Salsa20Engine_t3896743154_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.Salsa20Engine::DEFAULT_ROUNDS
	int32_t ___DEFAULT_ROUNDS_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Salsa20Engine::sigma
	ByteU5BU5D_t3397334013* ___sigma_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Salsa20Engine::tau
	ByteU5BU5D_t3397334013* ___tau_3;

public:
	inline static int32_t get_offset_of_DEFAULT_ROUNDS_0() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154_StaticFields, ___DEFAULT_ROUNDS_0)); }
	inline int32_t get_DEFAULT_ROUNDS_0() const { return ___DEFAULT_ROUNDS_0; }
	inline int32_t* get_address_of_DEFAULT_ROUNDS_0() { return &___DEFAULT_ROUNDS_0; }
	inline void set_DEFAULT_ROUNDS_0(int32_t value)
	{
		___DEFAULT_ROUNDS_0 = value;
	}

	inline static int32_t get_offset_of_sigma_2() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154_StaticFields, ___sigma_2)); }
	inline ByteU5BU5D_t3397334013* get_sigma_2() const { return ___sigma_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_sigma_2() { return &___sigma_2; }
	inline void set_sigma_2(ByteU5BU5D_t3397334013* value)
	{
		___sigma_2 = value;
		Il2CppCodeGenWriteBarrier(&___sigma_2, value);
	}

	inline static int32_t get_offset_of_tau_3() { return static_cast<int32_t>(offsetof(Salsa20Engine_t3896743154_StaticFields, ___tau_3)); }
	inline ByteU5BU5D_t3397334013* get_tau_3() const { return ___tau_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_tau_3() { return &___tau_3; }
	inline void set_tau_3(ByteU5BU5D_t3397334013* value)
	{
		___tau_3 = value;
		Il2CppCodeGenWriteBarrier(&___tau_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
