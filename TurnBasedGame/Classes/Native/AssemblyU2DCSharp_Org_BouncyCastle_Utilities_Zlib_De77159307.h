#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Utilities.Zlib.Deflate/Config[]
struct ConfigU5BU5D_t3303613768;
// System.String[]
struct StringU5BU5D_t1642385972;
// Org.BouncyCastle.Utilities.Zlib.ZStream
struct ZStream_t708755204;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Int16[]
struct Int16U5BU5D_t3104283263;
// Org.BouncyCastle.Utilities.Zlib.ZTree
struct ZTree_t4080091066;
// System.Int32[]
struct Int32U5BU5D_t3030399641;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Zlib.Deflate
struct  Deflate_t77159307  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Utilities.Zlib.ZStream Org.BouncyCastle.Utilities.Zlib.Deflate::strm
	ZStream_t708755204 * ___strm_56;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::status
	int32_t ___status_57;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.Deflate::pending_buf
	ByteU5BU5D_t3397334013* ___pending_buf_58;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::pending_buf_size
	int32_t ___pending_buf_size_59;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::pending_out
	int32_t ___pending_out_60;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::pending
	int32_t ___pending_61;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::noheader
	int32_t ___noheader_62;
	// System.Byte Org.BouncyCastle.Utilities.Zlib.Deflate::data_type
	uint8_t ___data_type_63;
	// System.Byte Org.BouncyCastle.Utilities.Zlib.Deflate::method
	uint8_t ___method_64;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::last_flush
	int32_t ___last_flush_65;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::w_size
	int32_t ___w_size_66;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::w_bits
	int32_t ___w_bits_67;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::w_mask
	int32_t ___w_mask_68;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.Deflate::window
	ByteU5BU5D_t3397334013* ___window_69;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::window_size
	int32_t ___window_size_70;
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.Deflate::prev
	Int16U5BU5D_t3104283263* ___prev_71;
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.Deflate::head
	Int16U5BU5D_t3104283263* ___head_72;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::ins_h
	int32_t ___ins_h_73;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::hash_size
	int32_t ___hash_size_74;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::hash_bits
	int32_t ___hash_bits_75;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::hash_mask
	int32_t ___hash_mask_76;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::hash_shift
	int32_t ___hash_shift_77;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::block_start
	int32_t ___block_start_78;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::match_length
	int32_t ___match_length_79;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::prev_match
	int32_t ___prev_match_80;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::match_available
	int32_t ___match_available_81;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::strstart
	int32_t ___strstart_82;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::match_start
	int32_t ___match_start_83;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::lookahead
	int32_t ___lookahead_84;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::prev_length
	int32_t ___prev_length_85;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::max_chain_length
	int32_t ___max_chain_length_86;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::max_lazy_match
	int32_t ___max_lazy_match_87;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::level
	int32_t ___level_88;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::strategy
	int32_t ___strategy_89;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::good_match
	int32_t ___good_match_90;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::nice_match
	int32_t ___nice_match_91;
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.Deflate::dyn_ltree
	Int16U5BU5D_t3104283263* ___dyn_ltree_92;
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.Deflate::dyn_dtree
	Int16U5BU5D_t3104283263* ___dyn_dtree_93;
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.Deflate::bl_tree
	Int16U5BU5D_t3104283263* ___bl_tree_94;
	// Org.BouncyCastle.Utilities.Zlib.ZTree Org.BouncyCastle.Utilities.Zlib.Deflate::l_desc
	ZTree_t4080091066 * ___l_desc_95;
	// Org.BouncyCastle.Utilities.Zlib.ZTree Org.BouncyCastle.Utilities.Zlib.Deflate::d_desc
	ZTree_t4080091066 * ___d_desc_96;
	// Org.BouncyCastle.Utilities.Zlib.ZTree Org.BouncyCastle.Utilities.Zlib.Deflate::bl_desc
	ZTree_t4080091066 * ___bl_desc_97;
	// System.Int16[] Org.BouncyCastle.Utilities.Zlib.Deflate::bl_count
	Int16U5BU5D_t3104283263* ___bl_count_98;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.Deflate::heap
	Int32U5BU5D_t3030399641* ___heap_99;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::heap_len
	int32_t ___heap_len_100;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::heap_max
	int32_t ___heap_max_101;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.Deflate::depth
	ByteU5BU5D_t3397334013* ___depth_102;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::l_buf
	int32_t ___l_buf_103;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::lit_bufsize
	int32_t ___lit_bufsize_104;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::last_lit
	int32_t ___last_lit_105;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::d_buf
	int32_t ___d_buf_106;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::opt_len
	int32_t ___opt_len_107;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::static_len
	int32_t ___static_len_108;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::matches
	int32_t ___matches_109;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::last_eob_len
	int32_t ___last_eob_len_110;
	// System.UInt32 Org.BouncyCastle.Utilities.Zlib.Deflate::bi_buf
	uint32_t ___bi_buf_111;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Deflate::bi_valid
	int32_t ___bi_valid_112;

