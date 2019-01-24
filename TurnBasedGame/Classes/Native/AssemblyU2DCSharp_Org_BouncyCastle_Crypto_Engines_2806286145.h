#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Collections.IDictionary
struct IDictionary_t596158605;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.Gost28147Engine
struct  Gost28147Engine_t2806286145  : public Il2CppObject
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::workingKey
	Int32U5BU5D_t3030399641* ___workingKey_1;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.Gost28147Engine::forEncryption
	bool ___forEncryption_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::S
	ByteU5BU5D_t3397334013* ___S_3;

public:
	inline static int32_t get_offset_of_workingKey_1() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145, ___workingKey_1)); }
	inline Int32U5BU5D_t3030399641* get_workingKey_1() const { return ___workingKey_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey_1() { return &___workingKey_1; }
	inline void set_workingKey_1(Int32U5BU5D_t3030399641* value)
	{
		___workingKey_1 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_1, value);
	}

	inline static int32_t get_offset_of_forEncryption_2() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145, ___forEncryption_2)); }
	inline bool get_forEncryption_2() const { return ___forEncryption_2; }
	inline bool* get_address_of_forEncryption_2() { return &___forEncryption_2; }
	inline void set_forEncryption_2(bool value)
	{
		___forEncryption_2 = value;
	}

	inline static int32_t get_offset_of_S_3() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145, ___S_3)); }
	inline ByteU5BU5D_t3397334013* get_S_3() const { return ___S_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_3() { return &___S_3; }
	inline void set_S_3(ByteU5BU5D_t3397334013* value)
	{
		___S_3 = value;
		Il2CppCodeGenWriteBarrier(&___S_3, value);
	}
};

struct Gost28147Engine_t2806286145_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::Sbox_Default
	ByteU5BU5D_t3397334013* ___Sbox_Default_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::ESbox_Test
	ByteU5BU5D_t3397334013* ___ESbox_Test_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::ESbox_A
	ByteU5BU5D_t3397334013* ___ESbox_A_6;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::ESbox_B
	ByteU5BU5D_t3397334013* ___ESbox_B_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::ESbox_C
	ByteU5BU5D_t3397334013* ___ESbox_C_8;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::ESbox_D
	ByteU5BU5D_t3397334013* ___ESbox_D_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::DSbox_Test
	ByteU5BU5D_t3397334013* ___DSbox_Test_10;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Gost28147Engine::DSbox_A
	ByteU5BU5D_t3397334013* ___DSbox_A_11;
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Engines.Gost28147Engine::sBoxes
	Il2CppObject * ___sBoxes_12;

public:
	inline static int32_t get_offset_of_Sbox_Default_4() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___Sbox_Default_4)); }
	inline ByteU5BU5D_t3397334013* get_Sbox_Default_4() const { return ___Sbox_Default_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_Sbox_Default_4() { return &___Sbox_Default_4; }
	inline void set_Sbox_Default_4(ByteU5BU5D_t3397334013* value)
	{
		___Sbox_Default_4 = value;
		Il2CppCodeGenWriteBarrier(&___Sbox_Default_4, value);
	}

	inline static int32_t get_offset_of_ESbox_Test_5() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___ESbox_Test_5)); }
	inline ByteU5BU5D_t3397334013* get_ESbox_Test_5() const { return ___ESbox_Test_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_ESbox_Test_5() { return &___ESbox_Test_5; }
	inline void set_ESbox_Test_5(ByteU5BU5D_t3397334013* value)
	{
		___ESbox_Test_5 = value;
		Il2CppCodeGenWriteBarrier(&___ESbox_Test_5, value);
	}

	inline static int32_t get_offset_of_ESbox_A_6() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___ESbox_A_6)); }
	inline ByteU5BU5D_t3397334013* get_ESbox_A_6() const { return ___ESbox_A_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_ESbox_A_6() { return &___ESbox_A_6; }
	inline void set_ESbox_A_6(ByteU5BU5D_t3397334013* value)
	{
		___ESbox_A_6 = value;
		Il2CppCodeGenWriteBarrier(&___ESbox_A_6, value);
	}

	inline static int32_t get_offset_of_ESbox_B_7() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___ESbox_B_7)); }
	inline ByteU5BU5D_t3397334013* get_ESbox_B_7() const { return ___ESbox_B_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_ESbox_B_7() { return &___ESbox_B_7; }
	inline void set_ESbox_B_7(ByteU5BU5D_t3397334013* value)
	{
		___ESbox_B_7 = value;
		Il2CppCodeGenWriteBarrier(&___ESbox_B_7, value);
	}

	inline static int32_t get_offset_of_ESbox_C_8() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___ESbox_C_8)); }
	inline ByteU5BU5D_t3397334013* get_ESbox_C_8() const { return ___ESbox_C_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_ESbox_C_8() { return &___ESbox_C_8; }
	inline void set_ESbox_C_8(ByteU5BU5D_t3397334013* value)
	{
		___ESbox_C_8 = value;
		Il2CppCodeGenWriteBarrier(&___ESbox_C_8, value);
	}

	inline static int32_t get_offset_of_ESbox_D_9() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___ESbox_D_9)); }
	inline ByteU5BU5D_t3397334013* get_ESbox_D_9() const { return ___ESbox_D_9; }
	inline ByteU5BU5D_t3397334013** get_address_of_ESbox_D_9() { return &___ESbox_D_9; }
	inline void set_ESbox_D_9(ByteU5BU5D_t3397334013* value)
	{
		___ESbox_D_9 = value;
		Il2CppCodeGenWriteBarrier(&___ESbox_D_9, value);
	}

	inline static int32_t get_offset_of_DSbox_Test_10() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___DSbox_Test_10)); }
	inline ByteU5BU5D_t3397334013* get_DSbox_Test_10() const { return ___DSbox_Test_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_DSbox_Test_10() { return &___DSbox_Test_10; }
	inline void set_DSbox_Test_10(ByteU5BU5D_t3397334013* value)
	{
		___DSbox_Test_10 = value;
		Il2CppCodeGenWriteBarrier(&___DSbox_Test_10, value);
	}

	inline static int32_t get_offset_of_DSbox_A_11() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___DSbox_A_11)); }
	inline ByteU5BU5D_t3397334013* get_DSbox_A_11() const { return ___DSbox_A_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_DSbox_A_11() { return &___DSbox_A_11; }
	inline void set_DSbox_A_11(ByteU5BU5D_t3397334013* value)
	{
		___DSbox_A_11 = value;
		Il2CppCodeGenWriteBarrier(&___DSbox_A_11, value);
	}

	inline static int32_t get_offset_of_sBoxes_12() { return static_cast<int32_t>(offsetof(Gost28147Engine_t2806286145_StaticFields, ___sBoxes_12)); }
	inline Il2CppObject * get_sBoxes_12() const { return ___sBoxes_12; }
	inline Il2CppObject ** get_address_of_sBoxes_12() { return &___sBoxes_12; }
	inline void set_sBoxes_12(Il2CppObject * value)
	{
		___sBoxes_12 = value;
		Il2CppCodeGenWriteBarrier(&___sBoxes_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
