#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.RxCompiler
struct  RxCompiler_t4215271879  : public Il2CppObject
{
public:
	// System.Byte[] System.Text.RegularExpressions.RxCompiler::program
	ByteU5BU5D_t3397334013* ___program_0;
	// System.Int32 System.Text.RegularExpressions.RxCompiler::curpos
	int32_t ___curpos_1;

public:
	inline static int32_t get_offset_of_program_0() { return static_cast<int32_t>(offsetof(RxCompiler_t4215271879, ___program_0)); }
	inline ByteU5BU5D_t3397334013* get_program_0() const { return ___program_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_program_0() { return &___program_0; }
	inline void set_program_0(ByteU5BU5D_t3397334013* value)
	{
		___program_0 = value;
		Il2CppCodeGenWriteBarrier(&___program_0, value);
	}

	inline static int32_t get_offset_of_curpos_1() { return static_cast<int32_t>(offsetof(RxCompiler_t4215271879, ___curpos_1)); }
	inline int32_t get_curpos_1() const { return ___curpos_1; }
	inline int32_t* get_address_of_curpos_1() { return &___curpos_1; }
	inline void set_curpos_1(int32_t value)
	{
		___curpos_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
