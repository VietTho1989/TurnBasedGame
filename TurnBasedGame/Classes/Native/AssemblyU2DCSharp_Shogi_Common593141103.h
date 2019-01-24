#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Shogi.Common/Piece[]
struct PieceU5BU5D_t377063635;
// Shogi.Common/HandPiece[]
struct HandPieceU5BU5D_t1029127404;
// System.String[]
struct StringU5BU5D_t1642385972;
// Shogi.Common/Rank[]
struct RankU5BU5D_t666093879;
// Shogi.Common/File[]
struct FileU5BU5D_t2008851651;
// Shogi.Common/PieceType[]
struct PieceTypeU5BU5D_t293930075;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.Common
struct  Common_t593141103  : public Il2CppObject
{
public:

public:
};

struct Common_t593141103_StaticFields
{
public:
	// Shogi.Common/Piece[] Shogi.Common::CanChosenPieces
	PieceU5BU5D_t377063635* ___CanChosenPieces_0;
	// Shogi.Common/HandPiece[] Shogi.Common::CanChosenHandPiecs
	HandPieceU5BU5D_t1029127404* ___CanChosenHandPiecs_2;
	// System.String[] Shogi.Common::HandPieceToStringTable
	StringU5BU5D_t1642385972* ___HandPieceToStringTable_3;
	// Shogi.Common/Rank[] Shogi.Common::SquareToRank
	RankU5BU5D_t666093879* ___SquareToRank_4;
	// Shogi.Common/File[] Shogi.Common::SquareToFile
	FileU5BU5D_t2008851651* ___SquareToFile_5;
	// System.String[] Shogi.Common::PieceToCharCSATable
	StringU5BU5D_t1642385972* ___PieceToCharCSATable_6;
	// System.String[] Shogi.Common::PieceToCharUSITable
	StringU5BU5D_t1642385972* ___PieceToCharUSITable_7;
	// Shogi.Common/PieceType[] Shogi.Common::HandPieceToPieceTypeTable
	PieceTypeU5BU5D_t293930075* ___HandPieceToPieceTypeTable_8;

public:
	inline static int32_t get_offset_of_CanChosenPieces_0() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___CanChosenPieces_0)); }
	inline PieceU5BU5D_t377063635* get_CanChosenPieces_0() const { return ___CanChosenPieces_0; }
	inline PieceU5BU5D_t377063635** get_address_of_CanChosenPieces_0() { return &___CanChosenPieces_0; }
	inline void set_CanChosenPieces_0(PieceU5BU5D_t377063635* value)
	{
		___CanChosenPieces_0 = value;
		Il2CppCodeGenWriteBarrier(&___CanChosenPieces_0, value);
	}

	inline static int32_t get_offset_of_CanChosenHandPiecs_2() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___CanChosenHandPiecs_2)); }
	inline HandPieceU5BU5D_t1029127404* get_CanChosenHandPiecs_2() const { return ___CanChosenHandPiecs_2; }
	inline HandPieceU5BU5D_t1029127404** get_address_of_CanChosenHandPiecs_2() { return &___CanChosenHandPiecs_2; }
	inline void set_CanChosenHandPiecs_2(HandPieceU5BU5D_t1029127404* value)
	{
		___CanChosenHandPiecs_2 = value;
		Il2CppCodeGenWriteBarrier(&___CanChosenHandPiecs_2, value);
	}

	inline static int32_t get_offset_of_HandPieceToStringTable_3() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___HandPieceToStringTable_3)); }
	inline StringU5BU5D_t1642385972* get_HandPieceToStringTable_3() const { return ___HandPieceToStringTable_3; }
	inline StringU5BU5D_t1642385972** get_address_of_HandPieceToStringTable_3() { return &___HandPieceToStringTable_3; }
	inline void set_HandPieceToStringTable_3(StringU5BU5D_t1642385972* value)
	{
		___HandPieceToStringTable_3 = value;
		Il2CppCodeGenWriteBarrier(&___HandPieceToStringTable_3, value);
	}

	inline static int32_t get_offset_of_SquareToRank_4() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___SquareToRank_4)); }
	inline RankU5BU5D_t666093879* get_SquareToRank_4() const { return ___SquareToRank_4; }
	inline RankU5BU5D_t666093879** get_address_of_SquareToRank_4() { return &___SquareToRank_4; }
	inline void set_SquareToRank_4(RankU5BU5D_t666093879* value)
	{
		___SquareToRank_4 = value;
		Il2CppCodeGenWriteBarrier(&___SquareToRank_4, value);
	}

	inline static int32_t get_offset_of_SquareToFile_5() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___SquareToFile_5)); }
	inline FileU5BU5D_t2008851651* get_SquareToFile_5() const { return ___SquareToFile_5; }
	inline FileU5BU5D_t2008851651** get_address_of_SquareToFile_5() { return &___SquareToFile_5; }
	inline void set_SquareToFile_5(FileU5BU5D_t2008851651* value)
	{
		___SquareToFile_5 = value;
		Il2CppCodeGenWriteBarrier(&___SquareToFile_5, value);
	}

	inline static int32_t get_offset_of_PieceToCharCSATable_6() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___PieceToCharCSATable_6)); }
	inline StringU5BU5D_t1642385972* get_PieceToCharCSATable_6() const { return ___PieceToCharCSATable_6; }
	inline StringU5BU5D_t1642385972** get_address_of_PieceToCharCSATable_6() { return &___PieceToCharCSATable_6; }
	inline void set_PieceToCharCSATable_6(StringU5BU5D_t1642385972* value)
	{
		___PieceToCharCSATable_6 = value;
		Il2CppCodeGenWriteBarrier(&___PieceToCharCSATable_6, value);
	}

	inline static int32_t get_offset_of_PieceToCharUSITable_7() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___PieceToCharUSITable_7)); }
	inline StringU5BU5D_t1642385972* get_PieceToCharUSITable_7() const { return ___PieceToCharUSITable_7; }
	inline StringU5BU5D_t1642385972** get_address_of_PieceToCharUSITable_7() { return &___PieceToCharUSITable_7; }
	inline void set_PieceToCharUSITable_7(StringU5BU5D_t1642385972* value)
	{
		___PieceToCharUSITable_7 = value;
		Il2CppCodeGenWriteBarrier(&___PieceToCharUSITable_7, value);
	}

	inline static int32_t get_offset_of_HandPieceToPieceTypeTable_8() { return static_cast<int32_t>(offsetof(Common_t593141103_StaticFields, ___HandPieceToPieceTypeTable_8)); }
	inline PieceTypeU5BU5D_t293930075* get_HandPieceToPieceTypeTable_8() const { return ___HandPieceToPieceTypeTable_8; }
	inline PieceTypeU5BU5D_t293930075** get_address_of_HandPieceToPieceTypeTable_8() { return &___HandPieceToPieceTypeTable_8; }
	inline void set_HandPieceToPieceTypeTable_8(PieceTypeU5BU5D_t293930075* value)
	{
		___HandPieceToPieceTypeTable_8 = value;
		Il2CppCodeGenWriteBarrier(&___HandPieceToPieceTypeTable_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
