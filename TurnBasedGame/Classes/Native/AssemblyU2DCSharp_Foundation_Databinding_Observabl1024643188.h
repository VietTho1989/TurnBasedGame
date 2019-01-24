#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

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

// Foundation.Databinding.ObservableObject
struct  ObservableObject_t1024643188  : public Il2CppObject
{
public:
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ObservableObject::_onBindingEvent
	Action_1_t2621495180 * ____onBindingEvent_0;
	// Foundation.Databinding.ModelBinder Foundation.Databinding.ObservableObject::_binder
	ModelBinder_t1847346839 * ____binder_1;
	// Foundation.Databinding.ObservableMessage Foundation.Databinding.ObservableObject::_bindingMessage
	ObservableMessage_t2819695798 * ____bindingMessage_2;

public:
	inline static int32_t get_offset_of__onBindingEvent_0() { return static_cast<int32_t>(offsetof(ObservableObject_t1024643188, ____onBindingEvent_0)); }
	inline Action_1_t2621495180 * get__onBindingEvent_0() const { return ____onBindingEvent_0; }
	inline Action_1_t2621495180 ** get_address_of__onBindingEvent_0() { return &____onBindingEvent_0; }
	inline void set__onBindingEvent_0(Action_1_t2621495180 * value)
	{
		____onBindingEvent_0 = value;
		Il2CppCodeGenWriteBarrier(&____onBindingEvent_0, value);
	}

	inline static int32_t get_offset_of__binder_1() { return static_cast<int32_t>(offsetof(ObservableObject_t1024643188, ____binder_1)); }
	inline ModelBinder_t1847346839 * get__binder_1() const { return ____binder_1; }
	inline ModelBinder_t1847346839 ** get_address_of__binder_1() { return &____binder_1; }
	inline void set__binder_1(ModelBinder_t1847346839 * value)
	{
		____binder_1 = value;
		Il2CppCodeGenWriteBarrier(&____binder_1, value);
	}

	inline static int32_t get_offset_of__bindingMessage_2() { return static_cast<int32_t>(offsetof(ObservableObject_t1024643188, ____bindingMessage_2)); }
	inline ObservableMessage_t2819695798 * get__bindingMessage_2() const { return ____bindingMessage_2; }
	inline ObservableMessage_t2819695798 ** get_address_of__bindingMessage_2() { return &____bindingMessage_2; }
	inline void set__bindingMessage_2(ObservableMessage_t2819695798 * value)
	{
		____bindingMessage_2 = value;
		Il2CppCodeGenWriteBarrier(&____bindingMessage_2, value);
	}
};

struct ObservableObject_t1024643188_StaticFields
{
public:
	// System.Action`1<Foundation.Databinding.ObservableMessage> Foundation.Databinding.ObservableObject::<>f__am$cache0
	Action_1_t2621495180 * ___U3CU3Ef__amU24cache0_3;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_3() { return static_cast<int32_t>(offsetof(ObservableObject_t1024643188_StaticFields, ___U3CU3Ef__amU24cache0_3)); }
	inline Action_1_t2621495180 * get_U3CU3Ef__amU24cache0_3() const { return ___U3CU3Ef__amU24cache0_3; }
	inline Action_1_t2621495180 ** get_address_of_U3CU3Ef__amU24cache0_3() { return &___U3CU3Ef__amU24cache0_3; }
	inline void set_U3CU3Ef__amU24cache0_3(Action_1_t2621495180 * value)
	{
		___U3CU3Ef__amU24cache0_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
