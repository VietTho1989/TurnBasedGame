#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameType1512575910.h"

// System.String
struct String_t;
// LP`1<InternationalDraught.Node>
struct LP_1_t3177115558;
// VP`1<InternationalDraught.Var>
struct VP_1_t141305727;
// VP`1<System.UInt64>
struct VP_1_t3287473920;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.InternationalDraught
struct  InternationalDraught_t346546735  : public GameType_t1512575910
{
public:
	// LP`1<InternationalDraught.Node> InternationalDraught.InternationalDraught::node
	LP_1_t3177115558 * ___node_11;
	// VP`1<InternationalDraught.Var> InternationalDraught.InternationalDraught::var
	VP_1_t141305727 * ___var_12;
	// VP`1<System.UInt64> InternationalDraught.InternationalDraught::lastMove
	VP_1_t3287473920 * ___lastMove_13;
	// VP`1<System.Int32> InternationalDraught.InternationalDraught::ply
	VP_1_t2450154454 * ___ply_14;
	// VP`1<System.Int32> InternationalDraught.InternationalDraught::captureSize
	VP_1_t2450154454 * ___captureSize_15;
	// LP`1<System.Int32> InternationalDraught.InternationalDraught::captureSquares
	LP_1_t809621404 * ___captureSquares_16;
	// VP`1<System.Boolean> InternationalDraught.InternationalDraught::isCustom
	VP_1_t4203851724 * ___isCustom_17;

public:
	inline static int32_t get_offset_of_node_11() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735, ___node_11)); }
	inline LP_1_t3177115558 * get_node_11() const { return ___node_11; }
	inline LP_1_t3177115558 ** get_address_of_node_11() { return &___node_11; }
	inline void set_node_11(LP_1_t3177115558 * value)
	{
		___node_11 = value;
		Il2CppCodeGenWriteBarrier(&___node_11, value);
	}

	inline static int32_t get_offset_of_var_12() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735, ___var_12)); }
	inline VP_1_t141305727 * get_var_12() const { return ___var_12; }
	inline VP_1_t141305727 ** get_address_of_var_12() { return &___var_12; }
	inline void set_var_12(VP_1_t141305727 * value)
	{
		___var_12 = value;
		Il2CppCodeGenWriteBarrier(&___var_12, value);
	}

	inline static int32_t get_offset_of_lastMove_13() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735, ___lastMove_13)); }
	inline VP_1_t3287473920 * get_lastMove_13() const { return ___lastMove_13; }
	inline VP_1_t3287473920 ** get_address_of_lastMove_13() { return &___lastMove_13; }
	inline void set_lastMove_13(VP_1_t3287473920 * value)
	{
		___lastMove_13 = value;
		Il2CppCodeGenWriteBarrier(&___lastMove_13, value);
	}

	inline static int32_t get_offset_of_ply_14() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735, ___ply_14)); }
	inline VP_1_t2450154454 * get_ply_14() const { return ___ply_14; }
	inline VP_1_t2450154454 ** get_address_of_ply_14() { return &___ply_14; }
	inline void set_ply_14(VP_1_t2450154454 * value)
	{
		___ply_14 = value;
		Il2CppCodeGenWriteBarrier(&___ply_14, value);
	}

	inline static int32_t get_offset_of_captureSize_15() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735, ___captureSize_15)); }
	inline VP_1_t2450154454 * get_captureSize_15() const { return ___captureSize_15; }
	inline VP_1_t2450154454 ** get_address_of_captureSize_15() { return &___captureSize_15; }
	inline void set_captureSize_15(VP_1_t2450154454 * value)
	{
		___captureSize_15 = value;
		Il2CppCodeGenWriteBarrier(&___captureSize_15, value);
	}

	inline static int32_t get_offset_of_captureSquares_16() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735, ___captureSquares_16)); }
	inline LP_1_t809621404 * get_captureSquares_16() const { return ___captureSquares_16; }
	inline LP_1_t809621404 ** get_address_of_captureSquares_16() { return &___captureSquares_16; }
	inline void set_captureSquares_16(LP_1_t809621404 * value)
	{
		___captureSquares_16 = value;
		Il2CppCodeGenWriteBarrier(&___captureSquares_16, value);
	}

	inline static int32_t get_offset_of_isCustom_17() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735, ___isCustom_17)); }
	inline VP_1_t4203851724 * get_isCustom_17() const { return ___isCustom_17; }
	inline VP_1_t4203851724 ** get_address_of_isCustom_17() { return &___isCustom_17; }
	inline void set_isCustom_17(VP_1_t4203851724 * value)
	{
		___isCustom_17 = value;
		Il2CppCodeGenWriteBarrier(&___isCustom_17, value);
	}
};

struct InternationalDraught_t346546735_StaticFields
{
public:
	// System.Boolean InternationalDraught.InternationalDraught::log
	bool ___log_9;
	// System.Collections.Generic.List`1<System.Byte> InternationalDraught.InternationalDraught::AllowNames
	List_1_t3052225568 * ___AllowNames_18;

public:
	inline static int32_t get_offset_of_log_9() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735_StaticFields, ___log_9)); }
	inline bool get_log_9() const { return ___log_9; }
	inline bool* get_address_of_log_9() { return &___log_9; }
	inline void set_log_9(bool value)
	{
		___log_9 = value;
	}

	inline static int32_t get_offset_of_AllowNames_18() { return static_cast<int32_t>(offsetof(InternationalDraught_t346546735_StaticFields, ___AllowNames_18)); }
	inline List_1_t3052225568 * get_AllowNames_18() const { return ___AllowNames_18; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_18() { return &___AllowNames_18; }
	inline void set_AllowNames_18(List_1_t3052225568 * value)
	{
		___AllowNames_18 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
