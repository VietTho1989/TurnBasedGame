#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1948911764.h"

// GameManager.Match.ContestManagerStateLobbyUI
struct ContestManagerStateLobbyUI_t1791232428;
// GameManager.Match.ContestManagerStatePlayUI
struct ContestManagerStatePlayUI_t2885588566;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerUI
struct  ContestManagerUI_t3270692713  : public UIBehavior_1_t1948911764
{
public:
	// GameManager.Match.ContestManagerStateLobbyUI GameManager.Match.ContestManagerUI::lobbyPrefab
	ContestManagerStateLobbyUI_t1791232428 * ___lobbyPrefab_6;
	// GameManager.Match.ContestManagerStatePlayUI GameManager.Match.ContestManagerUI::playPrefab
	ContestManagerStatePlayUI_t2885588566 * ___playPrefab_7;

public:
	inline static int32_t get_offset_of_lobbyPrefab_6() { return static_cast<int32_t>(offsetof(ContestManagerUI_t3270692713, ___lobbyPrefab_6)); }
	inline ContestManagerStateLobbyUI_t1791232428 * get_lobbyPrefab_6() const { return ___lobbyPrefab_6; }
	inline ContestManagerStateLobbyUI_t1791232428 ** get_address_of_lobbyPrefab_6() { return &___lobbyPrefab_6; }
	inline void set_lobbyPrefab_6(ContestManagerStateLobbyUI_t1791232428 * value)
	{
		___lobbyPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPrefab_6, value);
	}

	inline static int32_t get_offset_of_playPrefab_7() { return static_cast<int32_t>(offsetof(ContestManagerUI_t3270692713, ___playPrefab_7)); }
	inline ContestManagerStatePlayUI_t2885588566 * get_playPrefab_7() const { return ___playPrefab_7; }
	inline ContestManagerStatePlayUI_t2885588566 ** get_address_of_playPrefab_7() { return &___playPrefab_7; }
	inline void set_playPrefab_7(ContestManagerStatePlayUI_t2885588566 * value)
	{
		___playPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___playPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
