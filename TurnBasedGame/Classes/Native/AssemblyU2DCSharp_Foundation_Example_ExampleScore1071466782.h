#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_Observabl1024643188.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.ExampleScore
struct  ExampleScore_t1071466782  : public ObservableObject_t1024643188
{
public:
	// System.Boolean Foundation.Example.ExampleScore::_isSelf
	bool ____isSelf_4;
	// System.Int32 Foundation.Example.ExampleScore::_score
	int32_t ____score_5;
	// System.String Foundation.Example.ExampleScore::Username
	String_t* ___Username_6;

public:
	inline static int32_t get_offset_of__isSelf_4() { return static_cast<int32_t>(offsetof(ExampleScore_t1071466782, ____isSelf_4)); }
	inline bool get__isSelf_4() const { return ____isSelf_4; }
	inline bool* get_address_of__isSelf_4() { return &____isSelf_4; }
	inline void set__isSelf_4(bool value)
	{
		____isSelf_4 = value;
	}

	inline static int32_t get_offset_of__score_5() { return static_cast<int32_t>(offsetof(ExampleScore_t1071466782, ____score_5)); }
	inline int32_t get__score_5() const { return ____score_5; }
	inline int32_t* get_address_of__score_5() { return &____score_5; }
	inline void set__score_5(int32_t value)
	{
		____score_5 = value;
	}

	inline static int32_t get_offset_of_Username_6() { return static_cast<int32_t>(offsetof(ExampleScore_t1071466782, ___Username_6)); }
	inline String_t* get_Username_6() const { return ___Username_6; }
	inline String_t** get_address_of_Username_6() { return &___Username_6; }
	inline void set_Username_6(String_t* value)
	{
		___Username_6 = value;
		Il2CppCodeGenWriteBarrier(&___Username_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
