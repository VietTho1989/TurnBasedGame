#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameAction>>
struct VP_1_t3387276317;
// VP`1<GameActionsUI/UIData/Sub>
struct VP_1_t2658730539;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameActionsUI/UIData
struct  UIData_t2779798242  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameAction>> GameActionsUI/UIData::gameAction
	VP_1_t3387276317 * ___gameAction_5;
	// VP`1<GameActionsUI/UIData/Sub> GameActionsUI/UIData::sub
	VP_1_t2658730539 * ___sub_6;

public:
	inline static int32_t get_offset_of_gameAction_5() { return static_cast<int32_t>(offsetof(UIData_t2779798242, ___gameAction_5)); }
	inline VP_1_t3387276317 * get_gameAction_5() const { return ___gameAction_5; }
	inline VP_1_t3387276317 ** get_address_of_gameAction_5() { return &___gameAction_5; }
	inline void set_gameAction_5(VP_1_t3387276317 * value)
	{
		___gameAction_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameAction_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2779798242, ___sub_6)); }
	inline VP_1_t2658730539 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2658730539 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2658730539 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
