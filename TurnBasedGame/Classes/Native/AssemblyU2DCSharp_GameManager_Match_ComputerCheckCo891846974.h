#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1004397070.h"

// GameManager.Match.ContestManagerStateLobby
struct ContestManagerStateLobby_t3432289894;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ComputerCheckCorrectAIUpdate
struct  ComputerCheckCorrectAIUpdate_t891846974  : public UpdateBehavior_1_t1004397070
{
public:
	// GameManager.Match.ContestManagerStateLobby GameManager.Match.ComputerCheckCorrectAIUpdate::contestManagerStateLobby
	ContestManagerStateLobby_t3432289894 * ___contestManagerStateLobby_4;

public:
	inline static int32_t get_offset_of_contestManagerStateLobby_4() { return static_cast<int32_t>(offsetof(ComputerCheckCorrectAIUpdate_t891846974, ___contestManagerStateLobby_4)); }
	inline ContestManagerStateLobby_t3432289894 * get_contestManagerStateLobby_4() const { return ___contestManagerStateLobby_4; }
	inline ContestManagerStateLobby_t3432289894 ** get_address_of_contestManagerStateLobby_4() { return &___contestManagerStateLobby_4; }
	inline void set_contestManagerStateLobby_4(ContestManagerStateLobby_t3432289894 * value)
	{
		___contestManagerStateLobby_4 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStateLobby_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
