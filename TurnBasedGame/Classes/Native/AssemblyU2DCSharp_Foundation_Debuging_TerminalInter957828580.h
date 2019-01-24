#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Action`1<System.String>
struct Action_1_t1831019615;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Debuging.TerminalInterpreter
struct  TerminalInterpreter_t957828580  : public Il2CppObject
{
public:
	// System.String Foundation.Debuging.TerminalInterpreter::Label
	String_t* ___Label_0;
	// System.Action`1<System.String> Foundation.Debuging.TerminalInterpreter::Method
	Action_1_t1831019615 * ___Method_1;

public:
	inline static int32_t get_offset_of_Label_0() { return static_cast<int32_t>(offsetof(TerminalInterpreter_t957828580, ___Label_0)); }
	inline String_t* get_Label_0() const { return ___Label_0; }
	inline String_t** get_address_of_Label_0() { return &___Label_0; }
	inline void set_Label_0(String_t* value)
	{
		___Label_0 = value;
		Il2CppCodeGenWriteBarrier(&___Label_0, value);
	}

	inline static int32_t get_offset_of_Method_1() { return static_cast<int32_t>(offsetof(TerminalInterpreter_t957828580, ___Method_1)); }
	inline Action_1_t1831019615 * get_Method_1() const { return ___Method_1; }
	inline Action_1_t1831019615 ** get_address_of_Method_1() { return &___Method_1; }
	inline void set_Method_1(Action_1_t1831019615 * value)
	{
		___Method_1 = value;
		Il2CppCodeGenWriteBarrier(&___Method_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
