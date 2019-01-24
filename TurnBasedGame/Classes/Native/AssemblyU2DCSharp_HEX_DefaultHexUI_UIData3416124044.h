#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameTypeUI1278715567.h"

// VP`1<EditData`1<HEX.DefaultHex>>
struct VP_1_t499036618;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;
// VP`1<MiniGameDataUI/UIData>
struct VP_1_t1885838056;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.DefaultHexUI/UIData
struct  UIData_t3416124044  : public DefaultGameTypeUI_t1278715567
{
public:
	// VP`1<EditData`1<HEX.DefaultHex>> HEX.DefaultHexUI/UIData::editDefaultHex
	VP_1_t499036618 * ___editDefaultHex_5;
	// VP`1<RequestChangeIntUI/UIData> HEX.DefaultHexUI/UIData::boardSize
	VP_1_t1437137211 * ___boardSize_6;
	// VP`1<MiniGameDataUI/UIData> HEX.DefaultHexUI/UIData::miniGameDataUIData
	VP_1_t1885838056 * ___miniGameDataUIData_7;

public:
	inline static int32_t get_offset_of_editDefaultHex_5() { return static_cast<int32_t>(offsetof(UIData_t3416124044, ___editDefaultHex_5)); }
	inline VP_1_t499036618 * get_editDefaultHex_5() const { return ___editDefaultHex_5; }
	inline VP_1_t499036618 ** get_address_of_editDefaultHex_5() { return &___editDefaultHex_5; }
	inline void set_editDefaultHex_5(VP_1_t499036618 * value)
	{
		___editDefaultHex_5 = value;
		Il2CppCodeGenWriteBarrier(&___editDefaultHex_5, value);
	}

	inline static int32_t get_offset_of_boardSize_6() { return static_cast<int32_t>(offsetof(UIData_t3416124044, ___boardSize_6)); }
	inline VP_1_t1437137211 * get_boardSize_6() const { return ___boardSize_6; }
	inline VP_1_t1437137211 ** get_address_of_boardSize_6() { return &___boardSize_6; }
	inline void set_boardSize_6(VP_1_t1437137211 * value)
	{
		___boardSize_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_6, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIData_7() { return static_cast<int32_t>(offsetof(UIData_t3416124044, ___miniGameDataUIData_7)); }
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
