#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int64>
struct VP_1_t1287355043;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<Data/ChangeState>
struct VP_1_t1323069060;
// VP`1<Server/State/Type>
struct VP_1_t2238184744;
// VP`1<RequestChangeUpdate`1/UpdateData/Request<System.Int64>>
struct VP_1_t2362301789;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeUpdate`1/UpdateData<System.Int64>
struct  UpdateData_t3469036033  : public Data_t3569509720
{
public:
	// VP`1<K> RequestChangeUpdate`1/UpdateData::origin
	VP_1_t1287355043 * ___origin_5;
	// VP`1<K> RequestChangeUpdate`1/UpdateData::current
	VP_1_t1287355043 * ___current_6;
	// VP`1<System.Boolean> RequestChangeUpdate`1/UpdateData::canRequestChange
	VP_1_t4203851724 * ___canRequestChange_7;
	// VP`1<Data/ChangeState> RequestChangeUpdate`1/UpdateData::changeState
	VP_1_t1323069060 * ___changeState_8;
	// VP`1<Server/State/Type> RequestChangeUpdate`1/UpdateData::serverState
	VP_1_t2238184744 * ___serverState_9;
	// VP`1<RequestChangeUpdate`1/UpdateData/Request<K>> RequestChangeUpdate`1/UpdateData::request
	VP_1_t2362301789 * ___request_10;
	// VP`1<System.Single> RequestChangeUpdate`1/UpdateData::waitTime
	VP_1_t2454786938 * ___waitTime_11;

public:
	inline static int32_t get_offset_of_origin_5() { return static_cast<int32_t>(offsetof(UpdateData_t3469036033, ___origin_5)); }
	inline VP_1_t1287355043 * get_origin_5() const { return ___origin_5; }
	inline VP_1_t1287355043 ** get_address_of_origin_5() { return &___origin_5; }
	inline void set_origin_5(VP_1_t1287355043 * value)
	{
		___origin_5 = value;
		Il2CppCodeGenWriteBarrier(&___origin_5, value);
	}

	inline static int32_t get_offset_of_current_6() { return static_cast<int32_t>(offsetof(UpdateData_t3469036033, ___current_6)); }
	inline VP_1_t1287355043 * get_current_6() const { return ___current_6; }
	inline VP_1_t1287355043 ** get_address_of_current_6() { return &___current_6; }
	inline void set_current_6(VP_1_t1287355043 * value)
	{
		___current_6 = value;
		Il2CppCodeGenWriteBarrier(&___current_6, value);
	}

	inline static int32_t get_offset_of_canRequestChange_7() { return static_cast<int32_t>(offsetof(UpdateData_t3469036033, ___canRequestChange_7)); }
	inline VP_1_t4203851724 * get_canRequestChange_7() const { return ___canRequestChange_7; }
	inline VP_1_t4203851724 ** get_address_of_canRequestChange_7() { return &___canRequestChange_7; }
	inline void set_canRequestChange_7(VP_1_t4203851724 * value)
	{
		___canRequestChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___canRequestChange_7, value);
	}

	inline static int32_t get_offset_of_changeState_8() { return static_cast<int32_t>(offsetof(UpdateData_t3469036033, ___changeState_8)); }
	inline VP_1_t1323069060 * get_changeState_8() const { return ___changeState_8; }
	inline VP_1_t1323069060 ** get_address_of_changeState_8() { return &___changeState_8; }
	inline void set_changeState_8(VP_1_t1323069060 * value)
	{
		___changeState_8 = value;
		Il2CppCodeGenWriteBarrier(&___changeState_8, value);
	}

	inline static int32_t get_offset_of_serverState_9() { return static_cast<int32_t>(offsetof(UpdateData_t3469036033, ___serverState_9)); }
	inline VP_1_t2238184744 * get_serverState_9() const { return ___serverState_9; }
	inline VP_1_t2238184744 ** get_address_of_serverState_9() { return &___serverState_9; }
	inline void set_serverState_9(VP_1_t2238184744 * value)
	{
		___serverState_9 = value;
		Il2CppCodeGenWriteBarrier(&___serverState_9, value);
	}

	inline static int32_t get_offset_of_request_10() { return static_cast<int32_t>(offsetof(UpdateData_t3469036033, ___request_10)); }
	inline VP_1_t2362301789 * get_request_10() const { return ___request_10; }
	inline VP_1_t2362301789 ** get_address_of_request_10() { return &___request_10; }
	inline void set_request_10(VP_1_t2362301789 * value)
	{
		___request_10 = value;
		Il2CppCodeGenWriteBarrier(&___request_10, value);
	}

	inline static int32_t get_offset_of_waitTime_11() { return static_cast<int32_t>(offsetof(UpdateData_t3469036033, ___waitTime_11)); }
	inline VP_1_t2454786938 * get_waitTime_11() const { return ___waitTime_11; }
	inline VP_1_t2454786938 ** get_address_of_waitTime_11() { return &___waitTime_11; }
	inline void set_waitTime_11(VP_1_t2454786938 * value)
	{
		___waitTime_11 = value;
		Il2CppCodeGenWriteBarrier(&___waitTime_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
