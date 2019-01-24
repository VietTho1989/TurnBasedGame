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
// LP`1<Shogi.Common/BitBoard>
struct LP_1_t2778731645;
// VP`1<Shogi.Common/BitBoard>
struct VP_1_t124297399;
// LP`1<System.Int32>
struct LP_1_t809621404;
// LP`1<System.UInt32>
struct LP_1_t887425977;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.UInt32[]
struct UInt32U5BU5D_t59386216;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<Shogi.EvalList>
struct VP_1_t2814007838;
// LP`1<Shogi.StateInfo>
struct LP_1_t527833255;
// VP`1<System.Int64>
struct VP_1_t1287355043;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.Shogi
struct  Shogi_t1975542802  : public GameType_t1512575910
{
public:
	// LP`1<Shogi.Common/BitBoard> Shogi.Shogi::byTypeBB
	LP_1_t2778731645 * ___byTypeBB_10;
	// LP`1<Shogi.Common/BitBoard> Shogi.Shogi::byColorBB
	LP_1_t2778731645 * ___byColorBB_11;
	// VP`1<Shogi.Common/BitBoard> Shogi.Shogi::goldsBB
	VP_1_t124297399 * ___goldsBB_12;
	// LP`1<System.Int32> Shogi.Shogi::piece
	LP_1_t809621404 * ___piece_13;
	// LP`1<System.Int32> Shogi.Shogi::kingSquare
	LP_1_t809621404 * ___kingSquare_14;
	// LP`1<System.UInt32> Shogi.Shogi::hand
	LP_1_t887425977 * ___hand_15;
	// VP`1<System.Int32> Shogi.Shogi::turn
	VP_1_t2450154454 * ___turn_33;
	// VP`1<Shogi.EvalList> Shogi.Shogi::evalList
	VP_1_t2814007838 * ___evalList_34;
	// LP`1<Shogi.StateInfo> Shogi.Shogi::startState
	LP_1_t527833255 * ___startState_35;
	// LP`1<Shogi.StateInfo> Shogi.Shogi::st
	LP_1_t527833255 * ___st_36;
	// VP`1<System.Int32> Shogi.Shogi::gamePly
	VP_1_t2450154454 * ___gamePly_37;
	// VP`1<System.Int64> Shogi.Shogi::nodes
	VP_1_t1287355043 * ___nodes_38;
	// VP`1<System.Boolean> Shogi.Shogi::isCustom
	VP_1_t4203851724 * ___isCustom_39;

public:
	inline static int32_t get_offset_of_byTypeBB_10() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___byTypeBB_10)); }
	inline LP_1_t2778731645 * get_byTypeBB_10() const { return ___byTypeBB_10; }
	inline LP_1_t2778731645 ** get_address_of_byTypeBB_10() { return &___byTypeBB_10; }
	inline void set_byTypeBB_10(LP_1_t2778731645 * value)
	{
		___byTypeBB_10 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_10, value);
	}

	inline static int32_t get_offset_of_byColorBB_11() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___byColorBB_11)); }
	inline LP_1_t2778731645 * get_byColorBB_11() const { return ___byColorBB_11; }
	inline LP_1_t2778731645 ** get_address_of_byColorBB_11() { return &___byColorBB_11; }
	inline void set_byColorBB_11(LP_1_t2778731645 * value)
	{
		___byColorBB_11 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_11, value);
	}

	inline static int32_t get_offset_of_goldsBB_12() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___goldsBB_12)); }
	inline VP_1_t124297399 * get_goldsBB_12() const { return ___goldsBB_12; }
	inline VP_1_t124297399 ** get_address_of_goldsBB_12() { return &___goldsBB_12; }
	inline void set_goldsBB_12(VP_1_t124297399 * value)
	{
		___goldsBB_12 = value;
		Il2CppCodeGenWriteBarrier(&___goldsBB_12, value);
	}

	inline static int32_t get_offset_of_piece_13() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___piece_13)); }
	inline LP_1_t809621404 * get_piece_13() const { return ___piece_13; }
	inline LP_1_t809621404 ** get_address_of_piece_13() { return &___piece_13; }
	inline void set_piece_13(LP_1_t809621404 * value)
	{
		___piece_13 = value;
		Il2CppCodeGenWriteBarrier(&___piece_13, value);
	}

	inline static int32_t get_offset_of_kingSquare_14() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___kingSquare_14)); }
	inline LP_1_t809621404 * get_kingSquare_14() const { return ___kingSquare_14; }
	inline LP_1_t809621404 ** get_address_of_kingSquare_14() { return &___kingSquare_14; }
	inline void set_kingSquare_14(LP_1_t809621404 * value)
	{
		___kingSquare_14 = value;
		Il2CppCodeGenWriteBarrier(&___kingSquare_14, value);
	}

	inline static int32_t get_offset_of_hand_15() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___hand_15)); }
	inline LP_1_t887425977 * get_hand_15() const { return ___hand_15; }
	inline LP_1_t887425977 ** get_address_of_hand_15() { return &___hand_15; }
	inline void set_hand_15(LP_1_t887425977 * value)
	{
		___hand_15 = value;
		Il2CppCodeGenWriteBarrier(&___hand_15, value);
	}

	inline static int32_t get_offset_of_turn_33() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___turn_33)); }
	inline VP_1_t2450154454 * get_turn_33() const { return ___turn_33; }
	inline VP_1_t2450154454 ** get_address_of_turn_33() { return &___turn_33; }
	inline void set_turn_33(VP_1_t2450154454 * value)
	{
		___turn_33 = value;
		Il2CppCodeGenWriteBarrier(&___turn_33, value);
	}

	inline static int32_t get_offset_of_evalList_34() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___evalList_34)); }
	inline VP_1_t2814007838 * get_evalList_34() const { return ___evalList_34; }
	inline VP_1_t2814007838 ** get_address_of_evalList_34() { return &___evalList_34; }
	inline void set_evalList_34(VP_1_t2814007838 * value)
	{
		___evalList_34 = value;
		Il2CppCodeGenWriteBarrier(&___evalList_34, value);
	}

	inline static int32_t get_offset_of_startState_35() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___startState_35)); }
	inline LP_1_t527833255 * get_startState_35() const { return ___startState_35; }
	inline LP_1_t527833255 ** get_address_of_startState_35() { return &___startState_35; }
	inline void set_startState_35(LP_1_t527833255 * value)
	{
		___startState_35 = value;
		Il2CppCodeGenWriteBarrier(&___startState_35, value);
	}

	inline static int32_t get_offset_of_st_36() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___st_36)); }
	inline LP_1_t527833255 * get_st_36() const { return ___st_36; }
	inline LP_1_t527833255 ** get_address_of_st_36() { return &___st_36; }
	inline void set_st_36(LP_1_t527833255 * value)
	{
		___st_36 = value;
		Il2CppCodeGenWriteBarrier(&___st_36, value);
	}

	inline static int32_t get_offset_of_gamePly_37() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___gamePly_37)); }
	inline VP_1_t2450154454 * get_gamePly_37() const { return ___gamePly_37; }
	inline VP_1_t2450154454 ** get_address_of_gamePly_37() { return &___gamePly_37; }
	inline void set_gamePly_37(VP_1_t2450154454 * value)
	{
		___gamePly_37 = value;
		Il2CppCodeGenWriteBarrier(&___gamePly_37, value);
	}

	inline static int32_t get_offset_of_nodes_38() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___nodes_38)); }
	inline VP_1_t1287355043 * get_nodes_38() const { return ___nodes_38; }
	inline VP_1_t1287355043 ** get_address_of_nodes_38() { return &___nodes_38; }
	inline void set_nodes_38(VP_1_t1287355043 * value)
	{
		___nodes_38 = value;
		Il2CppCodeGenWriteBarrier(&___nodes_38, value);
	}

	inline static int32_t get_offset_of_isCustom_39() { return static_cast<int32_t>(offsetof(Shogi_t1975542802, ___isCustom_39)); }
	inline VP_1_t4203851724 * get_isCustom_39() const { return ___isCustom_39; }
	inline VP_1_t4203851724 ** get_address_of_isCustom_39() { return &___isCustom_39; }
	inline void set_isCustom_39(VP_1_t4203851724 * value)
	{
		___isCustom_39 = value;
		Il2CppCodeGenWriteBarrier(&___isCustom_39, value);
	}
};

