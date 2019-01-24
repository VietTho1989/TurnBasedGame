#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.RaycastMask
struct  RaycastMask_t2005723581  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Image UnityEngine.UI.Extensions.RaycastMask::_image
	Image_t2042527209 * ____image_2;
	// UnityEngine.Sprite UnityEngine.UI.Extensions.RaycastMask::_sprite
	Sprite_t309593783 * ____sprite_3;

public:
	inline static int32_t get_offset_of__image_2() { return static_cast<int32_t>(offsetof(RaycastMask_t2005723581, ____image_2)); }
	inline Image_t2042527209 * get__image_2() const { return ____image_2; }
	inline Image_t2042527209 ** get_address_of__image_2() { return &____image_2; }
	inline void set__image_2(Image_t2042527209 * value)
	{
		____image_2 = value;
		Il2CppCodeGenWriteBarrier(&____image_2, value);
	}

	inline static int32_t get_offset_of__sprite_3() { return static_cast<int32_t>(offsetof(RaycastMask_t2005723581, ____sprite_3)); }
	inline Sprite_t309593783 * get__sprite_3() const { return ____sprite_3; }
	inline Sprite_t309593783 ** get_address_of__sprite_3() { return &____sprite_3; }
	inline void set__sprite_3(Sprite_t309593783 * value)
	{
		____sprite_3 = value;
		Il2CppCodeGenWriteBarrier(&____sprite_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
