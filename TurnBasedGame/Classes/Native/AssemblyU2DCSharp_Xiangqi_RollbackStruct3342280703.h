#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Xiangqi.ZobristStruct>
struct VP_1_t4230359248;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.UInt32>
struct VP_1_t2527959027;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.RollbackStruct
struct  RollbackStruct_t3342280703  : public Data_t3569509720
{
public:
	// VP`1<Xiangqi.ZobristStruct> Xiangqi.RollbackStruct::zobr
	VP_1_t4230359248 * ___zobr_5;
	// VP`1<System.Int32> Xiangqi.RollbackStruct::vlWhite
	VP_1_t2450154454 * ___vlWhite_6;
	// VP`1<System.Int32> Xiangqi.RollbackStruct::vlBlack
	VP_1_t2450154454 * ___vlBlack_7;
	// VP`1<System.UInt32> Xiangqi.RollbackStruct::mvs
	VP_1_t2527959027 * ___mvs_8;

public:
	inline static int32_t get_offset_of_zobr_5() { return static_cast<int32_t>(offsetof(RollbackStruct_t3342280703, ___zobr_5)); }
	inline VP_1_t4230359248 * get_zobr_5() const { return ___zobr_5; }
	inline VP_1_t4230359248 ** get_address_of_zobr_5() { return &___zobr_5; }
	inline void set_zobr_5(VP_1_t4230359248 * value)
	{
		___zobr_5 = value;
		Il2CppCodeGenWriteBarrier(&___zobr_5, value);
	}

	inline static int32_t get_offset_of_vlWhite_6() { return static_cast<int32_t>(offsetof(RollbackStruct_t3342280703, ___vlWhite_6)); }
	inline VP_1_t2450154454 * get_vlWhite_6() const { return ___vlWhite_6; }
	inline VP_1_t2450154454 ** get_address_of_vlWhite_6() { return &___vlWhite_6; }
	inline void set_vlWhite_6(VP_1_t2450154454 * value)
	{
		___vlWhite_6 = value;
		Il2CppCodeGenWriteBarrier(&___vlWhite_6, value);
	}

	inline static int32_t get_offset_of_vlBlack_7() { return static_cast<int32_t>(offsetof(RollbackStruct_t3342280703, ___vlBlack_7)); }
	inline VP_1_t2450154454 * get_vlBlack_7() const { return ___vlBlack_7; }
	inline VP_1_t2450154454 ** get_address_of_vlBlack_7() { return &___vlBlack_7; }
	inline void set_vlBlack_7(VP_1_t2450154454 * value)
	{
		___vlBlack_7 = value;
		Il2CppCodeGenWriteBarrier(&___vlBlack_7, value);
	}

	inline static int32_t get_offset_of_mvs_8() { return static_cast<int32_t>(offsetof(RollbackStruct_t3342280703, ___mvs_8)); }
	inline VP_1_t2527959027 * get_mvs_8() const { return ___mvs_8; }
	inline VP_1_t2527959027 ** get_address_of_mvs_8() { return &___mvs_8; }
	inline void set_mvs_8(VP_1_t2527959027 * value)
	{
		___mvs_8 = value;
		Il2CppCodeGenWriteBarrier(&___mvs_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
