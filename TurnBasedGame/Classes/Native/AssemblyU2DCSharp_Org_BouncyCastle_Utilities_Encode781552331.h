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

// Org.BouncyCastle.Utilities.Encoders.Base64Encoder
struct  Base64Encoder_t781552331  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Utilities.Encoders.Base64Encoder::encodingTable
	ByteU5BU5D_t3397334013* ___encodingTable_0;
	// System.Byte Org.BouncyCastle.Utilities.Encoders.Base64Encoder::padding
	uint8_t ___padding_1;
	// System.Byte[] Org.BouncyCastle.Utilities.Encoders.Base64Encoder::decodingTable
	ByteU5BU5D_t3397334013* ___decodingTable_2;

public:
	inline static int32_t get_offset_of_encodingTable_0() { return static_cast<int32_t>(offsetof(Base64Encoder_t781552331, ___encodingTable_0)); }
	inline ByteU5BU5D_t3397334013* get_encodingTable_0() const { return ___encodingTable_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_encodingTable_0() { return &___encodingTable_0; }
	inline void set_encodingTable_0(ByteU5BU5D_t3397334013* value)
	{
		___encodingTable_0 = value;
		Il2CppCodeGenWriteBarrier(&___encodingTable_0, value);
	}

	inline static int32_t get_offset_of_padding_1() { return static_cast<int32_t>(offsetof(Base64Encoder_t781552331, ___padding_1)); }
	inline uint8_t get_padding_1() const { return ___padding_1; }
	inline uint8_t* get_address_of_padding_1() { return &___padding_1; }
	inline void set_padding_1(uint8_t value)
	{
		___padding_1 = value;
	}

	inline static int32_t get_offset_of_decodingTable_2() { return static_cast<int32_t>(offsetof(Base64Encoder_t781552331, ___decodingTable_2)); }
	inline ByteU5BU5D_t3397334013* get_decodingTable_2() const { return ___decodingTable_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_decodingTable_2() { return &___decodingTable_2; }
	inline void set_decodingTable_2(ByteU5BU5D_t3397334013* value)
	{
		___decodingTable_2 = value;
		Il2CppCodeGenWriteBarrier(&___decodingTable_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
