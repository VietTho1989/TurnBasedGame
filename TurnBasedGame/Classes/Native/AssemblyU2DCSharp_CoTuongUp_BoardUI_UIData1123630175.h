#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<CoTuongUp.CoTuongUp>>
struct VP_1_t1916974411;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// LP`1<CoTuongUp.PieceUI/UIData>
struct LP_1_t3800186387;
// LP`1<CoTuongUp.CaptureUI/UIData>
struct LP_1_t1670660921;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.BoardUI/UIData
struct  UIData_t1123630175  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<CoTuongUp.CoTuongUp>> CoTuongUp.BoardUI/UIData::coTuongUp
	VP_1_t1916974411 * ___coTuongUp_5;
	// VP`1<System.Boolean> CoTuongUp.BoardUI/UIData::isWatcher
	VP_1_t4203851724 * ___isWatcher_6;
	// LP`1<CoTuongUp.PieceUI/UIData> CoTuongUp.BoardUI/UIData::pieces
	LP_1_t3800186387 * ___pieces_7;
	// LP`1<CoTuongUp.CaptureUI/UIData> CoTuongUp.BoardUI/UIData::captures
	LP_1_t1670660921 * ___captures_8;

public:
	inline static int32_t get_offset_of_coTuongUp_5() { return static_cast<int32_t>(offsetof(UIData_t1123630175, ___coTuongUp_5)); }
	inline VP_1_t1916974411 * get_coTuongUp_5() const { return ___coTuongUp_5; }
	inline VP_1_t1916974411 ** get_address_of_coTuongUp_5() { return &___coTuongUp_5; }
	inline void set_coTuongUp_5(VP_1_t1916974411 * value)
	{
		___coTuongUp_5 = value;
		Il2CppCodeGenWriteBarrier(&___coTuongUp_5, value);
	}

	inline static int32_t get_offset_of_isWatcher_6() { return static_cast<int32_t>(offsetof(UIData_t1123630175, ___isWatcher_6)); }
	inline VP_1_t4203851724 * get_isWatcher_6() const { return ___isWatcher_6; }
	inline VP_1_t4203851724 ** get_address_of_isWatcher_6() { return &___isWatcher_6; }
	inline void set_isWatcher_6(VP_1_t4203851724 * value)
	{
		___isWatcher_6 = value;
		Il2CppCodeGenWriteBarrier(&___isWatcher_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t1123630175, ___pieces_7)); }
	inline LP_1_t3800186387 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t3800186387 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t3800186387 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}

	inline static int32_t get_offset_of_captures_8() { return static_cast<int32_t>(offsetof(UIData_t1123630175, ___captures_8)); }
	inline LP_1_t1670660921 * get_captures_8() const { return ___captures_8; }
	inline LP_1_t1670660921 ** get_address_of_captures_8() { return &___captures_8; }
	inline void set_captures_8(LP_1_t1670660921 * value)
	{
		___captures_8 = value;
		Il2CppCodeGenWriteBarrier(&___captures_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
