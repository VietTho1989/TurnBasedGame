#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>>
struct VP_1_t3537971637;
// VP`1<RequestChangeBoolUI/UIData>
struct VP_1_t3802102788;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerPlayBtnForceEndUI/UIData
struct  UIData_t1668254368  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>> GameManager.Match.ContestManagerPlayBtnForceEndUI/UIData::contestManagerStatePlay
	VP_1_t3537971637 * ___contestManagerStatePlay_5;
	// VP`1<RequestChangeBoolUI/UIData> GameManager.Match.ContestManagerPlayBtnForceEndUI/UIData::isForceEnd
	VP_1_t3802102788 * ___isForceEnd_6;

public:
	inline static int32_t get_offset_of_contestManagerStatePlay_5() { return static_cast<int32_t>(offsetof(UIData_t1668254368, ___contestManagerStatePlay_5)); }
	inline VP_1_t3537971637 * get_contestManagerStatePlay_5() const { return ___contestManagerStatePlay_5; }
	inline VP_1_t3537971637 ** get_address_of_contestManagerStatePlay_5() { return &___contestManagerStatePlay_5; }
	inline void set_contestManagerStatePlay_5(VP_1_t3537971637 * value)
	{
		___contestManagerStatePlay_5 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_5, value);
	}

	inline static int32_t get_offset_of_isForceEnd_6() { return static_cast<int32_t>(offsetof(UIData_t1668254368, ___isForceEnd_6)); }
	inline VP_1_t3802102788 * get_isForceEnd_6() const { return ___isForceEnd_6; }
	inline VP_1_t3802102788 ** get_address_of_isForceEnd_6() { return &___isForceEnd_6; }
	inline void set_isForceEnd_6(VP_1_t3802102788 * value)
	{
		___isForceEnd_6 = value;
		Il2CppCodeGenWriteBarrier(&___isForceEnd_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
