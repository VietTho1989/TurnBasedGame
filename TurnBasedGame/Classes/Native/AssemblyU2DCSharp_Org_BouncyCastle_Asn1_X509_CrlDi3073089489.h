#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.Asn1Sequence
struct Asn1Sequence_t54253652;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.CrlDistPoint
struct  CrlDistPoint_t3073089489  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.X509.CrlDistPoint::seq
	Asn1Sequence_t54253652 * ___seq_2;

public:
	inline static int32_t get_offset_of_seq_2() { return static_cast<int32_t>(offsetof(CrlDistPoint_t3073089489, ___seq_2)); }
	inline Asn1Sequence_t54253652 * get_seq_2() const { return ___seq_2; }
	inline Asn1Sequence_t54253652 ** get_address_of_seq_2() { return &___seq_2; }
	inline void set_seq_2(Asn1Sequence_t54253652 * value)
	{
		___seq_2 = value;
		Il2CppCodeGenWriteBarrier(&___seq_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
