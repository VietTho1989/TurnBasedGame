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
// DataIdentity/SyncListUInt64
struct SyncListUInt64_t567569778;
// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// UnityEngine.Networking.SyncListBool
struct SyncListBool_t375623471;
// NetData`1<RussianDraught.RussianDraught>
struct NetData_1_t3646328225;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtIdentity
struct  RussianDraughtIdentity_t1425899598  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt RussianDraught.RussianDraughtIdentity::Board
	SyncListInt_t3316705628 * ___Board_17;
	// System.UInt32 RussianDraught.RussianDraughtIdentity::num_wpieces
	uint32_t ___num_wpieces_18;
	// System.UInt32 RussianDraught.RussianDraughtIdentity::num_bpieces
	uint32_t ___num_bpieces_19;
	// System.Int32 RussianDraught.RussianDraughtIdentity::Color
	int32_t ___Color_20;
	// System.Int32 RussianDraught.RussianDraughtIdentity::g_root_mb
	int32_t ___g_root_mb_21;
	// System.Int32 RussianDraught.RussianDraughtIdentity::realdepth
	int32_t ___realdepth_22;
	// DataIdentity/SyncListUInt64 RussianDraught.RussianDraughtIdentity::RepNum
	SyncListUInt64_t567569778 * ___RepNum_23;
	// System.UInt64 RussianDraught.RussianDraughtIdentity::HASH_KEY
	uint64_t ___HASH_KEY_24;
	// UnityEngine.Networking.SyncListUInt RussianDraught.RussianDraughtIdentity::p_list
	SyncListUInt_t2190275715 * ___p_list_25;
	// UnityEngine.Networking.SyncListUInt RussianDraught.RussianDraughtIdentity::indices
	SyncListUInt_t2190275715 * ___indices_26;
	// UnityEngine.Networking.SyncListInt RussianDraught.RussianDraughtIdentity::g_pieces
	SyncListInt_t3316705628 * ___g_pieces_27;
	// UnityEngine.Networking.SyncListBool RussianDraught.RussianDraughtIdentity::Reversible
	SyncListBool_t375623471 * ___Reversible_28;
	// UnityEngine.Networking.SyncListUInt RussianDraught.RussianDraughtIdentity::c_num
	SyncListUInt_t2190275715 * ___c_num_29;
	// System.Boolean RussianDraught.RussianDraughtIdentity::isCustom
	bool ___isCustom_30;
	// NetData`1<RussianDraught.RussianDraught> RussianDraught.RussianDraughtIdentity::netData
	NetData_1_t3646328225 * ___netData_31;

