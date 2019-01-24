#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerApplicationSpecific
struct  DerApplicationSpecific_t2286556739  : public Asn1Object_t564283626
{
public:
	// System.Boolean Org.BouncyCastle.Asn1.DerApplicationSpecific::isConstructed
	bool ___isConstructed_2;
	// System.Int32 Org.BouncyCastle.Asn1.DerApplicationSpecific::tag
	int32_t ___tag_3;
	// System.Byte[] Org.BouncyCastle.Asn1.DerApplicationSpecific::octets
	ByteU5BU5D_t3397334013* ___octets_4;

public:
	inline static int32_t get_offset_of_isConstructed_2() { return static_cast<int32_t>(offsetof(DerApplicationSpecific_t2286556739, ___isConstructed_2)); }
	inline bool get_isConstructed_2() const { return ___isConstructed_2; }
	inline bool* get_address_of_isConstructed_2() { return &___isConstructed_2; }
	inline void set_isConstructed_2(bool value)
	{
		___isConstructed_2 = value;
	}

	inline static int32_t get_offset_of_tag_3() { return static_cast<int32_t>(offsetof(DerApplicationSpecific_t2286556739, ___tag_3)); }
	inline int32_t get_tag_3() const { return ___tag_3; }
	inline int32_t* get_address_of_tag_3() { return &___tag_3; }
	inline void set_tag_3(int32_t value)
	{
		___tag_3 = value;
	}

	inline static int32_t get_offset_of_octets_4() { return static_cast<int32_t>(offsetof(DerApplicationSpecific_t2286556739, ___octets_4)); }
	inline ByteU5BU5D_t3397334013* get_octets_4() const { return ___octets_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_octets_4() { return &___octets_4; }
	inline void set_octets_4(ByteU5BU5D_t3397334013* value)
	{
		___octets_4 = value;
		Il2CppCodeGenWriteBarrier(&___octets_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
