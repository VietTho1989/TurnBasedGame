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

// Org.BouncyCastle.Crypto.Engines.AesFastEngine
struct  AesFastEngine_t2923690633  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.AesFastEngine::ROUNDS
	int32_t ___ROUNDS_14;
	// System.UInt32[][] Org.BouncyCastle.Crypto.Engines.AesFastEngine::WorkingKey
	UInt32U5BU5DU5BU5D_t1156922361* ___WorkingKey_15;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesFastEngine::C0
	uint32_t ___C0_16;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesFastEngine::C1
	uint32_t ___C1_17;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesFastEngine::C2
	uint32_t ___C2_18;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.AesFastEngine::C3
	uint32_t ___C3_19;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.AesFastEngine::forEncryption
	bool ___forEncryption_20;

public:
	inline static int32_t get_offset_of_ROUNDS_14() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633, ___ROUNDS_14)); }
	inline int32_t get_ROUNDS_14() const { return ___ROUNDS_14; }
	inline int32_t* get_address_of_ROUNDS_14() { return &___ROUNDS_14; }
	inline void set_ROUNDS_14(int32_t value)
	{
		___ROUNDS_14 = value;
	}

	inline static int32_t get_offset_of_WorkingKey_15() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633, ___WorkingKey_15)); }
	inline UInt32U5BU5DU5BU5D_t1156922361* get_WorkingKey_15() const { return ___WorkingKey_15; }
	inline UInt32U5BU5DU5BU5D_t1156922361** get_address_of_WorkingKey_15() { return &___WorkingKey_15; }
	inline void set_WorkingKey_15(UInt32U5BU5DU5BU5D_t1156922361* value)
	{
		___WorkingKey_15 = value;
		Il2CppCodeGenWriteBarrier(&___WorkingKey_15, value);
	}

	inline static int32_t get_offset_of_C0_16() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633, ___C0_16)); }
	inline uint32_t get_C0_16() const { return ___C0_16; }
	inline uint32_t* get_address_of_C0_16() { return &___C0_16; }
	inline void set_C0_16(uint32_t value)
	{
		___C0_16 = value;
	}

	inline static int32_t get_offset_of_C1_17() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633, ___C1_17)); }
	inline uint32_t get_C1_17() const { return ___C1_17; }
	inline uint32_t* get_address_of_C1_17() { return &___C1_17; }
	inline void set_C1_17(uint32_t value)
	{
		___C1_17 = value;
	}

	inline static int32_t get_offset_of_C2_18() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633, ___C2_18)); }
	inline uint32_t get_C2_18() const { return ___C2_18; }
	inline uint32_t* get_address_of_C2_18() { return &___C2_18; }
	inline void set_C2_18(uint32_t value)
	{
		___C2_18 = value;
	}

	inline static int32_t get_offset_of_C3_19() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633, ___C3_19)); }
	inline uint32_t get_C3_19() const { return ___C3_19; }
	inline uint32_t* get_address_of_C3_19() { return &___C3_19; }
	inline void set_C3_19(uint32_t value)
	{
		___C3_19 = value;
	}

	inline static int32_t get_offset_of_forEncryption_20() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633, ___forEncryption_20)); }
	inline bool get_forEncryption_20() const { return ___forEncryption_20; }
	inline bool* get_address_of_forEncryption_20() { return &___forEncryption_20; }
	inline void set_forEncryption_20(bool value)
	{
		___forEncryption_20 = value;
	}
};

struct AesFastEngine_t2923690633_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::S
	ByteU5BU5D_t3397334013* ___S_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::Si
	ByteU5BU5D_t3397334013* ___Si_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::rcon
	ByteU5BU5D_t3397334013* ___rcon_2;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::T0
	UInt32U5BU5D_t59386216* ___T0_3;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::T1
	UInt32U5BU5D_t59386216* ___T1_4;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::T2
	UInt32U5BU5D_t59386216* ___T2_5;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::T3
	UInt32U5BU5D_t59386216* ___T3_6;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::Tinv0
	UInt32U5BU5D_t59386216* ___Tinv0_7;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::Tinv1
	UInt32U5BU5D_t59386216* ___Tinv1_8;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::Tinv2
	UInt32U5BU5D_t59386216* ___Tinv2_9;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.AesFastEngine::Tinv3
	UInt32U5BU5D_t59386216* ___Tinv3_10;

