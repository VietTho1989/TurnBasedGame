#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Shogi.ShogiAI>
struct NetData_1_t3622409633;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiAIIdentity
struct  ShogiAIIdentity_t688703498  : public DataIdentity_t543951486
{
public:
	// System.Int32 Shogi.ShogiAIIdentity::depth
	int32_t ___depth_17;
	// System.Int32 Shogi.ShogiAIIdentity::skillLevel
	int32_t ___skillLevel_18;
	// System.Int32 Shogi.ShogiAIIdentity::mr
	int32_t ___mr_19;
	// System.Int32 Shogi.ShogiAIIdentity::duration
	int32_t ___duration_20;
	// System.Boolean Shogi.ShogiAIIdentity::useBook
	bool ___useBook_21;
	// NetData`1<Shogi.ShogiAI> Shogi.ShogiAIIdentity::netData
	NetData_1_t3622409633 * ___netData_22;

public:
	inline static int32_t get_offset_of_depth_17() { return static_cast<int32_t>(offsetof(ShogiAIIdentity_t688703498, ___depth_17)); }
	inline int32_t get_depth_17() const { return ___depth_17; }
	inline int32_t* get_address_of_depth_17() { return &___depth_17; }
	inline void set_depth_17(int32_t value)
	{
		___depth_17 = value;
	}

	inline static int32_t get_offset_of_skillLevel_18() { return static_cast<int32_t>(offsetof(ShogiAIIdentity_t688703498, ___skillLevel_18)); }
	inline int32_t get_skillLevel_18() const { return ___skillLevel_18; }
	inline int32_t* get_address_of_skillLevel_18() { return &___skillLevel_18; }
	inline void set_skillLevel_18(int32_t value)
	{
		___skillLevel_18 = value;
	}

	inline static int32_t get_offset_of_mr_19() { return static_cast<int32_t>(offsetof(ShogiAIIdentity_t688703498, ___mr_19)); }
	inline int32_t get_mr_19() const { return ___mr_19; }
	inline int32_t* get_address_of_mr_19() { return &___mr_19; }
	inline void set_mr_19(int32_t value)
	{
		___mr_19 = value;
	}

	inline static int32_t get_offset_of_duration_20() { return static_cast<int32_t>(offsetof(ShogiAIIdentity_t688703498, ___duration_20)); }
	inline int32_t get_duration_20() const { return ___duration_20; }
	inline int32_t* get_address_of_duration_20() { return &___duration_20; }
	inline void set_duration_20(int32_t value)
	{
		___duration_20 = value;
	}

	inline static int32_t get_offset_of_useBook_21() { return static_cast<int32_t>(offsetof(ShogiAIIdentity_t688703498, ___useBook_21)); }
	inline bool get_useBook_21() const { return ___useBook_21; }
	inline bool* get_address_of_useBook_21() { return &___useBook_21; }
	inline void set_useBook_21(bool value)
	{
		___useBook_21 = value;
	}

	inline static int32_t get_offset_of_netData_22() { return static_cast<int32_t>(offsetof(ShogiAIIdentity_t688703498, ___netData_22)); }
	inline NetData_1_t3622409633 * get_netData_22() const { return ___netData_22; }
	inline NetData_1_t3622409633 ** get_address_of_netData_22() { return &___netData_22; }
	inline void set_netData_22(NetData_1_t3622409633 * value)
	{
		___netData_22 = value;
		Il2CppCodeGenWriteBarrier(&___netData_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
