#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Abc.ZTauElement
struct  ZTauElement_t2571810054  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Abc.ZTauElement::u
	BigInteger_t4268922522 * ___u_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Abc.ZTauElement::v
	BigInteger_t4268922522 * ___v_1;

public:
	inline static int32_t get_offset_of_u_0() { return static_cast<int32_t>(offsetof(ZTauElement_t2571810054, ___u_0)); }
	inline BigInteger_t4268922522 * get_u_0() const { return ___u_0; }
	inline BigInteger_t4268922522 ** get_address_of_u_0() { return &___u_0; }
	inline void set_u_0(BigInteger_t4268922522 * value)
	{
		___u_0 = value;
		Il2CppCodeGenWriteBarrier(&___u_0, value);
	}

	inline static int32_t get_offset_of_v_1() { return static_cast<int32_t>(offsetof(ZTauElement_t2571810054, ___v_1)); }
	inline BigInteger_t4268922522 * get_v_1() const { return ___v_1; }
	inline BigInteger_t4268922522 ** get_address_of_v_1() { return &___v_1; }
	inline void set_v_1(BigInteger_t4268922522 * value)
	{
		___v_1 = value;
		Il2CppCodeGenWriteBarrier(&___v_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
