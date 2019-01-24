#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// GameManager.Match.Elimination.RequestNewEliminationRoundStateAccept
struct RequestNewEliminationRoundStateAccept_t636882161;
// GameManager.Match.Elimination.EliminationContent
struct EliminationContent_t2343844232;
// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationRoundCheckChange`1<GameManager.Match.Elimination.RequestNewEliminationRoundStateAccept>
struct  EliminationRoundCheckChange_1_t3192575260  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.Elimination.EliminationRoundCheckChange`1::change
	VP_1_t2450154454 * ___change_5;
	// K GameManager.Match.Elimination.EliminationRoundCheckChange`1::data
	RequestNewEliminationRoundStateAccept_t636882161 * ___data_6;
	// GameManager.Match.Elimination.EliminationContent GameManager.Match.Elimination.EliminationRoundCheckChange`1::eliminationContent
	EliminationContent_t2343844232 * ___eliminationContent_7;
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.Elimination.EliminationRoundCheckChange`1::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_8;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(EliminationRoundCheckChange_1_t3192575260, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(EliminationRoundCheckChange_1_t3192575260, ___data_6)); }
	inline RequestNewEliminationRoundStateAccept_t636882161 * get_data_6() const { return ___data_6; }
	inline RequestNewEliminationRoundStateAccept_t636882161 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(RequestNewEliminationRoundStateAccept_t636882161 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_eliminationContent_7() { return static_cast<int32_t>(offsetof(EliminationRoundCheckChange_1_t3192575260, ___eliminationContent_7)); }
	inline EliminationContent_t2343844232 * get_eliminationContent_7() const { return ___eliminationContent_7; }
	inline EliminationContent_t2343844232 ** get_address_of_eliminationContent_7() { return &___eliminationContent_7; }
	inline void set_eliminationContent_7(EliminationContent_t2343844232 * value)
	{
		___eliminationContent_7 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationContent_7, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlay_8() { return static_cast<int32_t>(offsetof(EliminationRoundCheckChange_1_t3192575260, ___contestManagerStatePlay_8)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_8() const { return ___contestManagerStatePlay_8; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_8() { return &___contestManagerStatePlay_8; }
	inline void set_contestManagerStatePlay_8(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_8 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
