#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_DerGenerato951913470.h"

// System.IO.MemoryStream
struct MemoryStream_t743994179;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerSetGenerator
struct  DerSetGenerator_t2437150008  : public DerGenerator_t951913470
{
public:
	// System.IO.MemoryStream Org.BouncyCastle.Asn1.DerSetGenerator::_bOut
	MemoryStream_t743994179 * ____bOut_4;

public:
	inline static int32_t get_offset_of__bOut_4() { return static_cast<int32_t>(offsetof(DerSetGenerator_t2437150008, ____bOut_4)); }
	inline MemoryStream_t743994179 * get__bOut_4() const { return ____bOut_4; }
	inline MemoryStream_t743994179 ** get_address_of__bOut_4() { return &____bOut_4; }
	inline void set__bOut_4(MemoryStream_t743994179 * value)
	{
		____bOut_4 = value;
		Il2CppCodeGenWriteBarrier(&____bOut_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
