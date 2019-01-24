#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// TrashMan
struct TrashMan_t1150969798;
// System.Collections.Generic.List`1<TrashManRecycleBin>
struct List_1_t259158436;
// System.Collections.Generic.Dictionary`2<System.Int32,TrashManRecycleBin>
struct Dictionary_2_t4192830235;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TrashMan
struct  TrashMan_t1150969798  : public MonoBehaviour_t1158329972
{
public:
	// System.Collections.Generic.List`1<TrashManRecycleBin> TrashMan::recycleBinCollection
	List_1_t259158436 * ___recycleBinCollection_4;
	// System.Single TrashMan::cullExcessObjectsInterval
	float ___cullExcessObjectsInterval_5;
	// System.Boolean TrashMan::persistBetweenScenes
	bool ___persistBetweenScenes_6;
	// System.Collections.Generic.Dictionary`2<System.Int32,TrashManRecycleBin> TrashMan::_instanceIdToRecycleBin
	Dictionary_2_t4192830235 * ____instanceIdToRecycleBin_7;
	// UnityEngine.Transform TrashMan::transform
	Transform_t3275118058 * ___transform_8;

public:
	inline static int32_t get_offset_of_recycleBinCollection_4() { return static_cast<int32_t>(offsetof(TrashMan_t1150969798, ___recycleBinCollection_4)); }
	inline List_1_t259158436 * get_recycleBinCollection_4() const { return ___recycleBinCollection_4; }
	inline List_1_t259158436 ** get_address_of_recycleBinCollection_4() { return &___recycleBinCollection_4; }
	inline void set_recycleBinCollection_4(List_1_t259158436 * value)
	{
		___recycleBinCollection_4 = value;
		Il2CppCodeGenWriteBarrier(&___recycleBinCollection_4, value);
	}

	inline static int32_t get_offset_of_cullExcessObjectsInterval_5() { return static_cast<int32_t>(offsetof(TrashMan_t1150969798, ___cullExcessObjectsInterval_5)); }
	inline float get_cullExcessObjectsInterval_5() const { return ___cullExcessObjectsInterval_5; }
	inline float* get_address_of_cullExcessObjectsInterval_5() { return &___cullExcessObjectsInterval_5; }
	inline void set_cullExcessObjectsInterval_5(float value)
	{
		___cullExcessObjectsInterval_5 = value;
	}

	inline static int32_t get_offset_of_persistBetweenScenes_6() { return static_cast<int32_t>(offsetof(TrashMan_t1150969798, ___persistBetweenScenes_6)); }
	inline bool get_persistBetweenScenes_6() const { return ___persistBetweenScenes_6; }
	inline bool* get_address_of_persistBetweenScenes_6() { return &___persistBetweenScenes_6; }
	inline void set_persistBetweenScenes_6(bool value)
	{
		___persistBetweenScenes_6 = value;
	}

	inline static int32_t get_offset_of__instanceIdToRecycleBin_7() { return static_cast<int32_t>(offsetof(TrashMan_t1150969798, ____instanceIdToRecycleBin_7)); }
	inline Dictionary_2_t4192830235 * get__instanceIdToRecycleBin_7() const { return ____instanceIdToRecycleBin_7; }
	inline Dictionary_2_t4192830235 ** get_address_of__instanceIdToRecycleBin_7() { return &____instanceIdToRecycleBin_7; }
	inline void set__instanceIdToRecycleBin_7(Dictionary_2_t4192830235 * value)
	{
		____instanceIdToRecycleBin_7 = value;
		Il2CppCodeGenWriteBarrier(&____instanceIdToRecycleBin_7, value);
	}

	inline static int32_t get_offset_of_transform_8() { return static_cast<int32_t>(offsetof(TrashMan_t1150969798, ___transform_8)); }
	inline Transform_t3275118058 * get_transform_8() const { return ___transform_8; }
	inline Transform_t3275118058 ** get_address_of_transform_8() { return &___transform_8; }
	inline void set_transform_8(Transform_t3275118058 * value)
	{
		___transform_8 = value;
		Il2CppCodeGenWriteBarrier(&___transform_8, value);
	}
};

struct TrashMan_t1150969798_StaticFields
{
public:
	// System.Boolean TrashMan::log
	bool ___log_2;
	// TrashMan TrashMan::instance
	TrashMan_t1150969798 * ___instance_3;

public:
	inline static int32_t get_offset_of_log_2() { return static_cast<int32_t>(offsetof(TrashMan_t1150969798_StaticFields, ___log_2)); }
	inline bool get_log_2() const { return ___log_2; }
	inline bool* get_address_of_log_2() { return &___log_2; }
	inline void set_log_2(bool value)
	{
		___log_2 = value;
	}

	inline static int32_t get_offset_of_instance_3() { return static_cast<int32_t>(offsetof(TrashMan_t1150969798_StaticFields, ___instance_3)); }
	inline TrashMan_t1150969798 * get_instance_3() const { return ___instance_3; }
	inline TrashMan_t1150969798 ** get_address_of_instance_3() { return &___instance_3; }
	inline void set_instance_3(TrashMan_t1150969798 * value)
	{
		___instance_3 = value;
		Il2CppCodeGenWriteBarrier(&___instance_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
