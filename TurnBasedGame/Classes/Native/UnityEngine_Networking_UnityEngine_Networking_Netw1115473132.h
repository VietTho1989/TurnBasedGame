#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Networking.NetworkTransform
struct NetworkTransform_t1903367356;
// UnityEngine.Material
struct Material_t193706927;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkTransformVisualizer
struct  NetworkTransformVisualizer_t1115473132  : public NetworkBehaviour_t3873055601
{
public:
	// UnityEngine.GameObject UnityEngine.Networking.NetworkTransformVisualizer::m_VisualizerPrefab
	GameObject_t1756533147 * ___m_VisualizerPrefab_8;
	// UnityEngine.Networking.NetworkTransform UnityEngine.Networking.NetworkTransformVisualizer::m_NetworkTransform
	NetworkTransform_t1903367356 * ___m_NetworkTransform_9;
	// UnityEngine.GameObject UnityEngine.Networking.NetworkTransformVisualizer::m_Visualizer
	GameObject_t1756533147 * ___m_Visualizer_10;

public:
	inline static int32_t get_offset_of_m_VisualizerPrefab_8() { return static_cast<int32_t>(offsetof(NetworkTransformVisualizer_t1115473132, ___m_VisualizerPrefab_8)); }
	inline GameObject_t1756533147 * get_m_VisualizerPrefab_8() const { return ___m_VisualizerPrefab_8; }
	inline GameObject_t1756533147 ** get_address_of_m_VisualizerPrefab_8() { return &___m_VisualizerPrefab_8; }
	inline void set_m_VisualizerPrefab_8(GameObject_t1756533147 * value)
	{
		___m_VisualizerPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___m_VisualizerPrefab_8, value);
	}

	inline static int32_t get_offset_of_m_NetworkTransform_9() { return static_cast<int32_t>(offsetof(NetworkTransformVisualizer_t1115473132, ___m_NetworkTransform_9)); }
	inline NetworkTransform_t1903367356 * get_m_NetworkTransform_9() const { return ___m_NetworkTransform_9; }
	inline NetworkTransform_t1903367356 ** get_address_of_m_NetworkTransform_9() { return &___m_NetworkTransform_9; }
	inline void set_m_NetworkTransform_9(NetworkTransform_t1903367356 * value)
	{
		___m_NetworkTransform_9 = value;
		Il2CppCodeGenWriteBarrier(&___m_NetworkTransform_9, value);
	}

	inline static int32_t get_offset_of_m_Visualizer_10() { return static_cast<int32_t>(offsetof(NetworkTransformVisualizer_t1115473132, ___m_Visualizer_10)); }
	inline GameObject_t1756533147 * get_m_Visualizer_10() const { return ___m_Visualizer_10; }
	inline GameObject_t1756533147 ** get_address_of_m_Visualizer_10() { return &___m_Visualizer_10; }
	inline void set_m_Visualizer_10(GameObject_t1756533147 * value)
	{
		___m_Visualizer_10 = value;
		Il2CppCodeGenWriteBarrier(&___m_Visualizer_10, value);
	}
};

struct NetworkTransformVisualizer_t1115473132_StaticFields
{
public:
	// UnityEngine.Material UnityEngine.Networking.NetworkTransformVisualizer::s_LineMaterial
	Material_t193706927 * ___s_LineMaterial_11;

public:
	inline static int32_t get_offset_of_s_LineMaterial_11() { return static_cast<int32_t>(offsetof(NetworkTransformVisualizer_t1115473132_StaticFields, ___s_LineMaterial_11)); }
	inline Material_t193706927 * get_s_LineMaterial_11() const { return ___s_LineMaterial_11; }
	inline Material_t193706927 ** get_address_of_s_LineMaterial_11() { return &___s_LineMaterial_11; }
	inline void set_s_LineMaterial_11(Material_t193706927 * value)
	{
		___s_LineMaterial_11 = value;
		Il2CppCodeGenWriteBarrier(&___s_LineMaterial_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
