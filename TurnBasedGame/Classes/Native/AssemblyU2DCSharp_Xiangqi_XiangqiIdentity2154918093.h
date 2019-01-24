#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// DataIdentity/SyncListByte
struct SyncListByte_t230810734;
// DataIdentity/SyncListUShort
struct SyncListUShort_t2214179869;
// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// NetData`1<Xiangqi.Xiangqi>
struct NetData_1_t3486449428;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.XiangqiIdentity
struct  XiangqiIdentity_t2154918093  : public DataIdentity_t543951486
{
public:
	// System.Int32 Xiangqi.XiangqiIdentity::sdPlayer
	int32_t ___sdPlayer_17;
	// DataIdentity/SyncListByte Xiangqi.XiangqiIdentity::ucpcSquares
	SyncListByte_t230810734 * ___ucpcSquares_18;
	// DataIdentity/SyncListByte Xiangqi.XiangqiIdentity::ucsqPieces
	SyncListByte_t230810734 * ___ucsqPieces_19;
	// System.UInt32 Xiangqi.XiangqiIdentity::dwBitPiece
	uint32_t ___dwBitPiece_20;
	// DataIdentity/SyncListUShort Xiangqi.XiangqiIdentity::wBitRanks
	SyncListUShort_t2214179869 * ___wBitRanks_21;
	// DataIdentity/SyncListUShort Xiangqi.XiangqiIdentity::wBitFiles
	SyncListUShort_t2214179869 * ___wBitFiles_22;
	// System.Int32 Xiangqi.XiangqiIdentity::vlWhite
	int32_t ___vlWhite_23;
	// System.Int32 Xiangqi.XiangqiIdentity::vlBlack
	int32_t ___vlBlack_24;
	// System.Int32 Xiangqi.XiangqiIdentity::nMoveNum
	int32_t ___nMoveNum_25;
	// System.Int32 Xiangqi.XiangqiIdentity::nDistance
	int32_t ___nDistance_26;
	// UnityEngine.Networking.SyncListUInt Xiangqi.XiangqiIdentity::ucRepHash
	SyncListUInt_t2190275715 * ___ucRepHash_27;
	// System.Boolean Xiangqi.XiangqiIdentity::isCustom
	bool ___isCustom_28;
	// NetData`1<Xiangqi.Xiangqi> Xiangqi.XiangqiIdentity::netData
	NetData_1_t3486449428 * ___netData_29;

public:
	inline static int32_t get_offset_of_sdPlayer_17() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___sdPlayer_17)); }
	inline int32_t get_sdPlayer_17() const { return ___sdPlayer_17; }
	inline int32_t* get_address_of_sdPlayer_17() { return &___sdPlayer_17; }
	inline void set_sdPlayer_17(int32_t value)
	{
		___sdPlayer_17 = value;
	}

	inline static int32_t get_offset_of_ucpcSquares_18() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___ucpcSquares_18)); }
	inline SyncListByte_t230810734 * get_ucpcSquares_18() const { return ___ucpcSquares_18; }
	inline SyncListByte_t230810734 ** get_address_of_ucpcSquares_18() { return &___ucpcSquares_18; }
	inline void set_ucpcSquares_18(SyncListByte_t230810734 * value)
	{
		___ucpcSquares_18 = value;
		Il2CppCodeGenWriteBarrier(&___ucpcSquares_18, value);
	}

	inline static int32_t get_offset_of_ucsqPieces_19() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___ucsqPieces_19)); }
	inline SyncListByte_t230810734 * get_ucsqPieces_19() const { return ___ucsqPieces_19; }
	inline SyncListByte_t230810734 ** get_address_of_ucsqPieces_19() { return &___ucsqPieces_19; }
	inline void set_ucsqPieces_19(SyncListByte_t230810734 * value)
	{
		___ucsqPieces_19 = value;
		Il2CppCodeGenWriteBarrier(&___ucsqPieces_19, value);
	}

	inline static int32_t get_offset_of_dwBitPiece_20() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___dwBitPiece_20)); }
	inline uint32_t get_dwBitPiece_20() const { return ___dwBitPiece_20; }
	inline uint32_t* get_address_of_dwBitPiece_20() { return &___dwBitPiece_20; }
	inline void set_dwBitPiece_20(uint32_t value)
	{
		___dwBitPiece_20 = value;
	}

	inline static int32_t get_offset_of_wBitRanks_21() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___wBitRanks_21)); }
	inline SyncListUShort_t2214179869 * get_wBitRanks_21() const { return ___wBitRanks_21; }
	inline SyncListUShort_t2214179869 ** get_address_of_wBitRanks_21() { return &___wBitRanks_21; }
	inline void set_wBitRanks_21(SyncListUShort_t2214179869 * value)
	{
		___wBitRanks_21 = value;
		Il2CppCodeGenWriteBarrier(&___wBitRanks_21, value);
	}

	inline static int32_t get_offset_of_wBitFiles_22() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___wBitFiles_22)); }
	inline SyncListUShort_t2214179869 * get_wBitFiles_22() const { return ___wBitFiles_22; }
	inline SyncListUShort_t2214179869 ** get_address_of_wBitFiles_22() { return &___wBitFiles_22; }
	inline void set_wBitFiles_22(SyncListUShort_t2214179869 * value)
	{
		___wBitFiles_22 = value;
		Il2CppCodeGenWriteBarrier(&___wBitFiles_22, value);
	}

	inline static int32_t get_offset_of_vlWhite_23() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___vlWhite_23)); }
	inline int32_t get_vlWhite_23() const { return ___vlWhite_23; }
	inline int32_t* get_address_of_vlWhite_23() { return &___vlWhite_23; }
	inline void set_vlWhite_23(int32_t value)
	{
		___vlWhite_23 = value;
	}

	inline static int32_t get_offset_of_vlBlack_24() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___vlBlack_24)); }
	inline int32_t get_vlBlack_24() const { return ___vlBlack_24; }
	inline int32_t* get_address_of_vlBlack_24() { return &___vlBlack_24; }
	inline void set_vlBlack_24(int32_t value)
	{
		___vlBlack_24 = value;
	}

	inline static int32_t get_offset_of_nMoveNum_25() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___nMoveNum_25)); }
	inline int32_t get_nMoveNum_25() const { return ___nMoveNum_25; }
	inline int32_t* get_address_of_nMoveNum_25() { return &___nMoveNum_25; }
	inline void set_nMoveNum_25(int32_t value)
	{
		___nMoveNum_25 = value;
	}

	inline static int32_t get_offset_of_nDistance_26() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___nDistance_26)); }
	inline int32_t get_nDistance_26() const { return ___nDistance_26; }
	inline int32_t* get_address_of_nDistance_26() { return &___nDistance_26; }
	inline void set_nDistance_26(int32_t value)
	{
		___nDistance_26 = value;
	}

	inline static int32_t get_offset_of_ucRepHash_27() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___ucRepHash_27)); }
	inline SyncListUInt_t2190275715 * get_ucRepHash_27() const { return ___ucRepHash_27; }
	inline SyncListUInt_t2190275715 ** get_address_of_ucRepHash_27() { return &___ucRepHash_27; }
	inline void set_ucRepHash_27(SyncListUInt_t2190275715 * value)
	{
		___ucRepHash_27 = value;
		Il2CppCodeGenWriteBarrier(&___ucRepHash_27, value);
	}

	inline static int32_t get_offset_of_isCustom_28() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___isCustom_28)); }
	inline bool get_isCustom_28() const { return ___isCustom_28; }
	inline bool* get_address_of_isCustom_28() { return &___isCustom_28; }
	inline void set_isCustom_28(bool value)
	{
		___isCustom_28 = value;
	}

	inline static int32_t get_offset_of_netData_29() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093, ___netData_29)); }
	inline NetData_1_t3486449428 * get_netData_29() const { return ___netData_29; }
	inline NetData_1_t3486449428 ** get_address_of_netData_29() { return &___netData_29; }
	inline void set_netData_29(NetData_1_t3486449428 * value)
	{
		___netData_29 = value;
		Il2CppCodeGenWriteBarrier(&___netData_29, value);
	}
};

