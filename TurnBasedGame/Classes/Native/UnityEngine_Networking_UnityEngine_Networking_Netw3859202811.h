#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netw3239134783.h"

// System.Type
struct Type_t;
// UnityEngine.Networking.NetworkBehaviour/CmdDelegate
struct CmdDelegate_t2573314724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkBehaviour/Invoker
struct  Invoker_t3859202811  : public Il2CppObject
{
public:
	// UnityEngine.Networking.NetworkBehaviour/UNetInvokeType UnityEngine.Networking.NetworkBehaviour/Invoker::invokeType
	int32_t ___invokeType_0;
	// System.Type UnityEngine.Networking.NetworkBehaviour/Invoker::invokeClass
	Type_t * ___invokeClass_1;
	// UnityEngine.Networking.NetworkBehaviour/CmdDelegate UnityEngine.Networking.NetworkBehaviour/Invoker::invokeFunction
	CmdDelegate_t2573314724 * ___invokeFunction_2;

public:
	inline static int32_t get_offset_of_invokeType_0() { return static_cast<int32_t>(offsetof(Invoker_t3859202811, ___invokeType_0)); }
	inline int32_t get_invokeType_0() const { return ___invokeType_0; }
	inline int32_t* get_address_of_invokeType_0() { return &___invokeType_0; }
	inline void set_invokeType_0(int32_t value)
	{
		___invokeType_0 = value;
	}

	inline static int32_t get_offset_of_invokeClass_1() { return static_cast<int32_t>(offsetof(Invoker_t3859202811, ___invokeClass_1)); }
	inline Type_t * get_invokeClass_1() const { return ___invokeClass_1; }
	inline Type_t ** get_address_of_invokeClass_1() { return &___invokeClass_1; }
	inline void set_invokeClass_1(Type_t * value)
	{
		___invokeClass_1 = value;
		Il2CppCodeGenWriteBarrier(&___invokeClass_1, value);
	}

	inline static int32_t get_offset_of_invokeFunction_2() { return static_cast<int32_t>(offsetof(Invoker_t3859202811, ___invokeFunction_2)); }
	inline CmdDelegate_t2573314724 * get_invokeFunction_2() const { return ___invokeFunction_2; }
	inline CmdDelegate_t2573314724 ** get_address_of_invokeFunction_2() { return &___invokeFunction_2; }
	inline void set_invokeFunction_2(CmdDelegate_t2573314724 * value)
	{
		___invokeFunction_2 = value;
		Il2CppCodeGenWriteBarrier(&___invokeFunction_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
