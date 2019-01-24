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
// VP`1<Weiqi.Common/stone>
struct VP_1_t2022265424;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.PieceUI/UIData
struct  UIData_t3748339798  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Weiqi.PieceUI/UIData::coord
	VP_1_t2450154454 * ___coord_5;
	// VP`1<Weiqi.Common/stone> Weiqi.PieceUI/UIData::stone
	VP_1_t2022265424 * ___stone_6;
	// VP`1<System.Boolean> Weiqi.PieceUI/UIData::isDead
	VP_1_t4203851724 * ___isDead_7;
	// VP`1<System.Int32> Weiqi.PieceUI/UIData::owner
	VP_1_t2450154454 * ___owner_8;
	// VP`1<System.Int32> Weiqi.PieceUI/UIData::lastMove
	VP_1_t2450154454 * ___lastMove_9;

public:
	inline static int32_t get_offset_of_coord_5() { return static_cast<int32_t>(offsetof(UIData_t3748339798, ___coord_5)); }
	inline VP_1_t2450154454 * get_coord_5() const { return ___coord_5; }
	inline VP_1_t2450154454 ** get_address_of_coord_5() { return &___coord_5; }
	inline void set_coord_5(VP_1_t2450154454 * value)
	{
		___coord_5 = value;
		Il2CppCodeGenWriteBarrier(&___coord_5, value);
	}

	inline static int32_t get_offset_of_stone_6() { return static_cast<int32_t>(offsetof(UIData_t3748339798, ___stone_6)); }
	inline VP_1_t2022265424 * get_stone_6() const { return ___stone_6; }
	inline VP_1_t2022265424 ** get_address_of_stone_6() { return &___stone_6; }
	inline void set_stone_6(VP_1_t2022265424 * value)
	{
		___stone_6 = value;
		Il2CppCodeGenWriteBarrier(&___stone_6, value);
	}

	inline static int32_t get_offset_of_isDead_7() { return static_cast<int32_t>(offsetof(UIData_t3748339798, ___isDead_7)); }
	inline VP_1_t4203851724 * get_isDead_7() const { return ___isDead_7; }
	inline VP_1_t4203851724 ** get_address_of_isDead_7() { return &___isDead_7; }
	inline void set_isDead_7(VP_1_t4203851724 * value)
	{
		___isDead_7 = value;
		Il2CppCodeGenWriteBarrier(&___isDead_7, value);
	}

	inline static int32_t get_offset_of_owner_8() { return static_cast<int32_t>(offsetof(UIData_t3748339798, ___owner_8)); }
	inline VP_1_t2450154454 * get_owner_8() const { return ___owner_8; }
	inline VP_1_t2450154454 ** get_address_of_owner_8() { return &___owner_8; }
	inline void set_owner_8(VP_1_t2450154454 * value)
	{
		___owner_8 = value;
		Il2CppCodeGenWriteBarrier(&___owner_8, value);
	}

	inline static int32_t get_offset_of_lastMove_9() { return static_cast<int32_t>(offsetof(UIData_t3748339798, ___lastMove_9)); }
	inline VP_1_t2450154454 * get_lastMove_9() const { return ___lastMove_9; }
	inline VP_1_t2450154454 ** get_address_of_lastMove_9() { return &___lastMove_9; }
	inline void set_lastMove_9(VP_1_t2450154454 * value)
	{
		___lastMove_9 = value;
		Il2CppCodeGenWriteBarrier(&___lastMove_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
