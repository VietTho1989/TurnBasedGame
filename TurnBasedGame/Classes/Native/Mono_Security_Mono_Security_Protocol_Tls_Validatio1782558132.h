#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.Protocol.Tls.ValidationResult
struct  ValidationResult_t1782558132  : public Il2CppObject
{
public:
	// System.Boolean Mono.Security.Protocol.Tls.ValidationResult::trusted
	bool ___trusted_0;
	// System.Boolean Mono.Security.Protocol.Tls.ValidationResult::user_denied
	bool ___user_denied_1;
	// System.Int32 Mono.Security.Protocol.Tls.ValidationResult::error_code
	int32_t ___error_code_2;

public:
	inline static int32_t get_offset_of_trusted_0() { return static_cast<int32_t>(offsetof(ValidationResult_t1782558132, ___trusted_0)); }
	inline bool get_trusted_0() const { return ___trusted_0; }
	inline bool* get_address_of_trusted_0() { return &___trusted_0; }
	inline void set_trusted_0(bool value)
	{
		___trusted_0 = value;
	}

	inline static int32_t get_offset_of_user_denied_1() { return static_cast<int32_t>(offsetof(ValidationResult_t1782558132, ___user_denied_1)); }
	inline bool get_user_denied_1() const { return ___user_denied_1; }
	inline bool* get_address_of_user_denied_1() { return &___user_denied_1; }
	inline void set_user_denied_1(bool value)
	{
		___user_denied_1 = value;
	}

	inline static int32_t get_offset_of_error_code_2() { return static_cast<int32_t>(offsetof(ValidationResult_t1782558132, ___error_code_2)); }
	inline int32_t get_error_code_2() const { return ___error_code_2; }
	inline int32_t* get_address_of_error_code_2() { return &___error_code_2; }
	inline void set_error_code_2(int32_t value)
	{
		___error_code_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
