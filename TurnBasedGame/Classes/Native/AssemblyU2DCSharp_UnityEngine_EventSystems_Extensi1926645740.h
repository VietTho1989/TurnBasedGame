#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_EventSystems_PointerInp1441575871.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// System.String
struct String_t;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.EventSystems.Extensions.AimerInputModule
struct  AimerInputModule_t1926645740  : public PointerInputModule_t1441575871
{
public:
	// System.String UnityEngine.EventSystems.Extensions.AimerInputModule::activateAxis
	String_t* ___activateAxis_14;
	// UnityEngine.Vector2 UnityEngine.EventSystems.Extensions.AimerInputModule::aimerOffset
	Vector2_t2243707579  ___aimerOffset_15;

public:
	inline static int32_t get_offset_of_activateAxis_14() { return static_cast<int32_t>(offsetof(AimerInputModule_t1926645740, ___activateAxis_14)); }
	inline String_t* get_activateAxis_14() const { return ___activateAxis_14; }
	inline String_t** get_address_of_activateAxis_14() { return &___activateAxis_14; }
	inline void set_activateAxis_14(String_t* value)
	{
		___activateAxis_14 = value;
		Il2CppCodeGenWriteBarrier(&___activateAxis_14, value);
	}

	inline static int32_t get_offset_of_aimerOffset_15() { return static_cast<int32_t>(offsetof(AimerInputModule_t1926645740, ___aimerOffset_15)); }
	inline Vector2_t2243707579  get_aimerOffset_15() const { return ___aimerOffset_15; }
	inline Vector2_t2243707579 * get_address_of_aimerOffset_15() { return &___aimerOffset_15; }
	inline void set_aimerOffset_15(Vector2_t2243707579  value)
	{
		___aimerOffset_15 = value;
	}
};

struct AimerInputModule_t1926645740_StaticFields
{
public:
	// UnityEngine.GameObject UnityEngine.EventSystems.Extensions.AimerInputModule::objectUnderAimer
	GameObject_t1756533147 * ___objectUnderAimer_16;

public:
	inline static int32_t get_offset_of_objectUnderAimer_16() { return static_cast<int32_t>(offsetof(AimerInputModule_t1926645740_StaticFields, ___objectUnderAimer_16)); }
	inline GameObject_t1756533147 * get_objectUnderAimer_16() const { return ___objectUnderAimer_16; }
	inline GameObject_t1756533147 ** get_address_of_objectUnderAimer_16() { return &___objectUnderAimer_16; }
	inline void set_objectUnderAimer_16(GameObject_t1756533147 * value)
	{
		___objectUnderAimer_16 = value;
		Il2CppCodeGenWriteBarrier(&___objectUnderAimer_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
