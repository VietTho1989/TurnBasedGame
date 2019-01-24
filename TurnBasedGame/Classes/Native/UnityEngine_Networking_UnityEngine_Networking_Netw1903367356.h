#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netw3916231876.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netw1308292611.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netwo888528802.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "UnityEngine_UnityEngine_Quaternion4030073918.h"

// UnityEngine.Networking.NetworkTransform/ClientMoveCallback3D
struct ClientMoveCallback3D_t1738312058;
// UnityEngine.Networking.NetworkTransform/ClientMoveCallback2D
struct ClientMoveCallback2D_t1738312059;
// UnityEngine.Rigidbody
struct Rigidbody_t4233889191;
// UnityEngine.Rigidbody2D
struct Rigidbody2D_t502193897;
// UnityEngine.CharacterController
struct CharacterController_t4094781467;
// UnityEngine.Networking.NetworkWriter
struct NetworkWriter_t560143343;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkTransform
struct  NetworkTransform_t1903367356  : public NetworkBehaviour_t3873055601
{
public:
	// UnityEngine.Networking.NetworkTransform/TransformSyncMode UnityEngine.Networking.NetworkTransform::m_TransformSyncMode
	int32_t ___m_TransformSyncMode_8;
	// System.Single UnityEngine.Networking.NetworkTransform::m_SendInterval
	float ___m_SendInterval_9;
	// UnityEngine.Networking.NetworkTransform/AxisSyncMode UnityEngine.Networking.NetworkTransform::m_SyncRotationAxis
	int32_t ___m_SyncRotationAxis_10;
	// UnityEngine.Networking.NetworkTransform/CompressionSyncMode UnityEngine.Networking.NetworkTransform::m_RotationSyncCompression
	int32_t ___m_RotationSyncCompression_11;
	// System.Boolean UnityEngine.Networking.NetworkTransform::m_SyncSpin
	bool ___m_SyncSpin_12;
	// System.Single UnityEngine.Networking.NetworkTransform::m_MovementTheshold
	float ___m_MovementTheshold_13;
	// System.Single UnityEngine.Networking.NetworkTransform::m_VelocityThreshold
	float ___m_VelocityThreshold_14;
	// System.Single UnityEngine.Networking.NetworkTransform::m_SnapThreshold
	float ___m_SnapThreshold_15;
	// System.Single UnityEngine.Networking.NetworkTransform::m_InterpolateRotation
	float ___m_InterpolateRotation_16;
	// System.Single UnityEngine.Networking.NetworkTransform::m_InterpolateMovement
	float ___m_InterpolateMovement_17;
	// UnityEngine.Networking.NetworkTransform/ClientMoveCallback3D UnityEngine.Networking.NetworkTransform::m_ClientMoveCallback3D
	ClientMoveCallback3D_t1738312058 * ___m_ClientMoveCallback3D_18;
	// UnityEngine.Networking.NetworkTransform/ClientMoveCallback2D UnityEngine.Networking.NetworkTransform::m_ClientMoveCallback2D
	ClientMoveCallback2D_t1738312059 * ___m_ClientMoveCallback2D_19;
	// UnityEngine.Rigidbody UnityEngine.Networking.NetworkTransform::m_RigidBody3D
	Rigidbody_t4233889191 * ___m_RigidBody3D_20;
	// UnityEngine.Rigidbody2D UnityEngine.Networking.NetworkTransform::m_RigidBody2D
	Rigidbody2D_t502193897 * ___m_RigidBody2D_21;
	// UnityEngine.CharacterController UnityEngine.Networking.NetworkTransform::m_CharacterController
	CharacterController_t4094781467 * ___m_CharacterController_22;
	// System.Boolean UnityEngine.Networking.NetworkTransform::m_Grounded
	bool ___m_Grounded_23;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkTransform::m_TargetSyncPosition
	Vector3_t2243707580  ___m_TargetSyncPosition_24;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkTransform::m_TargetSyncVelocity
	Vector3_t2243707580  ___m_TargetSyncVelocity_25;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkTransform::m_FixedPosDiff
	Vector3_t2243707580  ___m_FixedPosDiff_26;
	// UnityEngine.Quaternion UnityEngine.Networking.NetworkTransform::m_TargetSyncRotation3D
	Quaternion_t4030073918  ___m_TargetSyncRotation3D_27;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkTransform::m_TargetSyncAngularVelocity3D
	Vector3_t2243707580  ___m_TargetSyncAngularVelocity3D_28;
	// System.Single UnityEngine.Networking.NetworkTransform::m_TargetSyncRotation2D
	float ___m_TargetSyncRotation2D_29;
	// System.Single UnityEngine.Networking.NetworkTransform::m_TargetSyncAngularVelocity2D
	float ___m_TargetSyncAngularVelocity2D_30;
	// System.Single UnityEngine.Networking.NetworkTransform::m_LastClientSyncTime
	float ___m_LastClientSyncTime_31;
	// System.Single UnityEngine.Networking.NetworkTransform::m_LastClientSendTime
	float ___m_LastClientSendTime_32;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkTransform::m_PrevPosition
	Vector3_t2243707580  ___m_PrevPosition_33;
	// UnityEngine.Quaternion UnityEngine.Networking.NetworkTransform::m_PrevRotation
	Quaternion_t4030073918  ___m_PrevRotation_34;
	// System.Single UnityEngine.Networking.NetworkTransform::m_PrevRotation2D
	float ___m_PrevRotation2D_35;
	// System.Single UnityEngine.Networking.NetworkTransform::m_PrevVelocity
	float ___m_PrevVelocity_36;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.NetworkTransform::m_LocalTransformWriter
	NetworkWriter_t560143343 * ___m_LocalTransformWriter_41;

public:
	inline static int32_t get_offset_of_m_TransformSyncMode_8() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_TransformSyncMode_8)); }
	inline int32_t get_m_TransformSyncMode_8() const { return ___m_TransformSyncMode_8; }
	inline int32_t* get_address_of_m_TransformSyncMode_8() { return &___m_TransformSyncMode_8; }
	inline void set_m_TransformSyncMode_8(int32_t value)
	{
		___m_TransformSyncMode_8 = value;
	}

	inline static int32_t get_offset_of_m_SendInterval_9() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_SendInterval_9)); }
	inline float get_m_SendInterval_9() const { return ___m_SendInterval_9; }
	inline float* get_address_of_m_SendInterval_9() { return &___m_SendInterval_9; }
	inline void set_m_SendInterval_9(float value)
	{
		___m_SendInterval_9 = value;
	}

	inline static int32_t get_offset_of_m_SyncRotationAxis_10() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_SyncRotationAxis_10)); }
	inline int32_t get_m_SyncRotationAxis_10() const { return ___m_SyncRotationAxis_10; }
	inline int32_t* get_address_of_m_SyncRotationAxis_10() { return &___m_SyncRotationAxis_10; }
	inline void set_m_SyncRotationAxis_10(int32_t value)
	{
		___m_SyncRotationAxis_10 = value;
	}

	inline static int32_t get_offset_of_m_RotationSyncCompression_11() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_RotationSyncCompression_11)); }
	inline int32_t get_m_RotationSyncCompression_11() const { return ___m_RotationSyncCompression_11; }
	inline int32_t* get_address_of_m_RotationSyncCompression_11() { return &___m_RotationSyncCompression_11; }
	inline void set_m_RotationSyncCompression_11(int32_t value)
	{
		___m_RotationSyncCompression_11 = value;
	}

	inline static int32_t get_offset_of_m_SyncSpin_12() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_SyncSpin_12)); }
	inline bool get_m_SyncSpin_12() const { return ___m_SyncSpin_12; }
	inline bool* get_address_of_m_SyncSpin_12() { return &___m_SyncSpin_12; }
	inline void set_m_SyncSpin_12(bool value)
	{
		___m_SyncSpin_12 = value;
	}

	inline static int32_t get_offset_of_m_MovementTheshold_13() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_MovementTheshold_13)); }
	inline float get_m_MovementTheshold_13() const { return ___m_MovementTheshold_13; }
	inline float* get_address_of_m_MovementTheshold_13() { return &___m_MovementTheshold_13; }
	inline void set_m_MovementTheshold_13(float value)
	{
		___m_MovementTheshold_13 = value;
	}

	inline static int32_t get_offset_of_m_VelocityThreshold_14() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_VelocityThreshold_14)); }
	inline float get_m_VelocityThreshold_14() const { return ___m_VelocityThreshold_14; }
	inline float* get_address_of_m_VelocityThreshold_14() { return &___m_VelocityThreshold_14; }
	inline void set_m_VelocityThreshold_14(float value)
	{
		___m_VelocityThreshold_14 = value;
	}

	inline static int32_t get_offset_of_m_SnapThreshold_15() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_SnapThreshold_15)); }
	inline float get_m_SnapThreshold_15() const { return ___m_SnapThreshold_15; }
	inline float* get_address_of_m_SnapThreshold_15() { return &___m_SnapThreshold_15; }
	inline void set_m_SnapThreshold_15(float value)
	{
		___m_SnapThreshold_15 = value;
	}

	inline static int32_t get_offset_of_m_InterpolateRotation_16() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_InterpolateRotation_16)); }
	inline float get_m_InterpolateRotation_16() const { return ___m_InterpolateRotation_16; }
	inline float* get_address_of_m_InterpolateRotation_16() { return &___m_InterpolateRotation_16; }
	inline void set_m_InterpolateRotation_16(float value)
	{
		___m_InterpolateRotation_16 = value;
	}

	inline static int32_t get_offset_of_m_InterpolateMovement_17() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_InterpolateMovement_17)); }
	inline float get_m_InterpolateMovement_17() const { return ___m_InterpolateMovement_17; }
	inline float* get_address_of_m_InterpolateMovement_17() { return &___m_InterpolateMovement_17; }
	inline void set_m_InterpolateMovement_17(float value)
	{
		___m_InterpolateMovement_17 = value;
	}

	inline static int32_t get_offset_of_m_ClientMoveCallback3D_18() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_ClientMoveCallback3D_18)); }
	inline ClientMoveCallback3D_t1738312058 * get_m_ClientMoveCallback3D_18() const { return ___m_ClientMoveCallback3D_18; }
	inline ClientMoveCallback3D_t1738312058 ** get_address_of_m_ClientMoveCallback3D_18() { return &___m_ClientMoveCallback3D_18; }
	inline void set_m_ClientMoveCallback3D_18(ClientMoveCallback3D_t1738312058 * value)
	{
		___m_ClientMoveCallback3D_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_ClientMoveCallback3D_18, value);
	}

	inline static int32_t get_offset_of_m_ClientMoveCallback2D_19() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_ClientMoveCallback2D_19)); }
	inline ClientMoveCallback2D_t1738312059 * get_m_ClientMoveCallback2D_19() const { return ___m_ClientMoveCallback2D_19; }
	inline ClientMoveCallback2D_t1738312059 ** get_address_of_m_ClientMoveCallback2D_19() { return &___m_ClientMoveCallback2D_19; }
	inline void set_m_ClientMoveCallback2D_19(ClientMoveCallback2D_t1738312059 * value)
	{
		___m_ClientMoveCallback2D_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_ClientMoveCallback2D_19, value);
	}

	inline static int32_t get_offset_of_m_RigidBody3D_20() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_RigidBody3D_20)); }
	inline Rigidbody_t4233889191 * get_m_RigidBody3D_20() const { return ___m_RigidBody3D_20; }
	inline Rigidbody_t4233889191 ** get_address_of_m_RigidBody3D_20() { return &___m_RigidBody3D_20; }
	inline void set_m_RigidBody3D_20(Rigidbody_t4233889191 * value)
	{
		___m_RigidBody3D_20 = value;
		Il2CppCodeGenWriteBarrier(&___m_RigidBody3D_20, value);
	}

	inline static int32_t get_offset_of_m_RigidBody2D_21() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_RigidBody2D_21)); }
	inline Rigidbody2D_t502193897 * get_m_RigidBody2D_21() const { return ___m_RigidBody2D_21; }
	inline Rigidbody2D_t502193897 ** get_address_of_m_RigidBody2D_21() { return &___m_RigidBody2D_21; }
	inline void set_m_RigidBody2D_21(Rigidbody2D_t502193897 * value)
	{
		___m_RigidBody2D_21 = value;
		Il2CppCodeGenWriteBarrier(&___m_RigidBody2D_21, value);
	}

	inline static int32_t get_offset_of_m_CharacterController_22() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_CharacterController_22)); }
	inline CharacterController_t4094781467 * get_m_CharacterController_22() const { return ___m_CharacterController_22; }
	inline CharacterController_t4094781467 ** get_address_of_m_CharacterController_22() { return &___m_CharacterController_22; }
	inline void set_m_CharacterController_22(CharacterController_t4094781467 * value)
	{
		___m_CharacterController_22 = value;
		Il2CppCodeGenWriteBarrier(&___m_CharacterController_22, value);
	}

	inline static int32_t get_offset_of_m_Grounded_23() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_Grounded_23)); }
	inline bool get_m_Grounded_23() const { return ___m_Grounded_23; }
	inline bool* get_address_of_m_Grounded_23() { return &___m_Grounded_23; }
	inline void set_m_Grounded_23(bool value)
	{
		___m_Grounded_23 = value;
	}

	inline static int32_t get_offset_of_m_TargetSyncPosition_24() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_TargetSyncPosition_24)); }
	inline Vector3_t2243707580  get_m_TargetSyncPosition_24() const { return ___m_TargetSyncPosition_24; }
	inline Vector3_t2243707580 * get_address_of_m_TargetSyncPosition_24() { return &___m_TargetSyncPosition_24; }
	inline void set_m_TargetSyncPosition_24(Vector3_t2243707580  value)
	{
		___m_TargetSyncPosition_24 = value;
	}

	inline static int32_t get_offset_of_m_TargetSyncVelocity_25() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_TargetSyncVelocity_25)); }
	inline Vector3_t2243707580  get_m_TargetSyncVelocity_25() const { return ___m_TargetSyncVelocity_25; }
	inline Vector3_t2243707580 * get_address_of_m_TargetSyncVelocity_25() { return &___m_TargetSyncVelocity_25; }
	inline void set_m_TargetSyncVelocity_25(Vector3_t2243707580  value)
	{
		___m_TargetSyncVelocity_25 = value;
	}

	inline static int32_t get_offset_of_m_FixedPosDiff_26() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_FixedPosDiff_26)); }
	inline Vector3_t2243707580  get_m_FixedPosDiff_26() const { return ___m_FixedPosDiff_26; }
	inline Vector3_t2243707580 * get_address_of_m_FixedPosDiff_26() { return &___m_FixedPosDiff_26; }
	inline void set_m_FixedPosDiff_26(Vector3_t2243707580  value)
	{
		___m_FixedPosDiff_26 = value;
	}

	inline static int32_t get_offset_of_m_TargetSyncRotation3D_27() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_TargetSyncRotation3D_27)); }
	inline Quaternion_t4030073918  get_m_TargetSyncRotation3D_27() const { return ___m_TargetSyncRotation3D_27; }
	inline Quaternion_t4030073918 * get_address_of_m_TargetSyncRotation3D_27() { return &___m_TargetSyncRotation3D_27; }
	inline void set_m_TargetSyncRotation3D_27(Quaternion_t4030073918  value)
	{
		___m_TargetSyncRotation3D_27 = value;
	}

	inline static int32_t get_offset_of_m_TargetSyncAngularVelocity3D_28() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_TargetSyncAngularVelocity3D_28)); }
	inline Vector3_t2243707580  get_m_TargetSyncAngularVelocity3D_28() const { return ___m_TargetSyncAngularVelocity3D_28; }
	inline Vector3_t2243707580 * get_address_of_m_TargetSyncAngularVelocity3D_28() { return &___m_TargetSyncAngularVelocity3D_28; }
	inline void set_m_TargetSyncAngularVelocity3D_28(Vector3_t2243707580  value)
	{
		___m_TargetSyncAngularVelocity3D_28 = value;
	}

	inline static int32_t get_offset_of_m_TargetSyncRotation2D_29() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_TargetSyncRotation2D_29)); }
	inline float get_m_TargetSyncRotation2D_29() const { return ___m_TargetSyncRotation2D_29; }
	inline float* get_address_of_m_TargetSyncRotation2D_29() { return &___m_TargetSyncRotation2D_29; }
	inline void set_m_TargetSyncRotation2D_29(float value)
	{
		___m_TargetSyncRotation2D_29 = value;
	}

	inline static int32_t get_offset_of_m_TargetSyncAngularVelocity2D_30() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_TargetSyncAngularVelocity2D_30)); }
	inline float get_m_TargetSyncAngularVelocity2D_30() const { return ___m_TargetSyncAngularVelocity2D_30; }
	inline float* get_address_of_m_TargetSyncAngularVelocity2D_30() { return &___m_TargetSyncAngularVelocity2D_30; }
	inline void set_m_TargetSyncAngularVelocity2D_30(float value)
	{
		___m_TargetSyncAngularVelocity2D_30 = value;
	}

	inline static int32_t get_offset_of_m_LastClientSyncTime_31() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_LastClientSyncTime_31)); }
	inline float get_m_LastClientSyncTime_31() const { return ___m_LastClientSyncTime_31; }
	inline float* get_address_of_m_LastClientSyncTime_31() { return &___m_LastClientSyncTime_31; }
	inline void set_m_LastClientSyncTime_31(float value)
	{
		___m_LastClientSyncTime_31 = value;
	}

	inline static int32_t get_offset_of_m_LastClientSendTime_32() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_LastClientSendTime_32)); }
	inline float get_m_LastClientSendTime_32() const { return ___m_LastClientSendTime_32; }
	inline float* get_address_of_m_LastClientSendTime_32() { return &___m_LastClientSendTime_32; }
	inline void set_m_LastClientSendTime_32(float value)
	{
		___m_LastClientSendTime_32 = value;
	}

	inline static int32_t get_offset_of_m_PrevPosition_33() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_PrevPosition_33)); }
	inline Vector3_t2243707580  get_m_PrevPosition_33() const { return ___m_PrevPosition_33; }
	inline Vector3_t2243707580 * get_address_of_m_PrevPosition_33() { return &___m_PrevPosition_33; }
	inline void set_m_PrevPosition_33(Vector3_t2243707580  value)
	{
		___m_PrevPosition_33 = value;
	}

	inline static int32_t get_offset_of_m_PrevRotation_34() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_PrevRotation_34)); }
	inline Quaternion_t4030073918  get_m_PrevRotation_34() const { return ___m_PrevRotation_34; }
	inline Quaternion_t4030073918 * get_address_of_m_PrevRotation_34() { return &___m_PrevRotation_34; }
	inline void set_m_PrevRotation_34(Quaternion_t4030073918  value)
	{
		___m_PrevRotation_34 = value;
	}

	inline static int32_t get_offset_of_m_PrevRotation2D_35() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_PrevRotation2D_35)); }
	inline float get_m_PrevRotation2D_35() const { return ___m_PrevRotation2D_35; }
	inline float* get_address_of_m_PrevRotation2D_35() { return &___m_PrevRotation2D_35; }
	inline void set_m_PrevRotation2D_35(float value)
	{
		___m_PrevRotation2D_35 = value;
	}

	inline static int32_t get_offset_of_m_PrevVelocity_36() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_PrevVelocity_36)); }
	inline float get_m_PrevVelocity_36() const { return ___m_PrevVelocity_36; }
	inline float* get_address_of_m_PrevVelocity_36() { return &___m_PrevVelocity_36; }
	inline void set_m_PrevVelocity_36(float value)
	{
		___m_PrevVelocity_36 = value;
	}

	inline static int32_t get_offset_of_m_LocalTransformWriter_41() { return static_cast<int32_t>(offsetof(NetworkTransform_t1903367356, ___m_LocalTransformWriter_41)); }
	inline NetworkWriter_t560143343 * get_m_LocalTransformWriter_41() const { return ___m_LocalTransformWriter_41; }
	inline NetworkWriter_t560143343 ** get_address_of_m_LocalTransformWriter_41() { return &___m_LocalTransformWriter_41; }
	inline void set_m_LocalTransformWriter_41(NetworkWriter_t560143343 * value)
	{
		___m_LocalTransformWriter_41 = value;
		Il2CppCodeGenWriteBarrier(&___m_LocalTransformWriter_41, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
