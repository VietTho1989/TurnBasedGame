#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;
// Org.BouncyCastle.Asn1.DerInteger
struct DerInteger_t967720487;
// Org.BouncyCastle.Asn1.Asn1Object
struct Asn1Object_t564283626;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerExternal
struct  DerExternal_t2315310584  : public Asn1Object_t564283626
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.DerExternal::directReference
	DerObjectIdentifier_t3495876513 * ___directReference_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.DerExternal::indirectReference
	DerInteger_t967720487 * ___indirectReference_3;
	// Org.BouncyCastle.Asn1.Asn1Object Org.BouncyCastle.Asn1.DerExternal::dataValueDescriptor
	Asn1Object_t564283626 * ___dataValueDescriptor_4;
	// System.Int32 Org.BouncyCastle.Asn1.DerExternal::encoding
	int32_t ___encoding_5;
	// Org.BouncyCastle.Asn1.Asn1Object Org.BouncyCastle.Asn1.DerExternal::externalContent
	Asn1Object_t564283626 * ___externalContent_6;

public:
	inline static int32_t get_offset_of_directReference_2() { return static_cast<int32_t>(offsetof(DerExternal_t2315310584, ___directReference_2)); }
	inline DerObjectIdentifier_t3495876513 * get_directReference_2() const { return ___directReference_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_directReference_2() { return &___directReference_2; }
	inline void set_directReference_2(DerObjectIdentifier_t3495876513 * value)
	{
		___directReference_2 = value;
		Il2CppCodeGenWriteBarrier(&___directReference_2, value);
	}

	inline static int32_t get_offset_of_indirectReference_3() { return static_cast<int32_t>(offsetof(DerExternal_t2315310584, ___indirectReference_3)); }
	inline DerInteger_t967720487 * get_indirectReference_3() const { return ___indirectReference_3; }
	inline DerInteger_t967720487 ** get_address_of_indirectReference_3() { return &___indirectReference_3; }
	inline void set_indirectReference_3(DerInteger_t967720487 * value)
	{
		___indirectReference_3 = value;
		Il2CppCodeGenWriteBarrier(&___indirectReference_3, value);
	}

	inline static int32_t get_offset_of_dataValueDescriptor_4() { return static_cast<int32_t>(offsetof(DerExternal_t2315310584, ___dataValueDescriptor_4)); }
	inline Asn1Object_t564283626 * get_dataValueDescriptor_4() const { return ___dataValueDescriptor_4; }
	inline Asn1Object_t564283626 ** get_address_of_dataValueDescriptor_4() { return &___dataValueDescriptor_4; }
	inline void set_dataValueDescriptor_4(Asn1Object_t564283626 * value)
	{
		___dataValueDescriptor_4 = value;
		Il2CppCodeGenWriteBarrier(&___dataValueDescriptor_4, value);
	}

	inline static int32_t get_offset_of_encoding_5() { return static_cast<int32_t>(offsetof(DerExternal_t2315310584, ___encoding_5)); }
	inline int32_t get_encoding_5() const { return ___encoding_5; }
	inline int32_t* get_address_of_encoding_5() { return &___encoding_5; }
	inline void set_encoding_5(int32_t value)
	{
		___encoding_5 = value;
	}

	inline static int32_t get_offset_of_externalContent_6() { return static_cast<int32_t>(offsetof(DerExternal_t2315310584, ___externalContent_6)); }
	inline Asn1Object_t564283626 * get_externalContent_6() const { return ___externalContent_6; }
	inline Asn1Object_t564283626 ** get_address_of_externalContent_6() { return &___externalContent_6; }
	inline void set_externalContent_6(Asn1Object_t564283626 * value)
	{
		___externalContent_6 = value;
		Il2CppCodeGenWriteBarrier(&___externalContent_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
