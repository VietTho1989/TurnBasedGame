#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2940522424.h"

// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.RenameFileUI
struct  RenameFileUI_t1579783440  : public UIBehavior_1_t2940522424
{
public:
	// System.Boolean FileSystem.RenameFileUI::needReset
	bool ___needReset_6;
	// RequestChangeStringUI FileSystem.RenameFileUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_7;
	// UnityEngine.Transform FileSystem.RenameFileUI::nameContainer
	Transform_t3275118058 * ___nameContainer_8;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(RenameFileUI_t1579783440, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_requestStringPrefab_7() { return static_cast<int32_t>(offsetof(RenameFileUI_t1579783440, ___requestStringPrefab_7)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_7() const { return ___requestStringPrefab_7; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_7() { return &___requestStringPrefab_7; }
	inline void set_requestStringPrefab_7(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_7, value);
	}

	inline static int32_t get_offset_of_nameContainer_8() { return static_cast<int32_t>(offsetof(RenameFileUI_t1579783440, ___nameContainer_8)); }
	inline Transform_t3275118058 * get_nameContainer_8() const { return ___nameContainer_8; }
	inline Transform_t3275118058 ** get_address_of_nameContainer_8() { return &___nameContainer_8; }
	inline void set_nameContainer_8(Transform_t3275118058 * value)
	{
		___nameContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___nameContainer_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
