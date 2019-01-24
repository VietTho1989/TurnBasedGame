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

// Org.BouncyCastle.Crypto.Engines.XteaEngine
struct  XteaEngine_t1315869442  : public Il2CppObject
{
public:
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.XteaEngine::_S
	UInt32U5BU5D_t59386216* ____S_3;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.XteaEngine::_sum0
	UInt32U5BU5D_t59386216* ____sum0_4;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.XteaEngine::_sum1
	UInt32U5BU5D_t59386216* ____sum1_5;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.XteaEngine::_initialised
	bool ____initialised_6;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.XteaEngine::_forEncryption
	bool ____forEncryption_7;

public:
	inline static int32_t get_offset_of__S_3() { return static_cast<int32_t>(offsetof(XteaEngine_t1315869442, ____S_3)); }
	inline UInt32U5BU5D_t59386216* get__S_3() const { return ____S_3; }
	inline UInt32U5BU5D_t59386216** get_address_of__S_3() { return &____S_3; }
	inline void set__S_3(UInt32U5BU5D_t59386216* value)
	{
		____S_3 = value;
		Il2CppCodeGenWriteBarrier(&____S_3, value);
	}

	inline static int32_t get_offset_of__sum0_4() { return static_cast<int32_t>(offsetof(XteaEngine_t1315869442, ____sum0_4)); }
	inline UInt32U5BU5D_t59386216* get__sum0_4() const { return ____sum0_4; }
	inline UInt32U5BU5D_t59386216** get_address_of__sum0_4() { return &____sum0_4; }
	inline void set__sum0_4(UInt32U5BU5D_t59386216* value)
	{
		____sum0_4 = value;
		Il2CppCodeGenWriteBarrier(&____sum0_4, value);
	}

	inline static int32_t get_offset_of__sum1_5() { return static_cast<int32_t>(offsetof(XteaEngine_t1315869442, ____sum1_5)); }
	inline UInt32U5BU5D_t59386216* get__sum1_5() const { return ____sum1_5; }
	inline UInt32U5BU5D_t59386216** get_address_of__sum1_5() { return &____sum1_5; }
	inline void set__sum1_5(UInt32U5BU5D_t59386216* value)
	{
		____sum1_5 = value;
		Il2CppCodeGenWriteBarrier(&____sum1_5, value);
	}

	inline static int32_t get_offset_of__initialised_6() { return static_cast<int32_t>(offsetof(XteaEngine_t1315869442, ____initialised_6)); }
	inline bool get__initialised_6() const { return ____initialised_6; }
	inline bool* get_address_of__initialised_6() { return &____initialised_6; }
	inline void set__initialised_6(bool value)
	{
		____initialised_6 = value;
	}

	inline static int32_t get_offset_of__forEncryption_7() { return static_cast<int32_t>(offsetof(XteaEngine_t1315869442, ____forEncryption_7)); }
	inline bool get__forEncryption_7() const { return ____forEncryption_7; }
	inline bool* get_address_of__forEncryption_7() { return &____forEncryption_7; }
	inline void set__forEncryption_7(bool value)
	{
		____forEncryption_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
