#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IEnumerator
struct IEnumerator_t1466026749;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Routine
struct  Routine_t2502590640  : public Il2CppObject
{
public:
	// System.Collections.IEnumerator AdvancedCoroutines.Routine::enumerator
	Il2CppObject * ___enumerator_0;
	// System.Object AdvancedCoroutines.Routine::obj
	Il2CppObject * ___obj_1;
	// System.Single AdvancedCoroutines.Routine::workTime
	float ___workTime_2;
	// System.Single AdvancedCoroutines.Routine::startTime
	float ___startTime_3;
	// System.Boolean AdvancedCoroutines.Routine::isPaused
	bool ___isPaused_4;
	// System.Boolean AdvancedCoroutines.Routine::isStandalone
	bool ___isStandalone_5;
	// System.Boolean AdvancedCoroutines.Routine::needToCheckEndOfUpdate
	bool ___needToCheckEndOfUpdate_6;
	// System.Boolean AdvancedCoroutines.Routine::needToCheckPostRender
	bool ___needToCheckPostRender_7;

public:
	inline static int32_t get_offset_of_enumerator_0() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___enumerator_0)); }
	inline Il2CppObject * get_enumerator_0() const { return ___enumerator_0; }
	inline Il2CppObject ** get_address_of_enumerator_0() { return &___enumerator_0; }
	inline void set_enumerator_0(Il2CppObject * value)
	{
		___enumerator_0 = value;
		Il2CppCodeGenWriteBarrier(&___enumerator_0, value);
	}

	inline static int32_t get_offset_of_obj_1() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___obj_1)); }
	inline Il2CppObject * get_obj_1() const { return ___obj_1; }
	inline Il2CppObject ** get_address_of_obj_1() { return &___obj_1; }
	inline void set_obj_1(Il2CppObject * value)
	{
		___obj_1 = value;
		Il2CppCodeGenWriteBarrier(&___obj_1, value);
	}

	inline static int32_t get_offset_of_workTime_2() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___workTime_2)); }
	inline float get_workTime_2() const { return ___workTime_2; }
	inline float* get_address_of_workTime_2() { return &___workTime_2; }
	inline void set_workTime_2(float value)
	{
		___workTime_2 = value;
	}

	inline static int32_t get_offset_of_startTime_3() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___startTime_3)); }
	inline float get_startTime_3() const { return ___startTime_3; }
	inline float* get_address_of_startTime_3() { return &___startTime_3; }
	inline void set_startTime_3(float value)
	{
		___startTime_3 = value;
	}

	inline static int32_t get_offset_of_isPaused_4() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___isPaused_4)); }
	inline bool get_isPaused_4() const { return ___isPaused_4; }
	inline bool* get_address_of_isPaused_4() { return &___isPaused_4; }
	inline void set_isPaused_4(bool value)
	{
		___isPaused_4 = value;
	}

	inline static int32_t get_offset_of_isStandalone_5() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___isStandalone_5)); }
	inline bool get_isStandalone_5() const { return ___isStandalone_5; }
	inline bool* get_address_of_isStandalone_5() { return &___isStandalone_5; }
	inline void set_isStandalone_5(bool value)
	{
		___isStandalone_5 = value;
	}

	inline static int32_t get_offset_of_needToCheckEndOfUpdate_6() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___needToCheckEndOfUpdate_6)); }
	inline bool get_needToCheckEndOfUpdate_6() const { return ___needToCheckEndOfUpdate_6; }
	inline bool* get_address_of_needToCheckEndOfUpdate_6() { return &___needToCheckEndOfUpdate_6; }
	inline void set_needToCheckEndOfUpdate_6(bool value)
	{
		___needToCheckEndOfUpdate_6 = value;
	}

	inline static int32_t get_offset_of_needToCheckPostRender_7() { return static_cast<int32_t>(offsetof(Routine_t2502590640, ___needToCheckPostRender_7)); }
	inline bool get_needToCheckPostRender_7() const { return ___needToCheckPostRender_7; }
	inline bool* get_address_of_needToCheckPostRender_7() { return &___needToCheckPostRender_7; }
	inline void set_needToCheckPostRender_7(bool value)
	{
		___needToCheckPostRender_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
