#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// Org.BouncyCastle.Asn1.Asn1Encodable
struct Asn1Encodable_t3447851422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Asn1TaggedObject
struct  Asn1TaggedObject_t990853098  : public Asn1Object_t564283626
{
public:
	// System.Int32 Org.BouncyCastle.Asn1.Asn1TaggedObject::tagNo
	int32_t ___tagNo_2;
	// System.Boolean Org.BouncyCastle.Asn1.Asn1TaggedObject::explicitly
	bool ___explicitly_3;
	// Org.BouncyCastle.Asn1.Asn1Encodable Org.BouncyCastle.Asn1.Asn1TaggedObject::obj
	Asn1Encodable_t3447851422 * ___obj_4;

public:
	inline static int32_t get_offset_of_tagNo_2() { return static_cast<int32_t>(offsetof(Asn1TaggedObject_t990853098, ___tagNo_2)); }
	inline int32_t get_tagNo_2() const { return ___tagNo_2; }
	inline int32_t* get_address_of_tagNo_2() { return &___tagNo_2; }
	inline void set_tagNo_2(int32_t value)
	{
		___tagNo_2 = value;
	}

	inline static int32_t get_offset_of_explicitly_3() { return static_cast<int32_t>(offsetof(Asn1TaggedObject_t990853098, ___explicitly_3)); }
	inline bool get_explicitly_3() const { return ___explicitly_3; }
	inline bool* get_address_of_explicitly_3() { return &___explicitly_3; }
	inline void set_explicitly_3(bool value)
	{
		___explicitly_3 = value;
	}

	inline static int32_t get_offset_of_obj_4() { return static_cast<int32_t>(offsetof(Asn1TaggedObject_t990853098, ___obj_4)); }
	inline Asn1Encodable_t3447851422 * get_obj_4() const { return ___obj_4; }
	inline Asn1Encodable_t3447851422 ** get_address_of_obj_4() { return &___obj_4; }
	inline void set_obj_4(Asn1Encodable_t3447851422 * value)
	{
		___obj_4 = value;
		Il2CppCodeGenWriteBarrier(&___obj_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
