#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlWriter1048088568.h"
#include "System_Xml_System_Xml_XmlTextWriter_XmlDeclState3530111136.h"
#include "System_Xml_System_Xml_NewLineHandling1737195169.h"
#include "System_Xml_System_Xml_WriteState1534871862.h"
#include "System_Xml_System_Xml_XmlNodeType739504597.h"
#include "System_Xml_System_Xml_NamespaceHandling1452270444.h"

// System.Text.Encoding
struct Encoding_t663144255;
// System.Char[]
struct CharU5BU5D_t1328083999;
// System.IO.Stream
struct Stream_t3255436806;
// System.IO.TextWriter
struct TextWriter_t4027217640;
// System.IO.StringWriter
struct StringWriter_t4139609088;
// System.String
struct String_t;
// System.Xml.XmlNamespaceManager
struct XmlNamespaceManager_t486731501;
// System.Xml.XmlTextWriter/XmlNodeInfo[]
struct XmlNodeInfoU5BU5D_t2015100792;
// System.Collections.Stack
struct Stack_t1043988394;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlTextWriter
struct  XmlTextWriter_t2527250655  : public XmlWriter_t1048088568
{
public:
	// System.IO.Stream System.Xml.XmlTextWriter::base_stream
	Stream_t3255436806 * ___base_stream_3;
	// System.IO.TextWriter System.Xml.XmlTextWriter::source
	TextWriter_t4027217640 * ___source_4;
	// System.IO.TextWriter System.Xml.XmlTextWriter::writer
	TextWriter_t4027217640 * ___writer_5;
	// System.IO.StringWriter System.Xml.XmlTextWriter::preserver
	StringWriter_t4139609088 * ___preserver_6;
	// System.String System.Xml.XmlTextWriter::preserved_name
	String_t* ___preserved_name_7;
	// System.Boolean System.Xml.XmlTextWriter::is_preserved_xmlns
	bool ___is_preserved_xmlns_8;
	// System.Boolean System.Xml.XmlTextWriter::allow_doc_fragment
	bool ___allow_doc_fragment_9;
	// System.Boolean System.Xml.XmlTextWriter::close_output_stream
	bool ___close_output_stream_10;
	// System.Boolean System.Xml.XmlTextWriter::ignore_encoding
	bool ___ignore_encoding_11;
	// System.Boolean System.Xml.XmlTextWriter::namespaces
	bool ___namespaces_12;
	// System.Xml.XmlTextWriter/XmlDeclState System.Xml.XmlTextWriter::xmldecl_state
	int32_t ___xmldecl_state_13;
	// System.Boolean System.Xml.XmlTextWriter::check_character_validity
	bool ___check_character_validity_14;
	// System.Xml.NewLineHandling System.Xml.XmlTextWriter::newline_handling
	int32_t ___newline_handling_15;
	// System.Boolean System.Xml.XmlTextWriter::is_document_entity
	bool ___is_document_entity_16;
	// System.Xml.WriteState System.Xml.XmlTextWriter::state
	int32_t ___state_17;
	// System.Xml.XmlNodeType System.Xml.XmlTextWriter::node_state
	int32_t ___node_state_18;
	// System.Xml.XmlNamespaceManager System.Xml.XmlTextWriter::nsmanager
	XmlNamespaceManager_t486731501 * ___nsmanager_19;
	// System.Int32 System.Xml.XmlTextWriter::open_count
	int32_t ___open_count_20;
	// System.Xml.XmlTextWriter/XmlNodeInfo[] System.Xml.XmlTextWriter::elements
	XmlNodeInfoU5BU5D_t2015100792* ___elements_21;
	// System.Collections.Stack System.Xml.XmlTextWriter::new_local_namespaces
	Stack_t1043988394 * ___new_local_namespaces_22;
	// System.Collections.ArrayList System.Xml.XmlTextWriter::explicit_nsdecls
	ArrayList_t4252133567 * ___explicit_nsdecls_23;
	// System.Xml.NamespaceHandling System.Xml.XmlTextWriter::namespace_handling
	int32_t ___namespace_handling_24;
	// System.Boolean System.Xml.XmlTextWriter::indent
	bool ___indent_25;
	// System.Int32 System.Xml.XmlTextWriter::indent_count
	int32_t ___indent_count_26;
	// System.Char System.Xml.XmlTextWriter::indent_char
	Il2CppChar ___indent_char_27;
	// System.String System.Xml.XmlTextWriter::indent_string
	String_t* ___indent_string_28;
	// System.String System.Xml.XmlTextWriter::newline
	String_t* ___newline_29;
	// System.Boolean System.Xml.XmlTextWriter::indent_attributes
	bool ___indent_attributes_30;
	// System.Char System.Xml.XmlTextWriter::quote_char
	Il2CppChar ___quote_char_31;
	// System.Boolean System.Xml.XmlTextWriter::v2
	bool ___v2_32;

public:
	inline static int32_t get_offset_of_base_stream_3() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___base_stream_3)); }
	inline Stream_t3255436806 * get_base_stream_3() const { return ___base_stream_3; }
	inline Stream_t3255436806 ** get_address_of_base_stream_3() { return &___base_stream_3; }
	inline void set_base_stream_3(Stream_t3255436806 * value)
	{
		___base_stream_3 = value;
		Il2CppCodeGenWriteBarrier(&___base_stream_3, value);
	}

	inline static int32_t get_offset_of_source_4() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___source_4)); }
	inline TextWriter_t4027217640 * get_source_4() const { return ___source_4; }
	inline TextWriter_t4027217640 ** get_address_of_source_4() { return &___source_4; }
	inline void set_source_4(TextWriter_t4027217640 * value)
	{
		___source_4 = value;
		Il2CppCodeGenWriteBarrier(&___source_4, value);
	}

	inline static int32_t get_offset_of_writer_5() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___writer_5)); }
	inline TextWriter_t4027217640 * get_writer_5() const { return ___writer_5; }
	inline TextWriter_t4027217640 ** get_address_of_writer_5() { return &___writer_5; }
	inline void set_writer_5(TextWriter_t4027217640 * value)
	{
		___writer_5 = value;
		Il2CppCodeGenWriteBarrier(&___writer_5, value);
	}

	inline static int32_t get_offset_of_preserver_6() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___preserver_6)); }
	inline StringWriter_t4139609088 * get_preserver_6() const { return ___preserver_6; }
	inline StringWriter_t4139609088 ** get_address_of_preserver_6() { return &___preserver_6; }
	inline void set_preserver_6(StringWriter_t4139609088 * value)
	{
		___preserver_6 = value;
		Il2CppCodeGenWriteBarrier(&___preserver_6, value);
	}

	inline static int32_t get_offset_of_preserved_name_7() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___preserved_name_7)); }
	inline String_t* get_preserved_name_7() const { return ___preserved_name_7; }
	inline String_t** get_address_of_preserved_name_7() { return &___preserved_name_7; }
	inline void set_preserved_name_7(String_t* value)
	{
		___preserved_name_7 = value;
		Il2CppCodeGenWriteBarrier(&___preserved_name_7, value);
	}

	inline static int32_t get_offset_of_is_preserved_xmlns_8() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___is_preserved_xmlns_8)); }
	inline bool get_is_preserved_xmlns_8() const { return ___is_preserved_xmlns_8; }
	inline bool* get_address_of_is_preserved_xmlns_8() { return &___is_preserved_xmlns_8; }
	inline void set_is_preserved_xmlns_8(bool value)
	{
		___is_preserved_xmlns_8 = value;
	}

	inline static int32_t get_offset_of_allow_doc_fragment_9() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___allow_doc_fragment_9)); }
	inline bool get_allow_doc_fragment_9() const { return ___allow_doc_fragment_9; }
	inline bool* get_address_of_allow_doc_fragment_9() { return &___allow_doc_fragment_9; }
	inline void set_allow_doc_fragment_9(bool value)
	{
		___allow_doc_fragment_9 = value;
	}

	inline static int32_t get_offset_of_close_output_stream_10() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___close_output_stream_10)); }
	inline bool get_close_output_stream_10() const { return ___close_output_stream_10; }
	inline bool* get_address_of_close_output_stream_10() { return &___close_output_stream_10; }
	inline void set_close_output_stream_10(bool value)
	{
		___close_output_stream_10 = value;
	}

	inline static int32_t get_offset_of_ignore_encoding_11() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___ignore_encoding_11)); }
	inline bool get_ignore_encoding_11() const { return ___ignore_encoding_11; }
	inline bool* get_address_of_ignore_encoding_11() { return &___ignore_encoding_11; }
	inline void set_ignore_encoding_11(bool value)
	{
		___ignore_encoding_11 = value;
	}

	inline static int32_t get_offset_of_namespaces_12() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___namespaces_12)); }
	inline bool get_namespaces_12() const { return ___namespaces_12; }
	inline bool* get_address_of_namespaces_12() { return &___namespaces_12; }
	inline void set_namespaces_12(bool value)
	{
		___namespaces_12 = value;
	}

	inline static int32_t get_offset_of_xmldecl_state_13() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___xmldecl_state_13)); }
	inline int32_t get_xmldecl_state_13() const { return ___xmldecl_state_13; }
	inline int32_t* get_address_of_xmldecl_state_13() { return &___xmldecl_state_13; }
	inline void set_xmldecl_state_13(int32_t value)
	{
		___xmldecl_state_13 = value;
	}

	inline static int32_t get_offset_of_check_character_validity_14() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___check_character_validity_14)); }
	inline bool get_check_character_validity_14() const { return ___check_character_validity_14; }
	inline bool* get_address_of_check_character_validity_14() { return &___check_character_validity_14; }
	inline void set_check_character_validity_14(bool value)
	{
		___check_character_validity_14 = value;
	}

	inline static int32_t get_offset_of_newline_handling_15() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___newline_handling_15)); }
	inline int32_t get_newline_handling_15() const { return ___newline_handling_15; }
	inline int32_t* get_address_of_newline_handling_15() { return &___newline_handling_15; }
	inline void set_newline_handling_15(int32_t value)
	{
		___newline_handling_15 = value;
	}

	inline static int32_t get_offset_of_is_document_entity_16() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___is_document_entity_16)); }
	inline bool get_is_document_entity_16() const { return ___is_document_entity_16; }
	inline bool* get_address_of_is_document_entity_16() { return &___is_document_entity_16; }
	inline void set_is_document_entity_16(bool value)
	{
		___is_document_entity_16 = value;
	}

	inline static int32_t get_offset_of_state_17() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___state_17)); }
	inline int32_t get_state_17() const { return ___state_17; }
	inline int32_t* get_address_of_state_17() { return &___state_17; }
	inline void set_state_17(int32_t value)
	{
		___state_17 = value;
	}

	inline static int32_t get_offset_of_node_state_18() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___node_state_18)); }
	inline int32_t get_node_state_18() const { return ___node_state_18; }
	inline int32_t* get_address_of_node_state_18() { return &___node_state_18; }
	inline void set_node_state_18(int32_t value)
	{
		___node_state_18 = value;
	}

	inline static int32_t get_offset_of_nsmanager_19() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___nsmanager_19)); }
	inline XmlNamespaceManager_t486731501 * get_nsmanager_19() const { return ___nsmanager_19; }
	inline XmlNamespaceManager_t486731501 ** get_address_of_nsmanager_19() { return &___nsmanager_19; }
	inline void set_nsmanager_19(XmlNamespaceManager_t486731501 * value)
	{
		___nsmanager_19 = value;
		Il2CppCodeGenWriteBarrier(&___nsmanager_19, value);
	}

	inline static int32_t get_offset_of_open_count_20() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___open_count_20)); }
	inline int32_t get_open_count_20() const { return ___open_count_20; }
	inline int32_t* get_address_of_open_count_20() { return &___open_count_20; }
	inline void set_open_count_20(int32_t value)
	{
		___open_count_20 = value;
	}

	inline static int32_t get_offset_of_elements_21() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___elements_21)); }
	inline XmlNodeInfoU5BU5D_t2015100792* get_elements_21() const { return ___elements_21; }
	inline XmlNodeInfoU5BU5D_t2015100792** get_address_of_elements_21() { return &___elements_21; }
	inline void set_elements_21(XmlNodeInfoU5BU5D_t2015100792* value)
	{
		___elements_21 = value;
		Il2CppCodeGenWriteBarrier(&___elements_21, value);
	}

	inline static int32_t get_offset_of_new_local_namespaces_22() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___new_local_namespaces_22)); }
	inline Stack_t1043988394 * get_new_local_namespaces_22() const { return ___new_local_namespaces_22; }
	inline Stack_t1043988394 ** get_address_of_new_local_namespaces_22() { return &___new_local_namespaces_22; }
	inline void set_new_local_namespaces_22(Stack_t1043988394 * value)
	{
		___new_local_namespaces_22 = value;
		Il2CppCodeGenWriteBarrier(&___new_local_namespaces_22, value);
	}

	inline static int32_t get_offset_of_explicit_nsdecls_23() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___explicit_nsdecls_23)); }
	inline ArrayList_t4252133567 * get_explicit_nsdecls_23() const { return ___explicit_nsdecls_23; }
	inline ArrayList_t4252133567 ** get_address_of_explicit_nsdecls_23() { return &___explicit_nsdecls_23; }
	inline void set_explicit_nsdecls_23(ArrayList_t4252133567 * value)
	{
		___explicit_nsdecls_23 = value;
		Il2CppCodeGenWriteBarrier(&___explicit_nsdecls_23, value);
	}

	inline static int32_t get_offset_of_namespace_handling_24() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___namespace_handling_24)); }
	inline int32_t get_namespace_handling_24() const { return ___namespace_handling_24; }
	inline int32_t* get_address_of_namespace_handling_24() { return &___namespace_handling_24; }
	inline void set_namespace_handling_24(int32_t value)
	{
		___namespace_handling_24 = value;
	}

	inline static int32_t get_offset_of_indent_25() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___indent_25)); }
	inline bool get_indent_25() const { return ___indent_25; }
	inline bool* get_address_of_indent_25() { return &___indent_25; }
	inline void set_indent_25(bool value)
	{
		___indent_25 = value;
	}

	inline static int32_t get_offset_of_indent_count_26() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___indent_count_26)); }
	inline int32_t get_indent_count_26() const { return ___indent_count_26; }
	inline int32_t* get_address_of_indent_count_26() { return &___indent_count_26; }
	inline void set_indent_count_26(int32_t value)
	{
		___indent_count_26 = value;
	}

	inline static int32_t get_offset_of_indent_char_27() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___indent_char_27)); }
	inline Il2CppChar get_indent_char_27() const { return ___indent_char_27; }
	inline Il2CppChar* get_address_of_indent_char_27() { return &___indent_char_27; }
	inline void set_indent_char_27(Il2CppChar value)
	{
		___indent_char_27 = value;
	}

	inline static int32_t get_offset_of_indent_string_28() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___indent_string_28)); }
	inline String_t* get_indent_string_28() const { return ___indent_string_28; }
	inline String_t** get_address_of_indent_string_28() { return &___indent_string_28; }
	inline void set_indent_string_28(String_t* value)
	{
		___indent_string_28 = value;
		Il2CppCodeGenWriteBarrier(&___indent_string_28, value);
	}

	inline static int32_t get_offset_of_newline_29() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___newline_29)); }
	inline String_t* get_newline_29() const { return ___newline_29; }
	inline String_t** get_address_of_newline_29() { return &___newline_29; }
	inline void set_newline_29(String_t* value)
	{
		___newline_29 = value;
		Il2CppCodeGenWriteBarrier(&___newline_29, value);
	}

	inline static int32_t get_offset_of_indent_attributes_30() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___indent_attributes_30)); }
	inline bool get_indent_attributes_30() const { return ___indent_attributes_30; }
	inline bool* get_address_of_indent_attributes_30() { return &___indent_attributes_30; }
	inline void set_indent_attributes_30(bool value)
	{
		___indent_attributes_30 = value;
	}

	inline static int32_t get_offset_of_quote_char_31() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___quote_char_31)); }
	inline Il2CppChar get_quote_char_31() const { return ___quote_char_31; }
	inline Il2CppChar* get_address_of_quote_char_31() { return &___quote_char_31; }
	inline void set_quote_char_31(Il2CppChar value)
	{
		___quote_char_31 = value;
	}

	inline static int32_t get_offset_of_v2_32() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655, ___v2_32)); }
	inline bool get_v2_32() const { return ___v2_32; }
	inline bool* get_address_of_v2_32() { return &___v2_32; }
	inline void set_v2_32(bool value)
	{
		___v2_32 = value;
	}
};

