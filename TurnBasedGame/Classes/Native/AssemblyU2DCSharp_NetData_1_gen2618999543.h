#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Xiangqi.XiangqiMove
struct XiangqiMove_t2372651018;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// NetData`1<Xiangqi.XiangqiMove>
struct  NetData_1_t2618999543  : public Il2CppObject
{
public:
	// T NetData`1::clientData
	XiangqiMove_t2372651018 * ___clientData_0;
	// T NetData`1::serverData
	XiangqiMove_t2372651018 * ___serverData_1;

public:
	inline static int32_t get_offset_of_clientData_0() { return static_cast<int32_t>(offsetof(NetData_1_t2618999543, ___clientData_0)); }
	inline XiangqiMove_t2372651018 * get_clientData_0() const { return ___clientData_0; }
	inline XiangqiMove_t2372651018 ** get_address_of_clientData_0() { return &___clientData_0; }
	inline void set_clientData_0(XiangqiMove_t2372651018 * value)
	{
		___clientData_0 = value;
		Il2CppCodeGenWriteBarrier(&___clientData_0, value);
	}

	inline static int32_t get_offset_of_serverData_1() { return static_cast<int32_t>(offsetof(NetData_1_t2618999543, ___serverData_1)); }
	inline XiangqiMove_t2372651018 * get_serverData_1() const { return ___serverData_1; }
	inline XiangqiMove_t2372651018 ** get_address_of_serverData_1() { return &___serverData_1; }
	inline void set_serverData_1(XiangqiMove_t2372651018 * value)
	{
		___serverData_1 = value;
		Il2CppCodeGenWriteBarrier(&___serverData_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
