#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Weiqi.DefaultWeiqi>
struct NetData_1_t2337535023;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.DefaultWeiqiIdentity
struct  DefaultWeiqiIdentity_t3190375464  : public DataIdentity_t543951486
{
public:
	// System.Int32 Weiqi.DefaultWeiqiIdentity::size
	int32_t ___size_17;
	// System.Single Weiqi.DefaultWeiqiIdentity::komi
	float ___komi_18;
	// System.Int32 Weiqi.DefaultWeiqiIdentity::rule
	int32_t ___rule_19;
	// System.Int32 Weiqi.DefaultWeiqiIdentity::handicap
	int32_t ___handicap_20;
	// NetData`1<Weiqi.DefaultWeiqi> Weiqi.DefaultWeiqiIdentity::netData
	NetData_1_t2337535023 * ___netData_21;

public:
	inline static int32_t get_offset_of_size_17() { return static_cast<int32_t>(offsetof(DefaultWeiqiIdentity_t3190375464, ___size_17)); }
	inline int32_t get_size_17() const { return ___size_17; }
	inline int32_t* get_address_of_size_17() { return &___size_17; }
	inline void set_size_17(int32_t value)
	{
		___size_17 = value;
	}

	inline static int32_t get_offset_of_komi_18() { return static_cast<int32_t>(offsetof(DefaultWeiqiIdentity_t3190375464, ___komi_18)); }
	inline float get_komi_18() const { return ___komi_18; }
	inline float* get_address_of_komi_18() { return &___komi_18; }
	inline void set_komi_18(float value)
	{
		___komi_18 = value;
	}

	inline static int32_t get_offset_of_rule_19() { return static_cast<int32_t>(offsetof(DefaultWeiqiIdentity_t3190375464, ___rule_19)); }
	inline int32_t get_rule_19() const { return ___rule_19; }
	inline int32_t* get_address_of_rule_19() { return &___rule_19; }
	inline void set_rule_19(int32_t value)
	{
		___rule_19 = value;
	}

	inline static int32_t get_offset_of_handicap_20() { return static_cast<int32_t>(offsetof(DefaultWeiqiIdentity_t3190375464, ___handicap_20)); }
	inline int32_t get_handicap_20() const { return ___handicap_20; }
	inline int32_t* get_address_of_handicap_20() { return &___handicap_20; }
	inline void set_handicap_20(int32_t value)
	{
		___handicap_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(DefaultWeiqiIdentity_t3190375464, ___netData_21)); }
	inline NetData_1_t2337535023 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t2337535023 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t2337535023 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
