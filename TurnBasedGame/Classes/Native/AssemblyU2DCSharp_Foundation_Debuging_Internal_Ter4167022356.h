#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// Foundation.Debuging.TerminalCommand
struct TerminalCommand_t1449585747;
// UnityEngine.UI.Text
struct Text_t356221433;
// System.Action
struct Action_t3226471752;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Debuging.Internal.TerminalCommandView
struct  TerminalCommandView_t4167022356  : public MonoBehaviour_t1158329972
{
public:
	// Foundation.Debuging.TerminalCommand Foundation.Debuging.Internal.TerminalCommandView::<Model>k__BackingField
	TerminalCommand_t1449585747 * ___U3CModelU3Ek__BackingField_2;
	// UnityEngine.UI.Text Foundation.Debuging.Internal.TerminalCommandView::Label
	Text_t356221433 * ___Label_3;
	// System.Action Foundation.Debuging.Internal.TerminalCommandView::Handler
	Action_t3226471752 * ___Handler_4;

public:
	inline static int32_t get_offset_of_U3CModelU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(TerminalCommandView_t4167022356, ___U3CModelU3Ek__BackingField_2)); }
	inline TerminalCommand_t1449585747 * get_U3CModelU3Ek__BackingField_2() const { return ___U3CModelU3Ek__BackingField_2; }
	inline TerminalCommand_t1449585747 ** get_address_of_U3CModelU3Ek__BackingField_2() { return &___U3CModelU3Ek__BackingField_2; }
	inline void set_U3CModelU3Ek__BackingField_2(TerminalCommand_t1449585747 * value)
	{
		___U3CModelU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CModelU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_Label_3() { return static_cast<int32_t>(offsetof(TerminalCommandView_t4167022356, ___Label_3)); }
	inline Text_t356221433 * get_Label_3() const { return ___Label_3; }
	inline Text_t356221433 ** get_address_of_Label_3() { return &___Label_3; }
	inline void set_Label_3(Text_t356221433 * value)
	{
		___Label_3 = value;
		Il2CppCodeGenWriteBarrier(&___Label_3, value);
	}

	inline static int32_t get_offset_of_Handler_4() { return static_cast<int32_t>(offsetof(TerminalCommandView_t4167022356, ___Handler_4)); }
	inline Action_t3226471752 * get_Handler_4() const { return ___Handler_4; }
	inline Action_t3226471752 ** get_address_of_Handler_4() { return &___Handler_4; }
	inline void set_Handler_4(Action_t3226471752 * value)
	{
		___Handler_4 = value;
		Il2CppCodeGenWriteBarrier(&___Handler_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
