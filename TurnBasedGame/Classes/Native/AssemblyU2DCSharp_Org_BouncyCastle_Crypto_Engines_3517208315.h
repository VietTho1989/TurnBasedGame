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

// Org.BouncyCastle.Crypto.Engines.RC532Engine
struct  RC532Engine_t3517208315  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC532Engine::_noRounds
	int32_t ____noRounds_0;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.RC532Engine::_S
	Int32U5BU5D_t3030399641* ____S_1;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.RC532Engine::forEncryption
	bool ___forEncryption_4;

public:
	inline static int32_t get_offset_of__noRounds_0() { return static_cast<int32_t>(offsetof(RC532Engine_t3517208315, ____noRounds_0)); }
	inline int32_t get__noRounds_0() const { return ____noRounds_0; }
	inline int32_t* get_address_of__noRounds_0() { return &____noRounds_0; }
	inline void set__noRounds_0(int32_t value)
	{
		____noRounds_0 = value;
	}

	inline static int32_t get_offset_of__S_1() { return static_cast<int32_t>(offsetof(RC532Engine_t3517208315, ____S_1)); }
	inline Int32U5BU5D_t3030399641* get__S_1() const { return ____S_1; }
	inline Int32U5BU5D_t3030399641** get_address_of__S_1() { return &____S_1; }
	inline void set__S_1(Int32U5BU5D_t3030399641* value)
	{
		____S_1 = value;
		Il2CppCodeGenWriteBarrier(&____S_1, value);
	}

	inline static int32_t get_offset_of_forEncryption_4() { return static_cast<int32_t>(offsetof(RC532Engine_t3517208315, ___forEncryption_4)); }
	inline bool get_forEncryption_4() const { return ___forEncryption_4; }
	inline bool* get_address_of_forEncryption_4() { return &___forEncryption_4; }
	inline void set_forEncryption_4(bool value)
	{
		___forEncryption_4 = value;
	}
};

struct RC532Engine_t3517208315_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC532Engine::P32
	int32_t ___P32_2;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC532Engine::Q32
	int32_t ___Q32_3;

public:
	inline static int32_t get_offset_of_P32_2() { return static_cast<int32_t>(offsetof(RC532Engine_t3517208315_StaticFields, ___P32_2)); }
	inline int32_t get_P32_2() const { return ___P32_2; }
	inline int32_t* get_address_of_P32_2() { return &___P32_2; }
	inline void set_P32_2(int32_t value)
	{
		___P32_2 = value;
	}

	inline static int32_t get_offset_of_Q32_3() { return static_cast<int32_t>(offsetof(RC532Engine_t3517208315_StaticFields, ___Q32_3)); }
	inline int32_t get_Q32_3() const { return ___Q32_3; }
	inline int32_t* get_address_of_Q32_3() { return &___Q32_3; }
	inline void set_Q32_3(int32_t value)
	{
		___Q32_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
