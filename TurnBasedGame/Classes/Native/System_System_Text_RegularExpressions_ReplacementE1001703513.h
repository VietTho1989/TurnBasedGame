#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Text.RegularExpressions.Regex
struct Regex_t1803876613;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.ReplacementEvaluator
struct  ReplacementEvaluator_t1001703513  : public Il2CppObject
{
public:
	// System.Text.RegularExpressions.Regex System.Text.RegularExpressions.ReplacementEvaluator::regex
	Regex_t1803876613 * ___regex_0;
	// System.Int32 System.Text.RegularExpressions.ReplacementEvaluator::n_pieces
	int32_t ___n_pieces_1;
	// System.Int32[] System.Text.RegularExpressions.ReplacementEvaluator::pieces
	Int32U5BU5D_t3030399641* ___pieces_2;
	// System.String System.Text.RegularExpressions.ReplacementEvaluator::replacement
	String_t* ___replacement_3;

public:
	inline static int32_t get_offset_of_regex_0() { return static_cast<int32_t>(offsetof(ReplacementEvaluator_t1001703513, ___regex_0)); }
	inline Regex_t1803876613 * get_regex_0() const { return ___regex_0; }
	inline Regex_t1803876613 ** get_address_of_regex_0() { return &___regex_0; }
	inline void set_regex_0(Regex_t1803876613 * value)
	{
		___regex_0 = value;
		Il2CppCodeGenWriteBarrier(&___regex_0, value);
	}

	inline static int32_t get_offset_of_n_pieces_1() { return static_cast<int32_t>(offsetof(ReplacementEvaluator_t1001703513, ___n_pieces_1)); }
	inline int32_t get_n_pieces_1() const { return ___n_pieces_1; }
	inline int32_t* get_address_of_n_pieces_1() { return &___n_pieces_1; }
	inline void set_n_pieces_1(int32_t value)
	{
		___n_pieces_1 = value;
	}

	inline static int32_t get_offset_of_pieces_2() { return static_cast<int32_t>(offsetof(ReplacementEvaluator_t1001703513, ___pieces_2)); }
	inline Int32U5BU5D_t3030399641* get_pieces_2() const { return ___pieces_2; }
	inline Int32U5BU5D_t3030399641** get_address_of_pieces_2() { return &___pieces_2; }
	inline void set_pieces_2(Int32U5BU5D_t3030399641* value)
	{
		___pieces_2 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_2, value);
	}

	inline static int32_t get_offset_of_replacement_3() { return static_cast<int32_t>(offsetof(ReplacementEvaluator_t1001703513, ___replacement_3)); }
	inline String_t* get_replacement_3() const { return ___replacement_3; }
	inline String_t** get_address_of_replacement_3() { return &___replacement_3; }
	inline void set_replacement_3(String_t* value)
	{
		___replacement_3 = value;
		Il2CppCodeGenWriteBarrier(&___replacement_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
