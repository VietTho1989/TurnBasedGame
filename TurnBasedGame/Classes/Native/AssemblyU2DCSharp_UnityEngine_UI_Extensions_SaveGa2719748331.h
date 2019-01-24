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
// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.SceneObject>
struct List_1_t336032673;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.SaveGame
struct  SaveGame_t2719748331  : public Il2CppObject
{
public:
	// System.String UnityEngine.UI.Extensions.SaveGame::savegameName
	String_t* ___savegameName_0;
	// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.SceneObject> UnityEngine.UI.Extensions.SaveGame::sceneObjects
	List_1_t336032673 * ___sceneObjects_1;

public:
	inline static int32_t get_offset_of_savegameName_0() { return static_cast<int32_t>(offsetof(SaveGame_t2719748331, ___savegameName_0)); }
	inline String_t* get_savegameName_0() const { return ___savegameName_0; }
	inline String_t** get_address_of_savegameName_0() { return &___savegameName_0; }
	inline void set_savegameName_0(String_t* value)
	{
		___savegameName_0 = value;
		Il2CppCodeGenWriteBarrier(&___savegameName_0, value);
	}

	inline static int32_t get_offset_of_sceneObjects_1() { return static_cast<int32_t>(offsetof(SaveGame_t2719748331, ___sceneObjects_1)); }
	inline List_1_t336032673 * get_sceneObjects_1() const { return ___sceneObjects_1; }
	inline List_1_t336032673 ** get_address_of_sceneObjects_1() { return &___sceneObjects_1; }
	inline void set_sceneObjects_1(List_1_t336032673 * value)
	{
		___sceneObjects_1 = value;
		Il2CppCodeGenWriteBarrier(&___sceneObjects_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
