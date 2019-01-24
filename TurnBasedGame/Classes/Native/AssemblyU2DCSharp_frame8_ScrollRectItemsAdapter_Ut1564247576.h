#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"
#include "UnityEngine_UnityEngine_TextAnchor112990806.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.RectOffset
struct RectOffset_t3387826427;
// UnityEngine.UI.HorizontalOrVerticalLayoutGroup
struct HorizontalOrVerticalLayoutGroup_t1968298610;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.GridView.GridParams
struct  GridParams_t1564247576  : public BaseParams_t1775368447
{
public:
	// UnityEngine.RectTransform frame8.ScrollRectItemsAdapter.Util.GridView.GridParams::cellPrefab
	RectTransform_t3349966182 * ___cellPrefab_20;
	// System.Int32 frame8.ScrollRectItemsAdapter.Util.GridView.GridParams::numCellsPerGroup
	int32_t ___numCellsPerGroup_21;
	// UnityEngine.TextAnchor frame8.ScrollRectItemsAdapter.Util.GridView.GridParams::alignmentOfCellsInGroup
	int32_t ___alignmentOfCellsInGroup_22;
	// UnityEngine.RectOffset frame8.ScrollRectItemsAdapter.Util.GridView.GridParams::groupPadding
	RectOffset_t3387826427 * ___groupPadding_23;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.GridView.GridParams::cellWidthForceExpandInGroup
	bool ___cellWidthForceExpandInGroup_24;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.GridView.GridParams::cellHeightForceExpandInGroup
	bool ___cellHeightForceExpandInGroup_25;
	// UnityEngine.UI.HorizontalOrVerticalLayoutGroup frame8.ScrollRectItemsAdapter.Util.GridView.GridParams::_TheOnlyGroupPrefab
	HorizontalOrVerticalLayoutGroup_t1968298610 * ____TheOnlyGroupPrefab_26;

public:
	inline static int32_t get_offset_of_cellPrefab_20() { return static_cast<int32_t>(offsetof(GridParams_t1564247576, ___cellPrefab_20)); }
	inline RectTransform_t3349966182 * get_cellPrefab_20() const { return ___cellPrefab_20; }
	inline RectTransform_t3349966182 ** get_address_of_cellPrefab_20() { return &___cellPrefab_20; }
	inline void set_cellPrefab_20(RectTransform_t3349966182 * value)
	{
		___cellPrefab_20 = value;
		Il2CppCodeGenWriteBarrier(&___cellPrefab_20, value);
	}

	inline static int32_t get_offset_of_numCellsPerGroup_21() { return static_cast<int32_t>(offsetof(GridParams_t1564247576, ___numCellsPerGroup_21)); }
	inline int32_t get_numCellsPerGroup_21() const { return ___numCellsPerGroup_21; }
	inline int32_t* get_address_of_numCellsPerGroup_21() { return &___numCellsPerGroup_21; }
	inline void set_numCellsPerGroup_21(int32_t value)
	{
		___numCellsPerGroup_21 = value;
	}

	inline static int32_t get_offset_of_alignmentOfCellsInGroup_22() { return static_cast<int32_t>(offsetof(GridParams_t1564247576, ___alignmentOfCellsInGroup_22)); }
	inline int32_t get_alignmentOfCellsInGroup_22() const { return ___alignmentOfCellsInGroup_22; }
	inline int32_t* get_address_of_alignmentOfCellsInGroup_22() { return &___alignmentOfCellsInGroup_22; }
	inline void set_alignmentOfCellsInGroup_22(int32_t value)
	{
		___alignmentOfCellsInGroup_22 = value;
	}

	inline static int32_t get_offset_of_groupPadding_23() { return static_cast<int32_t>(offsetof(GridParams_t1564247576, ___groupPadding_23)); }
	inline RectOffset_t3387826427 * get_groupPadding_23() const { return ___groupPadding_23; }
	inline RectOffset_t3387826427 ** get_address_of_groupPadding_23() { return &___groupPadding_23; }
	inline void set_groupPadding_23(RectOffset_t3387826427 * value)
	{
		___groupPadding_23 = value;
		Il2CppCodeGenWriteBarrier(&___groupPadding_23, value);
	}

	inline static int32_t get_offset_of_cellWidthForceExpandInGroup_24() { return static_cast<int32_t>(offsetof(GridParams_t1564247576, ___cellWidthForceExpandInGroup_24)); }
	inline bool get_cellWidthForceExpandInGroup_24() const { return ___cellWidthForceExpandInGroup_24; }
	inline bool* get_address_of_cellWidthForceExpandInGroup_24() { return &___cellWidthForceExpandInGroup_24; }
	inline void set_cellWidthForceExpandInGroup_24(bool value)
	{
		___cellWidthForceExpandInGroup_24 = value;
	}

	inline static int32_t get_offset_of_cellHeightForceExpandInGroup_25() { return static_cast<int32_t>(offsetof(GridParams_t1564247576, ___cellHeightForceExpandInGroup_25)); }
	inline bool get_cellHeightForceExpandInGroup_25() const { return ___cellHeightForceExpandInGroup_25; }
	inline bool* get_address_of_cellHeightForceExpandInGroup_25() { return &___cellHeightForceExpandInGroup_25; }
	inline void set_cellHeightForceExpandInGroup_25(bool value)
	{
		___cellHeightForceExpandInGroup_25 = value;
	}

	inline static int32_t get_offset_of__TheOnlyGroupPrefab_26() { return static_cast<int32_t>(offsetof(GridParams_t1564247576, ____TheOnlyGroupPrefab_26)); }
	inline HorizontalOrVerticalLayoutGroup_t1968298610 * get__TheOnlyGroupPrefab_26() const { return ____TheOnlyGroupPrefab_26; }
	inline HorizontalOrVerticalLayoutGroup_t1968298610 ** get_address_of__TheOnlyGroupPrefab_26() { return &____TheOnlyGroupPrefab_26; }
	inline void set__TheOnlyGroupPrefab_26(HorizontalOrVerticalLayoutGroup_t1968298610 * value)
	{
		____TheOnlyGroupPrefab_26 = value;
		Il2CppCodeGenWriteBarrier(&____TheOnlyGroupPrefab_26, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
