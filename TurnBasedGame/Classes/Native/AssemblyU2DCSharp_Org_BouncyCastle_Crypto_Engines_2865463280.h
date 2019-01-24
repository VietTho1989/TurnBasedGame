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

// Org.BouncyCastle.Crypto.Engines.VmpcEngine
struct  VmpcEngine_t2865463280  : public Il2CppObject
{
public:
	// System.Byte Org.BouncyCastle.Crypto.Engines.VmpcEngine::n
	uint8_t ___n_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.VmpcEngine::P
	ByteU5BU5D_t3397334013* ___P_1;
	// System.Byte Org.BouncyCastle.Crypto.Engines.VmpcEngine::s
	uint8_t ___s_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.VmpcEngine::workingIV
	ByteU5BU5D_t3397334013* ___workingIV_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.VmpcEngine::workingKey
	ByteU5BU5D_t3397334013* ___workingKey_4;

public:
	inline static int32_t get_offset_of_n_0() { return static_cast<int32_t>(offsetof(VmpcEngine_t2865463280, ___n_0)); }
	inline uint8_t get_n_0() const { return ___n_0; }
	inline uint8_t* get_address_of_n_0() { return &___n_0; }
	inline void set_n_0(uint8_t value)
	{
		___n_0 = value;
	}

	inline static int32_t get_offset_of_P_1() { return static_cast<int32_t>(offsetof(VmpcEngine_t2865463280, ___P_1)); }
	inline ByteU5BU5D_t3397334013* get_P_1() const { return ___P_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_P_1() { return &___P_1; }
	inline void set_P_1(ByteU5BU5D_t3397334013* value)
	{
		___P_1 = value;
		Il2CppCodeGenWriteBarrier(&___P_1, value);
	}

	inline static int32_t get_offset_of_s_2() { return static_cast<int32_t>(offsetof(VmpcEngine_t2865463280, ___s_2)); }
	inline uint8_t get_s_2() const { return ___s_2; }
	inline uint8_t* get_address_of_s_2() { return &___s_2; }
	inline void set_s_2(uint8_t value)
	{
		___s_2 = value;
	}

	inline static int32_t get_offset_of_workingIV_3() { return static_cast<int32_t>(offsetof(VmpcEngine_t2865463280, ___workingIV_3)); }
	inline ByteU5BU5D_t3397334013* get_workingIV_3() const { return ___workingIV_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_workingIV_3() { return &___workingIV_3; }
	inline void set_workingIV_3(ByteU5BU5D_t3397334013* value)
	{
		___workingIV_3 = value;
		Il2CppCodeGenWriteBarrier(&___workingIV_3, value);
	}

	inline static int32_t get_offset_of_workingKey_4() { return static_cast<int32_t>(offsetof(VmpcEngine_t2865463280, ___workingKey_4)); }
	inline ByteU5BU5D_t3397334013* get_workingKey_4() const { return ___workingKey_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_workingKey_4() { return &___workingKey_4; }
	inline void set_workingKey_4(ByteU5BU5D_t3397334013* value)
	{
		___workingKey_4 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
