#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "UnityEngine_UnityEngine_LogType1559732862.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.TaskManager/LogCommand
struct  LogCommand_t1799070289 
{
public:
	// UnityEngine.LogType Foundation.Tasks.TaskManager/LogCommand::Type
	int32_t ___Type_0;
	// System.Object Foundation.Tasks.TaskManager/LogCommand::Message
	Il2CppObject * ___Message_1;

public:
	inline static int32_t get_offset_of_Type_0() { return static_cast<int32_t>(offsetof(LogCommand_t1799070289, ___Type_0)); }
	inline int32_t get_Type_0() const { return ___Type_0; }
	inline int32_t* get_address_of_Type_0() { return &___Type_0; }
	inline void set_Type_0(int32_t value)
	{
		___Type_0 = value;
	}

	inline static int32_t get_offset_of_Message_1() { return static_cast<int32_t>(offsetof(LogCommand_t1799070289, ___Message_1)); }
	inline Il2CppObject * get_Message_1() const { return ___Message_1; }
	inline Il2CppObject ** get_address_of_Message_1() { return &___Message_1; }
	inline void set_Message_1(Il2CppObject * value)
	{
		___Message_1 = value;
		Il2CppCodeGenWriteBarrier(&___Message_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of Foundation.Tasks.TaskManager/LogCommand
struct LogCommand_t1799070289_marshaled_pinvoke
{
	int32_t ___Type_0;
	Il2CppIUnknown* ___Message_1;
};
// Native definition for COM marshalling of Foundation.Tasks.TaskManager/LogCommand
struct LogCommand_t1799070289_marshaled_com
{
	int32_t ___Type_0;
	Il2CppIUnknown* ___Message_1;
};
