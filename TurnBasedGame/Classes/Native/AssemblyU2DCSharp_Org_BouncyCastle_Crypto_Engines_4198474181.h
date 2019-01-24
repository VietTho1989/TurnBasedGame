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

// Org.BouncyCastle.Crypto.Engines.NoekeonEngine
struct  NoekeonEngine_t4198474181  : public Il2CppObject
{
public:
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.NoekeonEngine::state
	UInt32U5BU5D_t59386216* ___state_3;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.NoekeonEngine::subKeys
	UInt32U5BU5D_t59386216* ___subKeys_4;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.NoekeonEngine::decryptKeys
	UInt32U5BU5D_t59386216* ___decryptKeys_5;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.NoekeonEngine::_initialised
	bool ____initialised_6;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.NoekeonEngine::_forEncryption
	bool ____forEncryption_7;

public:
	inline static int32_t get_offset_of_state_3() { return static_cast<int32_t>(offsetof(NoekeonEngine_t4198474181, ___state_3)); }
	inline UInt32U5BU5D_t59386216* get_state_3() const { return ___state_3; }
	inline UInt32U5BU5D_t59386216** get_address_of_state_3() { return &___state_3; }
	inline void set_state_3(UInt32U5BU5D_t59386216* value)
	{
		___state_3 = value;
		Il2CppCodeGenWriteBarrier(&___state_3, value);
	}

	inline static int32_t get_offset_of_subKeys_4() { return static_cast<int32_t>(offsetof(NoekeonEngine_t4198474181, ___subKeys_4)); }
	inline UInt32U5BU5D_t59386216* get_subKeys_4() const { return ___subKeys_4; }
	inline UInt32U5BU5D_t59386216** get_address_of_subKeys_4() { return &___subKeys_4; }
	inline void set_subKeys_4(UInt32U5BU5D_t59386216* value)
	{
		___subKeys_4 = value;
		Il2CppCodeGenWriteBarrier(&___subKeys_4, value);
	}

	inline static int32_t get_offset_of_decryptKeys_5() { return static_cast<int32_t>(offsetof(NoekeonEngine_t4198474181, ___decryptKeys_5)); }
	inline UInt32U5BU5D_t59386216* get_decryptKeys_5() const { return ___decryptKeys_5; }
	inline UInt32U5BU5D_t59386216** get_address_of_decryptKeys_5() { return &___decryptKeys_5; }
	inline void set_decryptKeys_5(UInt32U5BU5D_t59386216* value)
	{
		___decryptKeys_5 = value;
		Il2CppCodeGenWriteBarrier(&___decryptKeys_5, value);
	}

	inline static int32_t get_offset_of__initialised_6() { return static_cast<int32_t>(offsetof(NoekeonEngine_t4198474181, ____initialised_6)); }
	inline bool get__initialised_6() const { return ____initialised_6; }
	inline bool* get_address_of__initialised_6() { return &____initialised_6; }
	inline void set__initialised_6(bool value)
	{
		____initialised_6 = value;
	}

	inline static int32_t get_offset_of__forEncryption_7() { return static_cast<int32_t>(offsetof(NoekeonEngine_t4198474181, ____forEncryption_7)); }
	inline bool get__forEncryption_7() const { return ____forEncryption_7; }
	inline bool* get_address_of__forEncryption_7() { return &____forEncryption_7; }
	inline void set__forEncryption_7(bool value)
	{
		____forEncryption_7 = value;
	}
};

struct NoekeonEngine_t4198474181_StaticFields
{
public:
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.NoekeonEngine::nullVector
	UInt32U5BU5D_t59386216* ___nullVector_1;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.NoekeonEngine::roundConstants
	UInt32U5BU5D_t59386216* ___roundConstants_2;

public:
	inline static int32_t get_offset_of_nullVector_1() { return static_cast<int32_t>(offsetof(NoekeonEngine_t4198474181_StaticFields, ___nullVector_1)); }
	inline UInt32U5BU5D_t59386216* get_nullVector_1() const { return ___nullVector_1; }
	inline UInt32U5BU5D_t59386216** get_address_of_nullVector_1() { return &___nullVector_1; }
	inline void set_nullVector_1(UInt32U5BU5D_t59386216* value)
	{
		___nullVector_1 = value;
		Il2CppCodeGenWriteBarrier(&___nullVector_1, value);
	}

	inline static int32_t get_offset_of_roundConstants_2() { return static_cast<int32_t>(offsetof(NoekeonEngine_t4198474181_StaticFields, ___roundConstants_2)); }
	inline UInt32U5BU5D_t59386216* get_roundConstants_2() const { return ___roundConstants_2; }
	inline UInt32U5BU5D_t59386216** get_address_of_roundConstants_2() { return &___roundConstants_2; }
	inline void set_roundConstants_2(UInt32U5BU5D_t59386216* value)
	{
		___roundConstants_2 = value;
		Il2CppCodeGenWriteBarrier(&___roundConstants_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
