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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Config
struct  Config_t982593218  : public Il2CppObject
{
public:

public:
};

struct Config_t982593218_StaticFields
{
public:
	// System.String Config::serverAddress
	String_t* ___serverAddress_0;
	// System.Int32 Config::serverPort
	int32_t ___serverPort_1;

public:
	inline static int32_t get_offset_of_serverAddress_0() { return static_cast<int32_t>(offsetof(Config_t982593218_StaticFields, ___serverAddress_0)); }
	inline String_t* get_serverAddress_0() const { return ___serverAddress_0; }
	inline String_t** get_address_of_serverAddress_0() { return &___serverAddress_0; }
	inline void set_serverAddress_0(String_t* value)
	{
		___serverAddress_0 = value;
		Il2CppCodeGenWriteBarrier(&___serverAddress_0, value);
	}

	inline static int32_t get_offset_of_serverPort_1() { return static_cast<int32_t>(offsetof(Config_t982593218_StaticFields, ___serverPort_1)); }
	inline int32_t get_serverPort_1() const { return ___serverPort_1; }
	inline int32_t* get_address_of_serverPort_1() { return &___serverPort_1; }
	inline void set_serverPort_1(int32_t value)
	{
		___serverPort_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
