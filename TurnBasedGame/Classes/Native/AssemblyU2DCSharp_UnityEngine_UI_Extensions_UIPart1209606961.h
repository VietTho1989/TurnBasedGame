#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_MaskableGraphic540192618.h"
#include "UnityEngine_UnityEngine_Vector42243707581.h"
#include "UnityEngine_UnityEngine_ParticleSystem_TextureShee4262561859.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.Texture
struct Texture_t2243626319;
// UnityEngine.Sprite
struct Sprite_t309593783;
// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.ParticleSystem
struct ParticleSystem_t3394631041;
// UnityEngine.ParticleSystem/Particle[]
struct ParticleU5BU5D_t574222242;
// UnityEngine.UIVertex[]
struct UIVertexU5BU5D_t3048644023;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIParticleSystem
struct  UIParticleSystem_t1209606961  : public MaskableGraphic_t540192618
{
public:
	// UnityEngine.Texture UnityEngine.UI.Extensions.UIParticleSystem::particleTexture
	Texture_t2243626319 * ___particleTexture_28;
	// UnityEngine.Sprite UnityEngine.UI.Extensions.UIParticleSystem::particleSprite
	Sprite_t309593783 * ___particleSprite_29;
	// UnityEngine.Transform UnityEngine.UI.Extensions.UIParticleSystem::_transform
	Transform_t3275118058 * ____transform_30;
	// UnityEngine.ParticleSystem UnityEngine.UI.Extensions.UIParticleSystem::_particleSystem
	ParticleSystem_t3394631041 * ____particleSystem_31;
	// UnityEngine.ParticleSystem/Particle[] UnityEngine.UI.Extensions.UIParticleSystem::_particles
	ParticleU5BU5D_t574222242* ____particles_32;
	// UnityEngine.UIVertex[] UnityEngine.UI.Extensions.UIParticleSystem::_quad
	UIVertexU5BU5D_t3048644023* ____quad_33;
	// UnityEngine.Vector4 UnityEngine.UI.Extensions.UIParticleSystem::_uv
	Vector4_t2243707581  ____uv_34;
	// UnityEngine.ParticleSystem/TextureSheetAnimationModule UnityEngine.UI.Extensions.UIParticleSystem::_textureSheetAnimation
	TextureSheetAnimationModule_t4262561859  ____textureSheetAnimation_35;
	// System.Int32 UnityEngine.UI.Extensions.UIParticleSystem::_textureSheetAnimationFrames
	int32_t ____textureSheetAnimationFrames_36;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UIParticleSystem::_textureSheedAnimationFrameSize
	Vector2_t2243707579  ____textureSheedAnimationFrameSize_37;

public:
	inline static int32_t get_offset_of_particleTexture_28() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ___particleTexture_28)); }
	inline Texture_t2243626319 * get_particleTexture_28() const { return ___particleTexture_28; }
	inline Texture_t2243626319 ** get_address_of_particleTexture_28() { return &___particleTexture_28; }
	inline void set_particleTexture_28(Texture_t2243626319 * value)
	{
		___particleTexture_28 = value;
		Il2CppCodeGenWriteBarrier(&___particleTexture_28, value);
	}

	inline static int32_t get_offset_of_particleSprite_29() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ___particleSprite_29)); }
	inline Sprite_t309593783 * get_particleSprite_29() const { return ___particleSprite_29; }
	inline Sprite_t309593783 ** get_address_of_particleSprite_29() { return &___particleSprite_29; }
	inline void set_particleSprite_29(Sprite_t309593783 * value)
	{
		___particleSprite_29 = value;
		Il2CppCodeGenWriteBarrier(&___particleSprite_29, value);
	}

	inline static int32_t get_offset_of__transform_30() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____transform_30)); }
	inline Transform_t3275118058 * get__transform_30() const { return ____transform_30; }
	inline Transform_t3275118058 ** get_address_of__transform_30() { return &____transform_30; }
	inline void set__transform_30(Transform_t3275118058 * value)
	{
		____transform_30 = value;
		Il2CppCodeGenWriteBarrier(&____transform_30, value);
	}

	inline static int32_t get_offset_of__particleSystem_31() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____particleSystem_31)); }
	inline ParticleSystem_t3394631041 * get__particleSystem_31() const { return ____particleSystem_31; }
	inline ParticleSystem_t3394631041 ** get_address_of__particleSystem_31() { return &____particleSystem_31; }
	inline void set__particleSystem_31(ParticleSystem_t3394631041 * value)
	{
		____particleSystem_31 = value;
		Il2CppCodeGenWriteBarrier(&____particleSystem_31, value);
	}

	inline static int32_t get_offset_of__particles_32() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____particles_32)); }
	inline ParticleU5BU5D_t574222242* get__particles_32() const { return ____particles_32; }
	inline ParticleU5BU5D_t574222242** get_address_of__particles_32() { return &____particles_32; }
	inline void set__particles_32(ParticleU5BU5D_t574222242* value)
	{
		____particles_32 = value;
		Il2CppCodeGenWriteBarrier(&____particles_32, value);
	}

	inline static int32_t get_offset_of__quad_33() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____quad_33)); }
	inline UIVertexU5BU5D_t3048644023* get__quad_33() const { return ____quad_33; }
	inline UIVertexU5BU5D_t3048644023** get_address_of__quad_33() { return &____quad_33; }
	inline void set__quad_33(UIVertexU5BU5D_t3048644023* value)
	{
		____quad_33 = value;
		Il2CppCodeGenWriteBarrier(&____quad_33, value);
	}

	inline static int32_t get_offset_of__uv_34() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____uv_34)); }
	inline Vector4_t2243707581  get__uv_34() const { return ____uv_34; }
	inline Vector4_t2243707581 * get_address_of__uv_34() { return &____uv_34; }
	inline void set__uv_34(Vector4_t2243707581  value)
	{
		____uv_34 = value;
	}

	inline static int32_t get_offset_of__textureSheetAnimation_35() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____textureSheetAnimation_35)); }
	inline TextureSheetAnimationModule_t4262561859  get__textureSheetAnimation_35() const { return ____textureSheetAnimation_35; }
	inline TextureSheetAnimationModule_t4262561859 * get_address_of__textureSheetAnimation_35() { return &____textureSheetAnimation_35; }
	inline void set__textureSheetAnimation_35(TextureSheetAnimationModule_t4262561859  value)
	{
		____textureSheetAnimation_35 = value;
	}

	inline static int32_t get_offset_of__textureSheetAnimationFrames_36() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____textureSheetAnimationFrames_36)); }
	inline int32_t get__textureSheetAnimationFrames_36() const { return ____textureSheetAnimationFrames_36; }
	inline int32_t* get_address_of__textureSheetAnimationFrames_36() { return &____textureSheetAnimationFrames_36; }
	inline void set__textureSheetAnimationFrames_36(int32_t value)
	{
		____textureSheetAnimationFrames_36 = value;
	}

	inline static int32_t get_offset_of__textureSheedAnimationFrameSize_37() { return static_cast<int32_t>(offsetof(UIParticleSystem_t1209606961, ____textureSheedAnimationFrameSize_37)); }
	inline Vector2_t2243707579  get__textureSheedAnimationFrameSize_37() const { return ____textureSheedAnimationFrameSize_37; }
	inline Vector2_t2243707579 * get_address_of__textureSheedAnimationFrameSize_37() { return &____textureSheedAnimationFrameSize_37; }
	inline void set__textureSheedAnimationFrameSize_37(Vector2_t2243707579  value)
	{
		____textureSheedAnimationFrameSize_37 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
