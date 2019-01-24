#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// WrapChange
struct WrapChange_t3071999284;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.Change
struct  Change_t99406048  : public Il2CppObject
{
public:
	// System.Single Record.Change::t
	float ___t_0;
	// WrapChange Record.Change::change
	WrapChange_t3071999284 * ___change_1;

public:
	inline static int32_t get_offset_of_t_0() { return static_cast<int32_t>(offsetof(Change_t99406048, ___t_0)); }
	inline float get_t_0() const { return ___t_0; }
	inline float* get_address_of_t_0() { return &___t_0; }
	inline void set_t_0(float value)
	{
		___t_0 = value;
	}

	inline static int32_t get_offset_of_change_1() { return static_cast<int32_t>(offsetof(Change_t99406048, ___change_1)); }
	inline WrapChange_t3071999284 * get_change_1() const { return ___change_1; }
	inline WrapChange_t3071999284 ** get_address_of_change_1() { return &___change_1; }
	inline void set_change_1(WrapChange_t3071999284 * value)
	{
		___change_1 = value;
		Il2CppCodeGenWriteBarrier(&___change_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
