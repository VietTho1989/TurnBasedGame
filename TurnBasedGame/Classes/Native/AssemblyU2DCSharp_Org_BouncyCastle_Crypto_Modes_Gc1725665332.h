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
// System.UInt32[][][]
struct UInt32U5BU5DU5BU5DU5BU5D_t4209500164;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.Gcm.Tables8kGcmMultiplier
struct  Tables8kGcmMultiplier_t1725665332  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.Gcm.Tables8kGcmMultiplier::H
	ByteU5BU5D_t3397334013* ___H_0;
	// System.UInt32[][][] Org.BouncyCastle.Crypto.Modes.Gcm.Tables8kGcmMultiplier::M
	UInt32U5BU5DU5BU5DU5BU5D_t4209500164* ___M_1;

public:
	inline static int32_t get_offset_of_H_0() { return static_cast<int32_t>(offsetof(Tables8kGcmMultiplier_t1725665332, ___H_0)); }
	inline ByteU5BU5D_t3397334013* get_H_0() const { return ___H_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_H_0() { return &___H_0; }
	inline void set_H_0(ByteU5BU5D_t3397334013* value)
	{
		___H_0 = value;
		Il2CppCodeGenWriteBarrier(&___H_0, value);
	}

	inline static int32_t get_offset_of_M_1() { return static_cast<int32_t>(offsetof(Tables8kGcmMultiplier_t1725665332, ___M_1)); }
	inline UInt32U5BU5DU5BU5DU5BU5D_t4209500164* get_M_1() const { return ___M_1; }
	inline UInt32U5BU5DU5BU5DU5BU5D_t4209500164** get_address_of_M_1() { return &___M_1; }
	inline void set_M_1(UInt32U5BU5DU5BU5DU5BU5D_t4209500164* value)
	{
		___M_1 = value;
		Il2CppCodeGenWriteBarrier(&___M_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
