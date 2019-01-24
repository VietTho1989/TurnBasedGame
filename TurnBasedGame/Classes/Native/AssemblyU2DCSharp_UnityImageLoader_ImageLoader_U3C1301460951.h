#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityImageLoader.DisplayOption
struct DisplayOption_t3565155513;
// System.String
struct String_t;
// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityImageLoader.ImageLoader
struct ImageLoader_t1566869356;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.ImageLoader/<DisplayFromHttp>c__AnonStorey2
struct  U3CDisplayFromHttpU3Ec__AnonStorey2_t1301460951  : public Il2CppObject
{
public:
	// UnityImageLoader.DisplayOption UnityImageLoader.ImageLoader/<DisplayFromHttp>c__AnonStorey2::option
	DisplayOption_t3565155513 * ___option_0;
	// System.String UnityImageLoader.ImageLoader/<DisplayFromHttp>c__AnonStorey2::uri
	String_t* ___uri_1;
	// UnityEngine.UI.Image UnityImageLoader.ImageLoader/<DisplayFromHttp>c__AnonStorey2::image
	Image_t2042527209 * ___image_2;
	// UnityImageLoader.ImageLoader UnityImageLoader.ImageLoader/<DisplayFromHttp>c__AnonStorey2::$this
	ImageLoader_t1566869356 * ___U24this_3;

public:
	inline static int32_t get_offset_of_option_0() { return static_cast<int32_t>(offsetof(U3CDisplayFromHttpU3Ec__AnonStorey2_t1301460951, ___option_0)); }
	inline DisplayOption_t3565155513 * get_option_0() const { return ___option_0; }
	inline DisplayOption_t3565155513 ** get_address_of_option_0() { return &___option_0; }
	inline void set_option_0(DisplayOption_t3565155513 * value)
	{
		___option_0 = value;
		Il2CppCodeGenWriteBarrier(&___option_0, value);
	}

	inline static int32_t get_offset_of_uri_1() { return static_cast<int32_t>(offsetof(U3CDisplayFromHttpU3Ec__AnonStorey2_t1301460951, ___uri_1)); }
	inline String_t* get_uri_1() const { return ___uri_1; }
	inline String_t** get_address_of_uri_1() { return &___uri_1; }
	inline void set_uri_1(String_t* value)
	{
		___uri_1 = value;
		Il2CppCodeGenWriteBarrier(&___uri_1, value);
	}

	inline static int32_t get_offset_of_image_2() { return static_cast<int32_t>(offsetof(U3CDisplayFromHttpU3Ec__AnonStorey2_t1301460951, ___image_2)); }
	inline Image_t2042527209 * get_image_2() const { return ___image_2; }
	inline Image_t2042527209 ** get_address_of_image_2() { return &___image_2; }
	inline void set_image_2(Image_t2042527209 * value)
	{
		___image_2 = value;
		Il2CppCodeGenWriteBarrier(&___image_2, value);
	}

	inline static int32_t get_offset_of_U24this_3() { return static_cast<int32_t>(offsetof(U3CDisplayFromHttpU3Ec__AnonStorey2_t1301460951, ___U24this_3)); }
	inline ImageLoader_t1566869356 * get_U24this_3() const { return ___U24this_3; }
	inline ImageLoader_t1566869356 ** get_address_of_U24this_3() { return &___U24this_3; }
	inline void set_U24this_3(ImageLoader_t1566869356 * value)
	{
		___U24this_3 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
