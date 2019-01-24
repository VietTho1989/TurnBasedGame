#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen315072958.h"

// MainUI/UIData
struct UIData_t1030998106;
// HomeUI
struct HomeUI_t337398877;
// PlayOnlineUI
struct PlayOnlineUI_t1758335677;
// OfflineUI
struct OfflineUI_t3418852663;
// LanUI
struct LanUI_t2500194061;
// LoadDataUI
struct LoadDataUI_t4137862618;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MainUI
struct  MainUI_t541415437  : public UIBehavior_1_t315072958
{
public:
	// MainUI/UIData MainUI::uiData
	UIData_t1030998106 * ___uiData_6;
	// HomeUI MainUI::homePrefab
	HomeUI_t337398877 * ___homePrefab_7;
	// PlayOnlineUI MainUI::playOnlinePrefab
	PlayOnlineUI_t1758335677 * ___playOnlinePrefab_8;
	// OfflineUI MainUI::playOfflinePrefab
	OfflineUI_t3418852663 * ___playOfflinePrefab_9;
	// LanUI MainUI::lanPrefab
	LanUI_t2500194061 * ___lanPrefab_10;
	// LoadDataUI MainUI::loadDataPrefab
	LoadDataUI_t4137862618 * ___loadDataPrefab_11;

public:
	inline static int32_t get_offset_of_uiData_6() { return static_cast<int32_t>(offsetof(MainUI_t541415437, ___uiData_6)); }
	inline UIData_t1030998106 * get_uiData_6() const { return ___uiData_6; }
	inline UIData_t1030998106 ** get_address_of_uiData_6() { return &___uiData_6; }
	inline void set_uiData_6(UIData_t1030998106 * value)
	{
		___uiData_6 = value;
		Il2CppCodeGenWriteBarrier(&___uiData_6, value);
	}

	inline static int32_t get_offset_of_homePrefab_7() { return static_cast<int32_t>(offsetof(MainUI_t541415437, ___homePrefab_7)); }
	inline HomeUI_t337398877 * get_homePrefab_7() const { return ___homePrefab_7; }
	inline HomeUI_t337398877 ** get_address_of_homePrefab_7() { return &___homePrefab_7; }
	inline void set_homePrefab_7(HomeUI_t337398877 * value)
	{
		___homePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___homePrefab_7, value);
	}

	inline static int32_t get_offset_of_playOnlinePrefab_8() { return static_cast<int32_t>(offsetof(MainUI_t541415437, ___playOnlinePrefab_8)); }
	inline PlayOnlineUI_t1758335677 * get_playOnlinePrefab_8() const { return ___playOnlinePrefab_8; }
	inline PlayOnlineUI_t1758335677 ** get_address_of_playOnlinePrefab_8() { return &___playOnlinePrefab_8; }
	inline void set_playOnlinePrefab_8(PlayOnlineUI_t1758335677 * value)
	{
		___playOnlinePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___playOnlinePrefab_8, value);
	}

	inline static int32_t get_offset_of_playOfflinePrefab_9() { return static_cast<int32_t>(offsetof(MainUI_t541415437, ___playOfflinePrefab_9)); }
	inline OfflineUI_t3418852663 * get_playOfflinePrefab_9() const { return ___playOfflinePrefab_9; }
	inline OfflineUI_t3418852663 ** get_address_of_playOfflinePrefab_9() { return &___playOfflinePrefab_9; }
	inline void set_playOfflinePrefab_9(OfflineUI_t3418852663 * value)
	{
		___playOfflinePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___playOfflinePrefab_9, value);
	}

	inline static int32_t get_offset_of_lanPrefab_10() { return static_cast<int32_t>(offsetof(MainUI_t541415437, ___lanPrefab_10)); }
	inline LanUI_t2500194061 * get_lanPrefab_10() const { return ___lanPrefab_10; }
	inline LanUI_t2500194061 ** get_address_of_lanPrefab_10() { return &___lanPrefab_10; }
	inline void set_lanPrefab_10(LanUI_t2500194061 * value)
	{
		___lanPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___lanPrefab_10, value);
	}

	inline static int32_t get_offset_of_loadDataPrefab_11() { return static_cast<int32_t>(offsetof(MainUI_t541415437, ___loadDataPrefab_11)); }
	inline LoadDataUI_t4137862618 * get_loadDataPrefab_11() const { return ___loadDataPrefab_11; }
	inline LoadDataUI_t4137862618 ** get_address_of_loadDataPrefab_11() { return &___loadDataPrefab_11; }
	inline void set_loadDataPrefab_11(LoadDataUI_t4137862618 * value)
	{
		___loadDataPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___loadDataPrefab_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
