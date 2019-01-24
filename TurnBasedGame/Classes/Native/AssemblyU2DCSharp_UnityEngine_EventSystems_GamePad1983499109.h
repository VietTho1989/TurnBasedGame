#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_EventSystems_BaseInputM1295781545.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.EventSystems.GamePadInputModule
struct  GamePadInputModule_t1983499109  : public BaseInputModule_t1295781545
{
public:
	// System.Single UnityEngine.EventSystems.GamePadInputModule::m_PrevActionTime
	float ___m_PrevActionTime_8;
	// UnityEngine.Vector2 UnityEngine.EventSystems.GamePadInputModule::m_LastMoveVector
	Vector2_t2243707579  ___m_LastMoveVector_9;
	// System.Int32 UnityEngine.EventSystems.GamePadInputModule::m_ConsecutiveMoveCount
	int32_t ___m_ConsecutiveMoveCount_10;
	// System.String UnityEngine.EventSystems.GamePadInputModule::m_HorizontalAxis
	String_t* ___m_HorizontalAxis_11;
	// System.String UnityEngine.EventSystems.GamePadInputModule::m_VerticalAxis
	String_t* ___m_VerticalAxis_12;
	// System.String UnityEngine.EventSystems.GamePadInputModule::m_SubmitButton
	String_t* ___m_SubmitButton_13;
	// System.String UnityEngine.EventSystems.GamePadInputModule::m_CancelButton
	String_t* ___m_CancelButton_14;
	// System.Single UnityEngine.EventSystems.GamePadInputModule::m_InputActionsPerSecond
	float ___m_InputActionsPerSecond_15;
	// System.Single UnityEngine.EventSystems.GamePadInputModule::m_RepeatDelay
	float ___m_RepeatDelay_16;

public:
	inline static int32_t get_offset_of_m_PrevActionTime_8() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_PrevActionTime_8)); }
	inline float get_m_PrevActionTime_8() const { return ___m_PrevActionTime_8; }
	inline float* get_address_of_m_PrevActionTime_8() { return &___m_PrevActionTime_8; }
	inline void set_m_PrevActionTime_8(float value)
	{
		___m_PrevActionTime_8 = value;
	}

	inline static int32_t get_offset_of_m_LastMoveVector_9() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_LastMoveVector_9)); }
	inline Vector2_t2243707579  get_m_LastMoveVector_9() const { return ___m_LastMoveVector_9; }
	inline Vector2_t2243707579 * get_address_of_m_LastMoveVector_9() { return &___m_LastMoveVector_9; }
	inline void set_m_LastMoveVector_9(Vector2_t2243707579  value)
	{
		___m_LastMoveVector_9 = value;
	}

	inline static int32_t get_offset_of_m_ConsecutiveMoveCount_10() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_ConsecutiveMoveCount_10)); }
	inline int32_t get_m_ConsecutiveMoveCount_10() const { return ___m_ConsecutiveMoveCount_10; }
	inline int32_t* get_address_of_m_ConsecutiveMoveCount_10() { return &___m_ConsecutiveMoveCount_10; }
	inline void set_m_ConsecutiveMoveCount_10(int32_t value)
	{
		___m_ConsecutiveMoveCount_10 = value;
	}

	inline static int32_t get_offset_of_m_HorizontalAxis_11() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_HorizontalAxis_11)); }
	inline String_t* get_m_HorizontalAxis_11() const { return ___m_HorizontalAxis_11; }
	inline String_t** get_address_of_m_HorizontalAxis_11() { return &___m_HorizontalAxis_11; }
	inline void set_m_HorizontalAxis_11(String_t* value)
	{
		___m_HorizontalAxis_11 = value;
		Il2CppCodeGenWriteBarrier(&___m_HorizontalAxis_11, value);
	}

	inline static int32_t get_offset_of_m_VerticalAxis_12() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_VerticalAxis_12)); }
	inline String_t* get_m_VerticalAxis_12() const { return ___m_VerticalAxis_12; }
	inline String_t** get_address_of_m_VerticalAxis_12() { return &___m_VerticalAxis_12; }
	inline void set_m_VerticalAxis_12(String_t* value)
	{
		___m_VerticalAxis_12 = value;
		Il2CppCodeGenWriteBarrier(&___m_VerticalAxis_12, value);
	}

	inline static int32_t get_offset_of_m_SubmitButton_13() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_SubmitButton_13)); }
	inline String_t* get_m_SubmitButton_13() const { return ___m_SubmitButton_13; }
	inline String_t** get_address_of_m_SubmitButton_13() { return &___m_SubmitButton_13; }
	inline void set_m_SubmitButton_13(String_t* value)
	{
		___m_SubmitButton_13 = value;
		Il2CppCodeGenWriteBarrier(&___m_SubmitButton_13, value);
	}

	inline static int32_t get_offset_of_m_CancelButton_14() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_CancelButton_14)); }
	inline String_t* get_m_CancelButton_14() const { return ___m_CancelButton_14; }
	inline String_t** get_address_of_m_CancelButton_14() { return &___m_CancelButton_14; }
	inline void set_m_CancelButton_14(String_t* value)
	{
		___m_CancelButton_14 = value;
		Il2CppCodeGenWriteBarrier(&___m_CancelButton_14, value);
	}

	inline static int32_t get_offset_of_m_InputActionsPerSecond_15() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_InputActionsPerSecond_15)); }
	inline float get_m_InputActionsPerSecond_15() const { return ___m_InputActionsPerSecond_15; }
	inline float* get_address_of_m_InputActionsPerSecond_15() { return &___m_InputActionsPerSecond_15; }
	inline void set_m_InputActionsPerSecond_15(float value)
	{
		___m_InputActionsPerSecond_15 = value;
	}

	inline static int32_t get_offset_of_m_RepeatDelay_16() { return static_cast<int32_t>(offsetof(GamePadInputModule_t1983499109, ___m_RepeatDelay_16)); }
	inline float get_m_RepeatDelay_16() const { return ___m_RepeatDelay_16; }
	inline float* get_address_of_m_RepeatDelay_16() { return &___m_RepeatDelay_16; }
	inline void set_m_RepeatDelay_16(float value)
	{
		___m_RepeatDelay_16 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
