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

// Org.BouncyCastle.Crypto.Engines.RC6Engine
struct  RC6Engine_t3849078273  : public Il2CppObject
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.RC6Engine::_S
	Int32U5BU5D_t3030399641* ____S_3;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.RC6Engine::forEncryption
	bool ___forEncryption_7;

public:
	inline static int32_t get_offset_of__S_3() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273, ____S_3)); }
	inline Int32U5BU5D_t3030399641* get__S_3() const { return ____S_3; }
	inline Int32U5BU5D_t3030399641** get_address_of__S_3() { return &____S_3; }
	inline void set__S_3(Int32U5BU5D_t3030399641* value)
	{
		____S_3 = value;
		Il2CppCodeGenWriteBarrier(&____S_3, value);
	}

	inline static int32_t get_offset_of_forEncryption_7() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273, ___forEncryption_7)); }
	inline bool get_forEncryption_7() const { return ___forEncryption_7; }
	inline bool* get_address_of_forEncryption_7() { return &___forEncryption_7; }
	inline void set_forEncryption_7(bool value)
	{
		___forEncryption_7 = value;
	}
};

struct RC6Engine_t3849078273_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC6Engine::wordSize
	int32_t ___wordSize_0;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC6Engine::bytesPerWord
	int32_t ___bytesPerWord_1;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC6Engine::_noRounds
	int32_t ____noRounds_2;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC6Engine::P32
	int32_t ___P32_4;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC6Engine::Q32
	int32_t ___Q32_5;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC6Engine::LGW
	int32_t ___LGW_6;

public:
	inline static int32_t get_offset_of_wordSize_0() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273_StaticFields, ___wordSize_0)); }
	inline int32_t get_wordSize_0() const { return ___wordSize_0; }
	inline int32_t* get_address_of_wordSize_0() { return &___wordSize_0; }
	inline void set_wordSize_0(int32_t value)
	{
		___wordSize_0 = value;
	}

	inline static int32_t get_offset_of_bytesPerWord_1() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273_StaticFields, ___bytesPerWord_1)); }
	inline int32_t get_bytesPerWord_1() const { return ___bytesPerWord_1; }
	inline int32_t* get_address_of_bytesPerWord_1() { return &___bytesPerWord_1; }
	inline void set_bytesPerWord_1(int32_t value)
	{
		___bytesPerWord_1 = value;
	}

	inline static int32_t get_offset_of__noRounds_2() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273_StaticFields, ____noRounds_2)); }
	inline int32_t get__noRounds_2() const { return ____noRounds_2; }
	inline int32_t* get_address_of__noRounds_2() { return &____noRounds_2; }
	inline void set__noRounds_2(int32_t value)
	{
		____noRounds_2 = value;
	}

	inline static int32_t get_offset_of_P32_4() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273_StaticFields, ___P32_4)); }
	inline int32_t get_P32_4() const { return ___P32_4; }
	inline int32_t* get_address_of_P32_4() { return &___P32_4; }
	inline void set_P32_4(int32_t value)
	{
		___P32_4 = value;
	}

	inline static int32_t get_offset_of_Q32_5() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273_StaticFields, ___Q32_5)); }
	inline int32_t get_Q32_5() const { return ___Q32_5; }
	inline int32_t* get_address_of_Q32_5() { return &___Q32_5; }
	inline void set_Q32_5(int32_t value)
	{
		___Q32_5 = value;
	}

	inline static int32_t get_offset_of_LGW_6() { return static_cast<int32_t>(offsetof(RC6Engine_t3849078273_StaticFields, ___LGW_6)); }
	inline int32_t get_LGW_6() const { return ___LGW_6; }
	inline int32_t* get_address_of_LGW_6() { return &___LGW_6; }
	inline void set_LGW_6(int32_t value)
	{
		___LGW_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
