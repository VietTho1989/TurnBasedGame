#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Rights.UndoRedoRight>
struct VP_1_t1233910736;
// VP`1<GameManager.Match.Swap.ChangeGamePlayerRight>
struct VP_1_t253170959;
// VP`1<ChangeUseRuleRight>
struct VP_1_t3836736843;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.ChangeRights
struct  ChangeRights_t1164553831  : public Data_t3569509720
{
public:
	// VP`1<Rights.UndoRedoRight> Rights.ChangeRights::undoRedoRight
	VP_1_t1233910736 * ___undoRedoRight_5;
	// VP`1<GameManager.Match.Swap.ChangeGamePlayerRight> Rights.ChangeRights::changeGamePlayerRight
	VP_1_t253170959 * ___changeGamePlayerRight_6;
	// VP`1<ChangeUseRuleRight> Rights.ChangeRights::changeUseRuleRight
	VP_1_t3836736843 * ___changeUseRuleRight_7;

public:
	inline static int32_t get_offset_of_undoRedoRight_5() { return static_cast<int32_t>(offsetof(ChangeRights_t1164553831, ___undoRedoRight_5)); }
	inline VP_1_t1233910736 * get_undoRedoRight_5() const { return ___undoRedoRight_5; }
	inline VP_1_t1233910736 ** get_address_of_undoRedoRight_5() { return &___undoRedoRight_5; }
	inline void set_undoRedoRight_5(VP_1_t1233910736 * value)
	{
		___undoRedoRight_5 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoRight_5, value);
	}

	inline static int32_t get_offset_of_changeGamePlayerRight_6() { return static_cast<int32_t>(offsetof(ChangeRights_t1164553831, ___changeGamePlayerRight_6)); }
	inline VP_1_t253170959 * get_changeGamePlayerRight_6() const { return ___changeGamePlayerRight_6; }
	inline VP_1_t253170959 ** get_address_of_changeGamePlayerRight_6() { return &___changeGamePlayerRight_6; }
	inline void set_changeGamePlayerRight_6(VP_1_t253170959 * value)
	{
		___changeGamePlayerRight_6 = value;
		Il2CppCodeGenWriteBarrier(&___changeGamePlayerRight_6, value);
	}

	inline static int32_t get_offset_of_changeUseRuleRight_7() { return static_cast<int32_t>(offsetof(ChangeRights_t1164553831, ___changeUseRuleRight_7)); }
	inline VP_1_t3836736843 * get_changeUseRuleRight_7() const { return ___changeUseRuleRight_7; }
	inline VP_1_t3836736843 ** get_address_of_changeUseRuleRight_7() { return &___changeUseRuleRight_7; }
	inline void set_changeUseRuleRight_7(VP_1_t3836736843 * value)
	{
		___changeUseRuleRight_7 = value;
		Il2CppCodeGenWriteBarrier(&___changeUseRuleRight_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
