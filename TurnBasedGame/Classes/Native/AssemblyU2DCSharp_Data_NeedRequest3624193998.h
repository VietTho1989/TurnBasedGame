#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Data/NeedRequest
struct  NeedRequest_t3624193998 
{
public:
	// System.Boolean Data/NeedRequest::canRequest
	bool ___canRequest_0;
	// System.Boolean Data/NeedRequest::needIdentity
	bool ___needIdentity_1;

public:
	inline static int32_t get_offset_of_canRequest_0() { return static_cast<int32_t>(offsetof(NeedRequest_t3624193998, ___canRequest_0)); }
	inline bool get_canRequest_0() const { return ___canRequest_0; }
	inline bool* get_address_of_canRequest_0() { return &___canRequest_0; }
	inline void set_canRequest_0(bool value)
	{
		___canRequest_0 = value;
	}

	inline static int32_t get_offset_of_needIdentity_1() { return static_cast<int32_t>(offsetof(NeedRequest_t3624193998, ___needIdentity_1)); }
	inline bool get_needIdentity_1() const { return ___needIdentity_1; }
	inline bool* get_address_of_needIdentity_1() { return &___needIdentity_1; }
	inline void set_needIdentity_1(bool value)
	{
		___needIdentity_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of Data/NeedRequest
struct NeedRequest_t3624193998_marshaled_pinvoke
{
	int32_t ___canRequest_0;
	int32_t ___needIdentity_1;
};
// Native definition for COM marshalling of Data/NeedRequest
struct NeedRequest_t3624193998_marshaled_com
{
	int32_t ___canRequest_0;
	int32_t ___needIdentity_1;
};
