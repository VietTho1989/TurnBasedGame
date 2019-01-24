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
// NetData`1<Shogi.ShogiMoveAnimation>
struct NetData_1_t3651998320;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiMoveAnimationIdentity
struct  ShogiMoveAnimationIdentity_t422289829  : public DataIdentity_t543951486
{
public:
	// System.Int32 Shogi.ShogiMoveAnimationIdentity::playerIndex
	int32_t ___playerIndex_17;
	// UnityEngine.Networking.SyncListInt Shogi.ShogiMoveAnimationIdentity::piece
	SyncListInt_t3316705628 * ___piece_18;
	// UnityEngine.Networking.SyncListUInt Shogi.ShogiMoveAnimationIdentity::hand
	SyncListUInt_t2190275715 * ___hand_19;
	// System.UInt32 Shogi.ShogiMoveAnimationIdentity::move
	uint32_t ___move_20;
	// NetData`1<Shogi.ShogiMoveAnimation> Shogi.ShogiMoveAnimationIdentity::netData
	NetData_1_t3651998320 * ___netData_21;

public:
	inline static int32_t get_offset_of_playerIndex_17() { return static_cast<int32_t>(offsetof(ShogiMoveAnimationIdentity_t422289829, ___playerIndex_17)); }
	inline int32_t get_playerIndex_17() const { return ___playerIndex_17; }
	inline int32_t* get_address_of_playerIndex_17() { return &___playerIndex_17; }
	inline void set_playerIndex_17(int32_t value)
	{
		___playerIndex_17 = value;
	}

	inline static int32_t get_offset_of_piece_18() { return static_cast<int32_t>(offsetof(ShogiMoveAnimationIdentity_t422289829, ___piece_18)); }
	inline SyncListInt_t3316705628 * get_piece_18() const { return ___piece_18; }
	inline SyncListInt_t3316705628 ** get_address_of_piece_18() { return &___piece_18; }
	inline void set_piece_18(SyncListInt_t3316705628 * value)
	{
		___piece_18 = value;
		Il2CppCodeGenWriteBarrier(&___piece_18, value);
	}

	inline static int32_t get_offset_of_hand_19() { return static_cast<int32_t>(offsetof(ShogiMoveAnimationIdentity_t422289829, ___hand_19)); }
	inline SyncListUInt_t2190275715 * get_hand_19() const { return ___hand_19; }
	inline SyncListUInt_t2190275715 ** get_address_of_hand_19() { return &___hand_19; }
	inline void set_hand_19(SyncListUInt_t2190275715 * value)
	{
		___hand_19 = value;
		Il2CppCodeGenWriteBarrier(&___hand_19, value);
	}

	inline static int32_t get_offset_of_move_20() { return static_cast<int32_t>(offsetof(ShogiMoveAnimationIdentity_t422289829, ___move_20)); }
	inline uint32_t get_move_20() const { return ___move_20; }
	inline uint32_t* get_address_of_move_20() { return &___move_20; }
	inline void set_move_20(uint32_t value)
	{
		___move_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(ShogiMoveAnimationIdentity_t422289829, ___netData_21)); }
	inline NetData_1_t3651998320 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t3651998320 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t3651998320 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

struct ShogiMoveAnimationIdentity_t422289829_StaticFields
{
public:
	// System.Int32 Shogi.ShogiMoveAnimationIdentity::kListpiece
	int32_t ___kListpiece_22;
	// System.Int32 Shogi.ShogiMoveAnimationIdentity::kListhand
	int32_t ___kListhand_23;

public:
	inline static int32_t get_offset_of_kListpiece_22() { return static_cast<int32_t>(offsetof(ShogiMoveAnimationIdentity_t422289829_StaticFields, ___kListpiece_22)); }
	inline int32_t get_kListpiece_22() const { return ___kListpiece_22; }
	inline int32_t* get_address_of_kListpiece_22() { return &___kListpiece_22; }
	inline void set_kListpiece_22(int32_t value)
	{
		___kListpiece_22 = value;
	}

	inline static int32_t get_offset_of_kListhand_23() { return static_cast<int32_t>(offsetof(ShogiMoveAnimationIdentity_t422289829_StaticFields, ___kListhand_23)); }
	inline int32_t get_kListhand_23() const { return ___kListhand_23; }
	inline int32_t* get_address_of_kListhand_23() { return &___kListhand_23; }
	inline void set_kListhand_23(int32_t value)
	{
		___kListhand_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
