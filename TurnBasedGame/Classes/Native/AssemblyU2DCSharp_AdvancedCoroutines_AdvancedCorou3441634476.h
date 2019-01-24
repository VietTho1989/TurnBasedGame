#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Collections.Generic.List`1<AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData>
struct List_1_t1375329359;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.AdvancedCoroutinesMonoContoller
struct  AdvancedCoroutinesMonoContoller_t3441634476  : public MonoBehaviour_t1158329972
{
public:
	// System.Collections.Generic.List`1<AdvancedCoroutines.AdvancedCoroutinesMonoContoller/CameraData> AdvancedCoroutines.AdvancedCoroutinesMonoContoller::_camerasScripts
	List_1_t1375329359 * ____camerasScripts_2;
	// System.Int32 AdvancedCoroutines.AdvancedCoroutinesMonoContoller::_postRenderMass
	int32_t ____postRenderMass_3;

public:
	inline static int32_t get_offset_of__camerasScripts_2() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesMonoContoller_t3441634476, ____camerasScripts_2)); }
	inline List_1_t1375329359 * get__camerasScripts_2() const { return ____camerasScripts_2; }
	inline List_1_t1375329359 ** get_address_of__camerasScripts_2() { return &____camerasScripts_2; }
	inline void set__camerasScripts_2(List_1_t1375329359 * value)
	{
		____camerasScripts_2 = value;
		Il2CppCodeGenWriteBarrier(&____camerasScripts_2, value);
	}

	inline static int32_t get_offset_of__postRenderMass_3() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesMonoContoller_t3441634476, ____postRenderMass_3)); }
	inline int32_t get__postRenderMass_3() const { return ____postRenderMass_3; }
	inline int32_t* get_address_of__postRenderMass_3() { return &____postRenderMass_3; }
	inline void set__postRenderMass_3(int32_t value)
	{
		____postRenderMass_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
