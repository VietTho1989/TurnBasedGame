#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Net.FtpWebResponse
struct FtpWebResponse_t2609078769;
// System.Threading.ManualResetEvent
struct ManualResetEvent_t926074657;
// System.Exception
struct Exception_t1927440687;
// System.AsyncCallback
struct AsyncCallback_t163412349;
// System.IO.Stream
struct Stream_t3255436806;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.FtpAsyncResult
struct  FtpAsyncResult_t770082413  : public Il2CppObject
{
public:
	// System.Net.FtpWebResponse System.Net.FtpAsyncResult::response
	FtpWebResponse_t2609078769 * ___response_0;
	// System.Threading.ManualResetEvent System.Net.FtpAsyncResult::waitHandle
	ManualResetEvent_t926074657 * ___waitHandle_1;
	// System.Exception System.Net.FtpAsyncResult::exception
	Exception_t1927440687 * ___exception_2;
	// System.AsyncCallback System.Net.FtpAsyncResult::callback
	AsyncCallback_t163412349 * ___callback_3;
	// System.IO.Stream System.Net.FtpAsyncResult::stream
	Stream_t3255436806 * ___stream_4;
	// System.Object System.Net.FtpAsyncResult::state
	Il2CppObject * ___state_5;
	// System.Boolean System.Net.FtpAsyncResult::completed
	bool ___completed_6;
	// System.Boolean System.Net.FtpAsyncResult::synch
	bool ___synch_7;
	// System.Object System.Net.FtpAsyncResult::locker
	Il2CppObject * ___locker_8;

public:
	inline static int32_t get_offset_of_response_0() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___response_0)); }
	inline FtpWebResponse_t2609078769 * get_response_0() const { return ___response_0; }
	inline FtpWebResponse_t2609078769 ** get_address_of_response_0() { return &___response_0; }
	inline void set_response_0(FtpWebResponse_t2609078769 * value)
	{
		___response_0 = value;
		Il2CppCodeGenWriteBarrier(&___response_0, value);
	}

	inline static int32_t get_offset_of_waitHandle_1() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___waitHandle_1)); }
	inline ManualResetEvent_t926074657 * get_waitHandle_1() const { return ___waitHandle_1; }
	inline ManualResetEvent_t926074657 ** get_address_of_waitHandle_1() { return &___waitHandle_1; }
	inline void set_waitHandle_1(ManualResetEvent_t926074657 * value)
	{
		___waitHandle_1 = value;
		Il2CppCodeGenWriteBarrier(&___waitHandle_1, value);
	}

	inline static int32_t get_offset_of_exception_2() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___exception_2)); }
	inline Exception_t1927440687 * get_exception_2() const { return ___exception_2; }
	inline Exception_t1927440687 ** get_address_of_exception_2() { return &___exception_2; }
	inline void set_exception_2(Exception_t1927440687 * value)
	{
		___exception_2 = value;
		Il2CppCodeGenWriteBarrier(&___exception_2, value);
	}

	inline static int32_t get_offset_of_callback_3() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___callback_3)); }
	inline AsyncCallback_t163412349 * get_callback_3() const { return ___callback_3; }
	inline AsyncCallback_t163412349 ** get_address_of_callback_3() { return &___callback_3; }
	inline void set_callback_3(AsyncCallback_t163412349 * value)
	{
		___callback_3 = value;
		Il2CppCodeGenWriteBarrier(&___callback_3, value);
	}

	inline static int32_t get_offset_of_stream_4() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___stream_4)); }
	inline Stream_t3255436806 * get_stream_4() const { return ___stream_4; }
	inline Stream_t3255436806 ** get_address_of_stream_4() { return &___stream_4; }
	inline void set_stream_4(Stream_t3255436806 * value)
	{
		___stream_4 = value;
		Il2CppCodeGenWriteBarrier(&___stream_4, value);
	}

	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___state_5)); }
	inline Il2CppObject * get_state_5() const { return ___state_5; }
	inline Il2CppObject ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(Il2CppObject * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_completed_6() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___completed_6)); }
	inline bool get_completed_6() const { return ___completed_6; }
	inline bool* get_address_of_completed_6() { return &___completed_6; }
	inline void set_completed_6(bool value)
	{
		___completed_6 = value;
	}

	inline static int32_t get_offset_of_synch_7() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___synch_7)); }
	inline bool get_synch_7() const { return ___synch_7; }
	inline bool* get_address_of_synch_7() { return &___synch_7; }
	inline void set_synch_7(bool value)
	{
		___synch_7 = value;
	}

	inline static int32_t get_offset_of_locker_8() { return static_cast<int32_t>(offsetof(FtpAsyncResult_t770082413, ___locker_8)); }
	inline Il2CppObject * get_locker_8() const { return ___locker_8; }
	inline Il2CppObject ** get_address_of_locker_8() { return &___locker_8; }
	inline void set_locker_8(Il2CppObject * value)
	{
		___locker_8 = value;
		Il2CppCodeGenWriteBarrier(&___locker_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
