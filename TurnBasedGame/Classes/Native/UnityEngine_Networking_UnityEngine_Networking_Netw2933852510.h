#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netw1308292611.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netwo888528802.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "UnityEngine_UnityEngine_Quaternion4030073918.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.Networking.NetworkTransform
struct NetworkTransform_t1903367356;
// UnityEngine.Networking.NetworkTransform/ClientMoveCallback3D
struct ClientMoveCallback3D_t1738312058;
// UnityEngine.Networking.NetworkWriter
struct NetworkWriter_t560143343;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkTransformChild
struct  NetworkTransformChild_t2933852510  : public NetworkBehaviour_t3873055601
{
public:
	// UnityEngine.Transform UnityEngine.Networking.NetworkTransformChild::m_Target
	Transform_t3275118058 * ___m_Target_8;
	// System.UInt32 UnityEngine.Networking.NetworkTransformChild::m_ChildIndex
	uint32_t ___m_ChildIndex_9;
	// UnityEngine.Networking.NetworkTransform UnityEngine.Networking.NetworkTransformChild::m_Root
	NetworkTransform_t1903367356 * ___m_Root_10;
	// System.Single UnityEngine.Networking.NetworkTransformChild::m_SendInterval
	float ___m_SendInterval_11;
	// UnityEngine.Networking.NetworkTransform/AxisSyncMode UnityEngine.Networking.NetworkTransformChild::m_SyncRotationAxis
	int32_t ___m_SyncRotationAxis_12;
	// UnityEngine.Networking.NetworkTransform/CompressionSyncMode UnityEngine.Networking.NetworkTransformChild::m_RotationSyncCompression
	int32_t ___m_RotationSyncCompression_13;
	// System.Single UnityEngine.Networking.NetworkTransformChild::m_MovementThreshold
	float ___m_MovementThreshold_14;
	// System.Single UnityEngine.Networking.NetworkTransformChild::m_InterpolateRotation
	float ___m_InterpolateRotation_15;
	// System.Single UnityEngine.Networking.NetworkTransformChild::m_InterpolateMovement
	float ___m_InterpolateMovement_16;
	// UnityEngine.Networking.NetworkTransform/ClientMoveCallback3D UnityEngine.Networking.NetworkTransformChild::m_ClientMoveCallback3D
	ClientMoveCallback3D_t1738312058 * ___m_ClientMoveCallback3D_17;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkTransformChild::m_TargetSyncPosition
	Vector3_t2243707580  ___m_TargetSyncPosition_18;
	// UnityEngine.Quaternion UnityEngine.Networking.NetworkTransformChild::m_TargetSyncRotation3D
	Quaternion_t4030073918  ___m_TargetSyncRotation3D_19;
	// System.Single UnityEngine.Networking.NetworkTransformChild::m_LastClientSyncTime
	float ___m_LastClientSyncTime_20;
	// System.Single UnityEngine.Networking.NetworkTransformChild::m_LastClientSendTime
	float ___m_LastClientSendTime_21;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkTransformChild::m_PrevPosition
	Vector3_t2243707580  ___m_PrevPosition_22;
	// UnityEngine.Quaternion UnityEngine.Networking.NetworkTransformChild::m_PrevRotation
	Quaternion_t4030073918  ___m_PrevRotation_23;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.NetworkTransformChild::m_LocalTransformWriter
	NetworkWriter_t560143343 * ___m_LocalTransformWriter_26;

public:
	inline static int32_t get_offset_of_m_Target_8() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_Target_8)); }
	inline Transform_t3275118058 * get_m_Target_8() const { return ___m_Target_8; }
	inline Transform_t3275118058 ** get_address_of_m_Target_8() { return &___m_Target_8; }
	inline void set_m_Target_8(Transform_t3275118058 * value)
	{
		___m_Target_8 = value;
		Il2CppCodeGenWriteBarrier(&___m_Target_8, value);
	}

	inline static int32_t get_offset_of_m_ChildIndex_9() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_ChildIndex_9)); }
	inline uint32_t get_m_ChildIndex_9() const { return ___m_ChildIndex_9; }
	inline uint32_t* get_address_of_m_ChildIndex_9() { return &___m_ChildIndex_9; }
	inline void set_m_ChildIndex_9(uint32_t value)
	{
		___m_ChildIndex_9 = value;
	}

	inline static int32_t get_offset_of_m_Root_10() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_Root_10)); }
	inline NetworkTransform_t1903367356 * get_m_Root_10() const { return ___m_Root_10; }
	inline NetworkTransform_t1903367356 ** get_address_of_m_Root_10() { return &___m_Root_10; }
	inline void set_m_Root_10(NetworkTransform_t1903367356 * value)
	{
		___m_Root_10 = value;
		Il2CppCodeGenWriteBarrier(&___m_Root_10, value);
	}

	inline static int32_t get_offset_of_m_SendInterval_11() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_SendInterval_11)); }
	inline float get_m_SendInterval_11() const { return ___m_SendInterval_11; }
	inline float* get_address_of_m_SendInterval_11() { return &___m_SendInterval_11; }
	inline void set_m_SendInterval_11(float value)
	{
		___m_SendInterval_11 = value;
	}

	inline static int32_t get_offset_of_m_SyncRotationAxis_12() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_SyncRotationAxis_12)); }
	inline int32_t get_m_SyncRotationAxis_12() const { return ___m_SyncRotationAxis_12; }
	inline int32_t* get_address_of_m_SyncRotationAxis_12() { return &___m_SyncRotationAxis_12; }
	inline void set_m_SyncRotationAxis_12(int32_t value)
	{
		___m_SyncRotationAxis_12 = value;
	}

	inline static int32_t get_offset_of_m_RotationSyncCompression_13() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_RotationSyncCompression_13)); }
	inline int32_t get_m_RotationSyncCompression_13() const { return ___m_RotationSyncCompression_13; }
	inline int32_t* get_address_of_m_RotationSyncCompression_13() { return &___m_RotationSyncCompression_13; }
	inline void set_m_RotationSyncCompression_13(int32_t value)
	{
		___m_RotationSyncCompression_13 = value;
	}

	inline static int32_t get_offset_of_m_MovementThreshold_14() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_MovementThreshold_14)); }
	inline float get_m_MovementThreshold_14() const { return ___m_MovementThreshold_14; }
	inline float* get_address_of_m_MovementThreshold_14() { return &___m_MovementThreshold_14; }
	inline void set_m_MovementThreshold_14(float value)
	{
		___m_MovementThreshold_14 = value;
	}

	inline static int32_t get_offset_of_m_InterpolateRotation_15() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_InterpolateRotation_15)); }
	inline float get_m_InterpolateRotation_15() const { return ___m_InterpolateRotation_15; }
	inline float* get_address_of_m_InterpolateRotation_15() { return &___m_InterpolateRotation_15; }
	inline void set_m_InterpolateRotation_15(float value)
	{
		___m_InterpolateRotation_15 = value;
	}

	inline static int32_t get_offset_of_m_InterpolateMovement_16() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_InterpolateMovement_16)); }
	inline float get_m_InterpolateMovement_16() const { return ___m_InterpolateMovement_16; }
	inline float* get_address_of_m_InterpolateMovement_16() { return &___m_InterpolateMovement_16; }
	inline void set_m_InterpolateMovement_16(float value)
	{
		___m_InterpolateMovement_16 = value;
	}

	inline static int32_t get_offset_of_m_ClientMoveCallback3D_17() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_ClientMoveCallback3D_17)); }
	inline ClientMoveCallback3D_t1738312058 * get_m_ClientMoveCallback3D_17() const { return ___m_ClientMoveCallback3D_17; }
	inline ClientMoveCallback3D_t1738312058 ** get_address_of_m_ClientMoveCallback3D_17() { return &___m_ClientMoveCallback3D_17; }
	inline void set_m_ClientMoveCallback3D_17(ClientMoveCallback3D_t1738312058 * value)
	{
		___m_ClientMoveCallback3D_17 = value;
		Il2CppCodeGenWriteBarrier(&___m_ClientMoveCallback3D_17, value);
	}

	inline static int32_t get_offset_of_m_TargetSyncPosition_18() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_TargetSyncPosition_18)); }
	inline Vector3_t2243707580  get_m_TargetSyncPosition_18() const { return ___m_TargetSyncPosition_18; }
	inline Vector3_t2243707580 * get_address_of_m_TargetSyncPosition_18() { return &___m_TargetSyncPosition_18; }
	inline void set_m_TargetSyncPosition_18(Vector3_t2243707580  value)
	{
		___m_TargetSyncPosition_18 = value;
	}

	inline static int32_t get_offset_of_m_TargetSyncRotation3D_19() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_TargetSyncRotation3D_19)); }
	inline Quaternion_t4030073918  get_m_TargetSyncRotation3D_19() const { return ___m_TargetSyncRotation3D_19; }
	inline Quaternion_t4030073918 * get_address_of_m_TargetSyncRotation3D_19() { return &___m_TargetSyncRotation3D_19; }
	inline void set_m_TargetSyncRotation3D_19(Quaternion_t4030073918  value)
	{
		___m_TargetSyncRotation3D_19 = value;
	}

	inline static int32_t get_offset_of_m_LastClientSyncTime_20() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_LastClientSyncTime_20)); }
	inline float get_m_LastClientSyncTime_20() const { return ___m_LastClientSyncTime_20; }
	inline float* get_address_of_m_LastClientSyncTime_20() { return &___m_LastClientSyncTime_20; }
	inline void set_m_LastClientSyncTime_20(float value)
	{
		___m_LastClientSyncTime_20 = value;
	}

	inline static int32_t get_offset_of_m_LastClientSendTime_21() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_LastClientSendTime_21)); }
	inline float get_m_LastClientSendTime_21() const { return ___m_LastClientSendTime_21; }
	inline float* get_address_of_m_LastClientSendTime_21() { return &___m_LastClientSendTime_21; }
	inline void set_m_LastClientSendTime_21(float value)
	{
		___m_LastClientSendTime_21 = value;
	}

	inline static int32_t get_offset_of_m_PrevPosition_22() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_PrevPosition_22)); }
	inline Vector3_t2243707580  get_m_PrevPosition_22() const { return ___m_PrevPosition_22; }
	inline Vector3_t2243707580 * get_address_of_m_PrevPosition_22() { return &___m_PrevPosition_22; }
	inline void set_m_PrevPosition_22(Vector3_t2243707580  value)
	{
		___m_PrevPosition_22 = value;
	}

	inline static int32_t get_offset_of_m_PrevRotation_23() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_PrevRotation_23)); }
	inline Quaternion_t4030073918  get_m_PrevRotation_23() const { return ___m_PrevRotation_23; }
	inline Quaternion_t4030073918 * get_address_of_m_PrevRotation_23() { return &___m_PrevRotation_23; }
	inline void set_m_PrevRotation_23(Quaternion_t4030073918  value)
	{
		___m_PrevRotation_23 = value;
	}

	inline static int32_t get_offset_of_m_LocalTransformWriter_26() { return static_cast<int32_t>(offsetof(NetworkTransformChild_t2933852510, ___m_LocalTransformWriter_26)); }
	inline NetworkWriter_t560143343 * get_m_LocalTransformWriter_26() const { return ___m_LocalTransformWriter_26; }
	inline NetworkWriter_t560143343 ** get_address_of_m_LocalTransformWriter_26() { return &___m_LocalTransformWriter_26; }
	inline void set_m_LocalTransformWriter_26(NetworkWriter_t560143343 * value)
	{
		___m_LocalTransformWriter_26 = value;
		Il2CppCodeGenWriteBarrier(&___m_LocalTransformWriter_26, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
