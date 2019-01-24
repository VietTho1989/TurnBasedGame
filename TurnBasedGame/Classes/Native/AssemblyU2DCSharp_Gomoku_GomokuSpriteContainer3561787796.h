#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// Gomoku.GomokuSpriteContainer
struct GomokuSpriteContainer_t3561787796;
// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuSpriteContainer
struct  GomokuSpriteContainer_t3561787796  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Sprite Gomoku.GomokuSpriteContainer::None
	Sprite_t309593783 * ___None_3;
	// UnityEngine.Sprite Gomoku.GomokuSpriteContainer::Black
	Sprite_t309593783 * ___Black_4;
	// UnityEngine.Sprite Gomoku.GomokuSpriteContainer::White
	Sprite_t309593783 * ___White_5;

public:
	inline static int32_t get_offset_of_None_3() { return static_cast<int32_t>(offsetof(GomokuSpriteContainer_t3561787796, ___None_3)); }
	inline Sprite_t309593783 * get_None_3() const { return ___None_3; }
	inline Sprite_t309593783 ** get_address_of_None_3() { return &___None_3; }
	inline void set_None_3(Sprite_t309593783 * value)
	{
		___None_3 = value;
		Il2CppCodeGenWriteBarrier(&___None_3, value);
	}

	inline static int32_t get_offset_of_Black_4() { return static_cast<int32_t>(offsetof(GomokuSpriteContainer_t3561787796, ___Black_4)); }
	inline Sprite_t309593783 * get_Black_4() const { return ___Black_4; }
	inline Sprite_t309593783 ** get_address_of_Black_4() { return &___Black_4; }
	inline void set_Black_4(Sprite_t309593783 * value)
	{
		___Black_4 = value;
		Il2CppCodeGenWriteBarrier(&___Black_4, value);
	}

	inline static int32_t get_offset_of_White_5() { return static_cast<int32_t>(offsetof(GomokuSpriteContainer_t3561787796, ___White_5)); }
	inline Sprite_t309593783 * get_White_5() const { return ___White_5; }
	inline Sprite_t309593783 ** get_address_of_White_5() { return &___White_5; }
	inline void set_White_5(Sprite_t309593783 * value)
	{
		___White_5 = value;
		Il2CppCodeGenWriteBarrier(&___White_5, value);
	}
};

struct GomokuSpriteContainer_t3561787796_StaticFields
{
public:
	// Gomoku.GomokuSpriteContainer Gomoku.GomokuSpriteContainer::instance
	GomokuSpriteContainer_t3561787796 * ___instance_2;

public:
	inline static int32_t get_offset_of_instance_2() { return static_cast<int32_t>(offsetof(GomokuSpriteContainer_t3561787796_StaticFields, ___instance_2)); }
	inline GomokuSpriteContainer_t3561787796 * get_instance_2() const { return ___instance_2; }
	inline GomokuSpriteContainer_t3561787796 ** get_address_of_instance_2() { return &___instance_2; }
	inline void set_instance_2(GomokuSpriteContainer_t3561787796 * value)
	{
		___instance_2 = value;
		Il2CppCodeGenWriteBarrier(&___instance_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
