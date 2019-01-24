#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<Weiqi.WeiqiMove>
struct VP_1_t428190090;
// VP`1<System.Byte>
struct VP_1_t4061381442;
// LP`1<System.UInt32>
struct LP_1_t887425977;
// LP`1<Weiqi.Group>
struct LP_1_t1255205619;
// VP`1<Weiqi.BoardSymmetry>
struct VP_1_t1597535086;
// LP`1<System.UInt64>
struct LP_1_t1646940870;
// VP`1<System.UInt64>
struct VP_1_t3287473920;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.Board
struct  Board_t3888677276  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Weiqi.Board::size
	VP_1_t2450154454 * ___size_7;
	// VP`1<System.Int32> Weiqi.Board::size2
	VP_1_t2450154454 * ___size2_8;
	// VP`1<System.Int32> Weiqi.Board::bits2
	VP_1_t2450154454 * ___bits2_9;
	// LP`1<System.Int32> Weiqi.Board::captures
	LP_1_t809621404 * ___captures_10;
	// VP`1<System.Single> Weiqi.Board::komi
	VP_1_t2454786938 * ___komi_11;
	// VP`1<System.Int32> Weiqi.Board::handicap
	VP_1_t2450154454 * ___handicap_12;
	// VP`1<System.Int32> Weiqi.Board::rules
	VP_1_t2450154454 * ___rules_13;
	// VP`1<System.Int32> Weiqi.Board::moves
	VP_1_t2450154454 * ___moves_14;
	// VP`1<Weiqi.WeiqiMove> Weiqi.Board::last_move
	VP_1_t428190090 * ___last_move_15;
	// VP`1<Weiqi.WeiqiMove> Weiqi.Board::last_move2
	VP_1_t428190090 * ___last_move2_16;
	// VP`1<Weiqi.WeiqiMove> Weiqi.Board::last_move3
	VP_1_t428190090 * ___last_move3_17;
	// VP`1<Weiqi.WeiqiMove> Weiqi.Board::last_move4
	VP_1_t428190090 * ___last_move4_18;
	// VP`1<System.Byte> Weiqi.Board::superko_violation
	VP_1_t4061381442 * ___superko_violation_19;
	// LP`1<System.Int32> Weiqi.Board::b
	LP_1_t809621404 * ___b_20;
	// LP`1<System.Int32> Weiqi.Board::g
	LP_1_t809621404 * ___g_21;
	// LP`1<System.Int32> Weiqi.Board::pp
	LP_1_t809621404 * ___pp_22;
	// LP`1<System.UInt32> Weiqi.Board::pat3
	LP_1_t887425977 * ___pat3_23;
	// LP`1<Weiqi.Group> Weiqi.Board::gi
	LP_1_t1255205619 * ___gi_24;
	// LP`1<System.Int32> Weiqi.Board::c
	LP_1_t809621404 * ___c_25;
	// VP`1<System.Int32> Weiqi.Board::clen
	VP_1_t2450154454 * ___clen_26;
	// VP`1<Weiqi.BoardSymmetry> Weiqi.Board::symmetry
	VP_1_t1597535086 * ___symmetry_27;
	// VP`1<Weiqi.WeiqiMove> Weiqi.Board::last_ko
	VP_1_t428190090 * ___last_ko_28;
	// VP`1<System.Int32> Weiqi.Board::last_ko_age
	VP_1_t2450154454 * ___last_ko_age_29;
	// VP`1<Weiqi.WeiqiMove> Weiqi.Board::ko
	VP_1_t428190090 * ___ko_30;
	// VP`1<System.Int32> Weiqi.Board::quicked
	VP_1_t2450154454 * ___quicked_31;
	// LP`1<System.UInt64> Weiqi.Board::history_hash
	LP_1_t1646940870 * ___history_hash_32;
	// VP`1<System.UInt64> Weiqi.Board::hash
	VP_1_t3287473920 * ___hash_33;
	// LP`1<System.UInt64> Weiqi.Board::qhash
	LP_1_t1646940870 * ___qhash_34;

