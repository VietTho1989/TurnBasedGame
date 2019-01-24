#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.ContactPoint2D[]
struct ContactPoint2DU5BU5D_t1215651809;
struct ContactPoint2D_t3659330976 ;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Collision2D
struct  Collision2D_t1539500754  : public Il2CppObject
{
public:
	// System.Int32 UnityEngine.Collision2D::m_Collider
	int32_t ___m_Collider_0;
	// System.Int32 UnityEngine.Collision2D::m_OtherCollider
	int32_t ___m_OtherCollider_1;
	// System.Int32 UnityEngine.Collision2D::m_Rigidbody
	int32_t ___m_Rigidbody_2;
	// System.Int32 UnityEngine.Collision2D::m_OtherRigidbody
	int32_t ___m_OtherRigidbody_3;
	// UnityEngine.ContactPoint2D[] UnityEngine.Collision2D::m_Contacts
	ContactPoint2DU5BU5D_t1215651809* ___m_Contacts_4;
	// UnityEngine.Vector2 UnityEngine.Collision2D::m_RelativeVelocity
	Vector2_t2243707579  ___m_RelativeVelocity_5;
	// System.Int32 UnityEngine.Collision2D::m_Enabled
	int32_t ___m_Enabled_6;

public:
	inline static int32_t get_offset_of_m_Collider_0() { return static_cast<int32_t>(offsetof(Collision2D_t1539500754, ___m_Collider_0)); }
	inline int32_t get_m_Collider_0() const { return ___m_Collider_0; }
	inline int32_t* get_address_of_m_Collider_0() { return &___m_Collider_0; }
	inline void set_m_Collider_0(int32_t value)
	{
		___m_Collider_0 = value;
	}

	inline static int32_t get_offset_of_m_OtherCollider_1() { return static_cast<int32_t>(offsetof(Collision2D_t1539500754, ___m_OtherCollider_1)); }
	inline int32_t get_m_OtherCollider_1() const { return ___m_OtherCollider_1; }
	inline int32_t* get_address_of_m_OtherCollider_1() { return &___m_OtherCollider_1; }
	inline void set_m_OtherCollider_1(int32_t value)
	{
		___m_OtherCollider_1 = value;
	}

	inline static int32_t get_offset_of_m_Rigidbody_2() { return static_cast<int32_t>(offsetof(Collision2D_t1539500754, ___m_Rigidbody_2)); }
	inline int32_t get_m_Rigidbody_2() const { return ___m_Rigidbody_2; }
	inline int32_t* get_address_of_m_Rigidbody_2() { return &___m_Rigidbody_2; }
	inline void set_m_Rigidbody_2(int32_t value)
	{
		___m_Rigidbody_2 = value;
	}

	inline static int32_t get_offset_of_m_OtherRigidbody_3() { return static_cast<int32_t>(offsetof(Collision2D_t1539500754, ___m_OtherRigidbody_3)); }
	inline int32_t get_m_OtherRigidbody_3() const { return ___m_OtherRigidbody_3; }
	inline int32_t* get_address_of_m_OtherRigidbody_3() { return &___m_OtherRigidbody_3; }
	inline void set_m_OtherRigidbody_3(int32_t value)
	{
		___m_OtherRigidbody_3 = value;
	}

	inline static int32_t get_offset_of_m_Contacts_4() { return static_cast<int32_t>(offsetof(Collision2D_t1539500754, ___m_Contacts_4)); }
	inline ContactPoint2DU5BU5D_t1215651809* get_m_Contacts_4() const { return ___m_Contacts_4; }
	inline ContactPoint2DU5BU5D_t1215651809** get_address_of_m_Contacts_4() { return &___m_Contacts_4; }
	inline void set_m_Contacts_4(ContactPoint2DU5BU5D_t1215651809* value)
	{
		___m_Contacts_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_Contacts_4, value);
	}

	inline static int32_t get_offset_of_m_RelativeVelocity_5() { return static_cast<int32_t>(offsetof(Collision2D_t1539500754, ___m_RelativeVelocity_5)); }
	inline Vector2_t2243707579  get_m_RelativeVelocity_5() const { return ___m_RelativeVelocity_5; }
	inline Vector2_t2243707579 * get_address_of_m_RelativeVelocity_5() { return &___m_RelativeVelocity_5; }
	inline void set_m_RelativeVelocity_5(Vector2_t2243707579  value)
	{
		___m_RelativeVelocity_5 = value;
	}

	inline static int32_t get_offset_of_m_Enabled_6() { return static_cast<int32_t>(offsetof(Collision2D_t1539500754, ___m_Enabled_6)); }
	inline int32_t get_m_Enabled_6() const { return ___m_Enabled_6; }
	inline int32_t* get_address_of_m_Enabled_6() { return &___m_Enabled_6; }
	inline void set_m_Enabled_6(int32_t value)
	{
		___m_Enabled_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Collision2D
struct Collision2D_t1539500754_marshaled_pinvoke
{
	int32_t ___m_Collider_0;
	int32_t ___m_OtherCollider_1;
	int32_t ___m_Rigidbody_2;
	int32_t ___m_OtherRigidbody_3;
	ContactPoint2D_t3659330976 * ___m_Contacts_4;
	Vector2_t2243707579  ___m_RelativeVelocity_5;
	int32_t ___m_Enabled_6;
};
// Native definition for COM marshalling of UnityEngine.Collision2D
struct Collision2D_t1539500754_marshaled_com
{
	int32_t ___m_Collider_0;
	int32_t ___m_OtherCollider_1;
	int32_t ___m_Rigidbody_2;
	int32_t ___m_OtherRigidbody_3;
	ContactPoint2D_t3659330976 * ___m_Contacts_4;
	Vector2_t2243707579  ___m_RelativeVelocity_5;
	int32_t ___m_Enabled_6;
};
