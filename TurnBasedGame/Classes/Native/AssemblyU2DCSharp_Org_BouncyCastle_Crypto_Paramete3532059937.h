#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Paramete3425534311.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters
struct  RsaPrivateCrtKeyParameters_t3532059937  : public RsaKeyParameters_t3425534311
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters::e
	BigInteger_t4268922522 * ___e_3;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters::p
	BigInteger_t4268922522 * ___p_4;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters::q
	BigInteger_t4268922522 * ___q_5;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters::dP
	BigInteger_t4268922522 * ___dP_6;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters::dQ
	BigInteger_t4268922522 * ___dQ_7;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters::qInv
	BigInteger_t4268922522 * ___qInv_8;

public:
	inline static int32_t get_offset_of_e_3() { return static_cast<int32_t>(offsetof(RsaPrivateCrtKeyParameters_t3532059937, ___e_3)); }
	inline BigInteger_t4268922522 * get_e_3() const { return ___e_3; }
	inline BigInteger_t4268922522 ** get_address_of_e_3() { return &___e_3; }
	inline void set_e_3(BigInteger_t4268922522 * value)
	{
		___e_3 = value;
		Il2CppCodeGenWriteBarrier(&___e_3, value);
	}

	inline static int32_t get_offset_of_p_4() { return static_cast<int32_t>(offsetof(RsaPrivateCrtKeyParameters_t3532059937, ___p_4)); }
	inline BigInteger_t4268922522 * get_p_4() const { return ___p_4; }
	inline BigInteger_t4268922522 ** get_address_of_p_4() { return &___p_4; }
	inline void set_p_4(BigInteger_t4268922522 * value)
	{
		___p_4 = value;
		Il2CppCodeGenWriteBarrier(&___p_4, value);
	}

	inline static int32_t get_offset_of_q_5() { return static_cast<int32_t>(offsetof(RsaPrivateCrtKeyParameters_t3532059937, ___q_5)); }
	inline BigInteger_t4268922522 * get_q_5() const { return ___q_5; }
	inline BigInteger_t4268922522 ** get_address_of_q_5() { return &___q_5; }
	inline void set_q_5(BigInteger_t4268922522 * value)
	{
		___q_5 = value;
		Il2CppCodeGenWriteBarrier(&___q_5, value);
	}

	inline static int32_t get_offset_of_dP_6() { return static_cast<int32_t>(offsetof(RsaPrivateCrtKeyParameters_t3532059937, ___dP_6)); }
	inline BigInteger_t4268922522 * get_dP_6() const { return ___dP_6; }
	inline BigInteger_t4268922522 ** get_address_of_dP_6() { return &___dP_6; }
	inline void set_dP_6(BigInteger_t4268922522 * value)
	{
		___dP_6 = value;
		Il2CppCodeGenWriteBarrier(&___dP_6, value);
	}

	inline static int32_t get_offset_of_dQ_7() { return static_cast<int32_t>(offsetof(RsaPrivateCrtKeyParameters_t3532059937, ___dQ_7)); }
	inline BigInteger_t4268922522 * get_dQ_7() const { return ___dQ_7; }
	inline BigInteger_t4268922522 ** get_address_of_dQ_7() { return &___dQ_7; }
	inline void set_dQ_7(BigInteger_t4268922522 * value)
	{
		___dQ_7 = value;
		Il2CppCodeGenWriteBarrier(&___dQ_7, value);
	}

	inline static int32_t get_offset_of_qInv_8() { return static_cast<int32_t>(offsetof(RsaPrivateCrtKeyParameters_t3532059937, ___qInv_8)); }
	inline BigInteger_t4268922522 * get_qInv_8() const { return ___qInv_8; }
	inline BigInteger_t4268922522 ** get_address_of_qInv_8() { return &___qInv_8; }
	inline void set_qInv_8(BigInteger_t4268922522 * value)
	{
		___qInv_8 = value;
		Il2CppCodeGenWriteBarrier(&___qInv_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
