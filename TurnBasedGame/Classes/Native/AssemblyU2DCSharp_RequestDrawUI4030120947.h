#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1952172764.h"

// RequestDrawStateNoneUI
struct RequestDrawStateNoneUI_t1467885476;
// RequestDrawStateAskUI
struct RequestDrawStateAskUI_t3247105013;
// RequestDrawStateAcceptUI
struct RequestDrawStateAcceptUI_t2519969706;
// RequestDrawStateCancelUI
struct RequestDrawStateCancelUI_t3916120600;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDrawUI
struct  RequestDrawUI_t4030120947  : public UIBehavior_1_t1952172764
{
public:
	// RequestDrawStateNoneUI RequestDrawUI::nonePrefab
	RequestDrawStateNoneUI_t1467885476 * ___nonePrefab_6;
	// RequestDrawStateAskUI RequestDrawUI::askPrefab
	RequestDrawStateAskUI_t3247105013 * ___askPrefab_7;
	// RequestDrawStateAcceptUI RequestDrawUI::acceptPrefab
	RequestDrawStateAcceptUI_t2519969706 * ___acceptPrefab_8;
	// RequestDrawStateCancelUI RequestDrawUI::cancelPrefab
	RequestDrawStateCancelUI_t3916120600 * ___cancelPrefab_9;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(RequestDrawUI_t4030120947, ___nonePrefab_6)); }
	inline RequestDrawStateNoneUI_t1467885476 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline RequestDrawStateNoneUI_t1467885476 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(RequestDrawStateNoneUI_t1467885476 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_askPrefab_7() { return static_cast<int32_t>(offsetof(RequestDrawUI_t4030120947, ___askPrefab_7)); }
	inline RequestDrawStateAskUI_t3247105013 * get_askPrefab_7() const { return ___askPrefab_7; }
	inline RequestDrawStateAskUI_t3247105013 ** get_address_of_askPrefab_7() { return &___askPrefab_7; }
	inline void set_askPrefab_7(RequestDrawStateAskUI_t3247105013 * value)
	{
		___askPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_7, value);
	}

	inline static int32_t get_offset_of_acceptPrefab_8() { return static_cast<int32_t>(offsetof(RequestDrawUI_t4030120947, ___acceptPrefab_8)); }
	inline RequestDrawStateAcceptUI_t2519969706 * get_acceptPrefab_8() const { return ___acceptPrefab_8; }
	inline RequestDrawStateAcceptUI_t2519969706 ** get_address_of_acceptPrefab_8() { return &___acceptPrefab_8; }
	inline void set_acceptPrefab_8(RequestDrawStateAcceptUI_t2519969706 * value)
	{
		___acceptPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___acceptPrefab_8, value);
	}

	inline static int32_t get_offset_of_cancelPrefab_9() { return static_cast<int32_t>(offsetof(RequestDrawUI_t4030120947, ___cancelPrefab_9)); }
	inline RequestDrawStateCancelUI_t3916120600 * get_cancelPrefab_9() const { return ___cancelPrefab_9; }
	inline RequestDrawStateCancelUI_t3916120600 ** get_address_of_cancelPrefab_9() { return &___cancelPrefab_9; }
	inline void set_cancelPrefab_9(RequestDrawStateCancelUI_t3916120600 * value)
	{
		___cancelPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___cancelPrefab_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
