#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2270543.h"

// AccountAvatarUI
struct AccountAvatarUI_t3584502088;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanAvatarUI
struct  HumanAvatarUI_t705612314  : public UIBehavior_1_t2270543
{
public:
	// AccountAvatarUI HumanAvatarUI::avatarPrefab
	AccountAvatarUI_t3584502088 * ___avatarPrefab_6;

public:
	inline static int32_t get_offset_of_avatarPrefab_6() { return static_cast<int32_t>(offsetof(HumanAvatarUI_t705612314, ___avatarPrefab_6)); }
	inline AccountAvatarUI_t3584502088 * get_avatarPrefab_6() const { return ___avatarPrefab_6; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_avatarPrefab_6() { return &___avatarPrefab_6; }
	inline void set_avatarPrefab_6(AccountAvatarUI_t3584502088 * value)
	{
		___avatarPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
