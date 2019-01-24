#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// System.Collections.Generic.List`1<MoveAnimation>
struct List_1_t2430644793;
// LP`1<AnimationProgress>
struct LP_1_t2431235445;
// VP`1<GameMove>
struct VP_1_t2240176003;
// VP`1<AnimationManager/State>
struct VP_1_t2612219109;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AnimationManager
struct  AnimationManager_t2328214095  : public Data_t3569509720
{
public:
	// System.Collections.Generic.List`1<MoveAnimation> AnimationManager::waitToAddMoveAnimations
	List_1_t2430644793 * ___waitToAddMoveAnimations_6;
	// LP`1<AnimationProgress> AnimationManager::animationProgresses
	LP_1_t2431235445 * ___animationProgresses_7;
	// VP`1<GameMove> AnimationManager::lastMove
	VP_1_t2240176003 * ___lastMove_8;
	// VP`1<AnimationManager/State> AnimationManager::state
	VP_1_t2612219109 * ___state_9;

public:
	inline static int32_t get_offset_of_waitToAddMoveAnimations_6() { return static_cast<int32_t>(offsetof(AnimationManager_t2328214095, ___waitToAddMoveAnimations_6)); }
	inline List_1_t2430644793 * get_waitToAddMoveAnimations_6() const { return ___waitToAddMoveAnimations_6; }
	inline List_1_t2430644793 ** get_address_of_waitToAddMoveAnimations_6() { return &___waitToAddMoveAnimations_6; }
	inline void set_waitToAddMoveAnimations_6(List_1_t2430644793 * value)
	{
		___waitToAddMoveAnimations_6 = value;
		Il2CppCodeGenWriteBarrier(&___waitToAddMoveAnimations_6, value);
	}

	inline static int32_t get_offset_of_animationProgresses_7() { return static_cast<int32_t>(offsetof(AnimationManager_t2328214095, ___animationProgresses_7)); }
	inline LP_1_t2431235445 * get_animationProgresses_7() const { return ___animationProgresses_7; }
	inline LP_1_t2431235445 ** get_address_of_animationProgresses_7() { return &___animationProgresses_7; }
	inline void set_animationProgresses_7(LP_1_t2431235445 * value)
	{
		___animationProgresses_7 = value;
		Il2CppCodeGenWriteBarrier(&___animationProgresses_7, value);
	}

	inline static int32_t get_offset_of_lastMove_8() { return static_cast<int32_t>(offsetof(AnimationManager_t2328214095, ___lastMove_8)); }
	inline VP_1_t2240176003 * get_lastMove_8() const { return ___lastMove_8; }
	inline VP_1_t2240176003 ** get_address_of_lastMove_8() { return &___lastMove_8; }
	inline void set_lastMove_8(VP_1_t2240176003 * value)
	{
		___lastMove_8 = value;
		Il2CppCodeGenWriteBarrier(&___lastMove_8, value);
	}

	inline static int32_t get_offset_of_state_9() { return static_cast<int32_t>(offsetof(AnimationManager_t2328214095, ___state_9)); }
	inline VP_1_t2612219109 * get_state_9() const { return ___state_9; }
	inline VP_1_t2612219109 ** get_address_of_state_9() { return &___state_9; }
	inline void set_state_9(VP_1_t2612219109 * value)
	{
		___state_9 = value;
		Il2CppCodeGenWriteBarrier(&___state_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
