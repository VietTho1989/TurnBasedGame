#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "UnityEngine_UnityEngine_Quaternion4030073918.h"

// System.String
struct String_t;
// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.ObjectComponent>
struct List_1_t2504701132;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.SceneObject
struct  SceneObject_t966911541  : public Il2CppObject
{
public:
	// System.String UnityEngine.UI.Extensions.SceneObject::name
	String_t* ___name_0;
	// System.String UnityEngine.UI.Extensions.SceneObject::prefabName
	String_t* ___prefabName_1;
	// System.String UnityEngine.UI.Extensions.SceneObject::id
	String_t* ___id_2;
	// System.String UnityEngine.UI.Extensions.SceneObject::idParent
	String_t* ___idParent_3;
	// System.Boolean UnityEngine.UI.Extensions.SceneObject::active
	bool ___active_4;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.SceneObject::position
	Vector3_t2243707580  ___position_5;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.SceneObject::localScale
	Vector3_t2243707580  ___localScale_6;
	// UnityEngine.Quaternion UnityEngine.UI.Extensions.SceneObject::rotation
	Quaternion_t4030073918  ___rotation_7;
	// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.ObjectComponent> UnityEngine.UI.Extensions.SceneObject::objectComponents
	List_1_t2504701132 * ___objectComponents_8;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier(&___name_0, value);
	}

	inline static int32_t get_offset_of_prefabName_1() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___prefabName_1)); }
	inline String_t* get_prefabName_1() const { return ___prefabName_1; }
	inline String_t** get_address_of_prefabName_1() { return &___prefabName_1; }
	inline void set_prefabName_1(String_t* value)
	{
		___prefabName_1 = value;
		Il2CppCodeGenWriteBarrier(&___prefabName_1, value);
	}

	inline static int32_t get_offset_of_id_2() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___id_2)); }
	inline String_t* get_id_2() const { return ___id_2; }
	inline String_t** get_address_of_id_2() { return &___id_2; }
	inline void set_id_2(String_t* value)
	{
		___id_2 = value;
		Il2CppCodeGenWriteBarrier(&___id_2, value);
	}

	inline static int32_t get_offset_of_idParent_3() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___idParent_3)); }
	inline String_t* get_idParent_3() const { return ___idParent_3; }
	inline String_t** get_address_of_idParent_3() { return &___idParent_3; }
	inline void set_idParent_3(String_t* value)
	{
		___idParent_3 = value;
		Il2CppCodeGenWriteBarrier(&___idParent_3, value);
	}

	inline static int32_t get_offset_of_active_4() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___active_4)); }
	inline bool get_active_4() const { return ___active_4; }
	inline bool* get_address_of_active_4() { return &___active_4; }
	inline void set_active_4(bool value)
	{
		___active_4 = value;
	}

	inline static int32_t get_offset_of_position_5() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___position_5)); }
	inline Vector3_t2243707580  get_position_5() const { return ___position_5; }
	inline Vector3_t2243707580 * get_address_of_position_5() { return &___position_5; }
	inline void set_position_5(Vector3_t2243707580  value)
	{
		___position_5 = value;
	}

	inline static int32_t get_offset_of_localScale_6() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___localScale_6)); }
	inline Vector3_t2243707580  get_localScale_6() const { return ___localScale_6; }
	inline Vector3_t2243707580 * get_address_of_localScale_6() { return &___localScale_6; }
	inline void set_localScale_6(Vector3_t2243707580  value)
	{
		___localScale_6 = value;
	}

	inline static int32_t get_offset_of_rotation_7() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___rotation_7)); }
	inline Quaternion_t4030073918  get_rotation_7() const { return ___rotation_7; }
	inline Quaternion_t4030073918 * get_address_of_rotation_7() { return &___rotation_7; }
	inline void set_rotation_7(Quaternion_t4030073918  value)
	{
		___rotation_7 = value;
	}

	inline static int32_t get_offset_of_objectComponents_8() { return static_cast<int32_t>(offsetof(SceneObject_t966911541, ___objectComponents_8)); }
	inline List_1_t2504701132 * get_objectComponents_8() const { return ___objectComponents_8; }
	inline List_1_t2504701132 ** get_address_of_objectComponents_8() { return &___objectComponents_8; }
	inline void set_objectComponents_8(List_1_t2504701132 * value)
	{
		___objectComponents_8 = value;
		Il2CppCodeGenWriteBarrier(&___objectComponents_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
