#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_AIUI_UIData_Sub3237004242.h"

// VP`1<EditData`1<Chess.ChessAI>>
struct VP_1_t3952307890;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;
// VP`1<RequestChangeLongUI/UIData>
struct VP_1_t3068299842;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.ChessAIUI/UIData
struct  UIData_t3527270599  : public Sub_t3237004242
{
public:
	// VP`1<EditData`1<Chess.ChessAI>> Chess.ChessAIUI/UIData::editAI
	VP_1_t3952307890 * ___editAI_5;
	// VP`1<RequestChangeIntUI/UIData> Chess.ChessAIUI/UIData::depth
	VP_1_t1437137211 * ___depth_6;
	// VP`1<RequestChangeIntUI/UIData> Chess.ChessAIUI/UIData::skillLevel
	VP_1_t1437137211 * ___skillLevel_7;
	// VP`1<RequestChangeLongUI/UIData> Chess.ChessAIUI/UIData::duration
	VP_1_t3068299842 * ___duration_8;

public:
	inline static int32_t get_offset_of_editAI_5() { return static_cast<int32_t>(offsetof(UIData_t3527270599, ___editAI_5)); }
	inline VP_1_t3952307890 * get_editAI_5() const { return ___editAI_5; }
	inline VP_1_t3952307890 ** get_address_of_editAI_5() { return &___editAI_5; }
	inline void set_editAI_5(VP_1_t3952307890 * value)
	{
		___editAI_5 = value;
		Il2CppCodeGenWriteBarrier(&___editAI_5, value);
	}

	inline static int32_t get_offset_of_depth_6() { return static_cast<int32_t>(offsetof(UIData_t3527270599, ___depth_6)); }
	inline VP_1_t1437137211 * get_depth_6() const { return ___depth_6; }
	inline VP_1_t1437137211 ** get_address_of_depth_6() { return &___depth_6; }
	inline void set_depth_6(VP_1_t1437137211 * value)
	{
		___depth_6 = value;
		Il2CppCodeGenWriteBarrier(&___depth_6, value);
	}

	inline static int32_t get_offset_of_skillLevel_7() { return static_cast<int32_t>(offsetof(UIData_t3527270599, ___skillLevel_7)); }
	inline VP_1_t1437137211 * get_skillLevel_7() const { return ___skillLevel_7; }
	inline VP_1_t1437137211 ** get_address_of_skillLevel_7() { return &___skillLevel_7; }
	inline void set_skillLevel_7(VP_1_t1437137211 * value)
	{
		___skillLevel_7 = value;
		Il2CppCodeGenWriteBarrier(&___skillLevel_7, value);
	}

	inline static int32_t get_offset_of_duration_8() { return static_cast<int32_t>(offsetof(UIData_t3527270599, ___duration_8)); }
	inline VP_1_t3068299842 * get_duration_8() const { return ___duration_8; }
	inline VP_1_t3068299842 ** get_address_of_duration_8() { return &___duration_8; }
	inline void set_duration_8(VP_1_t3068299842 * value)
	{
		___duration_8 = value;
		Il2CppCodeGenWriteBarrier(&___duration_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
