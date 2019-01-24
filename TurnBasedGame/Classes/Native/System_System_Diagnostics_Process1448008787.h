#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_ComponentModel_Component2826673791.h"
#include "mscorlib_System_IntPtr2504060609.h"

// System.ComponentModel.ISynchronizeInvoke
struct ISynchronizeInvoke_t2917099865;
// System.EventHandler
struct EventHandler_t277755526;
// System.String
struct String_t;
// System.IO.StreamReader
struct StreamReader_t2360341767;
// System.IO.StreamWriter
struct StreamWriter_t3858580635;
// System.Diagnostics.ProcessStartInfo
struct ProcessStartInfo_t2898458543;
// System.Diagnostics.Process/ProcessAsyncReader
struct ProcessAsyncReader_t2663114743;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Diagnostics.Process
struct  Process_t1448008787  : public Component_t2826673791
{
public:
	// System.IntPtr System.Diagnostics.Process::process_handle
	IntPtr_t ___process_handle_4;
	// System.Int32 System.Diagnostics.Process::pid
	int32_t ___pid_5;
	// System.Boolean System.Diagnostics.Process::enableRaisingEvents
	bool ___enableRaisingEvents_6;
	// System.Boolean System.Diagnostics.Process::already_waiting
	bool ___already_waiting_7;
	// System.ComponentModel.ISynchronizeInvoke System.Diagnostics.Process::synchronizingObject
	Il2CppObject * ___synchronizingObject_8;
	// System.EventHandler System.Diagnostics.Process::exited_event
	EventHandler_t277755526 * ___exited_event_9;
	// System.IntPtr System.Diagnostics.Process::stdout_rd
	IntPtr_t ___stdout_rd_10;
	// System.IntPtr System.Diagnostics.Process::stderr_rd
	IntPtr_t ___stderr_rd_11;
	// System.String System.Diagnostics.Process::process_name
	String_t* ___process_name_12;
	// System.IO.StreamReader System.Diagnostics.Process::error_stream
	StreamReader_t2360341767 * ___error_stream_13;
	// System.IO.StreamWriter System.Diagnostics.Process::input_stream
	StreamWriter_t3858580635 * ___input_stream_14;
	// System.IO.StreamReader System.Diagnostics.Process::output_stream
	StreamReader_t2360341767 * ___output_stream_15;
	// System.Diagnostics.ProcessStartInfo System.Diagnostics.Process::start_info
	ProcessStartInfo_t2898458543 * ___start_info_16;
	// System.Diagnostics.Process/ProcessAsyncReader System.Diagnostics.Process::async_output
	ProcessAsyncReader_t2663114743 * ___async_output_17;
	// System.Diagnostics.Process/ProcessAsyncReader System.Diagnostics.Process::async_error
	ProcessAsyncReader_t2663114743 * ___async_error_18;
	// System.Boolean System.Diagnostics.Process::disposed
	bool ___disposed_19;

public:
	inline static int32_t get_offset_of_process_handle_4() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___process_handle_4)); }
	inline IntPtr_t get_process_handle_4() const { return ___process_handle_4; }
	inline IntPtr_t* get_address_of_process_handle_4() { return &___process_handle_4; }
	inline void set_process_handle_4(IntPtr_t value)
	{
		___process_handle_4 = value;
	}

	inline static int32_t get_offset_of_pid_5() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___pid_5)); }
	inline int32_t get_pid_5() const { return ___pid_5; }
	inline int32_t* get_address_of_pid_5() { return &___pid_5; }
	inline void set_pid_5(int32_t value)
	{
		___pid_5 = value;
	}

	inline static int32_t get_offset_of_enableRaisingEvents_6() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___enableRaisingEvents_6)); }
	inline bool get_enableRaisingEvents_6() const { return ___enableRaisingEvents_6; }
	inline bool* get_address_of_enableRaisingEvents_6() { return &___enableRaisingEvents_6; }
	inline void set_enableRaisingEvents_6(bool value)
	{
		___enableRaisingEvents_6 = value;
	}

	inline static int32_t get_offset_of_already_waiting_7() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___already_waiting_7)); }
	inline bool get_already_waiting_7() const { return ___already_waiting_7; }
	inline bool* get_address_of_already_waiting_7() { return &___already_waiting_7; }
	inline void set_already_waiting_7(bool value)
	{
		___already_waiting_7 = value;
	}

	inline static int32_t get_offset_of_synchronizingObject_8() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___synchronizingObject_8)); }
	inline Il2CppObject * get_synchronizingObject_8() const { return ___synchronizingObject_8; }
	inline Il2CppObject ** get_address_of_synchronizingObject_8() { return &___synchronizingObject_8; }
	inline void set_synchronizingObject_8(Il2CppObject * value)
	{
		___synchronizingObject_8 = value;
		Il2CppCodeGenWriteBarrier(&___synchronizingObject_8, value);
	}

	inline static int32_t get_offset_of_exited_event_9() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___exited_event_9)); }
	inline EventHandler_t277755526 * get_exited_event_9() const { return ___exited_event_9; }
	inline EventHandler_t277755526 ** get_address_of_exited_event_9() { return &___exited_event_9; }
	inline void set_exited_event_9(EventHandler_t277755526 * value)
	{
		___exited_event_9 = value;
		Il2CppCodeGenWriteBarrier(&___exited_event_9, value);
	}

	inline static int32_t get_offset_of_stdout_rd_10() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___stdout_rd_10)); }
	inline IntPtr_t get_stdout_rd_10() const { return ___stdout_rd_10; }
	inline IntPtr_t* get_address_of_stdout_rd_10() { return &___stdout_rd_10; }
	inline void set_stdout_rd_10(IntPtr_t value)
	{
		___stdout_rd_10 = value;
	}

	inline static int32_t get_offset_of_stderr_rd_11() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___stderr_rd_11)); }
	inline IntPtr_t get_stderr_rd_11() const { return ___stderr_rd_11; }
	inline IntPtr_t* get_address_of_stderr_rd_11() { return &___stderr_rd_11; }
	inline void set_stderr_rd_11(IntPtr_t value)
	{
		___stderr_rd_11 = value;
	}

	inline static int32_t get_offset_of_process_name_12() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___process_name_12)); }
	inline String_t* get_process_name_12() const { return ___process_name_12; }
	inline String_t** get_address_of_process_name_12() { return &___process_name_12; }
	inline void set_process_name_12(String_t* value)
	{
		___process_name_12 = value;
		Il2CppCodeGenWriteBarrier(&___process_name_12, value);
	}

	inline static int32_t get_offset_of_error_stream_13() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___error_stream_13)); }
	inline StreamReader_t2360341767 * get_error_stream_13() const { return ___error_stream_13; }
	inline StreamReader_t2360341767 ** get_address_of_error_stream_13() { return &___error_stream_13; }
	inline void set_error_stream_13(StreamReader_t2360341767 * value)
	{
		___error_stream_13 = value;
		Il2CppCodeGenWriteBarrier(&___error_stream_13, value);
	}

	inline static int32_t get_offset_of_input_stream_14() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___input_stream_14)); }
	inline StreamWriter_t3858580635 * get_input_stream_14() const { return ___input_stream_14; }
	inline StreamWriter_t3858580635 ** get_address_of_input_stream_14() { return &___input_stream_14; }
	inline void set_input_stream_14(StreamWriter_t3858580635 * value)
	{
		___input_stream_14 = value;
		Il2CppCodeGenWriteBarrier(&___input_stream_14, value);
	}

	inline static int32_t get_offset_of_output_stream_15() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___output_stream_15)); }
	inline StreamReader_t2360341767 * get_output_stream_15() const { return ___output_stream_15; }
	inline StreamReader_t2360341767 ** get_address_of_output_stream_15() { return &___output_stream_15; }
	inline void set_output_stream_15(StreamReader_t2360341767 * value)
	{
		___output_stream_15 = value;
		Il2CppCodeGenWriteBarrier(&___output_stream_15, value);
	}

	inline static int32_t get_offset_of_start_info_16() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___start_info_16)); }
	inline ProcessStartInfo_t2898458543 * get_start_info_16() const { return ___start_info_16; }
	inline ProcessStartInfo_t2898458543 ** get_address_of_start_info_16() { return &___start_info_16; }
	inline void set_start_info_16(ProcessStartInfo_t2898458543 * value)
	{
		___start_info_16 = value;
		Il2CppCodeGenWriteBarrier(&___start_info_16, value);
	}

	inline static int32_t get_offset_of_async_output_17() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___async_output_17)); }
	inline ProcessAsyncReader_t2663114743 * get_async_output_17() const { return ___async_output_17; }
	inline ProcessAsyncReader_t2663114743 ** get_address_of_async_output_17() { return &___async_output_17; }
	inline void set_async_output_17(ProcessAsyncReader_t2663114743 * value)
	{
		___async_output_17 = value;
		Il2CppCodeGenWriteBarrier(&___async_output_17, value);
	}

	inline static int32_t get_offset_of_async_error_18() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___async_error_18)); }
	inline ProcessAsyncReader_t2663114743 * get_async_error_18() const { return ___async_error_18; }
	inline ProcessAsyncReader_t2663114743 ** get_address_of_async_error_18() { return &___async_error_18; }
	inline void set_async_error_18(ProcessAsyncReader_t2663114743 * value)
	{
		___async_error_18 = value;
		Il2CppCodeGenWriteBarrier(&___async_error_18, value);
	}

	inline static int32_t get_offset_of_disposed_19() { return static_cast<int32_t>(offsetof(Process_t1448008787, ___disposed_19)); }
	inline bool get_disposed_19() const { return ___disposed_19; }
	inline bool* get_address_of_disposed_19() { return &___disposed_19; }
	inline void set_disposed_19(bool value)
	{
		___disposed_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
