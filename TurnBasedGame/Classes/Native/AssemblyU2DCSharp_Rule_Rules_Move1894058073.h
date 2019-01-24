#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_Rule_Rules_Coord546067121.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rule.Rules/Move
struct  Move_t1894058073  : public Il2CppObject
{
public:
	// Rule.Rules/Coord Rule.Rules/Move::from
	Coord_t546067121  ___from_0;
	// Rule.Rules/Coord Rule.Rules/Move::dest
	Coord_t546067121  ___dest_1;

public:
	inline static int32_t get_offset_of_from_0() { return static_cast<int32_t>(offsetof(Move_t1894058073, ___from_0)); }
	inline Coord_t546067121  get_from_0() const { return ___from_0; }
	inline Coord_t546067121 * get_address_of_from_0() { return &___from_0; }
	inline void set_from_0(Coord_t546067121  value)
	{
		___from_0 = value;
	}

	inline static int32_t get_offset_of_dest_1() { return static_cast<int32_t>(offsetof(Move_t1894058073, ___dest_1)); }
	inline Coord_t546067121  get_dest_1() const { return ___dest_1; }
	inline Coord_t546067121 * get_address_of_dest_1() { return &___dest_1; }
	inline void set_dest_1(Coord_t546067121  value)
	{
		___dest_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
