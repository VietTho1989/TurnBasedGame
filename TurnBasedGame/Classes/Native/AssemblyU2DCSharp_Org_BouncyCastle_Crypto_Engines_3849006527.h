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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.RC4Engine
struct  RC4Engine_t3849006527  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RC4Engine::engineState
	ByteU5BU5D_t3397334013* ___engineState_1;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC4Engine::x
	int32_t ___x_2;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC4Engine::y
	int32_t ___y_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RC4Engine::workingKey
	ByteU5BU5D_t3397334013* ___workingKey_4;

public:
	inline static int32_t get_offset_of_engineState_1() { return static_cast<int32_t>(offsetof(RC4Engine_t3849006527, ___engineState_1)); }
	inline ByteU5BU5D_t3397334013* get_engineState_1() const { return ___engineState_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_engineState_1() { return &___engineState_1; }
	inline void set_engineState_1(ByteU5BU5D_t3397334013* value)
	{
		___engineState_1 = value;
		Il2CppCodeGenWriteBarrier(&___engineState_1, value);
	}

	inline static int32_t get_offset_of_x_2() { return static_cast<int32_t>(offsetof(RC4Engine_t3849006527, ___x_2)); }
	inline int32_t get_x_2() const { return ___x_2; }
	inline int32_t* get_address_of_x_2() { return &___x_2; }
	inline void set_x_2(int32_t value)
	{
		___x_2 = value;
	}

	inline static int32_t get_offset_of_y_3() { return static_cast<int32_t>(offsetof(RC4Engine_t3849006527, ___y_3)); }
	inline int32_t get_y_3() const { return ___y_3; }
	inline int32_t* get_address_of_y_3() { return &___y_3; }
	inline void set_y_3(int32_t value)
	{
		___y_3 = value;
	}

	inline static int32_t get_offset_of_workingKey_4() { return static_cast<int32_t>(offsetof(RC4Engine_t3849006527, ___workingKey_4)); }
	inline ByteU5BU5D_t3397334013* get_workingKey_4() const { return ___workingKey_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_workingKey_4() { return &___workingKey_4; }
	inline void set_workingKey_4(ByteU5BU5D_t3397334013* value)
	{
		___workingKey_4 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_4, value);
	}
};

struct RC4Engine_t3849006527_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RC4Engine::STATE_LENGTH
	int32_t ___STATE_LENGTH_0;

public:
	inline static int32_t get_offset_of_STATE_LENGTH_0() { return static_cast<int32_t>(offsetof(RC4Engine_t3849006527_StaticFields, ___STATE_LENGTH_0)); }
	inline int32_t get_STATE_LENGTH_0() const { return ___STATE_LENGTH_0; }
	inline int32_t* get_address_of_STATE_LENGTH_0() { return &___STATE_LENGTH_0; }
	inline void set_STATE_LENGTH_0(int32_t value)
	{
		___STATE_LENGTH_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
