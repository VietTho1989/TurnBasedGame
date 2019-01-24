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
// VP`1<Perspective/Sub>
struct VP_1_t2781761191;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Perspective
struct  Perspective_t2283615590  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Perspective::playerView
	VP_1_t2450154454 * ___playerView_5;
	// VP`1<Perspective/Sub> Perspective::sub
	VP_1_t2781761191 * ___sub_6;

public:
	inline static int32_t get_offset_of_playerView_5() { return static_cast<int32_t>(offsetof(Perspective_t2283615590, ___playerView_5)); }
	inline VP_1_t2450154454 * get_playerView_5() const { return ___playerView_5; }
	inline VP_1_t2450154454 ** get_address_of_playerView_5() { return &___playerView_5; }
	inline void set_playerView_5(VP_1_t2450154454 * value)
	{
		___playerView_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerView_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(Perspective_t2283615590, ___sub_6)); }
	inline VP_1_t2781761191 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2781761191 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2781761191 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
