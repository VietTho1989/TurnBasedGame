#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2799241283.h"

// GameDataBoardUI/UIData
struct UIData_t2908617385;
// GameCheckPlayerChange`1<GameData>
struct GameCheckPlayerChange_1_t3776416635;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PerspectiveUpdate
struct  PerspectiveUpdate_t630613419  : public UpdateBehavior_1_t2799241283
{
public:
	// GameDataBoardUI/UIData PerspectiveUpdate::gameDataBoardUIData
	UIData_t2908617385 * ___gameDataBoardUIData_4;
	// GameCheckPlayerChange`1<GameData> PerspectiveUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t3776416635 * ___gameCheckPlayerChange_5;

public:
	inline static int32_t get_offset_of_gameDataBoardUIData_4() { return static_cast<int32_t>(offsetof(PerspectiveUpdate_t630613419, ___gameDataBoardUIData_4)); }
	inline UIData_t2908617385 * get_gameDataBoardUIData_4() const { return ___gameDataBoardUIData_4; }
	inline UIData_t2908617385 ** get_address_of_gameDataBoardUIData_4() { return &___gameDataBoardUIData_4; }
	inline void set_gameDataBoardUIData_4(UIData_t2908617385 * value)
	{
		___gameDataBoardUIData_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardUIData_4, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_5() { return static_cast<int32_t>(offsetof(PerspectiveUpdate_t630613419, ___gameCheckPlayerChange_5)); }
	inline GameCheckPlayerChange_1_t3776416635 * get_gameCheckPlayerChange_5() const { return ___gameCheckPlayerChange_5; }
	inline GameCheckPlayerChange_1_t3776416635 ** get_address_of_gameCheckPlayerChange_5() { return &___gameCheckPlayerChange_5; }
	inline void set_gameCheckPlayerChange_5(GameCheckPlayerChange_1_t3776416635 * value)
	{
		___gameCheckPlayerChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