public:
	inline static int32_t get_offset_of_S_0() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___S_0)); }
	inline ByteU5BU5D_t3397334013* get_S_0() const { return ___S_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_0() { return &___S_0; }
	inline void set_S_0(ByteU5BU5D_t3397334013* value)
	{
		___S_0 = value;
		Il2CppCodeGenWriteBarrier(&___S_0, value);
	}

	inline static int32_t get_offset_of_Si_1() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___Si_1)); }
	inline ByteU5BU5D_t3397334013* get_Si_1() const { return ___Si_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_Si_1() { return &___Si_1; }
	inline void set_Si_1(ByteU5BU5D_t3397334013* value)
	{
		___Si_1 = value;
		Il2CppCodeGenWriteBarrier(&___Si_1, value);
	}

	inline static int32_t get_offset_of_rcon_2() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___rcon_2)); }
	inline ByteU5BU5D_t3397334013* get_rcon_2() const { return ___rcon_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_rcon_2() { return &___rcon_2; }
	inline void set_rcon_2(ByteU5BU5D_t3397334013* value)
	{
		___rcon_2 = value;
		Il2CppCodeGenWriteBarrier(&___rcon_2, value);
	}

	inline static int32_t get_offset_of_T0_3() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___T0_3)); }
	inline UInt32U5BU5D_t59386216* get_T0_3() const { return ___T0_3; }
	inline UInt32U5BU5D_t59386216** get_address_of_T0_3() { return &___T0_3; }
	inline void set_T0_3(UInt32U5BU5D_t59386216* value)
	{
		___T0_3 = value;
		Il2CppCodeGenWriteBarrier(&___T0_3, value);
	}

	inline static int32_t get_offset_of_T1_4() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___T1_4)); }
	inline UInt32U5BU5D_t59386216* get_T1_4() const { return ___T1_4; }
	inline UInt32U5BU5D_t59386216** get_address_of_T1_4() { return &___T1_4; }
	inline void set_T1_4(UInt32U5BU5D_t59386216* value)
	{
		___T1_4 = value;
		Il2CppCodeGenWriteBarrier(&___T1_4, value);
	}

	inline static int32_t get_offset_of_T2_5() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___T2_5)); }
	inline UInt32U5BU5D_t59386216* get_T2_5() const { return ___T2_5; }
	inline UInt32U5BU5D_t59386216** get_address_of_T2_5() { return &___T2_5; }
	inline void set_T2_5(UInt32U5BU5D_t59386216* value)
	{
		___T2_5 = value;
		Il2CppCodeGenWriteBarrier(&___T2_5, value);
	}

	inline static int32_t get_offset_of_T3_6() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___T3_6)); }
	inline UInt32U5BU5D_t59386216* get_T3_6() const { return ___T3_6; }
	inline UInt32U5BU5D_t59386216** get_address_of_T3_6() { return &___T3_6; }
	inline void set_T3_6(UInt32U5BU5D_t59386216* value)
	{
		___T3_6 = value;
		Il2CppCodeGenWriteBarrier(&___T3_6, value);
	}

	inline static int32_t get_offset_of_Tinv0_7() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___Tinv0_7)); }
	inline UInt32U5BU5D_t59386216* get_Tinv0_7() const { return ___Tinv0_7; }
	inline UInt32U5BU5D_t59386216** get_address_of_Tinv0_7() { return &___Tinv0_7; }
	inline void set_Tinv0_7(UInt32U5BU5D_t59386216* value)
	{
		___Tinv0_7 = value;
		Il2CppCodeGenWriteBarrier(&___Tinv0_7, value);
	}

	inline static int32_t get_offset_of_Tinv1_8() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___Tinv1_8)); }
	inline UInt32U5BU5D_t59386216* get_Tinv1_8() const { return ___Tinv1_8; }
	inline UInt32U5BU5D_t59386216** get_address_of_Tinv1_8() { return &___Tinv1_8; }
	inline void set_Tinv1_8(UInt32U5BU5D_t59386216* value)
	{
		___Tinv1_8 = value;
		Il2CppCodeGenWriteBarrier(&___Tinv1_8, value);
	}

	inline static int32_t get_offset_of_Tinv2_9() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___Tinv2_9)); }
	inline UInt32U5BU5D_t59386216* get_Tinv2_9() const { return ___Tinv2_9; }
	inline UInt32U5BU5D_t59386216** get_address_of_Tinv2_9() { return &___Tinv2_9; }
	inline void set_Tinv2_9(UInt32U5BU5D_t59386216* value)
	{
		___Tinv2_9 = value;
		Il2CppCodeGenWriteBarrier(&___Tinv2_9, value);
	}

	inline static int32_t get_offset_of_Tinv3_10() { return static_cast<int32_t>(offsetof(AesFastEngine_t2923690633_StaticFields, ___Tinv3_10)); }
	inline UInt32U5BU5D_t59386216* get_Tinv3_10() const { return ___Tinv3_10; }
	inline UInt32U5BU5D_t59386216** get_address_of_Tinv3_10() { return &___Tinv3_10; }
	inline void set_Tinv3_10(UInt32U5BU5D_t59386216* value)
	{
		___Tinv3_10 = value;
		Il2CppCodeGenWriteBarrier(&___Tinv3_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
