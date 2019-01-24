#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

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

// Foundation.Databinding.ObservableBehaviour
struct  ObservableBehaviour_t280907994  : public MonoBehaviour_t1158329972
{
public:
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ObservableBehaviour::_onBindingEvent
	Action_1_t2621495180 * ____onBindingEvent_2;
	// Foundation.Databinding.ModelBinder Foundation.Databinding.ObservableBehaviour::_binder
	ModelBinder_t1847346839 * ____binder_3;
	// System.Boolean Foundation.Databinding.ObservableBehaviour::_isDisposed
	bool ____isDisposed_4;
	// Foundation.Databinding.ObservableMessage Foundation.Databinding.ObservableBehaviour::_bindingMessage
	ObservableMessage_t2819695798 * ____bindingMessage_5;
	// System.Boolean Foundation.Databinding.ObservableBehaviour::<IsApplicationQuit>k__BackingField
	bool ___U3CIsApplicationQuitU3Ek__BackingField_6;

public:
	inline static int32_t get_offset_of__onBindingEvent_2() { return static_cast<int32_t>(offsetof(ObservableBehaviour_t280907994, ____onBindingEvent_2)); }
	inline Action_1_t2621495180 * get__onBindingEvent_2() const { return ____onBindingEvent_2; }
	inline Action_1_t2621495180 ** get_address_of__onBindingEvent_2() { return &____onBindingEvent_2; }
	inline void set__onBindingEvent_2(Action_1_t2621495180 * value)
	{
		____onBindingEvent_2 = value;
		Il2CppCodeGenWriteBarrier(&____onBindingEvent_2, value);
	}

	inline static int32_t get_offset_of__binder_3() { return static_cast<int32_t>(offsetof(ObservableBehaviour_t280907994, ____binder_3)); }
	inline ModelBinder_t1847346839 * get__binder_3() const { return ____binder_3; }
	inline ModelBinder_t1847346839 ** get_address_of__binder_3() { return &____binder_3; }
	inline void set__binder_3(ModelBinder_t1847346839 * value)
	{
		____binder_3 = value;
		Il2CppCodeGenWriteBarrier(&____binder_3, value);
	}

	inline static int32_t get_offset_of__isDisposed_4() { return static_cast<int32_t>(offsetof(ObservableBehaviour_t280907994, ____isDisposed_4)); }
	inline bool get__isDisposed_4() const { return ____isDisposed_4; }
	inline bool* get_address_of__isDisposed_4() { return &____isDisposed_4; }
	inline void set__isDisposed_4(bool value)
	{
		____isDisposed_4 = value;
	}

	inline static int32_t get_offset_of__bindingMessage_5() { return static_cast<int32_t>(offsetof(ObservableBehaviour_t280907994, ____bindingMessage_5)); }
	inline ObservableMessage_t2819695798 * get__bindingMessage_5() const { return ____bindingMessage_5; }
	inline ObservableMessage_t2819695798 ** get_address_of__bindingMessage_5() { return &____bindingMessage_5; }
	inline void set__bindingMessage_5(ObservableMessage_t2819695798 * value)
	{
		____bindingMessage_5 = value;
		Il2CppCodeGenWriteBarrier(&____bindingMessage_5, value);
	}

	inline static int32_t get_offset_of_U3CIsApplicationQuitU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(ObservableBehaviour_t280907994, ___U3CIsApplicationQuitU3Ek__BackingField_6)); }
	inline bool get_U3CIsApplicationQuitU3Ek__BackingField_6() const { return ___U3CIsApplicationQuitU3Ek__BackingField_6; }
	inline bool* get_address_of_U3CIsApplicationQuitU3Ek__BackingField_6() { return &___U3CIsApplicationQuitU3Ek__BackingField_6; }
	inline void set_U3CIsApplicationQuitU3Ek__BackingField_6(bool value)
	{
		___U3CIsApplicationQuitU3Ek__BackingField_6 = value;
	}
};

struct ObservableBehaviour_t280907994_StaticFields
{
public:
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ObservableBehaviour::<>f__am$cache0
	Action_1_t2621495180 * ___U3CU3Ef__amU24cache0_7;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_7() { return static_cast<int32_t>(offsetof(ObservableBehaviour_t280907994_StaticFields, ___U3CU3Ef__amU24cache0_7)); }
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
