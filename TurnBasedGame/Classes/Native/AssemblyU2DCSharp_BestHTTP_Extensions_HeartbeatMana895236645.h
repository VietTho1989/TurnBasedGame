#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_DateTime693205669.h"

// System.Collections.Generic.List`1<BestHTTP.Extensions.IHeartbeat>
struct List_1_t2586467451;
// BestHTTP.Extensions.IHeartbeat[]
struct IHeartbeatU5BU5D_t1896521686;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Extensions.HeartbeatManager
struct  HeartbeatManager_t895236645  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<BestHTTP.Extensions.IHeartbeat> BestHTTP.Extensions.HeartbeatManager::Heartbeats
	List_1_t2586467451 * ___Heartbeats_0;
	// BestHTTP.Extensions.IHeartbeat[] BestHTTP.Extensions.HeartbeatManager::UpdateArray
	IHeartbeatU5BU5D_t1896521686* ___UpdateArray_1;
	// System.DateTime BestHTTP.Extensions.HeartbeatManager::LastUpdate
	DateTime_t693205669  ___LastUpdate_2;

public:
	inline static int32_t get_offset_of_Heartbeats_0() { return static_cast<int32_t>(offsetof(HeartbeatManager_t895236645, ___Heartbeats_0)); }
	inline List_1_t2586467451 * get_Heartbeats_0() const { return ___Heartbeats_0; }
	inline List_1_t2586467451 ** get_address_of_Heartbeats_0() { return &___Heartbeats_0; }
	inline void set_Heartbeats_0(List_1_t2586467451 * value)
	{
		___Heartbeats_0 = value;
		Il2CppCodeGenWriteBarrier(&___Heartbeats_0, value);
	}

	inline static int32_t get_offset_of_UpdateArray_1() { return static_cast<int32_t>(offsetof(HeartbeatManager_t895236645, ___UpdateArray_1)); }
	inline IHeartbeatU5BU5D_t1896521686* get_UpdateArray_1() const { return ___UpdateArray_1; }
	inline IHeartbeatU5BU5D_t1896521686** get_address_of_UpdateArray_1() { return &___UpdateArray_1; }
	inline void set_UpdateArray_1(IHeartbeatU5BU5D_t1896521686* value)
	{
		___UpdateArray_1 = value;
		Il2CppCodeGenWriteBarrier(&___UpdateArray_1, value);
	}

	inline static int32_t get_offset_of_LastUpdate_2() { return static_cast<int32_t>(offsetof(HeartbeatManager_t895236645, ___LastUpdate_2)); }
	inline DateTime_t693205669  get_LastUpdate_2() const { return ___LastUpdate_2; }
	inline DateTime_t693205669 * get_address_of_LastUpdate_2() { return &___LastUpdate_2; }
	inline void set_LastUpdate_2(DateTime_t693205669  value)
	{
		___LastUpdate_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
