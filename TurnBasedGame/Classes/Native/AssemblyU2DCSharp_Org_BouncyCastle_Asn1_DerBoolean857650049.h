#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// Org.BouncyCastle.Asn1.DerBoolean
struct DerBoolean_t857650049;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerBoolean
struct  DerBoolean_t857650049  : public Asn1Object_t564283626
{
public:
	// System.Byte Org.BouncyCastle.Asn1.DerBoolean::value
	uint8_t ___value_2;

public:
	inline static int32_t get_offset_of_value_2() { return static_cast<int32_t>(offsetof(DerBoolean_t857650049, ___value_2)); }
	inline uint8_t get_value_2() const { return ___value_2; }
	inline uint8_t* get_address_of_value_2() { return &___value_2; }
	inline void set_value_2(uint8_t value)
	{
		___value_2 = value;
	}
};

struct DerBoolean_t857650049_StaticFields
{
public:
	// Org.BouncyCastle.Asn1.DerBoolean Org.BouncyCastle.Asn1.DerBoolean::False
	DerBoolean_t857650049 * ___False_3;
	// Org.BouncyCastle.Asn1.DerBoolean Org.BouncyCastle.Asn1.DerBoolean::True
	DerBoolean_t857650049 * ___True_4;

public:
	inline static int32_t get_offset_of_False_3() { return static_cast<int32_t>(offsetof(DerBoolean_t857650049_StaticFields, ___False_3)); }
	inline DerBoolean_t857650049 * get_False_3() const { return ___False_3; }
	inline DerBoolean_t857650049 ** get_address_of_False_3() { return &___False_3; }
	inline void set_False_3(DerBoolean_t857650049 * value)
	{
		___False_3 = value;
		Il2CppCodeGenWriteBarrier(&___False_3, value);
	}

	inline static int32_t get_offset_of_True_4() { return static_cast<int32_t>(offsetof(DerBoolean_t857650049_StaticFields, ___True_4)); }
	inline DerBoolean_t857650049 * get_True_4() const { return ___True_4; }
	inline DerBoolean_t857650049 ** get_address_of_True_4() { return &___True_4; }
	inline void set_True_4(DerBoolean_t857650049 * value)
	{
		___True_4 = value;
		Il2CppCodeGenWriteBarrier(&___True_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
