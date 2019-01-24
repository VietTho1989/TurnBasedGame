#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_t107267906;
// UnityEngine.Networking.NetworkReader
struct NetworkReader_t3187690923;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkMessage
struct  NetworkMessage_t2339216573  : public Il2CppObject
{
public:
	// System.Int16 UnityEngine.Networking.NetworkMessage::msgType
	int16_t ___msgType_1;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkMessage::conn
	NetworkConnection_t107267906 * ___conn_2;
	// UnityEngine.Networking.NetworkReader UnityEngine.Networking.NetworkMessage::reader
	NetworkReader_t3187690923 * ___reader_3;
	// System.Int32 UnityEngine.Networking.NetworkMessage::channelId
	int32_t ___channelId_4;

public:
	inline static int32_t get_offset_of_msgType_1() { return static_cast<int32_t>(offsetof(NetworkMessage_t2339216573, ___msgType_1)); }
	inline int16_t get_msgType_1() const { return ___msgType_1; }
	inline int16_t* get_address_of_msgType_1() { return &___msgType_1; }
	inline void set_msgType_1(int16_t value)
	{
		___msgType_1 = value;
	}

	inline static int32_t get_offset_of_conn_2() { return static_cast<int32_t>(offsetof(NetworkMessage_t2339216573, ___conn_2)); }
	inline NetworkConnection_t107267906 * get_conn_2() const { return ___conn_2; }
	inline NetworkConnection_t107267906 ** get_address_of_conn_2() { return &___conn_2; }
	inline void set_conn_2(NetworkConnection_t107267906 * value)
	{
		___conn_2 = value;
		Il2CppCodeGenWriteBarrier(&___conn_2, value);
	}

	inline static int32_t get_offset_of_reader_3() { return static_cast<int32_t>(offsetof(NetworkMessage_t2339216573, ___reader_3)); }
	inline NetworkReader_t3187690923 * get_reader_3() const { return ___reader_3; }
	inline NetworkReader_t3187690923 ** get_address_of_reader_3() { return &___reader_3; }
	inline void set_reader_3(NetworkReader_t3187690923 * value)
	{
		___reader_3 = value;
		Il2CppCodeGenWriteBarrier(&___reader_3, value);
	}

	inline static int32_t get_offset_of_channelId_4() { return static_cast<int32_t>(offsetof(NetworkMessage_t2339216573, ___channelId_4)); }
	inline int32_t get_channelId_4() const { return ___channelId_4; }
	inline int32_t* get_address_of_channelId_4() { return &___channelId_4; }
	inline void set_channelId_4(int32_t value)
	{
		___channelId_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
