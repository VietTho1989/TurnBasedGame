#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Type
struct Type_t;
// Foundation.Databinding.ObservableMessage
struct ObservableMessage_t2819695798;
// System.Object
struct Il2CppObject;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t1158329972;
// Foundation.Databinding.IObservableModel
struct IObservableModel_t1055181153;
// System.ComponentModel.INotifyPropertyChanged
struct INotifyPropertyChanged_t1237983815;
// System.Action`1<Foundation.Databinding.ObservableMessage>
struct Action_1_t2621495180;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ModelBinder
struct  ModelBinder_t1847346839  : public Il2CppObject
{
public:
	// System.Type Foundation.Databinding.ModelBinder::_myType
	Type_t * ____myType_0;
	// Foundation.Databinding.ObservableMessage Foundation.Databinding.ModelBinder::_bindingMessage
	ObservableMessage_t2819695798 * ____bindingMessage_1;
	// System.Object Foundation.Databinding.ModelBinder::_instance
	Il2CppObject * ____instance_2;
	// UnityEngine.MonoBehaviour Foundation.Databinding.ModelBinder::_insanceBehaviour
	MonoBehaviour_t1158329972 * ____insanceBehaviour_3;
	// Foundation.Databinding.IObservableModel Foundation.Databinding.ModelBinder::_bindableInstance
	Il2CppObject * ____bindableInstance_4;
	// System.ComponentModel.INotifyPropertyChanged Foundation.Databinding.ModelBinder::_notifyInstance
	Il2CppObject * ____notifyInstance_5;
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ModelBinder::_onBindingEvent
	Action_1_t2621495180 * ____onBindingEvent_6;

public:
	inline static int32_t get_offset_of__myType_0() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839, ____myType_0)); }
	inline Type_t * get__myType_0() const { return ____myType_0; }
	inline Type_t ** get_address_of__myType_0() { return &____myType_0; }
	inline void set__myType_0(Type_t * value)
	{
		____myType_0 = value;
		Il2CppCodeGenWriteBarrier(&____myType_0, value);
	}

	inline static int32_t get_offset_of__bindingMessage_1() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839, ____bindingMessage_1)); }
	inline ObservableMessage_t2819695798 * get__bindingMessage_1() const { return ____bindingMessage_1; }
	inline ObservableMessage_t2819695798 ** get_address_of__bindingMessage_1() { return &____bindingMessage_1; }
	inline void set__bindingMessage_1(ObservableMessage_t2819695798 * value)
	{
		____bindingMessage_1 = value;
		Il2CppCodeGenWriteBarrier(&____bindingMessage_1, value);
	}

	inline static int32_t get_offset_of__instance_2() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839, ____instance_2)); }
	inline Il2CppObject * get__instance_2() const { return ____instance_2; }
	inline Il2CppObject ** get_address_of__instance_2() { return &____instance_2; }
	inline void set__instance_2(Il2CppObject * value)
	{
		____instance_2 = value;
		Il2CppCodeGenWriteBarrier(&____instance_2, value);
	}

	inline static int32_t get_offset_of__insanceBehaviour_3() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839, ____insanceBehaviour_3)); }
	inline MonoBehaviour_t1158329972 * get__insanceBehaviour_3() const { return ____insanceBehaviour_3; }
	inline MonoBehaviour_t1158329972 ** get_address_of__insanceBehaviour_3() { return &____insanceBehaviour_3; }
	inline void set__insanceBehaviour_3(MonoBehaviour_t1158329972 * value)
	{
		____insanceBehaviour_3 = value;
		Il2CppCodeGenWriteBarrier(&____insanceBehaviour_3, value);
	}

	inline static int32_t get_offset_of__bindableInstance_4() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839, ____bindableInstance_4)); }
	inline Il2CppObject * get__bindableInstance_4() const { return ____bindableInstance_4; }
	inline Il2CppObject ** get_address_of__bindableInstance_4() { return &____bindableInstance_4; }
	inline void set__bindableInstance_4(Il2CppObject * value)
	{
		____bindableInstance_4 = value;
		Il2CppCodeGenWriteBarrier(&____bindableInstance_4, value);
	}

	inline static int32_t get_offset_of__notifyInstance_5() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839, ____notifyInstance_5)); }
	inline Il2CppObject * get__notifyInstance_5() const { return ____notifyInstance_5; }
	inline Il2CppObject ** get_address_of__notifyInstance_5() { return &____notifyInstance_5; }
	inline void set__notifyInstance_5(Il2CppObject * value)
	{
		____notifyInstance_5 = value;
		Il2CppCodeGenWriteBarrier(&____notifyInstance_5, value);
	}

	inline static int32_t get_offset_of__onBindingEvent_6() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839, ____onBindingEvent_6)); }
	inline Action_1_t2621495180 * get__onBindingEvent_6() const { return ____onBindingEvent_6; }
	inline Action_1_t2621495180 ** get_address_of__onBindingEvent_6() { return &____onBindingEvent_6; }
	inline void set__onBindingEvent_6(Action_1_t2621495180 * value)
	{
		____onBindingEvent_6 = value;
		Il2CppCodeGenWriteBarrier(&____onBindingEvent_6, value);
	}
};

struct ModelBinder_t1847346839_StaticFields
{
public:
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ModelBinder::<>f__am$cache0
	Action_1_t2621495180 * ___U3CU3Ef__amU24cache0_7;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_7() { return static_cast<int32_t>(offsetof(ModelBinder_t1847346839_StaticFields, ___U3CU3Ef__amU24cache0_7)); }
	inline Action_1_t2621495180 * get_U3CU3Ef__amU24cache0_7() const { return ___U3CU3Ef__amU24cache0_7; }
	inline Action_1_t2621495180 ** get_address_of_U3CU3Ef__amU24cache0_7() { return &___U3CU3Ef__amU24cache0_7; }
	inline void set_U3CU3Ef__amU24cache0_7(Action_1_t2621495180 * value)
	{
		___U3CU3Ef__amU24cache0_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
