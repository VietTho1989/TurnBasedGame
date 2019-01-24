#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Engines_1307100856.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.DesEdeEngine
struct  DesEdeEngine_t2644224304  : public DesEngine_t1307100856
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.DesEdeEngine::workingKey1
	Int32U5BU5D_t3030399641* ___workingKey1_15;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.DesEdeEngine::workingKey2
	Int32U5BU5D_t3030399641* ___workingKey2_16;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.DesEdeEngine::workingKey3
	Int32U5BU5D_t3030399641* ___workingKey3_17;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.DesEdeEngine::forEncryption
	bool ___forEncryption_18;

public:
	inline static int32_t get_offset_of_workingKey1_15() { return static_cast<int32_t>(offsetof(DesEdeEngine_t2644224304, ___workingKey1_15)); }
	inline Int32U5BU5D_t3030399641* get_workingKey1_15() const { return ___workingKey1_15; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey1_15() { return &___workingKey1_15; }
	inline void set_workingKey1_15(Int32U5BU5D_t3030399641* value)
	{
		___workingKey1_15 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey1_15, value);
	}

	inline static int32_t get_offset_of_workingKey2_16() { return static_cast<int32_t>(offsetof(DesEdeEngine_t2644224304, ___workingKey2_16)); }
	inline Int32U5BU5D_t3030399641* get_workingKey2_16() const { return ___workingKey2_16; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey2_16() { return &___workingKey2_16; }
	inline void set_workingKey2_16(Int32U5BU5D_t3030399641* value)
	{
		___workingKey2_16 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey2_16, value);
	}

	inline static int32_t get_offset_of_workingKey3_17() { return static_cast<int32_t>(offsetof(DesEdeEngine_t2644224304, ___workingKey3_17)); }
	inline Int32U5BU5D_t3030399641* get_workingKey3_17() const { return ___workingKey3_17; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey3_17() { return &___workingKey3_17; }
	inline void set_workingKey3_17(Int32U5BU5D_t3030399641* value)
	{
		___workingKey3_17 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey3_17, value);
	}

	inline static int32_t get_offset_of_forEncryption_18() { return static_cast<int32_t>(offsetof(DesEdeEngine_t2644224304, ___forEncryption_18)); }
	inline bool get_forEncryption_18() const { return ___forEncryption_18; }
	inline bool* get_address_of_forEncryption_18() { return &___forEncryption_18; }
	inline void set_forEncryption_18(bool value)
	{
		___forEncryption_18 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
