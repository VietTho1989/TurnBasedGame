#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.DisplayOption/Builder
struct  Builder_t2256807724  : public Il2CppObject
{
public:
	// System.Boolean UnityImageLoader.DisplayOption/Builder::isMemoryCache
	bool ___isMemoryCache_0;
	// System.Boolean UnityImageLoader.DisplayOption/Builder::isDiscCache
	bool ___isDiscCache_1;
	// System.String UnityImageLoader.DisplayOption/Builder::loadingImagePath
	String_t* ___loadingImagePath_2;
	// System.String UnityImageLoader.DisplayOption/Builder::loadErrorImagePath
	String_t* ___loadErrorImagePath_3;
	// UnityEngine.Sprite UnityImageLoader.DisplayOption/Builder::loadingSprite
	Sprite_t309593783 * ___loadingSprite_4;
	// UnityEngine.Sprite UnityImageLoader.DisplayOption/Builder::loadErrorSprite
	Sprite_t309593783 * ___loadErrorSprite_5;

public:
	inline static int32_t get_offset_of_isMemoryCache_0() { return static_cast<int32_t>(offsetof(Builder_t2256807724, ___isMemoryCache_0)); }
	inline bool get_isMemoryCache_0() const { return ___isMemoryCache_0; }
	inline bool* get_address_of_isMemoryCache_0() { return &___isMemoryCache_0; }
	inline void set_isMemoryCache_0(bool value)
	{
		___isMemoryCache_0 = value;
	}

	inline static int32_t get_offset_of_isDiscCache_1() { return static_cast<int32_t>(offsetof(Builder_t2256807724, ___isDiscCache_1)); }
	inline bool get_isDiscCache_1() const { return ___isDiscCache_1; }
	inline bool* get_address_of_isDiscCache_1() { return &___isDiscCache_1; }
	inline void set_isDiscCache_1(bool value)
	{
		___isDiscCache_1 = value;
	}

	inline static int32_t get_offset_of_loadingImagePath_2() { return static_cast<int32_t>(offsetof(Builder_t2256807724, ___loadingImagePath_2)); }
	inline String_t* get_loadingImagePath_2() const { return ___loadingImagePath_2; }
	inline String_t** get_address_of_loadingImagePath_2() { return &___loadingImagePath_2; }
	inline void set_loadingImagePath_2(String_t* value)
	{
		___loadingImagePath_2 = value;
		Il2CppCodeGenWriteBarrier(&___loadingImagePath_2, value);
	}

	inline static int32_t get_offset_of_loadErrorImagePath_3() { return static_cast<int32_t>(offsetof(Builder_t2256807724, ___loadErrorImagePath_3)); }
	inline String_t* get_loadErrorImagePath_3() const { return ___loadErrorImagePath_3; }
	inline String_t** get_address_of_loadErrorImagePath_3() { return &___loadErrorImagePath_3; }
	inline void set_loadErrorImagePath_3(String_t* value)
	{
		___loadErrorImagePath_3 = value;
		Il2CppCodeGenWriteBarrier(&___loadErrorImagePath_3, value);
	}

	inline static int32_t get_offset_of_loadingSprite_4() { return static_cast<int32_t>(offsetof(Builder_t2256807724, ___loadingSprite_4)); }
	inline Sprite_t309593783 * get_loadingSprite_4() const { return ___loadingSprite_4; }
	inline Sprite_t309593783 ** get_address_of_loadingSprite_4() { return &___loadingSprite_4; }
	inline void set_loadingSprite_4(Sprite_t309593783 * value)
	{
		___loadingSprite_4 = value;
		Il2CppCodeGenWriteBarrier(&___loadingSprite_4, value);
	}

	inline static int32_t get_offset_of_loadErrorSprite_5() { return static_cast<int32_t>(offsetof(Builder_t2256807724, ___loadErrorSprite_5)); }
	inline Sprite_t309593783 * get_loadErrorSprite_5() const { return ___loadErrorSprite_5; }
	inline Sprite_t309593783 ** get_address_of_loadErrorSprite_5() { return &___loadErrorSprite_5; }
	inline void set_loadErrorSprite_5(Sprite_t309593783 * value)
	{
		___loadErrorSprite_5 = value;
		Il2CppCodeGenWriteBarrier(&___loadErrorSprite_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
