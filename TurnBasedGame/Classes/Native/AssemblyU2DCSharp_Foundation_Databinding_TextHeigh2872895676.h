#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.LayoutElement
struct LayoutElement_t2808691390;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.TextHeightLayout
struct  TextHeightLayout_t2872895676  : public MonoBehaviour_t1158329972
{
public:
	// System.Int32 Foundation.Databinding.TextHeightLayout::BaseHeight
	int32_t ___BaseHeight_2;
	// System.Boolean Foundation.Databinding.TextHeightLayout::DebugMode
	bool ___DebugMode_3;
	// UnityEngine.UI.LayoutElement Foundation.Databinding.TextHeightLayout::Element
	LayoutElement_t2808691390 * ___Element_4;
	// UnityEngine.UI.Text Foundation.Databinding.TextHeightLayout::Text
	Text_t356221433 * ___Text_5;

public:
	inline static int32_t get_offset_of_BaseHeight_2() { return static_cast<int32_t>(offsetof(TextHeightLayout_t2872895676, ___BaseHeight_2)); }
	inline int32_t get_BaseHeight_2() const { return ___BaseHeight_2; }
	inline int32_t* get_address_of_BaseHeight_2() { return &___BaseHeight_2; }
	inline void set_BaseHeight_2(int32_t value)
	{
		___BaseHeight_2 = value;
	}

	inline static int32_t get_offset_of_DebugMode_3() { return static_cast<int32_t>(offsetof(TextHeightLayout_t2872895676, ___DebugMode_3)); }
	inline bool get_DebugMode_3() const { return ___DebugMode_3; }
	inline bool* get_address_of_DebugMode_3() { return &___DebugMode_3; }
	inline void set_DebugMode_3(bool value)
	{
		___DebugMode_3 = value;
	}

	inline static int32_t get_offset_of_Element_4() { return static_cast<int32_t>(offsetof(TextHeightLayout_t2872895676, ___Element_4)); }
	inline LayoutElement_t2808691390 * get_Element_4() const { return ___Element_4; }
	inline LayoutElement_t2808691390 ** get_address_of_Element_4() { return &___Element_4; }
	inline void set_Element_4(LayoutElement_t2808691390 * value)
	{
		___Element_4 = value;
		Il2CppCodeGenWriteBarrier(&___Element_4, value);
	}

	inline static int32_t get_offset_of_Text_5() { return static_cast<int32_t>(offsetof(TextHeightLayout_t2872895676, ___Text_5)); }
	inline Text_t356221433 * get_Text_5() const { return ___Text_5; }
	inline Text_t356221433 ** get_address_of_Text_5() { return &___Text_5; }
	inline void set_Text_5(Text_t356221433 * value)
	{
		___Text_5 = value;
		Il2CppCodeGenWriteBarrier(&___Text_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
