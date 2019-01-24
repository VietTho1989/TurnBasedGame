#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// Org.BouncyCastle.Math.EC.Abc.ZTauElement[]
struct ZTauElementU5BU5D_t3646072867;
// System.SByte[][]
struct SByteU5BU5DU5BU5D_t57182945;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Abc.Tnaf
struct  Tnaf_t1139038785  : public Il2CppObject
{
public:

public:
};

struct Tnaf_t1139038785_StaticFields
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Abc.Tnaf::MinusOne
	BigInteger_t4268922522 * ___MinusOne_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Abc.Tnaf::MinusTwo
	BigInteger_t4268922522 * ___MinusTwo_1;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Abc.Tnaf::MinusThree
	BigInteger_t4268922522 * ___MinusThree_2;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Abc.Tnaf::Four
	BigInteger_t4268922522 * ___Four_3;
	// Org.BouncyCastle.Math.EC.Abc.ZTauElement[] Org.BouncyCastle.Math.EC.Abc.Tnaf::Alpha0
	ZTauElementU5BU5D_t3646072867* ___Alpha0_6;
	// System.SByte[][] Org.BouncyCastle.Math.EC.Abc.Tnaf::Alpha0Tnaf
	SByteU5BU5DU5BU5D_t57182945* ___Alpha0Tnaf_7;
	// Org.BouncyCastle.Math.EC.Abc.ZTauElement[] Org.BouncyCastle.Math.EC.Abc.Tnaf::Alpha1
	ZTauElementU5BU5D_t3646072867* ___Alpha1_8;
	// System.SByte[][] Org.BouncyCastle.Math.EC.Abc.Tnaf::Alpha1Tnaf
	SByteU5BU5DU5BU5D_t57182945* ___Alpha1Tnaf_9;

public:
	inline static int32_t get_offset_of_MinusOne_0() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___MinusOne_0)); }
	inline BigInteger_t4268922522 * get_MinusOne_0() const { return ___MinusOne_0; }
	inline BigInteger_t4268922522 ** get_address_of_MinusOne_0() { return &___MinusOne_0; }
	inline void set_MinusOne_0(BigInteger_t4268922522 * value)
	{
		___MinusOne_0 = value;
		Il2CppCodeGenWriteBarrier(&___MinusOne_0, value);
	}

	inline static int32_t get_offset_of_MinusTwo_1() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___MinusTwo_1)); }
	inline BigInteger_t4268922522 * get_MinusTwo_1() const { return ___MinusTwo_1; }
	inline BigInteger_t4268922522 ** get_address_of_MinusTwo_1() { return &___MinusTwo_1; }
	inline void set_MinusTwo_1(BigInteger_t4268922522 * value)
	{
		___MinusTwo_1 = value;
		Il2CppCodeGenWriteBarrier(&___MinusTwo_1, value);
	}

	inline static int32_t get_offset_of_MinusThree_2() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___MinusThree_2)); }
	inline BigInteger_t4268922522 * get_MinusThree_2() const { return ___MinusThree_2; }
	inline BigInteger_t4268922522 ** get_address_of_MinusThree_2() { return &___MinusThree_2; }
	inline void set_MinusThree_2(BigInteger_t4268922522 * value)
	{
		___MinusThree_2 = value;
		Il2CppCodeGenWriteBarrier(&___MinusThree_2, value);
	}

	inline static int32_t get_offset_of_Four_3() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___Four_3)); }
	inline BigInteger_t4268922522 * get_Four_3() const { return ___Four_3; }
	inline BigInteger_t4268922522 ** get_address_of_Four_3() { return &___Four_3; }
	inline void set_Four_3(BigInteger_t4268922522 * value)
	{
		___Four_3 = value;
		Il2CppCodeGenWriteBarrier(&___Four_3, value);
	}

	inline static int32_t get_offset_of_Alpha0_6() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___Alpha0_6)); }
	inline ZTauElementU5BU5D_t3646072867* get_Alpha0_6() const { return ___Alpha0_6; }
	inline ZTauElementU5BU5D_t3646072867** get_address_of_Alpha0_6() { return &___Alpha0_6; }
	inline void set_Alpha0_6(ZTauElementU5BU5D_t3646072867* value)
	{
		___Alpha0_6 = value;
		Il2CppCodeGenWriteBarrier(&___Alpha0_6, value);
	}

	inline static int32_t get_offset_of_Alpha0Tnaf_7() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___Alpha0Tnaf_7)); }
	inline SByteU5BU5DU5BU5D_t57182945* get_Alpha0Tnaf_7() const { return ___Alpha0Tnaf_7; }
	inline SByteU5BU5DU5BU5D_t57182945** get_address_of_Alpha0Tnaf_7() { return &___Alpha0Tnaf_7; }
	inline void set_Alpha0Tnaf_7(SByteU5BU5DU5BU5D_t57182945* value)
	{
		___Alpha0Tnaf_7 = value;
		Il2CppCodeGenWriteBarrier(&___Alpha0Tnaf_7, value);
	}

	inline static int32_t get_offset_of_Alpha1_8() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___Alpha1_8)); }
	inline ZTauElementU5BU5D_t3646072867* get_Alpha1_8() const { return ___Alpha1_8; }
	inline ZTauElementU5BU5D_t3646072867** get_address_of_Alpha1_8() { return &___Alpha1_8; }
	inline void set_Alpha1_8(ZTauElementU5BU5D_t3646072867* value)
	{
		___Alpha1_8 = value;
		Il2CppCodeGenWriteBarrier(&___Alpha1_8, value);
	}

	inline static int32_t get_offset_of_Alpha1Tnaf_9() { return static_cast<int32_t>(offsetof(Tnaf_t1139038785_StaticFields, ___Alpha1Tnaf_9)); }
	inline SByteU5BU5DU5BU5D_t57182945* get_Alpha1Tnaf_9() const { return ___Alpha1Tnaf_9; }
	inline SByteU5BU5DU5BU5D_t57182945** get_address_of_Alpha1Tnaf_9() { return &___Alpha1Tnaf_9; }
	inline void set_Alpha1Tnaf_9(SByteU5BU5DU5BU5D_t57182945* value)
	{
		___Alpha1Tnaf_9 = value;
		Il2CppCodeGenWriteBarrier(&___Alpha1Tnaf_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