public:
	inline static int32_t get_offset_of_strm_56() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___strm_56)); }
	inline ZStream_t708755204 * get_strm_56() const { return ___strm_56; }
	inline ZStream_t708755204 ** get_address_of_strm_56() { return &___strm_56; }
	inline void set_strm_56(ZStream_t708755204 * value)
	{
		___strm_56 = value;
		Il2CppCodeGenWriteBarrier(&___strm_56, value);
	}

	inline static int32_t get_offset_of_status_57() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___status_57)); }
	inline int32_t get_status_57() const { return ___status_57; }
	inline int32_t* get_address_of_status_57() { return &___status_57; }
	inline void set_status_57(int32_t value)
	{
		___status_57 = value;
	}

	inline static int32_t get_offset_of_pending_buf_58() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___pending_buf_58)); }
	inline ByteU5BU5D_t3397334013* get_pending_buf_58() const { return ___pending_buf_58; }
	inline ByteU5BU5D_t3397334013** get_address_of_pending_buf_58() { return &___pending_buf_58; }
	inline void set_pending_buf_58(ByteU5BU5D_t3397334013* value)
	{
		___pending_buf_58 = value;
		Il2CppCodeGenWriteBarrier(&___pending_buf_58, value);
	}

	inline static int32_t get_offset_of_pending_buf_size_59() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___pending_buf_size_59)); }
	inline int32_t get_pending_buf_size_59() const { return ___pending_buf_size_59; }
	inline int32_t* get_address_of_pending_buf_size_59() { return &___pending_buf_size_59; }
	inline void set_pending_buf_size_59(int32_t value)
	{
		___pending_buf_size_59 = value;
	}

	inline static int32_t get_offset_of_pending_out_60() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___pending_out_60)); }
	inline int32_t get_pending_out_60() const { return ___pending_out_60; }
	inline int32_t* get_address_of_pending_out_60() { return &___pending_out_60; }
	inline void set_pending_out_60(int32_t value)
	{
		___pending_out_60 = value;
	}

	inline static int32_t get_offset_of_pending_61() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___pending_61)); }
	inline int32_t get_pending_61() const { return ___pending_61; }
	inline int32_t* get_address_of_pending_61() { return &___pending_61; }
	inline void set_pending_61(int32_t value)
	{
		___pending_61 = value;
	}

	inline static int32_t get_offset_of_noheader_62() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___noheader_62)); }
	inline int32_t get_noheader_62() const { return ___noheader_62; }
	inline int32_t* get_address_of_noheader_62() { return &___noheader_62; }
	inline void set_noheader_62(int32_t value)
	{
		___noheader_62 = value;
	}

	inline static int32_t get_offset_of_data_type_63() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___data_type_63)); }
	inline uint8_t get_data_type_63() const { return ___data_type_63; }
	inline uint8_t* get_address_of_data_type_63() { return &___data_type_63; }
	inline void set_data_type_63(uint8_t value)
	{
		___data_type_63 = value;
	}

	inline static int32_t get_offset_of_method_64() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___method_64)); }
	inline uint8_t get_method_64() const { return ___method_64; }
	inline uint8_t* get_address_of_method_64() { return &___method_64; }
	inline void set_method_64(uint8_t value)
	{
		___method_64 = value;
	}

	inline static int32_t get_offset_of_last_flush_65() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___last_flush_65)); }
	inline int32_t get_last_flush_65() const { return ___last_flush_65; }
	inline int32_t* get_address_of_last_flush_65() { return &___last_flush_65; }
	inline void set_last_flush_65(int32_t value)
	{
		___last_flush_65 = value;
	}

	inline static int32_t get_offset_of_w_size_66() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___w_size_66)); }
	inline int32_t get_w_size_66() const { return ___w_size_66; }
	inline int32_t* get_address_of_w_size_66() { return &___w_size_66; }
	inline void set_w_size_66(int32_t value)
	{
		___w_size_66 = value;
	}

	inline static int32_t get_offset_of_w_bits_67() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___w_bits_67)); }
	inline int32_t get_w_bits_67() const { return ___w_bits_67; }
	inline int32_t* get_address_of_w_bits_67() { return &___w_bits_67; }
	inline void set_w_bits_67(int32_t value)
	{
		___w_bits_67 = value;
	}

	inline static int32_t get_offset_of_w_mask_68() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___w_mask_68)); }
	inline int32_t get_w_mask_68() const { return ___w_mask_68; }
	inline int32_t* get_address_of_w_mask_68() { return &___w_mask_68; }
	inline void set_w_mask_68(int32_t value)
	{
		___w_mask_68 = value;
	}

	inline static int32_t get_offset_of_window_69() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___window_69)); }
	inline ByteU5BU5D_t3397334013* get_window_69() const { return ___window_69; }
	inline ByteU5BU5D_t3397334013** get_address_of_window_69() { return &___window_69; }
	inline void set_window_69(ByteU5BU5D_t3397334013* value)
	{
		___window_69 = value;
		Il2CppCodeGenWriteBarrier(&___window_69, value);
	}

	inline static int32_t get_offset_of_window_size_70() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___window_size_70)); }
	inline int32_t get_window_size_70() const { return ___window_size_70; }
	inline int32_t* get_address_of_window_size_70() { return &___window_size_70; }
	inline void set_window_size_70(int32_t value)
	{
		___window_size_70 = value;
	}

	inline static int32_t get_offset_of_prev_71() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___prev_71)); }
	inline Int16U5BU5D_t3104283263* get_prev_71() const { return ___prev_71; }
	inline Int16U5BU5D_t3104283263** get_address_of_prev_71() { return &___prev_71; }
	inline void set_prev_71(Int16U5BU5D_t3104283263* value)
	{
		___prev_71 = value;
		Il2CppCodeGenWriteBarrier(&___prev_71, value);
	}

	inline static int32_t get_offset_of_head_72() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___head_72)); }
	inline Int16U5BU5D_t3104283263* get_head_72() const { return ___head_72; }
	inline Int16U5BU5D_t3104283263** get_address_of_head_72() { return &___head_72; }
	inline void set_head_72(Int16U5BU5D_t3104283263* value)
	{
		___head_72 = value;
		Il2CppCodeGenWriteBarrier(&___head_72, value);
	}

	inline static int32_t get_offset_of_ins_h_73() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___ins_h_73)); }
	inline int32_t get_ins_h_73() const { return ___ins_h_73; }
	inline int32_t* get_address_of_ins_h_73() { return &___ins_h_73; }
	inline void set_ins_h_73(int32_t value)
	{
		___ins_h_73 = value;
	}

	inline static int32_t get_offset_of_hash_size_74() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___hash_size_74)); }
	inline int32_t get_hash_size_74() const { return ___hash_size_74; }
	inline int32_t* get_address_of_hash_size_74() { return &___hash_size_74; }
	inline void set_hash_size_74(int32_t value)
	{
		___hash_size_74 = value;
	}

	inline static int32_t get_offset_of_hash_bits_75() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___hash_bits_75)); }
	inline int32_t get_hash_bits_75() const { return ___hash_bits_75; }
	inline int32_t* get_address_of_hash_bits_75() { return &___hash_bits_75; }
	inline void set_hash_bits_75(int32_t value)
	{
		___hash_bits_75 = value;
	}

	inline static int32_t get_offset_of_hash_mask_76() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___hash_mask_76)); }
	inline int32_t get_hash_mask_76() const { return ___hash_mask_76; }
	inline int32_t* get_address_of_hash_mask_76() { return &___hash_mask_76; }
	inline void set_hash_mask_76(int32_t value)
	{
		___hash_mask_76 = value;
	}

	inline static int32_t get_offset_of_hash_shift_77() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___hash_shift_77)); }
	inline int32_t get_hash_shift_77() const { return ___hash_shift_77; }
	inline int32_t* get_address_of_hash_shift_77() { return &___hash_shift_77; }
	inline void set_hash_shift_77(int32_t value)
	{
		___hash_shift_77 = value;
	}

	inline static int32_t get_offset_of_block_start_78() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___block_start_78)); }
	inline int32_t get_block_start_78() const { return ___block_start_78; }
	inline int32_t* get_address_of_block_start_78() { return &___block_start_78; }
	inline void set_block_start_78(int32_t value)
	{
		___block_start_78 = value;
	}

	inline static int32_t get_offset_of_match_length_79() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___match_length_79)); }
	inline int32_t get_match_length_79() const { return ___match_length_79; }
	inline int32_t* get_address_of_match_length_79() { return &___match_length_79; }
	inline void set_match_length_79(int32_t value)
	{
		___match_length_79 = value;
	}

	inline static int32_t get_offset_of_prev_match_80() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___prev_match_80)); }
	inline int32_t get_prev_match_80() const { return ___prev_match_80; }
	inline int32_t* get_address_of_prev_match_80() { return &___prev_match_80; }
	inline void set_prev_match_80(int32_t value)
	{
		___prev_match_80 = value;
	}

	inline static int32_t get_offset_of_match_available_81() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___match_available_81)); }
	inline int32_t get_match_available_81() const { return ___match_available_81; }
	inline int32_t* get_address_of_match_available_81() { return &___match_available_81; }
	inline void set_match_available_81(int32_t value)
	{
		___match_available_81 = value;
	}

	inline static int32_t get_offset_of_strstart_82() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___strstart_82)); }
	inline int32_t get_strstart_82() const { return ___strstart_82; }
	inline int32_t* get_address_of_strstart_82() { return &___strstart_82; }
	inline void set_strstart_82(int32_t value)
	{
		___strstart_82 = value;
	}

	inline static int32_t get_offset_of_match_start_83() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___match_start_83)); }
	inline int32_t get_match_start_83() const { return ___match_start_83; }
	inline int32_t* get_address_of_match_start_83() { return &___match_start_83; }
	inline void set_match_start_83(int32_t value)
	{
		___match_start_83 = value;
	}

	inline static int32_t get_offset_of_lookahead_84() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___lookahead_84)); }
	inline int32_t get_lookahead_84() const { return ___lookahead_84; }
	inline int32_t* get_address_of_lookahead_84() { return &___lookahead_84; }
	inline void set_lookahead_84(int32_t value)
	{
		___lookahead_84 = value;
	}

	inline static int32_t get_offset_of_prev_length_85() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___prev_length_85)); }
	inline int32_t get_prev_length_85() const { return ___prev_length_85; }
	inline int32_t* get_address_of_prev_length_85() { return &___prev_length_85; }
	inline void set_prev_length_85(int32_t value)
	{
		___prev_length_85 = value;
	}

	inline static int32_t get_offset_of_max_chain_length_86() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___max_chain_length_86)); }
	inline int32_t get_max_chain_length_86() const { return ___max_chain_length_86; }
	inline int32_t* get_address_of_max_chain_length_86() { return &___max_chain_length_86; }
	inline void set_max_chain_length_86(int32_t value)
	{
		___max_chain_length_86 = value;
	}

	inline static int32_t get_offset_of_max_lazy_match_87() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___max_lazy_match_87)); }
	inline int32_t get_max_lazy_match_87() const { return ___max_lazy_match_87; }
	inline int32_t* get_address_of_max_lazy_match_87() { return &___max_lazy_match_87; }
	inline void set_max_lazy_match_87(int32_t value)
	{
		___max_lazy_match_87 = value;
	}

	inline static int32_t get_offset_of_level_88() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___level_88)); }
	inline int32_t get_level_88() const { return ___level_88; }
	inline int32_t* get_address_of_level_88() { return &___level_88; }
	inline void set_level_88(int32_t value)
	{
		___level_88 = value;
	}

	inline static int32_t get_offset_of_strategy_89() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___strategy_89)); }
	inline int32_t get_strategy_89() const { return ___strategy_89; }
	inline int32_t* get_address_of_strategy_89() { return &___strategy_89; }
	inline void set_strategy_89(int32_t value)
	{
		___strategy_89 = value;
	}

	inline static int32_t get_offset_of_good_match_90() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___good_match_90)); }
	inline int32_t get_good_match_90() const { return ___good_match_90; }
	inline int32_t* get_address_of_good_match_90() { return &___good_match_90; }
	inline void set_good_match_90(int32_t value)
	{
		___good_match_90 = value;
	}

	inline static int32_t get_offset_of_nice_match_91() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___nice_match_91)); }
	inline int32_t get_nice_match_91() const { return ___nice_match_91; }
	inline int32_t* get_address_of_nice_match_91() { return &___nice_match_91; }
	inline void set_nice_match_91(int32_t value)
	{
		___nice_match_91 = value;
	}

	inline static int32_t get_offset_of_dyn_ltree_92() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___dyn_ltree_92)); }
	inline Int16U5BU5D_t3104283263* get_dyn_ltree_92() const { return ___dyn_ltree_92; }
	inline Int16U5BU5D_t3104283263** get_address_of_dyn_ltree_92() { return &___dyn_ltree_92; }
	inline void set_dyn_ltree_92(Int16U5BU5D_t3104283263* value)
	{
		___dyn_ltree_92 = value;
		Il2CppCodeGenWriteBarrier(&___dyn_ltree_92, value);
	}

	inline static int32_t get_offset_of_dyn_dtree_93() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___dyn_dtree_93)); }
	inline Int16U5BU5D_t3104283263* get_dyn_dtree_93() const { return ___dyn_dtree_93; }
	inline Int16U5BU5D_t3104283263** get_address_of_dyn_dtree_93() { return &___dyn_dtree_93; }
	inline void set_dyn_dtree_93(Int16U5BU5D_t3104283263* value)
	{
		___dyn_dtree_93 = value;
		Il2CppCodeGenWriteBarrier(&___dyn_dtree_93, value);
	}

	inline static int32_t get_offset_of_bl_tree_94() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___bl_tree_94)); }
	inline Int16U5BU5D_t3104283263* get_bl_tree_94() const { return ___bl_tree_94; }
	inline Int16U5BU5D_t3104283263** get_address_of_bl_tree_94() { return &___bl_tree_94; }
	inline void set_bl_tree_94(Int16U5BU5D_t3104283263* value)
	{
		___bl_tree_94 = value;
		Il2CppCodeGenWriteBarrier(&___bl_tree_94, value);
	}

	inline static int32_t get_offset_of_l_desc_95() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___l_desc_95)); }
	inline ZTree_t4080091066 * get_l_desc_95() const { return ___l_desc_95; }
	inline ZTree_t4080091066 ** get_address_of_l_desc_95() { return &___l_desc_95; }
	inline void set_l_desc_95(ZTree_t4080091066 * value)
	{
		___l_desc_95 = value;
		Il2CppCodeGenWriteBarrier(&___l_desc_95, value);
	}

	inline static int32_t get_offset_of_d_desc_96() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___d_desc_96)); }
	inline ZTree_t4080091066 * get_d_desc_96() const { return ___d_desc_96; }
	inline ZTree_t4080091066 ** get_address_of_d_desc_96() { return &___d_desc_96; }
	inline void set_d_desc_96(ZTree_t4080091066 * value)
	{
		___d_desc_96 = value;
		Il2CppCodeGenWriteBarrier(&___d_desc_96, value);
	}

	inline static int32_t get_offset_of_bl_desc_97() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___bl_desc_97)); }
	inline ZTree_t4080091066 * get_bl_desc_97() const { return ___bl_desc_97; }
	inline ZTree_t4080091066 ** get_address_of_bl_desc_97() { return &___bl_desc_97; }
	inline void set_bl_desc_97(ZTree_t4080091066 * value)
	{
		___bl_desc_97 = value;
		Il2CppCodeGenWriteBarrier(&___bl_desc_97, value);
	}

	inline static int32_t get_offset_of_bl_count_98() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___bl_count_98)); }
	inline Int16U5BU5D_t3104283263* get_bl_count_98() const { return ___bl_count_98; }
	inline Int16U5BU5D_t3104283263** get_address_of_bl_count_98() { return &___bl_count_98; }
	inline void set_bl_count_98(Int16U5BU5D_t3104283263* value)
	{
		___bl_count_98 = value;
		Il2CppCodeGenWriteBarrier(&___bl_count_98, value);
	}

	inline static int32_t get_offset_of_heap_99() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___heap_99)); }
	inline Int32U5BU5D_t3030399641* get_heap_99() const { return ___heap_99; }
	inline Int32U5BU5D_t3030399641** get_address_of_heap_99() { return &___heap_99; }
	inline void set_heap_99(Int32U5BU5D_t3030399641* value)
	{
		___heap_99 = value;
		Il2CppCodeGenWriteBarrier(&___heap_99, value);
	}

	inline static int32_t get_offset_of_heap_len_100() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___heap_len_100)); }
	inline int32_t get_heap_len_100() const { return ___heap_len_100; }
	inline int32_t* get_address_of_heap_len_100() { return &___heap_len_100; }
	inline void set_heap_len_100(int32_t value)
	{
		___heap_len_100 = value;
	}

	inline static int32_t get_offset_of_heap_max_101() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___heap_max_101)); }
	inline int32_t get_heap_max_101() const { return ___heap_max_101; }
	inline int32_t* get_address_of_heap_max_101() { return &___heap_max_101; }
	inline void set_heap_max_101(int32_t value)
	{
		___heap_max_101 = value;
	}

	inline static int32_t get_offset_of_depth_102() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___depth_102)); }
	inline ByteU5BU5D_t3397334013* get_depth_102() const { return ___depth_102; }
	inline ByteU5BU5D_t3397334013** get_address_of_depth_102() { return &___depth_102; }
	inline void set_depth_102(ByteU5BU5D_t3397334013* value)
	{
		___depth_102 = value;
		Il2CppCodeGenWriteBarrier(&___depth_102, value);
	}

	inline static int32_t get_offset_of_l_buf_103() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___l_buf_103)); }
	inline int32_t get_l_buf_103() const { return ___l_buf_103; }
	inline int32_t* get_address_of_l_buf_103() { return &___l_buf_103; }
	inline void set_l_buf_103(int32_t value)
	{
		___l_buf_103 = value;
	}

	inline static int32_t get_offset_of_lit_bufsize_104() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___lit_bufsize_104)); }
	inline int32_t get_lit_bufsize_104() const { return ___lit_bufsize_104; }
	inline int32_t* get_address_of_lit_bufsize_104() { return &___lit_bufsize_104; }
	inline void set_lit_bufsize_104(int32_t value)
	{
		___lit_bufsize_104 = value;
	}

	inline static int32_t get_offset_of_last_lit_105() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___last_lit_105)); }
	inline int32_t get_last_lit_105() const { return ___last_lit_105; }
	inline int32_t* get_address_of_last_lit_105() { return &___last_lit_105; }
	inline void set_last_lit_105(int32_t value)
	{
		___last_lit_105 = value;
	}

	inline static int32_t get_offset_of_d_buf_106() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___d_buf_106)); }
	inline int32_t get_d_buf_106() const { return ___d_buf_106; }
	inline int32_t* get_address_of_d_buf_106() { return &___d_buf_106; }
	inline void set_d_buf_106(int32_t value)
	{
		___d_buf_106 = value;
	}

	inline static int32_t get_offset_of_opt_len_107() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___opt_len_107)); }
	inline int32_t get_opt_len_107() const { return ___opt_len_107; }
	inline int32_t* get_address_of_opt_len_107() { return &___opt_len_107; }
	inline void set_opt_len_107(int32_t value)
	{
		___opt_len_107 = value;
	}

	inline static int32_t get_offset_of_static_len_108() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___static_len_108)); }
	inline int32_t get_static_len_108() const { return ___static_len_108; }
	inline int32_t* get_address_of_static_len_108() { return &___static_len_108; }
	inline void set_static_len_108(int32_t value)
	{
		___static_len_108 = value;
	}

	inline static int32_t get_offset_of_matches_109() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___matches_109)); }
	inline int32_t get_matches_109() const { return ___matches_109; }
	inline int32_t* get_address_of_matches_109() { return &___matches_109; }
	inline void set_matches_109(int32_t value)
	{
		___matches_109 = value;
	}

	inline static int32_t get_offset_of_last_eob_len_110() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___last_eob_len_110)); }
	inline int32_t get_last_eob_len_110() const { return ___last_eob_len_110; }
	inline int32_t* get_address_of_last_eob_len_110() { return &___last_eob_len_110; }
	inline void set_last_eob_len_110(int32_t value)
	{
		___last_eob_len_110 = value;
	}

	inline static int32_t get_offset_of_bi_buf_111() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___bi_buf_111)); }
	inline uint32_t get_bi_buf_111() const { return ___bi_buf_111; }
	inline uint32_t* get_address_of_bi_buf_111() { return &___bi_buf_111; }
	inline void set_bi_buf_111(uint32_t value)
	{
		___bi_buf_111 = value;
	}

	inline static int32_t get_offset_of_bi_valid_112() { return static_cast<int32_t>(offsetof(Deflate_t77159307, ___bi_valid_112)); }
	inline int32_t get_bi_valid_112() const { return ___bi_valid_112; }
	inline int32_t* get_address_of_bi_valid_112() { return &___bi_valid_112; }
	inline void set_bi_valid_112(int32_t value)
	{
		___bi_valid_112 = value;
	}
};

