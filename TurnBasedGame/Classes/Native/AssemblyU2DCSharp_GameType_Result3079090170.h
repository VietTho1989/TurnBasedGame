#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Collections.Generic.List`1<GameType/Score>
struct List_1_t1120451679;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameType/Result
struct  Result_t3079090170 
{
public:
	// System.Boolean GameType/Result::isGameFinish
	bool ___isGameFinish_0;
	// System.Collections.Generic.List`1<GameType/Score> GameType/Result::scores
	List_1_t1120451679 * ___scores_1;

public:
	inline static int32_t get_offset_of_isGameFinish_0() { return static_cast<int32_t>(offsetof(Result_t3079090170, ___isGameFinish_0)); }
	inline bool get_isGameFinish_0() const { return ___isGameFinish_0; }
	inline bool* get_address_of_isGameFinish_0() { return &___isGameFinish_0; }
	inline void set_isGameFinish_0(bool value)
	{
		___isGameFinish_0 = value;
	}

	inline static int32_t get_offset_of_scores_1() { return static_cast<int32_t>(offsetof(Result_t3079090170, ___scores_1)); }
	inline List_1_t1120451679 * get_scores_1() const { return ___scores_1; }
	inline List_1_t1120451679 ** get_address_of_scores_1() { return &___scores_1; }
	inline void set_scores_1(List_1_t1120451679 * value)
	{
		___scores_1 = value;
		Il2CppCodeGenWriteBarrier(&___scores_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of GameType/Result
struct Result_t3079090170_marshaled_pinvoke
{
	int32_t ___isGameFinish_0;
	List_1_t1120451679 * ___scores_1;
};
// Native definition for COM marshalling of GameType/Result
struct Result_t3079090170_marshaled_com
{
	int32_t ___isGameFinish_0;
	List_1_t1120451679 * ___scores_1;
};
