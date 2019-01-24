#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_LimitedInpu781897436.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.IndefiniteLengthInputStream
struct  IndefiniteLengthInputStream_t1999368943  : public LimitedInputStream_t781897436
{
public:
	// System.Int32 Org.BouncyCastle.Asn1.IndefiniteLengthInputStream::_lookAhead
	int32_t ____lookAhead_5;
	// System.Boolean Org.BouncyCastle.Asn1.IndefiniteLengthInputStream::_eofOn00
	bool ____eofOn00_6;

public:
	inline static int32_t get_offset_of__lookAhead_5() { return static_cast<int32_t>(offsetof(IndefiniteLengthInputStream_t1999368943, ____lookAhead_5)); }
	inline int32_t get__lookAhead_5() const { return ____lookAhead_5; }
	inline int32_t* get_address_of__lookAhead_5() { return &____lookAhead_5; }
	inline void set__lookAhead_5(int32_t value)
	{
		____lookAhead_5 = value;
	}

	inline static int32_t get_offset_of__eofOn00_6() { return static_cast<int32_t>(offsetof(IndefiniteLengthInputStream_t1999368943, ____eofOn00_6)); }
	inline bool get__eofOn00_6() const { return ____eofOn00_6; }
	inline bool* get_address_of__eofOn00_6() { return &____eofOn00_6; }
	inline void set__eofOn00_6(bool value)
	{
		____eofOn00_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
