#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.SByte[]
struct SByteU5BU5D_t3472287392;
// System.Int16[]
struct Int16U5BU5D_t3104283263;
// BestHTTP.Decompression.Zlib.StaticTree
struct StaticTree_t2290192584;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.ZTree
struct  ZTree_t1042194920  : public Il2CppObject
{
public:
	// System.Int16[] BestHTTP.Decompression.Zlib.ZTree::dyn_tree
	Int16U5BU5D_t3104283263* ___dyn_tree_10;
	// System.Int32 BestHTTP.Decompression.Zlib.ZTree::max_code
	int32_t ___max_code_11;
	// BestHTTP.Decompression.Zlib.StaticTree BestHTTP.Decompression.Zlib.ZTree::staticTree
	StaticTree_t2290192584 * ___staticTree_12;

public:
	inline static int32_t get_offset_of_dyn_tree_10() { return static_cast<int32_t>(offsetof(ZTree_t1042194920, ___dyn_tree_10)); }
	inline Int16U5BU5D_t3104283263* get_dyn_tree_10() const { return ___dyn_tree_10; }
	inline Int16U5BU5D_t3104283263** get_address_of_dyn_tree_10() { return &___dyn_tree_10; }
	inline void set_dyn_tree_10(Int16U5BU5D_t3104283263* value)
	{
		___dyn_tree_10 = value;
		Il2CppCodeGenWriteBarrier(&___dyn_tree_10, value);
	}

	inline static int32_t get_offset_of_max_code_11() { return static_cast<int32_t>(offsetof(ZTree_t1042194920, ___max_code_11)); }
	inline int32_t get_max_code_11() const { return ___max_code_11; }
	inline int32_t* get_address_of_max_code_11() { return &___max_code_11; }
	inline void set_max_code_11(int32_t value)
	{
		___max_code_11 = value;
	}

	inline static int32_t get_offset_of_staticTree_12() { return static_cast<int32_t>(offsetof(ZTree_t1042194920, ___staticTree_12)); }
	inline StaticTree_t2290192584 * get_staticTree_12() const { return ___staticTree_12; }
	inline StaticTree_t2290192584 ** get_address_of_staticTree_12() { return &___staticTree_12; }
	inline void set_staticTree_12(StaticTree_t2290192584 * value)
	{
		___staticTree_12 = value;
		Il2CppCodeGenWriteBarrier(&___staticTree_12, value);
	}
};

