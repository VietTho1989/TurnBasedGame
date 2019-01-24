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
// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Macs.Gost28147Mac
struct  Gost28147Mac_t1934182742  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Macs.Gost28147Mac::bufOff
	int32_t ___bufOff_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.Gost28147Mac::buf
	ByteU5BU5D_t3397334013* ___buf_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.Gost28147Mac::mac
	ByteU5BU5D_t3397334013* ___mac_4;
	// System.Boolean Org.BouncyCastle.Crypto.Macs.Gost28147Mac::firstStep
	bool ___firstStep_5;
	// System.Int32[] Org.BouncyCastle.Crypto.Macs.Gost28147Mac::workingKey
	Int32U5BU5D_t3030399641* ___workingKey_6;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.Gost28147Mac::S
	ByteU5BU5D_t3397334013* ___S_7;

public:
	inline static int32_t get_offset_of_bufOff_2() { return static_cast<int32_t>(offsetof(Gost28147Mac_t1934182742, ___bufOff_2)); }
	inline int32_t get_bufOff_2() const { return ___bufOff_2; }
	inline int32_t* get_address_of_bufOff_2() { return &___bufOff_2; }
	inline void set_bufOff_2(int32_t value)
	{
		___bufOff_2 = value;
	}

	inline static int32_t get_offset_of_buf_3() { return static_cast<int32_t>(offsetof(Gost28147Mac_t1934182742, ___buf_3)); }
	inline ByteU5BU5D_t3397334013* get_buf_3() const { return ___buf_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf_3() { return &___buf_3; }
	inline void set_buf_3(ByteU5BU5D_t3397334013* value)
	{
		___buf_3 = value;
		Il2CppCodeGenWriteBarrier(&___buf_3, value);
	}

	inline static int32_t get_offset_of_mac_4() { return static_cast<int32_t>(offsetof(Gost28147Mac_t1934182742, ___mac_4)); }
	inline ByteU5BU5D_t3397334013* get_mac_4() const { return ___mac_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_mac_4() { return &___mac_4; }
	inline void set_mac_4(ByteU5BU5D_t3397334013* value)
	{
		___mac_4 = value;
		Il2CppCodeGenWriteBarrier(&___mac_4, value);
	}

	inline static int32_t get_offset_of_firstStep_5() { return static_cast<int32_t>(offsetof(Gost28147Mac_t1934182742, ___firstStep_5)); }
	inline bool get_firstStep_5() const { return ___firstStep_5; }
	inline bool* get_address_of_firstStep_5() { return &___firstStep_5; }
	inline void set_firstStep_5(bool value)
	{
		___firstStep_5 = value;
	}

	inline static int32_t get_offset_of_workingKey_6() { return static_cast<int32_t>(offsetof(Gost28147Mac_t1934182742, ___workingKey_6)); }
	inline Int32U5BU5D_t3030399641* get_workingKey_6() const { return ___workingKey_6; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey_6() { return &___workingKey_6; }
	inline void set_workingKey_6(Int32U5BU5D_t3030399641* value)
	{
		___workingKey_6 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_6, value);
	}

	inline static int32_t get_offset_of_S_7() { return static_cast<int32_t>(offsetof(Gost28147Mac_t1934182742, ___S_7)); }
	inline ByteU5BU5D_t3397334013* get_S_7() const { return ___S_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_7() { return &___S_7; }
	inline void set_S_7(ByteU5BU5D_t3397334013* value)
	{
		___S_7 = value;
		Il2CppCodeGenWriteBarrier(&___S_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
