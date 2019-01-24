#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Account39681427.h"

// VP`1<System.String>
struct VP_1_t2407497239;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountAdmin
struct  AccountAdmin_t3347688014  : public Account_t39681427
{
public:
	// VP`1<System.String> AccountAdmin::customName
	VP_1_t2407497239 * ___customName_7;
	// VP`1<System.String> AccountAdmin::avatarUrl
	VP_1_t2407497239 * ___avatarUrl_8;

public:
	inline static int32_t get_offset_of_customName_7() { return static_cast<int32_t>(offsetof(AccountAdmin_t3347688014, ___customName_7)); }
	inline VP_1_t2407497239 * get_customName_7() const { return ___customName_7; }
	inline VP_1_t2407497239 ** get_address_of_customName_7() { return &___customName_7; }
	inline void set_customName_7(VP_1_t2407497239 * value)
	{
		___customName_7 = value;
		Il2CppCodeGenWriteBarrier(&___customName_7, value);
	}

	inline static int32_t get_offset_of_avatarUrl_8() { return static_cast<int32_t>(offsetof(AccountAdmin_t3347688014, ___avatarUrl_8)); }
	inline VP_1_t2407497239 * get_avatarUrl_8() const { return ___avatarUrl_8; }
	inline VP_1_t2407497239 ** get_address_of_avatarUrl_8() { return &___avatarUrl_8; }
	inline void set_avatarUrl_8(VP_1_t2407497239 * value)
	{
		___avatarUrl_8 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrl_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
