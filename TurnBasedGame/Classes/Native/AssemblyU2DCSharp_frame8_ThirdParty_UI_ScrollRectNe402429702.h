#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_ScrollRect1199013257.h"

// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ThirdParty.UI.ScrollRectNested
struct  ScrollRectNested_t402429702  : public ScrollRect_t1199013257
{
public:
	// UnityEngine.UI.ScrollRect frame8.ThirdParty.UI.ScrollRectNested::_ParentScrollRect
	ScrollRect_t1199013257 * ____ParentScrollRect_38;
	// System.Boolean frame8.ThirdParty.UI.ScrollRectNested::_RouteToParent
	bool ____RouteToParent_39;

public:
	inline static int32_t get_offset_of__ParentScrollRect_38() { return static_cast<int32_t>(offsetof(ScrollRectNested_t402429702, ____ParentScrollRect_38)); }
	inline ScrollRect_t1199013257 * get__ParentScrollRect_38() const { return ____ParentScrollRect_38; }
	inline ScrollRect_t1199013257 ** get_address_of__ParentScrollRect_38() { return &____ParentScrollRect_38; }
	inline void set__ParentScrollRect_38(ScrollRect_t1199013257 * value)
	{
		____ParentScrollRect_38 = value;
		Il2CppCodeGenWriteBarrier(&____ParentScrollRect_38, value);
	}

	inline static int32_t get_offset_of__RouteToParent_39() { return static_cast<int32_t>(offsetof(ScrollRectNested_t402429702, ____RouteToParent_39)); }
	inline bool get__RouteToParent_39() const { return ____RouteToParent_39; }
	inline bool* get_address_of__RouteToParent_39() { return &____RouteToParent_39; }
	inline void set__RouteToParent_39(bool value)
	{
		____RouteToParent_39 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
