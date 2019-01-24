#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameType1512575910.h"

// System.String
struct String_t;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.Byte>
struct LP_1_t2420848392;
// VP`1<Xiangqi.ZobristStruct>
struct VP_1_t4230359248;
// VP`1<System.UInt32>
struct VP_1_t2527959027;
// LP`1<System.UInt16>
struct LP_1_t4019593863;
// LP`1<Xiangqi.RollbackStruct>
struct LP_1_t2080024659;
// LP`1<System.UInt32>
struct LP_1_t887425977;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.Xiangqi
struct  Xiangqi_t3240100903  : public GameType_t1512575910
{
public:
	// VP`1<System.Int32> Xiangqi.Xiangqi::sdPlayer
	VP_1_t2450154454 * ___sdPlayer_13;
	// LP`1<System.Byte> Xiangqi.Xiangqi::ucpcSquares
	LP_1_t2420848392 * ___ucpcSquares_14;
	// LP`1<System.Byte> Xiangqi.Xiangqi::ucsqPieces
	LP_1_t2420848392 * ___ucsqPieces_15;
	// VP`1<Xiangqi.ZobristStruct> Xiangqi.Xiangqi::zobr
	VP_1_t4230359248 * ___zobr_16;
	// VP`1<System.UInt32> Xiangqi.Xiangqi::dwBitPiece
	VP_1_t2527959027 * ___dwBitPiece_17;
	// LP`1<System.UInt16> Xiangqi.Xiangqi::wBitRanks
	LP_1_t4019593863 * ___wBitRanks_18;
	// LP`1<System.UInt16> Xiangqi.Xiangqi::wBitFiles
	LP_1_t4019593863 * ___wBitFiles_19;
	// VP`1<System.Int32> Xiangqi.Xiangqi::vlWhite
	VP_1_t2450154454 * ___vlWhite_20;
	// VP`1<System.Int32> Xiangqi.Xiangqi::vlBlack
	VP_1_t2450154454 * ___vlBlack_21;
	// VP`1<System.Int32> Xiangqi.Xiangqi::nMoveNum
	VP_1_t2450154454 * ___nMoveNum_22;
	// VP`1<System.Int32> Xiangqi.Xiangqi::nDistance
	VP_1_t2450154454 * ___nDistance_23;
	// LP`1<Xiangqi.RollbackStruct> Xiangqi.Xiangqi::rbsList
	LP_1_t2080024659 * ___rbsList_24;
	// LP`1<System.UInt32> Xiangqi.Xiangqi::ucRepHash
	LP_1_t887425977 * ___ucRepHash_25;
	// VP`1<System.Boolean> Xiangqi.Xiangqi::isCustom
	VP_1_t4203851724 * ___isCustom_26;

public:
	inline static int32_t get_offset_of_sdPlayer_13() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___sdPlayer_13)); }
	inline VP_1_t2450154454 * get_sdPlayer_13() const { return ___sdPlayer_13; }
	inline VP_1_t2450154454 ** get_address_of_sdPlayer_13() { return &___sdPlayer_13; }
	inline void set_sdPlayer_13(VP_1_t2450154454 * value)
	{
		___sdPlayer_13 = value;
		Il2CppCodeGenWriteBarrier(&___sdPlayer_13, value);
	}

	inline static int32_t get_offset_of_ucpcSquares_14() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___ucpcSquares_14)); }
	inline LP_1_t2420848392 * get_ucpcSquares_14() const { return ___ucpcSquares_14; }
	inline LP_1_t2420848392 ** get_address_of_ucpcSquares_14() { return &___ucpcSquares_14; }
	inline void set_ucpcSquares_14(LP_1_t2420848392 * value)
	{
		___ucpcSquares_14 = value;
		Il2CppCodeGenWriteBarrier(&___ucpcSquares_14, value);
	}

	inline static int32_t get_offset_of_ucsqPieces_15() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___ucsqPieces_15)); }
	inline LP_1_t2420848392 * get_ucsqPieces_15() const { return ___ucsqPieces_15; }
	inline LP_1_t2420848392 ** get_address_of_ucsqPieces_15() { return &___ucsqPieces_15; }
	inline void set_ucsqPieces_15(LP_1_t2420848392 * value)
	{
		___ucsqPieces_15 = value;
		Il2CppCodeGenWriteBarrier(&___ucsqPieces_15, value);
	}

	inline static int32_t get_offset_of_zobr_16() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___zobr_16)); }
	inline VP_1_t4230359248 * get_zobr_16() const { return ___zobr_16; }
	inline VP_1_t4230359248 ** get_address_of_zobr_16() { return &___zobr_16; }
	inline void set_zobr_16(VP_1_t4230359248 * value)
	{
		___zobr_16 = value;
		Il2CppCodeGenWriteBarrier(&___zobr_16, value);
	}

	inline static int32_t get_offset_of_dwBitPiece_17() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___dwBitPiece_17)); }
	inline VP_1_t2527959027 * get_dwBitPiece_17() const { return ___dwBitPiece_17; }
	inline VP_1_t2527959027 ** get_address_of_dwBitPiece_17() { return &___dwBitPiece_17; }
	inline void set_dwBitPiece_17(VP_1_t2527959027 * value)
	{
		___dwBitPiece_17 = value;
		Il2CppCodeGenWriteBarrier(&___dwBitPiece_17, value);
	}

	inline static int32_t get_offset_of_wBitRanks_18() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___wBitRanks_18)); }
	inline LP_1_t4019593863 * get_wBitRanks_18() const { return ___wBitRanks_18; }
	inline LP_1_t4019593863 ** get_address_of_wBitRanks_18() { return &___wBitRanks_18; }
	inline void set_wBitRanks_18(LP_1_t4019593863 * value)
	{
		___wBitRanks_18 = value;
		Il2CppCodeGenWriteBarrier(&___wBitRanks_18, value);
	}

	inline static int32_t get_offset_of_wBitFiles_19() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___wBitFiles_19)); }
	inline LP_1_t4019593863 * get_wBitFiles_19() const { return ___wBitFiles_19; }
	inline LP_1_t4019593863 ** get_address_of_wBitFiles_19() { return &___wBitFiles_19; }
	inline void set_wBitFiles_19(LP_1_t4019593863 * value)
	{
		___wBitFiles_19 = value;
		Il2CppCodeGenWriteBarrier(&___wBitFiles_19, value);
	}

	inline static int32_t get_offset_of_vlWhite_20() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___vlWhite_20)); }
	inline VP_1_t2450154454 * get_vlWhite_20() const { return ___vlWhite_20; }
	inline VP_1_t2450154454 ** get_address_of_vlWhite_20() { return &___vlWhite_20; }
	inline void set_vlWhite_20(VP_1_t2450154454 * value)
	{
		___vlWhite_20 = value;
		Il2CppCodeGenWriteBarrier(&___vlWhite_20, value);
	}

	inline static int32_t get_offset_of_vlBlack_21() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___vlBlack_21)); }
	inline VP_1_t2450154454 * get_vlBlack_21() const { return ___vlBlack_21; }
	inline VP_1_t2450154454 ** get_address_of_vlBlack_21() { return &___vlBlack_21; }
	inline void set_vlBlack_21(VP_1_t2450154454 * value)
	{
		___vlBlack_21 = value;
		Il2CppCodeGenWriteBarrier(&___vlBlack_21, value);
	}

	inline static int32_t get_offset_of_nMoveNum_22() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___nMoveNum_22)); }
	inline VP_1_t2450154454 * get_nMoveNum_22() const { return ___nMoveNum_22; }
	inline VP_1_t2450154454 ** get_address_of_nMoveNum_22() { return &___nMoveNum_22; }
	inline void set_nMoveNum_22(VP_1_t2450154454 * value)
	{
		___nMoveNum_22 = value;
		Il2CppCodeGenWriteBarrier(&___nMoveNum_22, value);
	}

	inline static int32_t get_offset_of_nDistance_23() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___nDistance_23)); }
	inline VP_1_t2450154454 * get_nDistance_23() const { return ___nDistance_23; }
	inline VP_1_t2450154454 ** get_address_of_nDistance_23() { return &___nDistance_23; }
	inline void set_nDistance_23(VP_1_t2450154454 * value)
	{
		___nDistance_23 = value;
		Il2CppCodeGenWriteBarrier(&___nDistance_23, value);
	}

	inline static int32_t get_offset_of_rbsList_24() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___rbsList_24)); }
	inline LP_1_t2080024659 * get_rbsList_24() const { return ___rbsList_24; }
	inline LP_1_t2080024659 ** get_address_of_rbsList_24() { return &___rbsList_24; }
	inline void set_rbsList_24(LP_1_t2080024659 * value)
	{
		___rbsList_24 = value;
		Il2CppCodeGenWriteBarrier(&___rbsList_24, value);
	}

	inline static int32_t get_offset_of_ucRepHash_25() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___ucRepHash_25)); }
	inline LP_1_t887425977 * get_ucRepHash_25() const { return ___ucRepHash_25; }
	inline LP_1_t887425977 ** get_address_of_ucRepHash_25() { return &___ucRepHash_25; }
	inline void set_ucRepHash_25(LP_1_t887425977 * value)
	{
		___ucRepHash_25 = value;
		Il2CppCodeGenWriteBarrier(&___ucRepHash_25, value);
	}

	inline static int32_t get_offset_of_isCustom_26() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903, ___isCustom_26)); }
	inline VP_1_t4203851724 * get_isCustom_26() const { return ___isCustom_26; }
	inline VP_1_t4203851724 ** get_address_of_isCustom_26() { return &___isCustom_26; }
	inline void set_isCustom_26(VP_1_t4203851724 * value)
	{
		___isCustom_26 = value;
		Il2CppCodeGenWriteBarrier(&___isCustom_26, value);
	}
};

struct Xiangqi_t3240100903_StaticFields
{
public:
	// System.Boolean Xiangqi.Xiangqi::log
	bool ___log_9;
	// System.Collections.Generic.List`1<System.Byte> Xiangqi.Xiangqi::AllowNames
	List_1_t3052225568 * ___AllowNames_27;

public:
	inline static int32_t get_offset_of_log_9() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903_StaticFields, ___log_9)); }
	inline bool get_log_9() const { return ___log_9; }
	inline bool* get_address_of_log_9() { return &___log_9; }
	inline void set_log_9(bool value)
	{
		___log_9 = value;
	}

	inline static int32_t get_offset_of_AllowNames_27() { return static_cast<int32_t>(offsetof(Xiangqi_t3240100903_StaticFields, ___AllowNames_27)); }
	inline List_1_t3052225568 * get_AllowNames_27() const { return ___AllowNames_27; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_27() { return &___AllowNames_27; }
	inline void set_AllowNames_27(List_1_t3052225568 * value)
	{
		___AllowNames_27 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_27, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
