#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeReport4200037705.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<TimeReportClient/State>
struct VP_1_t1142467056;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeReportClient
struct  TimeReportClient_t1909557796  : public TimeReport_t4200037705
{
public:
	// VP`1<System.UInt32> TimeReportClient::userId
	VP_1_t2527959027 * ___userId_5;
	// VP`1<System.Single> TimeReportClient::delta
	VP_1_t2454786938 * ___delta_6;
	// VP`1<System.Single> TimeReportClient::reportTime
	VP_1_t2454786938 * ___reportTime_7;
	// VP`1<TimeReportClient/State> TimeReportClient::clientState
	VP_1_t1142467056 * ___clientState_8;

public:
	inline static int32_t get_offset_of_userId_5() { return static_cast<int32_t>(offsetof(TimeReportClient_t1909557796, ___userId_5)); }
	inline VP_1_t2527959027 * get_userId_5() const { return ___userId_5; }
	inline VP_1_t2527959027 ** get_address_of_userId_5() { return &___userId_5; }
	inline void set_userId_5(VP_1_t2527959027 * value)
	{
		___userId_5 = value;
		Il2CppCodeGenWriteBarrier(&___userId_5, value);
	}

	inline static int32_t get_offset_of_delta_6() { return static_cast<int32_t>(offsetof(TimeReportClient_t1909557796, ___delta_6)); }
	inline VP_1_t2454786938 * get_delta_6() const { return ___delta_6; }
	inline VP_1_t2454786938 ** get_address_of_delta_6() { return &___delta_6; }
	inline void set_delta_6(VP_1_t2454786938 * value)
	{
		___delta_6 = value;
		Il2CppCodeGenWriteBarrier(&___delta_6, value);
	}

	inline static int32_t get_offset_of_reportTime_7() { return static_cast<int32_t>(offsetof(TimeReportClient_t1909557796, ___reportTime_7)); }
	inline VP_1_t2454786938 * get_reportTime_7() const { return ___reportTime_7; }
	inline VP_1_t2454786938 ** get_address_of_reportTime_7() { return &___reportTime_7; }
	inline void set_reportTime_7(VP_1_t2454786938 * value)
	{
		___reportTime_7 = value;
		Il2CppCodeGenWriteBarrier(&___reportTime_7, value);
	}

	inline static int32_t get_offset_of_clientState_8() { return static_cast<int32_t>(offsetof(TimeReportClient_t1909557796, ___clientState_8)); }
	inline VP_1_t1142467056 * get_clientState_8() const { return ___clientState_8; }
	inline VP_1_t1142467056 ** get_address_of_clientState_8() { return &___clientState_8; }
	inline void set_clientState_8(VP_1_t1142467056 * value)
	{
		___clientState_8 = value;
		Il2CppCodeGenWriteBarrier(&___clientState_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
