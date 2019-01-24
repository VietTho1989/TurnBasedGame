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
// System.String
struct String_t;
// System.Security.Cryptography.RSA
struct RSA_t3719518354;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.StrongNameKeyPair
struct  StrongNameKeyPair_t4090869089  : public Il2CppObject
{
public:
	// System.Byte[] System.Reflection.StrongNameKeyPair::_publicKey
	ByteU5BU5D_t3397334013* ____publicKey_0;
	// System.String System.Reflection.StrongNameKeyPair::_keyPairContainer
	String_t* ____keyPairContainer_1;
	// System.Boolean System.Reflection.StrongNameKeyPair::_keyPairExported
	bool ____keyPairExported_2;
	// System.Byte[] System.Reflection.StrongNameKeyPair::_keyPairArray
	ByteU5BU5D_t3397334013* ____keyPairArray_3;
	// System.Security.Cryptography.RSA System.Reflection.StrongNameKeyPair::_rsa
	RSA_t3719518354 * ____rsa_4;

public:
	inline static int32_t get_offset_of__publicKey_0() { return static_cast<int32_t>(offsetof(StrongNameKeyPair_t4090869089, ____publicKey_0)); }
	inline ByteU5BU5D_t3397334013* get__publicKey_0() const { return ____publicKey_0; }
	inline ByteU5BU5D_t3397334013** get_address_of__publicKey_0() { return &____publicKey_0; }
	inline void set__publicKey_0(ByteU5BU5D_t3397334013* value)
	{
		____publicKey_0 = value;
		Il2CppCodeGenWriteBarrier(&____publicKey_0, value);
	}

	inline static int32_t get_offset_of__keyPairContainer_1() { return static_cast<int32_t>(offsetof(StrongNameKeyPair_t4090869089, ____keyPairContainer_1)); }
	inline String_t* get__keyPairContainer_1() const { return ____keyPairContainer_1; }
	inline String_t** get_address_of__keyPairContainer_1() { return &____keyPairContainer_1; }
	inline void set__keyPairContainer_1(String_t* value)
	{
		____keyPairContainer_1 = value;
		Il2CppCodeGenWriteBarrier(&____keyPairContainer_1, value);
	}

	inline static int32_t get_offset_of__keyPairExported_2() { return static_cast<int32_t>(offsetof(StrongNameKeyPair_t4090869089, ____keyPairExported_2)); }
	inline bool get__keyPairExported_2() const { return ____keyPairExported_2; }
	inline bool* get_address_of__keyPairExported_2() { return &____keyPairExported_2; }
	inline void set__keyPairExported_2(bool value)
	{
		____keyPairExported_2 = value;
	}

	inline static int32_t get_offset_of__keyPairArray_3() { return static_cast<int32_t>(offsetof(StrongNameKeyPair_t4090869089, ____keyPairArray_3)); }
	inline ByteU5BU5D_t3397334013* get__keyPairArray_3() const { return ____keyPairArray_3; }
	inline ByteU5BU5D_t3397334013** get_address_of__keyPairArray_3() { return &____keyPairArray_3; }
	inline void set__keyPairArray_3(ByteU5BU5D_t3397334013* value)
	{
		____keyPairArray_3 = value;
		Il2CppCodeGenWriteBarrier(&____keyPairArray_3, value);
	}

	inline static int32_t get_offset_of__rsa_4() { return static_cast<int32_t>(offsetof(StrongNameKeyPair_t4090869089, ____rsa_4)); }
	inline RSA_t3719518354 * get__rsa_4() const { return ____rsa_4; }
	inline RSA_t3719518354 ** get_address_of__rsa_4() { return &____rsa_4; }
	inline void set__rsa_4(RSA_t3719518354 * value)
	{
		____rsa_4 = value;
		Il2CppCodeGenWriteBarrier(&____rsa_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
