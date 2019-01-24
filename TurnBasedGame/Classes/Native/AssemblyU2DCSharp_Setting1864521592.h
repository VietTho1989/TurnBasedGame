#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// Setting
struct Setting_t1864521592;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<AnimationSetting>
struct VP_1_t1045672848;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Setting
struct  Setting_t1864521592  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> Setting::showLastMove
	VP_1_t4203851724 * ___showLastMove_6;
	// VP`1<System.Boolean> Setting::viewUrlImage
	VP_1_t4203851724 * ___viewUrlImage_7;
	// VP`1<AnimationSetting> Setting::animationSetting
	VP_1_t1045672848 * ___animationSetting_8;
	// VP`1<System.Int32> Setting::maxThinkCount
	VP_1_t2450154454 * ___maxThinkCount_9;

public:
	inline static int32_t get_offset_of_showLastMove_6() { return static_cast<int32_t>(offsetof(Setting_t1864521592, ___showLastMove_6)); }
	inline VP_1_t4203851724 * get_showLastMove_6() const { return ___showLastMove_6; }
	inline VP_1_t4203851724 ** get_address_of_showLastMove_6() { return &___showLastMove_6; }
	inline void set_showLastMove_6(VP_1_t4203851724 * value)
	{
		___showLastMove_6 = value;
		Il2CppCodeGenWriteBarrier(&___showLastMove_6, value);
	}

	inline static int32_t get_offset_of_viewUrlImage_7() { return static_cast<int32_t>(offsetof(Setting_t1864521592, ___viewUrlImage_7)); }
	inline VP_1_t4203851724 * get_viewUrlImage_7() const { return ___viewUrlImage_7; }
	inline VP_1_t4203851724 ** get_address_of_viewUrlImage_7() { return &___viewUrlImage_7; }
	inline void set_viewUrlImage_7(VP_1_t4203851724 * value)
	{
		___viewUrlImage_7 = value;
		Il2CppCodeGenWriteBarrier(&___viewUrlImage_7, value);
	}

	inline static int32_t get_offset_of_animationSetting_8() { return static_cast<int32_t>(offsetof(Setting_t1864521592, ___animationSetting_8)); }
	inline VP_1_t1045672848 * get_animationSetting_8() const { return ___animationSetting_8; }
	inline VP_1_t1045672848 ** get_address_of_animationSetting_8() { return &___animationSetting_8; }
	inline void set_animationSetting_8(VP_1_t1045672848 * value)
	{
		___animationSetting_8 = value;
		Il2CppCodeGenWriteBarrier(&___animationSetting_8, value);
	}

	inline static int32_t get_offset_of_maxThinkCount_9() { return static_cast<int32_t>(offsetof(Setting_t1864521592, ___maxThinkCount_9)); }
	inline VP_1_t2450154454 * get_maxThinkCount_9() const { return ___maxThinkCount_9; }
	inline VP_1_t2450154454 ** get_address_of_maxThinkCount_9() { return &___maxThinkCount_9; }
	inline void set_maxThinkCount_9(VP_1_t2450154454 * value)
	{
		___maxThinkCount_9 = value;
		Il2CppCodeGenWriteBarrier(&___maxThinkCount_9, value);
	}
};

struct Setting_t1864521592_StaticFields
{
public:
	// Setting Setting::instance
	Setting_t1864521592 * ___instance_5;

public:
	inline static int32_t get_offset_of_instance_5() { return static_cast<int32_t>(offsetof(Setting_t1864521592_StaticFields, ___instance_5)); }
	inline Setting_t1864521592 * get_instance_5() const { return ___instance_5; }
	inline Setting_t1864521592 ** get_address_of_instance_5() { return &___instance_5; }
	inline void set_instance_5(Setting_t1864521592 * value)
	{
		___instance_5 = value;
		Il2CppCodeGenWriteBarrier(&___instance_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
