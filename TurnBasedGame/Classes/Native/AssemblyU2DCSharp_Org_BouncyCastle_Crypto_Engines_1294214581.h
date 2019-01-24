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
// System.UInt32[][]
struct UInt32U5BU5DU5BU5D_t1156922361;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.AesEngine
struct  AesEngine_t1294214581  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.AesEngine::ROUNDS
	int32_t ___ROUNDS_8;
	// System.UInt32[][] Org.BouncyCastle.Crypto.Engines.AesEngine::WorkingKey
	UInt32U5BU5DU5BU5D_t1156922361* ___WorkingKey_9;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesEngine::C0
	uint32_t ___C0_10;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesEngine::C1
	uint32_t ___C1_11;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesEngine::C2
	uint32_t ___C2_12;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesEngine::C3
	uint32_t ___C3_13;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.AesEngine::forEncryption
	bool ___forEncryption_14;

public:
	inline static int32_t get_offset_of_ROUNDS_8() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581, ___ROUNDS_8)); }
	inline int32_t get_ROUNDS_8() const { return ___ROUNDS_8; }
	inline int32_t* get_address_of_ROUNDS_8() { return &___ROUNDS_8; }
	inline void set_ROUNDS_8(int32_t value)
	{
		___ROUNDS_8 = value;
	}

	inline static int32_t get_offset_of_WorkingKey_9() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581, ___WorkingKey_9)); }
	inline UInt32U5BU5DU5BU5D_t1156922361* get_WorkingKey_9() const { return ___WorkingKey_9; }
	inline UInt32U5BU5DU5BU5D_t1156922361** get_address_of_WorkingKey_9() { return &___WorkingKey_9; }
	inline void set_WorkingKey_9(UInt32U5BU5DU5BU5D_t1156922361* value)
	{
		___WorkingKey_9 = value;
		Il2CppCodeGenWriteBarrier(&___WorkingKey_9, value);
	}

	inline static int32_t get_offset_of_C0_10() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581, ___C0_10)); }
	inline uint32_t get_C0_10() const { return ___C0_10; }
	inline uint32_t* get_address_of_C0_10() { return &___C0_10; }
	inline void set_C0_10(uint32_t value)
	{
		___C0_10 = value;
	}

	inline static int32_t get_offset_of_C1_11() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581, ___C1_11)); }
	inline uint32_t get_C1_11() const { return ___C1_11; }
	inline uint32_t* get_address_of_C1_11() { return &___C1_11; }
	inline void set_C1_11(uint32_t value)
	{
		___C1_11 = value;
	}

	inline static int32_t get_offset_of_C2_12() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581, ___C2_12)); }
	inline uint32_t get_C2_12() const { return ___C2_12; }
	inline uint32_t* get_address_of_C2_12() { return &___C2_12; }
	inline void set_C2_12(uint32_t value)
	{
		___C2_12 = value;
	}

	inline static int32_t get_offset_of_C3_13() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581, ___C3_13)); }
	inline uint32_t get_C3_13() const { return ___C3_13; }
	inline uint32_t* get_address_of_C3_13() { return &___C3_13; }
	inline void set_C3_13(uint32_t value)
	{
		___C3_13 = value;
	}

	inline static int32_t get_offset_of_forEncryption_14() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581, ___forEncryption_14)); }
	inline bool get_forEncryption_14() const { return ___forEncryption_14; }
	inline bool* get_address_of_forEncryption_14() { return &___forEncryption_14; }
	inline void set_forEncryption_14(bool value)
	{
		___forEncryption_14 = value;
	}
};

struct AesEngine_t1294214581_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.AesEngine::S
	ByteU5BU5D_t3397334013* ___S_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.AesEngine::Si
	ByteU5BU5D_t3397334013* ___Si_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.AesEngine::rcon
	ByteU5BU5D_t3397334013* ___rcon_2;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesEngine::T0
	UInt32U5BU5D_t59386216* ___T0_3;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesEngine::Tinv0
	UInt32U5BU5D_t59386216* ___Tinv0_4;

public:
	inline static int32_t get_offset_of_S_0() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581_StaticFields, ___S_0)); }
	inline ByteU5BU5D_t3397334013* get_S_0() const { return ___S_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_0() { return &___S_0; }
	inline void set_S_0(ByteU5BU5D_t3397334013* value)
	{
		___S_0 = value;
		Il2CppCodeGenWriteBarrier(&___S_0, value);
	}

	inline static int32_t get_offset_of_Si_1() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581_StaticFields, ___Si_1)); }
	inline ByteU5BU5D_t3397334013* get_Si_1() const { return ___Si_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_Si_1() { return &___Si_1; }
	inline void set_Si_1(ByteU5BU5D_t3397334013* value)
	{
		___Si_1 = value;
		Il2CppCodeGenWriteBarrier(&___Si_1, value);
	}

	inline static int32_t get_offset_of_rcon_2() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581_StaticFields, ___rcon_2)); }
	inline ByteU5BU5D_t3397334013* get_rcon_2() const { return ___rcon_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_rcon_2() { return &___rcon_2; }
	inline void set_rcon_2(ByteU5BU5D_t3397334013* value)
	{
		___rcon_2 = value;
		Il2CppCodeGenWriteBarrier(&___rcon_2, value);
	}

	inline static int32_t get_offset_of_T0_3() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581_StaticFields, ___T0_3)); }
	inline UInt32U5BU5D_t59386216* get_T0_3() const { return ___T0_3; }
	inline UInt32U5BU5D_t59386216** get_address_of_T0_3() { return &___T0_3; }
	inline void set_T0_3(UInt32U5BU5D_t59386216* value)
	{
		___T0_3 = value;
		Il2CppCodeGenWriteBarrier(&___T0_3, value);
	}

	inline static int32_t get_offset_of_Tinv0_4() { return static_cast<int32_t>(offsetof(AesEngine_t1294214581_StaticFields, ___Tinv0_4)); }
	inline UInt32U5BU5D_t59386216* get_Tinv0_4() const { return ___Tinv0_4; }
	inline UInt32U5BU5D_t59386216** get_address_of_Tinv0_4() { return &___Tinv0_4; }
	inline void set_Tinv0_4(UInt32U5BU5D_t59386216* value)
	{
		___Tinv0_4 = value;
		Il2CppCodeGenWriteBarrier(&___Tinv0_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