struct Shogi_t1975542802_StaticFields
{
public:
	// System.Int32[] Shogi.Shogi::HandPieceShiftBits
	Int32U5BU5D_t3030399641* ___HandPieceShiftBits_30;
	// System.UInt32[] Shogi.Shogi::HandPieceMask
	UInt32U5BU5D_t59386216* ___HandPieceMask_31;
	// System.UInt32[] Shogi.Shogi::HandPieceOne
	UInt32U5BU5D_t59386216* ___HandPieceOne_32;
	// System.Collections.Generic.List`1<System.Byte> Shogi.Shogi::AllowNames
	List_1_t3052225568 * ___AllowNames_40;
	// System.Boolean Shogi.Shogi::parseLog
	bool ___parseLog_41;

public:
	inline static int32_t get_offset_of_HandPieceShiftBits_30() { return static_cast<int32_t>(offsetof(Shogi_t1975542802_StaticFields, ___HandPieceShiftBits_30)); }
	inline Int32U5BU5D_t3030399641* get_HandPieceShiftBits_30() const { return ___HandPieceShiftBits_30; }
	inline Int32U5BU5D_t3030399641** get_address_of_HandPieceShiftBits_30() { return &___HandPieceShiftBits_30; }
	inline void set_HandPieceShiftBits_30(Int32U5BU5D_t3030399641* value)
	{
		___HandPieceShiftBits_30 = value;
		Il2CppCodeGenWriteBarrier(&___HandPieceShiftBits_30, value);
	}

