#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// DataIdentity/SyncListUInt64
struct SyncListUInt64_t567569778;
// NetData`1<Weiqi.Board>
struct NetData_1_t4135025801;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.BoardIdentity
struct  BoardIdentity_t2448856946  : public DataIdentity_t543951486
{
public:
	// System.Int32 Weiqi.BoardIdentity::size
	int32_t ___size_17;
	// System.Int32 Weiqi.BoardIdentity::size2
	int32_t ___size2_18;
	// System.Int32 Weiqi.BoardIdentity::bits2
	int32_t ___bits2_19;
	// UnityEngine.Networking.SyncListInt Weiqi.BoardIdentity::captures
	SyncListInt_t3316705628 * ___captures_20;
	// System.Single Weiqi.BoardIdentity::komi
	float ___komi_21;
	// System.Int32 Weiqi.BoardIdentity::handicap
	int32_t ___handicap_22;
	// System.Int32 Weiqi.BoardIdentity::rules
	int32_t ___rules_23;
	// System.Int32 Weiqi.BoardIdentity::moves
	int32_t ___moves_24;
	// System.Byte Weiqi.BoardIdentity::superko_violation
	uint8_t ___superko_violation_25;
	// UnityEngine.Networking.SyncListInt Weiqi.BoardIdentity::b
	SyncListInt_t3316705628 * ___b_26;
	// UnityEngine.Networking.SyncListInt Weiqi.BoardIdentity::g
	SyncListInt_t3316705628 * ___g_27;
	// UnityEngine.Networking.SyncListInt Weiqi.BoardIdentity::pp
	SyncListInt_t3316705628 * ___pp_28;
	// UnityEngine.Networking.SyncListUInt Weiqi.BoardIdentity::pat3
	SyncListUInt_t2190275715 * ___pat3_29;
	// UnityEngine.Networking.SyncListInt Weiqi.BoardIdentity::c
	SyncListInt_t3316705628 * ___c_30;
	// System.Int32 Weiqi.BoardIdentity::clen
	int32_t ___clen_31;
	// System.Int32 Weiqi.BoardIdentity::last_ko_age
	int32_t ___last_ko_age_32;
	// System.Int32 Weiqi.BoardIdentity::quicked
	int32_t ___quicked_33;
	// DataIdentity/SyncListUInt64 Weiqi.BoardIdentity::history_hash
	SyncListUInt64_t567569778 * ___history_hash_34;
	// System.UInt64 Weiqi.BoardIdentity::hash
	uint64_t ___hash_35;
	// DataIdentity/SyncListUInt64 Weiqi.BoardIdentity::qhash
	SyncListUInt64_t567569778 * ___qhash_36;
	// NetData`1<Weiqi.Board> Weiqi.BoardIdentity::netData
	NetData_1_t4135025801 * ___netData_37;

public:
	inline static int32_t get_offset_of_size_17() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___size_17)); }
	inline int32_t get_size_17() const { return ___size_17; }
	inline int32_t* get_address_of_size_17() { return &___size_17; }
	inline void set_size_17(int32_t value)
	{
		___size_17 = value;
	}

	inline static int32_t get_offset_of_size2_18() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___size2_18)); }
	inline int32_t get_size2_18() const { return ___size2_18; }
	inline int32_t* get_address_of_size2_18() { return &___size2_18; }
	inline void set_size2_18(int32_t value)
	{
		___size2_18 = value;
	}

	inline static int32_t get_offset_of_bits2_19() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___bits2_19)); }
	inline int32_t get_bits2_19() const { return ___bits2_19; }
	inline int32_t* get_address_of_bits2_19() { return &___bits2_19; }
	inline void set_bits2_19(int32_t value)
	{
		___bits2_19 = value;
	}

	inline static int32_t get_offset_of_captures_20() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___captures_20)); }
	inline SyncListInt_t3316705628 * get_captures_20() const { return ___captures_20; }
	inline SyncListInt_t3316705628 ** get_address_of_captures_20() { return &___captures_20; }
	inline void set_captures_20(SyncListInt_t3316705628 * value)
	{
		___captures_20 = value;
		Il2CppCodeGenWriteBarrier(&___captures_20, value);
	}

	inline static int32_t get_offset_of_komi_21() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___komi_21)); }
	inline float get_komi_21() const { return ___komi_21; }
	inline float* get_address_of_komi_21() { return &___komi_21; }
	inline void set_komi_21(float value)
	{
		___komi_21 = value;
	}

	inline static int32_t get_offset_of_handicap_22() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___handicap_22)); }
	inline int32_t get_handicap_22() const { return ___handicap_22; }
	inline int32_t* get_address_of_handicap_22() { return &___handicap_22; }
	inline void set_handicap_22(int32_t value)
	{
		___handicap_22 = value;
	}

	inline static int32_t get_offset_of_rules_23() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___rules_23)); }
	inline int32_t get_rules_23() const { return ___rules_23; }
	inline int32_t* get_address_of_rules_23() { return &___rules_23; }
	inline void set_rules_23(int32_t value)
	{
		___rules_23 = value;
	}

	inline static int32_t get_offset_of_moves_24() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___moves_24)); }
	inline int32_t get_moves_24() const { return ___moves_24; }
	inline int32_t* get_address_of_moves_24() { return &___moves_24; }
	inline void set_moves_24(int32_t value)
	{
		___moves_24 = value;
	}

	inline static int32_t get_offset_of_superko_violation_25() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___superko_violation_25)); }
	inline uint8_t get_superko_violation_25() const { return ___superko_violation_25; }
	inline uint8_t* get_address_of_superko_violation_25() { return &___superko_violation_25; }
	inline void set_superko_violation_25(uint8_t value)
	{
		___superko_violation_25 = value;
	}

	inline static int32_t get_offset_of_b_26() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___b_26)); }
	inline SyncListInt_t3316705628 * get_b_26() const { return ___b_26; }
	inline SyncListInt_t3316705628 ** get_address_of_b_26() { return &___b_26; }
	inline void set_b_26(SyncListInt_t3316705628 * value)
	{
		___b_26 = value;
		Il2CppCodeGenWriteBarrier(&___b_26, value);
	}

	inline static int32_t get_offset_of_g_27() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___g_27)); }
	inline SyncListInt_t3316705628 * get_g_27() const { return ___g_27; }
	inline SyncListInt_t3316705628 ** get_address_of_g_27() { return &___g_27; }
	inline void set_g_27(SyncListInt_t3316705628 * value)
	{
		___g_27 = value;
		Il2CppCodeGenWriteBarrier(&___g_27, value);
	}

	inline static int32_t get_offset_of_pp_28() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___pp_28)); }
	inline SyncListInt_t3316705628 * get_pp_28() const { return ___pp_28; }
	inline SyncListInt_t3316705628 ** get_address_of_pp_28() { return &___pp_28; }
	inline void set_pp_28(SyncListInt_t3316705628 * value)
	{
		___pp_28 = value;
		Il2CppCodeGenWriteBarrier(&___pp_28, value);
	}

	inline static int32_t get_offset_of_pat3_29() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___pat3_29)); }
	inline SyncListUInt_t2190275715 * get_pat3_29() const { return ___pat3_29; }
	inline SyncListUInt_t2190275715 ** get_address_of_pat3_29() { return &___pat3_29; }
	inline void set_pat3_29(SyncListUInt_t2190275715 * value)
	{
		___pat3_29 = value;
		Il2CppCodeGenWriteBarrier(&___pat3_29, value);
	}

	inline static int32_t get_offset_of_c_30() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___c_30)); }
	inline SyncListInt_t3316705628 * get_c_30() const { return ___c_30; }
	inline SyncListInt_t3316705628 ** get_address_of_c_30() { return &___c_30; }
	inline void set_c_30(SyncListInt_t3316705628 * value)
	{
		___c_30 = value;
		Il2CppCodeGenWriteBarrier(&___c_30, value);
	}

	inline static int32_t get_offset_of_clen_31() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___clen_31)); }
	inline int32_t get_clen_31() const { return ___clen_31; }
	inline int32_t* get_address_of_clen_31() { return &___clen_31; }
	inline void set_clen_31(int32_t value)
	{
		___clen_31 = value;
	}

	inline static int32_t get_offset_of_last_ko_age_32() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___last_ko_age_32)); }
	inline int32_t get_last_ko_age_32() const { return ___last_ko_age_32; }
	inline int32_t* get_address_of_last_ko_age_32() { return &___last_ko_age_32; }
	inline void set_last_ko_age_32(int32_t value)
	{
		___last_ko_age_32 = value;
	}

	inline static int32_t get_offset_of_quicked_33() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___quicked_33)); }
	inline int32_t get_quicked_33() const { return ___quicked_33; }
	inline int32_t* get_address_of_quicked_33() { return &___quicked_33; }
	inline void set_quicked_33(int32_t value)
	{
		___quicked_33 = value;
	}

	inline static int32_t get_offset_of_history_hash_34() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___history_hash_34)); }
	inline SyncListUInt64_t567569778 * get_history_hash_34() const { return ___history_hash_34; }
	inline SyncListUInt64_t567569778 ** get_address_of_history_hash_34() { return &___history_hash_34; }
	inline void set_history_hash_34(SyncListUInt64_t567569778 * value)
	{
		___history_hash_34 = value;
		Il2CppCodeGenWriteBarrier(&___history_hash_34, value);
	}

	inline static int32_t get_offset_of_hash_35() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___hash_35)); }
	inline uint64_t get_hash_35() const { return ___hash_35; }
	inline uint64_t* get_address_of_hash_35() { return &___hash_35; }
	inline void set_hash_35(uint64_t value)
	{
		___hash_35 = value;
	}

	inline static int32_t get_offset_of_qhash_36() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___qhash_36)); }
	inline SyncListUInt64_t567569778 * get_qhash_36() const { return ___qhash_36; }
	inline SyncListUInt64_t567569778 ** get_address_of_qhash_36() { return &___qhash_36; }
	inline void set_qhash_36(SyncListUInt64_t567569778 * value)
	{
		___qhash_36 = value;
		Il2CppCodeGenWriteBarrier(&___qhash_36, value);
	}

	inline static int32_t get_offset_of_netData_37() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946, ___netData_37)); }
	inline NetData_1_t4135025801 * get_netData_37() const { return ___netData_37; }
	inline NetData_1_t4135025801 ** get_address_of_netData_37() { return &___netData_37; }
	inline void set_netData_37(NetData_1_t4135025801 * value)
	{
		___netData_37 = value;
		Il2CppCodeGenWriteBarrier(&___netData_37, value);
	}
};

