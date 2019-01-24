#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.UInt32[]
struct UInt32U5BU5D_t59386216;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.Cast5Engine
struct  Cast5Engine_t2024773626  : public Il2CppObject
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::_Kr
	Int32U5BU5D_t3030399641* ____Kr_11;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::_Km
	UInt32U5BU5D_t59386216* ____Km_12;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.Cast5Engine::_encrypting
	bool ____encrypting_13;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::_workingKey
	ByteU5BU5D_t3397334013* ____workingKey_14;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.Cast5Engine::_rounds
	int32_t ____rounds_15;

public:
	inline static int32_t get_offset_of__Kr_11() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626, ____Kr_11)); }
	inline Int32U5BU5D_t3030399641* get__Kr_11() const { return ____Kr_11; }
	inline Int32U5BU5D_t3030399641** get_address_of__Kr_11() { return &____Kr_11; }
	inline void set__Kr_11(Int32U5BU5D_t3030399641* value)
	{
		____Kr_11 = value;
		Il2CppCodeGenWriteBarrier(&____Kr_11, value);
	}

	inline static int32_t get_offset_of__Km_12() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626, ____Km_12)); }
	inline UInt32U5BU5D_t59386216* get__Km_12() const { return ____Km_12; }
	inline UInt32U5BU5D_t59386216** get_address_of__Km_12() { return &____Km_12; }
	inline void set__Km_12(UInt32U5BU5D_t59386216* value)
	{
		____Km_12 = value;
		Il2CppCodeGenWriteBarrier(&____Km_12, value);
	}

	inline static int32_t get_offset_of__encrypting_13() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626, ____encrypting_13)); }
	inline bool get__encrypting_13() const { return ____encrypting_13; }
	inline bool* get_address_of__encrypting_13() { return &____encrypting_13; }
	inline void set__encrypting_13(bool value)
	{
		____encrypting_13 = value;
	}

	inline static int32_t get_offset_of__workingKey_14() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626, ____workingKey_14)); }
	inline ByteU5BU5D_t3397334013* get__workingKey_14() const { return ____workingKey_14; }
	inline ByteU5BU5D_t3397334013** get_address_of__workingKey_14() { return &____workingKey_14; }
	inline void set__workingKey_14(ByteU5BU5D_t3397334013* value)
	{
		____workingKey_14 = value;
		Il2CppCodeGenWriteBarrier(&____workingKey_14, value);
	}

	inline static int32_t get_offset_of__rounds_15() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626, ____rounds_15)); }
	inline int32_t get__rounds_15() const { return ____rounds_15; }
	inline int32_t* get_address_of__rounds_15() { return &____rounds_15; }
	inline void set__rounds_15(int32_t value)
	{
		____rounds_15 = value;
	}
};

