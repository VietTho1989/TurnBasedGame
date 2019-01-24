#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "UnityEngine_UnityEngine_Quaternion4030073918.h"

// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.TransformBinder
struct  TransformBinder_t3780348990  : public BindingBase_t2590300386
{
public:
	// System.Boolean Foundation.Databinding.TransformBinder::_doPosition
	bool ____doPosition_9;
	// System.Boolean Foundation.Databinding.TransformBinder::_doRotation
	bool ____doRotation_10;
	// System.Boolean Foundation.Databinding.TransformBinder::_doScale
	bool ____doScale_11;
	// UnityEngine.Vector3 Foundation.Databinding.TransformBinder::_position
	Vector3_t2243707580  ____position_12;
	// UnityEngine.Quaternion Foundation.Databinding.TransformBinder::_rotation
	Quaternion_t4030073918  ____rotation_13;
	// UnityEngine.Vector3 Foundation.Databinding.TransformBinder::_scale
	Vector3_t2243707580  ____scale_14;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.TransformBinder::PositionBinding
	BindingInfo_t2210172430 * ___PositionBinding_15;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.TransformBinder::RotationBinding
	BindingInfo_t2210172430 * ___RotationBinding_16;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.TransformBinder::ScaleBinding
	BindingInfo_t2210172430 * ___ScaleBinding_17;
	// UnityEngine.Transform Foundation.Databinding.TransformBinder::Transform
	Transform_t3275118058 * ___Transform_18;

public:
	inline static int32_t get_offset_of__doPosition_9() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ____doPosition_9)); }
	inline bool get__doPosition_9() const { return ____doPosition_9; }
	inline bool* get_address_of__doPosition_9() { return &____doPosition_9; }
	inline void set__doPosition_9(bool value)
	{
		____doPosition_9 = value;
	}

	inline static int32_t get_offset_of__doRotation_10() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ____doRotation_10)); }
	inline bool get__doRotation_10() const { return ____doRotation_10; }
	inline bool* get_address_of__doRotation_10() { return &____doRotation_10; }
	inline void set__doRotation_10(bool value)
	{
		____doRotation_10 = value;
	}

	inline static int32_t get_offset_of__doScale_11() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ____doScale_11)); }
	inline bool get__doScale_11() const { return ____doScale_11; }
	inline bool* get_address_of__doScale_11() { return &____doScale_11; }
	inline void set__doScale_11(bool value)
	{
		____doScale_11 = value;
	}

	inline static int32_t get_offset_of__position_12() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ____position_12)); }
	inline Vector3_t2243707580  get__position_12() const { return ____position_12; }
	inline Vector3_t2243707580 * get_address_of__position_12() { return &____position_12; }
	inline void set__position_12(Vector3_t2243707580  value)
	{
		____position_12 = value;
	}

	inline static int32_t get_offset_of__rotation_13() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ____rotation_13)); }
	inline Quaternion_t4030073918  get__rotation_13() const { return ____rotation_13; }
	inline Quaternion_t4030073918 * get_address_of__rotation_13() { return &____rotation_13; }
	inline void set__rotation_13(Quaternion_t4030073918  value)
	{
		____rotation_13 = value;
	}

	inline static int32_t get_offset_of__scale_14() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ____scale_14)); }
	inline Vector3_t2243707580  get__scale_14() const { return ____scale_14; }
	inline Vector3_t2243707580 * get_address_of__scale_14() { return &____scale_14; }
	inline void set__scale_14(Vector3_t2243707580  value)
	{
		____scale_14 = value;
	}

	inline static int32_t get_offset_of_PositionBinding_15() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ___PositionBinding_15)); }
	inline BindingInfo_t2210172430 * get_PositionBinding_15() const { return ___PositionBinding_15; }
	inline BindingInfo_t2210172430 ** get_address_of_PositionBinding_15() { return &___PositionBinding_15; }
	inline void set_PositionBinding_15(BindingInfo_t2210172430 * value)
	{
		___PositionBinding_15 = value;
		Il2CppCodeGenWriteBarrier(&___PositionBinding_15, value);
	}

	inline static int32_t get_offset_of_RotationBinding_16() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ___RotationBinding_16)); }
	inline BindingInfo_t2210172430 * get_RotationBinding_16() const { return ___RotationBinding_16; }
	inline BindingInfo_t2210172430 ** get_address_of_RotationBinding_16() { return &___RotationBinding_16; }
	inline void set_RotationBinding_16(BindingInfo_t2210172430 * value)
	{
		___RotationBinding_16 = value;
		Il2CppCodeGenWriteBarrier(&___RotationBinding_16, value);
	}

	inline static int32_t get_offset_of_ScaleBinding_17() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ___ScaleBinding_17)); }
	inline BindingInfo_t2210172430 * get_ScaleBinding_17() const { return ___ScaleBinding_17; }
	inline BindingInfo_t2210172430 ** get_address_of_ScaleBinding_17() { return &___ScaleBinding_17; }
	inline void set_ScaleBinding_17(BindingInfo_t2210172430 * value)
	{
		___ScaleBinding_17 = value;
		Il2CppCodeGenWriteBarrier(&___ScaleBinding_17, value);
	}

	inline static int32_t get_offset_of_Transform_18() { return static_cast<int32_t>(offsetof(TransformBinder_t3780348990, ___Transform_18)); }
	inline Transform_t3275118058 * get_Transform_18() const { return ___Transform_18; }
	inline Transform_t3275118058 ** get_address_of_Transform_18() { return &___Transform_18; }
	inline void set_Transform_18(Transform_t3275118058 * value)
	{
		___Transform_18 = value;
		Il2CppCodeGenWriteBarrier(&___Transform_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
