#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Networking.NetworkManager
struct NetworkManager_t3335581469;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkManagerHUD
struct  NetworkManagerHUD_t1541348254  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Networking.NetworkManager UnityEngine.Networking.NetworkManagerHUD::manager
	NetworkManager_t3335581469 * ___manager_2;
	// System.Boolean UnityEngine.Networking.NetworkManagerHUD::showGUI
	bool ___showGUI_3;
	// System.Int32 UnityEngine.Networking.NetworkManagerHUD::offsetX
	int32_t ___offsetX_4;
	// System.Int32 UnityEngine.Networking.NetworkManagerHUD::offsetY
	int32_t ___offsetY_5;
	// System.Boolean UnityEngine.Networking.NetworkManagerHUD::m_ShowServer
	bool ___m_ShowServer_6;

public:
	inline static int32_t get_offset_of_manager_2() { return static_cast<int32_t>(offsetof(NetworkManagerHUD_t1541348254, ___manager_2)); }
	inline NetworkManager_t3335581469 * get_manager_2() const { return ___manager_2; }
	inline NetworkManager_t3335581469 ** get_address_of_manager_2() { return &___manager_2; }
	inline void set_manager_2(NetworkManager_t3335581469 * value)
	{
		___manager_2 = value;
		Il2CppCodeGenWriteBarrier(&___manager_2, value);
	}

	inline static int32_t get_offset_of_showGUI_3() { return static_cast<int32_t>(offsetof(NetworkManagerHUD_t1541348254, ___showGUI_3)); }
	inline bool get_showGUI_3() const { return ___showGUI_3; }
	inline bool* get_address_of_showGUI_3() { return &___showGUI_3; }
	inline void set_showGUI_3(bool value)
	{
		___showGUI_3 = value;
	}

	inline static int32_t get_offset_of_offsetX_4() { return static_cast<int32_t>(offsetof(NetworkManagerHUD_t1541348254, ___offsetX_4)); }
	inline int32_t get_offsetX_4() const { return ___offsetX_4; }
	inline int32_t* get_address_of_offsetX_4() { return &___offsetX_4; }
	inline void set_offsetX_4(int32_t value)
	{
		___offsetX_4 = value;
	}

	inline static int32_t get_offset_of_offsetY_5() { return static_cast<int32_t>(offsetof(NetworkManagerHUD_t1541348254, ___offsetY_5)); }
	inline int32_t get_offsetY_5() const { return ___offsetY_5; }
	inline int32_t* get_address_of_offsetY_5() { return &___offsetY_5; }
	inline void set_offsetY_5(int32_t value)
	{
		___offsetY_5 = value;
	}

	inline static int32_t get_offset_of_m_ShowServer_6() { return static_cast<int32_t>(offsetof(NetworkManagerHUD_t1541348254, ___m_ShowServer_6)); }
	inline bool get_m_ShowServer_6() const { return ___m_ShowServer_6; }
	inline bool* get_address_of_m_ShowServer_6() { return &___m_ShowServer_6; }
	inline void set_m_ShowServer_6(bool value)
	{
		___m_ShowServer_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
