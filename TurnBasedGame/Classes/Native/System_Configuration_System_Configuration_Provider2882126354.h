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

// System.Configuration.Provider.ProviderBase
struct  ProviderBase_t2882126354  : public Il2CppObject
{
public:
	// System.Boolean System.Configuration.Provider.ProviderBase::alreadyInitialized
	bool ___alreadyInitialized_0;
	// System.String System.Configuration.Provider.ProviderBase::_description
	String_t* ____description_1;
	// System.String System.Configuration.Provider.ProviderBase::_name
	String_t* ____name_2;

public:
	inline static int32_t get_offset_of_alreadyInitialized_0() { return static_cast<int32_t>(offsetof(ProviderBase_t2882126354, ___alreadyInitialized_0)); }
	inline bool get_alreadyInitialized_0() const { return ___alreadyInitialized_0; }
	inline bool* get_address_of_alreadyInitialized_0() { return &___alreadyInitialized_0; }
	inline void set_alreadyInitialized_0(bool value)
	{
		___alreadyInitialized_0 = value;
	}

	inline static int32_t get_offset_of__description_1() { return static_cast<int32_t>(offsetof(ProviderBase_t2882126354, ____description_1)); }
	inline String_t* get__description_1() const { return ____description_1; }
	inline String_t** get_address_of__description_1() { return &____description_1; }
	inline void set__description_1(String_t* value)
	{
		____description_1 = value;
		Il2CppCodeGenWriteBarrier(&____description_1, value);
	}

	inline static int32_t get_offset_of__name_2() { return static_cast<int32_t>(offsetof(ProviderBase_t2882126354, ____name_2)); }
	inline String_t* get__name_2() const { return ____name_2; }
	inline String_t** get_address_of__name_2() { return &____name_2; }
	inline void set__name_2(String_t* value)
	{
		____name_2 = value;
		Il2CppCodeGenWriteBarrier(&____name_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
