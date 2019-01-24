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

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.BoundTooltipTrigger
struct  BoundTooltipTrigger_t709210963  : public MonoBehaviour_t1158329972
{
public:
	// System.String UnityEngine.UI.Extensions.BoundTooltipTrigger::text
	String_t* ___text_2;
	// System.Boolean UnityEngine.UI.Extensions.BoundTooltipTrigger::useMousePosition
	bool ___useMousePosition_3;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.BoundTooltipTrigger::offset
	Vector3_t2243707580  ___offset_4;

public:
	inline static int32_t get_offset_of_text_2() { return static_cast<int32_t>(offsetof(BoundTooltipTrigger_t709210963, ___text_2)); }
	inline String_t* get_text_2() const { return ___text_2; }
	inline String_t** get_address_of_text_2() { return &___text_2; }
	inline void set_text_2(String_t* value)
	{
		___text_2 = value;
		Il2CppCodeGenWriteBarrier(&___text_2, value);
	}

	inline static int32_t get_offset_of_useMousePosition_3() { return static_cast<int32_t>(offsetof(BoundTooltipTrigger_t709210963, ___useMousePosition_3)); }
	inline bool get_useMousePosition_3() const { return ___useMousePosition_3; }
	inline bool* get_address_of_useMousePosition_3() { return &___useMousePosition_3; }
	inline void set_useMousePosition_3(bool value)
	{
		___useMousePosition_3 = value;
	}

	inline static int32_t get_offset_of_offset_4() { return static_cast<int32_t>(offsetof(BoundTooltipTrigger_t709210963, ___offset_4)); }
	inline Vector3_t2243707580  get_offset_4() const { return ___offset_4; }
	inline Vector3_t2243707580 * get_address_of_offset_4() { return &___offset_4; }
	inline void set_offset_4(Vector3_t2243707580  value)
	{
		___offset_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
