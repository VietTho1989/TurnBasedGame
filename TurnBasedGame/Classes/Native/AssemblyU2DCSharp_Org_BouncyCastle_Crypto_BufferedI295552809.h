#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Buffered3241650255.h"

// Org.BouncyCastle.Crypto.Engines.IesEngine
struct IesEngine_t1284744109;
// System.IO.MemoryStream
struct MemoryStream_t743994179;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.BufferedIesCipher
struct  BufferedIesCipher_t295552809  : public BufferedCipherBase_t3241650255
{
public:
	// Org.BouncyCastle.Crypto.Engines.IesEngine Org.BouncyCastle.Crypto.BufferedIesCipher::engine
	IesEngine_t1284744109 * ___engine_1;
	// System.Boolean Org.BouncyCastle.Crypto.BufferedIesCipher::forEncryption
	bool ___forEncryption_2;
	// System.IO.MemoryStream Org.BouncyCastle.Crypto.BufferedIesCipher::buffer
	MemoryStream_t743994179 * ___buffer_3;

public:
	inline static int32_t get_offset_of_engine_1() { return static_cast<int32_t>(offsetof(BufferedIesCipher_t295552809, ___engine_1)); }
	inline IesEngine_t1284744109 * get_engine_1() const { return ___engine_1; }
	inline IesEngine_t1284744109 ** get_address_of_engine_1() { return &___engine_1; }
	inline void set_engine_1(IesEngine_t1284744109 * value)
	{
		___engine_1 = value;
		Il2CppCodeGenWriteBarrier(&___engine_1, value);
	}

	inline static int32_t get_offset_of_forEncryption_2() { return static_cast<int32_t>(offsetof(BufferedIesCipher_t295552809, ___forEncryption_2)); }
	inline bool get_forEncryption_2() const { return ___forEncryption_2; }
	inline bool* get_address_of_forEncryption_2() { return &___forEncryption_2; }
	inline void set_forEncryption_2(bool value)
	{
		___forEncryption_2 = value;
	}

	inline static int32_t get_offset_of_buffer_3() { return static_cast<int32_t>(offsetof(BufferedIesCipher_t295552809, ___buffer_3)); }
	inline MemoryStream_t743994179 * get_buffer_3() const { return ___buffer_3; }
	inline MemoryStream_t743994179 ** get_address_of_buffer_3() { return &___buffer_3; }
	inline void set_buffer_3(MemoryStream_t743994179 * value)
	{
		___buffer_3 = value;
		Il2CppCodeGenWriteBarrier(&___buffer_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
