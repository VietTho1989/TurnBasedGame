#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[0...,0...]
struct ByteU5BU2CU5D_t3397334014;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.TwofishEngine
struct  TwofishEngine_t3286458088  : public Il2CppObject
{
public:
	// System.Boolean Org.BouncyCastle.Crypto.Engines.TwofishEngine::encrypting
	bool ___encrypting_36;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.TwofishEngine::gMDS0
	Int32U5BU5D_t3030399641* ___gMDS0_37;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.TwofishEngine::gMDS1
	Int32U5BU5D_t3030399641* ___gMDS1_38;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.TwofishEngine::gMDS2
	Int32U5BU5D_t3030399641* ___gMDS2_39;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.TwofishEngine::gMDS3
	Int32U5BU5D_t3030399641* ___gMDS3_40;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.TwofishEngine::gSubKeys
	Int32U5BU5D_t3030399641* ___gSubKeys_41;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.TwofishEngine::gSBox
	Int32U5BU5D_t3030399641* ___gSBox_42;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.TwofishEngine::k64Cnt
	int32_t ___k64Cnt_43;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.TwofishEngine::workingKey
	ByteU5BU5D_t3397334013* ___workingKey_44;

public:
	inline static int32_t get_offset_of_encrypting_36() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___encrypting_36)); }
	inline bool get_encrypting_36() const { return ___encrypting_36; }
	inline bool* get_address_of_encrypting_36() { return &___encrypting_36; }
	inline void set_encrypting_36(bool value)
	{
		___encrypting_36 = value;
	}

	inline static int32_t get_offset_of_gMDS0_37() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___gMDS0_37)); }
	inline Int32U5BU5D_t3030399641* get_gMDS0_37() const { return ___gMDS0_37; }
	inline Int32U5BU5D_t3030399641** get_address_of_gMDS0_37() { return &___gMDS0_37; }
	inline void set_gMDS0_37(Int32U5BU5D_t3030399641* value)
	{
		___gMDS0_37 = value;
		Il2CppCodeGenWriteBarrier(&___gMDS0_37, value);
	}

	inline static int32_t get_offset_of_gMDS1_38() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___gMDS1_38)); }
	inline Int32U5BU5D_t3030399641* get_gMDS1_38() const { return ___gMDS1_38; }
	inline Int32U5BU5D_t3030399641** get_address_of_gMDS1_38() { return &___gMDS1_38; }
	inline void set_gMDS1_38(Int32U5BU5D_t3030399641* value)
	{
		___gMDS1_38 = value;
		Il2CppCodeGenWriteBarrier(&___gMDS1_38, value);
	}

	inline static int32_t get_offset_of_gMDS2_39() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___gMDS2_39)); }
	inline Int32U5BU5D_t3030399641* get_gMDS2_39() const { return ___gMDS2_39; }
	inline Int32U5BU5D_t3030399641** get_address_of_gMDS2_39() { return &___gMDS2_39; }
	inline void set_gMDS2_39(Int32U5BU5D_t3030399641* value)
	{
		___gMDS2_39 = value;
		Il2CppCodeGenWriteBarrier(&___gMDS2_39, value);
	}

	inline static int32_t get_offset_of_gMDS3_40() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___gMDS3_40)); }
	inline Int32U5BU5D_t3030399641* get_gMDS3_40() const { return ___gMDS3_40; }
	inline Int32U5BU5D_t3030399641** get_address_of_gMDS3_40() { return &___gMDS3_40; }
	inline void set_gMDS3_40(Int32U5BU5D_t3030399641* value)
	{
		___gMDS3_40 = value;
		Il2CppCodeGenWriteBarrier(&___gMDS3_40, value);
	}

	inline static int32_t get_offset_of_gSubKeys_41() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___gSubKeys_41)); }
	inline Int32U5BU5D_t3030399641* get_gSubKeys_41() const { return ___gSubKeys_41; }
	inline Int32U5BU5D_t3030399641** get_address_of_gSubKeys_41() { return &___gSubKeys_41; }
	inline void set_gSubKeys_41(Int32U5BU5D_t3030399641* value)
	{
		___gSubKeys_41 = value;
		Il2CppCodeGenWriteBarrier(&___gSubKeys_41, value);
	}

	inline static int32_t get_offset_of_gSBox_42() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___gSBox_42)); }
	inline Int32U5BU5D_t3030399641* get_gSBox_42() const { return ___gSBox_42; }
	inline Int32U5BU5D_t3030399641** get_address_of_gSBox_42() { return &___gSBox_42; }
	inline void set_gSBox_42(Int32U5BU5D_t3030399641* value)
	{
		___gSBox_42 = value;
		Il2CppCodeGenWriteBarrier(&___gSBox_42, value);
	}

	inline static int32_t get_offset_of_k64Cnt_43() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___k64Cnt_43)); }
	inline int32_t get_k64Cnt_43() const { return ___k64Cnt_43; }
	inline int32_t* get_address_of_k64Cnt_43() { return &___k64Cnt_43; }
	inline void set_k64Cnt_43(int32_t value)
	{
		___k64Cnt_43 = value;
	}

	inline static int32_t get_offset_of_workingKey_44() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088, ___workingKey_44)); }
	inline ByteU5BU5D_t3397334013* get_workingKey_44() const { return ___workingKey_44; }
	inline ByteU5BU5D_t3397334013** get_address_of_workingKey_44() { return &___workingKey_44; }
	inline void set_workingKey_44(ByteU5BU5D_t3397334013* value)
	{
		___workingKey_44 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_44, value);
	}
};

struct TwofishEngine_t3286458088_StaticFields
{
public:
	// System.Byte[0...,0...] Org.BouncyCastle.Crypto.Engines.TwofishEngine::P
	ByteU5BU2CU5D_t3397334014* ___P_0;

public:
	inline static int32_t get_offset_of_P_0() { return static_cast<int32_t>(offsetof(TwofishEngine_t3286458088_StaticFields, ___P_0)); }
	inline ByteU5BU2CU5D_t3397334014* get_P_0() const { return ___P_0; }
	inline ByteU5BU2CU5D_t3397334014** get_address_of_P_0() { return &___P_0; }
	inline void set_P_0(ByteU5BU2CU5D_t3397334014* value)
	{
		___P_0 = value;
		Il2CppCodeGenWriteBarrier(&___P_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
