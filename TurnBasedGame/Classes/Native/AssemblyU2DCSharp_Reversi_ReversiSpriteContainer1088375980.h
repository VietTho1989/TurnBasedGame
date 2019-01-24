#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// Reversi.ReversiSpriteContainer
struct ReversiSpriteContainer_t1088375980;
// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiSpriteContainer
struct  ReversiSpriteContainer_t1088375980  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Sprite Reversi.ReversiSpriteContainer::none
	Sprite_t309593783 * ___none_3;
	// UnityEngine.Sprite Reversi.ReversiSpriteContainer::white
	Sprite_t309593783 * ___white_4;
	// UnityEngine.Sprite Reversi.ReversiSpriteContainer::black
	Sprite_t309593783 * ___black_5;

public:
	inline static int32_t get_offset_of_none_3() { return static_cast<int32_t>(offsetof(ReversiSpriteContainer_t1088375980, ___none_3)); }
	inline Sprite_t309593783 * get_none_3() const { return ___none_3; }
	inline Sprite_t309593783 ** get_address_of_none_3() { return &___none_3; }
	inline void set_none_3(Sprite_t309593783 * value)
	{
		___none_3 = value;
		Il2CppCodeGenWriteBarrier(&___none_3, value);
	}

	inline static int32_t get_offset_of_white_4() { return static_cast<int32_t>(offsetof(ReversiSpriteContainer_t1088375980, ___white_4)); }
	inline Sprite_t309593783 * get_white_4() const { return ___white_4; }
	inline Sprite_t309593783 ** get_address_of_white_4() { return &___white_4; }
	inline void set_white_4(Sprite_t309593783 * value)
	{
		___white_4 = value;
		Il2CppCodeGenWriteBarrier(&___white_4, value);
	}

	inline static int32_t get_offset_of_black_5() { return static_cast<int32_t>(offsetof(ReversiSpriteContainer_t1088375980, ___black_5)); }
	inline Sprite_t309593783 * get_black_5() const { return ___black_5; }
	inline Sprite_t309593783 ** get_address_of_black_5() { return &___black_5; }
	inline void set_black_5(Sprite_t309593783 * value)
	{
		___black_5 = value;
		Il2CppCodeGenWriteBarrier(&___black_5, value);
	}
};

struct ReversiSpriteContainer_t1088375980_StaticFields
{
public:
	// Reversi.ReversiSpriteContainer Reversi.ReversiSpriteContainer::instance
	ReversiSpriteContainer_t1088375980 * ___instance_2;

public:
	inline static int32_t get_offset_of_instance_2() { return static_cast<int32_t>(offsetof(ReversiSpriteContainer_t1088375980_StaticFields, ___instance_2)); }
	inline ReversiSpriteContainer_t1088375980 * get_instance_2() const { return ___instance_2; }
	inline ReversiSpriteContainer_t1088375980 ** get_address_of_instance_2() { return &___instance_2; }
	inline void set_instance_2(ReversiSpriteContainer_t1088375980 * value)
	{
		___instance_2 = value;
		Il2CppCodeGenWriteBarrier(&___instance_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