	inline static int32_t get_offset_of_HandPieceMask_31() { return static_cast<int32_t>(offsetof(Shogi_t1975542802_StaticFields, ___HandPieceMask_31)); }
	inline UInt32U5BU5D_t59386216* get_HandPieceMask_31() const { return ___HandPieceMask_31; }
	inline UInt32U5BU5D_t59386216** get_address_of_HandPieceMask_31() { return &___HandPieceMask_31; }
	inline void set_HandPieceMask_31(UInt32U5BU5D_t59386216* value)
	{
		___HandPieceMask_31 = value;
		Il2CppCodeGenWriteBarrier(&___HandPieceMask_31, value);
	}

	inline static int32_t get_offset_of_HandPieceOne_32() { return static_cast<int32_t>(offsetof(Shogi_t1975542802_StaticFields, ___HandPieceOne_32)); }
	inline UInt32U5BU5D_t59386216* get_HandPieceOne_32() const { return ___HandPieceOne_32; }
	inline UInt32U5BU5D_t59386216** get_address_of_HandPieceOne_32() { return &___HandPieceOne_32; }
	inline void set_HandPieceOne_32(UInt32U5BU5D_t59386216* value)
	{
		___HandPieceOne_32 = value;
		Il2CppCodeGenWriteBarrier(&___HandPieceOne_32, value);
	}

	inline static int32_t get_offset_of_AllowNames_40() { return static_cast<int32_t>(offsetof(Shogi_t1975542802_StaticFields, ___AllowNames_40)); }
	inline List_1_t3052225568 * get_AllowNames_40() const { return ___AllowNames_40; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_40() { return &___AllowNames_40; }
	inline void set_AllowNames_40(List_1_t3052225568 * value)
	{
		___AllowNames_40 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_40, value);
	}

	inline static int32_t get_offset_of_parseLog_41() { return static_cast<int32_t>(offsetof(Shogi_t1975542802_StaticFields, ___parseLog_41)); }
	inline bool get_parseLog_41() const { return ___parseLog_41; }
	inline bool* get_address_of_parseLog_41() { return &___parseLog_41; }
	inline void set_parseLog_41(bool value)
	{
		___parseLog_41 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
