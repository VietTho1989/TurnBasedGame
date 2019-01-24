#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.BaseParamsWithPrefab
struct  BaseParamsWithPrefab_t2501375267  : public BaseParams_t1775368447
{
public:
	// UnityEngine.RectTransform frame8.ScrollRectItemsAdapter.Util.BaseParamsWithPrefab::itemPrefab
	RectTransform_t3349966182 * ___itemPrefab_20;
	// System.Single frame8.ScrollRectItemsAdapter.Util.BaseParamsWithPrefab::_PrefabSize
	float ____PrefabSize_21;

public:
	inline static int32_t get_offset_of_itemPrefab_20() { return static_cast<int32_t>(offsetof(BaseParamsWithPrefab_t2501375267, ___itemPrefab_20)); }
	inline RectTransform_t3349966182 * get_itemPrefab_20() const { return ___itemPrefab_20; }
	inline RectTransform_t3349966182 ** get_address_of_itemPrefab_20() { return &___itemPrefab_20; }
	inline void set_itemPrefab_20(RectTransform_t3349966182 * value)
	{
		___itemPrefab_20 = value;
		Il2CppCodeGenWriteBarrier(&___itemPrefab_20, value);
	}

	inline static int32_t get_offset_of__PrefabSize_21() { return static_cast<int32_t>(offsetof(BaseParamsWithPrefab_t2501375267, ____PrefabSize_21)); }
	inline float get__PrefabSize_21() const { return ____PrefabSize_21; }
	inline float* get_address_of__PrefabSize_21() { return &____PrefabSize_21; }
	inline void set__PrefabSize_21(float value)
	{
		____PrefabSize_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
