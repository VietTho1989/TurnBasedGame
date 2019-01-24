#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_KeyCode2283395152.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.InputField
struct InputField_t1631627530;
// Foundation.Debuging.Internal.TerminalCommandView
struct TerminalCommandView_t4167022356;
// Foundation.Debuging.Internal.TerminalItemView
struct TerminalItemView_t3118515854;
// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.UI.Scrollbar
struct Scrollbar_t3248359358;
// System.Collections.Generic.List`1<Foundation.Debuging.Internal.TerminalCommandView>
struct List_1_t3536143488;
// System.Collections.Generic.List`1<Foundation.Debuging.Internal.TerminalItemView>
struct List_1_t2487636986;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Debuging.Internal.TerminalView
struct  TerminalView_t3851946995  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean Foundation.Debuging.Internal.TerminalView::DoDontDestoryOnLoad
	bool ___DoDontDestoryOnLoad_2;
	// UnityEngine.GameObject Foundation.Debuging.Internal.TerminalView::DisplayRoot
	GameObject_t1756533147 * ___DisplayRoot_3;
	// UnityEngine.UI.InputField Foundation.Debuging.Internal.TerminalView::TextInput
	InputField_t1631627530 * ___TextInput_4;
	// Foundation.Debuging.Internal.TerminalCommandView Foundation.Debuging.Internal.TerminalView::CommandPrototype
	TerminalCommandView_t4167022356 * ___CommandPrototype_5;
	// Foundation.Debuging.Internal.TerminalItemView Foundation.Debuging.Internal.TerminalView::ItemPrototype
	TerminalItemView_t3118515854 * ___ItemPrototype_6;
	// UnityEngine.Transform Foundation.Debuging.Internal.TerminalView::CommandLayout
	Transform_t3275118058 * ___CommandLayout_7;
	// UnityEngine.Transform Foundation.Debuging.Internal.TerminalView::ItemLayout
	Transform_t3275118058 * ___ItemLayout_8;
	// UnityEngine.UI.Scrollbar Foundation.Debuging.Internal.TerminalView::ItemScrollBar
	Scrollbar_t3248359358 * ___ItemScrollBar_9;
	// System.Collections.Generic.List`1<Foundation.Debuging.Internal.TerminalCommandView> Foundation.Debuging.Internal.TerminalView::CommandItems
	List_1_t3536143488 * ___CommandItems_10;
	// System.Collections.Generic.List`1<Foundation.Debuging.Internal.TerminalItemView> Foundation.Debuging.Internal.TerminalView::TextItems
	List_1_t2487636986 * ___TextItems_11;
	// UnityEngine.KeyCode Foundation.Debuging.Internal.TerminalView::VisiblityKey
	int32_t ___VisiblityKey_12;
	// UnityEngine.Color Foundation.Debuging.Internal.TerminalView::LogColor
	Color_t2020392075  ___LogColor_13;
	// UnityEngine.Color Foundation.Debuging.Internal.TerminalView::WarningColor
	Color_t2020392075  ___WarningColor_14;
	// UnityEngine.Color Foundation.Debuging.Internal.TerminalView::ErrorColor
	Color_t2020392075  ___ErrorColor_15;
	// UnityEngine.Color Foundation.Debuging.Internal.TerminalView::SuccessColor
	Color_t2020392075  ___SuccessColor_16;
	// UnityEngine.Color Foundation.Debuging.Internal.TerminalView::InputColor
	Color_t2020392075  ___InputColor_17;
	// UnityEngine.Color Foundation.Debuging.Internal.TerminalView::ImportantColor
	Color_t2020392075  ___ImportantColor_18;

