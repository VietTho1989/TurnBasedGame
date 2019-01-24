#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<InternationalDraught.Pos>
struct VP_1_t2554364688;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.Node
struct  Node_t144404306  : public Data_t3569509720
{
public:
	// VP`1<InternationalDraught.Pos> InternationalDraught.Node::p_pos
	VP_1_t2554364688 * ___p_pos_5;
	// VP`1<System.Int32> InternationalDraught.Node::p_ply
	VP_1_t2450154454 * ___p_ply_6;

public:
	inline static int32_t get_offset_of_p_pos_5() { return static_cast<int32_t>(offsetof(Node_t144404306, ___p_pos_5)); }
	inline VP_1_t2554364688 * get_p_pos_5() const { return ___p_pos_5; }
	inline VP_1_t2554364688 ** get_address_of_p_pos_5() { return &___p_pos_5; }
	inline void set_p_pos_5(VP_1_t2554364688 * value)
	{
		___p_pos_5 = value;
		Il2CppCodeGenWriteBarrier(&___p_pos_5, value);
	}

	inline static int32_t get_offset_of_p_ply_6() { return static_cast<int32_t>(offsetof(Node_t144404306, ___p_ply_6)); }
	inline VP_1_t2450154454 * get_p_ply_6() const { return ___p_ply_6; }
	inline VP_1_t2450154454 ** get_address_of_p_ply_6() { return &___p_ply_6; }
	inline void set_p_ply_6(VP_1_t2450154454 * value)
	{
		___p_ply_6 = value;
		Il2CppCodeGenWriteBarrier(&___p_ply_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
