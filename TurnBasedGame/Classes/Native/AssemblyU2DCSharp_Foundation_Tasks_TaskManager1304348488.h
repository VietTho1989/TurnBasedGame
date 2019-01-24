#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Threading.Thread
struct Thread_t241561612;
// Foundation.Tasks.TaskManager
struct TaskManager_t1304348488;
// System.Object
struct Il2CppObject;
// System.Collections.Generic.List`1<Foundation.Tasks.TaskManager/CoroutineCommand>
struct List_1_t933895319;
// System.Collections.Generic.List`1<System.Collections.IEnumerator>
struct List_1_t835147881;
// System.Collections.Generic.List`1<System.Action>
struct List_1_t2595592884;
// System.Collections.Generic.List`1<Foundation.Tasks.TaskManager/LogCommand>
struct List_1_t1168191421;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.TaskManager
struct  TaskManager_t1304348488  : public MonoBehaviour_t1158329972
{
public:

public:
};

struct TaskManager_t1304348488_StaticFields
{
public:
	// System.Threading.Thread Foundation.Tasks.TaskManager::<MainThread>k__BackingField
	Thread_t241561612 * ___U3CMainThreadU3Ek__BackingField_2;
	// Foundation.Tasks.TaskManager Foundation.Tasks.TaskManager::_instance
	TaskManager_t1304348488 * ____instance_3;
	// System.Object Foundation.Tasks.TaskManager::syncRoot
	Il2CppObject * ___syncRoot_4;
	// System.Collections.Generic.List`1<Foundation.Tasks.TaskManager/CoroutineCommand> Foundation.Tasks.TaskManager::PendingCoroutineInfo
	List_1_t933895319 * ___PendingCoroutineInfo_5;
	// System.Collections.Generic.List`1<System.Collections.IEnumerator> Foundation.Tasks.TaskManager::PendingAdd
	List_1_t835147881 * ___PendingAdd_6;
	// System.Collections.Generic.List`1<System.Collections.IEnumerator> Foundation.Tasks.TaskManager::PendingRemove
	List_1_t835147881 * ___PendingRemove_7;
	// System.Collections.Generic.List`1<System.Action> Foundation.Tasks.TaskManager::PendingActions
	List_1_t2595592884 * ___PendingActions_8;
	// System.Collections.Generic.List`1<Foundation.Tasks.TaskManager/LogCommand> Foundation.Tasks.TaskManager::PendingLogs
	List_1_t1168191421 * ___PendingLogs_9;
	// System.Boolean Foundation.Tasks.TaskManager::IsApplicationQuit
	bool ___IsApplicationQuit_10;

public:
	inline static int32_t get_offset_of_U3CMainThreadU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___U3CMainThreadU3Ek__BackingField_2)); }
	inline Thread_t241561612 * get_U3CMainThreadU3Ek__BackingField_2() const { return ___U3CMainThreadU3Ek__BackingField_2; }
	inline Thread_t241561612 ** get_address_of_U3CMainThreadU3Ek__BackingField_2() { return &___U3CMainThreadU3Ek__BackingField_2; }
	inline void set_U3CMainThreadU3Ek__BackingField_2(Thread_t241561612 * value)
	{
		___U3CMainThreadU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMainThreadU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of__instance_3() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ____instance_3)); }
	inline TaskManager_t1304348488 * get__instance_3() const { return ____instance_3; }
	inline TaskManager_t1304348488 ** get_address_of__instance_3() { return &____instance_3; }
	inline void set__instance_3(TaskManager_t1304348488 * value)
	{
		____instance_3 = value;
		Il2CppCodeGenWriteBarrier(&____instance_3, value);
	}

	inline static int32_t get_offset_of_syncRoot_4() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___syncRoot_4)); }
	inline Il2CppObject * get_syncRoot_4() const { return ___syncRoot_4; }
	inline Il2CppObject ** get_address_of_syncRoot_4() { return &___syncRoot_4; }
	inline void set_syncRoot_4(Il2CppObject * value)
	{
		___syncRoot_4 = value;
		Il2CppCodeGenWriteBarrier(&___syncRoot_4, value);
	}

	inline static int32_t get_offset_of_PendingCoroutineInfo_5() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___PendingCoroutineInfo_5)); }
	inline List_1_t933895319 * get_PendingCoroutineInfo_5() const { return ___PendingCoroutineInfo_5; }
	inline List_1_t933895319 ** get_address_of_PendingCoroutineInfo_5() { return &___PendingCoroutineInfo_5; }
	inline void set_PendingCoroutineInfo_5(List_1_t933895319 * value)
	{
		___PendingCoroutineInfo_5 = value;
		Il2CppCodeGenWriteBarrier(&___PendingCoroutineInfo_5, value);
	}

	inline static int32_t get_offset_of_PendingAdd_6() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___PendingAdd_6)); }
	inline List_1_t835147881 * get_PendingAdd_6() const { return ___PendingAdd_6; }
	inline List_1_t835147881 ** get_address_of_PendingAdd_6() { return &___PendingAdd_6; }
	inline void set_PendingAdd_6(List_1_t835147881 * value)
	{
		___PendingAdd_6 = value;
		Il2CppCodeGenWriteBarrier(&___PendingAdd_6, value);
	}

	inline static int32_t get_offset_of_PendingRemove_7() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___PendingRemove_7)); }
	inline List_1_t835147881 * get_PendingRemove_7() const { return ___PendingRemove_7; }
	inline List_1_t835147881 ** get_address_of_PendingRemove_7() { return &___PendingRemove_7; }
	inline void set_PendingRemove_7(List_1_t835147881 * value)
	{
		___PendingRemove_7 = value;
		Il2CppCodeGenWriteBarrier(&___PendingRemove_7, value);
	}

	inline static int32_t get_offset_of_PendingActions_8() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___PendingActions_8)); }
	inline List_1_t2595592884 * get_PendingActions_8() const { return ___PendingActions_8; }
	inline List_1_t2595592884 ** get_address_of_PendingActions_8() { return &___PendingActions_8; }
	inline void set_PendingActions_8(List_1_t2595592884 * value)
	{
		___PendingActions_8 = value;
		Il2CppCodeGenWriteBarrier(&___PendingActions_8, value);
	}

	inline static int32_t get_offset_of_PendingLogs_9() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___PendingLogs_9)); }
	inline List_1_t1168191421 * get_PendingLogs_9() const { return ___PendingLogs_9; }
	inline List_1_t1168191421 ** get_address_of_PendingLogs_9() { return &___PendingLogs_9; }
	inline void set_PendingLogs_9(List_1_t1168191421 * value)
	{
		___PendingLogs_9 = value;
		Il2CppCodeGenWriteBarrier(&___PendingLogs_9, value);
	}

	inline static int32_t get_offset_of_IsApplicationQuit_10() { return static_cast<int32_t>(offsetof(TaskManager_t1304348488_StaticFields, ___IsApplicationQuit_10)); }
	inline bool get_IsApplicationQuit_10() const { return ___IsApplicationQuit_10; }
	inline bool* get_address_of_IsApplicationQuit_10() { return &___IsApplicationQuit_10; }
	inline void set_IsApplicationQuit_10(bool value)
	{
		___IsApplicationQuit_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
