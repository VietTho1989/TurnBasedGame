#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ObjectIdentifier
struct  ObjectIdentifier_t2981030592  : public MonoBehaviour_t1158329972
{
public:
	// System.String UnityEngine.UI.Extensions.ObjectIdentifier::prefabName
	String_t* ___prefabName_2;
	// System.String UnityEngine.UI.Extensions.ObjectIdentifier::id
	String_t* ___id_3;
	// System.String UnityEngine.UI.Extensions.ObjectIdentifier::idParent
	String_t* ___idParent_4;
	// System.Boolean UnityEngine.UI.Extensions.ObjectIdentifier::dontSave
	bool ___dontSave_5;

public:
	inline static int32_t get_offset_of_prefabName_2() { return static_cast<int32_t>(offsetof(ObjectIdentifier_t2981030592, ___prefabName_2)); }
	inline String_t* get_prefabName_2() const { return ___prefabName_2; }
	inline String_t** get_address_of_prefabName_2() { return &___prefabName_2; }
	inline void set_prefabName_2(String_t* value)
	{
		___prefabName_2 = value;
		Il2CppCodeGenWriteBarrier(&___prefabName_2, value);
	}

	inline static int32_t get_offset_of_id_3() { return static_cast<int32_t>(offsetof(ObjectIdentifier_t2981030592, ___id_3)); }
	inline String_t* get_id_3() const { return ___id_3; }
	inline String_t** get_address_of_id_3() { return &___id_3; }
	inline void set_id_3(String_t* value)
	{
		___id_3 = value;
		Il2CppCodeGenWriteBarrier(&___id_3, value);
	}

	inline static int32_t get_offset_of_idParent_4() { return static_cast<int32_t>(offsetof(ObjectIdentifier_t2981030592, ___idParent_4)); }
	inline String_t* get_idParent_4() const { return ___idParent_4; }
	inline String_t** get_address_of_idParent_4() { return &___idParent_4; }
	inline void set_idParent_4(String_t* value)
	{
		___idParent_4 = value;
		Il2CppCodeGenWriteBarrier(&___idParent_4, value);
	}

	inline static int32_t get_offset_of_dontSave_5() { return static_cast<int32_t>(offsetof(ObjectIdentifier_t2981030592, ___dontSave_5)); }
	inline bool get_dontSave_5() const { return ___dontSave_5; }
	inline bool* get_address_of_dontSave_5() { return &___dontSave_5; }
	inline void set_dontSave_5(bool value)
	{
		___dontSave_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
