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
// GameManager.Match.SingleContestContent
struct SingleContestContent_t2253205853;
// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.SingleContestContent>
struct  ContestManagerStatePlayTeamCheckChange_1_t2731033174  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.ContestManagerStatePlayTeamCheckChange`1::change
	VP_1_t2450154454 * ___change_5;
	// K GameManager.Match.ContestManagerStatePlayTeamCheckChange`1::data
	SingleContestContent_t2253205853 * ___data_6;
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.ContestManagerStatePlayTeamCheckChange`1::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_7;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayTeamCheckChange_1_t2731033174, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayTeamCheckChange_1_t2731033174, ___data_6)); }
	inline SingleContestContent_t2253205853 * get_data_6() const { return ___data_6; }
	inline SingleContestContent_t2253205853 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(SingleContestContent_t2253205853 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlay_7() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayTeamCheckChange_1_t2731033174, ___contestManagerStatePlay_7)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_7() const { return ___contestManagerStatePlay_7; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_7() { return &___contestManagerStatePlay_7; }
	inline void set_contestManagerStatePlay_7(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_7 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
