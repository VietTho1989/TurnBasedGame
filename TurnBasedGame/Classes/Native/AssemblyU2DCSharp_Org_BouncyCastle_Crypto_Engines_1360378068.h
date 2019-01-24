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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.CamelliaEngine
struct  CamelliaEngine_t1360378068  : public Il2CppObject
{
public:
	// System.Boolean Org.BouncyCastle.Crypto.Engines.CamelliaEngine::initialised
	bool ___initialised_0;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.CamelliaEngine::_keyIs128
	bool ____keyIs128_1;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::subkey
	UInt32U5BU5D_t59386216* ___subkey_3;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::kw
	UInt32U5BU5D_t59386216* ___kw_4;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::ke
	UInt32U5BU5D_t59386216* ___ke_5;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::state
	UInt32U5BU5D_t59386216* ___state_6;

public:
	inline static int32_t get_offset_of_initialised_0() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068, ___initialised_0)); }
	inline bool get_initialised_0() const { return ___initialised_0; }
	inline bool* get_address_of_initialised_0() { return &___initialised_0; }
	inline void set_initialised_0(bool value)
	{
		___initialised_0 = value;
	}

	inline static int32_t get_offset_of__keyIs128_1() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068, ____keyIs128_1)); }
	inline bool get__keyIs128_1() const { return ____keyIs128_1; }
	inline bool* get_address_of__keyIs128_1() { return &____keyIs128_1; }
	inline void set__keyIs128_1(bool value)
	{
		____keyIs128_1 = value;
	}

	inline static int32_t get_offset_of_subkey_3() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068, ___subkey_3)); }
	inline UInt32U5BU5D_t59386216* get_subkey_3() const { return ___subkey_3; }
	inline UInt32U5BU5D_t59386216** get_address_of_subkey_3() { return &___subkey_3; }
	inline void set_subkey_3(UInt32U5BU5D_t59386216* value)
	{
		___subkey_3 = value;
		Il2CppCodeGenWriteBarrier(&___subkey_3, value);
	}

	inline static int32_t get_offset_of_kw_4() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068, ___kw_4)); }
	inline UInt32U5BU5D_t59386216* get_kw_4() const { return ___kw_4; }
	inline UInt32U5BU5D_t59386216** get_address_of_kw_4() { return &___kw_4; }
	inline void set_kw_4(UInt32U5BU5D_t59386216* value)
	{
		___kw_4 = value;
		Il2CppCodeGenWriteBarrier(&___kw_4, value);
	}

	inline static int32_t get_offset_of_ke_5() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068, ___ke_5)); }
	inline UInt32U5BU5D_t59386216* get_ke_5() const { return ___ke_5; }
	inline UInt32U5BU5D_t59386216** get_address_of_ke_5() { return &___ke_5; }
	inline void set_ke_5(UInt32U5BU5D_t59386216* value)
	{
		___ke_5 = value;
		Il2CppCodeGenWriteBarrier(&___ke_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068, ___state_6)); }
	inline UInt32U5BU5D_t59386216* get_state_6() const { return ___state_6; }
	inline UInt32U5BU5D_t59386216** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(UInt32U5BU5D_t59386216* value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

struct CamelliaEngine_t1360378068_StaticFields
{
public:
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::SIGMA
	UInt32U5BU5D_t59386216* ___SIGMA_7;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::SBOX1_1110
	UInt32U5BU5D_t59386216* ___SBOX1_1110_8;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::SBOX4_4404
	UInt32U5BU5D_t59386216* ___SBOX4_4404_9;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::SBOX2_0222
	UInt32U5BU5D_t59386216* ___SBOX2_0222_10;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.CamelliaEngine::SBOX3_3033
	UInt32U5BU5D_t59386216* ___SBOX3_3033_11;

public:
	inline static int32_t get_offset_of_SIGMA_7() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068_StaticFields, ___SIGMA_7)); }
	inline UInt32U5BU5D_t59386216* get_SIGMA_7() const { return ___SIGMA_7; }
	inline UInt32U5BU5D_t59386216** get_address_of_SIGMA_7() { return &___SIGMA_7; }
	inline void set_SIGMA_7(UInt32U5BU5D_t59386216* value)
	{
		___SIGMA_7 = value;
		Il2CppCodeGenWriteBarrier(&___SIGMA_7, value);
	}

	inline static int32_t get_offset_of_SBOX1_1110_8() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068_StaticFields, ___SBOX1_1110_8)); }
	inline UInt32U5BU5D_t59386216* get_SBOX1_1110_8() const { return ___SBOX1_1110_8; }
	inline UInt32U5BU5D_t59386216** get_address_of_SBOX1_1110_8() { return &___SBOX1_1110_8; }
	inline void set_SBOX1_1110_8(UInt32U5BU5D_t59386216* value)
	{
		___SBOX1_1110_8 = value;
		Il2CppCodeGenWriteBarrier(&___SBOX1_1110_8, value);
	}

	inline static int32_t get_offset_of_SBOX4_4404_9() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068_StaticFields, ___SBOX4_4404_9)); }
	inline UInt32U5BU5D_t59386216* get_SBOX4_4404_9() const { return ___SBOX4_4404_9; }
	inline UInt32U5BU5D_t59386216** get_address_of_SBOX4_4404_9() { return &___SBOX4_4404_9; }
	inline void set_SBOX4_4404_9(UInt32U5BU5D_t59386216* value)
	{
		___SBOX4_4404_9 = value;
		Il2CppCodeGenWriteBarrier(&___SBOX4_4404_9, value);
	}

	inline static int32_t get_offset_of_SBOX2_0222_10() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068_StaticFields, ___SBOX2_0222_10)); }
	inline UInt32U5BU5D_t59386216* get_SBOX2_0222_10() const { return ___SBOX2_0222_10; }
	inline UInt32U5BU5D_t59386216** get_address_of_SBOX2_0222_10() { return &___SBOX2_0222_10; }
	inline void set_SBOX2_0222_10(UInt32U5BU5D_t59386216* value)
	{
		___SBOX2_0222_10 = value;
		Il2CppCodeGenWriteBarrier(&___SBOX2_0222_10, value);
	}

	inline static int32_t get_offset_of_SBOX3_3033_11() { return static_cast<int32_t>(offsetof(CamelliaEngine_t1360378068_StaticFields, ___SBOX3_3033_11)); }
	inline UInt32U5BU5D_t59386216* get_SBOX3_3033_11() const { return ___SBOX3_3033_11; }
	inline UInt32U5BU5D_t59386216** get_address_of_SBOX3_3033_11() { return &___SBOX3_3033_11; }
	inline void set_SBOX3_3033_11(UInt32U5BU5D_t59386216* value)
	{
		___SBOX3_3033_11 = value;
		Il2CppCodeGenWriteBarrier(&___SBOX3_3033_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
