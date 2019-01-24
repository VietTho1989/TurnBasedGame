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
// System.Byte[][]
struct ByteU5BU5DU5BU5D_t717853552;
// System.Int64[][]
struct Int64U5BU5DU5BU5D_t1808128809;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.RijndaelEngine
struct  RijndaelEngine_t2948722429  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::BC
	int32_t ___BC_9;
	// System.Int64 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::BC_MASK
	int64_t ___BC_MASK_10;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::ROUNDS
	int32_t ___ROUNDS_11;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::blockBits
	int32_t ___blockBits_12;
	// System.Int64[][] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::workingKey
	Int64U5BU5DU5BU5D_t1808128809* ___workingKey_13;
	// System.Int64 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::A0
	int64_t ___A0_14;
	// System.Int64 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::A1
	int64_t ___A1_15;
	// System.Int64 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::A2
	int64_t ___A2_16;
	// System.Int64 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::A3
	int64_t ___A3_17;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.RijndaelEngine::forEncryption
	bool ___forEncryption_18;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::shifts0SC
	ByteU5BU5D_t3397334013* ___shifts0SC_19;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::shifts1SC
	ByteU5BU5D_t3397334013* ___shifts1SC_20;

public:
	inline static int32_t get_offset_of_BC_9() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___BC_9)); }
	inline int32_t get_BC_9() const { return ___BC_9; }
	inline int32_t* get_address_of_BC_9() { return &___BC_9; }
	inline void set_BC_9(int32_t value)
	{
		___BC_9 = value;
	}

	inline static int32_t get_offset_of_BC_MASK_10() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___BC_MASK_10)); }
	inline int64_t get_BC_MASK_10() const { return ___BC_MASK_10; }
	inline int64_t* get_address_of_BC_MASK_10() { return &___BC_MASK_10; }
	inline void set_BC_MASK_10(int64_t value)
	{
		___BC_MASK_10 = value;
	}

	inline static int32_t get_offset_of_ROUNDS_11() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___ROUNDS_11)); }
	inline int32_t get_ROUNDS_11() const { return ___ROUNDS_11; }
	inline int32_t* get_address_of_ROUNDS_11() { return &___ROUNDS_11; }
	inline void set_ROUNDS_11(int32_t value)
	{
		___ROUNDS_11 = value;
	}

	inline static int32_t get_offset_of_blockBits_12() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___blockBits_12)); }
	inline int32_t get_blockBits_12() const { return ___blockBits_12; }
	inline int32_t* get_address_of_blockBits_12() { return &___blockBits_12; }
	inline void set_blockBits_12(int32_t value)
	{
		___blockBits_12 = value;
	}

	inline static int32_t get_offset_of_workingKey_13() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___workingKey_13)); }
	inline Int64U5BU5DU5BU5D_t1808128809* get_workingKey_13() const { return ___workingKey_13; }
	inline Int64U5BU5DU5BU5D_t1808128809** get_address_of_workingKey_13() { return &___workingKey_13; }
	inline void set_workingKey_13(Int64U5BU5DU5BU5D_t1808128809* value)
	{
		___workingKey_13 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_13, value);
	}

	inline static int32_t get_offset_of_A0_14() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___A0_14)); }
	inline int64_t get_A0_14() const { return ___A0_14; }
	inline int64_t* get_address_of_A0_14() { return &___A0_14; }
	inline void set_A0_14(int64_t value)
	{
		___A0_14 = value;
	}

	inline static int32_t get_offset_of_A1_15() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___A1_15)); }
	inline int64_t get_A1_15() const { return ___A1_15; }
	inline int64_t* get_address_of_A1_15() { return &___A1_15; }
	inline void set_A1_15(int64_t value)
	{
		___A1_15 = value;
	}

	inline static int32_t get_offset_of_A2_16() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___A2_16)); }
	inline int64_t get_A2_16() const { return ___A2_16; }
	inline int64_t* get_address_of_A2_16() { return &___A2_16; }
	inline void set_A2_16(int64_t value)
	{
		___A2_16 = value;
	}

	inline static int32_t get_offset_of_A3_17() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___A3_17)); }
	inline int64_t get_A3_17() const { return ___A3_17; }
	inline int64_t* get_address_of_A3_17() { return &___A3_17; }
	inline void set_A3_17(int64_t value)
	{
		___A3_17 = value;
	}

	inline static int32_t get_offset_of_forEncryption_18() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___forEncryption_18)); }
	inline bool get_forEncryption_18() const { return ___forEncryption_18; }
	inline bool* get_address_of_forEncryption_18() { return &___forEncryption_18; }
	inline void set_forEncryption_18(bool value)
	{
		___forEncryption_18 = value;
	}

	inline static int32_t get_offset_of_shifts0SC_19() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___shifts0SC_19)); }
	inline ByteU5BU5D_t3397334013* get_shifts0SC_19() const { return ___shifts0SC_19; }
	inline ByteU5BU5D_t3397334013** get_address_of_shifts0SC_19() { return &___shifts0SC_19; }
	inline void set_shifts0SC_19(ByteU5BU5D_t3397334013* value)
	{
		___shifts0SC_19 = value;
		Il2CppCodeGenWriteBarrier(&___shifts0SC_19, value);
	}

	inline static int32_t get_offset_of_shifts1SC_20() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429, ___shifts1SC_20)); }
	inline ByteU5BU5D_t3397334013* get_shifts1SC_20() const { return ___shifts1SC_20; }
	inline ByteU5BU5D_t3397334013** get_address_of_shifts1SC_20() { return &___shifts1SC_20; }
	inline void set_shifts1SC_20(ByteU5BU5D_t3397334013* value)
	{
		___shifts1SC_20 = value;
		Il2CppCodeGenWriteBarrier(&___shifts1SC_20, value);
	}
};

