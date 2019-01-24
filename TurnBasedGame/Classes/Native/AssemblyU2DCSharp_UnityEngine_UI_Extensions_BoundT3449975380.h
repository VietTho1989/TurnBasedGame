#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Extensions.BoundTooltipItem
struct BoundTooltipItem_t3449975380;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.BoundTooltipItem
struct  BoundTooltipItem_t3449975380  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Text UnityEngine.UI.Extensions.BoundTooltipItem::TooltipText
	Text_t356221433 * ___TooltipText_2;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.BoundTooltipItem::ToolTipOffset
	Vector3_t2243707580  ___ToolTipOffset_3;

public:
	inline static int32_t get_offset_of_TooltipText_2() { return static_cast<int32_t>(offsetof(BoundTooltipItem_t3449975380, ___TooltipText_2)); }
	inline Text_t356221433 * get_TooltipText_2() const { return ___TooltipText_2; }
	inline Text_t356221433 ** get_address_of_TooltipText_2() { return &___TooltipText_2; }
	inline void set_TooltipText_2(Text_t356221433 * value)
	{
		___TooltipText_2 = value;
		Il2CppCodeGenWriteBarrier(&___TooltipText_2, value);
	}

	inline static int32_t get_offset_of_ToolTipOffset_3() { return static_cast<int32_t>(offsetof(BoundTooltipItem_t3449975380, ___ToolTipOffset_3)); }
	inline Vector3_t2243707580  get_ToolTipOffset_3() const { return ___ToolTipOffset_3; }
	inline Vector3_t2243707580 * get_address_of_ToolTipOffset_3() { return &___ToolTipOffset_3; }
	inline void set_ToolTipOffset_3(Vector3_t2243707580  value)
	{
		___ToolTipOffset_3 = value;
	}
};

struct BoundTooltipItem_t3449975380_StaticFields
{
public:
	// UnityEngine.UI.Extensions.BoundTooltipItem UnityEngine.UI.Extensions.BoundTooltipItem::instance
	BoundTooltipItem_t3449975380 * ___instance_4;

public:
	inline static int32_t get_offset_of_instance_4() { return static_cast<int32_t>(offsetof(BoundTooltipItem_t3449975380_StaticFields, ___instance_4)); }
	inline BoundTooltipItem_t3449975380 * get_instance_4() const { return ___instance_4; }
	inline BoundTooltipItem_t3449975380 ** get_address_of_instance_4() { return &___instance_4; }
	inline void set_instance_4(BoundTooltipItem_t3449975380 * value)
	{
		___instance_4 = value;
		Il2CppCodeGenWriteBarrier(&___instance_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
