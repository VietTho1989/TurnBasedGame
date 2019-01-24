#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Piece501795431.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<FairyChess.FairyChessMoveAnimation>
struct NetData_1_t315392947;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.FairyChessMoveAnimationIdentity
struct  FairyChessMoveAnimationIdentity_t3257862896  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessMoveAnimationIdentity::board
	SyncListInt_t3316705628 * ___board_17;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessMoveAnimationIdentity::pieceCountInHand
	SyncListInt_t3316705628 * ___pieceCountInHand_18;
	// FairyChess.Common/Piece FairyChess.FairyChessMoveAnimationIdentity::promoteOrDropPiece
	int32_t ___promoteOrDropPiece_19;
	// System.Int32 FairyChess.FairyChessMoveAnimationIdentity::move
	int32_t ___move_20;
	// NetData`1<FairyChess.FairyChessMoveAnimation> FairyChess.FairyChessMoveAnimationIdentity::netData
	NetData_1_t315392947 * ___netData_21;

public:
	inline static int32_t get_offset_of_board_17() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimationIdentity_t3257862896, ___board_17)); }
	inline SyncListInt_t3316705628 * get_board_17() const { return ___board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_board_17() { return &___board_17; }
	inline void set_board_17(SyncListInt_t3316705628 * value)
	{
		___board_17 = value;
		Il2CppCodeGenWriteBarrier(&___board_17, value);
	}

	inline static int32_t get_offset_of_pieceCountInHand_18() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimationIdentity_t3257862896, ___pieceCountInHand_18)); }
	inline SyncListInt_t3316705628 * get_pieceCountInHand_18() const { return ___pieceCountInHand_18; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceCountInHand_18() { return &___pieceCountInHand_18; }
	inline void set_pieceCountInHand_18(SyncListInt_t3316705628 * value)
	{
		___pieceCountInHand_18 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCountInHand_18, value);
	}

	inline static int32_t get_offset_of_promoteOrDropPiece_19() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimationIdentity_t3257862896, ___promoteOrDropPiece_19)); }
	inline int32_t get_promoteOrDropPiece_19() const { return ___promoteOrDropPiece_19; }
	inline int32_t* get_address_of_promoteOrDropPiece_19() { return &___promoteOrDropPiece_19; }
	inline void set_promoteOrDropPiece_19(int32_t value)
	{
		___promoteOrDropPiece_19 = value;
	}

	inline static int32_t get_offset_of_move_20() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimationIdentity_t3257862896, ___move_20)); }
	inline int32_t get_move_20() const { return ___move_20; }
	inline int32_t* get_address_of_move_20() { return &___move_20; }
	inline void set_move_20(int32_t value)
	{
		___move_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimationIdentity_t3257862896, ___netData_21)); }
	inline NetData_1_t315392947 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t315392947 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t315392947 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

struct FairyChessMoveAnimationIdentity_t3257862896_StaticFields
{
public:
	// System.Int32 FairyChess.FairyChessMoveAnimationIdentity::kListboard
	int32_t ___kListboard_22;
	// System.Int32 FairyChess.FairyChessMoveAnimationIdentity::kListpieceCountInHand
	int32_t ___kListpieceCountInHand_23;

public:
	inline static int32_t get_offset_of_kListboard_22() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimationIdentity_t3257862896_StaticFields, ___kListboard_22)); }
	inline int32_t get_kListboard_22() const { return ___kListboard_22; }
	inline int32_t* get_address_of_kListboard_22() { return &___kListboard_22; }
	inline void set_kListboard_22(int32_t value)
	{
		___kListboard_22 = value;
	}

	inline static int32_t get_offset_of_kListpieceCountInHand_23() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimationIdentity_t3257862896_StaticFields, ___kListpieceCountInHand_23)); }
	inline int32_t get_kListpieceCountInHand_23() const { return ___kListpieceCountInHand_23; }
	inline int32_t* get_address_of_kListpieceCountInHand_23() { return &___kListpieceCountInHand_23; }
	inline void set_kListpieceCountInHand_23(int32_t value)
	{
		___kListpieceCountInHand_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
