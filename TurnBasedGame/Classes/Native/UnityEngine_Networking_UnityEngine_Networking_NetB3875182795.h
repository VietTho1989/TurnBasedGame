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

// UnityEngine.Networking.NetBuffer
struct  NetBuffer_t3875182795  : public Il2CppObject
{
public:
	// System.Byte[] UnityEngine.Networking.NetBuffer::m_Buffer
	ByteU5BU5D_t3397334013* ___m_Buffer_0;
	// System.UInt32 UnityEngine.Networking.NetBuffer::m_Pos
	uint32_t ___m_Pos_1;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NetBuffer_t3875182795, ___m_Buffer_0)); }
	inline ByteU5BU5D_t3397334013* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(ByteU5BU5D_t3397334013* value)
	{
		___m_Buffer_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_Buffer_0, value);
	}

	inline static int32_t get_offset_of_m_Pos_1() { return static_cast<int32_t>(offsetof(NetBuffer_t3875182795, ___m_Pos_1)); }
	inline uint32_t get_m_Pos_1() const { return ___m_Pos_1; }
	inline uint32_t* get_address_of_m_Pos_1() { return &___m_Pos_1; }
	inline void set_m_Pos_1(uint32_t value)
	{
		___m_Pos_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
