#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IO.TextWriter
struct TextWriter_t4027217640;
// System.IO.TextReader
struct TextReader_t1561828458;
// System.Text.Encoding
struct Encoding_t663144255;
// System.ConsoleCancelEventHandler
struct ConsoleCancelEventHandler_t1138054497;
// System.Console/InternalCancelHandler
struct InternalCancelHandler_t2895223116;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Console
struct  Console_t2311202731  : public Il2CppObject
{
public:

public:
};

struct Console_t2311202731_StaticFields
{
public:
	// System.IO.TextWriter System.Console::stdout
	TextWriter_t4027217640 * ___stdout_0;
	// System.IO.TextWriter System.Console::stderr
	TextWriter_t4027217640 * ___stderr_1;
	// System.IO.TextReader System.Console::stdin
	TextReader_t1561828458 * ___stdin_2;
	// System.Text.Encoding System.Console::inputEncoding
	Encoding_t663144255 * ___inputEncoding_3;
	// System.Text.Encoding System.Console::outputEncoding
	Encoding_t663144255 * ___outputEncoding_4;
	// System.ConsoleCancelEventHandler System.Console::cancel_event
	ConsoleCancelEventHandler_t1138054497 * ___cancel_event_5;
	// System.Console/InternalCancelHandler System.Console::cancel_handler
	InternalCancelHandler_t2895223116 * ___cancel_handler_6;

public:
	inline static int32_t get_offset_of_stdout_0() { return static_cast<int32_t>(offsetof(Console_t2311202731_StaticFields, ___stdout_0)); }
	inline TextWriter_t4027217640 * get_stdout_0() const { return ___stdout_0; }
	inline TextWriter_t4027217640 ** get_address_of_stdout_0() { return &___stdout_0; }
	inline void set_stdout_0(TextWriter_t4027217640 * value)
	{
		___stdout_0 = value;
		Il2CppCodeGenWriteBarrier(&___stdout_0, value);
	}

	inline static int32_t get_offset_of_stderr_1() { return static_cast<int32_t>(offsetof(Console_t2311202731_StaticFields, ___stderr_1)); }
	inline TextWriter_t4027217640 * get_stderr_1() const { return ___stderr_1; }
	inline TextWriter_t4027217640 ** get_address_of_stderr_1() { return &___stderr_1; }
	inline void set_stderr_1(TextWriter_t4027217640 * value)
	{
		___stderr_1 = value;
		Il2CppCodeGenWriteBarrier(&___stderr_1, value);
	}

	inline static int32_t get_offset_of_stdin_2() { return static_cast<int32_t>(offsetof(Console_t2311202731_StaticFields, ___stdin_2)); }
	inline TextReader_t1561828458 * get_stdin_2() const { return ___stdin_2; }
	inline TextReader_t1561828458 ** get_address_of_stdin_2() { return &___stdin_2; }
	inline void set_stdin_2(TextReader_t1561828458 * value)
	{
		___stdin_2 = value;
		Il2CppCodeGenWriteBarrier(&___stdin_2, value);
	}

	inline static int32_t get_offset_of_inputEncoding_3() { return static_cast<int32_t>(offsetof(Console_t2311202731_StaticFields, ___inputEncoding_3)); }
	inline Encoding_t663144255 * get_inputEncoding_3() const { return ___inputEncoding_3; }
	inline Encoding_t663144255 ** get_address_of_inputEncoding_3() { return &___inputEncoding_3; }
	inline void set_inputEncoding_3(Encoding_t663144255 * value)
	{
		___inputEncoding_3 = value;
		Il2CppCodeGenWriteBarrier(&___inputEncoding_3, value);
	}

	inline static int32_t get_offset_of_outputEncoding_4() { return static_cast<int32_t>(offsetof(Console_t2311202731_StaticFields, ___outputEncoding_4)); }
	inline Encoding_t663144255 * get_outputEncoding_4() const { return ___outputEncoding_4; }
	inline Encoding_t663144255 ** get_address_of_outputEncoding_4() { return &___outputEncoding_4; }
	inline void set_outputEncoding_4(Encoding_t663144255 * value)
	{
		___outputEncoding_4 = value;
		Il2CppCodeGenWriteBarrier(&___outputEncoding_4, value);
	}

	inline static int32_t get_offset_of_cancel_event_5() { return static_cast<int32_t>(offsetof(Console_t2311202731_StaticFields, ___cancel_event_5)); }
	inline ConsoleCancelEventHandler_t1138054497 * get_cancel_event_5() const { return ___cancel_event_5; }
	inline ConsoleCancelEventHandler_t1138054497 ** get_address_of_cancel_event_5() { return &___cancel_event_5; }
	inline void set_cancel_event_5(ConsoleCancelEventHandler_t1138054497 * value)
	{
		___cancel_event_5 = value;
		Il2CppCodeGenWriteBarrier(&___cancel_event_5, value);
	}

	inline static int32_t get_offset_of_cancel_handler_6() { return static_cast<int32_t>(offsetof(Console_t2311202731_StaticFields, ___cancel_handler_6)); }
	inline InternalCancelHandler_t2895223116 * get_cancel_handler_6() const { return ___cancel_handler_6; }
	inline InternalCancelHandler_t2895223116 ** get_address_of_cancel_handler_6() { return &___cancel_handler_6; }
	inline void set_cancel_handler_6(InternalCancelHandler_t2895223116 * value)
	{
		___cancel_handler_6 = value;
		Il2CppCodeGenWriteBarrier(&___cancel_handler_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
