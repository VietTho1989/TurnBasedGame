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
// NetData`1<Chess.StateInfo>
struct NetData_1_t3077713712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.StateInfoIdentity
struct  StateInfoIdentity_t1230215357  : public DataIdentity_t543951486
{
public:
	// System.UInt64 Chess.StateInfoIdentity::pawnKey
	uint64_t ___pawnKey_17;
	// System.UInt64 Chess.StateInfoIdentity::materialKey
	uint64_t ___materialKey_18;
	// UnityEngine.Networking.SyncListInt Chess.StateInfoIdentity::nonPawnMaterial
	SyncListInt_t3316705628 * ___nonPawnMaterial_19;
	// System.Int32 Chess.StateInfoIdentity::castlingRights
	int32_t ___castlingRights_20;
	// System.Int32 Chess.StateInfoIdentity::rule50
	int32_t ___rule50_21;
	// System.Int32 Chess.StateInfoIdentity::pliesFromNull
	int32_t ___pliesFromNull_22;
	// System.Int32 Chess.StateInfoIdentity::psq
	int32_t ___psq_23;
	// System.Int32 Chess.StateInfoIdentity::epSquare
	int32_t ___epSquare_24;
	// System.UInt64 Chess.StateInfoIdentity::key
	uint64_t ___key_25;
	// System.UInt64 Chess.StateInfoIdentity::checkersBB
	uint64_t ___checkersBB_26;
	// System.Int32 Chess.StateInfoIdentity::capturedPiece
	int32_t ___capturedPiece_27;
	// DataIdentity/SyncListUInt64 Chess.StateInfoIdentity::blockersForKing
	SyncListUInt64_t567569778 * ___blockersForKing_28;
	// DataIdentity/SyncListUInt64 Chess.StateInfoIdentity::pinnersForKing
	SyncListUInt64_t567569778 * ___pinnersForKing_29;
	// DataIdentity/SyncListUInt64 Chess.StateInfoIdentity::checkSquares
	SyncListUInt64_t567569778 * ___checkSquares_30;
	// NetData`1<Chess.StateInfo> Chess.StateInfoIdentity::netData
	NetData_1_t3077713712 * ___netData_31;

public:
	inline static int32_t get_offset_of_pawnKey_17() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___pawnKey_17)); }
	inline uint64_t get_pawnKey_17() const { return ___pawnKey_17; }
	inline uint64_t* get_address_of_pawnKey_17() { return &___pawnKey_17; }
	inline void set_pawnKey_17(uint64_t value)
	{
		___pawnKey_17 = value;
	}

	inline static int32_t get_offset_of_materialKey_18() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___materialKey_18)); }
	inline uint64_t get_materialKey_18() const { return ___materialKey_18; }
	inline uint64_t* get_address_of_materialKey_18() { return &___materialKey_18; }
	inline void set_materialKey_18(uint64_t value)
	{
		___materialKey_18 = value;
	}

	inline static int32_t get_offset_of_nonPawnMaterial_19() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___nonPawnMaterial_19)); }
	inline SyncListInt_t3316705628 * get_nonPawnMaterial_19() const { return ___nonPawnMaterial_19; }
	inline SyncListInt_t3316705628 ** get_address_of_nonPawnMaterial_19() { return &___nonPawnMaterial_19; }
	inline void set_nonPawnMaterial_19(SyncListInt_t3316705628 * value)
	{
		___nonPawnMaterial_19 = value;
		Il2CppCodeGenWriteBarrier(&___nonPawnMaterial_19, value);
	}

	inline static int32_t get_offset_of_castlingRights_20() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___castlingRights_20)); }
	inline int32_t get_castlingRights_20() const { return ___castlingRights_20; }
	inline int32_t* get_address_of_castlingRights_20() { return &___castlingRights_20; }
	inline void set_castlingRights_20(int32_t value)
	{
		___castlingRights_20 = value;
	}

	inline static int32_t get_offset_of_rule50_21() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___rule50_21)); }
	inline int32_t get_rule50_21() const { return ___rule50_21; }
	inline int32_t* get_address_of_rule50_21() { return &___rule50_21; }
	inline void set_rule50_21(int32_t value)
	{
		___rule50_21 = value;
	}

	inline static int32_t get_offset_of_pliesFromNull_22() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___pliesFromNull_22)); }
	inline int32_t get_pliesFromNull_22() const { return ___pliesFromNull_22; }
	inline int32_t* get_address_of_pliesFromNull_22() { return &___pliesFromNull_22; }
	inline void set_pliesFromNull_22(int32_t value)
	{
		___pliesFromNull_22 = value;
	}

	inline static int32_t get_offset_of_psq_23() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___psq_23)); }
	inline int32_t get_psq_23() const { return ___psq_23; }
	inline int32_t* get_address_of_psq_23() { return &___psq_23; }
	inline void set_psq_23(int32_t value)
	{
		___psq_23 = value;
	}

	inline static int32_t get_offset_of_epSquare_24() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___epSquare_24)); }
	inline int32_t get_epSquare_24() const { return ___epSquare_24; }
	inline int32_t* get_address_of_epSquare_24() { return &___epSquare_24; }
	inline void set_epSquare_24(int32_t value)
	{
		___epSquare_24 = value;
	}

	inline static int32_t get_offset_of_key_25() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___key_25)); }
	inline uint64_t get_key_25() const { return ___key_25; }
	inline uint64_t* get_address_of_key_25() { return &___key_25; }
	inline void set_key_25(uint64_t value)
	{
		___key_25 = value;
	}

	inline static int32_t get_offset_of_checkersBB_26() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___checkersBB_26)); }
	inline uint64_t get_checkersBB_26() const { return ___checkersBB_26; }
	inline uint64_t* get_address_of_checkersBB_26() { return &___checkersBB_26; }
	inline void set_checkersBB_26(uint64_t value)
	{
		___checkersBB_26 = value;
	}

	inline static int32_t get_offset_of_capturedPiece_27() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___capturedPiece_27)); }
	inline int32_t get_capturedPiece_27() const { return ___capturedPiece_27; }
	inline int32_t* get_address_of_capturedPiece_27() { return &___capturedPiece_27; }
	inline void set_capturedPiece_27(int32_t value)
	{
		___capturedPiece_27 = value;
	}

	inline static int32_t get_offset_of_blockersForKing_28() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___blockersForKing_28)); }
	inline SyncListUInt64_t567569778 * get_blockersForKing_28() const { return ___blockersForKing_28; }
	inline SyncListUInt64_t567569778 ** get_address_of_blockersForKing_28() { return &___blockersForKing_28; }
	inline void set_blockersForKing_28(SyncListUInt64_t567569778 * value)
	{
		___blockersForKing_28 = value;
		Il2CppCodeGenWriteBarrier(&___blockersForKing_28, value);
	}

	inline static int32_t get_offset_of_pinnersForKing_29() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___pinnersForKing_29)); }
	inline SyncListUInt64_t567569778 * get_pinnersForKing_29() const { return ___pinnersForKing_29; }
	inline SyncListUInt64_t567569778 ** get_address_of_pinnersForKing_29() { return &___pinnersForKing_29; }
	inline void set_pinnersForKing_29(SyncListUInt64_t567569778 * value)
	{
		___pinnersForKing_29 = value;
		Il2CppCodeGenWriteBarrier(&___pinnersForKing_29, value);
	}

	inline static int32_t get_offset_of_checkSquares_30() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___checkSquares_30)); }
	inline SyncListUInt64_t567569778 * get_checkSquares_30() const { return ___checkSquares_30; }
	inline SyncListUInt64_t567569778 ** get_address_of_checkSquares_30() { return &___checkSquares_30; }
	inline void set_checkSquares_30(SyncListUInt64_t567569778 * value)
	{
		___checkSquares_30 = value;
		Il2CppCodeGenWriteBarrier(&___checkSquares_30, value);
	}

	inline static int32_t get_offset_of_netData_31() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357, ___netData_31)); }
	inline NetData_1_t3077713712 * get_netData_31() const { return ___netData_31; }
	inline NetData_1_t3077713712 ** get_address_of_netData_31() { return &___netData_31; }
	inline void set_netData_31(NetData_1_t3077713712 * value)
	{
		___netData_31 = value;
		Il2CppCodeGenWriteBarrier(&___netData_31, value);
	}
};

