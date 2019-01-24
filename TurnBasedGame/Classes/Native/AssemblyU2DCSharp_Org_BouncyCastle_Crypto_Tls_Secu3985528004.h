#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.SecurityParameters
struct  SecurityParameters_t3985528004  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Tls.SecurityParameters::entity
	int32_t ___entity_0;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.SecurityParameters::cipherSuite
	int32_t ___cipherSuite_1;
	// System.Byte Org.BouncyCastle.Crypto.Tls.SecurityParameters::compressionAlgorithm
	uint8_t ___compressionAlgorithm_2;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.SecurityParameters::prfAlgorithm
	int32_t ___prfAlgorithm_3;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.SecurityParameters::verifyDataLength
	int32_t ___verifyDataLength_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SecurityParameters::masterSecret
	ByteU5BU5D_t3397334013* ___masterSecret_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SecurityParameters::clientRandom
	ByteU5BU5D_t3397334013* ___clientRandom_6;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SecurityParameters::serverRandom
	ByteU5BU5D_t3397334013* ___serverRandom_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SecurityParameters::sessionHash
	ByteU5BU5D_t3397334013* ___sessionHash_8;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SecurityParameters::pskIdentity
	ByteU5BU5D_t3397334013* ___pskIdentity_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SecurityParameters::srpIdentity
	ByteU5BU5D_t3397334013* ___srpIdentity_10;
	// System.Int16 Org.BouncyCastle.Crypto.Tls.SecurityParameters::maxFragmentLength
	int16_t ___maxFragmentLength_11;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.SecurityParameters::truncatedHMac
	bool ___truncatedHMac_12;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.SecurityParameters::encryptThenMac
	bool ___encryptThenMac_13;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.SecurityParameters::extendedMasterSecret
	bool ___extendedMasterSecret_14;

