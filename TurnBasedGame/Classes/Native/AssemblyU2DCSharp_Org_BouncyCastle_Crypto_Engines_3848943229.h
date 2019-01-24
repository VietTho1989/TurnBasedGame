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

// Org.BouncyCastle.Crypto.Engines.RC2Engine
struct  RC2Engine_t3848943229  : public Il2CppObject
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.RC2Engine::workingKey
	Int32U5BU5D_t3030399641* ___workingKey_2;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.RC2Engine::encrypting
	bool ___encrypting_3;

public:
	inline static int32_t get_offset_of_workingKey_2() { return static_cast<int32_t>(offsetof(RC2Engine_t3848943229, ___workingKey_2)); }
	inline Int32U5BU5D_t3030399641* get_workingKey_2() const { return ___workingKey_2; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey_2() { return &___workingKey_2; }
	inline void set_workingKey_2(Int32U5BU5D_t3030399641* value)
	{
		___workingKey_2 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_2, value);
	}

	inline static int32_t get_offset_of_encrypting_3() { return static_cast<int32_t>(offsetof(RC2Engine_t3848943229, ___encrypting_3)); }
	inline bool get_encrypting_3() const { return ___encrypting_3; }
	inline bool* get_address_of_encrypting_3() { return &___encrypting_3; }
	inline void set_encrypting_3(bool value)
	{
		___encrypting_3 = value;
	}
};

struct RC2Engine_t3848943229_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.RC2Engine::piTable
	ByteU5BU5D_t3397334013* ___piTable_0;

public:
	inline static int32_t get_offset_of_piTable_0() { return static_cast<int32_t>(offsetof(RC2Engine_t3848943229_StaticFields, ___piTable_0)); }
	inline ByteU5BU5D_t3397334013* get_piTable_0() const { return ___piTable_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_piTable_0() { return &___piTable_0; }
	inline void set_piTable_0(ByteU5BU5D_t3397334013* value)
	{
		___piTable_0 = value;
		Il2CppCodeGenWriteBarrier(&___piTable_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
