#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<System.Byte>
struct LP_1_t2420848392;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.NeighborColors
struct  NeighborColors_t1258851970  : public Data_t3569509720
{
public:
	// LP`1<System.Byte> Weiqi.NeighborColors::colors
	LP_1_t2420848392 * ___colors_6;

public:
	inline static int32_t get_offset_of_colors_6() { return static_cast<int32_t>(offsetof(NeighborColors_t1258851970, ___colors_6)); }
	inline LP_1_t2420848392 * get_colors_6() const { return ___colors_6; }
	inline LP_1_t2420848392 ** get_address_of_colors_6() { return &___colors_6; }
	inline void set_colors_6(LP_1_t2420848392 * value)
	{
		___colors_6 = value;
		Il2CppCodeGenWriteBarrier(&___colors_6, value);
	}
};

struct NeighborColors_t1258851970_StaticFields
{
public:
	// System.Boolean Weiqi.NeighborColors::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(NeighborColors_t1258851970_StaticFields, ___log_5)); }
	inline bool get_log_5() const { return ___log_5; }
	inline bool* get_address_of_log_5() { return &___log_5; }
	inline void set_log_5(bool value)
	{
		___log_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
