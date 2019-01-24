#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1152507854.h"

// GameManager.Match.Elimination.EliminationRoundCheckChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAccept>
struct EliminationRoundCheckChange_1_t3192575260;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.RequestNewEliminationRoundStateAcceptUpdate
struct  RequestNewEliminationRoundStateAcceptUpdate_t4229824404  : public UpdateBehavior_1_t1152507854
{
public:
	// GameManager.Match.Elimination.EliminationRoundCheckChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAccept> GameManager.Match.Elimination.RequestNewEliminationRoundStateAcceptUpdate::eliminationRoundCheckChange
	EliminationRoundCheckChange_1_t3192575260 * ___eliminationRoundCheckChange_4;

public:
	inline static int32_t get_offset_of_eliminationRoundCheckChange_4() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundStateAcceptUpdate_t4229824404, ___eliminationRoundCheckChange_4)); }
	inline EliminationRoundCheckChange_1_t3192575260 * get_eliminationRoundCheckChange_4() const { return ___eliminationRoundCheckChange_4; }
	inline EliminationRoundCheckChange_1_t3192575260 ** get_address_of_eliminationRoundCheckChange_4() { return &___eliminationRoundCheckChange_4; }
	inline void set_eliminationRoundCheckChange_4(EliminationRoundCheckChange_1_t3192575260 * value)
	{
		___eliminationRoundCheckChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRoundCheckChange_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
