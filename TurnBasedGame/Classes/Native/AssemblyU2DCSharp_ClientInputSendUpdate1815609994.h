#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3809738666.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Server
struct Server_t2724320767;
// WaitInputAction
struct WaitInputAction_t1882979057;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientInputSendUpdate
struct  ClientInputSendUpdate_t1815609994  : public UpdateBehavior_1_t3809738666
{
public:
	// AdvancedCoroutines.Routine ClientInputSendUpdate::waitToResend
	Routine_t2502590640 * ___waitToResend_4;
	// Server ClientInputSendUpdate::server
	Server_t2724320767 * ___server_5;
	// System.Boolean ClientInputSendUpdate::haveChange
	bool ___haveChange_6;
	// WaitInputAction ClientInputSendUpdate::waitInputAction
	WaitInputAction_t1882979057 * ___waitInputAction_7;

public:
	inline static int32_t get_offset_of_waitToResend_4() { return static_cast<int32_t>(offsetof(ClientInputSendUpdate_t1815609994, ___waitToResend_4)); }
	inline Routine_t2502590640 * get_waitToResend_4() const { return ___waitToResend_4; }
	inline Routine_t2502590640 ** get_address_of_waitToResend_4() { return &___waitToResend_4; }
	inline void set_waitToResend_4(Routine_t2502590640 * value)
	{
		___waitToResend_4 = value;
		Il2CppCodeGenWriteBarrier(&___waitToResend_4, value);
	}

	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(ClientInputSendUpdate_t1815609994, ___server_5)); }
	inline Server_t2724320767 * get_server_5() const { return ___server_5; }
	inline Server_t2724320767 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(Server_t2724320767 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_haveChange_6() { return static_cast<int32_t>(offsetof(ClientInputSendUpdate_t1815609994, ___haveChange_6)); }
	inline bool get_haveChange_6() const { return ___haveChange_6; }
	inline bool* get_address_of_haveChange_6() { return &___haveChange_6; }
	inline void set_haveChange_6(bool value)
	{
		___haveChange_6 = value;
	}

	inline static int32_t get_offset_of_waitInputAction_7() { return static_cast<int32_t>(offsetof(ClientInputSendUpdate_t1815609994, ___waitInputAction_7)); }
	inline WaitInputAction_t1882979057 * get_waitInputAction_7() const { return ___waitInputAction_7; }
	inline WaitInputAction_t1882979057 ** get_address_of_waitInputAction_7() { return &___waitInputAction_7; }
	inline void set_waitInputAction_7(WaitInputAction_t1882979057 * value)
	{
		___waitInputAction_7 = value;
		Il2CppCodeGenWriteBarrier(&___waitInputAction_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
