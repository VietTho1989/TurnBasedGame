#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.UInt32[]
struct UInt32U5BU5D_t59386216;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.HC256Engine
struct  HC256Engine_t1873260450  : public Il2CppObject
{
public:
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.HC256Engine::p
	UInt32U5BU5D_t59386216* ___p_0;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.HC256Engine::q
	UInt32U5BU5D_t59386216* ___q_1;
	// System.UInt32 Org.BouncyCastle.Crypto.Engines.HC256Engine::cnt
	uint32_t ___cnt_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.HC256Engine::key
	ByteU5BU5D_t3397334013* ___key_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.HC256Engine::iv
	ByteU5BU5D_t3397334013* ___iv_4;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.HC256Engine::initialised
	bool ___initialised_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.HC256Engine::buf
	ByteU5BU5D_t3397334013* ___buf_6;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.HC256Engine::idx
	int32_t ___idx_7;

public:
	inline static int32_t get_offset_of_p_0() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___p_0)); }
	inline UInt32U5BU5D_t59386216* get_p_0() const { return ___p_0; }
	inline UInt32U5BU5D_t59386216** get_address_of_p_0() { return &___p_0; }
	inline void set_p_0(UInt32U5BU5D_t59386216* value)
	{
		___p_0 = value;
		Il2CppCodeGenWriteBarrier(&___p_0, value);
	}

	inline static int32_t get_offset_of_q_1() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___q_1)); }
	inline UInt32U5BU5D_t59386216* get_q_1() const { return ___q_1; }
	inline UInt32U5BU5D_t59386216** get_address_of_q_1() { return &___q_1; }
	inline void set_q_1(UInt32U5BU5D_t59386216* value)
	{
		___q_1 = value;
		Il2CppCodeGenWriteBarrier(&___q_1, value);
	}

	inline static int32_t get_offset_of_cnt_2() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___cnt_2)); }
	inline uint32_t get_cnt_2() const { return ___cnt_2; }
	inline uint32_t* get_address_of_cnt_2() { return &___cnt_2; }
	inline void set_cnt_2(uint32_t value)
	{
		___cnt_2 = value;
	}

	inline static int32_t get_offset_of_key_3() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___key_3)); }
	inline ByteU5BU5D_t3397334013* get_key_3() const { return ___key_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_key_3() { return &___key_3; }
	inline void set_key_3(ByteU5BU5D_t3397334013* value)
	{
		___key_3 = value;
		Il2CppCodeGenWriteBarrier(&___key_3, value);
	}

	inline static int32_t get_offset_of_iv_4() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___iv_4)); }
	inline ByteU5BU5D_t3397334013* get_iv_4() const { return ___iv_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_iv_4() { return &___iv_4; }
	inline void set_iv_4(ByteU5BU5D_t3397334013* value)
	{
		___iv_4 = value;
		Il2CppCodeGenWriteBarrier(&___iv_4, value);
	}

	inline static int32_t get_offset_of_initialised_5() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___initialised_5)); }
	inline bool get_initialised_5() const { return ___initialised_5; }
	inline bool* get_address_of_initialised_5() { return &___initialised_5; }
	inline void set_initialised_5(bool value)
	{
		___initialised_5 = value;
	}

	inline static int32_t get_offset_of_buf_6() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___buf_6)); }
	inline ByteU5BU5D_t3397334013* get_buf_6() const { return ___buf_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf_6() { return &___buf_6; }
	inline void set_buf_6(ByteU5BU5D_t3397334013* value)
	{
		___buf_6 = value;
		Il2CppCodeGenWriteBarrier(&___buf_6, value);
	}

	inline static int32_t get_offset_of_idx_7() { return static_cast<int32_t>(offsetof(HC256Engine_t1873260450, ___idx_7)); }
	inline int32_t get_idx_7() const { return ___idx_7; }
	inline int32_t* get_address_of_idx_7() { return &___idx_7; }
	inline void set_idx_7(int32_t value)
	{
		___idx_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
