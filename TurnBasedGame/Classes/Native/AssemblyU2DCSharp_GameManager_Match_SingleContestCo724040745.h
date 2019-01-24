#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2768831546.h"

// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.SingleContestContentCheckEndUpdate
struct  SingleContestContentCheckEndUpdate_t724040745  : public UpdateBehavior_1_t2768831546
{
public:
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.SingleContestContentCheckEndUpdate::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_4;

public:
	inline static int32_t get_offset_of_contestManagerStatePlay_4() { return static_cast<int32_t>(offsetof(SingleContestContentCheckEndUpdate_t724040745, ___contestManagerStatePlay_4)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_4() const { return ___contestManagerStatePlay_4; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_4() { return &___contestManagerStatePlay_4; }
	inline void set_contestManagerStatePlay_4(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_4 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
