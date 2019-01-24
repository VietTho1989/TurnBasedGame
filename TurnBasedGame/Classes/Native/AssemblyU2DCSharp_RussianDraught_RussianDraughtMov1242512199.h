#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// LP`1<System.UInt16>
struct LP_1_t4019593863;
// LP`1<System.Byte>
struct LP_1_t2420848392;
// VP`1<System.Byte>
struct VP_1_t4061381442;
// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtMove
struct  RussianDraughtMove_t1242512199  : public GameMove_t1861898997
{
public:
	// LP`1<System.UInt16> RussianDraught.RussianDraughtMove::m
	LP_1_t4019593863 * ___m_5;
	// LP`1<System.Byte> RussianDraught.RussianDraughtMove::path
	LP_1_t2420848392 * ___path_6;
	// VP`1<System.Byte> RussianDraught.RussianDraughtMove::l
	VP_1_t4061381442 * ___l_7;

public:
	inline static int32_t get_offset_of_m_5() { return static_cast<int32_t>(offsetof(RussianDraughtMove_t1242512199, ___m_5)); }
	inline LP_1_t4019593863 * get_m_5() const { return ___m_5; }
	inline LP_1_t4019593863 ** get_address_of_m_5() { return &___m_5; }
	inline void set_m_5(LP_1_t4019593863 * value)
	{
		___m_5 = value;
		Il2CppCodeGenWriteBarrier(&___m_5, value);
	}

	inline static int32_t get_offset_of_path_6() { return static_cast<int32_t>(offsetof(RussianDraughtMove_t1242512199, ___path_6)); }
	inline LP_1_t2420848392 * get_path_6() const { return ___path_6; }
	inline LP_1_t2420848392 ** get_address_of_path_6() { return &___path_6; }
	inline void set_path_6(LP_1_t2420848392 * value)
	{
		___path_6 = value;
		Il2CppCodeGenWriteBarrier(&___path_6, value);
	}

	inline static int32_t get_offset_of_l_7() { return static_cast<int32_t>(offsetof(RussianDraughtMove_t1242512199, ___l_7)); }
	inline VP_1_t4061381442 * get_l_7() const { return ___l_7; }
	inline VP_1_t4061381442 ** get_address_of_l_7() { return &___l_7; }
	inline void set_l_7(VP_1_t4061381442 * value)
	{
		___l_7 = value;
		Il2CppCodeGenWriteBarrier(&___l_7, value);
	}
};

struct RussianDraughtMove_t1242512199_StaticFields
{
public:
	// System.Int32[] RussianDraught.RussianDraughtMove::Square64
	Int32U5BU5D_t3030399641* ___Square64_8;

public:
	inline static int32_t get_offset_of_Square64_8() { return static_cast<int32_t>(offsetof(RussianDraughtMove_t1242512199_StaticFields, ___Square64_8)); }
	inline Int32U5BU5D_t3030399641* get_Square64_8() const { return ___Square64_8; }
	inline Int32U5BU5D_t3030399641** get_address_of_Square64_8() { return &___Square64_8; }
	inline void set_Square64_8(Int32U5BU5D_t3030399641* value)
	{
		___Square64_8 = value;
		Il2CppCodeGenWriteBarrier(&___Square64_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
