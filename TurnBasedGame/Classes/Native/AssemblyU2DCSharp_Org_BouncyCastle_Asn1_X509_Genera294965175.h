#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.Asn1Encodable
struct Asn1Encodable_t3447851422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.GeneralName
struct  GeneralName_t294965175  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Encodable Org.BouncyCastle.Asn1.X509.GeneralName::obj
	Asn1Encodable_t3447851422 * ___obj_11;
	// System.Int32 Org.BouncyCastle.Asn1.X509.GeneralName::tag
	int32_t ___tag_12;

public:
	inline static int32_t get_offset_of_obj_11() { return static_cast<int32_t>(offsetof(GeneralName_t294965175, ___obj_11)); }
	inline Asn1Encodable_t3447851422 * get_obj_11() const { return ___obj_11; }
	inline Asn1Encodable_t3447851422 ** get_address_of_obj_11() { return &___obj_11; }
	inline void set_obj_11(Asn1Encodable_t3447851422 * value)
	{
		___obj_11 = value;
		Il2CppCodeGenWriteBarrier(&___obj_11, value);
	}

	inline static int32_t get_offset_of_tag_12() { return static_cast<int32_t>(offsetof(GeneralName_t294965175, ___tag_12)); }
	inline int32_t get_tag_12() const { return ___tag_12; }
	inline int32_t* get_address_of_tag_12() { return &___tag_12; }
	inline void set_tag_12(int32_t value)
	{
		___tag_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
