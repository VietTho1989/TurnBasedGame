#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Text_Encoding663144255.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.SByte[]
struct SByteU5BU5D_t3472287392;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.UTF7Encoding
struct  UTF7Encoding_t741406939  : public Encoding_t663144255
{
public:
	// System.Boolean System.Text.UTF7Encoding::allowOptionals
	bool ___allowOptionals_29;

public:
	inline static int32_t get_offset_of_allowOptionals_29() { return static_cast<int32_t>(offsetof(UTF7Encoding_t741406939, ___allowOptionals_29)); }
	inline bool get_allowOptionals_29() const { return ___allowOptionals_29; }
	inline bool* get_address_of_allowOptionals_29() { return &___allowOptionals_29; }
	inline void set_allowOptionals_29(bool value)
	{
		___allowOptionals_29 = value;
	}
};

struct UTF7Encoding_t741406939_StaticFields
{
public:
	// System.Byte[] System.Text.UTF7Encoding::encodingRules
	ByteU5BU5D_t3397334013* ___encodingRules_30;
	// System.SByte[] System.Text.UTF7Encoding::base64Values
	SByteU5BU5D_t3472287392* ___base64Values_31;

public:
	inline static int32_t get_offset_of_encodingRules_30() { return static_cast<int32_t>(offsetof(UTF7Encoding_t741406939_StaticFields, ___encodingRules_30)); }
	inline ByteU5BU5D_t3397334013* get_encodingRules_30() const { return ___encodingRules_30; }
	inline ByteU5BU5D_t3397334013** get_address_of_encodingRules_30() { return &___encodingRules_30; }
	inline void set_encodingRules_30(ByteU5BU5D_t3397334013* value)
	{
		___encodingRules_30 = value;
		Il2CppCodeGenWriteBarrier(&___encodingRules_30, value);
	}

	inline static int32_t get_offset_of_base64Values_31() { return static_cast<int32_t>(offsetof(UTF7Encoding_t741406939_StaticFields, ___base64Values_31)); }
	inline SByteU5BU5D_t3472287392* get_base64Values_31() const { return ___base64Values_31; }
	inline SByteU5BU5D_t3472287392** get_address_of_base64Values_31() { return &___base64Values_31; }
	inline void set_base64Values_31(SByteU5BU5D_t3472287392* value)
	{
		___base64Values_31 = value;
		Il2CppCodeGenWriteBarrier(&___base64Values_31, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
