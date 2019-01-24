#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Collections.Generic.List`1<UnityEngine.Transform>
struct List_1_t2644239190;
// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.ReorderableListElement>
struct List_1_t2496814557;
// UnityEngine.UI.Extensions.ReorderableListElement
struct ReorderableListElement_t3127693425;
// UnityEngine.UI.Extensions.ReorderableList
struct ReorderableList_t970849249;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ReorderableListContent
struct  ReorderableListContent_t133253858  : public MonoBehaviour_t1158329972
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Transform> UnityEngine.UI.Extensions.ReorderableListContent::_cachedChildren
	List_1_t2644239190 * ____cachedChildren_2;
	// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.ReorderableListElement> UnityEngine.UI.Extensions.ReorderableListContent::_cachedListElement
	List_1_t2496814557 * ____cachedListElement_3;
	// UnityEngine.UI.Extensions.ReorderableListElement UnityEngine.UI.Extensions.ReorderableListContent::_ele
	ReorderableListElement_t3127693425 * ____ele_4;
	// UnityEngine.UI.Extensions.ReorderableList UnityEngine.UI.Extensions.ReorderableListContent::_extList
	ReorderableList_t970849249 * ____extList_5;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ReorderableListContent::_rect
	RectTransform_t3349966182 * ____rect_6;

public:
	inline static int32_t get_offset_of__cachedChildren_2() { return static_cast<int32_t>(offsetof(ReorderableListContent_t133253858, ____cachedChildren_2)); }
	inline List_1_t2644239190 * get__cachedChildren_2() const { return ____cachedChildren_2; }
	inline List_1_t2644239190 ** get_address_of__cachedChildren_2() { return &____cachedChildren_2; }
	inline void set__cachedChildren_2(List_1_t2644239190 * value)
	{
		____cachedChildren_2 = value;
		Il2CppCodeGenWriteBarrier(&____cachedChildren_2, value);
	}

	inline static int32_t get_offset_of__cachedListElement_3() { return static_cast<int32_t>(offsetof(ReorderableListContent_t133253858, ____cachedListElement_3)); }
	inline List_1_t2496814557 * get__cachedListElement_3() const { return ____cachedListElement_3; }
	inline List_1_t2496814557 ** get_address_of__cachedListElement_3() { return &____cachedListElement_3; }
	inline void set__cachedListElement_3(List_1_t2496814557 * value)
	{
		____cachedListElement_3 = value;
		Il2CppCodeGenWriteBarrier(&____cachedListElement_3, value);
	}

	inline static int32_t get_offset_of__ele_4() { return static_cast<int32_t>(offsetof(ReorderableListContent_t133253858, ____ele_4)); }
	inline ReorderableListElement_t3127693425 * get__ele_4() const { return ____ele_4; }
	inline ReorderableListElement_t3127693425 ** get_address_of__ele_4() { return &____ele_4; }
	inline void set__ele_4(ReorderableListElement_t3127693425 * value)
	{
		____ele_4 = value;
		Il2CppCodeGenWriteBarrier(&____ele_4, value);
	}

	inline static int32_t get_offset_of__extList_5() { return static_cast<int32_t>(offsetof(ReorderableListContent_t133253858, ____extList_5)); }
	inline ReorderableList_t970849249 * get__extList_5() const { return ____extList_5; }
	inline ReorderableList_t970849249 ** get_address_of__extList_5() { return &____extList_5; }
	inline void set__extList_5(ReorderableList_t970849249 * value)
	{
		____extList_5 = value;
		Il2CppCodeGenWriteBarrier(&____extList_5, value);
	}

	inline static int32_t get_offset_of__rect_6() { return static_cast<int32_t>(offsetof(ReorderableListContent_t133253858, ____rect_6)); }
	inline RectTransform_t3349966182 * get__rect_6() const { return ____rect_6; }
	inline RectTransform_t3349966182 ** get_address_of__rect_6() { return &____rect_6; }
	inline void set__rect_6(RectTransform_t3349966182 * value)
	{
		____rect_6 = value;
		Il2CppCodeGenWriteBarrier(&____rect_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
