﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameTypeUI1278715567.h"

// VP`1<EditData`1<Chess.DefaultChess>>
struct VP_1_t4192423069;
// VP`1<RequestChangeBoolUI/UIData>
struct VP_1_t3802102788;
// VP`1<MiniGameDataUI/UIData>
struct VP_1_t1885838056;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.DefaultChessUI/UIData
struct  UIData_t3866873770  : public DefaultGameTypeUI_t1278715567
{
public:
	// VP`1<EditData`1<Chess.DefaultChess>> Chess.DefaultChessUI/UIData::editDefaultChess
	VP_1_t4192423069 * ___editDefaultChess_5;
	// VP`1<RequestChangeBoolUI/UIData> Chess.DefaultChessUI/UIData::chess960
	VP_1_t3802102788 * ___chess960_6;
	// VP`1<MiniGameDataUI/UIData> Chess.DefaultChessUI/UIData::miniGameDataUIData
	VP_1_t1885838056 * ___miniGameDataUIData_7;

public:
	inline static int32_t get_offset_of_editDefaultChess_5() { return static_cast<int32_t>(offsetof(UIData_t3866873770, ___editDefaultChess_5)); }
	inline VP_1_t4192423069 * get_editDefaultChess_5() const { return ___editDefaultChess_5; }
	inline VP_1_t4192423069 ** get_address_of_editDefaultChess_5() { return &___editDefaultChess_5; }
	inline void set_editDefaultChess_5(VP_1_t4192423069 * value)
	{
		___editDefaultChess_5 = value;
		Il2CppCodeGenWriteBarrier(&___editDefaultChess_5, value);
	}

	inline static int32_t get_offset_of_chess960_6() { return static_cast<int32_t>(offsetof(UIData_t3866873770, ___chess960_6)); }
	inline VP_1_t3802102788 * get_chess960_6() const { return ___chess960_6; }
	inline VP_1_t3802102788 ** get_address_of_chess960_6() { return &___chess960_6; }
	inline void set_chess960_6(VP_1_t3802102788 * value)
	{
		___chess960_6 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_6, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIData_7() { return static_cast<int32_t>(offsetof(UIData_t3866873770, ___miniGameDataUIData_7)); }
	inline VP_1_t1885838056 * get_miniGameDataUIData_7() const { return ___miniGameDataUIData_7; }
	inline VP_1_t1885838056 ** get_address_of_miniGameDataUIData_7() { return &___miniGameDataUIData_7; }
	inline void set_miniGameDataUIData_7(VP_1_t1885838056 * value)
	{
		___miniGameDataUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
