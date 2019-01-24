#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3171213151.h"

// FileSystem.BtnDeleteUI/UIData
struct UIData_t3224366149;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnDeleteConfirmUI
struct  BtnDeleteConfirmUI_t3181475839  : public UIBehavior_1_t3171213151
{
public:
	// FileSystem.BtnDeleteUI/UIData FileSystem.BtnDeleteConfirmUI::btnDeleteUIData
	UIData_t3224366149 * ___btnDeleteUIData_6;

public:
	inline static int32_t get_offset_of_btnDeleteUIData_6() { return static_cast<int32_t>(offsetof(BtnDeleteConfirmUI_t3181475839, ___btnDeleteUIData_6)); }
	inline UIData_t3224366149 * get_btnDeleteUIData_6() const { return ___btnDeleteUIData_6; }
	inline UIData_t3224366149 ** get_address_of_btnDeleteUIData_6() { return &___btnDeleteUIData_6; }
	inline void set_btnDeleteUIData_6(UIData_t3224366149 * value)
	{
		___btnDeleteUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnDeleteUIData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
