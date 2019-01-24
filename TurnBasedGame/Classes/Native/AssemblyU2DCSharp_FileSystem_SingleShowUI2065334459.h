#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2291667453.h"

// FileSystem.ShowDirectoryUI
struct ShowDirectoryUI_t3733321548;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.SingleShowUI
struct  SingleShowUI_t2065334459  : public UIBehavior_1_t2291667453
{
public:
	// FileSystem.ShowDirectoryUI FileSystem.SingleShowUI::showDirectoryPrefab
	ShowDirectoryUI_t3733321548 * ___showDirectoryPrefab_6;
	// UnityEngine.Transform FileSystem.SingleShowUI::showDirectoryContainer
	Transform_t3275118058 * ___showDirectoryContainer_7;

public:
	inline static int32_t get_offset_of_showDirectoryPrefab_6() { return static_cast<int32_t>(offsetof(SingleShowUI_t2065334459, ___showDirectoryPrefab_6)); }
	inline ShowDirectoryUI_t3733321548 * get_showDirectoryPrefab_6() const { return ___showDirectoryPrefab_6; }
	inline ShowDirectoryUI_t3733321548 ** get_address_of_showDirectoryPrefab_6() { return &___showDirectoryPrefab_6; }
	inline void set_showDirectoryPrefab_6(ShowDirectoryUI_t3733321548 * value)
	{
		___showDirectoryPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___showDirectoryPrefab_6, value);
	}

	inline static int32_t get_offset_of_showDirectoryContainer_7() { return static_cast<int32_t>(offsetof(SingleShowUI_t2065334459, ___showDirectoryContainer_7)); }
	inline Transform_t3275118058 * get_showDirectoryContainer_7() const { return ___showDirectoryContainer_7; }
	inline Transform_t3275118058 ** get_address_of_showDirectoryContainer_7() { return &___showDirectoryContainer_7; }
	inline void set_showDirectoryContainer_7(Transform_t3275118058 * value)
	{
		___showDirectoryContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___showDirectoryContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
