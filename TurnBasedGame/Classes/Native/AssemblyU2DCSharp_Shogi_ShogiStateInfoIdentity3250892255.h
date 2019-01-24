#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Shogi_Common_BitBoard4040987689.h"
#include "AssemblyU2DCSharp_Shogi_Common_Piece444841494.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<Shogi.StateInfo>
struct NetData_1_t2036437824;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiStateInfoIdentity
struct  ShogiStateInfoIdentity_t3250892255  : public DataIdentity_t543951486
{
public:
	// System.Int32 Shogi.ShogiStateInfoIdentity::material
	int32_t ___material_17;
	// System.Int32 Shogi.ShogiStateInfoIdentity::pliesFromNull
	int32_t ___pliesFromNull_18;
	// UnityEngine.Networking.SyncListInt Shogi.ShogiStateInfoIdentity::continuousCheck
	SyncListInt_t3316705628 * ___continuousCheck_19;
	// System.UInt64 Shogi.ShogiStateInfoIdentity::boardKey
	uint64_t ___boardKey_20;
	// System.UInt64 Shogi.ShogiStateInfoIdentity::handKey
	uint64_t ___handKey_21;
	// Shogi.Common/BitBoard Shogi.ShogiStateInfoIdentity::checkersBB
	BitBoard_t4040987689  ___checkersBB_22;
	// Shogi.Common/Piece Shogi.ShogiStateInfoIdentity::capturedPiece
	int32_t ___capturedPiece_23;
	// System.UInt32 Shogi.ShogiStateInfoIdentity::hand
	uint32_t ___hand_24;
	// NetData`1<Shogi.StateInfo> Shogi.ShogiStateInfoIdentity::netData
	NetData_1_t2036437824 * ___netData_25;

public:
	inline static int32_t get_offset_of_material_17() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___material_17)); }
	inline int32_t get_material_17() const { return ___material_17; }
	inline int32_t* get_address_of_material_17() { return &___material_17; }
	inline void set_material_17(int32_t value)
	{
		___material_17 = value;
	}

	inline static int32_t get_offset_of_pliesFromNull_18() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___pliesFromNull_18)); }
	inline int32_t get_pliesFromNull_18() const { return ___pliesFromNull_18; }
	inline int32_t* get_address_of_pliesFromNull_18() { return &___pliesFromNull_18; }
	inline void set_pliesFromNull_18(int32_t value)
	{
		___pliesFromNull_18 = value;
	}

	inline static int32_t get_offset_of_continuousCheck_19() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___continuousCheck_19)); }
	inline SyncListInt_t3316705628 * get_continuousCheck_19() const { return ___continuousCheck_19; }
	inline SyncListInt_t3316705628 ** get_address_of_continuousCheck_19() { return &___continuousCheck_19; }
	inline void set_continuousCheck_19(SyncListInt_t3316705628 * value)
	{
		___continuousCheck_19 = value;
		Il2CppCodeGenWriteBarrier(&___continuousCheck_19, value);
	}

	inline static int32_t get_offset_of_boardKey_20() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___boardKey_20)); }
	inline uint64_t get_boardKey_20() const { return ___boardKey_20; }
	inline uint64_t* get_address_of_boardKey_20() { return &___boardKey_20; }
	inline void set_boardKey_20(uint64_t value)
	{
		___boardKey_20 = value;
	}

	inline static int32_t get_offset_of_handKey_21() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___handKey_21)); }
	inline uint64_t get_handKey_21() const { return ___handKey_21; }
	inline uint64_t* get_address_of_handKey_21() { return &___handKey_21; }
	inline void set_handKey_21(uint64_t value)
	{
		___handKey_21 = value;
	}

	inline static int32_t get_offset_of_checkersBB_22() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___checkersBB_22)); }
	inline BitBoard_t4040987689  get_checkersBB_22() const { return ___checkersBB_22; }
	inline BitBoard_t4040987689 * get_address_of_checkersBB_22() { return &___checkersBB_22; }
	inline void set_checkersBB_22(BitBoard_t4040987689  value)
	{
		___checkersBB_22 = value;
	}

	inline static int32_t get_offset_of_capturedPiece_23() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___capturedPiece_23)); }
	inline int32_t get_capturedPiece_23() const { return ___capturedPiece_23; }
	inline int32_t* get_address_of_capturedPiece_23() { return &___capturedPiece_23; }
	inline void set_capturedPiece_23(int32_t value)
	{
		___capturedPiece_23 = value;
	}

	inline static int32_t get_offset_of_hand_24() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___hand_24)); }
	inline uint32_t get_hand_24() const { return ___hand_24; }
	inline uint32_t* get_address_of_hand_24() { return &___hand_24; }
	inline void set_hand_24(uint32_t value)
	{
		___hand_24 = value;
	}

	inline static int32_t get_offset_of_netData_25() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255, ___netData_25)); }
	inline NetData_1_t2036437824 * get_netData_25() const { return ___netData_25; }
	inline NetData_1_t2036437824 ** get_address_of_netData_25() { return &___netData_25; }
	inline void set_netData_25(NetData_1_t2036437824 * value)
	{
		___netData_25 = value;
		Il2CppCodeGenWriteBarrier(&___netData_25, value);
	}
};

struct ShogiStateInfoIdentity_t3250892255_StaticFields
{
public:
	// System.Int32 Shogi.ShogiStateInfoIdentity::kListcontinuousCheck
	int32_t ___kListcontinuousCheck_26;

public:
	inline static int32_t get_offset_of_kListcontinuousCheck_26() { return static_cast<int32_t>(offsetof(ShogiStateInfoIdentity_t3250892255_StaticFields, ___kListcontinuousCheck_26)); }
	inline int32_t get_kListcontinuousCheck_26() const { return ___kListcontinuousCheck_26; }
	inline int32_t* get_address_of_kListcontinuousCheck_26() { return &___kListcontinuousCheck_26; }
	inline void set_kListcontinuousCheck_26(int32_t value)
	{
		___kListcontinuousCheck_26 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
