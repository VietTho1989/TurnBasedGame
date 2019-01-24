#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Type
struct Type_t;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Messenger/Cache
struct  Cache_t4234171411  : public Il2CppObject
{
public:
	// System.Type Foundation.Messenger/Cache::MessageType
	Type_t * ___MessageType_0;
	// System.Object Foundation.Messenger/Cache::Message
	Il2CppObject * ___Message_1;

public:
	inline static int32_t get_offset_of_MessageType_0() { return static_cast<int32_t>(offsetof(Cache_t4234171411, ___MessageType_0)); }
	inline Type_t * get_MessageType_0() const { return ___MessageType_0; }
	inline Type_t ** get_address_of_MessageType_0() { return &___MessageType_0; }
	inline void set_MessageType_0(Type_t * value)
	{
		___MessageType_0 = value;
		Il2CppCodeGenWriteBarrier(&___MessageType_0, value);
	}

	inline static int32_t get_offset_of_Message_1() { return static_cast<int32_t>(offsetof(Cache_t4234171411, ___Message_1)); }
	inline Il2CppObject * get_Message_1() const { return ___Message_1; }
	inline Il2CppObject ** get_address_of_Message_1() { return &___Message_1; }
	inline void set_Message_1(Il2CppObject * value)
	{
		___Message_1 = value;
		Il2CppCodeGenWriteBarrier(&___Message_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
