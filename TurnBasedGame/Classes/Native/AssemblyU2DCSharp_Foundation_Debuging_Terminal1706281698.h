#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// Foundation.Debuging.Terminal
struct Terminal_t1706281698;
// Foundation.Databinding.ObservableList`1<Foundation.Debuging.TerminalItem>
struct ObservableList_1_t1152242774;
// Foundation.Databinding.ObservableList`1<Foundation.Debuging.TerminalCommand>
struct ObservableList_1_t3104578688;
// Foundation.Databinding.ObservableList`1<Foundation.Debuging.TerminalInterpreter>
struct ObservableList_1_t2612821521;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Debuging.Terminal
struct  Terminal_t1706281698  : public Il2CppObject
{
public:
	// UnityEngine.Color Foundation.Debuging.Terminal::LogColor
	Color_t2020392075  ___LogColor_1;
	// UnityEngine.Color Foundation.Debuging.Terminal::WarningColor
	Color_t2020392075  ___WarningColor_2;
	// UnityEngine.Color Foundation.Debuging.Terminal::ErrorColor
	Color_t2020392075  ___ErrorColor_3;
	// UnityEngine.Color Foundation.Debuging.Terminal::SuccessColor
	Color_t2020392075  ___SuccessColor_4;
	// UnityEngine.Color Foundation.Debuging.Terminal::InputColor
	Color_t2020392075  ___InputColor_5;
	// UnityEngine.Color Foundation.Debuging.Terminal::ImportantColor
	Color_t2020392075  ___ImportantColor_6;
	// Foundation.Databinding.ObservableList`1<Foundation.Debuging.TerminalItem> Foundation.Debuging.Terminal::Items
	ObservableList_1_t1152242774 * ___Items_7;
	// Foundation.Databinding.ObservableList`1<Foundation.Debuging.TerminalCommand> Foundation.Debuging.Terminal::Commands
	ObservableList_1_t3104578688 * ___Commands_8;
	// Foundation.Databinding.ObservableList`1<Foundation.Debuging.TerminalInterpreter> Foundation.Debuging.Terminal::Interpreters
	ObservableList_1_t2612821521 * ___Interpreters_9;

public:
	inline static int32_t get_offset_of_LogColor_1() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___LogColor_1)); }
	inline Color_t2020392075  get_LogColor_1() const { return ___LogColor_1; }
	inline Color_t2020392075 * get_address_of_LogColor_1() { return &___LogColor_1; }
	inline void set_LogColor_1(Color_t2020392075  value)
	{
		___LogColor_1 = value;
	}

	inline static int32_t get_offset_of_WarningColor_2() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___WarningColor_2)); }
	inline Color_t2020392075  get_WarningColor_2() const { return ___WarningColor_2; }
	inline Color_t2020392075 * get_address_of_WarningColor_2() { return &___WarningColor_2; }
	inline void set_WarningColor_2(Color_t2020392075  value)
	{
		___WarningColor_2 = value;
	}

	inline static int32_t get_offset_of_ErrorColor_3() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___ErrorColor_3)); }
	inline Color_t2020392075  get_ErrorColor_3() const { return ___ErrorColor_3; }
	inline Color_t2020392075 * get_address_of_ErrorColor_3() { return &___ErrorColor_3; }
	inline void set_ErrorColor_3(Color_t2020392075  value)
	{
		___ErrorColor_3 = value;
	}

	inline static int32_t get_offset_of_SuccessColor_4() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___SuccessColor_4)); }
	inline Color_t2020392075  get_SuccessColor_4() const { return ___SuccessColor_4; }
	inline Color_t2020392075 * get_address_of_SuccessColor_4() { return &___SuccessColor_4; }
	inline void set_SuccessColor_4(Color_t2020392075  value)
	{
		___SuccessColor_4 = value;
	}

	inline static int32_t get_offset_of_InputColor_5() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___InputColor_5)); }
	inline Color_t2020392075  get_InputColor_5() const { return ___InputColor_5; }
	inline Color_t2020392075 * get_address_of_InputColor_5() { return &___InputColor_5; }
	inline void set_InputColor_5(Color_t2020392075  value)
	{
		___InputColor_5 = value;
	}

	inline static int32_t get_offset_of_ImportantColor_6() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___ImportantColor_6)); }
	inline Color_t2020392075  get_ImportantColor_6() const { return ___ImportantColor_6; }
	inline Color_t2020392075 * get_address_of_ImportantColor_6() { return &___ImportantColor_6; }
	inline void set_ImportantColor_6(Color_t2020392075  value)
	{
		___ImportantColor_6 = value;
	}

	inline static int32_t get_offset_of_Items_7() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___Items_7)); }
	inline ObservableList_1_t1152242774 * get_Items_7() const { return ___Items_7; }
	inline ObservableList_1_t1152242774 ** get_address_of_Items_7() { return &___Items_7; }
	inline void set_Items_7(ObservableList_1_t1152242774 * value)
	{
		___Items_7 = value;
		Il2CppCodeGenWriteBarrier(&___Items_7, value);
	}

	inline static int32_t get_offset_of_Commands_8() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___Commands_8)); }
	inline ObservableList_1_t3104578688 * get_Commands_8() const { return ___Commands_8; }
	inline ObservableList_1_t3104578688 ** get_address_of_Commands_8() { return &___Commands_8; }
	inline void set_Commands_8(ObservableList_1_t3104578688 * value)
	{
		___Commands_8 = value;
		Il2CppCodeGenWriteBarrier(&___Commands_8, value);
	}

	inline static int32_t get_offset_of_Interpreters_9() { return static_cast<int32_t>(offsetof(Terminal_t1706281698, ___Interpreters_9)); }
	inline ObservableList_1_t2612821521 * get_Interpreters_9() const { return ___Interpreters_9; }
	inline ObservableList_1_t2612821521 ** get_address_of_Interpreters_9() { return &___Interpreters_9; }
	inline void set_Interpreters_9(ObservableList_1_t2612821521 * value)
	{
		___Interpreters_9 = value;
		Il2CppCodeGenWriteBarrier(&___Interpreters_9, value);
	}
};

struct Terminal_t1706281698_StaticFields
{
public:
	// Foundation.Debuging.Terminal Foundation.Debuging.Terminal::Instance
	Terminal_t1706281698 * ___Instance_0;

public:
	inline static int32_t get_offset_of_Instance_0() { return static_cast<int32_t>(offsetof(Terminal_t1706281698_StaticFields, ___Instance_0)); }
	inline Terminal_t1706281698 * get_Instance_0() const { return ___Instance_0; }
	inline Terminal_t1706281698 ** get_address_of_Instance_0() { return &___Instance_0; }
	inline void set_Instance_0(Terminal_t1706281698 * value)
	{
		___Instance_0 = value;
		Il2CppCodeGenWriteBarrier(&___Instance_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
