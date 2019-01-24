#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ScrollRectTweener
struct  ScrollRectTweener_t3873690283  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.ScrollRectTweener::scrollRect
	ScrollRect_t1199013257 * ___scrollRect_2;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ScrollRectTweener::startPos
	Vector2_t2243707579  ___startPos_3;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ScrollRectTweener::targetPos
	Vector2_t2243707579  ___targetPos_4;
	// System.Boolean UnityEngine.UI.Extensions.ScrollRectTweener::wasHorizontal
	bool ___wasHorizontal_5;
	// System.Boolean UnityEngine.UI.Extensions.ScrollRectTweener::wasVertical
	bool ___wasVertical_6;
	// System.Single UnityEngine.UI.Extensions.ScrollRectTweener::moveSpeed
	float ___moveSpeed_7;
	// System.Boolean UnityEngine.UI.Extensions.ScrollRectTweener::disableDragWhileTweening
	bool ___disableDragWhileTweening_8;

public:
	inline static int32_t get_offset_of_scrollRect_2() { return static_cast<int32_t>(offsetof(ScrollRectTweener_t3873690283, ___scrollRect_2)); }
	inline ScrollRect_t1199013257 * get_scrollRect_2() const { return ___scrollRect_2; }
	inline ScrollRect_t1199013257 ** get_address_of_scrollRect_2() { return &___scrollRect_2; }
	inline void set_scrollRect_2(ScrollRect_t1199013257 * value)
	{
		___scrollRect_2 = value;
		Il2CppCodeGenWriteBarrier(&___scrollRect_2, value);
	}

	inline static int32_t get_offset_of_startPos_3() { return static_cast<int32_t>(offsetof(ScrollRectTweener_t3873690283, ___startPos_3)); }
	inline Vector2_t2243707579  get_startPos_3() const { return ___startPos_3; }
	inline Vector2_t2243707579 * get_address_of_startPos_3() { return &___startPos_3; }
	inline void set_startPos_3(Vector2_t2243707579  value)
	{
		___startPos_3 = value;
	}

	inline static int32_t get_offset_of_targetPos_4() { return static_cast<int32_t>(offsetof(ScrollRectTweener_t3873690283, ___targetPos_4)); }
	inline Vector2_t2243707579  get_targetPos_4() const { return ___targetPos_4; }
	inline Vector2_t2243707579 * get_address_of_targetPos_4() { return &___targetPos_4; }
	inline void set_targetPos_4(Vector2_t2243707579  value)
	{
		___targetPos_4 = value;
	}

	inline static int32_t get_offset_of_wasHorizontal_5() { return static_cast<int32_t>(offsetof(ScrollRectTweener_t3873690283, ___wasHorizontal_5)); }
	inline bool get_wasHorizontal_5() const { return ___wasHorizontal_5; }
	inline bool* get_address_of_wasHorizontal_5() { return &___wasHorizontal_5; }
	inline void set_wasHorizontal_5(bool value)
	{
		___wasHorizontal_5 = value;
	}

	inline static int32_t get_offset_of_wasVertical_6() { return static_cast<int32_t>(offsetof(ScrollRectTweener_t3873690283, ___wasVertical_6)); }
	inline bool get_wasVertical_6() const { return ___wasVertical_6; }
	inline bool* get_address_of_wasVertical_6() { return &___wasVertical_6; }
	inline void set_wasVertical_6(bool value)
	{
		___wasVertical_6 = value;
	}

	inline static int32_t get_offset_of_moveSpeed_7() { return static_cast<int32_t>(offsetof(ScrollRectTweener_t3873690283, ___moveSpeed_7)); }
	inline float get_moveSpeed_7() const { return ___moveSpeed_7; }
	inline float* get_address_of_moveSpeed_7() { return &___moveSpeed_7; }
	inline void set_moveSpeed_7(float value)
	{
		___moveSpeed_7 = value;
	}

	inline static int32_t get_offset_of_disableDragWhileTweening_8() { return static_cast<int32_t>(offsetof(ScrollRectTweener_t3873690283, ___disableDragWhileTweening_8)); }
	inline bool get_disableDragWhileTweening_8() const { return ___disableDragWhileTweening_8; }
	inline bool* get_address_of_disableDragWhileTweening_8() { return &___disableDragWhileTweening_8; }
	inline void set_disableDragWhileTweening_8(bool value)
	{
		___disableDragWhileTweening_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
