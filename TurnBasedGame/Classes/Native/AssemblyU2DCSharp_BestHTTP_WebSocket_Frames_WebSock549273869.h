#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_WebSocket_Frames_WebSoc3499449257.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.WebSocket.Frames.WebSocketFrameReader
struct  WebSocketFrameReader_t549273869  : public Il2CppObject
{
public:
	// System.Boolean BestHTTP.WebSocket.Frames.WebSocketFrameReader::<IsFinal>k__BackingField
	bool ___U3CIsFinalU3Ek__BackingField_0;
	// BestHTTP.WebSocket.Frames.WebSocketFrameTypes BestHTTP.WebSocket.Frames.WebSocketFrameReader::<Type>k__BackingField
	uint8_t ___U3CTypeU3Ek__BackingField_1;
	// System.Boolean BestHTTP.WebSocket.Frames.WebSocketFrameReader::<HasMask>k__BackingField
	bool ___U3CHasMaskU3Ek__BackingField_2;
	// System.UInt64 BestHTTP.WebSocket.Frames.WebSocketFrameReader::<Length>k__BackingField
	uint64_t ___U3CLengthU3Ek__BackingField_3;
	// System.Byte[] BestHTTP.WebSocket.Frames.WebSocketFrameReader::<Mask>k__BackingField
	ByteU5BU5D_t3397334013* ___U3CMaskU3Ek__BackingField_4;
	// System.Byte[] BestHTTP.WebSocket.Frames.WebSocketFrameReader::<Data>k__BackingField
	ByteU5BU5D_t3397334013* ___U3CDataU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_U3CIsFinalU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(WebSocketFrameReader_t549273869, ___U3CIsFinalU3Ek__BackingField_0)); }
	inline bool get_U3CIsFinalU3Ek__BackingField_0() const { return ___U3CIsFinalU3Ek__BackingField_0; }
	inline bool* get_address_of_U3CIsFinalU3Ek__BackingField_0() { return &___U3CIsFinalU3Ek__BackingField_0; }
	inline void set_U3CIsFinalU3Ek__BackingField_0(bool value)
	{
		___U3CIsFinalU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CTypeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(WebSocketFrameReader_t549273869, ___U3CTypeU3Ek__BackingField_1)); }
	inline uint8_t get_U3CTypeU3Ek__BackingField_1() const { return ___U3CTypeU3Ek__BackingField_1; }
	inline uint8_t* get_address_of_U3CTypeU3Ek__BackingField_1() { return &___U3CTypeU3Ek__BackingField_1; }
	inline void set_U3CTypeU3Ek__BackingField_1(uint8_t value)
	{
		___U3CTypeU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CHasMaskU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(WebSocketFrameReader_t549273869, ___U3CHasMaskU3Ek__BackingField_2)); }
	inline bool get_U3CHasMaskU3Ek__BackingField_2() const { return ___U3CHasMaskU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CHasMaskU3Ek__BackingField_2() { return &___U3CHasMaskU3Ek__BackingField_2; }
	inline void set_U3CHasMaskU3Ek__BackingField_2(bool value)
	{
		___U3CHasMaskU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CLengthU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(WebSocketFrameReader_t549273869, ___U3CLengthU3Ek__BackingField_3)); }
	inline uint64_t get_U3CLengthU3Ek__BackingField_3() const { return ___U3CLengthU3Ek__BackingField_3; }
	inline uint64_t* get_address_of_U3CLengthU3Ek__BackingField_3() { return &___U3CLengthU3Ek__BackingField_3; }
	inline void set_U3CLengthU3Ek__BackingField_3(uint64_t value)
	{
		___U3CLengthU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CMaskU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(WebSocketFrameReader_t549273869, ___U3CMaskU3Ek__BackingField_4)); }
	inline ByteU5BU5D_t3397334013* get_U3CMaskU3Ek__BackingField_4() const { return ___U3CMaskU3Ek__BackingField_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_U3CMaskU3Ek__BackingField_4() { return &___U3CMaskU3Ek__BackingField_4; }
	inline void set_U3CMaskU3Ek__BackingField_4(ByteU5BU5D_t3397334013* value)
	{
		___U3CMaskU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMaskU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CDataU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(WebSocketFrameReader_t549273869, ___U3CDataU3Ek__BackingField_5)); }
	inline ByteU5BU5D_t3397334013* get_U3CDataU3Ek__BackingField_5() const { return ___U3CDataU3Ek__BackingField_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_U3CDataU3Ek__BackingField_5() { return &___U3CDataU3Ek__BackingField_5; }
	inline void set_U3CDataU3Ek__BackingField_5(ByteU5BU5D_t3397334013* value)
	{
		___U3CDataU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDataU3Ek__BackingField_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
