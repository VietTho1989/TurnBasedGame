#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<Guild>
struct LP_1_t4235840665;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GuildWorld
struct  GuildWorld_t1401615751  : public Data_t3569509720
{
public:
	// LP`1<Guild> GuildWorld::guilds
	LP_1_t4235840665 * ___guilds_5;

public:
	inline static int32_t get_offset_of_guilds_5() { return static_cast<int32_t>(offsetof(GuildWorld_t1401615751, ___guilds_5)); }
	inline LP_1_t4235840665 * get_guilds_5() const { return ___guilds_5; }
	inline LP_1_t4235840665 ** get_address_of_guilds_5() { return &___guilds_5; }
	inline void set_guilds_5(LP_1_t4235840665 * value)
	{
		___guilds_5 = value;
		Il2CppCodeGenWriteBarrier(&___guilds_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
