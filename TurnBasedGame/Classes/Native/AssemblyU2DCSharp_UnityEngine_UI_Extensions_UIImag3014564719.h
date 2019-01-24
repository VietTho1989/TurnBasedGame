#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.MaskableGraphic
struct MaskableGraphic_t540192618;
// UnityEngine.Material
struct Material_t193706927;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIImageCrop
struct  UIImageCrop_t3014564719  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.MaskableGraphic UnityEngine.UI.Extensions.UIImageCrop::mGraphic
	MaskableGraphic_t540192618 * ___mGraphic_2;
	// UnityEngine.Material UnityEngine.UI.Extensions.UIImageCrop::mat
	Material_t193706927 * ___mat_3;
	// System.Int32 UnityEngine.UI.Extensions.UIImageCrop::XCropProperty
	int32_t ___XCropProperty_4;
	// System.Int32 UnityEngine.UI.Extensions.UIImageCrop::YCropProperty
	int32_t ___YCropProperty_5;
	// System.Single UnityEngine.UI.Extensions.UIImageCrop::XCrop
	float ___XCrop_6;
	// System.Single UnityEngine.UI.Extensions.UIImageCrop::YCrop
	float ___YCrop_7;

public:
	inline static int32_t get_offset_of_mGraphic_2() { return static_cast<int32_t>(offsetof(UIImageCrop_t3014564719, ___mGraphic_2)); }
	inline MaskableGraphic_t540192618 * get_mGraphic_2() const { return ___mGraphic_2; }
	inline MaskableGraphic_t540192618 ** get_address_of_mGraphic_2() { return &___mGraphic_2; }
	inline void set_mGraphic_2(MaskableGraphic_t540192618 * value)
	{
		___mGraphic_2 = value;
		Il2CppCodeGenWriteBarrier(&___mGraphic_2, value);
	}

	inline static int32_t get_offset_of_mat_3() { return static_cast<int32_t>(offsetof(UIImageCrop_t3014564719, ___mat_3)); }
	inline Material_t193706927 * get_mat_3() const { return ___mat_3; }
	inline Material_t193706927 ** get_address_of_mat_3() { return &___mat_3; }
	inline void set_mat_3(Material_t193706927 * value)
	{
		___mat_3 = value;
		Il2CppCodeGenWriteBarrier(&___mat_3, value);
	}

	inline static int32_t get_offset_of_XCropProperty_4() { return static_cast<int32_t>(offsetof(UIImageCrop_t3014564719, ___XCropProperty_4)); }
	inline int32_t get_XCropProperty_4() const { return ___XCropProperty_4; }
	inline int32_t* get_address_of_XCropProperty_4() { return &___XCropProperty_4; }
	inline void set_XCropProperty_4(int32_t value)
	{
		___XCropProperty_4 = value;
	}

	inline static int32_t get_offset_of_YCropProperty_5() { return static_cast<int32_t>(offsetof(UIImageCrop_t3014564719, ___YCropProperty_5)); }
	inline int32_t get_YCropProperty_5() const { return ___YCropProperty_5; }
	inline int32_t* get_address_of_YCropProperty_5() { return &___YCropProperty_5; }
	inline void set_YCropProperty_5(int32_t value)
	{
		___YCropProperty_5 = value;
	}

	inline static int32_t get_offset_of_XCrop_6() { return static_cast<int32_t>(offsetof(UIImageCrop_t3014564719, ___XCrop_6)); }
	inline float get_XCrop_6() const { return ___XCrop_6; }
	inline float* get_address_of_XCrop_6() { return &___XCrop_6; }
	inline void set_XCrop_6(float value)
	{
		___XCrop_6 = value;
	}

	inline static int32_t get_offset_of_YCrop_7() { return static_cast<int32_t>(offsetof(UIImageCrop_t3014564719, ___YCrop_7)); }
	inline float get_YCrop_7() const { return ___YCrop_7; }
	inline float* get_address_of_YCrop_7() { return &___YCrop_7; }
	inline void set_YCrop_7(float value)
	{
		___YCrop_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
