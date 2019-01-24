#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_ScriptableObject1975622470.h"

// System.Action`1<Foundation.Databinding.ObservableMessage>
struct Action_1_t2621495180;
// Foundation.Databinding.ModelBinder
struct ModelBinder_t1847346839;
// Foundation.Databinding.ObservableMessage
struct ObservableMessage_t2819695798;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ObservableScriptableObject
struct  ObservableScriptableObject_t694408415  : public ScriptableObject_t1975622470
{
public:
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ObservableScriptableObject::_onBindingEvent
	Action_1_t2621495180 * ____onBindingEvent_2;
	// Foundation.Databinding.ModelBinder Foundation.Databinding.ObservableScriptableObject::_binder
	ModelBinder_t1847346839 * ____binder_3;
	// Foundation.Databinding.ObservableMessage Foundation.Databinding.ObservableScriptableObject::_bindingMessage
	ObservableMessage_t2819695798 * ____bindingMessage_4;

public:
	inline static int32_t get_offset_of__onBindingEvent_2() { return static_cast<int32_t>(offsetof(ObservableScriptableObject_t694408415, ____onBindingEvent_2)); }
	inline Action_1_t2621495180 * get__onBindingEvent_2() const { return ____onBindingEvent_2; }
	inline Action_1_t2621495180 ** get_address_of__onBindingEvent_2() { return &____onBindingEvent_2; }
	inline void set__onBindingEvent_2(Action_1_t2621495180 * value)
	{
		____onBindingEvent_2 = value;
		Il2CppCodeGenWriteBarrier(&____onBindingEvent_2, value);
	}

	inline static int32_t get_offset_of__binder_3() { return static_cast<int32_t>(offsetof(ObservableScriptableObject_t694408415, ____binder_3)); }
	inline ModelBinder_t1847346839 * get__binder_3() const { return ____binder_3; }
	inline ModelBinder_t1847346839 ** get_address_of__binder_3() { return &____binder_3; }
	inline void set__binder_3(ModelBinder_t1847346839 * value)
	{
		____binder_3 = value;
		Il2CppCodeGenWriteBarrier(&____binder_3, value);
	}

	inline static int32_t get_offset_of__bindingMessage_4() { return static_cast<int32_t>(offsetof(ObservableScriptableObject_t694408415, ____bindingMessage_4)); }
	inline ObservableMessage_t2819695798 * get__bindingMessage_4() const { return ____bindingMessage_4; }
	inline ObservableMessage_t2819695798 ** get_address_of__bindingMessage_4() { return &____bindingMessage_4; }
	inline void set__bindingMessage_4(ObservableMessage_t2819695798 * value)
	{
		____bindingMessage_4 = value;
		Il2CppCodeGenWriteBarrier(&____bindingMessage_4, value);
	}
};

struct ObservableScriptableObject_t694408415_StaticFields
{
public:
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ObservableScriptableObject::<>f__am$cache0
	Action_1_t2621495180 * ___U3CU3Ef__amU24cache0_5;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_5() { return static_cast<int32_t>(offsetof(ObservableScriptableObject_t694408415_StaticFields, ___U3CU3Ef__amU24cache0_5)); }
	inline Action_1_t2621495180 * get_U3CU3Ef__amU24cache0_5() const { return ___U3CU3Ef__amU24cache0_5; }
	inline Action_1_t2621495180 ** get_address_of_U3CU3Ef__amU24cache0_5() { return &___U3CU3Ef__amU24cache0_5; }
	inline void set_U3CU3Ef__amU24cache0_5(Action_1_t2621495180 * value)
	{
		___U3CU3Ef__amU24cache0_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
