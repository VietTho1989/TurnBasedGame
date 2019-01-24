#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// System.Collections.IList
struct IList_t3321498491;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Asn1Sequence
struct  Asn1Sequence_t54253652  : public Asn1Object_t564283626
{
public:
	// System.Collections.IList Org.BouncyCastle.Asn1.Asn1Sequence::seq
	Il2CppObject * ___seq_2;

public:
	inline static int32_t get_offset_of_seq_2() { return static_cast<int32_t>(offsetof(Asn1Sequence_t54253652, ___seq_2)); }
	inline Il2CppObject * get_seq_2() const { return ___seq_2; }
	inline Il2CppObject ** get_address_of_seq_2() { return &___seq_2; }
	inline void set_seq_2(Il2CppObject * value)
	{
		___seq_2 = value;
		Il2CppCodeGenWriteBarrier(&___seq_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
