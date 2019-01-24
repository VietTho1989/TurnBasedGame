#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1737691675.h"

// FileSystem.BtnPathHolder
struct BtnPathHolder_t2665413323;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnPathAdapter
struct  BtnPathAdapter_t1446809136  : public SRIA_2_t1737691675
{
public:
	// FileSystem.BtnPathHolder FileSystem.BtnPathAdapter::holderPrefab
	BtnPathHolder_t2665413323 * ___holderPrefab_24;
	// UnityEngine.GameObject FileSystem.BtnPathAdapter::noDirs
	GameObject_t1756533147 * ___noDirs_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(BtnPathAdapter_t1446809136, ___holderPrefab_24)); }
	inline BtnPathHolder_t2665413323 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline BtnPathHolder_t2665413323 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(BtnPathHolder_t2665413323 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noDirs_25() { return static_cast<int32_t>(offsetof(BtnPathAdapter_t1446809136, ___noDirs_25)); }
	inline GameObject_t1756533147 * get_noDirs_25() const { return ___noDirs_25; }
	inline GameObject_t1756533147 ** get_address_of_noDirs_25() { return &___noDirs_25; }
	inline void set_noDirs_25(GameObject_t1756533147 * value)
	{
		___noDirs_25 = value;
		Il2CppCodeGenWriteBarrier(&___noDirs_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
