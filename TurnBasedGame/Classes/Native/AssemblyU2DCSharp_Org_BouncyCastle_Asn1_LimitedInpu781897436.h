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

// Org.BouncyCastle.Asn1.LimitedInputStream
struct  LimitedInputStream_t781897436  : public BaseInputStream_t1872372563
{
public:
	// System.IO.Stream Org.BouncyCastle.Asn1.LimitedInputStream::_in
	Stream_t3255436806 * ____in_3;
	// System.Int32 Org.BouncyCastle.Asn1.LimitedInputStream::_limit
	int32_t ____limit_4;

public:
	inline static int32_t get_offset_of__in_3() { return static_cast<int32_t>(offsetof(LimitedInputStream_t781897436, ____in_3)); }
	inline Stream_t3255436806 * get__in_3() const { return ____in_3; }
	inline Stream_t3255436806 ** get_address_of__in_3() { return &____in_3; }
	inline void set__in_3(Stream_t3255436806 * value)
	{
		____in_3 = value;
		Il2CppCodeGenWriteBarrier(&____in_3, value);
	}

	inline static int32_t get_offset_of__limit_4() { return static_cast<int32_t>(offsetof(LimitedInputStream_t781897436, ____limit_4)); }
	inline int32_t get__limit_4() const { return ____limit_4; }
	inline int32_t* get_address_of__limit_4() { return &____limit_4; }
	inline void set__limit_4(int32_t value)
	{
		____limit_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
