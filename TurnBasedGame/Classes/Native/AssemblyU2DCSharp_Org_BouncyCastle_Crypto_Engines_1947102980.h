#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int64[]
struct Int64U5BU5D_t717125112;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.RC564Engine
struct  RC564Engine_t1947102980  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC564Engine::_noRounds
	int32_t ____noRounds_2;
	// System.Int64[] Org.BouncyCastle.Crypto.Engines.RC564Engine::_S
	Int64U5BU5D_t717125112* ____S_3;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.RC564Engine::forEncryption
	bool ___forEncryption_6;

public:
	inline static int32_t get_offset_of__noRounds_2() { return static_cast<int32_t>(offsetof(RC564Engine_t1947102980, ____noRounds_2)); }
	inline int32_t get__noRounds_2() const { return ____noRounds_2; }
	inline int32_t* get_address_of__noRounds_2() { return &____noRounds_2; }
	inline void set__noRounds_2(int32_t value)
	{
		____noRounds_2 = value;
	}

	inline static int32_t get_offset_of__S_3() { return static_cast<int32_t>(offsetof(RC564Engine_t1947102980, ____S_3)); }
	inline Int64U5BU5D_t717125112* get__S_3() const { return ____S_3; }
	inline Int64U5BU5D_t717125112** get_address_of__S_3() { return &____S_3; }
	inline void set__S_3(Int64U5BU5D_t717125112* value)
	{
		____S_3 = value;
		Il2CppCodeGenWriteBarrier(&____S_3, value);
	}

	inline static int32_t get_offset_of_forEncryption_6() { return static_cast<int32_t>(offsetof(RC564Engine_t1947102980, ___forEncryption_6)); }
	inline bool get_forEncryption_6() const { return ___forEncryption_6; }
	inline bool* get_address_of_forEncryption_6() { return &___forEncryption_6; }
	inline void set_forEncryption_6(bool value)
	{
		___forEncryption_6 = value;
	}
};

struct RC564Engine_t1947102980_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC564Engine::wordSize
	int32_t ___wordSize_0;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC564Engine::bytesPerWord
	int32_t ___bytesPerWord_1;
	// System.Int64 Org.BouncyCastle.Crypto.Engines.RC564Engine::P64
	int64_t ___P64_4;
	// System.Int64 Org.BouncyCastle.Crypto.Engines.RC564Engine::Q64
	int64_t ___Q64_5;

public:
	inline static int32_t get_offset_of_wordSize_0() { return static_cast<int32_t>(offsetof(RC564Engine_t1947102980_StaticFields, ___wordSize_0)); }
	inline int32_t get_wordSize_0() const { return ___wordSize_0; }
	inline int32_t* get_address_of_wordSize_0() { return &___wordSize_0; }
	inline void set_wordSize_0(int32_t value)
	{
		___wordSize_0 = value;
	}

	inline static int32_t get_offset_of_bytesPerWord_1() { return static_cast<int32_t>(offsetof(RC564Engine_t1947102980_StaticFields, ___bytesPerWord_1)); }
	inline int32_t get_bytesPerWord_1() const { return ___bytesPerWord_1; }
	inline int32_t* get_address_of_bytesPerWord_1() { return &___bytesPerWord_1; }
	inline void set_bytesPerWord_1(int32_t value)
	{
		___bytesPerWord_1 = value;
	}

	inline static int32_t get_offset_of_P64_4() { return static_cast<int32_t>(offsetof(RC564Engine_t1947102980_StaticFields, ___P64_4)); }
	inline int64_t get_P64_4() const { return ___P64_4; }
	inline int64_t* get_address_of_P64_4() { return &___P64_4; }
	inline void set_P64_4(int64_t value)
	{
		___P64_4 = value;
	}

	inline static int32_t get_offset_of_Q64_5() { return static_cast<int32_t>(offsetof(RC564Engine_t1947102980_StaticFields, ___Q64_5)); }
	inline int64_t get_Q64_5() const { return ___Q64_5; }
	inline int64_t* get_address_of_Q64_5() { return &___Q64_5; }
	inline void set_Q64_5(int64_t value)
	{
		___Q64_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
