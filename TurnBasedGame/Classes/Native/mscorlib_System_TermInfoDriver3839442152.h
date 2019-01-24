#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_ConsoleColor1950027312.h"

// System.String[]
struct StringU5BU5D_t1642385972;
// System.TermInfoReader
struct TermInfoReader_t3840788697;
// System.String
struct String_t;
// System.IO.StreamReader
struct StreamReader_t2360341767;
// System.IO.CStreamWriter
struct CStreamWriter_t2592797654;
// System.Char[]
struct CharU5BU5D_t1328083999;
// System.Object
struct Il2CppObject;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.ByteMatcher
struct ByteMatcher_t2890532040;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.TermInfoStrings[]
struct TermInfoStringsU5BU5D_t3527186833;
// System.Int32
struct Int32_t2071877448;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.TermInfoDriver
struct  TermInfoDriver_t3839442152  : public Il2CppObject
{
public:
	// System.TermInfoReader System.TermInfoDriver::reader
	TermInfoReader_t3840788697 * ___reader_3;
	// System.Int32 System.TermInfoDriver::cursorLeft
	int32_t ___cursorLeft_4;
	// System.Int32 System.TermInfoDriver::cursorTop
	int32_t ___cursorTop_5;
	// System.String System.TermInfoDriver::title
	String_t* ___title_6;
	// System.String System.TermInfoDriver::titleFormat
	String_t* ___titleFormat_7;
	// System.Boolean System.TermInfoDriver::cursorVisible
	bool ___cursorVisible_8;
	// System.String System.TermInfoDriver::csrVisible
	String_t* ___csrVisible_9;
	// System.String System.TermInfoDriver::csrInvisible
	String_t* ___csrInvisible_10;
	// System.String System.TermInfoDriver::clear
	String_t* ___clear_11;
	// System.String System.TermInfoDriver::bell
	String_t* ___bell_12;
	// System.String System.TermInfoDriver::term
	String_t* ___term_13;
	// System.IO.StreamReader System.TermInfoDriver::stdin
	StreamReader_t2360341767 * ___stdin_14;
	// System.IO.CStreamWriter System.TermInfoDriver::stdout
	CStreamWriter_t2592797654 * ___stdout_15;
	// System.Int32 System.TermInfoDriver::windowWidth
	int32_t ___windowWidth_16;
	// System.Int32 System.TermInfoDriver::windowHeight
	int32_t ___windowHeight_17;
	// System.Int32 System.TermInfoDriver::bufferHeight
	int32_t ___bufferHeight_18;
	// System.Int32 System.TermInfoDriver::bufferWidth
	int32_t ___bufferWidth_19;
	// System.Char[] System.TermInfoDriver::buffer
	CharU5BU5D_t1328083999* ___buffer_20;
	// System.Int32 System.TermInfoDriver::readpos
	int32_t ___readpos_21;
	// System.Int32 System.TermInfoDriver::writepos
	int32_t ___writepos_22;
	// System.String System.TermInfoDriver::keypadXmit
	String_t* ___keypadXmit_23;
	// System.String System.TermInfoDriver::keypadLocal
	String_t* ___keypadLocal_24;
	// System.Boolean System.TermInfoDriver::inited
	bool ___inited_25;
	// System.Object System.TermInfoDriver::initLock
	Il2CppObject * ___initLock_26;
	// System.Boolean System.TermInfoDriver::initKeys
	bool ___initKeys_27;
	// System.String System.TermInfoDriver::origPair
	String_t* ___origPair_28;
	// System.String System.TermInfoDriver::origColors
	String_t* ___origColors_29;
	// System.String System.TermInfoDriver::cursorAddress
	String_t* ___cursorAddress_30;
	// System.ConsoleColor System.TermInfoDriver::fgcolor
	int32_t ___fgcolor_31;
	// System.Boolean System.TermInfoDriver::color16
	bool ___color16_32;
	// System.String System.TermInfoDriver::setlfgcolor
	String_t* ___setlfgcolor_33;
	// System.String System.TermInfoDriver::setlbgcolor
	String_t* ___setlbgcolor_34;
	// System.String System.TermInfoDriver::setfgcolor
	String_t* ___setfgcolor_35;
	// System.String System.TermInfoDriver::setbgcolor
	String_t* ___setbgcolor_36;
	// System.Boolean System.TermInfoDriver::noGetPosition
	bool ___noGetPosition_37;
	// System.Collections.Hashtable System.TermInfoDriver::keymap
	Hashtable_t909839986 * ___keymap_38;
	// System.ByteMatcher System.TermInfoDriver::rootmap
	ByteMatcher_t2890532040 * ___rootmap_39;
	// System.Boolean System.TermInfoDriver::home_1_1
	bool ___home_1_1_40;
	// System.Int32 System.TermInfoDriver::rl_startx
	int32_t ___rl_startx_41;
	// System.Int32 System.TermInfoDriver::rl_starty
	int32_t ___rl_starty_42;
	// System.Byte[] System.TermInfoDriver::control_characters
	ByteU5BU5D_t3397334013* ___control_characters_43;
	// System.Char[] System.TermInfoDriver::echobuf
	CharU5BU5D_t1328083999* ___echobuf_44;
	// System.Int32 System.TermInfoDriver::echon
	int32_t ___echon_45;

public:
	inline static int32_t get_offset_of_reader_3() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___reader_3)); }
	inline TermInfoReader_t3840788697 * get_reader_3() const { return ___reader_3; }
	inline TermInfoReader_t3840788697 ** get_address_of_reader_3() { return &___reader_3; }
	inline void set_reader_3(TermInfoReader_t3840788697 * value)
	{
		___reader_3 = value;
		Il2CppCodeGenWriteBarrier(&___reader_3, value);
	}

	inline static int32_t get_offset_of_cursorLeft_4() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___cursorLeft_4)); }
	inline int32_t get_cursorLeft_4() const { return ___cursorLeft_4; }
	inline int32_t* get_address_of_cursorLeft_4() { return &___cursorLeft_4; }
	inline void set_cursorLeft_4(int32_t value)
	{
		___cursorLeft_4 = value;
	}

	inline static int32_t get_offset_of_cursorTop_5() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___cursorTop_5)); }
	inline int32_t get_cursorTop_5() const { return ___cursorTop_5; }
	inline int32_t* get_address_of_cursorTop_5() { return &___cursorTop_5; }
	inline void set_cursorTop_5(int32_t value)
	{
		___cursorTop_5 = value;
	}

	inline static int32_t get_offset_of_title_6() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___title_6)); }
	inline String_t* get_title_6() const { return ___title_6; }
	inline String_t** get_address_of_title_6() { return &___title_6; }
	inline void set_title_6(String_t* value)
	{
		___title_6 = value;
		Il2CppCodeGenWriteBarrier(&___title_6, value);
	}

	inline static int32_t get_offset_of_titleFormat_7() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___titleFormat_7)); }
	inline String_t* get_titleFormat_7() const { return ___titleFormat_7; }
	inline String_t** get_address_of_titleFormat_7() { return &___titleFormat_7; }
	inline void set_titleFormat_7(String_t* value)
	{
		___titleFormat_7 = value;
		Il2CppCodeGenWriteBarrier(&___titleFormat_7, value);
	}

	inline static int32_t get_offset_of_cursorVisible_8() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___cursorVisible_8)); }
	inline bool get_cursorVisible_8() const { return ___cursorVisible_8; }
	inline bool* get_address_of_cursorVisible_8() { return &___cursorVisible_8; }
	inline void set_cursorVisible_8(bool value)
	{
		___cursorVisible_8 = value;
	}

	inline static int32_t get_offset_of_csrVisible_9() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___csrVisible_9)); }
	inline String_t* get_csrVisible_9() const { return ___csrVisible_9; }
	inline String_t** get_address_of_csrVisible_9() { return &___csrVisible_9; }
	inline void set_csrVisible_9(String_t* value)
	{
		___csrVisible_9 = value;
		Il2CppCodeGenWriteBarrier(&___csrVisible_9, value);
	}

	inline static int32_t get_offset_of_csrInvisible_10() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___csrInvisible_10)); }
	inline String_t* get_csrInvisible_10() const { return ___csrInvisible_10; }
	inline String_t** get_address_of_csrInvisible_10() { return &___csrInvisible_10; }
	inline void set_csrInvisible_10(String_t* value)
	{
		___csrInvisible_10 = value;
		Il2CppCodeGenWriteBarrier(&___csrInvisible_10, value);
	}

	inline static int32_t get_offset_of_clear_11() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___clear_11)); }
	inline String_t* get_clear_11() const { return ___clear_11; }
	inline String_t** get_address_of_clear_11() { return &___clear_11; }
	inline void set_clear_11(String_t* value)
	{
		___clear_11 = value;
		Il2CppCodeGenWriteBarrier(&___clear_11, value);
	}

	inline static int32_t get_offset_of_bell_12() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___bell_12)); }
	inline String_t* get_bell_12() const { return ___bell_12; }
	inline String_t** get_address_of_bell_12() { return &___bell_12; }
	inline void set_bell_12(String_t* value)
	{
		___bell_12 = value;
		Il2CppCodeGenWriteBarrier(&___bell_12, value);
	}

	inline static int32_t get_offset_of_term_13() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___term_13)); }
	inline String_t* get_term_13() const { return ___term_13; }
	inline String_t** get_address_of_term_13() { return &___term_13; }
	inline void set_term_13(String_t* value)
	{
		___term_13 = value;
		Il2CppCodeGenWriteBarrier(&___term_13, value);
	}

	inline static int32_t get_offset_of_stdin_14() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___stdin_14)); }
	inline StreamReader_t2360341767 * get_stdin_14() const { return ___stdin_14; }
	inline StreamReader_t2360341767 ** get_address_of_stdin_14() { return &___stdin_14; }
	inline void set_stdin_14(StreamReader_t2360341767 * value)
	{
		___stdin_14 = value;
		Il2CppCodeGenWriteBarrier(&___stdin_14, value);
	}

	inline static int32_t get_offset_of_stdout_15() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___stdout_15)); }
	inline CStreamWriter_t2592797654 * get_stdout_15() const { return ___stdout_15; }
	inline CStreamWriter_t2592797654 ** get_address_of_stdout_15() { return &___stdout_15; }
	inline void set_stdout_15(CStreamWriter_t2592797654 * value)
	{
		___stdout_15 = value;
		Il2CppCodeGenWriteBarrier(&___stdout_15, value);
	}

	inline static int32_t get_offset_of_windowWidth_16() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___windowWidth_16)); }
	inline int32_t get_windowWidth_16() const { return ___windowWidth_16; }
	inline int32_t* get_address_of_windowWidth_16() { return &___windowWidth_16; }
	inline void set_windowWidth_16(int32_t value)
	{
		___windowWidth_16 = value;
	}

	inline static int32_t get_offset_of_windowHeight_17() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___windowHeight_17)); }
	inline int32_t get_windowHeight_17() const { return ___windowHeight_17; }
	inline int32_t* get_address_of_windowHeight_17() { return &___windowHeight_17; }
	inline void set_windowHeight_17(int32_t value)
	{
		___windowHeight_17 = value;
	}

	inline static int32_t get_offset_of_bufferHeight_18() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___bufferHeight_18)); }
	inline int32_t get_bufferHeight_18() const { return ___bufferHeight_18; }
	inline int32_t* get_address_of_bufferHeight_18() { return &___bufferHeight_18; }
	inline void set_bufferHeight_18(int32_t value)
	{
		___bufferHeight_18 = value;
	}

	inline static int32_t get_offset_of_bufferWidth_19() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___bufferWidth_19)); }
	inline int32_t get_bufferWidth_19() const { return ___bufferWidth_19; }
	inline int32_t* get_address_of_bufferWidth_19() { return &___bufferWidth_19; }
	inline void set_bufferWidth_19(int32_t value)
	{
		___bufferWidth_19 = value;
	}

	inline static int32_t get_offset_of_buffer_20() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___buffer_20)); }
	inline CharU5BU5D_t1328083999* get_buffer_20() const { return ___buffer_20; }
	inline CharU5BU5D_t1328083999** get_address_of_buffer_20() { return &___buffer_20; }
	inline void set_buffer_20(CharU5BU5D_t1328083999* value)
	{
		___buffer_20 = value;
		Il2CppCodeGenWriteBarrier(&___buffer_20, value);
	}

	inline static int32_t get_offset_of_readpos_21() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___readpos_21)); }
	inline int32_t get_readpos_21() const { return ___readpos_21; }
	inline int32_t* get_address_of_readpos_21() { return &___readpos_21; }
	inline void set_readpos_21(int32_t value)
	{
		___readpos_21 = value;
	}

	inline static int32_t get_offset_of_writepos_22() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___writepos_22)); }
	inline int32_t get_writepos_22() const { return ___writepos_22; }
	inline int32_t* get_address_of_writepos_22() { return &___writepos_22; }
	inline void set_writepos_22(int32_t value)
	{
		___writepos_22 = value;
	}

	inline static int32_t get_offset_of_keypadXmit_23() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___keypadXmit_23)); }
	inline String_t* get_keypadXmit_23() const { return ___keypadXmit_23; }
	inline String_t** get_address_of_keypadXmit_23() { return &___keypadXmit_23; }
	inline void set_keypadXmit_23(String_t* value)
	{
		___keypadXmit_23 = value;
		Il2CppCodeGenWriteBarrier(&___keypadXmit_23, value);
	}

	inline static int32_t get_offset_of_keypadLocal_24() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___keypadLocal_24)); }
	inline String_t* get_keypadLocal_24() const { return ___keypadLocal_24; }
	inline String_t** get_address_of_keypadLocal_24() { return &___keypadLocal_24; }
	inline void set_keypadLocal_24(String_t* value)
	{
		___keypadLocal_24 = value;
		Il2CppCodeGenWriteBarrier(&___keypadLocal_24, value);
	}

	inline static int32_t get_offset_of_inited_25() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___inited_25)); }
	inline bool get_inited_25() const { return ___inited_25; }
	inline bool* get_address_of_inited_25() { return &___inited_25; }
	inline void set_inited_25(bool value)
	{
		___inited_25 = value;
	}

	inline static int32_t get_offset_of_initLock_26() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___initLock_26)); }
	inline Il2CppObject * get_initLock_26() const { return ___initLock_26; }
	inline Il2CppObject ** get_address_of_initLock_26() { return &___initLock_26; }
	inline void set_initLock_26(Il2CppObject * value)
	{
		___initLock_26 = value;
		Il2CppCodeGenWriteBarrier(&___initLock_26, value);
	}

	inline static int32_t get_offset_of_initKeys_27() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___initKeys_27)); }
	inline bool get_initKeys_27() const { return ___initKeys_27; }
	inline bool* get_address_of_initKeys_27() { return &___initKeys_27; }
	inline void set_initKeys_27(bool value)
	{
		___initKeys_27 = value;
	}

	inline static int32_t get_offset_of_origPair_28() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___origPair_28)); }
	inline String_t* get_origPair_28() const { return ___origPair_28; }
	inline String_t** get_address_of_origPair_28() { return &___origPair_28; }
	inline void set_origPair_28(String_t* value)
	{
		___origPair_28 = value;
		Il2CppCodeGenWriteBarrier(&___origPair_28, value);
	}

	inline static int32_t get_offset_of_origColors_29() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___origColors_29)); }
	inline String_t* get_origColors_29() const { return ___origColors_29; }
	inline String_t** get_address_of_origColors_29() { return &___origColors_29; }
	inline void set_origColors_29(String_t* value)
	{
		___origColors_29 = value;
		Il2CppCodeGenWriteBarrier(&___origColors_29, value);
	}

	inline static int32_t get_offset_of_cursorAddress_30() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___cursorAddress_30)); }
	inline String_t* get_cursorAddress_30() const { return ___cursorAddress_30; }
	inline String_t** get_address_of_cursorAddress_30() { return &___cursorAddress_30; }
	inline void set_cursorAddress_30(String_t* value)
	{
		___cursorAddress_30 = value;
		Il2CppCodeGenWriteBarrier(&___cursorAddress_30, value);
	}

	inline static int32_t get_offset_of_fgcolor_31() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___fgcolor_31)); }
	inline int32_t get_fgcolor_31() const { return ___fgcolor_31; }
	inline int32_t* get_address_of_fgcolor_31() { return &___fgcolor_31; }
	inline void set_fgcolor_31(int32_t value)
	{
		___fgcolor_31 = value;
	}

	inline static int32_t get_offset_of_color16_32() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___color16_32)); }
	inline bool get_color16_32() const { return ___color16_32; }
	inline bool* get_address_of_color16_32() { return &___color16_32; }
	inline void set_color16_32(bool value)
	{
		___color16_32 = value;
	}

	inline static int32_t get_offset_of_setlfgcolor_33() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___setlfgcolor_33)); }
	inline String_t* get_setlfgcolor_33() const { return ___setlfgcolor_33; }
	inline String_t** get_address_of_setlfgcolor_33() { return &___setlfgcolor_33; }
	inline void set_setlfgcolor_33(String_t* value)
	{
		___setlfgcolor_33 = value;
		Il2CppCodeGenWriteBarrier(&___setlfgcolor_33, value);
	}

	inline static int32_t get_offset_of_setlbgcolor_34() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___setlbgcolor_34)); }
	inline String_t* get_setlbgcolor_34() const { return ___setlbgcolor_34; }
	inline String_t** get_address_of_setlbgcolor_34() { return &___setlbgcolor_34; }
	inline void set_setlbgcolor_34(String_t* value)
	{
		___setlbgcolor_34 = value;
		Il2CppCodeGenWriteBarrier(&___setlbgcolor_34, value);
	}

	inline static int32_t get_offset_of_setfgcolor_35() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___setfgcolor_35)); }
	inline String_t* get_setfgcolor_35() const { return ___setfgcolor_35; }
	inline String_t** get_address_of_setfgcolor_35() { return &___setfgcolor_35; }
	inline void set_setfgcolor_35(String_t* value)
	{
		___setfgcolor_35 = value;
		Il2CppCodeGenWriteBarrier(&___setfgcolor_35, value);
	}

	inline static int32_t get_offset_of_setbgcolor_36() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___setbgcolor_36)); }
	inline String_t* get_setbgcolor_36() const { return ___setbgcolor_36; }
	inline String_t** get_address_of_setbgcolor_36() { return &___setbgcolor_36; }
	inline void set_setbgcolor_36(String_t* value)
	{
		___setbgcolor_36 = value;
		Il2CppCodeGenWriteBarrier(&___setbgcolor_36, value);
	}

	inline static int32_t get_offset_of_noGetPosition_37() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___noGetPosition_37)); }
	inline bool get_noGetPosition_37() const { return ___noGetPosition_37; }
	inline bool* get_address_of_noGetPosition_37() { return &___noGetPosition_37; }
	inline void set_noGetPosition_37(bool value)
	{
		___noGetPosition_37 = value;
	}

	inline static int32_t get_offset_of_keymap_38() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___keymap_38)); }
	inline Hashtable_t909839986 * get_keymap_38() const { return ___keymap_38; }
	inline Hashtable_t909839986 ** get_address_of_keymap_38() { return &___keymap_38; }
	inline void set_keymap_38(Hashtable_t909839986 * value)
	{
		___keymap_38 = value;
		Il2CppCodeGenWriteBarrier(&___keymap_38, value);
	}

	inline static int32_t get_offset_of_rootmap_39() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___rootmap_39)); }
	inline ByteMatcher_t2890532040 * get_rootmap_39() const { return ___rootmap_39; }
	inline ByteMatcher_t2890532040 ** get_address_of_rootmap_39() { return &___rootmap_39; }
	inline void set_rootmap_39(ByteMatcher_t2890532040 * value)
	{
		___rootmap_39 = value;
		Il2CppCodeGenWriteBarrier(&___rootmap_39, value);
	}

	inline static int32_t get_offset_of_home_1_1_40() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___home_1_1_40)); }
	inline bool get_home_1_1_40() const { return ___home_1_1_40; }
	inline bool* get_address_of_home_1_1_40() { return &___home_1_1_40; }
	inline void set_home_1_1_40(bool value)
	{
		___home_1_1_40 = value;
	}

	inline static int32_t get_offset_of_rl_startx_41() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___rl_startx_41)); }
	inline int32_t get_rl_startx_41() const { return ___rl_startx_41; }
	inline int32_t* get_address_of_rl_startx_41() { return &___rl_startx_41; }
	inline void set_rl_startx_41(int32_t value)
	{
		___rl_startx_41 = value;
	}

	inline static int32_t get_offset_of_rl_starty_42() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___rl_starty_42)); }
	inline int32_t get_rl_starty_42() const { return ___rl_starty_42; }
	inline int32_t* get_address_of_rl_starty_42() { return &___rl_starty_42; }
	inline void set_rl_starty_42(int32_t value)
	{
		___rl_starty_42 = value;
	}

	inline static int32_t get_offset_of_control_characters_43() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___control_characters_43)); }
	inline ByteU5BU5D_t3397334013* get_control_characters_43() const { return ___control_characters_43; }
	inline ByteU5BU5D_t3397334013** get_address_of_control_characters_43() { return &___control_characters_43; }
	inline void set_control_characters_43(ByteU5BU5D_t3397334013* value)
	{
		___control_characters_43 = value;
		Il2CppCodeGenWriteBarrier(&___control_characters_43, value);
	}

	inline static int32_t get_offset_of_echobuf_44() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___echobuf_44)); }
	inline CharU5BU5D_t1328083999* get_echobuf_44() const { return ___echobuf_44; }
	inline CharU5BU5D_t1328083999** get_address_of_echobuf_44() { return &___echobuf_44; }
	inline void set_echobuf_44(CharU5BU5D_t1328083999* value)
	{
		___echobuf_44 = value;
		Il2CppCodeGenWriteBarrier(&___echobuf_44, value);
	}

	inline static int32_t get_offset_of_echon_45() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152, ___echon_45)); }
	inline int32_t get_echon_45() const { return ___echon_45; }
	inline int32_t* get_address_of_echon_45() { return &___echon_45; }
	inline void set_echon_45(int32_t value)
	{
		___echon_45 = value;
	}
};

