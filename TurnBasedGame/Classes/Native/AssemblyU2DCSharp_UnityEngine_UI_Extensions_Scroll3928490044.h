#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ScrollRectLinker
struct  ScrollRectLinker_t3928490044  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean UnityEngine.UI.Extensions.ScrollRectLinker::clamp
	bool ___clamp_2;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.ScrollRectLinker::controllingScrollRect
	ScrollRect_t1199013257 * ___controllingScrollRect_3;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.ScrollRectLinker::scrollRect
	ScrollRect_t1199013257 * ___scrollRect_4;

public:
	inline static int32_t get_offset_of_clamp_2() { return static_cast<int32_t>(offsetof(ScrollRectLinker_t3928490044, ___clamp_2)); }
	inline bool get_clamp_2() const { return ___clamp_2; }
	inline bool* get_address_of_clamp_2() { return &___clamp_2; }
	inline void set_clamp_2(bool value)
	{
		___clamp_2 = value;
	}

	inline static int32_t get_offset_of_controllingScrollRect_3() { return static_cast<int32_t>(offsetof(ScrollRectLinker_t3928490044, ___controllingScrollRect_3)); }
	inline ScrollRect_t1199013257 * get_controllingScrollRect_3() const { return ___controllingScrollRect_3; }
	inline ScrollRect_t1199013257 ** get_address_of_controllingScrollRect_3() { return &___controllingScrollRect_3; }
	inline void set_controllingScrollRect_3(ScrollRect_t1199013257 * value)
	{
		___controllingScrollRect_3 = value;
		Il2CppCodeGenWriteBarrier(&___controllingScrollRect_3, value);
	}

	inline static int32_t get_offset_of_scrollRect_4() { return static_cast<int32_t>(offsetof(ScrollRectLinker_t3928490044, ___scrollRect_4)); }
	inline ScrollRect_t1199013257 * get_scrollRect_4() const { return ___scrollRect_4; }
	inline ScrollRect_t1199013257 ** get_address_of_scrollRect_4() { return &___scrollRect_4; }
	inline void set_scrollRect_4(ScrollRect_t1199013257 * value)
	{
		___scrollRect_4 = value;
		Il2CppCodeGenWriteBarrier(&___scrollRect_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
