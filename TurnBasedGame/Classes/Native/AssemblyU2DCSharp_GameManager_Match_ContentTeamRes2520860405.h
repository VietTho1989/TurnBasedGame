#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.ContentTeamResult>
struct NetData_1_t3926928812;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContentTeamResultIdentity
struct  ContentTeamResultIdentity_t2520860405  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.ContentTeamResultIdentity::isEnd
	bool ___isEnd_17;
	// NetData`1<GameManager.Match.ContentTeamResult> GameManager.Match.ContentTeamResultIdentity::netData
	NetData_1_t3926928812 * ___netData_18;

public:
	inline static int32_t get_offset_of_isEnd_17() { return static_cast<int32_t>(offsetof(ContentTeamResultIdentity_t2520860405, ___isEnd_17)); }
	inline bool get_isEnd_17() const { return ___isEnd_17; }
	inline bool* get_address_of_isEnd_17() { return &___isEnd_17; }
	inline void set_isEnd_17(bool value)
	{
		___isEnd_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(ContentTeamResultIdentity_t2520860405, ___netData_18)); }
	inline NetData_1_t3926928812 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3926928812 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3926928812 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
