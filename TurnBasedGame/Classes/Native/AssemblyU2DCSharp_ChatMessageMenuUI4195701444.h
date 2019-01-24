#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3164217287.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// ChatMessageMenuNoneUI
struct ChatMessageMenuNoneUI_t3375078094;
// ChatMessageMenuEditUI
struct ChatMessageMenuEditUI_t2205184088;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatMessageMenuUI
struct  ChatMessageMenuUI_t4195701444  : public UIBehavior_1_t3164217287
{
public:
	// UnityEngine.Transform ChatMessageMenuUI::content
	Transform_t3275118058 * ___content_6;
	// ChatMessageMenuNoneUI ChatMessageMenuUI::nonePrefab
	ChatMessageMenuNoneUI_t3375078094 * ___nonePrefab_7;
	// ChatMessageMenuEditUI ChatMessageMenuUI::editPrefab
	ChatMessageMenuEditUI_t2205184088 * ___editPrefab_8;

public:
	inline static int32_t get_offset_of_content_6() { return static_cast<int32_t>(offsetof(ChatMessageMenuUI_t4195701444, ___content_6)); }
	inline Transform_t3275118058 * get_content_6() const { return ___content_6; }
	inline Transform_t3275118058 ** get_address_of_content_6() { return &___content_6; }
	inline void set_content_6(Transform_t3275118058 * value)
	{
		___content_6 = value;
		Il2CppCodeGenWriteBarrier(&___content_6, value);
	}

	inline static int32_t get_offset_of_nonePrefab_7() { return static_cast<int32_t>(offsetof(ChatMessageMenuUI_t4195701444, ___nonePrefab_7)); }
	inline ChatMessageMenuNoneUI_t3375078094 * get_nonePrefab_7() const { return ___nonePrefab_7; }
	inline ChatMessageMenuNoneUI_t3375078094 ** get_address_of_nonePrefab_7() { return &___nonePrefab_7; }
	inline void set_nonePrefab_7(ChatMessageMenuNoneUI_t3375078094 * value)
	{
		___nonePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_7, value);
	}

	inline static int32_t get_offset_of_editPrefab_8() { return static_cast<int32_t>(offsetof(ChatMessageMenuUI_t4195701444, ___editPrefab_8)); }
	inline ChatMessageMenuEditUI_t2205184088 * get_editPrefab_8() const { return ___editPrefab_8; }
	inline ChatMessageMenuEditUI_t2205184088 ** get_address_of_editPrefab_8() { return &___editPrefab_8; }
	inline void set_editPrefab_8(ChatMessageMenuEditUI_t2205184088 * value)
	{
		___editPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___editPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
