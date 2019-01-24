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
// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.GameObject>
struct Dictionary_2_t3671312409;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.SaveLoadMenu
struct  SaveLoadMenu_t3541125646  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean UnityEngine.UI.Extensions.SaveLoadMenu::showMenu
	bool ___showMenu_2;
	// System.Boolean UnityEngine.UI.Extensions.SaveLoadMenu::usePersistentDataPath
	bool ___usePersistentDataPath_3;
	// System.String UnityEngine.UI.Extensions.SaveLoadMenu::savePath
	String_t* ___savePath_4;
	// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.GameObject> UnityEngine.UI.Extensions.SaveLoadMenu::prefabDictionary
	Dictionary_2_t3671312409 * ___prefabDictionary_5;

public:
	inline static int32_t get_offset_of_showMenu_2() { return static_cast<int32_t>(offsetof(SaveLoadMenu_t3541125646, ___showMenu_2)); }
	inline bool get_showMenu_2() const { return ___showMenu_2; }
	inline bool* get_address_of_showMenu_2() { return &___showMenu_2; }
	inline void set_showMenu_2(bool value)
	{
		___showMenu_2 = value;
	}

	inline static int32_t get_offset_of_usePersistentDataPath_3() { return static_cast<int32_t>(offsetof(SaveLoadMenu_t3541125646, ___usePersistentDataPath_3)); }
	inline bool get_usePersistentDataPath_3() const { return ___usePersistentDataPath_3; }
	inline bool* get_address_of_usePersistentDataPath_3() { return &___usePersistentDataPath_3; }
	inline void set_usePersistentDataPath_3(bool value)
	{
		___usePersistentDataPath_3 = value;
	}

	inline static int32_t get_offset_of_savePath_4() { return static_cast<int32_t>(offsetof(SaveLoadMenu_t3541125646, ___savePath_4)); }
	inline String_t* get_savePath_4() const { return ___savePath_4; }
	inline String_t** get_address_of_savePath_4() { return &___savePath_4; }
	inline void set_savePath_4(String_t* value)
	{
		___savePath_4 = value;
		Il2CppCodeGenWriteBarrier(&___savePath_4, value);
	}

	inline static int32_t get_offset_of_prefabDictionary_5() { return static_cast<int32_t>(offsetof(SaveLoadMenu_t3541125646, ___prefabDictionary_5)); }
	inline Dictionary_2_t3671312409 * get_prefabDictionary_5() const { return ___prefabDictionary_5; }
	inline Dictionary_2_t3671312409 ** get_address_of_prefabDictionary_5() { return &___prefabDictionary_5; }
	inline void set_prefabDictionary_5(Dictionary_2_t3671312409 * value)
	{
		___prefabDictionary_5 = value;
		Il2CppCodeGenWriteBarrier(&___prefabDictionary_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
