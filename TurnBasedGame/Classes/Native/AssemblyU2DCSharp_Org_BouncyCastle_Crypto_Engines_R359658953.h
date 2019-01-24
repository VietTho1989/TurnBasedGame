#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters
struct RsaKeyParameters_t3425534311;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.RsaCoreEngine
struct  RsaCoreEngine_t359658953  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters Org.BouncyCastle.Crypto.Engines.RsaCoreEngine::key
	RsaKeyParameters_t3425534311 * ___key_0;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.RsaCoreEngine::forEncryption
	bool ___forEncryption_1;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.RsaCoreEngine::bitSize
	int32_t ___bitSize_2;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(RsaCoreEngine_t359658953, ___key_0)); }
	inline RsaKeyParameters_t3425534311 * get_key_0() const { return ___key_0; }
	inline RsaKeyParameters_t3425534311 ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(RsaKeyParameters_t3425534311 * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_forEncryption_1() { return static_cast<int32_t>(offsetof(RsaCoreEngine_t359658953, ___forEncryption_1)); }
	inline bool get_forEncryption_1() const { return ___forEncryption_1; }
	inline bool* get_address_of_forEncryption_1() { return &___forEncryption_1; }
	inline void set_forEncryption_1(bool value)
	{
		___forEncryption_1 = value;
	}

	inline static int32_t get_offset_of_bitSize_2() { return static_cast<int32_t>(offsetof(RsaCoreEngine_t359658953, ___bitSize_2)); }
	inline int32_t get_bitSize_2() const { return ___bitSize_2; }
	inline int32_t* get_address_of_bitSize_2() { return &___bitSize_2; }
	inline void set_bitSize_2(int32_t value)
	{
		___bitSize_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
