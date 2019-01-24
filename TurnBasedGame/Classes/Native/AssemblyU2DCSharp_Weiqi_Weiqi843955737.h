#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameType1512575910.h"

// VP`1<Weiqi.Board>
struct VP_1_t4266954282;
// VP`1<Weiqi.MoveQueue>
struct VP_1_t650600236;
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.Weiqi
struct  Weiqi_t843955737  : public GameType_t1512575910
{
public:
	// VP`1<Weiqi.Board> Weiqi.Weiqi::b
	VP_1_t4266954282 * ___b_11;
	// VP`1<Weiqi.MoveQueue> Weiqi.Weiqi::deadgroup
	VP_1_t650600236 * ___deadgroup_12;
	// LP`1<System.Int32> Weiqi.Weiqi::scoreOwnerMap
	LP_1_t809621404 * ___scoreOwnerMap_13;
	// VP`1<System.Int32> Weiqi.Weiqi::scoreOwnerMapSize
	VP_1_t2450154454 * ___scoreOwnerMapSize_14;
	// VP`1<System.Int32> Weiqi.Weiqi::scoreBlack
	VP_1_t2450154454 * ___scoreBlack_15;
	// VP`1<System.Int32> Weiqi.Weiqi::scoreWhite
	VP_1_t2450154454 * ___scoreWhite_16;
	// VP`1<System.Int32> Weiqi.Weiqi::dame
	VP_1_t2450154454 * ___dame_17;
	// VP`1<System.Single> Weiqi.Weiqi::score
	VP_1_t2454786938 * ___score_18;
	// VP`1<System.Boolean> Weiqi.Weiqi::isCustom
	VP_1_t4203851724 * ___isCustom_19;

public:
	inline static int32_t get_offset_of_b_11() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___b_11)); }
	inline VP_1_t4266954282 * get_b_11() const { return ___b_11; }
	inline VP_1_t4266954282 ** get_address_of_b_11() { return &___b_11; }
	inline void set_b_11(VP_1_t4266954282 * value)
	{
		___b_11 = value;
		Il2CppCodeGenWriteBarrier(&___b_11, value);
	}

	inline static int32_t get_offset_of_deadgroup_12() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___deadgroup_12)); }
	inline VP_1_t650600236 * get_deadgroup_12() const { return ___deadgroup_12; }
	inline VP_1_t650600236 ** get_address_of_deadgroup_12() { return &___deadgroup_12; }
	inline void set_deadgroup_12(VP_1_t650600236 * value)
	{
		___deadgroup_12 = value;
		Il2CppCodeGenWriteBarrier(&___deadgroup_12, value);
	}

	inline static int32_t get_offset_of_scoreOwnerMap_13() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___scoreOwnerMap_13)); }
	inline LP_1_t809621404 * get_scoreOwnerMap_13() const { return ___scoreOwnerMap_13; }
	inline LP_1_t809621404 ** get_address_of_scoreOwnerMap_13() { return &___scoreOwnerMap_13; }
	inline void set_scoreOwnerMap_13(LP_1_t809621404 * value)
	{
		___scoreOwnerMap_13 = value;
		Il2CppCodeGenWriteBarrier(&___scoreOwnerMap_13, value);
	}

	inline static int32_t get_offset_of_scoreOwnerMapSize_14() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___scoreOwnerMapSize_14)); }
	inline VP_1_t2450154454 * get_scoreOwnerMapSize_14() const { return ___scoreOwnerMapSize_14; }
	inline VP_1_t2450154454 ** get_address_of_scoreOwnerMapSize_14() { return &___scoreOwnerMapSize_14; }
	inline void set_scoreOwnerMapSize_14(VP_1_t2450154454 * value)
	{
		___scoreOwnerMapSize_14 = value;
		Il2CppCodeGenWriteBarrier(&___scoreOwnerMapSize_14, value);
	}

	inline static int32_t get_offset_of_scoreBlack_15() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___scoreBlack_15)); }
	inline VP_1_t2450154454 * get_scoreBlack_15() const { return ___scoreBlack_15; }
	inline VP_1_t2450154454 ** get_address_of_scoreBlack_15() { return &___scoreBlack_15; }
	inline void set_scoreBlack_15(VP_1_t2450154454 * value)
	{
		___scoreBlack_15 = value;
		Il2CppCodeGenWriteBarrier(&___scoreBlack_15, value);
	}

	inline static int32_t get_offset_of_scoreWhite_16() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___scoreWhite_16)); }
	inline VP_1_t2450154454 * get_scoreWhite_16() const { return ___scoreWhite_16; }
	inline VP_1_t2450154454 ** get_address_of_scoreWhite_16() { return &___scoreWhite_16; }
	inline void set_scoreWhite_16(VP_1_t2450154454 * value)
	{
		___scoreWhite_16 = value;
		Il2CppCodeGenWriteBarrier(&___scoreWhite_16, value);
	}

	inline static int32_t get_offset_of_dame_17() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___dame_17)); }
	inline VP_1_t2450154454 * get_dame_17() const { return ___dame_17; }
	inline VP_1_t2450154454 ** get_address_of_dame_17() { return &___dame_17; }
	inline void set_dame_17(VP_1_t2450154454 * value)
	{
		___dame_17 = value;
		Il2CppCodeGenWriteBarrier(&___dame_17, value);
	}

	inline static int32_t get_offset_of_score_18() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___score_18)); }
	inline VP_1_t2454786938 * get_score_18() const { return ___score_18; }
	inline VP_1_t2454786938 ** get_address_of_score_18() { return &___score_18; }
	inline void set_score_18(VP_1_t2454786938 * value)
	{
		___score_18 = value;
		Il2CppCodeGenWriteBarrier(&___score_18, value);
	}

	inline static int32_t get_offset_of_isCustom_19() { return static_cast<int32_t>(offsetof(Weiqi_t843955737, ___isCustom_19)); }
	inline VP_1_t4203851724 * get_isCustom_19() const { return ___isCustom_19; }
	inline VP_1_t4203851724 ** get_address_of_isCustom_19() { return &___isCustom_19; }
	inline void set_isCustom_19(VP_1_t4203851724 * value)
	{
		___isCustom_19 = value;
		Il2CppCodeGenWriteBarrier(&___isCustom_19, value);
	}
};

