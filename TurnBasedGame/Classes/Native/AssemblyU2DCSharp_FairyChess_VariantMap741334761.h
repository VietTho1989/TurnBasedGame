#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<FairyChess.Common/VariantType,FairyChess.Variant>
struct Dictionary_2_t1187004422;
// FairyChess.Common/VariantType[]
struct VariantTypeU5BU5D_t892498229;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.VariantMap
struct  VariantMap_t741334761  : public Il2CppObject
{
public:

public:
};

struct VariantMap_t741334761_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<FairyChess.Common/VariantType,FairyChess.Variant> FairyChess.VariantMap::variants
	Dictionary_2_t1187004422 * ___variants_0;
	// FairyChess.Common/VariantType[] FairyChess.VariantMap::EnableVariants
	VariantTypeU5BU5D_t892498229* ___EnableVariants_1;

public:
	inline static int32_t get_offset_of_variants_0() { return static_cast<int32_t>(offsetof(VariantMap_t741334761_StaticFields, ___variants_0)); }
	inline Dictionary_2_t1187004422 * get_variants_0() const { return ___variants_0; }
	inline Dictionary_2_t1187004422 ** get_address_of_variants_0() { return &___variants_0; }
	inline void set_variants_0(Dictionary_2_t1187004422 * value)
	{
		___variants_0 = value;
		Il2CppCodeGenWriteBarrier(&___variants_0, value);
	}

	inline static int32_t get_offset_of_EnableVariants_1() { return static_cast<int32_t>(offsetof(VariantMap_t741334761_StaticFields, ___EnableVariants_1)); }
	inline VariantTypeU5BU5D_t892498229* get_EnableVariants_1() const { return ___EnableVariants_1; }
	inline VariantTypeU5BU5D_t892498229** get_address_of_EnableVariants_1() { return &___EnableVariants_1; }
	inline void set_EnableVariants_1(VariantTypeU5BU5D_t892498229* value)
	{
		___EnableVariants_1 = value;
		Il2CppCodeGenWriteBarrier(&___EnableVariants_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
