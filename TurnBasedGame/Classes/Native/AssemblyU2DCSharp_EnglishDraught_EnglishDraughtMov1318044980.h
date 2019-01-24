#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.UInt64>
struct VP_1_t3287473920;
// LP`1<System.Byte>
struct LP_1_t2420848392;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.EnglishDraughtMove
struct  EnglishDraughtMove_t1318044980  : public GameMove_t1861898997
{
public:
	// VP`1<System.UInt64> EnglishDraught.EnglishDraughtMove::SrcDst
	VP_1_t3287473920 * ___SrcDst_5;
	// LP`1<System.Byte> EnglishDraught.EnglishDraughtMove::cPath
	LP_1_t2420848392 * ___cPath_6;

public:
	inline static int32_t get_offset_of_SrcDst_5() { return static_cast<int32_t>(offsetof(EnglishDraughtMove_t1318044980, ___SrcDst_5)); }
	inline VP_1_t3287473920 * get_SrcDst_5() const { return ___SrcDst_5; }
	inline VP_1_t3287473920 ** get_address_of_SrcDst_5() { return &___SrcDst_5; }
	inline void set_SrcDst_5(VP_1_t3287473920 * value)
	{
		___SrcDst_5 = value;
		Il2CppCodeGenWriteBarrier(&___SrcDst_5, value);
	}

	inline static int32_t get_offset_of_cPath_6() { return static_cast<int32_t>(offsetof(EnglishDraughtMove_t1318044980, ___cPath_6)); }
	inline LP_1_t2420848392 * get_cPath_6() const { return ___cPath_6; }
	inline LP_1_t2420848392 ** get_address_of_cPath_6() { return &___cPath_6; }
	inline void set_cPath_6(LP_1_t2420848392 * value)
	{
		___cPath_6 = value;
		Il2CppCodeGenWriteBarrier(&___cPath_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
