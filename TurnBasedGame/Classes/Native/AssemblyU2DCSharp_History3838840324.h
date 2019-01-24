#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;
// LP`1<HistoryChange>
struct LP_1_t3085927444;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.UInt32>
struct VP_1_t2527959027;
// LP`1<HumanConnection>
struct LP_1_t2370501235;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// History
struct  History_t3838840324  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> History::isActive
	VP_1_t4203851724 * ___isActive_5;
	// LP`1<HistoryChange> History::changes
	LP_1_t3085927444 * ___changes_6;
	// VP`1<System.Int32> History::position
	VP_1_t2450154454 * ___position_7;
	// VP`1<System.UInt32> History::changeCount
	VP_1_t2527959027 * ___changeCount_8;
	// LP`1<HumanConnection> History::humanConnections
	LP_1_t2370501235 * ___humanConnections_9;

public:
	inline static int32_t get_offset_of_isActive_5() { return static_cast<int32_t>(offsetof(History_t3838840324, ___isActive_5)); }
	inline VP_1_t4203851724 * get_isActive_5() const { return ___isActive_5; }
	inline VP_1_t4203851724 ** get_address_of_isActive_5() { return &___isActive_5; }
	inline void set_isActive_5(VP_1_t4203851724 * value)
	{
		___isActive_5 = value;
		Il2CppCodeGenWriteBarrier(&___isActive_5, value);
	}

	inline static int32_t get_offset_of_changes_6() { return static_cast<int32_t>(offsetof(History_t3838840324, ___changes_6)); }
	inline LP_1_t3085927444 * get_changes_6() const { return ___changes_6; }
	inline LP_1_t3085927444 ** get_address_of_changes_6() { return &___changes_6; }
	inline void set_changes_6(LP_1_t3085927444 * value)
	{
		___changes_6 = value;
		Il2CppCodeGenWriteBarrier(&___changes_6, value);
	}

	inline static int32_t get_offset_of_position_7() { return static_cast<int32_t>(offsetof(History_t3838840324, ___position_7)); }
	inline VP_1_t2450154454 * get_position_7() const { return ___position_7; }
	inline VP_1_t2450154454 ** get_address_of_position_7() { return &___position_7; }
	inline void set_position_7(VP_1_t2450154454 * value)
	{
		___position_7 = value;
		Il2CppCodeGenWriteBarrier(&___position_7, value);
	}

	inline static int32_t get_offset_of_changeCount_8() { return static_cast<int32_t>(offsetof(History_t3838840324, ___changeCount_8)); }
	inline VP_1_t2527959027 * get_changeCount_8() const { return ___changeCount_8; }
	inline VP_1_t2527959027 ** get_address_of_changeCount_8() { return &___changeCount_8; }
	inline void set_changeCount_8(VP_1_t2527959027 * value)
	{
		___changeCount_8 = value;
		Il2CppCodeGenWriteBarrier(&___changeCount_8, value);
	}

	inline static int32_t get_offset_of_humanConnections_9() { return static_cast<int32_t>(offsetof(History_t3838840324, ___humanConnections_9)); }
	inline LP_1_t2370501235 * get_humanConnections_9() const { return ___humanConnections_9; }
	inline LP_1_t2370501235 ** get_address_of_humanConnections_9() { return &___humanConnections_9; }
	inline void set_humanConnections_9(LP_1_t2370501235 * value)
	{
		___humanConnections_9 = value;
		Il2CppCodeGenWriteBarrier(&___humanConnections_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