struct TermInfoDriver_t3839442152_StaticFields
{
public:
	// System.Int32* System.TermInfoDriver::native_terminal_size
	int32_t* ___native_terminal_size_0;
	// System.Int32 System.TermInfoDriver::terminal_size
	int32_t ___terminal_size_1;
	// System.String[] System.TermInfoDriver::locations
	StringU5BU5D_t1642385972* ___locations_2;
	// System.TermInfoStrings[] System.TermInfoDriver::UsedKeys
	TermInfoStringsU5BU5D_t3527186833* ___UsedKeys_46;

public:
	inline static int32_t get_offset_of_native_terminal_size_0() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152_StaticFields, ___native_terminal_size_0)); }
	inline int32_t* get_native_terminal_size_0() const { return ___native_terminal_size_0; }
	inline int32_t** get_address_of_native_terminal_size_0() { return &___native_terminal_size_0; }
	inline void set_native_terminal_size_0(int32_t* value)
	{
		___native_terminal_size_0 = value;
	}

	inline static int32_t get_offset_of_terminal_size_1() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152_StaticFields, ___terminal_size_1)); }
	inline int32_t get_terminal_size_1() const { return ___terminal_size_1; }
	inline int32_t* get_address_of_terminal_size_1() { return &___terminal_size_1; }
	inline void set_terminal_size_1(int32_t value)
	{
		___terminal_size_1 = value;
	}

	inline static int32_t get_offset_of_locations_2() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152_StaticFields, ___locations_2)); }
	inline StringU5BU5D_t1642385972* get_locations_2() const { return ___locations_2; }
	inline StringU5BU5D_t1642385972** get_address_of_locations_2() { return &___locations_2; }
	inline void set_locations_2(StringU5BU5D_t1642385972* value)
	{
		___locations_2 = value;
		Il2CppCodeGenWriteBarrier(&___locations_2, value);
	}

	inline static int32_t get_offset_of_UsedKeys_46() { return static_cast<int32_t>(offsetof(TermInfoDriver_t3839442152_StaticFields, ___UsedKeys_46)); }
	inline TermInfoStringsU5BU5D_t3527186833* get_UsedKeys_46() const { return ___UsedKeys_46; }
	inline TermInfoStringsU5BU5D_t3527186833** get_address_of_UsedKeys_46() { return &___UsedKeys_46; }
	inline void set_UsedKeys_46(TermInfoStringsU5BU5D_t3527186833* value)
	{
		___UsedKeys_46 = value;
		Il2CppCodeGenWriteBarrier(&___UsedKeys_46, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
