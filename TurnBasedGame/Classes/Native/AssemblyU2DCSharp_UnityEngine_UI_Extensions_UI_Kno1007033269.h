#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_UI_Kno3408261084.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_Quaternion4030073918.h"

// UnityEngine.UI.Extensions.KnobFloatValueEvent
struct KnobFloatValueEvent_t2705095779;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UI_Knob
struct  UI_Knob_t1007033269  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.UI_Knob/Direction UnityEngine.UI.Extensions.UI_Knob::direction
	int32_t ___direction_2;
	// System.Single UnityEngine.UI.Extensions.UI_Knob::knobValue
	float ___knobValue_3;
	// System.Single UnityEngine.UI.Extensions.UI_Knob::maxValue
	float ___maxValue_4;
	// System.Int32 UnityEngine.UI.Extensions.UI_Knob::loops
	int32_t ___loops_5;
	// System.Boolean UnityEngine.UI.Extensions.UI_Knob::clampOutput01
	bool ___clampOutput01_6;
	// System.Boolean UnityEngine.UI.Extensions.UI_Knob::snapToPosition
	bool ___snapToPosition_7;
	// System.Int32 UnityEngine.UI.Extensions.UI_Knob::snapStepsPerLoop
	int32_t ___snapStepsPerLoop_8;
	// UnityEngine.UI.Extensions.KnobFloatValueEvent UnityEngine.UI.Extensions.UI_Knob::OnValueChanged
	KnobFloatValueEvent_t2705095779 * ___OnValueChanged_9;
	// System.Single UnityEngine.UI.Extensions.UI_Knob::_currentLoops
	float ____currentLoops_10;
	// System.Single UnityEngine.UI.Extensions.UI_Knob::_previousValue
	float ____previousValue_11;
	// System.Single UnityEngine.UI.Extensions.UI_Knob::_initAngle
	float ____initAngle_12;
	// System.Single UnityEngine.UI.Extensions.UI_Knob::_currentAngle
	float ____currentAngle_13;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UI_Knob::_currentVector
	Vector2_t2243707579  ____currentVector_14;
	// UnityEngine.Quaternion UnityEngine.UI.Extensions.UI_Knob::_initRotation
	Quaternion_t4030073918  ____initRotation_15;
	// System.Boolean UnityEngine.UI.Extensions.UI_Knob::_canDrag
	bool ____canDrag_16;