struct Deflate_t77159307_StaticFields
{
public:
	// Org.BouncyCastle.Utilities.Zlib.Deflate/Config[] Org.BouncyCastle.Utilities.Zlib.Deflate::config_table
	ConfigU5BU5D_t3303613768* ___config_table_7;
	// System.String[] Org.BouncyCastle.Utilities.Zlib.Deflate::z_errmsg
	StringU5BU5D_t1642385972* ___z_errmsg_8;

public:
	inline static int32_t get_offset_of_config_table_7() { return static_cast<int32_t>(offsetof(Deflate_t77159307_StaticFields, ___config_table_7)); }
	inline ConfigU5BU5D_t3303613768* get_config_table_7() const { return ___config_table_7; }
	inline ConfigU5BU5D_t3303613768** get_address_of_config_table_7() { return &___config_table_7; }
	inline void set_config_table_7(ConfigU5BU5D_t3303613768* value)
	{
		___config_table_7 = value;
		Il2CppCodeGenWriteBarrier(&___config_table_7, value);
	}

	inline static int32_t get_offset_of_z_errmsg_8() { return static_cast<int32_t>(offsetof(Deflate_t77159307_StaticFields, ___z_errmsg_8)); }
	inline StringU5BU5D_t1642385972* get_z_errmsg_8() const { return ___z_errmsg_8; }
	inline StringU5BU5D_t1642385972** get_address_of_z_errmsg_8() { return &___z_errmsg_8; }
	inline void set_z_errmsg_8(StringU5BU5D_t1642385972* value)
	{
		___z_errmsg_8 = value;
		Il2CppCodeGenWriteBarrier(&___z_errmsg_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
