#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.InputRecord
struct  InputRecord_t3971050487 
{
public:
	// System.Int16 System.InputRecord::EventType
	int16_t ___EventType_0;
	// System.Boolean System.InputRecord::KeyDown
	bool ___KeyDown_1;
	// System.Int16 System.InputRecord::RepeatCount
	int16_t ___RepeatCount_2;
	// System.Int16 System.InputRecord::VirtualKeyCode
	int16_t ___VirtualKeyCode_3;
	// System.Int16 System.InputRecord::VirtualScanCode
	int16_t ___VirtualScanCode_4;
	// System.Char System.InputRecord::Character
	Il2CppChar ___Character_5;
	// System.Int32 System.InputRecord::ControlKeyState
	int32_t ___ControlKeyState_6;
	// System.Int32 System.InputRecord::pad1
	int32_t ___pad1_7;
	// System.Boolean System.InputRecord::pad2
	bool ___pad2_8;

public:
	inline static int32_t get_offset_of_EventType_0() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___EventType_0)); }
	inline int16_t get_EventType_0() const { return ___EventType_0; }
	inline int16_t* get_address_of_EventType_0() { return &___EventType_0; }
	inline void set_EventType_0(int16_t value)
	{
		___EventType_0 = value;
	}

	inline static int32_t get_offset_of_KeyDown_1() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___KeyDown_1)); }
	inline bool get_KeyDown_1() const { return ___KeyDown_1; }
	inline bool* get_address_of_KeyDown_1() { return &___KeyDown_1; }
	inline void set_KeyDown_1(bool value)
	{
		___KeyDown_1 = value;
	}

	inline static int32_t get_offset_of_RepeatCount_2() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___RepeatCount_2)); }
	inline int16_t get_RepeatCount_2() const { return ___RepeatCount_2; }
	inline int16_t* get_address_of_RepeatCount_2() { return &___RepeatCount_2; }
	inline void set_RepeatCount_2(int16_t value)
	{
		___RepeatCount_2 = value;
	}

	inline static int32_t get_offset_of_VirtualKeyCode_3() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___VirtualKeyCode_3)); }
	inline int16_t get_VirtualKeyCode_3() const { return ___VirtualKeyCode_3; }
	inline int16_t* get_address_of_VirtualKeyCode_3() { return &___VirtualKeyCode_3; }
	inline void set_VirtualKeyCode_3(int16_t value)
	{
		___VirtualKeyCode_3 = value;
	}

	inline static int32_t get_offset_of_VirtualScanCode_4() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___VirtualScanCode_4)); }
	inline int16_t get_VirtualScanCode_4() const { return ___VirtualScanCode_4; }
	inline int16_t* get_address_of_VirtualScanCode_4() { return &___VirtualScanCode_4; }
	inline void set_VirtualScanCode_4(int16_t value)
	{
		___VirtualScanCode_4 = value;
	}

	inline static int32_t get_offset_of_Character_5() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___Character_5)); }
	inline Il2CppChar get_Character_5() const { return ___Character_5; }
	inline Il2CppChar* get_address_of_Character_5() { return &___Character_5; }
	inline void set_Character_5(Il2CppChar value)
	{
		___Character_5 = value;
	}

	inline static int32_t get_offset_of_ControlKeyState_6() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___ControlKeyState_6)); }
	inline int32_t get_ControlKeyState_6() const { return ___ControlKeyState_6; }
	inline int32_t* get_address_of_ControlKeyState_6() { return &___ControlKeyState_6; }
	inline void set_ControlKeyState_6(int32_t value)
	{
		___ControlKeyState_6 = value;
	}

	inline static int32_t get_offset_of_pad1_7() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___pad1_7)); }
	inline int32_t get_pad1_7() const { return ___pad1_7; }
	inline int32_t* get_address_of_pad1_7() { return &___pad1_7; }
	inline void set_pad1_7(int32_t value)
	{
		___pad1_7 = value;
	}

	inline static int32_t get_offset_of_pad2_8() { return static_cast<int32_t>(offsetof(InputRecord_t3971050487, ___pad2_8)); }
	inline bool get_pad2_8() const { return ___pad2_8; }
	inline bool* get_address_of_pad2_8() { return &___pad2_8; }
	inline void set_pad2_8(bool value)
	{
		___pad2_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.InputRecord
struct InputRecord_t3971050487_marshaled_pinvoke
{
	int16_t ___EventType_0;
	int32_t ___KeyDown_1;
	int16_t ___RepeatCount_2;
	int16_t ___VirtualKeyCode_3;
	int16_t ___VirtualScanCode_4;
	uint8_t ___Character_5;
	int32_t ___ControlKeyState_6;
	int32_t ___pad1_7;
	int32_t ___pad2_8;
};
// Native definition for COM marshalling of System.InputRecord
struct InputRecord_t3971050487_marshaled_com
{
	int16_t ___EventType_0;
	int32_t ___KeyDown_1;
	int16_t ___RepeatCount_2;
	int16_t ___VirtualKeyCode_3;
	int16_t ___VirtualScanCode_4;
	uint8_t ___Character_5;
	int32_t ___ControlKeyState_6;
	int32_t ___pad1_7;
	int32_t ___pad2_8;
};
