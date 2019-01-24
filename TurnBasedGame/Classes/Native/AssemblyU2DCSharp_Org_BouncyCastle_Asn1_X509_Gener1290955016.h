#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.X509.GeneralName[]
struct GeneralNameU5BU5D_t309690254;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.GeneralNames
struct  GeneralNames_t1290955016  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X509.GeneralName[] Org.BouncyCastle.Asn1.X509.GeneralNames::names
	GeneralNameU5BU5D_t309690254* ___names_2;

public:
	inline static int32_t get_offset_of_names_2() { return static_cast<int32_t>(offsetof(GeneralNames_t1290955016, ___names_2)); }
	inline GeneralNameU5BU5D_t309690254* get_names_2() const { return ___names_2; }
	inline GeneralNameU5BU5D_t309690254** get_address_of_names_2() { return &___names_2; }
	inline void set_names_2(GeneralNameU5BU5D_t309690254* value)
	{
		___names_2 = value;
		Il2CppCodeGenWriteBarrier(&___names_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