public:
	inline static int32_t get_offset_of_direction_2() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___direction_2)); }
	inline int32_t get_direction_2() const { return ___direction_2; }
	inline int32_t* get_address_of_direction_2() { return &___direction_2; }
	inline void set_direction_2(int32_t value)
	{
		___direction_2 = value;
	}

	inline static int32_t get_offset_of_knobValue_3() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___knobValue_3)); }
	inline float get_knobValue_3() const { return ___knobValue_3; }
	inline float* get_address_of_knobValue_3() { return &___knobValue_3; }
	inline void set_knobValue_3(float value)
	{
		___knobValue_3 = value;
	}

	inline static int32_t get_offset_of_maxValue_4() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___maxValue_4)); }
	inline float get_maxValue_4() const { return ___maxValue_4; }
	inline float* get_address_of_maxValue_4() { return &___maxValue_4; }
	inline void set_maxValue_4(float value)
	{
		___maxValue_4 = value;
	}

	inline static int32_t get_offset_of_loops_5() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___loops_5)); }
	inline int32_t get_loops_5() const { return ___loops_5; }
	inline int32_t* get_address_of_loops_5() { return &___loops_5; }
	inline void set_loops_5(int32_t value)
	{
		___loops_5 = value;
	}

	inline static int32_t get_offset_of_clampOutput01_6() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___clampOutput01_6)); }
	inline bool get_clampOutput01_6() const { return ___clampOutput01_6; }
	inline bool* get_address_of_clampOutput01_6() { return &___clampOutput01_6; }
	inline void set_clampOutput01_6(bool value)
	{
		___clampOutput01_6 = value;
	}

	inline static int32_t get_offset_of_snapToPosition_7() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___snapToPosition_7)); }
	inline bool get_snapToPosition_7() const { return ___snapToPosition_7; }
	inline bool* get_address_of_snapToPosition_7() { return &___snapToPosition_7; }
	inline void set_snapToPosition_7(bool value)
	{
		___snapToPosition_7 = value;
	}

	inline static int32_t get_offset_of_snapStepsPerLoop_8() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___snapStepsPerLoop_8)); }
	inline int32_t get_snapStepsPerLoop_8() const { return ___snapStepsPerLoop_8; }
	inline int32_t* get_address_of_snapStepsPerLoop_8() { return &___snapStepsPerLoop_8; }
	inline void set_snapStepsPerLoop_8(int32_t value)
	{
		___snapStepsPerLoop_8 = value;
	}

	inline static int32_t get_offset_of_OnValueChanged_9() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ___OnValueChanged_9)); }
	inline KnobFloatValueEvent_t2705095779 * get_OnValueChanged_9() const { return ___OnValueChanged_9; }
	inline KnobFloatValueEvent_t2705095779 ** get_address_of_OnValueChanged_9() { return &___OnValueChanged_9; }
	inline void set_OnValueChanged_9(KnobFloatValueEvent_t2705095779 * value)
	{
		___OnValueChanged_9 = value;
		Il2CppCodeGenWriteBarrier(&___OnValueChanged_9, value);
	}

	inline static int32_t get_offset_of__currentLoops_10() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ____currentLoops_10)); }
	inline float get__currentLoops_10() const { return ____currentLoops_10; }
	inline float* get_address_of__currentLoops_10() { return &____currentLoops_10; }
	inline void set__currentLoops_10(float value)
	{
		____currentLoops_10 = value;
	}

	inline static int32_t get_offset_of__previousValue_11() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ____previousValue_11)); }
	inline float get__previousValue_11() const { return ____previousValue_11; }
	inline float* get_address_of__previousValue_11() { return &____previousValue_11; }
	inline void set__previousValue_11(float value)
	{
		____previousValue_11 = value;
	}

	inline static int32_t get_offset_of__initAngle_12() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ____initAngle_12)); }
	inline float get__initAngle_12() const { return ____initAngle_12; }
	inline float* get_address_of__initAngle_12() { return &____initAngle_12; }
	inline void set__initAngle_12(float value)
	{
		____initAngle_12 = value;
	}

	inline static int32_t get_offset_of__currentAngle_13() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ____currentAngle_13)); }
	inline float get__currentAngle_13() const { return ____currentAngle_13; }
	inline float* get_address_of__currentAngle_13() { return &____currentAngle_13; }
	inline void set__currentAngle_13(float value)
	{
		____currentAngle_13 = value;
	}

	inline static int32_t get_offset_of__currentVector_14() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ____currentVector_14)); }
	inline Vector2_t2243707579  get__currentVector_14() const { return ____currentVector_14; }
	inline Vector2_t2243707579 * get_address_of__currentVector_14() { return &____currentVector_14; }
	inline void set__currentVector_14(Vector2_t2243707579  value)
	{
		____currentVector_14 = value;
	}

	inline static int32_t get_offset_of__initRotation_15() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ____initRotation_15)); }
	inline Quaternion_t4030073918  get__initRotation_15() const { return ____initRotation_15; }
	inline Quaternion_t4030073918 * get_address_of__initRotation_15() { return &____initRotation_15; }
	inline void set__initRotation_15(Quaternion_t4030073918  value)
	{
		____initRotation_15 = value;
	}

	inline static int32_t get_offset_of__canDrag_16() { return static_cast<int32_t>(offsetof(UI_Knob_t1007033269, ____canDrag_16)); }
	inline bool get__canDrag_16() const { return ____canDrag_16; }
	inline bool* get_address_of__canDrag_16() { return &____canDrag_16; }
	inline void set__canDrag_16(bool value)
	{
		____canDrag_16 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
