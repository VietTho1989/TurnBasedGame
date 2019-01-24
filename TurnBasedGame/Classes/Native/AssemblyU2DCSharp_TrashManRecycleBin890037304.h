#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// System.Collections.Generic.Stack`1<UnityEngine.GameObject>
struct Stack_1_t2844261301;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TrashManRecycleBin
struct  TrashManRecycleBin_t890037304  : public Il2CppObject
{
public:
	// UnityEngine.GameObject TrashManRecycleBin::prefab
	GameObject_t1756533147 * ___prefab_0;
	// System.Int32 TrashManRecycleBin::instancesToPreallocate
	int32_t ___instancesToPreallocate_1;
	// System.Int32 TrashManRecycleBin::instancesToAllocateIfEmpty
	int32_t ___instancesToAllocateIfEmpty_2;
	// System.Boolean TrashManRecycleBin::imposeHardLimit
	bool ___imposeHardLimit_3;
	// System.Int32 TrashManRecycleBin::hardLimit
	int32_t ___hardLimit_4;
	// System.Boolean TrashManRecycleBin::cullExcessPrefabs
	bool ___cullExcessPrefabs_5;
	// System.Int32 TrashManRecycleBin::instancesToMaintainInPool
	int32_t ___instancesToMaintainInPool_6;
	// System.Single TrashManRecycleBin::cullInterval
	float ___cullInterval_7;
	// System.Boolean TrashManRecycleBin::persistBetweenScenes
	bool ___persistBetweenScenes_8;
	// System.Collections.Generic.Stack`1<UnityEngine.GameObject> TrashManRecycleBin::_gameObjectPool
	Stack_1_t2844261301 * ____gameObjectPool_9;
	// System.Single TrashManRecycleBin::_timeOfLastCull
	float ____timeOfLastCull_10;
	// System.Int32 TrashManRecycleBin::_spawnedInstanceCount
	int32_t ____spawnedInstanceCount_11;

public:
	inline static int32_t get_offset_of_prefab_0() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___prefab_0)); }
	inline GameObject_t1756533147 * get_prefab_0() const { return ___prefab_0; }
	inline GameObject_t1756533147 ** get_address_of_prefab_0() { return &___prefab_0; }
	inline void set_prefab_0(GameObject_t1756533147 * value)
	{
		___prefab_0 = value;
		Il2CppCodeGenWriteBarrier(&___prefab_0, value);
	}

	inline static int32_t get_offset_of_instancesToPreallocate_1() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___instancesToPreallocate_1)); }
	inline int32_t get_instancesToPreallocate_1() const { return ___instancesToPreallocate_1; }
	inline int32_t* get_address_of_instancesToPreallocate_1() { return &___instancesToPreallocate_1; }
	inline void set_instancesToPreallocate_1(int32_t value)
	{
		___instancesToPreallocate_1 = value;
	}

	inline static int32_t get_offset_of_instancesToAllocateIfEmpty_2() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___instancesToAllocateIfEmpty_2)); }
	inline int32_t get_instancesToAllocateIfEmpty_2() const { return ___instancesToAllocateIfEmpty_2; }
	inline int32_t* get_address_of_instancesToAllocateIfEmpty_2() { return &___instancesToAllocateIfEmpty_2; }
	inline void set_instancesToAllocateIfEmpty_2(int32_t value)
	{
		___instancesToAllocateIfEmpty_2 = value;
	}

	inline static int32_t get_offset_of_imposeHardLimit_3() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___imposeHardLimit_3)); }
	inline bool get_imposeHardLimit_3() const { return ___imposeHardLimit_3; }
	inline bool* get_address_of_imposeHardLimit_3() { return &___imposeHardLimit_3; }
	inline void set_imposeHardLimit_3(bool value)
	{
		___imposeHardLimit_3 = value;
	}

	inline static int32_t get_offset_of_hardLimit_4() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___hardLimit_4)); }
	inline int32_t get_hardLimit_4() const { return ___hardLimit_4; }
	inline int32_t* get_address_of_hardLimit_4() { return &___hardLimit_4; }
	inline void set_hardLimit_4(int32_t value)
	{
		___hardLimit_4 = value;
	}

	inline static int32_t get_offset_of_cullExcessPrefabs_5() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___cullExcessPrefabs_5)); }
	inline bool get_cullExcessPrefabs_5() const { return ___cullExcessPrefabs_5; }
	inline bool* get_address_of_cullExcessPrefabs_5() { return &___cullExcessPrefabs_5; }
	inline void set_cullExcessPrefabs_5(bool value)
	{
		___cullExcessPrefabs_5 = value;
	}

	inline static int32_t get_offset_of_instancesToMaintainInPool_6() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___instancesToMaintainInPool_6)); }
	inline int32_t get_instancesToMaintainInPool_6() const { return ___instancesToMaintainInPool_6; }
	inline int32_t* get_address_of_instancesToMaintainInPool_6() { return &___instancesToMaintainInPool_6; }
	inline void set_instancesToMaintainInPool_6(int32_t value)
	{
		___instancesToMaintainInPool_6 = value;
	}

	inline static int32_t get_offset_of_cullInterval_7() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___cullInterval_7)); }
	inline float get_cullInterval_7() const { return ___cullInterval_7; }
	inline float* get_address_of_cullInterval_7() { return &___cullInterval_7; }
	inline void set_cullInterval_7(float value)
	{
		___cullInterval_7 = value;
	}

	inline static int32_t get_offset_of_persistBetweenScenes_8() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ___persistBetweenScenes_8)); }
	inline bool get_persistBetweenScenes_8() const { return ___persistBetweenScenes_8; }
	inline bool* get_address_of_persistBetweenScenes_8() { return &___persistBetweenScenes_8; }
	inline void set_persistBetweenScenes_8(bool value)
	{
		___persistBetweenScenes_8 = value;
	}

	inline static int32_t get_offset_of__gameObjectPool_9() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ____gameObjectPool_9)); }
	inline Stack_1_t2844261301 * get__gameObjectPool_9() const { return ____gameObjectPool_9; }
	inline Stack_1_t2844261301 ** get_address_of__gameObjectPool_9() { return &____gameObjectPool_9; }
	inline void set__gameObjectPool_9(Stack_1_t2844261301 * value)
	{
		____gameObjectPool_9 = value;
		Il2CppCodeGenWriteBarrier(&____gameObjectPool_9, value);
	}

	inline static int32_t get_offset_of__timeOfLastCull_10() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ____timeOfLastCull_10)); }
	inline float get__timeOfLastCull_10() const { return ____timeOfLastCull_10; }
	inline float* get_address_of__timeOfLastCull_10() { return &____timeOfLastCull_10; }
	inline void set__timeOfLastCull_10(float value)
	{
		____timeOfLastCull_10 = value;
	}

	inline static int32_t get_offset_of__spawnedInstanceCount_11() { return static_cast<int32_t>(offsetof(TrashManRecycleBin_t890037304, ____spawnedInstanceCount_11)); }
	inline int32_t get__spawnedInstanceCount_11() const { return ____spawnedInstanceCount_11; }
	inline int32_t* get_address_of__spawnedInstanceCount_11() { return &____spawnedInstanceCount_11; }
	inline void set__spawnedInstanceCount_11(int32_t value)
	{
		____spawnedInstanceCount_11 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
