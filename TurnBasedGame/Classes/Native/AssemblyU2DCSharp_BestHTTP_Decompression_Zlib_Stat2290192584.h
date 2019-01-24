#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int16[]
struct Int16U5BU5D_t3104283263;
// BestHTTP.Decompression.Zlib.StaticTree
struct StaticTree_t2290192584;
// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.StaticTree
struct  StaticTree_t2290192584  : public Il2CppObject
{
public:
	// System.Int16[] BestHTTP.Decompression.Zlib.StaticTree::treeCodes
	Int16U5BU5D_t3104283263* ___treeCodes_5;
	// System.Int32[] BestHTTP.Decompression.Zlib.StaticTree::extraBits
	Int32U5BU5D_t3030399641* ___extraBits_6;
	// System.Int32 BestHTTP.Decompression.Zlib.StaticTree::extraBase
	int32_t ___extraBase_7;
	// System.Int32 BestHTTP.Decompression.Zlib.StaticTree::elems
	int32_t ___elems_8;
	// System.Int32 BestHTTP.Decompression.Zlib.StaticTree::maxLength
	int32_t ___maxLength_9;

public:
	inline static int32_t get_offset_of_treeCodes_5() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584, ___treeCodes_5)); }
	inline Int16U5BU5D_t3104283263* get_treeCodes_5() const { return ___treeCodes_5; }
	inline Int16U5BU5D_t3104283263** get_address_of_treeCodes_5() { return &___treeCodes_5; }
	inline void set_treeCodes_5(Int16U5BU5D_t3104283263* value)
	{
		___treeCodes_5 = value;
		Il2CppCodeGenWriteBarrier(&___treeCodes_5, value);
	}

	inline static int32_t get_offset_of_extraBits_6() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584, ___extraBits_6)); }
	inline Int32U5BU5D_t3030399641* get_extraBits_6() const { return ___extraBits_6; }
	inline Int32U5BU5D_t3030399641** get_address_of_extraBits_6() { return &___extraBits_6; }
	inline void set_extraBits_6(Int32U5BU5D_t3030399641* value)
	{
		___extraBits_6 = value;
		Il2CppCodeGenWriteBarrier(&___extraBits_6, value);
	}

	inline static int32_t get_offset_of_extraBase_7() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584, ___extraBase_7)); }
	inline int32_t get_extraBase_7() const { return ___extraBase_7; }
	inline int32_t* get_address_of_extraBase_7() { return &___extraBase_7; }
	inline void set_extraBase_7(int32_t value)
	{
		___extraBase_7 = value;
	}

	inline static int32_t get_offset_of_elems_8() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584, ___elems_8)); }
	inline int32_t get_elems_8() const { return ___elems_8; }
	inline int32_t* get_address_of_elems_8() { return &___elems_8; }
	inline void set_elems_8(int32_t value)
	{
		___elems_8 = value;
	}

	inline static int32_t get_offset_of_maxLength_9() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584, ___maxLength_9)); }
	inline int32_t get_maxLength_9() const { return ___maxLength_9; }
	inline int32_t* get_address_of_maxLength_9() { return &___maxLength_9; }
	inline void set_maxLength_9(int32_t value)
	{
		___maxLength_9 = value;
	}
};

struct StaticTree_t2290192584_StaticFields
{
public:
	// System.Int16[] BestHTTP.Decompression.Zlib.StaticTree::lengthAndLiteralsTreeCodes
	Int16U5BU5D_t3104283263* ___lengthAndLiteralsTreeCodes_0;
	// System.Int16[] BestHTTP.Decompression.Zlib.StaticTree::distTreeCodes
	Int16U5BU5D_t3104283263* ___distTreeCodes_1;
	// BestHTTP.Decompression.Zlib.StaticTree BestHTTP.Decompression.Zlib.StaticTree::Literals
	StaticTree_t2290192584 * ___Literals_2;
	// BestHTTP.Decompression.Zlib.StaticTree BestHTTP.Decompression.Zlib.StaticTree::Distances
	StaticTree_t2290192584 * ___Distances_3;
	// BestHTTP.Decompression.Zlib.StaticTree BestHTTP.Decompression.Zlib.StaticTree::BitLengths
	StaticTree_t2290192584 * ___BitLengths_4;

public:
	inline static int32_t get_offset_of_lengthAndLiteralsTreeCodes_0() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584_StaticFields, ___lengthAndLiteralsTreeCodes_0)); }
	inline Int16U5BU5D_t3104283263* get_lengthAndLiteralsTreeCodes_0() const { return ___lengthAndLiteralsTreeCodes_0; }
	inline Int16U5BU5D_t3104283263** get_address_of_lengthAndLiteralsTreeCodes_0() { return &___lengthAndLiteralsTreeCodes_0; }
	inline void set_lengthAndLiteralsTreeCodes_0(Int16U5BU5D_t3104283263* value)
	{
		___lengthAndLiteralsTreeCodes_0 = value;
		Il2CppCodeGenWriteBarrier(&___lengthAndLiteralsTreeCodes_0, value);
	}

	inline static int32_t get_offset_of_distTreeCodes_1() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584_StaticFields, ___distTreeCodes_1)); }
	inline Int16U5BU5D_t3104283263* get_distTreeCodes_1() const { return ___distTreeCodes_1; }
	inline Int16U5BU5D_t3104283263** get_address_of_distTreeCodes_1() { return &___distTreeCodes_1; }
	inline void set_distTreeCodes_1(Int16U5BU5D_t3104283263* value)
	{
		___distTreeCodes_1 = value;
		Il2CppCodeGenWriteBarrier(&___distTreeCodes_1, value);
	}

	inline static int32_t get_offset_of_Literals_2() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584_StaticFields, ___Literals_2)); }
	inline StaticTree_t2290192584 * get_Literals_2() const { return ___Literals_2; }
	inline StaticTree_t2290192584 ** get_address_of_Literals_2() { return &___Literals_2; }
	inline void set_Literals_2(StaticTree_t2290192584 * value)
	{
		___Literals_2 = value;
		Il2CppCodeGenWriteBarrier(&___Literals_2, value);
	}

	inline static int32_t get_offset_of_Distances_3() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584_StaticFields, ___Distances_3)); }
	inline StaticTree_t2290192584 * get_Distances_3() const { return ___Distances_3; }
	inline StaticTree_t2290192584 ** get_address_of_Distances_3() { return &___Distances_3; }
	inline void set_Distances_3(StaticTree_t2290192584 * value)
	{
		___Distances_3 = value;
		Il2CppCodeGenWriteBarrier(&___Distances_3, value);
	}

	inline static int32_t get_offset_of_BitLengths_4() { return static_cast<int32_t>(offsetof(StaticTree_t2290192584_StaticFields, ___BitLengths_4)); }
	inline StaticTree_t2290192584 * get_BitLengths_4() const { return ___BitLengths_4; }
	inline StaticTree_t2290192584 ** get_address_of_BitLengths_4() { return &___BitLengths_4; }
	inline void set_BitLengths_4(StaticTree_t2290192584 * value)
	{
		___BitLengths_4 = value;
		Il2CppCodeGenWriteBarrier(&___BitLengths_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
