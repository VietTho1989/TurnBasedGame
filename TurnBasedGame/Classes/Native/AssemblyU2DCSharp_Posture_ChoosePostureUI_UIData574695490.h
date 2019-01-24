#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameType/Type>
struct VP_1_t2728349165;
// VP`1<Posture.ChoosePostureAdapter/UIData>
struct VP_1_t653635831;
// VP`1<Posture.ChoosePostureUI/UIData/State>
struct VP_1_t648700914;
// LP`1<Posture.PostureGameData>
struct LP_1_t3844898000;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.ChoosePostureUI/UIData
struct  UIData_t574695490  : public Data_t3569509720
{
public:
	// VP`1<GameType/Type> Posture.ChoosePostureUI/UIData::gameType
	VP_1_t2728349165 * ___gameType_5;
	// VP`1<Posture.ChoosePostureAdapter/UIData> Posture.ChoosePostureUI/UIData::adapter
	VP_1_t653635831 * ___adapter_6;
	// VP`1<Posture.ChoosePostureUI/UIData/State> Posture.ChoosePostureUI/UIData::state
	VP_1_t648700914 * ___state_7;
	// LP`1<Posture.PostureGameData> Posture.ChoosePostureUI/UIData::gameDatas
	LP_1_t3844898000 * ___gameDatas_8;

public:
	inline static int32_t get_offset_of_gameType_5() { return static_cast<int32_t>(offsetof(UIData_t574695490, ___gameType_5)); }
	inline VP_1_t2728349165 * get_gameType_5() const { return ___gameType_5; }
	inline VP_1_t2728349165 ** get_address_of_gameType_5() { return &___gameType_5; }
	inline void set_gameType_5(VP_1_t2728349165 * value)
	{
		___gameType_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameType_5, value);
	}

	inline static int32_t get_offset_of_adapter_6() { return static_cast<int32_t>(offsetof(UIData_t574695490, ___adapter_6)); }
	inline VP_1_t653635831 * get_adapter_6() const { return ___adapter_6; }
	inline VP_1_t653635831 ** get_address_of_adapter_6() { return &___adapter_6; }
	inline void set_adapter_6(VP_1_t653635831 * value)
	{
		___adapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___adapter_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(UIData_t574695490, ___state_7)); }
	inline VP_1_t648700914 * get_state_7() const { return ___state_7; }
	inline VP_1_t648700914 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t648700914 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}

	inline static int32_t get_offset_of_gameDatas_8() { return static_cast<int32_t>(offsetof(UIData_t574695490, ___gameDatas_8)); }
	inline LP_1_t3844898000 * get_gameDatas_8() const { return ___gameDatas_8; }
	inline LP_1_t3844898000 ** get_address_of_gameDatas_8() { return &___gameDatas_8; }
	inline void set_gameDatas_8(LP_1_t3844898000 * value)
	{
		___gameDatas_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDatas_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
