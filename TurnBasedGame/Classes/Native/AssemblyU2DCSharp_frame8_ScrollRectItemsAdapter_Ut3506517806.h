#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshGizmo
struct PullToRefreshGizmo_t3372597009;
// UnityEngine.AudioClip
struct AudioClip_t1932558630;
// UnityEngine.Events.UnityEvent
struct UnityEvent_t408735097;
// frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour/UnityEventFloat
struct UnityEventFloat_t1628738750;
// frame8.Logic.Misc.Visual.UI.IScrollRectProxy
struct IScrollRectProxy_t1619251202;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// System.Action`1<System.Single>
struct Action_1_t1878309314;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour
struct  PullToRefreshBehaviour_t3506517806  : public MonoBehaviour_t1158329972
{
public:
	// System.Single frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_PullAmountNormalized
	float ____PullAmountNormalized_2;
	// frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshGizmo frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_RefreshGizmo
	PullToRefreshGizmo_t3372597009 * ____RefreshGizmo_3;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_AutoHideRefreshGizmo
	bool ____AutoHideRefreshGizmo_4;
	// UnityEngine.AudioClip frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_SoundOnPreRefresh
	AudioClip_t1932558630 * ____SoundOnPreRefresh_5;
	// UnityEngine.AudioClip frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_SoundOnRefresh
	AudioClip_t1932558630 * ____SoundOnRefresh_6;
	// UnityEngine.Events.UnityEvent frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::OnRefresh
	UnityEvent_t408735097 * ___OnRefresh_7;
	// frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour/UnityEventFloat frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::OnPullProgress
	UnityEventFloat_t1628738750 * ___OnPullProgress_8;
	// frame8.Logic.Misc.Visual.UI.IScrollRectProxy frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::externalScrollRectProxy
	Il2CppObject * ___externalScrollRectProxy_9;
	// UnityEngine.UI.ScrollRect frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_ScrollRect
	ScrollRect_t1199013257 * ____ScrollRect_10;
	// System.Single frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_ResolvedAVGScreenSize
	float ____ResolvedAVGScreenSize_11;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_PlayedPreSoundForCurrentDrag
	bool ____PlayedPreSoundForCurrentDrag_12;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::_IgnoreCurrentDrag
	bool ____IgnoreCurrentDrag_13;
	// System.Action`1<System.Single> frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshBehaviour::ScrollPositionChanged
	Action_1_t1878309314 * ___ScrollPositionChanged_14;

public:
	inline static int32_t get_offset_of__PullAmountNormalized_2() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____PullAmountNormalized_2)); }
	inline float get__PullAmountNormalized_2() const { return ____PullAmountNormalized_2; }
	inline float* get_address_of__PullAmountNormalized_2() { return &____PullAmountNormalized_2; }
	inline void set__PullAmountNormalized_2(float value)
	{
		____PullAmountNormalized_2 = value;
	}

	inline static int32_t get_offset_of__RefreshGizmo_3() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____RefreshGizmo_3)); }
	inline PullToRefreshGizmo_t3372597009 * get__RefreshGizmo_3() const { return ____RefreshGizmo_3; }
	inline PullToRefreshGizmo_t3372597009 ** get_address_of__RefreshGizmo_3() { return &____RefreshGizmo_3; }
	inline void set__RefreshGizmo_3(PullToRefreshGizmo_t3372597009 * value)
	{
		____RefreshGizmo_3 = value;
		Il2CppCodeGenWriteBarrier(&____RefreshGizmo_3, value);
	}

	inline static int32_t get_offset_of__AutoHideRefreshGizmo_4() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____AutoHideRefreshGizmo_4)); }
	inline bool get__AutoHideRefreshGizmo_4() const { return ____AutoHideRefreshGizmo_4; }
	inline bool* get_address_of__AutoHideRefreshGizmo_4() { return &____AutoHideRefreshGizmo_4; }
	inline void set__AutoHideRefreshGizmo_4(bool value)
	{
		____AutoHideRefreshGizmo_4 = value;
	}

	inline static int32_t get_offset_of__SoundOnPreRefresh_5() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____SoundOnPreRefresh_5)); }
	inline AudioClip_t1932558630 * get__SoundOnPreRefresh_5() const { return ____SoundOnPreRefresh_5; }
	inline AudioClip_t1932558630 ** get_address_of__SoundOnPreRefresh_5() { return &____SoundOnPreRefresh_5; }
	inline void set__SoundOnPreRefresh_5(AudioClip_t1932558630 * value)
	{
		____SoundOnPreRefresh_5 = value;
		Il2CppCodeGenWriteBarrier(&____SoundOnPreRefresh_5, value);
	}

	inline static int32_t get_offset_of__SoundOnRefresh_6() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____SoundOnRefresh_6)); }
	inline AudioClip_t1932558630 * get__SoundOnRefresh_6() const { return ____SoundOnRefresh_6; }
	inline AudioClip_t1932558630 ** get_address_of__SoundOnRefresh_6() { return &____SoundOnRefresh_6; }
	inline void set__SoundOnRefresh_6(AudioClip_t1932558630 * value)
	{
		____SoundOnRefresh_6 = value;
		Il2CppCodeGenWriteBarrier(&____SoundOnRefresh_6, value);
	}

	inline static int32_t get_offset_of_OnRefresh_7() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ___OnRefresh_7)); }
	inline UnityEvent_t408735097 * get_OnRefresh_7() const { return ___OnRefresh_7; }
	inline UnityEvent_t408735097 ** get_address_of_OnRefresh_7() { return &___OnRefresh_7; }
	inline void set_OnRefresh_7(UnityEvent_t408735097 * value)
	{
		___OnRefresh_7 = value;
		Il2CppCodeGenWriteBarrier(&___OnRefresh_7, value);
	}

	inline static int32_t get_offset_of_OnPullProgress_8() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ___OnPullProgress_8)); }
	inline UnityEventFloat_t1628738750 * get_OnPullProgress_8() const { return ___OnPullProgress_8; }
	inline UnityEventFloat_t1628738750 ** get_address_of_OnPullProgress_8() { return &___OnPullProgress_8; }
	inline void set_OnPullProgress_8(UnityEventFloat_t1628738750 * value)
	{
		___OnPullProgress_8 = value;
		Il2CppCodeGenWriteBarrier(&___OnPullProgress_8, value);
	}

	inline static int32_t get_offset_of_externalScrollRectProxy_9() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ___externalScrollRectProxy_9)); }
	inline Il2CppObject * get_externalScrollRectProxy_9() const { return ___externalScrollRectProxy_9; }
	inline Il2CppObject ** get_address_of_externalScrollRectProxy_9() { return &___externalScrollRectProxy_9; }
	inline void set_externalScrollRectProxy_9(Il2CppObject * value)
	{
		___externalScrollRectProxy_9 = value;
		Il2CppCodeGenWriteBarrier(&___externalScrollRectProxy_9, value);
	}

	inline static int32_t get_offset_of__ScrollRect_10() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____ScrollRect_10)); }
	inline ScrollRect_t1199013257 * get__ScrollRect_10() const { return ____ScrollRect_10; }
	inline ScrollRect_t1199013257 ** get_address_of__ScrollRect_10() { return &____ScrollRect_10; }
	inline void set__ScrollRect_10(ScrollRect_t1199013257 * value)
	{
		____ScrollRect_10 = value;
		Il2CppCodeGenWriteBarrier(&____ScrollRect_10, value);
	}

	inline static int32_t get_offset_of__ResolvedAVGScreenSize_11() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____ResolvedAVGScreenSize_11)); }
	inline float get__ResolvedAVGScreenSize_11() const { return ____ResolvedAVGScreenSize_11; }
	inline float* get_address_of__ResolvedAVGScreenSize_11() { return &____ResolvedAVGScreenSize_11; }
	inline void set__ResolvedAVGScreenSize_11(float value)
	{
		____ResolvedAVGScreenSize_11 = value;
	}

	inline static int32_t get_offset_of__PlayedPreSoundForCurrentDrag_12() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____PlayedPreSoundForCurrentDrag_12)); }
	inline bool get__PlayedPreSoundForCurrentDrag_12() const { return ____PlayedPreSoundForCurrentDrag_12; }
	inline bool* get_address_of__PlayedPreSoundForCurrentDrag_12() { return &____PlayedPreSoundForCurrentDrag_12; }
	inline void set__PlayedPreSoundForCurrentDrag_12(bool value)
	{
		____PlayedPreSoundForCurrentDrag_12 = value;
	}

	inline static int32_t get_offset_of__IgnoreCurrentDrag_13() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ____IgnoreCurrentDrag_13)); }
	inline bool get__IgnoreCurrentDrag_13() const { return ____IgnoreCurrentDrag_13; }
	inline bool* get_address_of__IgnoreCurrentDrag_13() { return &____IgnoreCurrentDrag_13; }
	inline void set__IgnoreCurrentDrag_13(bool value)
	{
		____IgnoreCurrentDrag_13 = value;
	}

	inline static int32_t get_offset_of_ScrollPositionChanged_14() { return static_cast<int32_t>(offsetof(PullToRefreshBehaviour_t3506517806, ___ScrollPositionChanged_14)); }
	inline Action_1_t1878309314 * get_ScrollPositionChanged_14() const { return ___ScrollPositionChanged_14; }
	inline Action_1_t1878309314 ** get_address_of_ScrollPositionChanged_14() { return &___ScrollPositionChanged_14; }
	inline void set_ScrollPositionChanged_14(Action_1_t1878309314 * value)
	{
		___ScrollPositionChanged_14 = value;
		Il2CppCodeGenWriteBarrier(&___ScrollPositionChanged_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
