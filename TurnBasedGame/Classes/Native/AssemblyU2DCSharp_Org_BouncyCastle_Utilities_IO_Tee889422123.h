#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Utilities_IO_Base91853118.h"

// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.IO.TeeOutputStream
struct  TeeOutputStream_t889422123  : public BaseOutputStream_t91853118
{
public:
	// System.IO.Stream Org.BouncyCastle.Utilities.IO.TeeOutputStream::output
	Stream_t3255436806 * ___output_3;
	// System.IO.Stream Org.BouncyCastle.Utilities.IO.TeeOutputStream::tee
	Stream_t3255436806 * ___tee_4;

public:
	inline static int32_t get_offset_of_output_3() { return static_cast<int32_t>(offsetof(TeeOutputStream_t889422123, ___output_3)); }
	inline Stream_t3255436806 * get_output_3() const { return ___output_3; }
	inline Stream_t3255436806 ** get_address_of_output_3() { return &___output_3; }
	inline void set_output_3(Stream_t3255436806 * value)
	{
		___output_3 = value;
		Il2CppCodeGenWriteBarrier(&___output_3, value);
	}

	inline static int32_t get_offset_of_tee_4() { return static_cast<int32_t>(offsetof(TeeOutputStream_t889422123, ___tee_4)); }
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
