#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Weiqi.WeiqiAI>
struct NetData_1_t2935102504;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.WeiqiAIIdentity
struct  WeiqiAIIdentity_t3577890641  : public DataIdentity_t543951486
{
public:
	// System.Boolean Weiqi.WeiqiAIIdentity::canResign
	bool ___canResign_17;
	// System.Boolean Weiqi.WeiqiAIIdentity::useBook
	bool ___useBook_18;
	// System.Int32 Weiqi.WeiqiAIIdentity::time
	int32_t ___time_19;
	// System.Int32 Weiqi.WeiqiAIIdentity::games
	int32_t ___games_20;
	// System.Int32 Weiqi.WeiqiAIIdentity::engine
	int32_t ___engine_21;
	// NetData`1<Weiqi.WeiqiAI> Weiqi.WeiqiAIIdentity::netData
	NetData_1_t2935102504 * ___netData_22;

public:
	inline static int32_t get_offset_of_canResign_17() { return static_cast<int32_t>(offsetof(WeiqiAIIdentity_t3577890641, ___canResign_17)); }
	inline bool get_canResign_17() const { return ___canResign_17; }
	inline bool* get_address_of_canResign_17() { return &___canResign_17; }
	inline void set_canResign_17(bool value)
	{
		___canResign_17 = value;
	}

	inline static int32_t get_offset_of_useBook_18() { return static_cast<int32_t>(offsetof(WeiqiAIIdentity_t3577890641, ___useBook_18)); }
	inline bool get_useBook_18() const { return ___useBook_18; }
	inline bool* get_address_of_useBook_18() { return &___useBook_18; }
	inline void set_useBook_18(bool value)
	{
		___useBook_18 = value;
	}

	inline static int32_t get_offset_of_time_19() { return static_cast<int32_t>(offsetof(WeiqiAIIdentity_t3577890641, ___time_19)); }
	inline int32_t get_time_19() const { return ___time_19; }
	inline int32_t* get_address_of_time_19() { return &___time_19; }
	inline void set_time_19(int32_t value)
	{
		___time_19 = value;
	}

	inline static int32_t get_offset_of_games_20() { return static_cast<int32_t>(offsetof(WeiqiAIIdentity_t3577890641, ___games_20)); }
	inline int32_t get_games_20() const { return ___games_20; }
	inline int32_t* get_address_of_games_20() { return &___games_20; }
	inline void set_games_20(int32_t value)
	{
		___games_20 = value;
	}

	inline static int32_t get_offset_of_engine_21() { return static_cast<int32_t>(offsetof(WeiqiAIIdentity_t3577890641, ___engine_21)); }
	inline int32_t get_engine_21() const { return ___engine_21; }
	inline int32_t* get_address_of_engine_21() { return &___engine_21; }
	inline void set_engine_21(int32_t value)
	{
		___engine_21 = value;
	}

	inline static int32_t get_offset_of_netData_22() { return static_cast<int32_t>(offsetof(WeiqiAIIdentity_t3577890641, ___netData_22)); }
	inline NetData_1_t2935102504 * get_netData_22() const { return ___netData_22; }
	inline NetData_1_t2935102504 ** get_address_of_netData_22() { return &___netData_22; }
	inline void set_netData_22(NetData_1_t2935102504 * value)
	{
		___netData_22 = value;
		Il2CppCodeGenWriteBarrier(&___netData_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
