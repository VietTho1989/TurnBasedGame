#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameObserver_CheckChange811089867.h"

// Data
struct Data_t3569509720;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FollowParentObserver
struct  FollowParentObserver_t626599707  : public CheckChange_t811089867
{
public:
	// Data FollowParentObserver::data
	Data_t3569509720 * ___data_1;

public:
	inline static int32_t get_offset_of_data_1() { return static_cast<int32_t>(offsetof(FollowParentObserver_t626599707, ___data_1)); }
	inline Data_t3569509720 * get_data_1() const { return ___data_1; }
	inline Data_t3569509720 ** get_address_of_data_1() { return &___data_1; }
	inline void set_data_1(Data_t3569509720 * value)
	{
		___data_1 = value;
		Il2CppCodeGenWriteBarrier(&___data_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
