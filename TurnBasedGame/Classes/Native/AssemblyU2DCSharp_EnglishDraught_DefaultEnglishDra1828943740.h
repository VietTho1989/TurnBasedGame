#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<EnglishDraught.DefaultEnglishDraught>
struct NetData_1_t591560719;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.DefaultEnglishDraughtIdentity
struct  DefaultEnglishDraughtIdentity_t1828943740  : public DataIdentity_t543951486
{
public:
	// System.Boolean EnglishDraught.DefaultEnglishDraughtIdentity::threeMoveRandom
	bool ___threeMoveRandom_17;
	// System.Int32 EnglishDraught.DefaultEnglishDraughtIdentity::maxPly
	int32_t ___maxPly_18;
	// NetData`1<EnglishDraught.DefaultEnglishDraught> EnglishDraught.DefaultEnglishDraughtIdentity::netData
	NetData_1_t591560719 * ___netData_19;

public:
	inline static int32_t get_offset_of_threeMoveRandom_17() { return static_cast<int32_t>(offsetof(DefaultEnglishDraughtIdentity_t1828943740, ___threeMoveRandom_17)); }
	inline bool get_threeMoveRandom_17() const { return ___threeMoveRandom_17; }
	inline bool* get_address_of_threeMoveRandom_17() { return &___threeMoveRandom_17; }
	inline void set_threeMoveRandom_17(bool value)
	{
		___threeMoveRandom_17 = value;
	}

	inline static int32_t get_offset_of_maxPly_18() { return static_cast<int32_t>(offsetof(DefaultEnglishDraughtIdentity_t1828943740, ___maxPly_18)); }
	inline int32_t get_maxPly_18() const { return ___maxPly_18; }
	inline int32_t* get_address_of_maxPly_18() { return &___maxPly_18; }
	inline void set_maxPly_18(int32_t value)
	{
		___maxPly_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(DefaultEnglishDraughtIdentity_t1828943740, ___netData_19)); }
	inline NetData_1_t591560719 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t591560719 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t591560719 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
