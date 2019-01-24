#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<Foundation.Databinding.AudioLayer,System.Single>
struct Dictionary_2_t2855487944;
// System.Action`2<Foundation.Databinding.AudioLayer,System.Single>
struct Action_2_t3146030374;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.AudioManager
struct  AudioManager_t2662707639  : public Il2CppObject
{
public:

public:
};

struct AudioManager_t2662707639_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<Foundation.Databinding.AudioLayer,System.Single> Foundation.Databinding.AudioManager::Volumes
	Dictionary_2_t2855487944 * ___Volumes_0;
	// System.Action`2<Foundation.Databinding.AudioLayer,System.Single> Foundation.Databinding.AudioManager::OnVolumeChanged
	Action_2_t3146030374 * ___OnVolumeChanged_1;

public:
	inline static int32_t get_offset_of_Volumes_0() { return static_cast<int32_t>(offsetof(AudioManager_t2662707639_StaticFields, ___Volumes_0)); }
	inline Dictionary_2_t2855487944 * get_Volumes_0() const { return ___Volumes_0; }
	inline Dictionary_2_t2855487944 ** get_address_of_Volumes_0() { return &___Volumes_0; }
	inline void set_Volumes_0(Dictionary_2_t2855487944 * value)
	{
		___Volumes_0 = value;
		Il2CppCodeGenWriteBarrier(&___Volumes_0, value);
	}

	inline static int32_t get_offset_of_OnVolumeChanged_1() { return static_cast<int32_t>(offsetof(AudioManager_t2662707639_StaticFields, ___OnVolumeChanged_1)); }
	inline Action_2_t3146030374 * get_OnVolumeChanged_1() const { return ___OnVolumeChanged_1; }
	inline Action_2_t3146030374 ** get_address_of_OnVolumeChanged_1() { return &___OnVolumeChanged_1; }
	inline void set_OnVolumeChanged_1(Action_2_t3146030374 * value)
	{
		___OnVolumeChanged_1 = value;
		Il2CppCodeGenWriteBarrier(&___OnVolumeChanged_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
