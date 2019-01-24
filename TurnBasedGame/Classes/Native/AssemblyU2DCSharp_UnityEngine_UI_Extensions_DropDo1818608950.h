#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// UnityEngine.Sprite
struct Sprite_t309593783;
// System.Action
struct Action_t3226471752;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.DropDownListItem
struct  DropDownListItem_t1818608950  : public Il2CppObject
{
public:
	// System.String UnityEngine.UI.Extensions.DropDownListItem::_caption
	String_t* ____caption_0;
	// UnityEngine.Sprite UnityEngine.UI.Extensions.DropDownListItem::_image
	Sprite_t309593783 * ____image_1;
	// System.Boolean UnityEngine.UI.Extensions.DropDownListItem::_isDisabled
	bool ____isDisabled_2;
	// System.String UnityEngine.UI.Extensions.DropDownListItem::_id
	String_t* ____id_3;
	// System.Action UnityEngine.UI.Extensions.DropDownListItem::OnSelect
	Action_t3226471752 * ___OnSelect_4;
	// System.Action UnityEngine.UI.Extensions.DropDownListItem::OnUpdate
	Action_t3226471752 * ___OnUpdate_5;

public:
	inline static int32_t get_offset_of__caption_0() { return static_cast<int32_t>(offsetof(DropDownListItem_t1818608950, ____caption_0)); }
	inline String_t* get__caption_0() const { return ____caption_0; }
	inline String_t** get_address_of__caption_0() { return &____caption_0; }
	inline void set__caption_0(String_t* value)
	{
		____caption_0 = value;
		Il2CppCodeGenWriteBarrier(&____caption_0, value);
	}

	inline static int32_t get_offset_of__image_1() { return static_cast<int32_t>(offsetof(DropDownListItem_t1818608950, ____image_1)); }
	inline Sprite_t309593783 * get__image_1() const { return ____image_1; }
	inline Sprite_t309593783 ** get_address_of__image_1() { return &____image_1; }
	inline void set__image_1(Sprite_t309593783 * value)
	{
		____image_1 = value;
		Il2CppCodeGenWriteBarrier(&____image_1, value);
	}

	inline static int32_t get_offset_of__isDisabled_2() { return static_cast<int32_t>(offsetof(DropDownListItem_t1818608950, ____isDisabled_2)); }
	inline bool get__isDisabled_2() const { return ____isDisabled_2; }
	inline bool* get_address_of__isDisabled_2() { return &____isDisabled_2; }
	inline void set__isDisabled_2(bool value)
	{
		____isDisabled_2 = value;
	}

	inline static int32_t get_offset_of__id_3() { return static_cast<int32_t>(offsetof(DropDownListItem_t1818608950, ____id_3)); }
	inline String_t* get__id_3() const { return ____id_3; }
	inline String_t** get_address_of__id_3() { return &____id_3; }
	inline void set__id_3(String_t* value)
	{
		____id_3 = value;
		Il2CppCodeGenWriteBarrier(&____id_3, value);
	}

	inline static int32_t get_offset_of_OnSelect_4() { return static_cast<int32_t>(offsetof(DropDownListItem_t1818608950, ___OnSelect_4)); }
	inline Action_t3226471752 * get_OnSelect_4() const { return ___OnSelect_4; }
	inline Action_t3226471752 ** get_address_of_OnSelect_4() { return &___OnSelect_4; }
	inline void set_OnSelect_4(Action_t3226471752 * value)
	{
		___OnSelect_4 = value;
		Il2CppCodeGenWriteBarrier(&___OnSelect_4, value);
	}

	inline static int32_t get_offset_of_OnUpdate_5() { return static_cast<int32_t>(offsetof(DropDownListItem_t1818608950, ___OnUpdate_5)); }
	inline Action_t3226471752 * get_OnUpdate_5() const { return ___OnUpdate_5; }
	inline Action_t3226471752 ** get_address_of_OnUpdate_5() { return &___OnUpdate_5; }
	inline void set_OnUpdate_5(Action_t3226471752 * value)
	{
		___OnUpdate_5 = value;
		Il2CppCodeGenWriteBarrier(&___OnUpdate_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
