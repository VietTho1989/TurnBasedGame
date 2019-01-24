#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.ServerName
struct  ServerName_t2635557658  : public Il2CppObject
{
public:
	// System.Byte Org.BouncyCastle.Crypto.Tls.ServerName::mNameType
	uint8_t ___mNameType_0;
	// System.Object Org.BouncyCastle.Crypto.Tls.ServerName::mName
	Il2CppObject * ___mName_1;

public:
	inline static int32_t get_offset_of_mNameType_0() { return static_cast<int32_t>(offsetof(ServerName_t2635557658, ___mNameType_0)); }
	inline uint8_t get_mNameType_0() const { return ___mNameType_0; }
	inline uint8_t* get_address_of_mNameType_0() { return &___mNameType_0; }
	inline void set_mNameType_0(uint8_t value)
	{
		___mNameType_0 = value;
	}

	inline static int32_t get_offset_of_mName_1() { return static_cast<int32_t>(offsetof(ServerName_t2635557658, ___mName_1)); }
	inline Il2CppObject * get_mName_1() const { return ___mName_1; }
	inline Il2CppObject ** get_address_of_mName_1() { return &___mName_1; }
	inline void set_mName_1(Il2CppObject * value)
	{
		___mName_1 = value;
		Il2CppCodeGenWriteBarrier(&___mName_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
