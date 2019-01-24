#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Xiangqi.Xiangqi>>
struct VP_1_t2689160972;
// VP`1<Xiangqi.XiangqiFenUI/UIData>
struct VP_1_t1612910934;
// LP`1<Xiangqi.XiangqiPieceUI/UIData>
struct LP_1_t591239789;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.XiangqiBoardUI/UIData
struct  UIData_t2703834069  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Xiangqi.Xiangqi>> Xiangqi.XiangqiBoardUI/UIData::xiangqi
	VP_1_t2689160972 * ___xiangqi_5;
	// VP`1<Xiangqi.XiangqiFenUI/UIData> Xiangqi.XiangqiBoardUI/UIData::xiangqiFen
	VP_1_t1612910934 * ___xiangqiFen_6;
	// LP`1<Xiangqi.XiangqiPieceUI/UIData> Xiangqi.XiangqiBoardUI/UIData::pieces
	LP_1_t591239789 * ___pieces_7;

public:
	inline static int32_t get_offset_of_xiangqi_5() { return static_cast<int32_t>(offsetof(UIData_t2703834069, ___xiangqi_5)); }
	inline VP_1_t2689160972 * get_xiangqi_5() const { return ___xiangqi_5; }
	inline VP_1_t2689160972 ** get_address_of_xiangqi_5() { return &___xiangqi_5; }
	inline void set_xiangqi_5(VP_1_t2689160972 * value)
	{
		___xiangqi_5 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqi_5, value);
	}

	inline static int32_t get_offset_of_xiangqiFen_6() { return static_cast<int32_t>(offsetof(UIData_t2703834069, ___xiangqiFen_6)); }
	inline VP_1_t1612910934 * get_xiangqiFen_6() const { return ___xiangqiFen_6; }
	inline VP_1_t1612910934 ** get_address_of_xiangqiFen_6() { return &___xiangqiFen_6; }
	inline void set_xiangqiFen_6(VP_1_t1612910934 * value)
	{
		___xiangqiFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t2703834069, ___pieces_7)); }
	inline LP_1_t591239789 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t591239789 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t591239789 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
