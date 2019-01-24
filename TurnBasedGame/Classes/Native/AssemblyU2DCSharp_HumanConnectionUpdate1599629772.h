#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen4148382972.h"

// Human
struct Human_t1156088493;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanConnectionUpdate
struct  HumanConnectionUpdate_t1599629772  : public UpdateBehavior_1_t4148382972
{
public:
	// Human HumanConnectionUpdate::serverHuman
	Human_t1156088493 * ___serverHuman_4;

public:
	inline static int32_t get_offset_of_serverHuman_4() { return static_cast<int32_t>(offsetof(HumanConnectionUpdate_t1599629772, ___serverHuman_4)); }
	inline Human_t1156088493 * get_serverHuman_4() const { return ___serverHuman_4; }
	inline Human_t1156088493 ** get_address_of_serverHuman_4() { return &___serverHuman_4; }
	inline void set_serverHuman_4(Human_t1156088493 * value)
	{
		___serverHuman_4 = value;
		Il2CppCodeGenWriteBarrier(&___serverHuman_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
