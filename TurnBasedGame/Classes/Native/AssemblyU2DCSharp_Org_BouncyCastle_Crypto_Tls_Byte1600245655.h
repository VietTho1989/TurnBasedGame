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

// Org.BouncyCastle.Crypto.Tls.ByteQueue
struct  ByteQueue_t1600245655  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.ByteQueue::databuf
	ByteU5BU5D_t3397334013* ___databuf_1;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.ByteQueue::skipped
	int32_t ___skipped_2;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.ByteQueue::available
	int32_t ___available_3;

public:
	inline static int32_t get_offset_of_databuf_1() { return static_cast<int32_t>(offsetof(ByteQueue_t1600245655, ___databuf_1)); }
	inline ByteU5BU5D_t3397334013* get_databuf_1() const { return ___databuf_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_databuf_1() { return &___databuf_1; }
	inline void set_databuf_1(ByteU5BU5D_t3397334013* value)
	{
		___databuf_1 = value;
		Il2CppCodeGenWriteBarrier(&___databuf_1, value);
	}

	inline static int32_t get_offset_of_skipped_2() { return static_cast<int32_t>(offsetof(ByteQueue_t1600245655, ___skipped_2)); }
	inline int32_t get_skipped_2() const { return ___skipped_2; }
	inline int32_t* get_address_of_skipped_2() { return &___skipped_2; }
	inline void set_skipped_2(int32_t value)
	{
		___skipped_2 = value;
	}

	inline static int32_t get_offset_of_available_3() { return static_cast<int32_t>(offsetof(ByteQueue_t1600245655, ___available_3)); }
	inline int32_t get_available_3() const { return ___available_3; }
	inline int32_t* get_address_of_available_3() { return &___available_3; }
	inline void set_available_3(int32_t value)
	{
		___available_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
