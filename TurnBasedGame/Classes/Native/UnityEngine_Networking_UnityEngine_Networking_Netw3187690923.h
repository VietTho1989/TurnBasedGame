#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Networking.NetBuffer
struct NetBuffer_t3875182795;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Text.Encoding
struct Encoding_t663144255;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkReader
struct  NetworkReader_t3187690923  : public Il2CppObject
{
public:
	// UnityEngine.Networking.NetBuffer UnityEngine.Networking.NetworkReader::m_buf
	NetBuffer_t3875182795 * ___m_buf_0;

public:
	inline static int32_t get_offset_of_m_buf_0() { return static_cast<int32_t>(offsetof(NetworkReader_t3187690923, ___m_buf_0)); }
	inline NetBuffer_t3875182795 * get_m_buf_0() const { return ___m_buf_0; }
	inline NetBuffer_t3875182795 ** get_address_of_m_buf_0() { return &___m_buf_0; }
	inline void set_m_buf_0(NetBuffer_t3875182795 * value)
	{
		___m_buf_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_buf_0, value);
	}
};

struct NetworkReader_t3187690923_StaticFields
{
public:
	// System.Byte[] UnityEngine.Networking.NetworkReader::s_StringReaderBuffer
	ByteU5BU5D_t3397334013* ___s_StringReaderBuffer_3;
	// System.Text.Encoding UnityEngine.Networking.NetworkReader::s_Encoding
	Encoding_t663144255 * ___s_Encoding_4;

public:
	inline static int32_t get_offset_of_s_StringReaderBuffer_3() { return static_cast<int32_t>(offsetof(NetworkReader_t3187690923_StaticFields, ___s_StringReaderBuffer_3)); }
	inline ByteU5BU5D_t3397334013* get_s_StringReaderBuffer_3() const { return ___s_StringReaderBuffer_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_s_StringReaderBuffer_3() { return &___s_StringReaderBuffer_3; }
	inline void set_s_StringReaderBuffer_3(ByteU5BU5D_t3397334013* value)
	{
		___s_StringReaderBuffer_3 = value;
		Il2CppCodeGenWriteBarrier(&___s_StringReaderBuffer_3, value);
	}

	inline static int32_t get_offset_of_s_Encoding_4() { return static_cast<int32_t>(offsetof(NetworkReader_t3187690923_StaticFields, ___s_Encoding_4)); }
	inline Encoding_t663144255 * get_s_Encoding_4() const { return ___s_Encoding_4; }
	inline Encoding_t663144255 ** get_address_of_s_Encoding_4() { return &___s_Encoding_4; }
	inline void set_s_Encoding_4(Encoding_t663144255 * value)
	{
		___s_Encoding_4 = value;
		Il2CppCodeGenWriteBarrier(&___s_Encoding_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
