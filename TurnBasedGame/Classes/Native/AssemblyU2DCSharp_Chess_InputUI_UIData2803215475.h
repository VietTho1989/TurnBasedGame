#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Chess.Chess>>
struct VP_1_t1603404227;
// VP`1<Chess.InputUI/UIData/Sub>
struct VP_1_t137050800;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.InputUI/UIData
struct  UIData_t2803215475  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Chess.Chess>> Chess.InputUI/UIData::chess
	VP_1_t1603404227 * ___chess_5;
	// VP`1<Chess.InputUI/UIData/Sub> Chess.InputUI/UIData::sub
	VP_1_t137050800 * ___sub_6;

public:
	inline static int32_t get_offset_of_chess_5() { return static_cast<int32_t>(offsetof(UIData_t2803215475, ___chess_5)); }
	inline VP_1_t1603404227 * get_chess_5() const { return ___chess_5; }
	inline VP_1_t1603404227 ** get_address_of_chess_5() { return &___chess_5; }
	inline void set_chess_5(VP_1_t1603404227 * value)
	{
		___chess_5 = value;
		Il2CppCodeGenWriteBarrier(&___chess_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2803215475, ___sub_6)); }
	inline VP_1_t137050800 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t137050800 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t137050800 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
