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
// System.String
struct String_t;
// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UrlImage
struct  UrlImage_t451595586  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Image UrlImage::Image
	Image_t2042527209 * ___Image_2;
	// System.String UrlImage::url
	String_t* ___url_3;
	// System.String UrlImage::loadingPath
	String_t* ___loadingPath_4;
	// System.String UrlImage::errorPath
	String_t* ___errorPath_5;
	// UnityEngine.Sprite UrlImage::loadingSprite
	Sprite_t309593783 * ___loadingSprite_6;
	// UnityEngine.Sprite UrlImage::errorSprite
	Sprite_t309593783 * ___errorSprite_7;

public:
	inline static int32_t get_offset_of_Image_2() { return static_cast<int32_t>(offsetof(UrlImage_t451595586, ___Image_2)); }
	inline Image_t2042527209 * get_Image_2() const { return ___Image_2; }
	inline Image_t2042527209 ** get_address_of_Image_2() { return &___Image_2; }
	inline void set_Image_2(Image_t2042527209 * value)
	{
		___Image_2 = value;
		Il2CppCodeGenWriteBarrier(&___Image_2, value);
	}

	inline static int32_t get_offset_of_url_3() { return static_cast<int32_t>(offsetof(UrlImage_t451595586, ___url_3)); }
	inline String_t* get_url_3() const { return ___url_3; }
	inline String_t** get_address_of_url_3() { return &___url_3; }
	inline void set_url_3(String_t* value)
	{
		___url_3 = value;
		Il2CppCodeGenWriteBarrier(&___url_3, value);
	}

	inline static int32_t get_offset_of_loadingPath_4() { return static_cast<int32_t>(offsetof(UrlImage_t451595586, ___loadingPath_4)); }
	inline String_t* get_loadingPath_4() const { return ___loadingPath_4; }
	inline String_t** get_address_of_loadingPath_4() { return &___loadingPath_4; }
	inline void set_loadingPath_4(String_t* value)
	{
		___loadingPath_4 = value;
		Il2CppCodeGenWriteBarrier(&___loadingPath_4, value);
	}

	inline static int32_t get_offset_of_errorPath_5() { return static_cast<int32_t>(offsetof(UrlImage_t451595586, ___errorPath_5)); }
	inline String_t* get_errorPath_5() const { return ___errorPath_5; }
	inline String_t** get_address_of_errorPath_5() { return &___errorPath_5; }
	inline void set_errorPath_5(String_t* value)
	{
		___errorPath_5 = value;
		Il2CppCodeGenWriteBarrier(&___errorPath_5, value);
	}

	inline static int32_t get_offset_of_loadingSprite_6() { return static_cast<int32_t>(offsetof(UrlImage_t451595586, ___loadingSprite_6)); }
	inline Sprite_t309593783 * get_loadingSprite_6() const { return ___loadingSprite_6; }
	inline Sprite_t309593783 ** get_address_of_loadingSprite_6() { return &___loadingSprite_6; }
	inline void set_loadingSprite_6(Sprite_t309593783 * value)
	{
		___loadingSprite_6 = value;
		Il2CppCodeGenWriteBarrier(&___loadingSprite_6, value);
	}

	inline static int32_t get_offset_of_errorSprite_7() { return static_cast<int32_t>(offsetof(UrlImage_t451595586, ___errorSprite_7)); }
	inline Sprite_t309593783 * get_errorSprite_7() const { return ___errorSprite_7; }
	inline Sprite_t309593783 ** get_address_of_errorSprite_7() { return &___errorSprite_7; }
	inline void set_errorSprite_7(Sprite_t309593783 * value)
	{
		___errorSprite_7 = value;
		Il2CppCodeGenWriteBarrier(&___errorSprite_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
