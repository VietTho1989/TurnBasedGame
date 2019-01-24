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

// Org.BouncyCastle.Crypto.Tls.SupplementalDataEntry
struct  SupplementalDataEntry_t1084707380  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Tls.SupplementalDataEntry::mDataType
	int32_t ___mDataType_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.SupplementalDataEntry::mData
	ByteU5BU5D_t3397334013* ___mData_1;

public:
	inline static int32_t get_offset_of_mDataType_0() { return static_cast<int32_t>(offsetof(SupplementalDataEntry_t1084707380, ___mDataType_0)); }
	inline int32_t get_mDataType_0() const { return ___mDataType_0; }
	inline int32_t* get_address_of_mDataType_0() { return &___mDataType_0; }
	inline void set_mDataType_0(int32_t value)
	{
		___mDataType_0 = value;
	}

	inline static int32_t get_offset_of_mData_1() { return static_cast<int32_t>(offsetof(SupplementalDataEntry_t1084707380, ___mData_1)); }
	inline ByteU5BU5D_t3397334013* get_mData_1() const { return ___mData_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_mData_1() { return &___mData_1; }
	inline void set_mData_1(ByteU5BU5D_t3397334013* value)
	{
		___mData_1 = value;
		Il2CppCodeGenWriteBarrier(&___mData_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
