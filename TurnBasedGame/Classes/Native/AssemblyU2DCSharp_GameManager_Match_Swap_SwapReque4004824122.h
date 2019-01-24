#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameManager.Match.Swap.SwapRequest/State>
struct VP_1_t304490277;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<GamePlayer/Inform>
struct VP_1_t92972119;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequest
struct  SwapRequest_t4004824122  : public Data_t3569509720
{
public:
	// VP`1<GameManager.Match.Swap.SwapRequest/State> GameManager.Match.Swap.SwapRequest::state
	VP_1_t304490277 * ___state_5;
	// VP`1<System.Int32> GameManager.Match.Swap.SwapRequest::teamIndex
	VP_1_t2450154454 * ___teamIndex_6;
	// VP`1<System.Int32> GameManager.Match.Swap.SwapRequest::playerIndex
	VP_1_t2450154454 * ___playerIndex_7;
	// VP`1<GamePlayer/Inform> GameManager.Match.Swap.SwapRequest::inform
	VP_1_t92972119 * ___inform_8;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(SwapRequest_t4004824122, ___state_5)); }
	inline VP_1_t304490277 * get_state_5() const { return ___state_5; }
	inline VP_1_t304490277 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t304490277 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_teamIndex_6() { return static_cast<int32_t>(offsetof(SwapRequest_t4004824122, ___teamIndex_6)); }
	inline VP_1_t2450154454 * get_teamIndex_6() const { return ___teamIndex_6; }
	inline VP_1_t2450154454 ** get_address_of_teamIndex_6() { return &___teamIndex_6; }
	inline void set_teamIndex_6(VP_1_t2450154454 * value)
	{
		___teamIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndex_6, value);
	}

	inline static int32_t get_offset_of_playerIndex_7() { return static_cast<int32_t>(offsetof(SwapRequest_t4004824122, ___playerIndex_7)); }
	inline VP_1_t2450154454 * get_playerIndex_7() const { return ___playerIndex_7; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_7() { return &___playerIndex_7; }
	inline void set_playerIndex_7(VP_1_t2450154454 * value)
	{
		___playerIndex_7 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_7, value);
	}

	inline static int32_t get_offset_of_inform_8() { return static_cast<int32_t>(offsetof(SwapRequest_t4004824122, ___inform_8)); }
	inline VP_1_t92972119 * get_inform_8() const { return ___inform_8; }
	inline VP_1_t92972119 ** get_address_of_inform_8() { return &___inform_8; }
	inline void set_inform_8(VP_1_t92972119 * value)
	{
		___inform_8 = value;
		Il2CppCodeGenWriteBarrier(&___inform_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
