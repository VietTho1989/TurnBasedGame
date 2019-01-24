#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<MineSweeper.Point>
struct LP_1_t1781911552;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.Neb
struct  Neb_t3622027583  : public Data_t3569509720
{
public:
	// LP`1<MineSweeper.Point> MineSweeper.Neb::interior
	LP_1_t1781911552 * ___interior_5;
	// LP`1<MineSweeper.Point> MineSweeper.Neb::fringe
	LP_1_t1781911552 * ___fringe_6;
	// LP`1<MineSweeper.Point> MineSweeper.Neb::boundary
	LP_1_t1781911552 * ___boundary_7;

public:
	inline static int32_t get_offset_of_interior_5() { return static_cast<int32_t>(offsetof(Neb_t3622027583, ___interior_5)); }
	inline LP_1_t1781911552 * get_interior_5() const { return ___interior_5; }
	inline LP_1_t1781911552 ** get_address_of_interior_5() { return &___interior_5; }
	inline void set_interior_5(LP_1_t1781911552 * value)
	{
		___interior_5 = value;
		Il2CppCodeGenWriteBarrier(&___interior_5, value);
	}

	inline static int32_t get_offset_of_fringe_6() { return static_cast<int32_t>(offsetof(Neb_t3622027583, ___fringe_6)); }
	inline LP_1_t1781911552 * get_fringe_6() const { return ___fringe_6; }
	inline LP_1_t1781911552 ** get_address_of_fringe_6() { return &___fringe_6; }
	inline void set_fringe_6(LP_1_t1781911552 * value)
	{
		___fringe_6 = value;
		Il2CppCodeGenWriteBarrier(&___fringe_6, value);
	}

	inline static int32_t get_offset_of_boundary_7() { return static_cast<int32_t>(offsetof(Neb_t3622027583, ___boundary_7)); }
	inline LP_1_t1781911552 * get_boundary_7() const { return ___boundary_7; }
	inline LP_1_t1781911552 ** get_address_of_boundary_7() { return &___boundary_7; }
	inline void set_boundary_7(LP_1_t1781911552 * value)
	{
		___boundary_7 = value;
		Il2CppCodeGenWriteBarrier(&___boundary_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