public:
	inline static int32_t get_offset_of_Board_17() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___Board_17)); }
	inline SyncListInt_t3316705628 * get_Board_17() const { return ___Board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_Board_17() { return &___Board_17; }
	inline void set_Board_17(SyncListInt_t3316705628 * value)
	{
		___Board_17 = value;
		Il2CppCodeGenWriteBarrier(&___Board_17, value);
	}

	inline static int32_t get_offset_of_num_wpieces_18() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___num_wpieces_18)); }
	inline uint32_t get_num_wpieces_18() const { return ___num_wpieces_18; }
	inline uint32_t* get_address_of_num_wpieces_18() { return &___num_wpieces_18; }
	inline void set_num_wpieces_18(uint32_t value)
	{
		___num_wpieces_18 = value;
	}

	inline static int32_t get_offset_of_num_bpieces_19() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___num_bpieces_19)); }
	inline uint32_t get_num_bpieces_19() const { return ___num_bpieces_19; }
	inline uint32_t* get_address_of_num_bpieces_19() { return &___num_bpieces_19; }
	inline void set_num_bpieces_19(uint32_t value)
	{
		___num_bpieces_19 = value;
	}

	inline static int32_t get_offset_of_Color_20() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___Color_20)); }
	inline int32_t get_Color_20() const { return ___Color_20; }
	inline int32_t* get_address_of_Color_20() { return &___Color_20; }
	inline void set_Color_20(int32_t value)
	{
		___Color_20 = value;
	}

	inline static int32_t get_offset_of_g_root_mb_21() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___g_root_mb_21)); }
	inline int32_t get_g_root_mb_21() const { return ___g_root_mb_21; }
	inline int32_t* get_address_of_g_root_mb_21() { return &___g_root_mb_21; }
	inline void set_g_root_mb_21(int32_t value)
	{
		___g_root_mb_21 = value;
	}

	inline static int32_t get_offset_of_realdepth_22() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___realdepth_22)); }
	inline int32_t get_realdepth_22() const { return ___realdepth_22; }
	inline int32_t* get_address_of_realdepth_22() { return &___realdepth_22; }
	inline void set_realdepth_22(int32_t value)
	{
		___realdepth_22 = value;
	}

	inline static int32_t get_offset_of_RepNum_23() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___RepNum_23)); }
	inline SyncListUInt64_t567569778 * get_RepNum_23() const { return ___RepNum_23; }
	inline SyncListUInt64_t567569778 ** get_address_of_RepNum_23() { return &___RepNum_23; }
	inline void set_RepNum_23(SyncListUInt64_t567569778 * value)
	{
		___RepNum_23 = value;
		Il2CppCodeGenWriteBarrier(&___RepNum_23, value);
	}

	inline static int32_t get_offset_of_HASH_KEY_24() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___HASH_KEY_24)); }
	inline uint64_t get_HASH_KEY_24() const { return ___HASH_KEY_24; }
	inline uint64_t* get_address_of_HASH_KEY_24() { return &___HASH_KEY_24; }
	inline void set_HASH_KEY_24(uint64_t value)
	{
		___HASH_KEY_24 = value;
	}

	inline static int32_t get_offset_of_p_list_25() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___p_list_25)); }
	inline SyncListUInt_t2190275715 * get_p_list_25() const { return ___p_list_25; }
	inline SyncListUInt_t2190275715 ** get_address_of_p_list_25() { return &___p_list_25; }
	inline void set_p_list_25(SyncListUInt_t2190275715 * value)
	{
		___p_list_25 = value;
		Il2CppCodeGenWriteBarrier(&___p_list_25, value);
	}

	inline static int32_t get_offset_of_indices_26() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___indices_26)); }
	inline SyncListUInt_t2190275715 * get_indices_26() const { return ___indices_26; }
	inline SyncListUInt_t2190275715 ** get_address_of_indices_26() { return &___indices_26; }
	inline void set_indices_26(SyncListUInt_t2190275715 * value)
	{
		___indices_26 = value;
		Il2CppCodeGenWriteBarrier(&___indices_26, value);
	}

	inline static int32_t get_offset_of_g_pieces_27() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___g_pieces_27)); }
	inline SyncListInt_t3316705628 * get_g_pieces_27() const { return ___g_pieces_27; }
	inline SyncListInt_t3316705628 ** get_address_of_g_pieces_27() { return &___g_pieces_27; }
	inline void set_g_pieces_27(SyncListInt_t3316705628 * value)
	{
		___g_pieces_27 = value;
		Il2CppCodeGenWriteBarrier(&___g_pieces_27, value);
	}

	inline static int32_t get_offset_of_Reversible_28() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___Reversible_28)); }
	inline SyncListBool_t375623471 * get_Reversible_28() const { return ___Reversible_28; }
	inline SyncListBool_t375623471 ** get_address_of_Reversible_28() { return &___Reversible_28; }
	inline void set_Reversible_28(SyncListBool_t375623471 * value)
	{
		___Reversible_28 = value;
		Il2CppCodeGenWriteBarrier(&___Reversible_28, value);
	}

	inline static int32_t get_offset_of_c_num_29() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___c_num_29)); }
	inline SyncListUInt_t2190275715 * get_c_num_29() const { return ___c_num_29; }
	inline SyncListUInt_t2190275715 ** get_address_of_c_num_29() { return &___c_num_29; }
	inline void set_c_num_29(SyncListUInt_t2190275715 * value)
	{
		___c_num_29 = value;
		Il2CppCodeGenWriteBarrier(&___c_num_29, value);
	}

	inline static int32_t get_offset_of_isCustom_30() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___isCustom_30)); }
	inline bool get_isCustom_30() const { return ___isCustom_30; }
	inline bool* get_address_of_isCustom_30() { return &___isCustom_30; }
	inline void set_isCustom_30(bool value)
	{
		___isCustom_30 = value;
	}

	inline static int32_t get_offset_of_netData_31() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598, ___netData_31)); }
	inline NetData_1_t3646328225 * get_netData_31() const { return ___netData_31; }
	inline NetData_1_t3646328225 ** get_address_of_netData_31() { return &___netData_31; }
	inline void set_netData_31(NetData_1_t3646328225 * value)
	{
		___netData_31 = value;
		Il2CppCodeGenWriteBarrier(&___netData_31, value);
	}
};

