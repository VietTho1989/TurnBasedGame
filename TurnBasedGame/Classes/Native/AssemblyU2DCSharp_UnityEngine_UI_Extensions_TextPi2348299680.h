#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Collections.Generic.List`1<UnityEngine.Rect>
struct List_1_t3050876758;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.TextPic/HrefInfo
struct  HrefInfo_t2348299680  : public Il2CppObject
{
public:
	// System.Int32 UnityEngine.UI.Extensions.TextPic/HrefInfo::startIndex
	int32_t ___startIndex_0;
	// System.Int32 UnityEngine.UI.Extensions.TextPic/HrefInfo::endIndex
	int32_t ___endIndex_1;
	// System.String UnityEngine.UI.Extensions.TextPic/HrefInfo::name
	String_t* ___name_2;
	// System.Collections.Generic.List`1<UnityEngine.Rect> UnityEngine.UI.Extensions.TextPic/HrefInfo::boxes
	List_1_t3050876758 * ___boxes_3;

public:
	inline static int32_t get_offset_of_startIndex_0() { return static_cast<int32_t>(offsetof(HrefInfo_t2348299680, ___startIndex_0)); }
	inline int32_t get_startIndex_0() const { return ___startIndex_0; }
	inline int32_t* get_address_of_startIndex_0() { return &___startIndex_0; }
	inline void set_startIndex_0(int32_t value)
	{
		___startIndex_0 = value;
	}

	inline static int32_t get_offset_of_endIndex_1() { return static_cast<int32_t>(offsetof(HrefInfo_t2348299680, ___endIndex_1)); }
	inline int32_t get_endIndex_1() const { return ___endIndex_1; }
	inline int32_t* get_address_of_endIndex_1() { return &___endIndex_1; }
	inline void set_endIndex_1(int32_t value)
	{
		___endIndex_1 = value;
	}

	inline static int32_t get_offset_of_name_2() { return static_cast<int32_t>(offsetof(HrefInfo_t2348299680, ___name_2)); }
	inline String_t* get_name_2() const { return ___name_2; }
	inline String_t** get_address_of_name_2() { return &___name_2; }
	inline void set_name_2(String_t* value)
	{
		___name_2 = value;
		Il2CppCodeGenWriteBarrier(&___name_2, value);
	}

	inline static int32_t get_offset_of_boxes_3() { return static_cast<int32_t>(offsetof(HrefInfo_t2348299680, ___boxes_3)); }
	inline List_1_t3050876758 * get_boxes_3() const { return ___boxes_3; }
	inline List_1_t3050876758 ** get_address_of_boxes_3() { return &___boxes_3; }
	inline void set_boxes_3(List_1_t3050876758 * value)
	{
		___boxes_3 = value;
		Il2CppCodeGenWriteBarrier(&___boxes_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
