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

// System.Net.ChunkStream/Chunk
struct  Chunk_t3860501603  : public Il2CppObject
{
public:
	// System.Byte[] System.Net.ChunkStream/Chunk::Bytes
	ByteU5BU5D_t3397334013* ___Bytes_0;
	// System.Int32 System.Net.ChunkStream/Chunk::Offset
	int32_t ___Offset_1;

public:
	inline static int32_t get_offset_of_Bytes_0() { return static_cast<int32_t>(offsetof(Chunk_t3860501603, ___Bytes_0)); }
	inline ByteU5BU5D_t3397334013* get_Bytes_0() const { return ___Bytes_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_Bytes_0() { return &___Bytes_0; }
	inline void set_Bytes_0(ByteU5BU5D_t3397334013* value)
	{
		___Bytes_0 = value;
		Il2CppCodeGenWriteBarrier(&___Bytes_0, value);
	}

	inline static int32_t get_offset_of_Offset_1() { return static_cast<int32_t>(offsetof(Chunk_t3860501603, ___Offset_1)); }
	inline int32_t get_Offset_1() const { return ___Offset_1; }
	inline int32_t* get_address_of_Offset_1() { return &___Offset_1; }
	inline void set_Offset_1(int32_t value)
	{
		___Offset_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