struct RussianDraughtIdentity_t1425899598_StaticFields
{
public:
	// System.Int32 RussianDraught.RussianDraughtIdentity::kListBoard
	int32_t ___kListBoard_32;
	// System.Int32 RussianDraught.RussianDraughtIdentity::kListRepNum
	int32_t ___kListRepNum_33;
	// System.Int32 RussianDraught.RussianDraughtIdentity::kListp_list
	int32_t ___kListp_list_34;
	// System.Int32 RussianDraught.RussianDraughtIdentity::kListindices
	int32_t ___kListindices_35;
	// System.Int32 RussianDraught.RussianDraughtIdentity::kListg_pieces
	int32_t ___kListg_pieces_36;
	// System.Int32 RussianDraught.RussianDraughtIdentity::kListReversible
	int32_t ___kListReversible_37;
	// System.Int32 RussianDraught.RussianDraughtIdentity::kListc_num
	int32_t ___kListc_num_38;

public:
	inline static int32_t get_offset_of_kListBoard_32() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598_StaticFields, ___kListBoard_32)); }
	inline int32_t get_kListBoard_32() const { return ___kListBoard_32; }
	inline int32_t* get_address_of_kListBoard_32() { return &___kListBoard_32; }
	inline void set_kListBoard_32(int32_t value)
	{
		___kListBoard_32 = value;
	}

	inline static int32_t get_offset_of_kListRepNum_33() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598_StaticFields, ___kListRepNum_33)); }
	inline int32_t get_kListRepNum_33() const { return ___kListRepNum_33; }
	inline int32_t* get_address_of_kListRepNum_33() { return &___kListRepNum_33; }
	inline void set_kListRepNum_33(int32_t value)
	{
		___kListRepNum_33 = value;
	}

	inline static int32_t get_offset_of_kListp_list_34() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598_StaticFields, ___kListp_list_34)); }
	inline int32_t get_kListp_list_34() const { return ___kListp_list_34; }
	inline int32_t* get_address_of_kListp_list_34() { return &___kListp_list_34; }
	inline void set_kListp_list_34(int32_t value)
	{
		___kListp_list_34 = value;
	}

	inline static int32_t get_offset_of_kListindices_35() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598_StaticFields, ___kListindices_35)); }
	inline int32_t get_kListindices_35() const { return ___kListindices_35; }
	inline int32_t* get_address_of_kListindices_35() { return &___kListindices_35; }
	inline void set_kListindices_35(int32_t value)
	{
		___kListindices_35 = value;
	}

	inline static int32_t get_offset_of_kListg_pieces_36() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598_StaticFields, ___kListg_pieces_36)); }
	inline int32_t get_kListg_pieces_36() const { return ___kListg_pieces_36; }
	inline int32_t* get_address_of_kListg_pieces_36() { return &___kListg_pieces_36; }
	inline void set_kListg_pieces_36(int32_t value)
	{
		___kListg_pieces_36 = value;
	}

	inline static int32_t get_offset_of_kListReversible_37() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598_StaticFields, ___kListReversible_37)); }
	inline int32_t get_kListReversible_37() const { return ___kListReversible_37; }
	inline int32_t* get_address_of_kListReversible_37() { return &___kListReversible_37; }
	inline void set_kListReversible_37(int32_t value)
	{
		___kListReversible_37 = value;
	}

	inline static int32_t get_offset_of_kListc_num_38() { return static_cast<int32_t>(offsetof(RussianDraughtIdentity_t1425899598_StaticFields, ___kListc_num_38)); }
	inline int32_t get_kListc_num_38() const { return ___kListc_num_38; }
	inline int32_t* get_address_of_kListc_num_38() { return &___kListc_num_38; }
	inline void set_kListc_num_38(int32_t value)
	{
		___kListc_num_38 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
