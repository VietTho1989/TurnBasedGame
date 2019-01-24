#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_Foundation_Debuging_TerminalItem3792217129.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Debuging.Internal.TerminalItemView
struct  TerminalItemView_t3118515854  : public MonoBehaviour_t1158329972
{
public:
	// Foundation.Debuging.TerminalItem Foundation.Debuging.Internal.TerminalItemView::<Model>k__BackingField
	TerminalItem_t3792217129  ___U3CModelU3Ek__BackingField_2;
	// UnityEngine.UI.Text Foundation.Debuging.Internal.TerminalItemView::Label
	Text_t356221433 * ___Label_3;

public:
	inline static int32_t get_offset_of_U3CModelU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(TerminalItemView_t3118515854, ___U3CModelU3Ek__BackingField_2)); }
	inline TerminalItem_t3792217129  get_U3CModelU3Ek__BackingField_2() const { return ___U3CModelU3Ek__BackingField_2; }
	inline TerminalItem_t3792217129 * get_address_of_U3CModelU3Ek__BackingField_2() { return &___U3CModelU3Ek__BackingField_2; }
	inline void set_U3CModelU3Ek__BackingField_2(TerminalItem_t3792217129  value)
	{
		___U3CModelU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_Label_3() { return static_cast<int32_t>(offsetof(TerminalItemView_t3118515854, ___Label_3)); }
	inline Text_t356221433 * get_Label_3() const { return ___Label_3; }
	inline Text_t356221433 ** get_address_of_Label_3() { return &___Label_3; }
	inline void set_Label_3(Text_t356221433 * value)
	{
		___Label_3 = value;
		Il2CppCodeGenWriteBarrier(&___Label_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
