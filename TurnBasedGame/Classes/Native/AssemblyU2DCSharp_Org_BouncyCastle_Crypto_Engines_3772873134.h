#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.IBlockCipher
struct IBlockCipher_t916483717;
// Org.BouncyCastle.Crypto.Parameters.KeyParameter
struct KeyParameter_t215653120;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.Rfc3394WrapEngine
struct  Rfc3394WrapEngine_t3772873134  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Engines.Rfc3394WrapEngine::engine
	Il2CppObject * ___engine_0;
	// Org.BouncyCastle.Crypto.Parameters.KeyParameter Org.BouncyCastle.Crypto.Engines.Rfc3394WrapEngine::param
	KeyParameter_t215653120 * ___param_1;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.Rfc3394WrapEngine::forWrapping
	bool ___forWrapping_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.Rfc3394WrapEngine::iv
	ByteU5BU5D_t3397334013* ___iv_3;

public:
	inline static int32_t get_offset_of_engine_0() { return static_cast<int32_t>(offsetof(Rfc3394WrapEngine_t3772873134, ___engine_0)); }
	inline Il2CppObject * get_engine_0() const { return ___engine_0; }
	inline Il2CppObject ** get_address_of_engine_0() { return &___engine_0; }
	inline void set_engine_0(Il2CppObject * value)
	{
		___engine_0 = value;
		Il2CppCodeGenWriteBarrier(&___engine_0, value);
	}

	inline static int32_t get_offset_of_param_1() { return static_cast<int32_t>(offsetof(Rfc3394WrapEngine_t3772873134, ___param_1)); }
	inline KeyParameter_t215653120 * get_param_1() const { return ___param_1; }
	inline KeyParameter_t215653120 ** get_address_of_param_1() { return &___param_1; }
	inline void set_param_1(KeyParameter_t215653120 * value)
	{
		___param_1 = value;
		Il2CppCodeGenWriteBarrier(&___param_1, value);
	}

	inline static int32_t get_offset_of_forWrapping_2() { return static_cast<int32_t>(offsetof(Rfc3394WrapEngine_t3772873134, ___forWrapping_2)); }
	inline bool get_forWrapping_2() const { return ___forWrapping_2; }
	inline bool* get_address_of_forWrapping_2() { return &___forWrapping_2; }
	inline void set_forWrapping_2(bool value)
	{
		___forWrapping_2 = value;
	}

	inline static int32_t get_offset_of_iv_3() { return static_cast<int32_t>(offsetof(Rfc3394WrapEngine_t3772873134, ___iv_3)); }
	inline ByteU5BU5D_t3397334013* get_iv_3() const { return ___iv_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_iv_3() { return &___iv_3; }
	inline void set_iv_3(ByteU5BU5D_t3397334013* value)
	{
		___iv_3 = value;
		Il2CppCodeGenWriteBarrier(&___iv_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
