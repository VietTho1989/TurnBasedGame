#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_LayoutGroup3962498969.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_TableL3586515314.h"

// System.Single[]
struct SingleU5BU5D_t577127397;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.TableLayoutGroup
struct  TableLayoutGroup_t2874982773  : public LayoutGroup_t3962498969
{
public:
	// UnityEngine.UI.Extensions.TableLayoutGroup/Corner UnityEngine.UI.Extensions.TableLayoutGroup::startCorner
	int32_t ___startCorner_10;
	// System.Single[] UnityEngine.UI.Extensions.TableLayoutGroup::columnWidths
	SingleU5BU5D_t577127397* ___columnWidths_11;
	// System.Single UnityEngine.UI.Extensions.TableLayoutGroup::minimumRowHeight
	float ___minimumRowHeight_12;
	// System.Boolean UnityEngine.UI.Extensions.TableLayoutGroup::flexibleRowHeight
	bool ___flexibleRowHeight_13;
	// System.Single UnityEngine.UI.Extensions.TableLayoutGroup::columnSpacing
	float ___columnSpacing_14;
	// System.Single UnityEngine.UI.Extensions.TableLayoutGroup::rowSpacing
	float ___rowSpacing_15;
	// System.Single[] UnityEngine.UI.Extensions.TableLayoutGroup::preferredRowHeights
	SingleU5BU5D_t577127397* ___preferredRowHeights_16;

public:
	inline static int32_t get_offset_of_startCorner_10() { return static_cast<int32_t>(offsetof(TableLayoutGroup_t2874982773, ___startCorner_10)); }
	inline int32_t get_startCorner_10() const { return ___startCorner_10; }
	inline int32_t* get_address_of_startCorner_10() { return &___startCorner_10; }
	inline void set_startCorner_10(int32_t value)
	{
		___startCorner_10 = value;
	}

	inline static int32_t get_offset_of_columnWidths_11() { return static_cast<int32_t>(offsetof(TableLayoutGroup_t2874982773, ___columnWidths_11)); }
	inline SingleU5BU5D_t577127397* get_columnWidths_11() const { return ___columnWidths_11; }
	inline SingleU5BU5D_t577127397** get_address_of_columnWidths_11() { return &___columnWidths_11; }
	inline void set_columnWidths_11(SingleU5BU5D_t577127397* value)
	{
		___columnWidths_11 = value;
		Il2CppCodeGenWriteBarrier(&___columnWidths_11, value);
	}

	inline static int32_t get_offset_of_minimumRowHeight_12() { return static_cast<int32_t>(offsetof(TableLayoutGroup_t2874982773, ___minimumRowHeight_12)); }
	inline float get_minimumRowHeight_12() const { return ___minimumRowHeight_12; }
	inline float* get_address_of_minimumRowHeight_12() { return &___minimumRowHeight_12; }
	inline void set_minimumRowHeight_12(float value)
	{
		___minimumRowHeight_12 = value;
	}

	inline static int32_t get_offset_of_flexibleRowHeight_13() { return static_cast<int32_t>(offsetof(TableLayoutGroup_t2874982773, ___flexibleRowHeight_13)); }
	inline bool get_flexibleRowHeight_13() const { return ___flexibleRowHeight_13; }
	inline bool* get_address_of_flexibleRowHeight_13() { return &___flexibleRowHeight_13; }
	inline void set_flexibleRowHeight_13(bool value)
	{
		___flexibleRowHeight_13 = value;
	}

	inline static int32_t get_offset_of_columnSpacing_14() { return static_cast<int32_t>(offsetof(TableLayoutGroup_t2874982773, ___columnSpacing_14)); }
	inline float get_columnSpacing_14() const { return ___columnSpacing_14; }
	inline float* get_address_of_columnSpacing_14() { return &___columnSpacing_14; }
	inline void set_columnSpacing_14(float value)
	{
		___columnSpacing_14 = value;
	}

	inline static int32_t get_offset_of_rowSpacing_15() { return static_cast<int32_t>(offsetof(TableLayoutGroup_t2874982773, ___rowSpacing_15)); }
	inline float get_rowSpacing_15() const { return ___rowSpacing_15; }
	inline float* get_address_of_rowSpacing_15() { return &___rowSpacing_15; }
	inline void set_rowSpacing_15(float value)
	{
		___rowSpacing_15 = value;
	}

	inline static int32_t get_offset_of_preferredRowHeights_16() { return static_cast<int32_t>(offsetof(TableLayoutGroup_t2874982773, ___preferredRowHeights_16)); }
	inline SingleU5BU5D_t577127397* get_preferredRowHeights_16() const { return ___preferredRowHeights_16; }
	inline SingleU5BU5D_t577127397** get_address_of_preferredRowHeights_16() { return &___preferredRowHeights_16; }
	inline void set_preferredRowHeights_16(SingleU5BU5D_t577127397* value)
	{
		___preferredRowHeights_16 = value;
		Il2CppCodeGenWriteBarrier(&___preferredRowHeights_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
