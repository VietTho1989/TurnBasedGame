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

// BestHTTP.WebSocket.Frames.WebSocketBinaryFrame
struct  WebSocketBinaryFrame_t1362129157  : public Il2CppObject
{
public:
	// System.Boolean BestHTTP.WebSocket.Frames.WebSocketBinaryFrame::<IsFinal>k__BackingField
	bool ___U3CIsFinalU3Ek__BackingField_1;
	// System.Byte[] BestHTTP.WebSocket.Frames.WebSocketBinaryFrame::<Data>k__BackingField
	ByteU5BU5D_t3397334013* ___U3CDataU3Ek__BackingField_2;
	// System.UInt64 BestHTTP.WebSocket.Frames.WebSocketBinaryFrame::<Pos>k__BackingField
	uint64_t ___U3CPosU3Ek__BackingField_3;
	// System.UInt64 BestHTTP.WebSocket.Frames.WebSocketBinaryFrame::<Length>k__BackingField
	uint64_t ___U3CLengthU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_U3CIsFinalU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(WebSocketBinaryFrame_t1362129157, ___U3CIsFinalU3Ek__BackingField_1)); }
	inline bool get_U3CIsFinalU3Ek__BackingField_1() const { return ___U3CIsFinalU3Ek__BackingField_1; }
	inline bool* get_address_of_U3CIsFinalU3Ek__BackingField_1() { return &___U3CIsFinalU3Ek__BackingField_1; }
	inline void set_U3CIsFinalU3Ek__BackingField_1(bool value)
	{
		___U3CIsFinalU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CDataU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(WebSocketBinaryFrame_t1362129157, ___U3CDataU3Ek__BackingField_2)); }
	inline ByteU5BU5D_t3397334013* get_U3CDataU3Ek__BackingField_2() const { return ___U3CDataU3Ek__BackingField_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_U3CDataU3Ek__BackingField_2() { return &___U3CDataU3Ek__BackingField_2; }
	inline void set_U3CDataU3Ek__BackingField_2(ByteU5BU5D_t3397334013* value)
	{
		___U3CDataU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDataU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CPosU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(WebSocketBinaryFrame_t1362129157, ___U3CPosU3Ek__BackingField_3)); }
	inline uint64_t get_U3CPosU3Ek__BackingField_3() const { return ___U3CPosU3Ek__BackingField_3; }
	inline uint64_t* get_address_of_U3CPosU3Ek__BackingField_3() { return &___U3CPosU3Ek__BackingField_3; }
	inline void set_U3CPosU3Ek__BackingField_3(uint64_t value)
	{
		___U3CPosU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CLengthU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(WebSocketBinaryFrame_t1362129157, ___U3CLengthU3Ek__BackingField_4)); }
	inline uint64_t get_U3CLengthU3Ek__BackingField_4() const { return ___U3CLengthU3Ek__BackingField_4; }
	inline uint64_t* get_address_of_U3CLengthU3Ek__BackingField_4() { return &___U3CLengthU3Ek__BackingField_4; }
	inline void set_U3CLengthU3Ek__BackingField_4(uint64_t value)
	{
		___U3CLengthU3Ek__BackingField_4 = value;
	}
};

struct WebSocketBinaryFrame_t1362129157_StaticFields
{
public:
	// System.Byte[] BestHTTP.WebSocket.Frames.WebSocketBinaryFrame::NoData
	ByteU5BU5D_t3397334013* ___NoData_0;

public:
	inline static int32_t get_offset_of_NoData_0() { return static_cast<int32_t>(offsetof(WebSocketBinaryFrame_t1362129157_StaticFields, ___NoData_0)); }
	inline ByteU5BU5D_t3397334013* get_NoData_0() const { return ___NoData_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_NoData_0() { return &___NoData_0; }
	inline void set_NoData_0(ByteU5BU5D_t3397334013* value)
	{
		___NoData_0 = value;
		Il2CppCodeGenWriteBarrier(&___NoData_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