struct XmlTextWriter_t2527250655_StaticFields
{
public:
	// System.Text.Encoding System.Xml.XmlTextWriter::unmarked_utf8encoding
	Encoding_t663144255 * ___unmarked_utf8encoding_0;
	// System.Char[] System.Xml.XmlTextWriter::escaped_text_chars
	CharU5BU5D_t1328083999* ___escaped_text_chars_1;
	// System.Char[] System.Xml.XmlTextWriter::escaped_attr_chars
	CharU5BU5D_t1328083999* ___escaped_attr_chars_2;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.XmlTextWriter::<>f__switch$map3A
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map3A_33;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.XmlTextWriter::<>f__switch$map3B
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map3B_34;

public:
	inline static int32_t get_offset_of_unmarked_utf8encoding_0() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655_StaticFields, ___unmarked_utf8encoding_0)); }
	inline Encoding_t663144255 * get_unmarked_utf8encoding_0() const { return ___unmarked_utf8encoding_0; }
	inline Encoding_t663144255 ** get_address_of_unmarked_utf8encoding_0() { return &___unmarked_utf8encoding_0; }
	inline void set_unmarked_utf8encoding_0(Encoding_t663144255 * value)
	{
		___unmarked_utf8encoding_0 = value;
		Il2CppCodeGenWriteBarrier(&___unmarked_utf8encoding_0, value);
	}

	inline static int32_t get_offset_of_escaped_text_chars_1() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655_StaticFields, ___escaped_text_chars_1)); }
	inline CharU5BU5D_t1328083999* get_escaped_text_chars_1() const { return ___escaped_text_chars_1; }
	inline CharU5BU5D_t1328083999** get_address_of_escaped_text_chars_1() { return &___escaped_text_chars_1; }
	inline void set_escaped_text_chars_1(CharU5BU5D_t1328083999* value)
	{
		___escaped_text_chars_1 = value;
		Il2CppCodeGenWriteBarrier(&___escaped_text_chars_1, value);
	}

	inline static int32_t get_offset_of_escaped_attr_chars_2() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655_StaticFields, ___escaped_attr_chars_2)); }
	inline CharU5BU5D_t1328083999* get_escaped_attr_chars_2() const { return ___escaped_attr_chars_2; }
	inline CharU5BU5D_t1328083999** get_address_of_escaped_attr_chars_2() { return &___escaped_attr_chars_2; }
	inline void set_escaped_attr_chars_2(CharU5BU5D_t1328083999* value)
	{
		___escaped_attr_chars_2 = value;
		Il2CppCodeGenWriteBarrier(&___escaped_attr_chars_2, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map3A_33() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655_StaticFields, ___U3CU3Ef__switchU24map3A_33)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map3A_33() const { return ___U3CU3Ef__switchU24map3A_33; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map3A_33() { return &___U3CU3Ef__switchU24map3A_33; }
	inline void set_U3CU3Ef__switchU24map3A_33(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map3A_33 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map3A_33, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map3B_34() { return static_cast<int32_t>(offsetof(XmlTextWriter_t2527250655_StaticFields, ___U3CU3Ef__switchU24map3B_34)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map3B_34() const { return ___U3CU3Ef__switchU24map3B_34; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map3B_34() { return &___U3CU3Ef__switchU24map3B_34; }
	inline void set_U3CU3Ef__switchU24map3B_34(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map3B_34 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map3B_34, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
