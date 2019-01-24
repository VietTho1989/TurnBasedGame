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
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Int16[]
struct Int16U5BU5D_t3104283263;
// Org.BouncyCastle.Utilities.Zlib.StaticTree
struct StaticTree_t561547724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Zlib.ZTree
struct  ZTree_t4080091066  : public Il2CppObject
{
public:
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.ZTree::dyn_tree
	Int16U5BU5D_t3104283263* ___dyn_tree_22;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.ZTree::max_code
	int32_t ___max_code_23;
	// Org.BouncyCastle.Utilities.Zlib.StaticTree Org.BouncyCastle.Utilities.Zlib.ZTree::stat_desc
	StaticTree_t561547724 * ___stat_desc_24;

public:
	inline static int32_t get_offset_of_dyn_tree_22() { return static_cast<int32_t>(offsetof(ZTree_t4080091066, ___dyn_tree_22)); }
	inline Int16U5BU5D_t3104283263* get_dyn_tree_22() const { return ___dyn_tree_22; }
	inline Int16U5BU5D_t3104283263** get_address_of_dyn_tree_22() { return &___dyn_tree_22; }
	inline void set_dyn_tree_22(Int16U5BU5D_t3104283263* value)
	{
		___dyn_tree_22 = value;
		Il2CppCodeGenWriteBarrier(&___dyn_tree_22, value);
	}

	inline static int32_t get_offset_of_max_code_23() { return static_cast<int32_t>(offsetof(ZTree_t4080091066, ___max_code_23)); }
	inline int32_t get_max_code_23() const { return ___max_code_23; }
	inline int32_t* get_address_of_max_code_23() { return &___max_code_23; }
	inline void set_max_code_23(int32_t value)
	{
		___max_code_23 = value;
	}

	inline static int32_t get_offset_of_stat_desc_24() { return static_cast<int32_t>(offsetof(ZTree_t4080091066, ___stat_desc_24)); }
	inline StaticTree_t561547724 * get_stat_desc_24() const { return ___stat_desc_24; }
	inline StaticTree_t561547724 ** get_address_of_stat_desc_24() { return &___stat_desc_24; }
	inline void set_stat_desc_24(StaticTree_t561547724 * value)
	{
		___stat_desc_24 = value;
		Il2CppCodeGenWriteBarrier(&___stat_desc_24, value);
	}
};

struct ZTree_t4080091066_StaticFields
{
public:
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.ZTree::extra_lbits
	Int32U5BU5D_t3030399641* ___extra_lbits_12;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.ZTree::extra_dbits
	Int32U5BU5D_t3030399641* ___extra_dbits_13;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.ZTree::extra_blbits
	Int32U5BU5D_t3030399641* ___extra_blbits_14;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.ZTree::bl_order
	ByteU5BU5D_t3397334013* ___bl_order_15;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.ZTree::_dist_code
	ByteU5BU5D_t3397334013* ____dist_code_18;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.ZTree::_length_code
	ByteU5BU5D_t3397334013* ____length_code_19;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.ZTree::base_length
	Int32U5BU5D_t3030399641* ___base_length_20;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.ZTree::base_dist
	Int32U5BU5D_t3030399641* ___base_dist_21;

public:
	inline static int32_t get_offset_of_extra_lbits_12() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ___extra_lbits_12)); }
	inline Int32U5BU5D_t3030399641* get_extra_lbits_12() const { return ___extra_lbits_12; }
	inline Int32U5BU5D_t3030399641** get_address_of_extra_lbits_12() { return &___extra_lbits_12; }
	inline void set_extra_lbits_12(Int32U5BU5D_t3030399641* value)
	{
		___extra_lbits_12 = value;
		Il2CppCodeGenWriteBarrier(&___extra_lbits_12, value);
	}

	inline static int32_t get_offset_of_extra_dbits_13() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ___extra_dbits_13)); }
	inline Int32U5BU5D_t3030399641* get_extra_dbits_13() const { return ___extra_dbits_13; }
	inline Int32U5BU5D_t3030399641** get_address_of_extra_dbits_13() { return &___extra_dbits_13; }
	inline void set_extra_dbits_13(Int32U5BU5D_t3030399641* value)
	{
		___extra_dbits_13 = value;
		Il2CppCodeGenWriteBarrier(&___extra_dbits_13, value);
	}

	inline static int32_t get_offset_of_extra_blbits_14() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ___extra_blbits_14)); }
	inline Int32U5BU5D_t3030399641* get_extra_blbits_14() const { return ___extra_blbits_14; }
	inline Int32U5BU5D_t3030399641** get_address_of_extra_blbits_14() { return &___extra_blbits_14; }
	inline void set_extra_blbits_14(Int32U5BU5D_t3030399641* value)
	{
		___extra_blbits_14 = value;
		Il2CppCodeGenWriteBarrier(&___extra_blbits_14, value);
	}

	inline static int32_t get_offset_of_bl_order_15() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ___bl_order_15)); }
	inline ByteU5BU5D_t3397334013* get_bl_order_15() const { return ___bl_order_15; }
	inline ByteU5BU5D_t3397334013** get_address_of_bl_order_15() { return &___bl_order_15; }
	inline void set_bl_order_15(ByteU5BU5D_t3397334013* value)
	{
		___bl_order_15 = value;
		Il2CppCodeGenWriteBarrier(&___bl_order_15, value);
	}

	inline static int32_t get_offset_of__dist_code_18() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ____dist_code_18)); }
	inline ByteU5BU5D_t3397334013* get__dist_code_18() const { return ____dist_code_18; }
	inline ByteU5BU5D_t3397334013** get_address_of__dist_code_18() { return &____dist_code_18; }
	inline void set__dist_code_18(ByteU5BU5D_t3397334013* value)
	{
		____dist_code_18 = value;
		Il2CppCodeGenWriteBarrier(&____dist_code_18, value);
	}

	inline static int32_t get_offset_of__length_code_19() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ____length_code_19)); }
	inline ByteU5BU5D_t3397334013* get__length_code_19() const { return ____length_code_19; }
	inline ByteU5BU5D_t3397334013** get_address_of__length_code_19() { return &____length_code_19; }
	inline void set__length_code_19(ByteU5BU5D_t3397334013* value)
	{
		____length_code_19 = value;
		Il2CppCodeGenWriteBarrier(&____length_code_19, value);
	}

	inline static int32_t get_offset_of_base_length_20() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ___base_length_20)); }
	inline Int32U5BU5D_t3030399641* get_base_length_20() const { return ___base_length_20; }
	inline Int32U5BU5D_t3030399641** get_address_of_base_length_20() { return &___base_length_20; }
	inline void set_base_length_20(Int32U5BU5D_t3030399641* value)
	{
		___base_length_20 = value;
		Il2CppCodeGenWriteBarrier(&___base_length_20, value);
	}

	inline static int32_t get_offset_of_base_dist_21() { return static_cast<int32_t>(offsetof(ZTree_t4080091066_StaticFields, ___base_dist_21)); }
	inline Int32U5BU5D_t3030399641* get_base_dist_21() const { return ___base_dist_21; }
	inline Int32U5BU5D_t3030399641** get_address_of_base_dist_21() { return &___base_dist_21; }
	inline void set_base_dist_21(Int32U5BU5D_t3030399641* value)
	{
		___base_dist_21 = value;
		Il2CppCodeGenWriteBarrier(&___base_dist_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
