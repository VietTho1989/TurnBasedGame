#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Infl2450294045.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;
// BestHTTP.Decompression.Zlib.InflateCodes
struct InflateCodes_t996093859;
// BestHTTP.Decompression.Zlib.ZlibCodec
struct ZlibCodec_t1899545627;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Object
struct Il2CppObject;
// BestHTTP.Decompression.Zlib.InfTree
struct InfTree_t1475751651;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.InflateBlocks
struct  InflateBlocks_t3437229943  : public Il2CppObject
{
public:
	// BestHTTP.Decompression.Zlib.InflateBlocks/InflateBlockMode BestHTTP.Decompression.Zlib.InflateBlocks::mode
	int32_t ___mode_2;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::left
	int32_t ___left_3;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::table
	int32_t ___table_4;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::index
	int32_t ___index_5;
	// System.Int32[] BestHTTP.Decompression.Zlib.InflateBlocks::blens
	Int32U5BU5D_t3030399641* ___blens_6;
	// System.Int32[] BestHTTP.Decompression.Zlib.InflateBlocks::bb
	Int32U5BU5D_t3030399641* ___bb_7;
	// System.Int32[] BestHTTP.Decompression.Zlib.InflateBlocks::tb
	Int32U5BU5D_t3030399641* ___tb_8;
	// BestHTTP.Decompression.Zlib.InflateCodes BestHTTP.Decompression.Zlib.InflateBlocks::codes
	InflateCodes_t996093859 * ___codes_9;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::last
	int32_t ___last_10;
	// BestHTTP.Decompression.Zlib.ZlibCodec BestHTTP.Decompression.Zlib.InflateBlocks::_codec
	ZlibCodec_t1899545627 * ____codec_11;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::bitk
	int32_t ___bitk_12;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::bitb
	int32_t ___bitb_13;
	// System.Int32[] BestHTTP.Decompression.Zlib.InflateBlocks::hufts
	Int32U5BU5D_t3030399641* ___hufts_14;
	// System.Byte[] BestHTTP.Decompression.Zlib.InflateBlocks::window
	ByteU5BU5D_t3397334013* ___window_15;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::end
	int32_t ___end_16;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::readAt
	int32_t ___readAt_17;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateBlocks::writeAt
	int32_t ___writeAt_18;
	// System.Object BestHTTP.Decompression.Zlib.InflateBlocks::checkfn
	Il2CppObject * ___checkfn_19;
	// System.UInt32 BestHTTP.Decompression.Zlib.InflateBlocks::check
	uint32_t ___check_20;
	// BestHTTP.Decompression.Zlib.InfTree BestHTTP.Decompression.Zlib.InflateBlocks::inftree
	InfTree_t1475751651 * ___inftree_21;

public:
	inline static int32_t get_offset_of_mode_2() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___mode_2)); }
	inline int32_t get_mode_2() const { return ___mode_2; }
	inline int32_t* get_address_of_mode_2() { return &___mode_2; }
	inline void set_mode_2(int32_t value)
	{
		___mode_2 = value;
	}

	inline static int32_t get_offset_of_left_3() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___left_3)); }
	inline int32_t get_left_3() const { return ___left_3; }
	inline int32_t* get_address_of_left_3() { return &___left_3; }
	inline void set_left_3(int32_t value)
	{
		___left_3 = value;
	}

	inline static int32_t get_offset_of_table_4() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___table_4)); }
	inline int32_t get_table_4() const { return ___table_4; }
	inline int32_t* get_address_of_table_4() { return &___table_4; }
	inline void set_table_4(int32_t value)
	{
		___table_4 = value;
	}

	inline static int32_t get_offset_of_index_5() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___index_5)); }
	inline int32_t get_index_5() const { return ___index_5; }
	inline int32_t* get_address_of_index_5() { return &___index_5; }
	inline void set_index_5(int32_t value)
	{
		___index_5 = value;
	}

	inline static int32_t get_offset_of_blens_6() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___blens_6)); }
	inline Int32U5BU5D_t3030399641* get_blens_6() const { return ___blens_6; }
	inline Int32U5BU5D_t3030399641** get_address_of_blens_6() { return &___blens_6; }
	inline void set_blens_6(Int32U5BU5D_t3030399641* value)
	{
		___blens_6 = value;
		Il2CppCodeGenWriteBarrier(&___blens_6, value);
	}

	inline static int32_t get_offset_of_bb_7() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___bb_7)); }
	inline Int32U5BU5D_t3030399641* get_bb_7() const { return ___bb_7; }
	inline Int32U5BU5D_t3030399641** get_address_of_bb_7() { return &___bb_7; }
	inline void set_bb_7(Int32U5BU5D_t3030399641* value)
	{
		___bb_7 = value;
		Il2CppCodeGenWriteBarrier(&___bb_7, value);
	}

	inline static int32_t get_offset_of_tb_8() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___tb_8)); }
	inline Int32U5BU5D_t3030399641* get_tb_8() const { return ___tb_8; }
	inline Int32U5BU5D_t3030399641** get_address_of_tb_8() { return &___tb_8; }
	inline void set_tb_8(Int32U5BU5D_t3030399641* value)
	{
		___tb_8 = value;
		Il2CppCodeGenWriteBarrier(&___tb_8, value);
	}

	inline static int32_t get_offset_of_codes_9() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___codes_9)); }
	inline InflateCodes_t996093859 * get_codes_9() const { return ___codes_9; }
	inline InflateCodes_t996093859 ** get_address_of_codes_9() { return &___codes_9; }
	inline void set_codes_9(InflateCodes_t996093859 * value)
	{
		___codes_9 = value;
		Il2CppCodeGenWriteBarrier(&___codes_9, value);
	}

	inline static int32_t get_offset_of_last_10() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___last_10)); }
	inline int32_t get_last_10() const { return ___last_10; }
	inline int32_t* get_address_of_last_10() { return &___last_10; }
	inline void set_last_10(int32_t value)
	{
		___last_10 = value;
	}

	inline static int32_t get_offset_of__codec_11() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ____codec_11)); }
	inline ZlibCodec_t1899545627 * get__codec_11() const { return ____codec_11; }
	inline ZlibCodec_t1899545627 ** get_address_of__codec_11() { return &____codec_11; }
	inline void set__codec_11(ZlibCodec_t1899545627 * value)
	{
		____codec_11 = value;
		Il2CppCodeGenWriteBarrier(&____codec_11, value);
	}

	inline static int32_t get_offset_of_bitk_12() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___bitk_12)); }
	inline int32_t get_bitk_12() const { return ___bitk_12; }
	inline int32_t* get_address_of_bitk_12() { return &___bitk_12; }
	inline void set_bitk_12(int32_t value)
	{
		___bitk_12 = value;
	}

	inline static int32_t get_offset_of_bitb_13() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___bitb_13)); }
	inline int32_t get_bitb_13() const { return ___bitb_13; }
	inline int32_t* get_address_of_bitb_13() { return &___bitb_13; }
	inline void set_bitb_13(int32_t value)
	{
		___bitb_13 = value;
	}

	inline static int32_t get_offset_of_hufts_14() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___hufts_14)); }
	inline Int32U5BU5D_t3030399641* get_hufts_14() const { return ___hufts_14; }
	inline Int32U5BU5D_t3030399641** get_address_of_hufts_14() { return &___hufts_14; }
	inline void set_hufts_14(Int32U5BU5D_t3030399641* value)
	{
		___hufts_14 = value;
		Il2CppCodeGenWriteBarrier(&___hufts_14, value);
	}

	inline static int32_t get_offset_of_window_15() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___window_15)); }
	inline ByteU5BU5D_t3397334013* get_window_15() const { return ___window_15; }
	inline ByteU5BU5D_t3397334013** get_address_of_window_15() { return &___window_15; }
	inline void set_window_15(ByteU5BU5D_t3397334013* value)
	{
		___window_15 = value;
		Il2CppCodeGenWriteBarrier(&___window_15, value);
	}

	inline static int32_t get_offset_of_end_16() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___end_16)); }
	inline int32_t get_end_16() const { return ___end_16; }
	inline int32_t* get_address_of_end_16() { return &___end_16; }
	inline void set_end_16(int32_t value)
	{
		___end_16 = value;
	}

	inline static int32_t get_offset_of_readAt_17() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___readAt_17)); }
	inline int32_t get_readAt_17() const { return ___readAt_17; }
	inline int32_t* get_address_of_readAt_17() { return &___readAt_17; }
	inline void set_readAt_17(int32_t value)
	{
		___readAt_17 = value;
	}

	inline static int32_t get_offset_of_writeAt_18() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___writeAt_18)); }
	inline int32_t get_writeAt_18() const { return ___writeAt_18; }
	inline int32_t* get_address_of_writeAt_18() { return &___writeAt_18; }
	inline void set_writeAt_18(int32_t value)
	{
		___writeAt_18 = value;
	}

	inline static int32_t get_offset_of_checkfn_19() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___checkfn_19)); }
	inline Il2CppObject * get_checkfn_19() const { return ___checkfn_19; }
	inline Il2CppObject ** get_address_of_checkfn_19() { return &___checkfn_19; }
	inline void set_checkfn_19(Il2CppObject * value)
	{
		___checkfn_19 = value;
		Il2CppCodeGenWriteBarrier(&___checkfn_19, value);
	}

	inline static int32_t get_offset_of_check_20() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___check_20)); }
	inline uint32_t get_check_20() const { return ___check_20; }
	inline uint32_t* get_address_of_check_20() { return &___check_20; }
	inline void set_check_20(uint32_t value)
	{
		___check_20 = value;
	}

	inline static int32_t get_offset_of_inftree_21() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943, ___inftree_21)); }
	inline InfTree_t1475751651 * get_inftree_21() const { return ___inftree_21; }
	inline InfTree_t1475751651 ** get_address_of_inftree_21() { return &___inftree_21; }
	inline void set_inftree_21(InfTree_t1475751651 * value)
	{
		___inftree_21 = value;
		Il2CppCodeGenWriteBarrier(&___inftree_21, value);
	}
};

struct InflateBlocks_t3437229943_StaticFields
{
public:
	// System.Int32[] BestHTTP.Decompression.Zlib.InflateBlocks::border
	Int32U5BU5D_t3030399641* ___border_1;

public:
	inline static int32_t get_offset_of_border_1() { return static_cast<int32_t>(offsetof(InflateBlocks_t3437229943_StaticFields, ___border_1)); }
	inline Int32U5BU5D_t3030399641* get_border_1() const { return ___border_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_border_1() { return &___border_1; }
	inline void set_border_1(Int32U5BU5D_t3030399641* value)
	{
		___border_1 = value;
		Il2CppCodeGenWriteBarrier(&___border_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
