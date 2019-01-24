#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"

// System.ComponentModel.LocalizableAttribute
struct LocalizableAttribute_t1267247394;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.LocalizableAttribute
struct  LocalizableAttribute_t1267247394  : public Attribute_t542643598
{
public:
	// System.Boolean System.ComponentModel.LocalizableAttribute::localizable
	bool ___localizable_0;

public:
	inline static int32_t get_offset_of_localizable_0() { return static_cast<int32_t>(offsetof(LocalizableAttribute_t1267247394, ___localizable_0)); }
	inline bool get_localizable_0() const { return ___localizable_0; }
	inline bool* get_address_of_localizable_0() { return &___localizable_0; }
	inline void set_localizable_0(bool value)
	{
		___localizable_0 = value;
	}
};

struct LocalizableAttribute_t1267247394_StaticFields
{
public:
	// System.ComponentModel.LocalizableAttribute System.ComponentModel.LocalizableAttribute::Default
	LocalizableAttribute_t1267247394 * ___Default_1;
	// System.ComponentModel.LocalizableAttribute System.ComponentModel.LocalizableAttribute::No
	LocalizableAttribute_t1267247394 * ___No_2;
	// System.ComponentModel.LocalizableAttribute System.ComponentModel.LocalizableAttribute::Yes
	LocalizableAttribute_t1267247394 * ___Yes_3;

public:
	inline static int32_t get_offset_of_Default_1() { return static_cast<int32_t>(offsetof(LocalizableAttribute_t1267247394_StaticFields, ___Default_1)); }
	inline LocalizableAttribute_t1267247394 * get_Default_1() const { return ___Default_1; }
	inline LocalizableAttribute_t1267247394 ** get_address_of_Default_1() { return &___Default_1; }
	inline void set_Default_1(LocalizableAttribute_t1267247394 * value)
	{
		___Default_1 = value;
		Il2CppCodeGenWriteBarrier(&___Default_1, value);
	}

	inline static int32_t get_offset_of_No_2() { return static_cast<int32_t>(offsetof(LocalizableAttribute_t1267247394_StaticFields, ___No_2)); }
	inline LocalizableAttribute_t1267247394 * get_No_2() const { return ___No_2; }
	inline LocalizableAttribute_t1267247394 ** get_address_of_No_2() { return &___No_2; }
	inline void set_No_2(LocalizableAttribute_t1267247394 * value)
	{
		___No_2 = value;
		Il2CppCodeGenWriteBarrier(&___No_2, value);
	}

	inline static int32_t get_offset_of_Yes_3() { return static_cast<int32_t>(offsetof(LocalizableAttribute_t1267247394_StaticFields, ___Yes_3)); }
	inline LocalizableAttribute_t1267247394 * get_Yes_3() const { return ___Yes_3; }
	inline LocalizableAttribute_t1267247394 ** get_address_of_Yes_3() { return &___Yes_3; }
	inline void set_Yes_3(LocalizableAttribute_t1267247394 * value)
	{
		___Yes_3 = value;
		Il2CppCodeGenWriteBarrier(&___Yes_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