struct XiangqiIdentity_t2154918093_StaticFields
{
public:
	// System.Int32 Xiangqi.XiangqiIdentity::kListucpcSquares
	int32_t ___kListucpcSquares_30;
	// System.Int32 Xiangqi.XiangqiIdentity::kListucsqPieces
	int32_t ___kListucsqPieces_31;
	// System.Int32 Xiangqi.XiangqiIdentity::kListwBitRanks
	int32_t ___kListwBitRanks_32;
	// System.Int32 Xiangqi.XiangqiIdentity::kListwBitFiles
	int32_t ___kListwBitFiles_33;
	// System.Int32 Xiangqi.XiangqiIdentity::kListucRepHash
	int32_t ___kListucRepHash_34;

public:
	inline static int32_t get_offset_of_kListucpcSquares_30() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093_StaticFields, ___kListucpcSquares_30)); }
	inline int32_t get_kListucpcSquares_30() const { return ___kListucpcSquares_30; }
	inline int32_t* get_address_of_kListucpcSquares_30() { return &___kListucpcSquares_30; }
	inline void set_kListucpcSquares_30(int32_t value)
	{
		___kListucpcSquares_30 = value;
	}

	inline static int32_t get_offset_of_kListucsqPieces_31() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093_StaticFields, ___kListucsqPieces_31)); }
	inline int32_t get_kListucsqPieces_31() const { return ___kListucsqPieces_31; }
	inline int32_t* get_address_of_kListucsqPieces_31() { return &___kListucsqPieces_31; }
	inline void set_kListucsqPieces_31(int32_t value)
	{
		___kListucsqPieces_31 = value;
	}

	inline static int32_t get_offset_of_kListwBitRanks_32() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093_StaticFields, ___kListwBitRanks_32)); }
	inline int32_t get_kListwBitRanks_32() const { return ___kListwBitRanks_32; }
	inline int32_t* get_address_of_kListwBitRanks_32() { return &___kListwBitRanks_32; }
	inline void set_kListwBitRanks_32(int32_t value)
	{
		___kListwBitRanks_32 = value;
	}

	inline static int32_t get_offset_of_kListwBitFiles_33() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093_StaticFields, ___kListwBitFiles_33)); }
	inline int32_t get_kListwBitFiles_33() const { return ___kListwBitFiles_33; }
	inline int32_t* get_address_of_kListwBitFiles_33() { return &___kListwBitFiles_33; }
	inline void set_kListwBitFiles_33(int32_t value)
	{
		___kListwBitFiles_33 = value;
	}

	inline static int32_t get_offset_of_kListucRepHash_34() { return static_cast<int32_t>(offsetof(XiangqiIdentity_t2154918093_StaticFields, ___kListucRepHash_34)); }
	inline int32_t get_kListucRepHash_34() const { return ___kListucRepHash_34; }
	inline int32_t* get_address_of_kListucRepHash_34() { return &___kListucRepHash_34; }
	inline void set_kListucRepHash_34(int32_t value)
	{
		___kListucRepHash_34 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