struct ZTree_t1042194920_StaticFields
{
public:
	// System.Int32 BestHTTP.Decompression.Zlib.ZTree::HEAP_SIZE
	int32_t ___HEAP_SIZE_0;
	// System.Int32[] BestHTTP.Decompression.Zlib.ZTree::ExtraLengthBits
	Int32U5BU5D_t3030399641* ___ExtraLengthBits_1;
	// System.Int32[] BestHTTP.Decompression.Zlib.ZTree::ExtraDistanceBits
	Int32U5BU5D_t3030399641* ___ExtraDistanceBits_2;
	// System.Int32[] BestHTTP.Decompression.Zlib.ZTree::extra_blbits
	Int32U5BU5D_t3030399641* ___extra_blbits_3;
	// System.SByte[] BestHTTP.Decompression.Zlib.ZTree::bl_order
	SByteU5BU5D_t3472287392* ___bl_order_4;
	// System.SByte[] BestHTTP.Decompression.Zlib.ZTree::_dist_code
	SByteU5BU5D_t3472287392* ____dist_code_6;
	// System.SByte[] BestHTTP.Decompression.Zlib.ZTree::LengthCode
	SByteU5BU5D_t3472287392* ___LengthCode_7;
	// System.Int32[] BestHTTP.Decompression.Zlib.ZTree::LengthBase
	Int32U5BU5D_t3030399641* ___LengthBase_8;
	// System.Int32[] BestHTTP.Decompression.Zlib.ZTree::DistanceBase
	Int32U5BU5D_t3030399641* ___DistanceBase_9;

public:
	inline static int32_t get_offset_of_HEAP_SIZE_0() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___HEAP_SIZE_0)); }
	inline int32_t get_HEAP_SIZE_0() const { return ___HEAP_SIZE_0; }
	inline int32_t* get_address_of_HEAP_SIZE_0() { return &___HEAP_SIZE_0; }
	inline void set_HEAP_SIZE_0(int32_t value)
	{
		___HEAP_SIZE_0 = value;
	}

	inline static int32_t get_offset_of_ExtraLengthBits_1() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___ExtraLengthBits_1)); }
	inline Int32U5BU5D_t3030399641* get_ExtraLengthBits_1() const { return ___ExtraLengthBits_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_ExtraLengthBits_1() { return &___ExtraLengthBits_1; }
	inline void set_ExtraLengthBits_1(Int32U5BU5D_t3030399641* value)
	{
		___ExtraLengthBits_1 = value;
		Il2CppCodeGenWriteBarrier(&___ExtraLengthBits_1, value);
	}

	inline static int32_t get_offset_of_ExtraDistanceBits_2() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___ExtraDistanceBits_2)); }
	inline Int32U5BU5D_t3030399641* get_ExtraDistanceBits_2() const { return ___ExtraDistanceBits_2; }
	inline Int32U5BU5D_t3030399641** get_address_of_ExtraDistanceBits_2() { return &___ExtraDistanceBits_2; }
	inline void set_ExtraDistanceBits_2(Int32U5BU5D_t3030399641* value)
	{
		___ExtraDistanceBits_2 = value;
		Il2CppCodeGenWriteBarrier(&___ExtraDistanceBits_2, value);
	}

	inline static int32_t get_offset_of_extra_blbits_3() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___extra_blbits_3)); }
	inline Int32U5BU5D_t3030399641* get_extra_blbits_3() const { return ___extra_blbits_3; }
	inline Int32U5BU5D_t3030399641** get_address_of_extra_blbits_3() { return &___extra_blbits_3; }
	inline void set_extra_blbits_3(Int32U5BU5D_t3030399641* value)
	{
		___extra_blbits_3 = value;
		Il2CppCodeGenWriteBarrier(&___extra_blbits_3, value);
	}

	inline static int32_t get_offset_of_bl_order_4() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___bl_order_4)); }
	inline SByteU5BU5D_t3472287392* get_bl_order_4() const { return ___bl_order_4; }
	inline SByteU5BU5D_t3472287392** get_address_of_bl_order_4() { return &___bl_order_4; }
	inline void set_bl_order_4(SByteU5BU5D_t3472287392* value)
	{
		___bl_order_4 = value;
		Il2CppCodeGenWriteBarrier(&___bl_order_4, value);
	}

	inline static int32_t get_offset_of__dist_code_6() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ____dist_code_6)); }
	inline SByteU5BU5D_t3472287392* get__dist_code_6() const { return ____dist_code_6; }
	inline SByteU5BU5D_t3472287392** get_address_of__dist_code_6() { return &____dist_code_6; }
	inline void set__dist_code_6(SByteU5BU5D_t3472287392* value)
	{
		____dist_code_6 = value;
		Il2CppCodeGenWriteBarrier(&____dist_code_6, value);
	}

	inline static int32_t get_offset_of_LengthCode_7() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___LengthCode_7)); }
	inline SByteU5BU5D_t3472287392* get_LengthCode_7() const { return ___LengthCode_7; }
	inline SByteU5BU5D_t3472287392** get_address_of_LengthCode_7() { return &___LengthCode_7; }
	inline void set_LengthCode_7(SByteU5BU5D_t3472287392* value)
	{
		___LengthCode_7 = value;
		Il2CppCodeGenWriteBarrier(&___LengthCode_7, value);
	}

	inline static int32_t get_offset_of_LengthBase_8() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___LengthBase_8)); }
	inline Int32U5BU5D_t3030399641* get_LengthBase_8() const { return ___LengthBase_8; }
	inline Int32U5BU5D_t3030399641** get_address_of_LengthBase_8() { return &___LengthBase_8; }
	inline void set_LengthBase_8(Int32U5BU5D_t3030399641* value)
	{
		___LengthBase_8 = value;
		Il2CppCodeGenWriteBarrier(&___LengthBase_8, value);
	}

	inline static int32_t get_offset_of_DistanceBase_9() { return static_cast<int32_t>(offsetof(ZTree_t1042194920_StaticFields, ___DistanceBase_9)); }
	inline Int32U5BU5D_t3030399641* get_DistanceBase_9() const { return ___DistanceBase_9; }
	inline Int32U5BU5D_t3030399641** get_address_of_DistanceBase_9() { return &___DistanceBase_9; }
	inline void set_DistanceBase_9(Int32U5BU5D_t3030399641* value)
	{
		___DistanceBase_9 = value;
		Il2CppCodeGenWriteBarrier(&___DistanceBase_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
