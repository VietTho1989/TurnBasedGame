#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Utilities_IO_Ba1872372563.h"

// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.IO.TeeInputStream
struct  TeeInputStream_t2454987356  : public BaseInputStream_t1872372563
{
public:
	// System.IO.Stream Org.BouncyCastle.Utilities.IO.TeeInputStream::input
	Stream_t3255436806 * ___input_3;
	// System.IO.Stream Org.BouncyCastle.Utilities.IO.TeeInputStream::tee
	Stream_t3255436806 * ___tee_4;

public:
	inline static int32_t get_offset_of_input_3() { return static_cast<int32_t>(offsetof(TeeInputStream_t2454987356, ___input_3)); }
	inline Stream_t3255436806 * get_input_3() const { return ___input_3; }
	inline Stream_t3255436806 ** get_address_of_input_3() { return &___input_3; }
	inline void set_input_3(Stream_t3255436806 * value)
	{
		___input_3 = value;
		Il2CppCodeGenWriteBarrier(&___input_3, value);
	}

	inline static int32_t get_offset_of_tee_4() { return static_cast<int32_t>(offsetof(TeeInputStream_t2454987356, ___tee_4)); }
	inline Stream_t3255436806 * get_tee_4() const { return ___tee_4; }
	inline Stream_t3255436806 ** get_address_of_tee_4() { return &___tee_4; }
	inline void set_tee_4(Stream_t3255436806 * value)
	{
		___tee_4 = value;
		Il2CppCodeGenWriteBarrier(&___tee_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