struct BoardIdentity_t2448856946_StaticFields
{
public:
	// System.Int32 Weiqi.BoardIdentity::kListcaptures
	int32_t ___kListcaptures_38;
	// System.Int32 Weiqi.BoardIdentity::kListb
	int32_t ___kListb_39;
	// System.Int32 Weiqi.BoardIdentity::kListg
	int32_t ___kListg_40;
	// System.Int32 Weiqi.BoardIdentity::kListpp
	int32_t ___kListpp_41;
	// System.Int32 Weiqi.BoardIdentity::kListpat3
	int32_t ___kListpat3_42;
	// System.Int32 Weiqi.BoardIdentity::kListc
	int32_t ___kListc_43;
	// System.Int32 Weiqi.BoardIdentity::kListhistory_hash
	int32_t ___kListhistory_hash_44;
	// System.Int32 Weiqi.BoardIdentity::kListqhash
	int32_t ___kListqhash_45;

public:
	inline static int32_t get_offset_of_kListcaptures_38() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListcaptures_38)); }
	inline int32_t get_kListcaptures_38() const { return ___kListcaptures_38; }
	inline int32_t* get_address_of_kListcaptures_38() { return &___kListcaptures_38; }
	inline void set_kListcaptures_38(int32_t value)
	{
		___kListcaptures_38 = value;
	}

	inline static int32_t get_offset_of_kListb_39() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListb_39)); }
	inline int32_t get_kListb_39() const { return ___kListb_39; }
	inline int32_t* get_address_of_kListb_39() { return &___kListb_39; }
	inline void set_kListb_39(int32_t value)
	{
		___kListb_39 = value;
	}

	inline static int32_t get_offset_of_kListg_40() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListg_40)); }
	inline int32_t get_kListg_40() const { return ___kListg_40; }
	inline int32_t* get_address_of_kListg_40() { return &___kListg_40; }
	inline void set_kListg_40(int32_t value)
	{
		___kListg_40 = value;
	}

	inline static int32_t get_offset_of_kListpp_41() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListpp_41)); }
	inline int32_t get_kListpp_41() const { return ___kListpp_41; }
	inline int32_t* get_address_of_kListpp_41() { return &___kListpp_41; }
	inline void set_kListpp_41(int32_t value)
	{
		___kListpp_41 = value;
	}

	inline static int32_t get_offset_of_kListpat3_42() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListpat3_42)); }
	inline int32_t get_kListpat3_42() const { return ___kListpat3_42; }
	inline int32_t* get_address_of_kListpat3_42() { return &___kListpat3_42; }
	inline void set_kListpat3_42(int32_t value)
	{
		___kListpat3_42 = value;
	}

	inline static int32_t get_offset_of_kListc_43() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListc_43)); }
	inline int32_t get_kListc_43() const { return ___kListc_43; }
	inline int32_t* get_address_of_kListc_43() { return &___kListc_43; }
	inline void set_kListc_43(int32_t value)
	{
		___kListc_43 = value;
	}

	inline static int32_t get_offset_of_kListhistory_hash_44() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListhistory_hash_44)); }
	inline int32_t get_kListhistory_hash_44() const { return ___kListhistory_hash_44; }
	inline int32_t* get_address_of_kListhistory_hash_44() { return &___kListhistory_hash_44; }
	inline void set_kListhistory_hash_44(int32_t value)
	{
		___kListhistory_hash_44 = value;
	}

	inline static int32_t get_offset_of_kListqhash_45() { return static_cast<int32_t>(offsetof(BoardIdentity_t2448856946_StaticFields, ___kListqhash_45)); }
	inline int32_t get_kListqhash_45() const { return ___kListqhash_45; }
	inline int32_t* get_address_of_kListqhash_45() { return &___kListqhash_45; }
	inline void set_kListqhash_45(int32_t value)
	{
		___kListqhash_45 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
