#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_Observable280907994.h"

// UnityEngine.Texture2D
struct Texture2D_t3542995729;
// System.String
struct String_t;
// Foundation.Example.ExampleOptions
struct ExampleOptions_t2666555878;
// Foundation.Example.ExampleList
struct ExampleList_t3532235008;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.ExampleMainMenu
struct  ExampleMainMenu_t1744134894  : public ObservableBehaviour_t280907994
{
public:
	// System.Boolean Foundation.Example.ExampleMainMenu::_isVisible
	bool ____isVisible_8;
	// UnityEngine.Texture2D Foundation.Example.ExampleMainMenu::GameIcon
	Texture2D_t3542995729 * ___GameIcon_9;
	// System.String Foundation.Example.ExampleMainMenu::GameName
	String_t* ___GameName_10;
	// Foundation.Example.ExampleOptions Foundation.Example.ExampleMainMenu::Options
	ExampleOptions_t2666555878 * ___Options_11;
	// Foundation.Example.ExampleList Foundation.Example.ExampleMainMenu::Scores
	ExampleList_t3532235008 * ___Scores_12;

public:
	inline static int32_t get_offset_of__isVisible_8() { return static_cast<int32_t>(offsetof(ExampleMainMenu_t1744134894, ____isVisible_8)); }
	inline bool get__isVisible_8() const { return ____isVisible_8; }
	inline bool* get_address_of__isVisible_8() { return &____isVisible_8; }
	inline void set__isVisible_8(bool value)
	{
		____isVisible_8 = value;
	}

	inline static int32_t get_offset_of_GameIcon_9() { return static_cast<int32_t>(offsetof(ExampleMainMenu_t1744134894, ___GameIcon_9)); }
	inline Texture2D_t3542995729 * get_GameIcon_9() const { return ___GameIcon_9; }
	inline Texture2D_t3542995729 ** get_address_of_GameIcon_9() { return &___GameIcon_9; }
	inline void set_GameIcon_9(Texture2D_t3542995729 * value)
	{
		___GameIcon_9 = value;
		Il2CppCodeGenWriteBarrier(&___GameIcon_9, value);
	}

	inline static int32_t get_offset_of_GameName_10() { return static_cast<int32_t>(offsetof(ExampleMainMenu_t1744134894, ___GameName_10)); }
	inline String_t* get_GameName_10() const { return ___GameName_10; }
	inline String_t** get_address_of_GameName_10() { return &___GameName_10; }
	inline void set_GameName_10(String_t* value)
	{
		___GameName_10 = value;
		Il2CppCodeGenWriteBarrier(&___GameName_10, value);
	}

	inline static int32_t get_offset_of_Options_11() { return static_cast<int32_t>(offsetof(ExampleMainMenu_t1744134894, ___Options_11)); }
	inline ExampleOptions_t2666555878 * get_Options_11() const { return ___Options_11; }
	inline ExampleOptions_t2666555878 ** get_address_of_Options_11() { return &___Options_11; }
	inline void set_Options_11(ExampleOptions_t2666555878 * value)
	{
		___Options_11 = value;
		Il2CppCodeGenWriteBarrier(&___Options_11, value);
	}

	inline static int32_t get_offset_of_Scores_12() { return static_cast<int32_t>(offsetof(ExampleMainMenu_t1744134894, ___Scores_12)); }
	inline ExampleList_t3532235008 * get_Scores_12() const { return ___Scores_12; }
	inline ExampleList_t3532235008 ** get_address_of_Scores_12() { return &___Scores_12; }
	inline void set_Scores_12(ExampleList_t3532235008 * value)
	{
		___Scores_12 = value;
		Il2CppCodeGenWriteBarrier(&___Scores_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