struct RijndaelEngine_t2948722429_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::MAXROUNDS
	int32_t ___MAXROUNDS_0;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RijndaelEngine::MAXKC
	int32_t ___MAXKC_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::Logtable
	ByteU5BU5D_t3397334013* ___Logtable_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::Alogtable
	ByteU5BU5D_t3397334013* ___Alogtable_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::S
	ByteU5BU5D_t3397334013* ___S_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::Si
	ByteU5BU5D_t3397334013* ___Si_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::rcon
	ByteU5BU5D_t3397334013* ___rcon_6;
	// System.Byte[][] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::shifts0
	ByteU5BU5DU5BU5D_t717853552* ___shifts0_7;
	// System.Byte[][] Org.BouncyCastle.Crypto.Engines.RijndaelEngine::shifts1
	ByteU5BU5DU5BU5D_t717853552* ___shifts1_8;

public:
	inline static int32_t get_offset_of_MAXROUNDS_0() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___MAXROUNDS_0)); }
	inline int32_t get_MAXROUNDS_0() const { return ___MAXROUNDS_0; }
	inline int32_t* get_address_of_MAXROUNDS_0() { return &___MAXROUNDS_0; }
	inline void set_MAXROUNDS_0(int32_t value)
	{
		___MAXROUNDS_0 = value;
	}

	inline static int32_t get_offset_of_MAXKC_1() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___MAXKC_1)); }
	inline int32_t get_MAXKC_1() const { return ___MAXKC_1; }
	inline int32_t* get_address_of_MAXKC_1() { return &___MAXKC_1; }
	inline void set_MAXKC_1(int32_t value)
	{
		___MAXKC_1 = value;
	}

	inline static int32_t get_offset_of_Logtable_2() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___Logtable_2)); }
	inline ByteU5BU5D_t3397334013* get_Logtable_2() const { return ___Logtable_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_Logtable_2() { return &___Logtable_2; }
	inline void set_Logtable_2(ByteU5BU5D_t3397334013* value)
	{
		___Logtable_2 = value;
		Il2CppCodeGenWriteBarrier(&___Logtable_2, value);
	}

	inline static int32_t get_offset_of_Alogtable_3() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___Alogtable_3)); }
	inline ByteU5BU5D_t3397334013* get_Alogtable_3() const { return ___Alogtable_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_Alogtable_3() { return &___Alogtable_3; }
	inline void set_Alogtable_3(ByteU5BU5D_t3397334013* value)
	{
		___Alogtable_3 = value;
		Il2CppCodeGenWriteBarrier(&___Alogtable_3, value);
	}

	inline static int32_t get_offset_of_S_4() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___S_4)); }
	inline ByteU5BU5D_t3397334013* get_S_4() const { return ___S_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_4() { return &___S_4; }
	inline void set_S_4(ByteU5BU5D_t3397334013* value)
	{
		___S_4 = value;
		Il2CppCodeGenWriteBarrier(&___S_4, value);
	}

	inline static int32_t get_offset_of_Si_5() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___Si_5)); }
	inline ByteU5BU5D_t3397334013* get_Si_5() const { return ___Si_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_Si_5() { return &___Si_5; }
	inline void set_Si_5(ByteU5BU5D_t3397334013* value)
	{
		___Si_5 = value;
		Il2CppCodeGenWriteBarrier(&___Si_5, value);
	}

	inline static int32_t get_offset_of_rcon_6() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___rcon_6)); }
	inline ByteU5BU5D_t3397334013* get_rcon_6() const { return ___rcon_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_rcon_6() { return &___rcon_6; }
	inline void set_rcon_6(ByteU5BU5D_t3397334013* value)
	{
		___rcon_6 = value;
		Il2CppCodeGenWriteBarrier(&___rcon_6, value);
	}

	inline static int32_t get_offset_of_shifts0_7() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___shifts0_7)); }
	inline ByteU5BU5DU5BU5D_t717853552* get_shifts0_7() const { return ___shifts0_7; }
	inline ByteU5BU5DU5BU5D_t717853552** get_address_of_shifts0_7() { return &___shifts0_7; }
	inline void set_shifts0_7(ByteU5BU5DU5BU5D_t717853552* value)
	{
		___shifts0_7 = value;
		Il2CppCodeGenWriteBarrier(&___shifts0_7, value);
	}

	inline static int32_t get_offset_of_shifts1_8() { return static_cast<int32_t>(offsetof(RijndaelEngine_t2948722429_StaticFields, ___shifts1_8)); }
	inline ByteU5BU5DU5BU5D_t717853552* get_shifts1_8() const { return ___shifts1_8; }
	inline ByteU5BU5DU5BU5D_t717853552** get_address_of_shifts1_8() { return &___shifts1_8; }
	inline void set_shifts1_8(ByteU5BU5DU5BU5D_t717853552* value)
	{
		___shifts1_8 = value;
		Il2CppCodeGenWriteBarrier(&___shifts1_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
