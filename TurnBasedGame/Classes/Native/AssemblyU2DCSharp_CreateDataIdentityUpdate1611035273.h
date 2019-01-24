#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3239946460.h"

// System.Collections.Generic.Dictionary`2<System.Type,DataIdentity>
struct Dictionary_2_t2481309383;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CreateDataIdentityUpdate
struct  CreateDataIdentityUpdate_t1611035273  : public UpdateBehavior_1_t3239946460
{
public:
	// System.Collections.Generic.Dictionary`2<System.Type,DataIdentity> CreateDataIdentityUpdate::prefabDict
	Dictionary_2_t2481309383 * ___prefabDict_4;

public:
	inline static int32_t get_offset_of_prefabDict_4() { return static_cast<int32_t>(offsetof(CreateDataIdentityUpdate_t1611035273, ___prefabDict_4)); }
	inline Dictionary_2_t2481309383 * get_prefabDict_4() const { return ___prefabDict_4; }
	inline Dictionary_2_t2481309383 ** get_address_of_prefabDict_4() { return &___prefabDict_4; }
	inline void set_prefabDict_4(Dictionary_2_t2481309383 * value)
	{
		___prefabDict_4 = value;
		Il2CppCodeGenWriteBarrier(&___prefabDict_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
