#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netw1215540681.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkProximityChecker
struct  NetworkProximityChecker_t1785431524  : public NetworkBehaviour_t3873055601
{
public:
	// System.Int32 UnityEngine.Networking.NetworkProximityChecker::visRange
	int32_t ___visRange_8;
	// System.Single UnityEngine.Networking.NetworkProximityChecker::visUpdateInterval
	float ___visUpdateInterval_9;
	// UnityEngine.Networking.NetworkProximityChecker/CheckMethod UnityEngine.Networking.NetworkProximityChecker::checkMethod
	int32_t ___checkMethod_10;
	// System.Boolean UnityEngine.Networking.NetworkProximityChecker::forceHidden
	bool ___forceHidden_11;
	// System.Single UnityEngine.Networking.NetworkProximityChecker::m_VisUpdateTime
	float ___m_VisUpdateTime_12;

public:
	inline static int32_t get_offset_of_visRange_8() { return static_cast<int32_t>(offsetof(NetworkProximityChecker_t1785431524, ___visRange_8)); }
	inline int32_t get_visRange_8() const { return ___visRange_8; }
	inline int32_t* get_address_of_visRange_8() { return &___visRange_8; }
	inline void set_visRange_8(int32_t value)
	{
		___visRange_8 = value;
	}

	inline static int32_t get_offset_of_visUpdateInterval_9() { return static_cast<int32_t>(offsetof(NetworkProximityChecker_t1785431524, ___visUpdateInterval_9)); }
	inline float get_visUpdateInterval_9() const { return ___visUpdateInterval_9; }
	inline float* get_address_of_visUpdateInterval_9() { return &___visUpdateInterval_9; }
	inline void set_visUpdateInterval_9(float value)
	{
		___visUpdateInterval_9 = value;
	}

	inline static int32_t get_offset_of_checkMethod_10() { return static_cast<int32_t>(offsetof(NetworkProximityChecker_t1785431524, ___checkMethod_10)); }
	inline int32_t get_checkMethod_10() const { return ___checkMethod_10; }
	inline int32_t* get_address_of_checkMethod_10() { return &___checkMethod_10; }
	inline void set_checkMethod_10(int32_t value)
	{
		___checkMethod_10 = value;
	}

	inline static int32_t get_offset_of_forceHidden_11() { return static_cast<int32_t>(offsetof(NetworkProximityChecker_t1785431524, ___forceHidden_11)); }
	inline bool get_forceHidden_11() const { return ___forceHidden_11; }
	inline bool* get_address_of_forceHidden_11() { return &___forceHidden_11; }
	inline void set_forceHidden_11(bool value)
	{
		___forceHidden_11 = value;
	}

	inline static int32_t get_offset_of_m_VisUpdateTime_12() { return static_cast<int32_t>(offsetof(NetworkProximityChecker_t1785431524, ___m_VisUpdateTime_12)); }
	inline float get_m_VisUpdateTime_12() const { return ___m_VisUpdateTime_12; }
	inline float* get_address_of_m_VisUpdateTime_12() { return &___m_VisUpdateTime_12; }
	inline void set_m_VisUpdateTime_12(float value)
	{
		___m_VisUpdateTime_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
