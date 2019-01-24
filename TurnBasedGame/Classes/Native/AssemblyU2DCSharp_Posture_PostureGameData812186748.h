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
// VP`1<System.String>
struct VP_1_t2407497239;
// VP`1<GameData>
struct VP_1_t828551228;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.PostureGameData
struct  PostureGameData_t812186748  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Posture.PostureGameData::postureIndex
	VP_1_t2450154454 * ___postureIndex_5;
	// VP`1<System.String> Posture.PostureGameData::name
	VP_1_t2407497239 * ___name_6;
	// VP`1<GameData> Posture.PostureGameData::gameData
	VP_1_t828551228 * ___gameData_7;

public:
	inline static int32_t get_offset_of_postureIndex_5() { return static_cast<int32_t>(offsetof(PostureGameData_t812186748, ___postureIndex_5)); }
	inline VP_1_t2450154454 * get_postureIndex_5() const { return ___postureIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_postureIndex_5() { return &___postureIndex_5; }
	inline void set_postureIndex_5(VP_1_t2450154454 * value)
	{
		___postureIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___postureIndex_5, value);
	}

	inline static int32_t get_offset_of_name_6() { return static_cast<int32_t>(offsetof(PostureGameData_t812186748, ___name_6)); }
	inline VP_1_t2407497239 * get_name_6() const { return ___name_6; }
	inline VP_1_t2407497239 ** get_address_of_name_6() { return &___name_6; }
	inline void set_name_6(VP_1_t2407497239 * value)
	{
		___name_6 = value;
		Il2CppCodeGenWriteBarrier(&___name_6, value);
	}

	inline static int32_t get_offset_of_gameData_7() { return static_cast<int32_t>(offsetof(PostureGameData_t812186748, ___gameData_7)); }
	inline VP_1_t828551228 * get_gameData_7() const { return ___gameData_7; }
	inline VP_1_t828551228 ** get_address_of_gameData_7() { return &___gameData_7; }
	inline void set_gameData_7(VP_1_t828551228 * value)
	{
		___gameData_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
