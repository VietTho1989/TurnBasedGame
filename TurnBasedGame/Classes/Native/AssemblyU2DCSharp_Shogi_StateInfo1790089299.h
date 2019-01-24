#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<System.UInt64>
struct VP_1_t3287473920;
// VP`1<Shogi.Common/BitBoard>
struct VP_1_t124297399;
// VP`1<Shogi.Common/Piece>
struct VP_1_t823118500;
// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<Shogi.ChangedLists>
struct VP_1_t335553895;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.StateInfo
struct  StateInfo_t1790089299  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Shogi.StateInfo::material
	VP_1_t2450154454 * ___material_6;
	// VP`1<System.Int32> Shogi.StateInfo::pliesFromNull
	VP_1_t2450154454 * ___pliesFromNull_7;
	// LP`1<System.Int32> Shogi.StateInfo::continuousCheck
	LP_1_t809621404 * ___continuousCheck_8;
	// VP`1<System.UInt64> Shogi.StateInfo::boardKey
	VP_1_t3287473920 * ___boardKey_9;
	// VP`1<System.UInt64> Shogi.StateInfo::handKey
	VP_1_t3287473920 * ___handKey_10;
	// VP`1<Shogi.Common/BitBoard> Shogi.StateInfo::checkersBB
	VP_1_t124297399 * ___checkersBB_11;
	// VP`1<Shogi.Common/Piece> Shogi.StateInfo::capturedPiece
	VP_1_t823118500 * ___capturedPiece_12;
	// VP`1<System.UInt32> Shogi.StateInfo::hand
	VP_1_t2527959027 * ___hand_13;
	// VP`1<Shogi.ChangedLists> Shogi.StateInfo::cl
	VP_1_t335553895 * ___cl_14;

public:
	inline static int32_t get_offset_of_material_6() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___material_6)); }
	inline VP_1_t2450154454 * get_material_6() const { return ___material_6; }
	inline VP_1_t2450154454 ** get_address_of_material_6() { return &___material_6; }
	inline void set_material_6(VP_1_t2450154454 * value)
	{
		___material_6 = value;
		Il2CppCodeGenWriteBarrier(&___material_6, value);
	}

	inline static int32_t get_offset_of_pliesFromNull_7() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___pliesFromNull_7)); }
	inline VP_1_t2450154454 * get_pliesFromNull_7() const { return ___pliesFromNull_7; }
	inline VP_1_t2450154454 ** get_address_of_pliesFromNull_7() { return &___pliesFromNull_7; }
	inline void set_pliesFromNull_7(VP_1_t2450154454 * value)
	{
		___pliesFromNull_7 = value;
		Il2CppCodeGenWriteBarrier(&___pliesFromNull_7, value);
	}

	inline static int32_t get_offset_of_continuousCheck_8() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___continuousCheck_8)); }
	inline LP_1_t809621404 * get_continuousCheck_8() const { return ___continuousCheck_8; }
	inline LP_1_t809621404 ** get_address_of_continuousCheck_8() { return &___continuousCheck_8; }
	inline void set_continuousCheck_8(LP_1_t809621404 * value)
	{
		___continuousCheck_8 = value;
		Il2CppCodeGenWriteBarrier(&___continuousCheck_8, value);
	}

	inline static int32_t get_offset_of_boardKey_9() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___boardKey_9)); }
	inline VP_1_t3287473920 * get_boardKey_9() const { return ___boardKey_9; }
	inline VP_1_t3287473920 ** get_address_of_boardKey_9() { return &___boardKey_9; }
	inline void set_boardKey_9(VP_1_t3287473920 * value)
	{
		___boardKey_9 = value;
		Il2CppCodeGenWriteBarrier(&___boardKey_9, value);
	}

	inline static int32_t get_offset_of_handKey_10() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___handKey_10)); }
	inline VP_1_t3287473920 * get_handKey_10() const { return ___handKey_10; }
	inline VP_1_t3287473920 ** get_address_of_handKey_10() { return &___handKey_10; }
	inline void set_handKey_10(VP_1_t3287473920 * value)
	{
		___handKey_10 = value;
		Il2CppCodeGenWriteBarrier(&___handKey_10, value);
	}

	inline static int32_t get_offset_of_checkersBB_11() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___checkersBB_11)); }
	inline VP_1_t124297399 * get_checkersBB_11() const { return ___checkersBB_11; }
	inline VP_1_t124297399 ** get_address_of_checkersBB_11() { return &___checkersBB_11; }
	inline void set_checkersBB_11(VP_1_t124297399 * value)
	{
		___checkersBB_11 = value;
		Il2CppCodeGenWriteBarrier(&___checkersBB_11, value);
	}

	inline static int32_t get_offset_of_capturedPiece_12() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___capturedPiece_12)); }
	inline VP_1_t823118500 * get_capturedPiece_12() const { return ___capturedPiece_12; }
	inline VP_1_t823118500 ** get_address_of_capturedPiece_12() { return &___capturedPiece_12; }
	inline void set_capturedPiece_12(VP_1_t823118500 * value)
	{
		___capturedPiece_12 = value;
		Il2CppCodeGenWriteBarrier(&___capturedPiece_12, value);
	}

	inline static int32_t get_offset_of_hand_13() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___hand_13)); }
	inline VP_1_t2527959027 * get_hand_13() const { return ___hand_13; }
	inline VP_1_t2527959027 ** get_address_of_hand_13() { return &___hand_13; }
	inline void set_hand_13(VP_1_t2527959027 * value)
	{
		___hand_13 = value;
		Il2CppCodeGenWriteBarrier(&___hand_13, value);
	}

	inline static int32_t get_offset_of_cl_14() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299, ___cl_14)); }
	inline VP_1_t335553895 * get_cl_14() const { return ___cl_14; }
	inline VP_1_t335553895 ** get_address_of_cl_14() { return &___cl_14; }
	inline void set_cl_14(VP_1_t335553895 * value)
	{
		___cl_14 = value;
		Il2CppCodeGenWriteBarrier(&___cl_14, value);
	}
};

struct StateInfo_t1790089299_StaticFields
{
public:
	// System.Boolean Shogi.StateInfo::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(StateInfo_t1790089299_StaticFields, ___log_5)); }
	inline bool get_log_5() const { return ___log_5; }
	inline bool* get_address_of_log_5() { return &___log_5; }
	inline void set_log_5(bool value)
	{
		___log_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
