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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.SerpentEngine
struct  SerpentEngine_t1009038245  : public Il2CppObject
{
public:
	// System.Boolean Org.BouncyCastle.Crypto.Engines.SerpentEngine::encrypting
	bool ___encrypting_3;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.SerpentEngine::wKey
	Int32U5BU5D_t3030399641* ___wKey_4;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.SerpentEngine::X0
	int32_t ___X0_5;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.SerpentEngine::X1
	int32_t ___X1_6;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.SerpentEngine::X2
	int32_t ___X2_7;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.SerpentEngine::X3
	int32_t ___X3_8;

public:
	inline static int32_t get_offset_of_encrypting_3() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245, ___encrypting_3)); }
	inline bool get_encrypting_3() const { return ___encrypting_3; }
	inline bool* get_address_of_encrypting_3() { return &___encrypting_3; }
	inline void set_encrypting_3(bool value)
	{
		___encrypting_3 = value;
	}

	inline static int32_t get_offset_of_wKey_4() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245, ___wKey_4)); }
	inline Int32U5BU5D_t3030399641* get_wKey_4() const { return ___wKey_4; }
	inline Int32U5BU5D_t3030399641** get_address_of_wKey_4() { return &___wKey_4; }
	inline void set_wKey_4(Int32U5BU5D_t3030399641* value)
	{
		___wKey_4 = value;
		Il2CppCodeGenWriteBarrier(&___wKey_4, value);
	}

	inline static int32_t get_offset_of_X0_5() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245, ___X0_5)); }
	inline int32_t get_X0_5() const { return ___X0_5; }
	inline int32_t* get_address_of_X0_5() { return &___X0_5; }
	inline void set_X0_5(int32_t value)
	{
		___X0_5 = value;
	}

	inline static int32_t get_offset_of_X1_6() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245, ___X1_6)); }
	inline int32_t get_X1_6() const { return ___X1_6; }
	inline int32_t* get_address_of_X1_6() { return &___X1_6; }
	inline void set_X1_6(int32_t value)
	{
		___X1_6 = value;
	}

	inline static int32_t get_offset_of_X2_7() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245, ___X2_7)); }
	inline int32_t get_X2_7() const { return ___X2_7; }
	inline int32_t* get_address_of_X2_7() { return &___X2_7; }
	inline void set_X2_7(int32_t value)
	{
		___X2_7 = value;
	}

	inline static int32_t get_offset_of_X3_8() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245, ___X3_8)); }
	inline int32_t get_X3_8() const { return ___X3_8; }
	inline int32_t* get_address_of_X3_8() { return &___X3_8; }
	inline void set_X3_8(int32_t value)
	{
		___X3_8 = value;
	}
};

struct SerpentEngine_t1009038245_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.SerpentEngine::ROUNDS
	int32_t ___ROUNDS_1;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.SerpentEngine::PHI
	int32_t ___PHI_2;

public:
	inline static int32_t get_offset_of_ROUNDS_1() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245_StaticFields, ___ROUNDS_1)); }
	inline int32_t get_ROUNDS_1() const { return ___ROUNDS_1; }
	inline int32_t* get_address_of_ROUNDS_1() { return &___ROUNDS_1; }
	inline void set_ROUNDS_1(int32_t value)
	{
		___ROUNDS_1 = value;
	}

	inline static int32_t get_offset_of_PHI_2() { return static_cast<int32_t>(offsetof(SerpentEngine_t1009038245_StaticFields, ___PHI_2)); }
	inline int32_t get_PHI_2() const { return ___PHI_2; }
	inline int32_t* get_address_of_PHI_2() { return &___PHI_2; }
	inline void set_PHI_2(int32_t value)
	{
		___PHI_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
