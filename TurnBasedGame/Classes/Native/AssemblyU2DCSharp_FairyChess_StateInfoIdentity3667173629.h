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
// NetData`1<FairyChess.StateInfo>
struct NetData_1_t3407415148;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.StateInfoIdentity
struct  StateInfoIdentity_t3667173629  : public DataIdentity_t543951486
{
public:
	// System.UInt64 FairyChess.StateInfoIdentity::pawnKey
	uint64_t ___pawnKey_17;
	// System.UInt64 FairyChess.StateInfoIdentity::materialKey
	uint64_t ___materialKey_18;
	// UnityEngine.Networking.SyncListInt FairyChess.StateInfoIdentity::nonPawnMaterial
	SyncListInt_t3316705628 * ___nonPawnMaterial_19;
	// System.Int32 FairyChess.StateInfoIdentity::castlingRights
	int32_t ___castlingRights_20;
	// System.Int32 FairyChess.StateInfoIdentity::rule50
	int32_t ___rule50_21;
	// System.Int32 FairyChess.StateInfoIdentity::pliesFromNull
	int32_t ___pliesFromNull_22;
	// UnityEngine.Networking.SyncListInt FairyChess.StateInfoIdentity::checksGiven
	SyncListInt_t3316705628 * ___checksGiven_23;
	// System.Int32 FairyChess.StateInfoIdentity::psq
	int32_t ___psq_24;
	// System.Int32 FairyChess.StateInfoIdentity::epSquare
	int32_t ___epSquare_25;
	// System.UInt64 FairyChess.StateInfoIdentity::key
	uint64_t ___key_26;
	// System.UInt64 FairyChess.StateInfoIdentity::checkersBB
	uint64_t ___checkersBB_27;
	// System.Int32 FairyChess.StateInfoIdentity::capturedPiece
	int32_t ___capturedPiece_28;
	// System.Int32 FairyChess.StateInfoIdentity::unpromotedCapturedPiece
	int32_t ___unpromotedCapturedPiece_29;
	// DataIdentity/SyncListUInt64 FairyChess.StateInfoIdentity::blockersForKing
	SyncListUInt64_t567569778 * ___blockersForKing_30;
	// DataIdentity/SyncListUInt64 FairyChess.StateInfoIdentity::pinners
	SyncListUInt64_t567569778 * ___pinners_31;
	// DataIdentity/SyncListUInt64 FairyChess.StateInfoIdentity::checkSquares
	SyncListUInt64_t567569778 * ___checkSquares_32;
	// System.Boolean FairyChess.StateInfoIdentity::capturedpromoted
	bool ___capturedpromoted_33;
	// NetData`1<FairyChess.StateInfo> FairyChess.StateInfoIdentity::netData
	NetData_1_t3407415148 * ___netData_34;

public:
	inline static int32_t get_offset_of_pawnKey_17() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___pawnKey_17)); }
	inline uint64_t get_pawnKey_17() const { return ___pawnKey_17; }
	inline uint64_t* get_address_of_pawnKey_17() { return &___pawnKey_17; }
	inline void set_pawnKey_17(uint64_t value)
	{
		___pawnKey_17 = value;
	}

	inline static int32_t get_offset_of_materialKey_18() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___materialKey_18)); }
	inline uint64_t get_materialKey_18() const { return ___materialKey_18; }
	inline uint64_t* get_address_of_materialKey_18() { return &___materialKey_18; }
	inline void set_materialKey_18(uint64_t value)
	{
		___materialKey_18 = value;
	}

	inline static int32_t get_offset_of_nonPawnMaterial_19() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___nonPawnMaterial_19)); }
	inline SyncListInt_t3316705628 * get_nonPawnMaterial_19() const { return ___nonPawnMaterial_19; }
	inline SyncListInt_t3316705628 ** get_address_of_nonPawnMaterial_19() { return &___nonPawnMaterial_19; }
	inline void set_nonPawnMaterial_19(SyncListInt_t3316705628 * value)
	{
		___nonPawnMaterial_19 = value;
		Il2CppCodeGenWriteBarrier(&___nonPawnMaterial_19, value);
	}

	inline static int32_t get_offset_of_castlingRights_20() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___castlingRights_20)); }
	inline int32_t get_castlingRights_20() const { return ___castlingRights_20; }
	inline int32_t* get_address_of_castlingRights_20() { return &___castlingRights_20; }
	inline void set_castlingRights_20(int32_t value)
	{
		___castlingRights_20 = value;
	}

	inline static int32_t get_offset_of_rule50_21() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___rule50_21)); }
	inline int32_t get_rule50_21() const { return ___rule50_21; }
	inline int32_t* get_address_of_rule50_21() { return &___rule50_21; }
	inline void set_rule50_21(int32_t value)
	{
		___rule50_21 = value;
	}

	inline static int32_t get_offset_of_pliesFromNull_22() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___pliesFromNull_22)); }
	inline int32_t get_pliesFromNull_22() const { return ___pliesFromNull_22; }
	inline int32_t* get_address_of_pliesFromNull_22() { return &___pliesFromNull_22; }
	inline void set_pliesFromNull_22(int32_t value)
	{
		___pliesFromNull_22 = value;
	}

	inline static int32_t get_offset_of_checksGiven_23() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___checksGiven_23)); }
	inline SyncListInt_t3316705628 * get_checksGiven_23() const { return ___checksGiven_23; }
	inline SyncListInt_t3316705628 ** get_address_of_checksGiven_23() { return &___checksGiven_23; }
	inline void set_checksGiven_23(SyncListInt_t3316705628 * value)
	{
		___checksGiven_23 = value;
		Il2CppCodeGenWriteBarrier(&___checksGiven_23, value);
	}

	inline static int32_t get_offset_of_psq_24() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___psq_24)); }
	inline int32_t get_psq_24() const { return ___psq_24; }
	inline int32_t* get_address_of_psq_24() { return &___psq_24; }
	inline void set_psq_24(int32_t value)
	{
		___psq_24 = value;
	}

	inline static int32_t get_offset_of_epSquare_25() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___epSquare_25)); }
	inline int32_t get_epSquare_25() const { return ___epSquare_25; }
	inline int32_t* get_address_of_epSquare_25() { return &___epSquare_25; }
	inline void set_epSquare_25(int32_t value)
	{
		___epSquare_25 = value;
	}

	inline static int32_t get_offset_of_key_26() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___key_26)); }
	inline uint64_t get_key_26() const { return ___key_26; }
	inline uint64_t* get_address_of_key_26() { return &___key_26; }
	inline void set_key_26(uint64_t value)
	{
		___key_26 = value;
	}

	inline static int32_t get_offset_of_checkersBB_27() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___checkersBB_27)); }
	inline uint64_t get_checkersBB_27() const { return ___checkersBB_27; }
	inline uint64_t* get_address_of_checkersBB_27() { return &___checkersBB_27; }
	inline void set_checkersBB_27(uint64_t value)
	{
		___checkersBB_27 = value;
	}

	inline static int32_t get_offset_of_capturedPiece_28() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___capturedPiece_28)); }
	inline int32_t get_capturedPiece_28() const { return ___capturedPiece_28; }
	inline int32_t* get_address_of_capturedPiece_28() { return &___capturedPiece_28; }
	inline void set_capturedPiece_28(int32_t value)
	{
		___capturedPiece_28 = value;
	}

	inline static int32_t get_offset_of_unpromotedCapturedPiece_29() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___unpromotedCapturedPiece_29)); }
	inline int32_t get_unpromotedCapturedPiece_29() const { return ___unpromotedCapturedPiece_29; }
	inline int32_t* get_address_of_unpromotedCapturedPiece_29() { return &___unpromotedCapturedPiece_29; }
	inline void set_unpromotedCapturedPiece_29(int32_t value)
	{
		___unpromotedCapturedPiece_29 = value;
	}

	inline static int32_t get_offset_of_blockersForKing_30() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___blockersForKing_30)); }
	inline SyncListUInt64_t567569778 * get_blockersForKing_30() const { return ___blockersForKing_30; }
	inline SyncListUInt64_t567569778 ** get_address_of_blockersForKing_30() { return &___blockersForKing_30; }
	inline void set_blockersForKing_30(SyncListUInt64_t567569778 * value)
	{
		___blockersForKing_30 = value;
		Il2CppCodeGenWriteBarrier(&___blockersForKing_30, value);
	}

	inline static int32_t get_offset_of_pinners_31() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___pinners_31)); }
	inline SyncListUInt64_t567569778 * get_pinners_31() const { return ___pinners_31; }
	inline SyncListUInt64_t567569778 ** get_address_of_pinners_31() { return &___pinners_31; }
	inline void set_pinners_31(SyncListUInt64_t567569778 * value)
	{
		___pinners_31 = value;
		Il2CppCodeGenWriteBarrier(&___pinners_31, value);
	}

	inline static int32_t get_offset_of_checkSquares_32() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___checkSquares_32)); }
	inline SyncListUInt64_t567569778 * get_checkSquares_32() const { return ___checkSquares_32; }
	inline SyncListUInt64_t567569778 ** get_address_of_checkSquares_32() { return &___checkSquares_32; }
	inline void set_checkSquares_32(SyncListUInt64_t567569778 * value)
	{
		___checkSquares_32 = value;
		Il2CppCodeGenWriteBarrier(&___checkSquares_32, value);
	}

	inline static int32_t get_offset_of_capturedpromoted_33() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___capturedpromoted_33)); }
	inline bool get_capturedpromoted_33() const { return ___capturedpromoted_33; }
	inline bool* get_address_of_capturedpromoted_33() { return &___capturedpromoted_33; }
	inline void set_capturedpromoted_33(bool value)
	{
		___capturedpromoted_33 = value;
	}

	inline static int32_t get_offset_of_netData_34() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629, ___netData_34)); }
	inline NetData_1_t3407415148 * get_netData_34() const { return ___netData_34; }
	inline NetData_1_t3407415148 ** get_address_of_netData_34() { return &___netData_34; }
	inline void set_netData_34(NetData_1_t3407415148 * value)
	{
		___netData_34 = value;
		Il2CppCodeGenWriteBarrier(&___netData_34, value);
	}
};

