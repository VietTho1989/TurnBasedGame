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
// LP`1<System.Byte>
struct LP_1_t2420848392;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.Node
struct  Node_t1040288906  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> CoTuongUp.Node::ply
	VP_1_t2450154454 * ___ply_5;
	// LP`1<System.Byte> CoTuongUp.Node::pieces
	LP_1_t2420848392 * ___pieces_6;
	// LP`1<System.Byte> CoTuongUp.Node::captures
	LP_1_t2420848392 * ___captures_7;

public:
	inline static int32_t get_offset_of_ply_5() { return static_cast<int32_t>(offsetof(Node_t1040288906, ___ply_5)); }
	inline VP_1_t2450154454 * get_ply_5() const { return ___ply_5; }
	inline VP_1_t2450154454 ** get_address_of_ply_5() { return &___ply_5; }
	inline void set_ply_5(VP_1_t2450154454 * value)
	{
		___ply_5 = value;
		Il2CppCodeGenWriteBarrier(&___ply_5, value);
	}

	inline static int32_t get_offset_of_pieces_6() { return static_cast<int32_t>(offsetof(Node_t1040288906, ___pieces_6)); }
	inline LP_1_t2420848392 * get_pieces_6() const { return ___pieces_6; }
	inline LP_1_t2420848392 ** get_address_of_pieces_6() { return &___pieces_6; }
	inline void set_pieces_6(LP_1_t2420848392 * value)
	{
		___pieces_6 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_6, value);
	}

	inline static int32_t get_offset_of_captures_7() { return static_cast<int32_t>(offsetof(Node_t1040288906, ___captures_7)); }
	inline LP_1_t2420848392 * get_captures_7() const { return ___captures_7; }
	inline LP_1_t2420848392 ** get_address_of_captures_7() { return &___captures_7; }
	inline void set_captures_7(LP_1_t2420848392 * value)
	{
		___captures_7 = value;
		Il2CppCodeGenWriteBarrier(&___captures_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
