#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"

// System.ComponentModel.ReadOnlyAttribute
struct ReadOnlyAttribute_t4102148880;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.ReadOnlyAttribute
struct  ReadOnlyAttribute_t4102148880  : public Attribute_t542643598
{
public:
	// System.Boolean System.ComponentModel.ReadOnlyAttribute::read_only
	bool ___read_only_0;

public:
	inline static int32_t get_offset_of_read_only_0() { return static_cast<int32_t>(offsetof(ReadOnlyAttribute_t4102148880, ___read_only_0)); }
	inline bool get_read_only_0() const { return ___read_only_0; }
	inline bool* get_address_of_read_only_0() { return &___read_only_0; }
	inline void set_read_only_0(bool value)
	{
		___read_only_0 = value;
	}
};

struct ReadOnlyAttribute_t4102148880_StaticFields
{
public:
	// System.ComponentModel.ReadOnlyAttribute System.ComponentModel.ReadOnlyAttribute::No
	ReadOnlyAttribute_t4102148880 * ___No_1;
	// System.ComponentModel.ReadOnlyAttribute System.ComponentModel.ReadOnlyAttribute::Yes
	ReadOnlyAttribute_t4102148880 * ___Yes_2;
	// System.ComponentModel.ReadOnlyAttribute System.ComponentModel.ReadOnlyAttribute::Default
	ReadOnlyAttribute_t4102148880 * ___Default_3;

public:
	inline static int32_t get_offset_of_No_1() { return static_cast<int32_t>(offsetof(ReadOnlyAttribute_t4102148880_StaticFields, ___No_1)); }
	inline ReadOnlyAttribute_t4102148880 * get_No_1() const { return ___No_1; }
	inline ReadOnlyAttribute_t4102148880 ** get_address_of_No_1() { return &___No_1; }
	inline void set_No_1(ReadOnlyAttribute_t4102148880 * value)
	{
		___No_1 = value;
		Il2CppCodeGenWriteBarrier(&___No_1, value);
	}

	inline static int32_t get_offset_of_Yes_2() { return static_cast<int32_t>(offsetof(ReadOnlyAttribute_t4102148880_StaticFields, ___Yes_2)); }
	inline ReadOnlyAttribute_t4102148880 * get_Yes_2() const { return ___Yes_2; }
	inline ReadOnlyAttribute_t4102148880 ** get_address_of_Yes_2() { return &___Yes_2; }
	inline void set_Yes_2(ReadOnlyAttribute_t4102148880 * value)
	{
		___Yes_2 = value;
		Il2CppCodeGenWriteBarrier(&___Yes_2, value);
	}

	inline static int32_t get_offset_of_Default_3() { return static_cast<int32_t>(offsetof(ReadOnlyAttribute_t4102148880_StaticFields, ___Default_3)); }
	inline ReadOnlyAttribute_t4102148880 * get_Default_3() const { return ___Default_3; }
	inline ReadOnlyAttribute_t4102148880 ** get_address_of_Default_3() { return &___Default_3; }
	inline void set_Default_3(ReadOnlyAttribute_t4102148880 * value)
	{
		___Default_3 = value;
		Il2CppCodeGenWriteBarrier(&___Default_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