struct StateInfoIdentity_t3667173629_StaticFields
{
public:
	// System.Int32 FairyChess.StateInfoIdentity::kListnonPawnMaterial
	int32_t ___kListnonPawnMaterial_35;
	// System.Int32 FairyChess.StateInfoIdentity::kListchecksGiven
	int32_t ___kListchecksGiven_36;
	// System.Int32 FairyChess.StateInfoIdentity::kListblockersForKing
	int32_t ___kListblockersForKing_37;
	// System.Int32 FairyChess.StateInfoIdentity::kListpinners
	int32_t ___kListpinners_38;
	// System.Int32 FairyChess.StateInfoIdentity::kListcheckSquares
	int32_t ___kListcheckSquares_39;

public:
	inline static int32_t get_offset_of_kListnonPawnMaterial_35() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629_StaticFields, ___kListnonPawnMaterial_35)); }
	inline int32_t get_kListnonPawnMaterial_35() const { return ___kListnonPawnMaterial_35; }
	inline int32_t* get_address_of_kListnonPawnMaterial_35() { return &___kListnonPawnMaterial_35; }
	inline void set_kListnonPawnMaterial_35(int32_t value)
	{
		___kListnonPawnMaterial_35 = value;
	}

	inline static int32_t get_offset_of_kListchecksGiven_36() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629_StaticFields, ___kListchecksGiven_36)); }
	inline int32_t get_kListchecksGiven_36() const { return ___kListchecksGiven_36; }
	inline int32_t* get_address_of_kListchecksGiven_36() { return &___kListchecksGiven_36; }
	inline void set_kListchecksGiven_36(int32_t value)
	{
		___kListchecksGiven_36 = value;
	}

	inline static int32_t get_offset_of_kListblockersForKing_37() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629_StaticFields, ___kListblockersForKing_37)); }
	inline int32_t get_kListblockersForKing_37() const { return ___kListblockersForKing_37; }
	inline int32_t* get_address_of_kListblockersForKing_37() { return &___kListblockersForKing_37; }
	inline void set_kListblockersForKing_37(int32_t value)
	{
		___kListblockersForKing_37 = value;
	}

	inline static int32_t get_offset_of_kListpinners_38() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629_StaticFields, ___kListpinners_38)); }
	inline int32_t get_kListpinners_38() const { return ___kListpinners_38; }
	inline int32_t* get_address_of_kListpinners_38() { return &___kListpinners_38; }
	inline void set_kListpinners_38(int32_t value)
	{
		___kListpinners_38 = value;
	}

	inline static int32_t get_offset_of_kListcheckSquares_39() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t3667173629_StaticFields, ___kListcheckSquares_39)); }
	inline int32_t get_kListcheckSquares_39() const { return ___kListcheckSquares_39; }
	inline int32_t* get_address_of_kListcheckSquares_39() { return &___kListcheckSquares_39; }
	inline void set_kListcheckSquares_39(int32_t value)
	{
		___kListcheckSquares_39 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
