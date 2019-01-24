#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<UnityEngine.Vector3>
struct VP_1_t2621984586;
// VP`1<UnityEngine.Quaternion>
struct VP_1_t113383628;
// VP`1<UnityEngine.Vector2>
struct VP_1_t2621984585;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UpdateTransform/UpdateData
struct  UpdateData_t2488869861  : public Data_t3569509720
{
public:
	// VP`1<UnityEngine.Vector3> UpdateTransform/UpdateData::position
	VP_1_t2621984586 * ___position_5;
	// VP`1<UnityEngine.Quaternion> UpdateTransform/UpdateData::rotation
	VP_1_t113383628 * ___rotation_6;
	// VP`1<UnityEngine.Vector3> UpdateTransform/UpdateData::scale
	VP_1_t2621984586 * ___scale_7;
	// VP`1<UnityEngine.Vector2> UpdateTransform/UpdateData::size
	VP_1_t2621984585 * ___size_8;

public:
	inline static int32_t get_offset_of_position_5() { return static_cast<int32_t>(offsetof(UpdateData_t2488869861, ___position_5)); }
	inline VP_1_t2621984586 * get_position_5() const { return ___position_5; }
	inline VP_1_t2621984586 ** get_address_of_position_5() { return &___position_5; }
	inline void set_position_5(VP_1_t2621984586 * value)
	{
		___position_5 = value;
		Il2CppCodeGenWriteBarrier(&___position_5, value);
	}

	inline static int32_t get_offset_of_rotation_6() { return static_cast<int32_t>(offsetof(UpdateData_t2488869861, ___rotation_6)); }
	inline VP_1_t113383628 * get_rotation_6() const { return ___rotation_6; }
	inline VP_1_t113383628 ** get_address_of_rotation_6() { return &___rotation_6; }
	inline void set_rotation_6(VP_1_t113383628 * value)
	{
		___rotation_6 = value;
		Il2CppCodeGenWriteBarrier(&___rotation_6, value);
	}

	inline static int32_t get_offset_of_scale_7() { return static_cast<int32_t>(offsetof(UpdateData_t2488869861, ___scale_7)); }
	inline VP_1_t2621984586 * get_scale_7() const { return ___scale_7; }
	inline VP_1_t2621984586 ** get_address_of_scale_7() { return &___scale_7; }
	inline void set_scale_7(VP_1_t2621984586 * value)
	{
		___scale_7 = value;
		Il2CppCodeGenWriteBarrier(&___scale_7, value);
	}

	inline static int32_t get_offset_of_size_8() { return static_cast<int32_t>(offsetof(UpdateData_t2488869861, ___size_8)); }
	inline VP_1_t2621984585 * get_size_8() const { return ___size_8; }
	inline VP_1_t2621984585 ** get_address_of_size_8() { return &___size_8; }
	inline void set_size_8(VP_1_t2621984585 * value)
	{
		___size_8 = value;
		Il2CppCodeGenWriteBarrier(&___size_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