public:
	inline static int32_t get_offset_of_DoDontDestoryOnLoad_2() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___DoDontDestoryOnLoad_2)); }
	inline bool get_DoDontDestoryOnLoad_2() const { return ___DoDontDestoryOnLoad_2; }
	inline bool* get_address_of_DoDontDestoryOnLoad_2() { return &___DoDontDestoryOnLoad_2; }
	inline void set_DoDontDestoryOnLoad_2(bool value)
	{
		___DoDontDestoryOnLoad_2 = value;
	}

	inline static int32_t get_offset_of_DisplayRoot_3() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___DisplayRoot_3)); }
	inline GameObject_t1756533147 * get_DisplayRoot_3() const { return ___DisplayRoot_3; }
	inline GameObject_t1756533147 ** get_address_of_DisplayRoot_3() { return &___DisplayRoot_3; }
	inline void set_DisplayRoot_3(GameObject_t1756533147 * value)
	{
		___DisplayRoot_3 = value;
		Il2CppCodeGenWriteBarrier(&___DisplayRoot_3, value);
	}

	inline static int32_t get_offset_of_TextInput_4() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___TextInput_4)); }
	inline InputField_t1631627530 * get_TextInput_4() const { return ___TextInput_4; }
	inline InputField_t1631627530 ** get_address_of_TextInput_4() { return &___TextInput_4; }
	inline void set_TextInput_4(InputField_t1631627530 * value)
	{
		___TextInput_4 = value;
		Il2CppCodeGenWriteBarrier(&___TextInput_4, value);
	}

	inline static int32_t get_offset_of_CommandPrototype_5() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___CommandPrototype_5)); }
	inline TerminalCommandView_t4167022356 * get_CommandPrototype_5() const { return ___CommandPrototype_5; }
	inline TerminalCommandView_t4167022356 ** get_address_of_CommandPrototype_5() { return &___CommandPrototype_5; }
	inline void set_CommandPrototype_5(TerminalCommandView_t4167022356 * value)
	{
		___CommandPrototype_5 = value;
		Il2CppCodeGenWriteBarrier(&___CommandPrototype_5, value);
	}

	inline static int32_t get_offset_of_ItemPrototype_6() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___ItemPrototype_6)); }
	inline TerminalItemView_t3118515854 * get_ItemPrototype_6() const { return ___ItemPrototype_6; }
	inline TerminalItemView_t3118515854 ** get_address_of_ItemPrototype_6() { return &___ItemPrototype_6; }
	inline void set_ItemPrototype_6(TerminalItemView_t3118515854 * value)
	{
		___ItemPrototype_6 = value;
		Il2CppCodeGenWriteBarrier(&___ItemPrototype_6, value);
	}

	inline static int32_t get_offset_of_CommandLayout_7() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___CommandLayout_7)); }
	inline Transform_t3275118058 * get_CommandLayout_7() const { return ___CommandLayout_7; }
	inline Transform_t3275118058 ** get_address_of_CommandLayout_7() { return &___CommandLayout_7; }
	inline void set_CommandLayout_7(Transform_t3275118058 * value)
	{
		___CommandLayout_7 = value;
		Il2CppCodeGenWriteBarrier(&___CommandLayout_7, value);
	}

	inline static int32_t get_offset_of_ItemLayout_8() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___ItemLayout_8)); }
	inline Transform_t3275118058 * get_ItemLayout_8() const { return ___ItemLayout_8; }
	inline Transform_t3275118058 ** get_address_of_ItemLayout_8() { return &___ItemLayout_8; }
	inline void set_ItemLayout_8(Transform_t3275118058 * value)
	{
		___ItemLayout_8 = value;
		Il2CppCodeGenWriteBarrier(&___ItemLayout_8, value);
	}

	inline static int32_t get_offset_of_ItemScrollBar_9() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___ItemScrollBar_9)); }
	inline Scrollbar_t3248359358 * get_ItemScrollBar_9() const { return ___ItemScrollBar_9; }
	inline Scrollbar_t3248359358 ** get_address_of_ItemScrollBar_9() { return &___ItemScrollBar_9; }
	inline void set_ItemScrollBar_9(Scrollbar_t3248359358 * value)
	{
		___ItemScrollBar_9 = value;
		Il2CppCodeGenWriteBarrier(&___ItemScrollBar_9, value);
	}

	inline static int32_t get_offset_of_CommandItems_10() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___CommandItems_10)); }
	inline List_1_t3536143488 * get_CommandItems_10() const { return ___CommandItems_10; }
	inline List_1_t3536143488 ** get_address_of_CommandItems_10() { return &___CommandItems_10; }
	inline void set_CommandItems_10(List_1_t3536143488 * value)
	{
		___CommandItems_10 = value;
		Il2CppCodeGenWriteBarrier(&___CommandItems_10, value);
	}

	inline static int32_t get_offset_of_TextItems_11() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___TextItems_11)); }
	inline List_1_t2487636986 * get_TextItems_11() const { return ___TextItems_11; }
	inline List_1_t2487636986 ** get_address_of_TextItems_11() { return &___TextItems_11; }
	inline void set_TextItems_11(List_1_t2487636986 * value)
	{
		___TextItems_11 = value;
		Il2CppCodeGenWriteBarrier(&___TextItems_11, value);
	}

	inline static int32_t get_offset_of_VisiblityKey_12() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___VisiblityKey_12)); }
	inline int32_t get_VisiblityKey_12() const { return ___VisiblityKey_12; }
	inline int32_t* get_address_of_VisiblityKey_12() { return &___VisiblityKey_12; }
	inline void set_VisiblityKey_12(int32_t value)
	{
		___VisiblityKey_12 = value;
	}

	inline static int32_t get_offset_of_LogColor_13() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___LogColor_13)); }
	inline Color_t2020392075  get_LogColor_13() const { return ___LogColor_13; }
	inline Color_t2020392075 * get_address_of_LogColor_13() { return &___LogColor_13; }
	inline void set_LogColor_13(Color_t2020392075  value)
	{
		___LogColor_13 = value;
	}

	inline static int32_t get_offset_of_WarningColor_14() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___WarningColor_14)); }
	inline Color_t2020392075  get_WarningColor_14() const { return ___WarningColor_14; }
	inline Color_t2020392075 * get_address_of_WarningColor_14() { return &___WarningColor_14; }
	inline void set_WarningColor_14(Color_t2020392075  value)
	{
		___WarningColor_14 = value;
	}

	inline static int32_t get_offset_of_ErrorColor_15() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___ErrorColor_15)); }
	inline Color_t2020392075  get_ErrorColor_15() const { return ___ErrorColor_15; }
	inline Color_t2020392075 * get_address_of_ErrorColor_15() { return &___ErrorColor_15; }
	inline void set_ErrorColor_15(Color_t2020392075  value)
	{
		___ErrorColor_15 = value;
	}

	inline static int32_t get_offset_of_SuccessColor_16() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___SuccessColor_16)); }
	inline Color_t2020392075  get_SuccessColor_16() const { return ___SuccessColor_16; }
	inline Color_t2020392075 * get_address_of_SuccessColor_16() { return &___SuccessColor_16; }
	inline void set_SuccessColor_16(Color_t2020392075  value)
	{
		___SuccessColor_16 = value;
	}

	inline static int32_t get_offset_of_InputColor_17() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___InputColor_17)); }
	inline Color_t2020392075  get_InputColor_17() const { return ___InputColor_17; }
	inline Color_t2020392075 * get_address_of_InputColor_17() { return &___InputColor_17; }
	inline void set_InputColor_17(Color_t2020392075  value)
	{
		___InputColor_17 = value;
	}

	inline static int32_t get_offset_of_ImportantColor_18() { return static_cast<int32_t>(offsetof(TerminalView_t3851946995, ___ImportantColor_18)); }
	inline Color_t2020392075  get_ImportantColor_18() const { return ___ImportantColor_18; }
	inline Color_t2020392075 * get_address_of_ImportantColor_18() { return &___ImportantColor_18; }
	inline void set_ImportantColor_18(Color_t2020392075  value)
	{
		___ImportantColor_18 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
