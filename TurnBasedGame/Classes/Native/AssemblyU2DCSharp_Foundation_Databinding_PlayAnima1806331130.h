#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// UnityEngine.Animation
struct Animation_t2068071072;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.PlayAnimationBinder
struct  PlayAnimationBinder_t1806331130  : public BindingBase_t2590300386
{
public:
	// UnityEngine.Animation Foundation.Databinding.PlayAnimationBinder::Anim
	Animation_t2068071072 * ___Anim_9;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.PlayAnimationBinder::AnimationBindingInfo
	BindingInfo_t2210172430 * ___AnimationBindingInfo_10;

public:
	inline static int32_t get_offset_of_Anim_9() { return static_cast<int32_t>(offsetof(PlayAnimationBinder_t1806331130, ___Anim_9)); }
	inline Animation_t2068071072 * get_Anim_9() const { return ___Anim_9; }
	inline Animation_t2068071072 ** get_address_of_Anim_9() { return &___Anim_9; }
	inline void set_Anim_9(Animation_t2068071072 * value)
	{
		___Anim_9 = value;
		Il2CppCodeGenWriteBarrier(&___Anim_9, value);
	}

	inline static int32_t get_offset_of_AnimationBindingInfo_10() { return static_cast<int32_t>(offsetof(PlayAnimationBinder_t1806331130, ___AnimationBindingInfo_10)); }
	inline BindingInfo_t2210172430 * get_AnimationBindingInfo_10() const { return ___AnimationBindingInfo_10; }
	inline BindingInfo_t2210172430 ** get_address_of_AnimationBindingInfo_10() { return &___AnimationBindingInfo_10; }
	inline void set_AnimationBindingInfo_10(BindingInfo_t2210172430 * value)
	{
		___AnimationBindingInfo_10 = value;
		Il2CppCodeGenWriteBarrier(&___AnimationBindingInfo_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