struct Weiqi_t843955737_StaticFields
{
public:
	// System.Collections.Generic.List`1<System.Byte> Weiqi.Weiqi::AllowNames
	List_1_t3052225568 * ___AllowNames_20;
	// System.Collections.Generic.List`1<System.Byte> Weiqi.Weiqi::UpdateScoreNames
	List_1_t3052225568 * ___UpdateScoreNames_21;

public:
	inline static int32_t get_offset_of_AllowNames_20() { return static_cast<int32_t>(offsetof(Weiqi_t843955737_StaticFields, ___AllowNames_20)); }
	inline List_1_t3052225568 * get_AllowNames_20() const { return ___AllowNames_20; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_20() { return &___AllowNames_20; }
	inline void set_AllowNames_20(List_1_t3052225568 * value)
	{
		___AllowNames_20 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_20, value);
	}

	inline static int32_t get_offset_of_UpdateScoreNames_21() { return static_cast<int32_t>(offsetof(Weiqi_t843955737_StaticFields, ___UpdateScoreNames_21)); }
	inline List_1_t3052225568 * get_UpdateScoreNames_21() const { return ___UpdateScoreNames_21; }
	inline List_1_t3052225568 ** get_address_of_UpdateScoreNames_21() { return &___UpdateScoreNames_21; }
	inline void set_UpdateScoreNames_21(List_1_t3052225568 * value)
	{
		___UpdateScoreNames_21 = value;
		Il2CppCodeGenWriteBarrier(&___UpdateScoreNames_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
