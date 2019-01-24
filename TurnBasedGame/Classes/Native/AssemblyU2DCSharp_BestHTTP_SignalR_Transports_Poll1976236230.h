#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_SignalR_Transports_Post4137891006.h"
#include "mscorlib_System_DateTime693205669.h"
#include "mscorlib_System_TimeSpan3430258949.h"

// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Transports.PollingTransport
struct  PollingTransport_t1976236230  : public PostSendTransportBase_t4137891006
{
public:
	// System.DateTime BestHTTP.SignalR.Transports.PollingTransport::LastPoll
	DateTime_t693205669  ___LastPoll_6;
	// System.TimeSpan BestHTTP.SignalR.Transports.PollingTransport::PollDelay
	TimeSpan_t3430258949  ___PollDelay_7;
	// System.TimeSpan BestHTTP.SignalR.Transports.PollingTransport::PollTimeout
	TimeSpan_t3430258949  ___PollTimeout_8;
	// BestHTTP.HTTPRequest BestHTTP.SignalR.Transports.PollingTransport::pollRequest
	HTTPRequest_t138485887 * ___pollRequest_9;

public:
	inline static int32_t get_offset_of_LastPoll_6() { return static_cast<int32_t>(offsetof(PollingTransport_t1976236230, ___LastPoll_6)); }
	inline DateTime_t693205669  get_LastPoll_6() const { return ___LastPoll_6; }
	inline DateTime_t693205669 * get_address_of_LastPoll_6() { return &___LastPoll_6; }
	inline void set_LastPoll_6(DateTime_t693205669  value)
	{
		___LastPoll_6 = value;
	}

	inline static int32_t get_offset_of_PollDelay_7() { return static_cast<int32_t>(offsetof(PollingTransport_t1976236230, ___PollDelay_7)); }
	inline TimeSpan_t3430258949  get_PollDelay_7() const { return ___PollDelay_7; }
	inline TimeSpan_t3430258949 * get_address_of_PollDelay_7() { return &___PollDelay_7; }
	inline void set_PollDelay_7(TimeSpan_t3430258949  value)
	{
		___PollDelay_7 = value;
	}

	inline static int32_t get_offset_of_PollTimeout_8() { return static_cast<int32_t>(offsetof(PollingTransport_t1976236230, ___PollTimeout_8)); }
	inline TimeSpan_t3430258949  get_PollTimeout_8() const { return ___PollTimeout_8; }
	inline TimeSpan_t3430258949 * get_address_of_PollTimeout_8() { return &___PollTimeout_8; }
	inline void set_PollTimeout_8(TimeSpan_t3430258949  value)
	{
		___PollTimeout_8 = value;
	}

	inline static int32_t get_offset_of_pollRequest_9() { return static_cast<int32_t>(offsetof(PollingTransport_t1976236230, ___pollRequest_9)); }
	inline HTTPRequest_t138485887 * get_pollRequest_9() const { return ___pollRequest_9; }
	inline HTTPRequest_t138485887 ** get_address_of_pollRequest_9() { return &___pollRequest_9; }
	inline void set_pollRequest_9(HTTPRequest_t138485887 * value)
	{
		___pollRequest_9 = value;
		Il2CppCodeGenWriteBarrier(&___pollRequest_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
