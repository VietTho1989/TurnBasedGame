#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Tasks_Response3308644429.h"

// Foundation.Example.ServerTests/DemoObject[]
struct DemoObjectU5BU5D_t3348656117;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.Response`1<Foundation.Example.ServerTests/DemoObject[]>
struct  Response_1_t1750402518  : public Response_t3308644429
{
public:
	// T Foundation.Tasks.Response`1::Result
	DemoObjectU5BU5D_t3348656117* ___Result_2;

public:
	inline static int32_t get_offset_of_Result_2() { return static_cast<int32_t>(offsetof(Response_1_t1750402518, ___Result_2)); }
	inline DemoObjectU5BU5D_t3348656117* get_Result_2() const { return ___Result_2; }
	inline DemoObjectU5BU5D_t3348656117** get_address_of_Result_2() { return &___Result_2; }
	inline void set_Result_2(DemoObjectU5BU5D_t3348656117* value)
	{
		___Result_2 = value;
		Il2CppCodeGenWriteBarrier(&___Result_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
