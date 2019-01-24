#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"

// System.String
struct String_t;
// UnityEngine.Networking.NetworkSystem.PeerInfoPlayer[]
struct PeerInfoPlayerU5BU5D_t1632998306;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.PeerInfoMessage
struct  PeerInfoMessage_t4070066639  : public MessageBase_t2552428296
{
public:
	// System.Int32 UnityEngine.Networking.NetworkSystem.PeerInfoMessage::connectionId
	int32_t ___connectionId_0;
	// System.String UnityEngine.Networking.NetworkSystem.PeerInfoMessage::address
	String_t* ___address_1;
	// System.Int32 UnityEngine.Networking.NetworkSystem.PeerInfoMessage::port
	int32_t ___port_2;
	// System.Boolean UnityEngine.Networking.NetworkSystem.PeerInfoMessage::isHost
	bool ___isHost_3;
	// System.Boolean UnityEngine.Networking.NetworkSystem.PeerInfoMessage::isYou
	bool ___isYou_4;
	// UnityEngine.Networking.NetworkSystem.PeerInfoPlayer[] UnityEngine.Networking.NetworkSystem.PeerInfoMessage::playerIds
	PeerInfoPlayerU5BU5D_t1632998306* ___playerIds_5;

public:
	inline static int32_t get_offset_of_connectionId_0() { return static_cast<int32_t>(offsetof(PeerInfoMessage_t4070066639, ___connectionId_0)); }
	inline int32_t get_connectionId_0() const { return ___connectionId_0; }
	inline int32_t* get_address_of_connectionId_0() { return &___connectionId_0; }
	inline void set_connectionId_0(int32_t value)
	{
		___connectionId_0 = value;
	}

	inline static int32_t get_offset_of_address_1() { return static_cast<int32_t>(offsetof(PeerInfoMessage_t4070066639, ___address_1)); }
	inline String_t* get_address_1() const { return ___address_1; }
	inline String_t** get_address_of_address_1() { return &___address_1; }
	inline void set_address_1(String_t* value)
	{
		___address_1 = value;
		Il2CppCodeGenWriteBarrier(&___address_1, value);
	}

	inline static int32_t get_offset_of_port_2() { return static_cast<int32_t>(offsetof(PeerInfoMessage_t4070066639, ___port_2)); }
	inline int32_t get_port_2() const { return ___port_2; }
	inline int32_t* get_address_of_port_2() { return &___port_2; }
	inline void set_port_2(int32_t value)
	{
		___port_2 = value;
	}

	inline static int32_t get_offset_of_isHost_3() { return static_cast<int32_t>(offsetof(PeerInfoMessage_t4070066639, ___isHost_3)); }
	inline bool get_isHost_3() const { return ___isHost_3; }
	inline bool* get_address_of_isHost_3() { return &___isHost_3; }
	inline void set_isHost_3(bool value)
	{
		___isHost_3 = value;
	}

	inline static int32_t get_offset_of_isYou_4() { return static_cast<int32_t>(offsetof(PeerInfoMessage_t4070066639, ___isYou_4)); }
	inline bool get_isYou_4() const { return ___isYou_4; }
	inline bool* get_address_of_isYou_4() { return &___isYou_4; }
	inline void set_isYou_4(bool value)
	{
		___isYou_4 = value;
	}

	inline static int32_t get_offset_of_playerIds_5() { return static_cast<int32_t>(offsetof(PeerInfoMessage_t4070066639, ___playerIds_5)); }
	inline PeerInfoPlayerU5BU5D_t1632998306* get_playerIds_5() const { return ___playerIds_5; }
	inline PeerInfoPlayerU5BU5D_t1632998306** get_address_of_playerIds_5() { return &___playerIds_5; }
	inline void set_playerIds_5(PeerInfoPlayerU5BU5D_t1632998306* value)
	{
		___playerIds_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerIds_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
