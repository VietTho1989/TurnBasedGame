#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ToastTestUpdate
struct  ToastTestUpdate_t1258838130  : public MonoBehaviour_t1158329972
{
public:
	// AdvancedCoroutines.Routine ToastTestUpdate::checkToast
	Routine_t2502590640 * ___checkToast_2;

public:
	inline static int32_t get_offset_of_checkToast_2() { return static_cast<int32_t>(offsetof(ToastTestUpdate_t1258838130, ___checkToast_2)); }
	inline Routine_t2502590640 * get_checkToast_2() const { return ___checkToast_2; }
	inline Routine_t2502590640 ** get_address_of_checkToast_2() { return &___checkToast_2; }
	inline void set_checkToast_2(Routine_t2502590640 * value)
	{
		___checkToast_2 = value;
		Il2CppCodeGenWriteBarrier(&___checkToast_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
