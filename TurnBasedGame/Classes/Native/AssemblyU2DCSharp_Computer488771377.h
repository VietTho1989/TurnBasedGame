#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GamePlayer_Inform4009662409.h"

// VP`1<System.String>
struct VP_1_t2407497239;
// VP`1<Computer/AI>
struct VP_1_t3781544230;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Computer
struct  Computer_t488771377  : public Inform_t4009662409
{
public:
	// VP`1<System.String> Computer::name
	VP_1_t2407497239 * ___name_5;
	// VP`1<System.String> Computer::avatarUrl
	VP_1_t2407497239 * ___avatarUrl_6;
	// VP`1<Computer/AI> Computer::ai
	VP_1_t3781544230 * ___ai_7;

public:
	inline static int32_t get_offset_of_name_5() { return static_cast<int32_t>(offsetof(Computer_t488771377, ___name_5)); }
	inline VP_1_t2407497239 * get_name_5() const { return ___name_5; }
	inline VP_1_t2407497239 ** get_address_of_name_5() { return &___name_5; }
	inline void set_name_5(VP_1_t2407497239 * value)
	{
		___name_5 = value;
		Il2CppCodeGenWriteBarrier(&___name_5, value);
	}

	inline static int32_t get_offset_of_avatarUrl_6() { return static_cast<int32_t>(offsetof(Computer_t488771377, ___avatarUrl_6)); }
	inline VP_1_t2407497239 * get_avatarUrl_6() const { return ___avatarUrl_6; }
	inline VP_1_t2407497239 ** get_address_of_avatarUrl_6() { return &___avatarUrl_6; }
	inline void set_avatarUrl_6(VP_1_t2407497239 * value)
	{
		___avatarUrl_6 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrl_6, value);
	}

	inline static int32_t get_offset_of_ai_7() { return static_cast<int32_t>(offsetof(Computer_t488771377, ___ai_7)); }
	inline VP_1_t3781544230 * get_ai_7() const { return ___ai_7; }
	inline VP_1_t3781544230 ** get_address_of_ai_7() { return &___ai_7; }
	inline void set_ai_7(VP_1_t3781544230 * value)
	{
		___ai_7 = value;
		Il2CppCodeGenWriteBarrier(&___ai_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
