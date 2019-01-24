#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_ChatMessage_Content2083754853.h"

// VP`1<Turn>
struct VP_1_t231024689;
// VP`1<GameMove>
struct VP_1_t2240176003;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatGameMoveContent
struct  ChatGameMoveContent_t3465962366  : public Content_t2083754853
{
public:
	// VP`1<Turn> ChatGameMoveContent::turn
	VP_1_t231024689 * ___turn_5;
	// VP`1<GameMove> ChatGameMoveContent::gameMove
	VP_1_t2240176003 * ___gameMove_6;

public:
	inline static int32_t get_offset_of_turn_5() { return static_cast<int32_t>(offsetof(ChatGameMoveContent_t3465962366, ___turn_5)); }
	inline VP_1_t231024689 * get_turn_5() const { return ___turn_5; }
	inline VP_1_t231024689 ** get_address_of_turn_5() { return &___turn_5; }
	inline void set_turn_5(VP_1_t231024689 * value)
	{
		___turn_5 = value;
		Il2CppCodeGenWriteBarrier(&___turn_5, value);
	}

	inline static int32_t get_offset_of_gameMove_6() { return static_cast<int32_t>(offsetof(ChatGameMoveContent_t3465962366, ___gameMove_6)); }
	inline VP_1_t2240176003 * get_gameMove_6() const { return ___gameMove_6; }
	inline VP_1_t2240176003 ** get_address_of_gameMove_6() { return &___gameMove_6; }
	inline void set_gameMove_6(VP_1_t2240176003 * value)
	{
		___gameMove_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameMove_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
