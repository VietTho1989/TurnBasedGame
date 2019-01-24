#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Runtime.Serialization.ISurrogateSelector
struct ISurrogateSelector_t1912587528;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.SurrogateSelector
struct  SurrogateSelector_t3321182695  : public Il2CppObject
{
public:
	// System.Collections.Hashtable System.Runtime.Serialization.SurrogateSelector::Surrogates
	Hashtable_t909839986 * ___Surrogates_0;
	// System.Runtime.Serialization.ISurrogateSelector System.Runtime.Serialization.SurrogateSelector::nextSelector
	Il2CppObject * ___nextSelector_1;

public:
	inline static int32_t get_offset_of_Surrogates_0() { return static_cast<int32_t>(offsetof(SurrogateSelector_t3321182695, ___Surrogates_0)); }
	inline Hashtable_t909839986 * get_Surrogates_0() const { return ___Surrogates_0; }
	inline Hashtable_t909839986 ** get_address_of_Surrogates_0() { return &___Surrogates_0; }
	inline void set_Surrogates_0(Hashtable_t909839986 * value)
	{
		___Surrogates_0 = value;
		Il2CppCodeGenWriteBarrier(&___Surrogates_0, value);
	}

	inline static int32_t get_offset_of_nextSelector_1() { return static_cast<int32_t>(offsetof(SurrogateSelector_t3321182695, ___nextSelector_1)); }
	inline Il2CppObject * get_nextSelector_1() const { return ___nextSelector_1; }
	inline Il2CppObject ** get_address_of_nextSelector_1() { return &___nextSelector_1; }
	inline void set_nextSelector_1(Il2CppObject * value)
	{
		___nextSelector_1 = value;
		Il2CppCodeGenWriteBarrier(&___nextSelector_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
