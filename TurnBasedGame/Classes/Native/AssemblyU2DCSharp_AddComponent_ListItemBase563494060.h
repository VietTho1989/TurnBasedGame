#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// AddComponent.ListItemBase/OnSelectedHandler
struct OnSelectedHandler_t578121523;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AddComponent.ListItemBase
struct  ListItemBase_t563494060  : public MonoBehaviour_t1158329972
{
public:
	// AddComponent.ListItemBase/OnSelectedHandler AddComponent.ListItemBase::onSelected
	OnSelectedHandler_t578121523 * ___onSelected_2;
	// UnityEngine.RectTransform AddComponent.ListItemBase::_rectTransform
	RectTransform_t3349966182 * ____rectTransform_3;
	// System.Int32 AddComponent.ListItemBase::<Index>k__BackingField
	int32_t ___U3CIndexU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_onSelected_2() { return static_cast<int32_t>(offsetof(ListItemBase_t563494060, ___onSelected_2)); }
	inline OnSelectedHandler_t578121523 * get_onSelected_2() const { return ___onSelected_2; }
	inline OnSelectedHandler_t578121523 ** get_address_of_onSelected_2() { return &___onSelected_2; }
	inline void set_onSelected_2(OnSelectedHandler_t578121523 * value)
	{
		___onSelected_2 = value;
		Il2CppCodeGenWriteBarrier(&___onSelected_2, value);
	}

	inline static int32_t get_offset_of__rectTransform_3() { return static_cast<int32_t>(offsetof(ListItemBase_t563494060, ____rectTransform_3)); }
	inline RectTransform_t3349966182 * get__rectTransform_3() const { return ____rectTransform_3; }
	inline RectTransform_t3349966182 ** get_address_of__rectTransform_3() { return &____rectTransform_3; }
	inline void set__rectTransform_3(RectTransform_t3349966182 * value)
	{
		____rectTransform_3 = value;
		Il2CppCodeGenWriteBarrier(&____rectTransform_3, value);
	}

	inline static int32_t get_offset_of_U3CIndexU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(ListItemBase_t563494060, ___U3CIndexU3Ek__BackingField_4)); }
	inline int32_t get_U3CIndexU3Ek__BackingField_4() const { return ___U3CIndexU3Ek__BackingField_4; }
	inline int32_t* get_address_of_U3CIndexU3Ek__BackingField_4() { return &___U3CIndexU3Ek__BackingField_4; }
	inline void set_U3CIndexU3Ek__BackingField_4(int32_t value)
	{
		___U3CIndexU3Ek__BackingField_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
