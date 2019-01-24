#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"

// ServerManager
struct ServerManager_t3491151942;
// UnityEngine.Networking.NetworkIdentity
struct NetworkIdentity_t1766639790;
// DataIdentity
struct DataIdentity_t543951486;
// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection>
struct List_1_t3771356334;
// ObserverController
struct ObserverController_t919277822;
// GameObserver/CheckChange
struct CheckChange_t811089867;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameObserver
struct  GameObserver_t741476472  : public NetworkBehaviour_t3873055601
{
public:
	// ServerManager GameObserver::ServerManager
	ServerManager_t3491151942 * ___ServerManager_8;
	// UnityEngine.Networking.NetworkIdentity GameObserver::Identity
	NetworkIdentity_t1766639790 * ___Identity_9;
	// DataIdentity GameObserver::DataIdentity
	DataIdentity_t543951486 * ___DataIdentity_10;
	// System.Boolean GameObserver::dirty
	bool ___dirty_11;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> GameObserver::allConnections
	List_1_t3771356334 * ___allConnections_12;
	// System.Boolean GameObserver::needRefresh
	bool ___needRefresh_13;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> GameObserver::notAddImmediatelyConnections
	List_1_t3771356334 * ___notAddImmediatelyConnections_15;
	// System.Boolean GameObserver::isRebuildingObserver
	bool ___isRebuildingObserver_16;
	// GameObserver/CheckChange GameObserver::checkChange
	CheckChange_t811089867 * ___checkChange_17;

public:
	inline static int32_t get_offset_of_ServerManager_8() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___ServerManager_8)); }
	inline ServerManager_t3491151942 * get_ServerManager_8() const { return ___ServerManager_8; }
	inline ServerManager_t3491151942 ** get_address_of_ServerManager_8() { return &___ServerManager_8; }
	inline void set_ServerManager_8(ServerManager_t3491151942 * value)
	{
		___ServerManager_8 = value;
		Il2CppCodeGenWriteBarrier(&___ServerManager_8, value);
	}

	inline static int32_t get_offset_of_Identity_9() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___Identity_9)); }
	inline NetworkIdentity_t1766639790 * get_Identity_9() const { return ___Identity_9; }
	inline NetworkIdentity_t1766639790 ** get_address_of_Identity_9() { return &___Identity_9; }
	inline void set_Identity_9(NetworkIdentity_t1766639790 * value)
	{
		___Identity_9 = value;
		Il2CppCodeGenWriteBarrier(&___Identity_9, value);
	}

	inline static int32_t get_offset_of_DataIdentity_10() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___DataIdentity_10)); }
	inline DataIdentity_t543951486 * get_DataIdentity_10() const { return ___DataIdentity_10; }
	inline DataIdentity_t543951486 ** get_address_of_DataIdentity_10() { return &___DataIdentity_10; }
	inline void set_DataIdentity_10(DataIdentity_t543951486 * value)
	{
		___DataIdentity_10 = value;
		Il2CppCodeGenWriteBarrier(&___DataIdentity_10, value);
	}

	inline static int32_t get_offset_of_dirty_11() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___dirty_11)); }
	inline bool get_dirty_11() const { return ___dirty_11; }
	inline bool* get_address_of_dirty_11() { return &___dirty_11; }
	inline void set_dirty_11(bool value)
	{
		___dirty_11 = value;
	}

	inline static int32_t get_offset_of_allConnections_12() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___allConnections_12)); }
	inline List_1_t3771356334 * get_allConnections_12() const { return ___allConnections_12; }
	inline List_1_t3771356334 ** get_address_of_allConnections_12() { return &___allConnections_12; }
	inline void set_allConnections_12(List_1_t3771356334 * value)
	{
		___allConnections_12 = value;
		Il2CppCodeGenWriteBarrier(&___allConnections_12, value);
	}

	inline static int32_t get_offset_of_needRefresh_13() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___needRefresh_13)); }
	inline bool get_needRefresh_13() const { return ___needRefresh_13; }
	inline bool* get_address_of_needRefresh_13() { return &___needRefresh_13; }
	inline void set_needRefresh_13(bool value)
	{
		___needRefresh_13 = value;
	}

	inline static int32_t get_offset_of_notAddImmediatelyConnections_15() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___notAddImmediatelyConnections_15)); }
	inline List_1_t3771356334 * get_notAddImmediatelyConnections_15() const { return ___notAddImmediatelyConnections_15; }
	inline List_1_t3771356334 ** get_address_of_notAddImmediatelyConnections_15() { return &___notAddImmediatelyConnections_15; }
	inline void set_notAddImmediatelyConnections_15(List_1_t3771356334 * value)
	{
		___notAddImmediatelyConnections_15 = value;
		Il2CppCodeGenWriteBarrier(&___notAddImmediatelyConnections_15, value);
	}

	inline static int32_t get_offset_of_isRebuildingObserver_16() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___isRebuildingObserver_16)); }
	inline bool get_isRebuildingObserver_16() const { return ___isRebuildingObserver_16; }
	inline bool* get_address_of_isRebuildingObserver_16() { return &___isRebuildingObserver_16; }
	inline void set_isRebuildingObserver_16(bool value)
	{
		___isRebuildingObserver_16 = value;
	}

	inline static int32_t get_offset_of_checkChange_17() { return static_cast<int32_t>(offsetof(GameObserver_t741476472, ___checkChange_17)); }
	inline CheckChange_t811089867 * get_checkChange_17() const { return ___checkChange_17; }
	inline CheckChange_t811089867 ** get_address_of_checkChange_17() { return &___checkChange_17; }
	inline void set_checkChange_17(CheckChange_t811089867 * value)
	{
		___checkChange_17 = value;
		Il2CppCodeGenWriteBarrier(&___checkChange_17, value);
	}
};

struct GameObserver_t741476472_StaticFields
{
public:
	// ObserverController GameObserver::Controller
	ObserverController_t919277822 * ___Controller_14;

public:
	inline static int32_t get_offset_of_Controller_14() { return static_cast<int32_t>(offsetof(GameObserver_t741476472_StaticFields, ___Controller_14)); }
	inline ObserverController_t919277822 * get_Controller_14() const { return ___Controller_14; }
	inline ObserverController_t919277822 ** get_address_of_Controller_14() { return &___Controller_14; }
	inline void set_Controller_14(ObserverController_t919277822 * value)
	{
		___Controller_14 = value;
		Il2CppCodeGenWriteBarrier(&___Controller_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