struct StateInfoIdentity_t1230215357_StaticFields
{
public:
	// System.Int32 Chess.StateInfoIdentity::kListnonPawnMaterial
	int32_t ___kListnonPawnMaterial_32;
	// System.Int32 Chess.StateInfoIdentity::kListblockersForKing
	int32_t ___kListblockersForKing_33;
	// System.Int32 Chess.StateInfoIdentity::kListpinnersForKing
	int32_t ___kListpinnersForKing_34;
	// System.Int32 Chess.StateInfoIdentity::kListcheckSquares
	int32_t ___kListcheckSquares_35;

public:
	inline static int32_t get_offset_of_kListnonPawnMaterial_32() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357_StaticFields, ___kListnonPawnMaterial_32)); }
	inline int32_t get_kListnonPawnMaterial_32() const { return ___kListnonPawnMaterial_32; }
	inline int32_t* get_address_of_kListnonPawnMaterial_32() { return &___kListnonPawnMaterial_32; }
	inline void set_kListnonPawnMaterial_32(int32_t value)
	{
		___kListnonPawnMaterial_32 = value;
	}

	inline static int32_t get_offset_of_kListblockersForKing_33() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357_StaticFields, ___kListblockersForKing_33)); }
	inline int32_t get_kListblockersForKing_33() const { return ___kListblockersForKing_33; }
	inline int32_t* get_address_of_kListblockersForKing_33() { return &___kListblockersForKing_33; }
	inline void set_kListblockersForKing_33(int32_t value)
	{
		___kListblockersForKing_33 = value;
	}

	inline static int32_t get_offset_of_kListpinnersForKing_34() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357_StaticFields, ___kListpinnersForKing_34)); }
	inline int32_t get_kListpinnersForKing_34() const { return ___kListpinnersForKing_34; }
	inline int32_t* get_address_of_kListpinnersForKing_34() { return &___kListpinnersForKing_34; }
	inline void set_kListpinnersForKing_34(int32_t value)
	{
		___kListpinnersForKing_34 = value;
	}

	inline static int32_t get_offset_of_kListcheckSquares_35() { return static_cast<int32_t>(offsetof(StateInfoIdentity_t1230215357_StaticFields, ___kListcheckSquares_35)); }
	inline int32_t get_kListcheckSquares_35() const { return ___kListcheckSquares_35; }
	inline int32_t* get_address_of_kListcheckSquares_35() { return &___kListcheckSquares_35; }
	inline void set_kListcheckSquares_35(int32_t value)
	{
		___kListcheckSquares_35 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
