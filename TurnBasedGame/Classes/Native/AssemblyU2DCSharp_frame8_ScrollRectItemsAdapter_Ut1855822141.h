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

// frame8.ScrollRectItemsAdapter.Util.LoadSceneOnClick
struct  LoadSceneOnClick_t1855822141  : public MonoBehaviour_t1158329972
{
public:
	// System.String frame8.ScrollRectItemsAdapter.Util.LoadSceneOnClick::sceneName
	String_t* ___sceneName_2;

public:
	inline static int32_t get_offset_of_sceneName_2() { return static_cast<int32_t>(offsetof(LoadSceneOnClick_t1855822141, ___sceneName_2)); }
	inline String_t* get_sceneName_2() const { return ___sceneName_2; }
	inline String_t** get_address_of_sceneName_2() { return &___sceneName_2; }
	inline void set_sceneName_2(String_t* value)
	{
		___sceneName_2 = value;
		Il2CppCodeGenWriteBarrier(&___sceneName_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