struct Cast5Engine_t2024773626_StaticFields
{
public:
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S1
	UInt32U5BU5D_t59386216* ___S1_0;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S2
	UInt32U5BU5D_t59386216* ___S2_1;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S3
	UInt32U5BU5D_t59386216* ___S3_2;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S4
	UInt32U5BU5D_t59386216* ___S4_3;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S5
	UInt32U5BU5D_t59386216* ___S5_4;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S6
	UInt32U5BU5D_t59386216* ___S6_5;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S7
	UInt32U5BU5D_t59386216* ___S7_6;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.Cast5Engine::S8
	UInt32U5BU5D_t59386216* ___S8_7;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.Cast5Engine::MAX_ROUNDS
	int32_t ___MAX_ROUNDS_8;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.Cast5Engine::RED_ROUNDS
	int32_t ___RED_ROUNDS_9;

public:
	inline static int32_t get_offset_of_S1_0() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S1_0)); }
	inline UInt32U5BU5D_t59386216* get_S1_0() const { return ___S1_0; }
	inline UInt32U5BU5D_t59386216** get_address_of_S1_0() { return &___S1_0; }
	inline void set_S1_0(UInt32U5BU5D_t59386216* value)
	{
		___S1_0 = value;
		Il2CppCodeGenWriteBarrier(&___S1_0, value);
	}

	inline static int32_t get_offset_of_S2_1() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S2_1)); }
	inline UInt32U5BU5D_t59386216* get_S2_1() const { return ___S2_1; }
	inline UInt32U5BU5D_t59386216** get_address_of_S2_1() { return &___S2_1; }
	inline void set_S2_1(UInt32U5BU5D_t59386216* value)
	{
		___S2_1 = value;
		Il2CppCodeGenWriteBarrier(&___S2_1, value);
	}

	inline static int32_t get_offset_of_S3_2() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S3_2)); }
	inline UInt32U5BU5D_t59386216* get_S3_2() const { return ___S3_2; }
	inline UInt32U5BU5D_t59386216** get_address_of_S3_2() { return &___S3_2; }
	inline void set_S3_2(UInt32U5BU5D_t59386216* value)
	{
		___S3_2 = value;
		Il2CppCodeGenWriteBarrier(&___S3_2, value);
	}

	inline static int32_t get_offset_of_S4_3() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S4_3)); }
	inline UInt32U5BU5D_t59386216* get_S4_3() const { return ___S4_3; }
	inline UInt32U5BU5D_t59386216** get_address_of_S4_3() { return &___S4_3; }
	inline void set_S4_3(UInt32U5BU5D_t59386216* value)
	{
		___S4_3 = value;
		Il2CppCodeGenWriteBarrier(&___S4_3, value);
	}

	inline static int32_t get_offset_of_S5_4() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S5_4)); }
	inline UInt32U5BU5D_t59386216* get_S5_4() const { return ___S5_4; }
	inline UInt32U5BU5D_t59386216** get_address_of_S5_4() { return &___S5_4; }
	inline void set_S5_4(UInt32U5BU5D_t59386216* value)
	{
		___S5_4 = value;
		Il2CppCodeGenWriteBarrier(&___S5_4, value);
	}

	inline static int32_t get_offset_of_S6_5() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S6_5)); }
	inline UInt32U5BU5D_t59386216* get_S6_5() const { return ___S6_5; }
	inline UInt32U5BU5D_t59386216** get_address_of_S6_5() { return &___S6_5; }
	inline void set_S6_5(UInt32U5BU5D_t59386216* value)
	{
		___S6_5 = value;
		Il2CppCodeGenWriteBarrier(&___S6_5, value);
	}

	inline static int32_t get_offset_of_S7_6() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S7_6)); }
	inline UInt32U5BU5D_t59386216* get_S7_6() const { return ___S7_6; }
	inline UInt32U5BU5D_t59386216** get_address_of_S7_6() { return &___S7_6; }
	inline void set_S7_6(UInt32U5BU5D_t59386216* value)
	{
		___S7_6 = value;
		Il2CppCodeGenWriteBarrier(&___S7_6, value);
	}

	inline static int32_t get_offset_of_S8_7() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___S8_7)); }
	inline UInt32U5BU5D_t59386216* get_S8_7() const { return ___S8_7; }
	inline UInt32U5BU5D_t59386216** get_address_of_S8_7() { return &___S8_7; }
	inline void set_S8_7(UInt32U5BU5D_t59386216* value)
	{
		___S8_7 = value;
		Il2CppCodeGenWriteBarrier(&___S8_7, value);
	}

	inline static int32_t get_offset_of_MAX_ROUNDS_8() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___MAX_ROUNDS_8)); }
	inline int32_t get_MAX_ROUNDS_8() const { return ___MAX_ROUNDS_8; }
	inline int32_t* get_address_of_MAX_ROUNDS_8() { return &___MAX_ROUNDS_8; }
	inline void set_MAX_ROUNDS_8(int32_t value)
	{
		___MAX_ROUNDS_8 = value;
	}

	inline static int32_t get_offset_of_RED_ROUNDS_9() { return static_cast<int32_t>(offsetof(Cast5Engine_t2024773626_StaticFields, ___RED_ROUNDS_9)); }
	inline int32_t get_RED_ROUNDS_9() const { return ___RED_ROUNDS_9; }
	inline int32_t* get_address_of_RED_ROUNDS_9() { return &___RED_ROUNDS_9; }
	inline void set_RED_ROUNDS_9(int32_t value)
	{
		___RED_ROUNDS_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