public:
	inline static int32_t get_offset_of_entity_0() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___entity_0)); }
	inline int32_t get_entity_0() const { return ___entity_0; }
	inline int32_t* get_address_of_entity_0() { return &___entity_0; }
	inline void set_entity_0(int32_t value)
	{
		___entity_0 = value;
	}

	inline static int32_t get_offset_of_cipherSuite_1() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___cipherSuite_1)); }
	inline int32_t get_cipherSuite_1() const { return ___cipherSuite_1; }
	inline int32_t* get_address_of_cipherSuite_1() { return &___cipherSuite_1; }
	inline void set_cipherSuite_1(int32_t value)
	{
		___cipherSuite_1 = value;
	}

	inline static int32_t get_offset_of_compressionAlgorithm_2() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___compressionAlgorithm_2)); }
	inline uint8_t get_compressionAlgorithm_2() const { return ___compressionAlgorithm_2; }
	inline uint8_t* get_address_of_compressionAlgorithm_2() { return &___compressionAlgorithm_2; }
	inline void set_compressionAlgorithm_2(uint8_t value)
	{
		___compressionAlgorithm_2 = value;
	}

	inline static int32_t get_offset_of_prfAlgorithm_3() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___prfAlgorithm_3)); }
	inline int32_t get_prfAlgorithm_3() const { return ___prfAlgorithm_3; }
	inline int32_t* get_address_of_prfAlgorithm_3() { return &___prfAlgorithm_3; }
	inline void set_prfAlgorithm_3(int32_t value)
	{
		___prfAlgorithm_3 = value;
	}

	inline static int32_t get_offset_of_verifyDataLength_4() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___verifyDataLength_4)); }
	inline int32_t get_verifyDataLength_4() const { return ___verifyDataLength_4; }
	inline int32_t* get_address_of_verifyDataLength_4() { return &___verifyDataLength_4; }
	inline void set_verifyDataLength_4(int32_t value)
	{
		___verifyDataLength_4 = value;
	}

	inline static int32_t get_offset_of_masterSecret_5() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___masterSecret_5)); }
	inline ByteU5BU5D_t3397334013* get_masterSecret_5() const { return ___masterSecret_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_masterSecret_5() { return &___masterSecret_5; }
	inline void set_masterSecret_5(ByteU5BU5D_t3397334013* value)
	{
		___masterSecret_5 = value;
		Il2CppCodeGenWriteBarrier(&___masterSecret_5, value);
	}

	inline static int32_t get_offset_of_clientRandom_6() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___clientRandom_6)); }
	inline ByteU5BU5D_t3397334013* get_clientRandom_6() const { return ___clientRandom_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_clientRandom_6() { return &___clientRandom_6; }
	inline void set_clientRandom_6(ByteU5BU5D_t3397334013* value)
	{
		___clientRandom_6 = value;
		Il2CppCodeGenWriteBarrier(&___clientRandom_6, value);
	}

	inline static int32_t get_offset_of_serverRandom_7() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___serverRandom_7)); }
	inline ByteU5BU5D_t3397334013* get_serverRandom_7() const { return ___serverRandom_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_serverRandom_7() { return &___serverRandom_7; }
	inline void set_serverRandom_7(ByteU5BU5D_t3397334013* value)
	{
		___serverRandom_7 = value;
		Il2CppCodeGenWriteBarrier(&___serverRandom_7, value);
	}

	inline static int32_t get_offset_of_sessionHash_8() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___sessionHash_8)); }
	inline ByteU5BU5D_t3397334013* get_sessionHash_8() const { return ___sessionHash_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_sessionHash_8() { return &___sessionHash_8; }
	inline void set_sessionHash_8(ByteU5BU5D_t3397334013* value)
	{
		___sessionHash_8 = value;
		Il2CppCodeGenWriteBarrier(&___sessionHash_8, value);
	}

	inline static int32_t get_offset_of_pskIdentity_9() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___pskIdentity_9)); }
	inline ByteU5BU5D_t3397334013* get_pskIdentity_9() const { return ___pskIdentity_9; }
	inline ByteU5BU5D_t3397334013** get_address_of_pskIdentity_9() { return &___pskIdentity_9; }
	inline void set_pskIdentity_9(ByteU5BU5D_t3397334013* value)
	{
		___pskIdentity_9 = value;
		Il2CppCodeGenWriteBarrier(&___pskIdentity_9, value);
	}

	inline static int32_t get_offset_of_srpIdentity_10() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___srpIdentity_10)); }
	inline ByteU5BU5D_t3397334013* get_srpIdentity_10() const { return ___srpIdentity_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_srpIdentity_10() { return &___srpIdentity_10; }
	inline void set_srpIdentity_10(ByteU5BU5D_t3397334013* value)
	{
		___srpIdentity_10 = value;
		Il2CppCodeGenWriteBarrier(&___srpIdentity_10, value);
	}

	inline static int32_t get_offset_of_maxFragmentLength_11() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___maxFragmentLength_11)); }
	inline int16_t get_maxFragmentLength_11() const { return ___maxFragmentLength_11; }
	inline int16_t* get_address_of_maxFragmentLength_11() { return &___maxFragmentLength_11; }
	inline void set_maxFragmentLength_11(int16_t value)
	{
		___maxFragmentLength_11 = value;
	}

	inline static int32_t get_offset_of_truncatedHMac_12() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___truncatedHMac_12)); }
	inline bool get_truncatedHMac_12() const { return ___truncatedHMac_12; }
	inline bool* get_address_of_truncatedHMac_12() { return &___truncatedHMac_12; }
	inline void set_truncatedHMac_12(bool value)
	{
		___truncatedHMac_12 = value;
	}

	inline static int32_t get_offset_of_encryptThenMac_13() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___encryptThenMac_13)); }
	inline bool get_encryptThenMac_13() const { return ___encryptThenMac_13; }
	inline bool* get_address_of_encryptThenMac_13() { return &___encryptThenMac_13; }
	inline void set_encryptThenMac_13(bool value)
	{
		___encryptThenMac_13 = value;
	}

	inline static int32_t get_offset_of_extendedMasterSecret_14() { return static_cast<int32_t>(offsetof(SecurityParameters_t3985528004, ___extendedMasterSecret_14)); }
	inline bool get_extendedMasterSecret_14() const { return ___extendedMasterSecret_14; }
	inline bool* get_address_of_extendedMasterSecret_14() { return &___extendedMasterSecret_14; }
	inline void set_extendedMasterSecret_14(bool value)
	{
		___extendedMasterSecret_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
