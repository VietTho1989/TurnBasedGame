#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// AdvancedCoroutines.AdvancedCoroutinesCameraMonoController
struct AdvancedCoroutinesCameraMonoController_t668637255;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData
struct  CameraData_t2006208227 
{
public:
	// AdvancedCoroutines.AdvancedCoroutinesCameraMonoController AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData::cameraScript
	AdvancedCoroutinesCameraMonoController_t668637255 * ___cameraScript_0;
	// System.Boolean AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData::isEnabled
	bool ___isEnabled_1;

public:
	inline static int32_t get_offset_of_cameraScript_0() { return static_cast<int32_t>(offsetof(CameraData_t2006208227, ___cameraScript_0)); }
	inline AdvancedCoroutinesCameraMonoController_t668637255 * get_cameraScript_0() const { return ___cameraScript_0; }
	inline AdvancedCoroutinesCameraMonoController_t668637255 ** get_address_of_cameraScript_0() { return &___cameraScript_0; }
	inline void set_cameraScript_0(AdvancedCoroutinesCameraMonoController_t668637255 * value)
	{
		___cameraScript_0 = value;
		Il2CppCodeGenWriteBarrier(&___cameraScript_0, value);
	}

	inline static int32_t get_offset_of_isEnabled_1() { return static_cast<int32_t>(offsetof(CameraData_t2006208227, ___isEnabled_1)); }
	inline bool get_isEnabled_1() const { return ___isEnabled_1; }
	inline bool* get_address_of_isEnabled_1() { return &___isEnabled_1; }
	inline void set_isEnabled_1(bool value)
	{
		___isEnabled_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData
struct CameraData_t2006208227_marshaled_pinvoke
{
	AdvancedCoroutinesCameraMonoController_t668637255 * ___cameraScript_0;
	int32_t ___isEnabled_1;
};
// Native definition for COM marshalling of AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData
struct CameraData_t2006208227_marshaled_com
{
	AdvancedCoroutinesCameraMonoController_t668637255 * ___cameraScript_0;
	int32_t ___isEnabled_1;
};
