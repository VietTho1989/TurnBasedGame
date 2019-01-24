#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.IO.BaseInputStream
struct  BaseInputStream_t1872372563  : public Stream_t3255436806
{
public:
	// System.Boolean Org.BouncyCastle.Utilities.IO.BaseInputStream::closed
	bool ___closed_2;

public:
	inline static int32_t get_offset_of_closed_2() { return static_cast<int32_t>(offsetof(BaseInputStream_t1872372563, ___closed_2)); }
	inline bool get_closed_2() const { return ___closed_2; }
	inline bool* get_address_of_closed_2() { return &___closed_2; }
	inline void set_closed_2(bool value)
	{
		___closed_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
