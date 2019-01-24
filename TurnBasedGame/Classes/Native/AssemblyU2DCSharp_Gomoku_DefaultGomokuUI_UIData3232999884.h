#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameTypeUI1278715567.h"

// VP`1<EditData`1<Gomoku.DefaultGomoku>>
struct VP_1_t2564788559;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;
// VP`1<MiniGameDataUI/UIData>
struct VP_1_t1885838056;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.DefaultGomokuUI/UIData
struct  UIData_t3232999884  : public DefaultGameTypeUI_t1278715567
{
public:
	// VP`1<EditData`1<Gomoku.DefaultGomoku>> Gomoku.DefaultGomokuUI/UIData::editDefaultGomoku
	VP_1_t2564788559 * ___editDefaultGomoku_5;
	// VP`1<RequestChangeIntUI/UIData> Gomoku.DefaultGomokuUI/UIData::boardSize
	VP_1_t1437137211 * ___boardSize_6;
	// VP`1<MiniGameDataUI/UIData> Gomoku.DefaultGomokuUI/UIData::miniGameDataUIData
	VP_1_t1885838056 * ___miniGameDataUIData_7;

public:
	inline static int32_t get_offset_of_editDefaultGomoku_5() { return static_cast<int32_t>(offsetof(UIData_t3232999884, ___editDefaultGomoku_5)); }
	inline VP_1_t2564788559 * get_editDefaultGomoku_5() const { return ___editDefaultGomoku_5; }
	inline VP_1_t2564788559 ** get_address_of_editDefaultGomoku_5() { return &___editDefaultGomoku_5; }
	inline void set_editDefaultGomoku_5(VP_1_t2564788559 * value)
	{
		___editDefaultGomoku_5 = value;
		Il2CppCodeGenWriteBarrier(&___editDefaultGomoku_5, value);
	}

	inline static int32_t get_offset_of_boardSize_6() { return static_cast<int32_t>(offsetof(UIData_t3232999884, ___boardSize_6)); }
	inline VP_1_t1437137211 * get_boardSize_6() const { return ___boardSize_6; }
	inline VP_1_t1437137211 ** get_address_of_boardSize_6() { return &___boardSize_6; }
	inline void set_boardSize_6(VP_1_t1437137211 * value)
	{
		___boardSize_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_6, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIData_7() { return static_cast<int32_t>(offsetof(UIData_t3232999884, ___miniGameDataUIData_7)); }
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
