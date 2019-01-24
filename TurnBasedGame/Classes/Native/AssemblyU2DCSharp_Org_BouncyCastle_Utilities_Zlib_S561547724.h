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
// Org.BouncyCastle.Utilities.Zlib.StaticTree
struct StaticTree_t561547724;
// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Zlib.StaticTree
struct  StaticTree_t561547724  : public Il2CppObject
{
public:
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.StaticTree::static_tree
	Int16U5BU5D_t3104283263* ___static_tree_12;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.StaticTree::extra_bits
	Int32U5BU5D_t3030399641* ___extra_bits_13;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.StaticTree::extra_base
	int32_t ___extra_base_14;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.StaticTree::elems
	int32_t ___elems_15;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.StaticTree::max_length
	int32_t ___max_length_16;

public:
	inline static int32_t get_offset_of_static_tree_12() { return static_cast<int32_t>(offsetof(StaticTree_t561547724, ___static_tree_12)); }
	inline Int16U5BU5D_t3104283263* get_static_tree_12() const { return ___static_tree_12; }
	inline Int16U5BU5D_t3104283263** get_address_of_static_tree_12() { return &___static_tree_12; }
	inline void set_static_tree_12(Int16U5BU5D_t3104283263* value)
	{
		___static_tree_12 = value;
		Il2CppCodeGenWriteBarrier(&___static_tree_12, value);
	}

	inline static int32_t get_offset_of_extra_bits_13() { return static_cast<int32_t>(offsetof(StaticTree_t561547724, ___extra_bits_13)); }
	inline Int32U5BU5D_t3030399641* get_extra_bits_13() const { return ___extra_bits_13; }
	inline Int32U5BU5D_t3030399641** get_address_of_extra_bits_13() { return &___extra_bits_13; }
	inline void set_extra_bits_13(Int32U5BU5D_t3030399641* value)
	{
		___extra_bits_13 = value;
		Il2CppCodeGenWriteBarrier(&___extra_bits_13, value);
	}

	inline static int32_t get_offset_of_extra_base_14() { return static_cast<int32_t>(offsetof(StaticTree_t561547724, ___extra_base_14)); }
	inline int32_t get_extra_base_14() const { return ___extra_base_14; }
	inline int32_t* get_address_of_extra_base_14() { return &___extra_base_14; }
	inline void set_extra_base_14(int32_t value)
	{
		___extra_base_14 = value;
	}

	inline static int32_t get_offset_of_elems_15() { return static_cast<int32_t>(offsetof(StaticTree_t561547724, ___elems_15)); }
	inline int32_t get_elems_15() const { return ___elems_15; }
	inline int32_t* get_address_of_elems_15() { return &___elems_15; }
	inline void set_elems_15(int32_t value)
	{
		___elems_15 = value;
	}

	inline static int32_t get_offset_of_max_length_16() { return static_cast<int32_t>(offsetof(StaticTree_t561547724, ___max_length_16)); }
	inline int32_t get_max_length_16() const { return ___max_length_16; }
	inline int32_t* get_address_of_max_length_16() { return &___max_length_16; }
	inline void set_max_length_16(int32_t value)
	{
		___max_length_16 = value;
	}
};

struct StaticTree_t561547724_StaticFields
{
public:
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.StaticTree::static_ltree
	Int16U5BU5D_t3104283263* ___static_ltree_7;
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.StaticTree::static_dtree
	Int16U5BU5D_t3104283263* ___static_dtree_8;
	// Org.BouncyCastle.Utilities.Zlib.StaticTree Org.BouncyCastle.Utilities.Zlib.StaticTree::static_l_desc
	StaticTree_t561547724 * ___static_l_desc_9;
	// Org.BouncyCastle.Utilities.Zlib.StaticTree Org.BouncyCastle.Utilities.Zlib.StaticTree::static_d_desc
	StaticTree_t561547724 * ___static_d_desc_10;
	// Org.BouncyCastle.Utilities.Zlib.StaticTree Org.BouncyCastle.Utilities.Zlib.StaticTree::static_bl_desc
	StaticTree_t561547724 * ___static_bl_desc_11;

public:
	inline static int32_t get_offset_of_static_ltree_7() { return static_cast<int32_t>(offsetof(StaticTree_t561547724_StaticFields, ___static_ltree_7)); }
	inline Int16U5BU5D_t3104283263* get_static_ltree_7() const { return ___static_ltree_7; }
	inline Int16U5BU5D_t3104283263** get_address_of_static_ltree_7() { return &___static_ltree_7; }
	inline void set_static_ltree_7(Int16U5BU5D_t3104283263* value)
	{
		___static_ltree_7 = value;
		Il2CppCodeGenWriteBarrier(&___static_ltree_7, value);
	}

	inline static int32_t get_offset_of_static_dtree_8() { return static_cast<int32_t>(offsetof(StaticTree_t561547724_StaticFields, ___static_dtree_8)); }
	inline Int16U5BU5D_t3104283263* get_static_dtree_8() const { return ___static_dtree_8; }
	inline Int16U5BU5D_t3104283263** get_address_of_static_dtree_8() { return &___static_dtree_8; }
	inline void set_static_dtree_8(Int16U5BU5D_t3104283263* value)
	{
		___static_dtree_8 = value;
		Il2CppCodeGenWriteBarrier(&___static_dtree_8, value);
	}

	inline static int32_t get_offset_of_static_l_desc_9() { return static_cast<int32_t>(offsetof(StaticTree_t561547724_StaticFields, ___static_l_desc_9)); }
	inline StaticTree_t561547724 * get_static_l_desc_9() const { return ___static_l_desc_9; }
	inline StaticTree_t561547724 ** get_address_of_static_l_desc_9() { return &___static_l_desc_9; }
	inline void set_static_l_desc_9(StaticTree_t561547724 * value)
	{
		___static_l_desc_9 = value;
		Il2CppCodeGenWriteBarrier(&___static_l_desc_9, value);
	}

	inline static int32_t get_offset_of_static_d_desc_10() { return static_cast<int32_t>(offsetof(StaticTree_t561547724_StaticFields, ___static_d_desc_10)); }
	inline StaticTree_t561547724 * get_static_d_desc_10() const { return ___static_d_desc_10; }
	inline StaticTree_t561547724 ** get_address_of_static_d_desc_10() { return &___static_d_desc_10; }
	inline void set_static_d_desc_10(StaticTree_t561547724 * value)
	{
		___static_d_desc_10 = value;
		Il2CppCodeGenWriteBarrier(&___static_d_desc_10, value);
	}

	inline static int32_t get_offset_of_static_bl_desc_11() { return static_cast<int32_t>(offsetof(StaticTree_t561547724_StaticFields, ___static_bl_desc_11)); }
	inline StaticTree_t561547724 * get_static_bl_desc_11() const { return ___static_bl_desc_11; }
	inline StaticTree_t561547724 ** get_address_of_static_bl_desc_11() { return &___static_bl_desc_11; }
	inline void set_static_bl_desc_11(StaticTree_t561547724 * value)
	{
		___static_bl_desc_11 = value;
		Il2CppCodeGenWriteBarrier(&___static_bl_desc_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
