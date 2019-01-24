#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkLobbyPlayer
struct  NetworkLobbyPlayer_t2123032571  : public NetworkBehaviour_t3873055601
{
public:
	// System.Boolean UnityEngine.Networking.NetworkLobbyPlayer::ShowLobbyGUI
	bool ___ShowLobbyGUI_8;
	// System.Byte UnityEngine.Networking.NetworkLobbyPlayer::m_Slot
	uint8_t ___m_Slot_9;
	// System.Boolean UnityEngine.Networking.NetworkLobbyPlayer::m_ReadyToBegin
	bool ___m_ReadyToBegin_10;

public:
	inline static int32_t get_offset_of_ShowLobbyGUI_8() { return static_cast<int32_t>(offsetof(NetworkLobbyPlayer_t2123032571, ___ShowLobbyGUI_8)); }
	inline bool get_ShowLobbyGUI_8() const { return ___ShowLobbyGUI_8; }
	inline bool* get_address_of_ShowLobbyGUI_8() { return &___ShowLobbyGUI_8; }
	inline void set_ShowLobbyGUI_8(bool value)
	{
		___ShowLobbyGUI_8 = value;
	}

	inline static int32_t get_offset_of_m_Slot_9() { return static_cast<int32_t>(offsetof(NetworkLobbyPlayer_t2123032571, ___m_Slot_9)); }
	inline uint8_t get_m_Slot_9() const { return ___m_Slot_9; }
	inline uint8_t* get_address_of_m_Slot_9() { return &___m_Slot_9; }
	inline void set_m_Slot_9(uint8_t value)
	{
		___m_Slot_9 = value;
	}

	inline static int32_t get_offset_of_m_ReadyToBegin_10() { return static_cast<int32_t>(offsetof(NetworkLobbyPlayer_t2123032571, ___m_ReadyToBegin_10)); }
	inline bool get_m_ReadyToBegin_10() const { return ___m_ReadyToBegin_10; }
	inline bool* get_address_of_m_ReadyToBegin_10() { return &___m_ReadyToBegin_10; }
	inline void set_m_ReadyToBegin_10(bool value)
	{
		___m_ReadyToBegin_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
