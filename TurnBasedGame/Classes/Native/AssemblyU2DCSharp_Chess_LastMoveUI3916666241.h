#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2651567940.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Chess.ChessMoveUI
struct ChessMoveUI_t3171707265;
// Chess.NoneRule.ChessCustomSetUI
struct ChessCustomSetUI_t507609497;
// Chess.NoneRule.ChessCustomMoveUI
struct ChessCustomMoveUI_t1974963002;
// LastMoveCheckChange`1<Chess.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t2254935857;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.LastMoveUI
struct  LastMoveUI_t3916666241  : public UIBehavior_1_t2651567940
{
public:
	// UnityEngine.Transform Chess.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Chess.ChessMoveUI Chess.LastMoveUI::chessMovePrefab
	ChessMoveUI_t3171707265 * ___chessMovePrefab_7;
	// Chess.NoneRule.ChessCustomSetUI Chess.LastMoveUI::chessCustomSetPrefab
	ChessCustomSetUI_t507609497 * ___chessCustomSetPrefab_8;
	// Chess.NoneRule.ChessCustomMoveUI Chess.LastMoveUI::chessCustomMovePrefab
	ChessCustomMoveUI_t1974963002 * ___chessCustomMovePrefab_9;
	// LastMoveCheckChange`1<Chess.LastMoveUI/UIData> Chess.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t2254935857 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t3916666241, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_chessMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t3916666241, ___chessMovePrefab_7)); }
	inline ChessMoveUI_t3171707265 * get_chessMovePrefab_7() const { return ___chessMovePrefab_7; }
	inline ChessMoveUI_t3171707265 ** get_address_of_chessMovePrefab_7() { return &___chessMovePrefab_7; }
	inline void set_chessMovePrefab_7(ChessMoveUI_t3171707265 * value)
	{
		___chessMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___chessMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_chessCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t3916666241, ___chessCustomSetPrefab_8)); }
	inline ChessCustomSetUI_t507609497 * get_chessCustomSetPrefab_8() const { return ___chessCustomSetPrefab_8; }
	inline ChessCustomSetUI_t507609497 ** get_address_of_chessCustomSetPrefab_8() { return &___chessCustomSetPrefab_8; }
	inline void set_chessCustomSetPrefab_8(ChessCustomSetUI_t507609497 * value)
	{
		___chessCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___chessCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_chessCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t3916666241, ___chessCustomMovePrefab_9)); }
	inline ChessCustomMoveUI_t1974963002 * get_chessCustomMovePrefab_9() const { return ___chessCustomMovePrefab_9; }
	inline ChessCustomMoveUI_t1974963002 ** get_address_of_chessCustomMovePrefab_9() { return &___chessCustomMovePrefab_9; }
	inline void set_chessCustomMovePrefab_9(ChessCustomMoveUI_t1974963002 * value)
	{
		___chessCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___chessCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t3916666241, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t2254935857 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t2254935857 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t2254935857 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
