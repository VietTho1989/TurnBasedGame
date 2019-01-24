#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameActionsUI_UIData_Sub2280453533.h"

// VP`1<ReferenceData`1<WaitInputAction>>
struct VP_1_t1332039126;
// VP`1<WaitInputActionUI/UIData/Sub>
struct VP_1_t831651163;
// VP`1<ClientInputUI/UIData>
struct VP_1_t3210448488;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitInputActionUI/UIData
struct  UIData_t1551346322  : public Sub_t2280453533
{
public:
	// VP`1<ReferenceData`1<WaitInputAction>> WaitInputActionUI/UIData::waitInputAction
	VP_1_t1332039126 * ___waitInputAction_5;
	// VP`1<WaitInputActionUI/UIData/Sub> WaitInputActionUI/UIData::sub
	VP_1_t831651163 * ___sub_6;
	// VP`1<ClientInputUI/UIData> WaitInputActionUI/UIData::clientInputUIData
	VP_1_t3210448488 * ___clientInputUIData_7;

public:
	inline static int32_t get_offset_of_waitInputAction_5() { return static_cast<int32_t>(offsetof(UIData_t1551346322, ___waitInputAction_5)); }
	inline VP_1_t1332039126 * get_waitInputAction_5() const { return ___waitInputAction_5; }
	inline VP_1_t1332039126 ** get_address_of_waitInputAction_5() { return &___waitInputAction_5; }
	inline void set_waitInputAction_5(VP_1_t1332039126 * value)
	{
		___waitInputAction_5 = value;
		Il2CppCodeGenWriteBarrier(&___waitInputAction_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t1551346322, ___sub_6)); }
	inline VP_1_t831651163 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t831651163 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t831651163 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}

	inline static int32_t get_offset_of_clientInputUIData_7() { return static_cast<int32_t>(offsetof(UIData_t1551346322, ___clientInputUIData_7)); }
	inline VP_1_t3210448488 * get_clientInputUIData_7() const { return ___clientInputUIData_7; }
	inline VP_1_t3210448488 ** get_address_of_clientInputUIData_7() { return &___clientInputUIData_7; }
	inline void set_clientInputUIData_7(VP_1_t3210448488 * value)
	{
		___clientInputUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___clientInputUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
