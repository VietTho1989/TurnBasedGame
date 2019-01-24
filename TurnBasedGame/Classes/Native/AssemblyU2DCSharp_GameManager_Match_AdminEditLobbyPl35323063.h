#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_AdminEditLobby3879877176.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData/StateRequest
struct  StateRequest_t35323063  : public State_t3879877176
{
public:
	// VP`1<System.UInt32> GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData/StateRequest::humanId
	VP_1_t2527959027 * ___humanId_5;

public:
	inline static int32_t get_offset_of_humanId_5() { return static_cast<int32_t>(offsetof(StateRequest_t35323063, ___humanId_5)); }
	inline VP_1_t2527959027 * get_humanId_5() const { return ___humanId_5; }
	inline VP_1_t2527959027 ** get_address_of_humanId_5() { return &___humanId_5; }
	inline void set_humanId_5(VP_1_t2527959027 * value)
	{
		___humanId_5 = value;
		Il2CppCodeGenWriteBarrier(&___humanId_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
