#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen105516123.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ChoosePieceHolder
struct  ChoosePieceHolder_t312252573  : public SriaHolderBehavior_1_t105516123
{
public:
	// UnityEngine.UI.Image Shogi.NoneRule.ChoosePieceHolder::imgPiece
	Image_t2042527209 * ___imgPiece_16;
	// Shogi.ShogiGameDataUI/UIData Shogi.NoneRule.ChoosePieceHolder::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_17;

public:
	inline static int32_t get_offset_of_imgPiece_16() { return static_cast<int32_t>(offsetof(ChoosePieceHolder_t312252573, ___imgPiece_16)); }
	inline Image_t2042527209 * get_imgPiece_16() const { return ___imgPiece_16; }
	inline Image_t2042527209 ** get_address_of_imgPiece_16() { return &___imgPiece_16; }
	inline void set_imgPiece_16(Image_t2042527209 * value)
	{
		___imgPiece_16 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_16, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_17() { return static_cast<int32_t>(offsetof(ChoosePieceHolder_t312252573, ___shogiGameDataUIData_17)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_17() const { return ___shogiGameDataUIData_17; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_17() { return &___shogiGameDataUIData_17; }
	inline void set_shogiGameDataUIData_17(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_17 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