public:
	inline static int32_t get_offset_of_size_7() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___size_7)); }
	inline VP_1_t2450154454 * get_size_7() const { return ___size_7; }
	inline VP_1_t2450154454 ** get_address_of_size_7() { return &___size_7; }
	inline void set_size_7(VP_1_t2450154454 * value)
	{
		___size_7 = value;
		Il2CppCodeGenWriteBarrier(&___size_7, value);
	}

	inline static int32_t get_offset_of_size2_8() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___size2_8)); }
	inline VP_1_t2450154454 * get_size2_8() const { return ___size2_8; }
	inline VP_1_t2450154454 ** get_address_of_size2_8() { return &___size2_8; }
	inline void set_size2_8(VP_1_t2450154454 * value)
	{
		___size2_8 = value;
		Il2CppCodeGenWriteBarrier(&___size2_8, value);
	}

	inline static int32_t get_offset_of_bits2_9() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___bits2_9)); }
	inline VP_1_t2450154454 * get_bits2_9() const { return ___bits2_9; }
	inline VP_1_t2450154454 ** get_address_of_bits2_9() { return &___bits2_9; }
	inline void set_bits2_9(VP_1_t2450154454 * value)
	{
		___bits2_9 = value;
		Il2CppCodeGenWriteBarrier(&___bits2_9, value);
	}

	inline static int32_t get_offset_of_captures_10() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___captures_10)); }
	inline LP_1_t809621404 * get_captures_10() const { return ___captures_10; }
	inline LP_1_t809621404 ** get_address_of_captures_10() { return &___captures_10; }
	inline void set_captures_10(LP_1_t809621404 * value)
	{
		___captures_10 = value;
		Il2CppCodeGenWriteBarrier(&___captures_10, value);
	}

	inline static int32_t get_offset_of_komi_11() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___komi_11)); }
	inline VP_1_t2454786938 * get_komi_11() const { return ___komi_11; }
	inline VP_1_t2454786938 ** get_address_of_komi_11() { return &___komi_11; }
	inline void set_komi_11(VP_1_t2454786938 * value)
	{
		___komi_11 = value;
		Il2CppCodeGenWriteBarrier(&___komi_11, value);
	}

	inline static int32_t get_offset_of_handicap_12() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___handicap_12)); }
	inline VP_1_t2450154454 * get_handicap_12() const { return ___handicap_12; }
	inline VP_1_t2450154454 ** get_address_of_handicap_12() { return &___handicap_12; }
	inline void set_handicap_12(VP_1_t2450154454 * value)
	{
		___handicap_12 = value;
		Il2CppCodeGenWriteBarrier(&___handicap_12, value);
	}

	inline static int32_t get_offset_of_rules_13() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___rules_13)); }
	inline VP_1_t2450154454 * get_rules_13() const { return ___rules_13; }
	inline VP_1_t2450154454 ** get_address_of_rules_13() { return &___rules_13; }
	inline void set_rules_13(VP_1_t2450154454 * value)
	{
		___rules_13 = value;
		Il2CppCodeGenWriteBarrier(&___rules_13, value);
	}

	inline static int32_t get_offset_of_moves_14() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___moves_14)); }
	inline VP_1_t2450154454 * get_moves_14() const { return ___moves_14; }
	inline VP_1_t2450154454 ** get_address_of_moves_14() { return &___moves_14; }
	inline void set_moves_14(VP_1_t2450154454 * value)
	{
		___moves_14 = value;
		Il2CppCodeGenWriteBarrier(&___moves_14, value);
	}

	inline static int32_t get_offset_of_last_move_15() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___last_move_15)); }
	inline VP_1_t428190090 * get_last_move_15() const { return ___last_move_15; }
	inline VP_1_t428190090 ** get_address_of_last_move_15() { return &___last_move_15; }
	inline void set_last_move_15(VP_1_t428190090 * value)
	{
		___last_move_15 = value;
		Il2CppCodeGenWriteBarrier(&___last_move_15, value);
	}

	inline static int32_t get_offset_of_last_move2_16() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___last_move2_16)); }
	inline VP_1_t428190090 * get_last_move2_16() const { return ___last_move2_16; }
	inline VP_1_t428190090 ** get_address_of_last_move2_16() { return &___last_move2_16; }
	inline void set_last_move2_16(VP_1_t428190090 * value)
	{
		___last_move2_16 = value;
		Il2CppCodeGenWriteBarrier(&___last_move2_16, value);
	}

	inline static int32_t get_offset_of_last_move3_17() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___last_move3_17)); }
	inline VP_1_t428190090 * get_last_move3_17() const { return ___last_move3_17; }
	inline VP_1_t428190090 ** get_address_of_last_move3_17() { return &___last_move3_17; }
	inline void set_last_move3_17(VP_1_t428190090 * value)
	{
		___last_move3_17 = value;
		Il2CppCodeGenWriteBarrier(&___last_move3_17, value);
	}

	inline static int32_t get_offset_of_last_move4_18() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___last_move4_18)); }
	inline VP_1_t428190090 * get_last_move4_18() const { return ___last_move4_18; }
	inline VP_1_t428190090 ** get_address_of_last_move4_18() { return &___last_move4_18; }
	inline void set_last_move4_18(VP_1_t428190090 * value)
	{
		___last_move4_18 = value;
		Il2CppCodeGenWriteBarrier(&___last_move4_18, value);
	}

	inline static int32_t get_offset_of_superko_violation_19() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___superko_violation_19)); }
	inline VP_1_t4061381442 * get_superko_violation_19() const { return ___superko_violation_19; }
	inline VP_1_t4061381442 ** get_address_of_superko_violation_19() { return &___superko_violation_19; }
	inline void set_superko_violation_19(VP_1_t4061381442 * value)
	{
		___superko_violation_19 = value;
		Il2CppCodeGenWriteBarrier(&___superko_violation_19, value);
	}

	inline static int32_t get_offset_of_b_20() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___b_20)); }
	inline LP_1_t809621404 * get_b_20() const { return ___b_20; }
	inline LP_1_t809621404 ** get_address_of_b_20() { return &___b_20; }
	inline void set_b_20(LP_1_t809621404 * value)
	{
		___b_20 = value;
		Il2CppCodeGenWriteBarrier(&___b_20, value);
	}

	inline static int32_t get_offset_of_g_21() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___g_21)); }
	inline LP_1_t809621404 * get_g_21() const { return ___g_21; }
	inline LP_1_t809621404 ** get_address_of_g_21() { return &___g_21; }
	inline void set_g_21(LP_1_t809621404 * value)
	{
		___g_21 = value;
		Il2CppCodeGenWriteBarrier(&___g_21, value);
	}

	inline static int32_t get_offset_of_pp_22() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___pp_22)); }
	inline LP_1_t809621404 * get_pp_22() const { return ___pp_22; }
	inline LP_1_t809621404 ** get_address_of_pp_22() { return &___pp_22; }
	inline void set_pp_22(LP_1_t809621404 * value)
	{
		___pp_22 = value;
		Il2CppCodeGenWriteBarrier(&___pp_22, value);
	}

	inline static int32_t get_offset_of_pat3_23() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___pat3_23)); }
	inline LP_1_t887425977 * get_pat3_23() const { return ___pat3_23; }
	inline LP_1_t887425977 ** get_address_of_pat3_23() { return &___pat3_23; }
	inline void set_pat3_23(LP_1_t887425977 * value)
	{
		___pat3_23 = value;
		Il2CppCodeGenWriteBarrier(&___pat3_23, value);
	}

	inline static int32_t get_offset_of_gi_24() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___gi_24)); }
	inline LP_1_t1255205619 * get_gi_24() const { return ___gi_24; }
	inline LP_1_t1255205619 ** get_address_of_gi_24() { return &___gi_24; }
	inline void set_gi_24(LP_1_t1255205619 * value)
	{
		___gi_24 = value;
		Il2CppCodeGenWriteBarrier(&___gi_24, value);
	}

	inline static int32_t get_offset_of_c_25() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___c_25)); }
	inline LP_1_t809621404 * get_c_25() const { return ___c_25; }
	inline LP_1_t809621404 ** get_address_of_c_25() { return &___c_25; }
	inline void set_c_25(LP_1_t809621404 * value)
	{
		___c_25 = value;
		Il2CppCodeGenWriteBarrier(&___c_25, value);
	}

	inline static int32_t get_offset_of_clen_26() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___clen_26)); }
	inline VP_1_t2450154454 * get_clen_26() const { return ___clen_26; }
	inline VP_1_t2450154454 ** get_address_of_clen_26() { return &___clen_26; }
	inline void set_clen_26(VP_1_t2450154454 * value)
	{
		___clen_26 = value;
		Il2CppCodeGenWriteBarrier(&___clen_26, value);
	}

	inline static int32_t get_offset_of_symmetry_27() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___symmetry_27)); }
	inline VP_1_t1597535086 * get_symmetry_27() const { return ___symmetry_27; }
	inline VP_1_t1597535086 ** get_address_of_symmetry_27() { return &___symmetry_27; }
	inline void set_symmetry_27(VP_1_t1597535086 * value)
	{
		___symmetry_27 = value;
		Il2CppCodeGenWriteBarrier(&___symmetry_27, value);
	}

	inline static int32_t get_offset_of_last_ko_28() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___last_ko_28)); }
	inline VP_1_t428190090 * get_last_ko_28() const { return ___last_ko_28; }
	inline VP_1_t428190090 ** get_address_of_last_ko_28() { return &___last_ko_28; }
	inline void set_last_ko_28(VP_1_t428190090 * value)
	{
		___last_ko_28 = value;
		Il2CppCodeGenWriteBarrier(&___last_ko_28, value);
	}

	inline static int32_t get_offset_of_last_ko_age_29() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___last_ko_age_29)); }
	inline VP_1_t2450154454 * get_last_ko_age_29() const { return ___last_ko_age_29; }
	inline VP_1_t2450154454 ** get_address_of_last_ko_age_29() { return &___last_ko_age_29; }
	inline void set_last_ko_age_29(VP_1_t2450154454 * value)
	{
		___last_ko_age_29 = value;
		Il2CppCodeGenWriteBarrier(&___last_ko_age_29, value);
	}

	inline static int32_t get_offset_of_ko_30() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___ko_30)); }
	inline VP_1_t428190090 * get_ko_30() const { return ___ko_30; }
	inline VP_1_t428190090 ** get_address_of_ko_30() { return &___ko_30; }
	inline void set_ko_30(VP_1_t428190090 * value)
	{
		___ko_30 = value;
		Il2CppCodeGenWriteBarrier(&___ko_30, value);
	}

	inline static int32_t get_offset_of_quicked_31() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___quicked_31)); }
	inline VP_1_t2450154454 * get_quicked_31() const { return ___quicked_31; }
	inline VP_1_t2450154454 ** get_address_of_quicked_31() { return &___quicked_31; }
	inline void set_quicked_31(VP_1_t2450154454 * value)
	{
		___quicked_31 = value;
		Il2CppCodeGenWriteBarrier(&___quicked_31, value);
	}

	inline static int32_t get_offset_of_history_hash_32() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___history_hash_32)); }
	inline LP_1_t1646940870 * get_history_hash_32() const { return ___history_hash_32; }
	inline LP_1_t1646940870 ** get_address_of_history_hash_32() { return &___history_hash_32; }
	inline void set_history_hash_32(LP_1_t1646940870 * value)
	{
		___history_hash_32 = value;
		Il2CppCodeGenWriteBarrier(&___history_hash_32, value);
	}

	inline static int32_t get_offset_of_hash_33() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___hash_33)); }
	inline VP_1_t3287473920 * get_hash_33() const { return ___hash_33; }
	inline VP_1_t3287473920 ** get_address_of_hash_33() { return &___hash_33; }
	inline void set_hash_33(VP_1_t3287473920 * value)
	{
		___hash_33 = value;
		Il2CppCodeGenWriteBarrier(&___hash_33, value);
	}

	inline static int32_t get_offset_of_qhash_34() { return static_cast<int32_t>(offsetof(Board_t3888677276, ___qhash_34)); }
	inline LP_1_t1646940870 * get_qhash_34() const { return ___qhash_34; }
	inline LP_1_t1646940870 ** get_address_of_qhash_34() { return &___qhash_34; }
	inline void set_qhash_34(LP_1_t1646940870 * value)
	{
		___qhash_34 = value;
		Il2CppCodeGenWriteBarrier(&___qhash_34, value);
	}
};

struct Board_t3888677276_StaticFields
{
public:
	// System.Boolean Weiqi.Board::log
	bool ___log_6;

public:
	inline static int32_t get_offset_of_log_6() { return static_cast<int32_t>(offsetof(Board_t3888677276_StaticFields, ___log_6)); }
	inline bool get_log_6() const { return ___log_6; }
	inline bool* get_address_of_log_6() { return &___log_6; }
	inline void set_log_6(bool value)
	{
		___log_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
