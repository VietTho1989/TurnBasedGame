#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<Rule.RuleSet>
struct List_1_t4236142516;
// System.Boolean[0...,0...]
struct BooleanU5BU2CU5D_t3568034316;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rule.Rules
struct  Rules_t894123657  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<Rule.RuleSet> Rule.Rules::ruleSets
	List_1_t4236142516 * ___ruleSets_0;
	// System.Boolean[0...,0...] Rule.Rules::restrict
	BooleanU5BU2CU5D_t3568034316* ___restrict_1;

public:
	inline static int32_t get_offset_of_ruleSets_0() { return static_cast<int32_t>(offsetof(Rules_t894123657, ___ruleSets_0)); }
	inline List_1_t4236142516 * get_ruleSets_0() const { return ___ruleSets_0; }
	inline List_1_t4236142516 ** get_address_of_ruleSets_0() { return &___ruleSets_0; }
	inline void set_ruleSets_0(List_1_t4236142516 * value)
	{
		___ruleSets_0 = value;
		Il2CppCodeGenWriteBarrier(&___ruleSets_0, value);
	}

	inline static int32_t get_offset_of_restrict_1() { return static_cast<int32_t>(offsetof(Rules_t894123657, ___restrict_1)); }
	inline BooleanU5BU2CU5D_t3568034316* get_restrict_1() const { return ___restrict_1; }
	inline BooleanU5BU2CU5D_t3568034316** get_address_of_restrict_1() { return &___restrict_1; }
	inline void set_restrict_1(BooleanU5BU2CU5D_t3568034316* value)
	{
		___restrict_1 = value;
		Il2CppCodeGenWriteBarrier(&___restrict_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
