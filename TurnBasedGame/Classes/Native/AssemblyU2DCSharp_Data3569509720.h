#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// WrapProperty
struct WrapProperty_t3727681325;
// System.Collections.Generic.List`1<WrapProperty>
struct List_1_t3096802457;
// System.Collections.Generic.List`1<ValueChangeCallBack>
struct List_1_t2170265942;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Data
struct  Data_t3569509720  : public Il2CppObject
{
public:
	// System.UInt32 Data::uid
	uint32_t ___uid_1;
	// WrapProperty Data::p
	WrapProperty_t3727681325 * ___p_2;
	// System.Collections.Generic.List`1<WrapProperty> Data::pts
	List_1_t3096802457 * ___pts_3;
	// System.Collections.Generic.List`1<ValueChangeCallBack> Data::callBacks
	List_1_t2170265942 * ___callBacks_4;

public:
	inline static int32_t get_offset_of_uid_1() { return static_cast<int32_t>(offsetof(Data_t3569509720, ___uid_1)); }
	inline uint32_t get_uid_1() const { return ___uid_1; }
	inline uint32_t* get_address_of_uid_1() { return &___uid_1; }
	inline void set_uid_1(uint32_t value)
	{
		___uid_1 = value;
	}

	inline static int32_t get_offset_of_p_2() { return static_cast<int32_t>(offsetof(Data_t3569509720, ___p_2)); }
	inline WrapProperty_t3727681325 * get_p_2() const { return ___p_2; }
	inline WrapProperty_t3727681325 ** get_address_of_p_2() { return &___p_2; }
	inline void set_p_2(WrapProperty_t3727681325 * value)
	{
		___p_2 = value;
		Il2CppCodeGenWriteBarrier(&___p_2, value);
	}

	inline static int32_t get_offset_of_pts_3() { return static_cast<int32_t>(offsetof(Data_t3569509720, ___pts_3)); }
	inline List_1_t3096802457 * get_pts_3() const { return ___pts_3; }
	inline List_1_t3096802457 ** get_address_of_pts_3() { return &___pts_3; }
	inline void set_pts_3(List_1_t3096802457 * value)
	{
		___pts_3 = value;
		Il2CppCodeGenWriteBarrier(&___pts_3, value);
	}

	inline static int32_t get_offset_of_callBacks_4() { return static_cast<int32_t>(offsetof(Data_t3569509720, ___callBacks_4)); }
	inline List_1_t2170265942 * get_callBacks_4() const { return ___callBacks_4; }
	inline List_1_t2170265942 ** get_address_of_callBacks_4() { return &___callBacks_4; }
	inline void set_callBacks_4(List_1_t2170265942 * value)
	{
		___callBacks_4 = value;
		Il2CppCodeGenWriteBarrier(&___callBacks_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
