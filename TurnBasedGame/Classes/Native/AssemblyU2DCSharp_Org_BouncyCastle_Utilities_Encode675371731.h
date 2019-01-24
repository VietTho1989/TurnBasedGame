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

// Org.BouncyCastle.Utilities.Encoders.HexEncoder
struct  HexEncoder_t675371731  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Utilities.Encoders.HexEncoder::encodingTable
	ByteU5BU5D_t3397334013* ___encodingTable_0;
	// System.Byte[] Org.BouncyCastle.Utilities.Encoders.HexEncoder::decodingTable
	ByteU5BU5D_t3397334013* ___decodingTable_1;

public:
	inline static int32_t get_offset_of_encodingTable_0() { return static_cast<int32_t>(offsetof(HexEncoder_t675371731, ___encodingTable_0)); }
	inline ByteU5BU5D_t3397334013* get_encodingTable_0() const { return ___encodingTable_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_encodingTable_0() { return &___encodingTable_0; }
	inline void set_encodingTable_0(ByteU5BU5D_t3397334013* value)
	{
		___encodingTable_0 = value;
		Il2CppCodeGenWriteBarrier(&___encodingTable_0, value);
	}

	inline static int32_t get_offset_of_decodingTable_1() { return static_cast<int32_t>(offsetof(HexEncoder_t675371731, ___decodingTable_1)); }
	inline ByteU5BU5D_t3397334013* get_decodingTable_1() const { return ___decodingTable_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_decodingTable_1() { return &___decodingTable_1; }
	inline void set_decodingTable_1(ByteU5BU5D_t3397334013* value)
	{
		___decodingTable_1 = value;
		Il2CppCodeGenWriteBarrier(&___decodingTable_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
