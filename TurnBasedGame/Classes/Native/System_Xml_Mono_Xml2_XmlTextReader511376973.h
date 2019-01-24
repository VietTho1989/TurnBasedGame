#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlReader3675626668.h"
#include "System_Xml_System_Xml_ReadState3138905245.h"
#include "System_Xml_System_Xml_XmlNodeType739504597.h"
#include "System_Xml_System_Xml_WhitespaceHandling3754063142.h"
#include "System_Xml_System_Xml_EntityHandling3960499440.h"

// Mono.Xml2.XmlTextReader/XmlTokenInfo
struct XmlTokenInfo_t254587324;
// Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo
struct XmlAttributeTokenInfo_t3353594030;
// Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo[]
struct XmlAttributeTokenInfoU5BU5D_t650561755;
// Mono.Xml2.XmlTextReader/XmlTokenInfo[]
struct XmlTokenInfoU5BU5D_t1699546069;
// System.Xml.XmlParserContext
struct XmlParserContext_t2728039553;
// System.Xml.XmlNameTable
struct XmlNameTable_t1345805268;
// System.Xml.XmlNamespaceManager
struct XmlNamespaceManager_t486731501;
// Mono.Xml2.XmlTextReader/TagName[]
struct TagNameU5BU5D_t3429625476;
// System.String
struct String_t;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;
// System.IO.TextReader
struct TextReader_t1561828458;
// System.Char[]
struct CharU5BU5D_t1328083999;
// System.Xml.XmlReaderBinarySupport/CharGetter
struct CharGetter_t1955031820;
// System.Xml.XmlResolver
struct XmlResolver_t2024571559;
// System.Xml.NameTable
struct NameTable_t594386929;
// Mono.Xml2.XmlTextReader/DtdInputStateStack
struct DtdInputStateStack_t3023928423;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml2.XmlTextReader
struct  XmlTextReader_t511376973  : public XmlReader_t3675626668
{
public:
	// Mono.Xml2.XmlTextReader/XmlTokenInfo Mono.Xml2.XmlTextReader::cursorToken
	XmlTokenInfo_t254587324 * ___cursorToken_2;
	// Mono.Xml2.XmlTextReader/XmlTokenInfo Mono.Xml2.XmlTextReader::currentToken
	XmlTokenInfo_t254587324 * ___currentToken_3;
	// Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo Mono.Xml2.XmlTextReader::currentAttributeToken
	XmlAttributeTokenInfo_t3353594030 * ___currentAttributeToken_4;
	// Mono.Xml2.XmlTextReader/XmlTokenInfo Mono.Xml2.XmlTextReader::currentAttributeValueToken
	XmlTokenInfo_t254587324 * ___currentAttributeValueToken_5;
	// Mono.Xml2.XmlTextReader/XmlAttributeTokenInfo[] Mono.Xml2.XmlTextReader::attributeTokens
	XmlAttributeTokenInfoU5BU5D_t650561755* ___attributeTokens_6;
	// Mono.Xml2.XmlTextReader/XmlTokenInfo[] Mono.Xml2.XmlTextReader::attributeValueTokens
	XmlTokenInfoU5BU5D_t1699546069* ___attributeValueTokens_7;
	// System.Int32 Mono.Xml2.XmlTextReader::currentAttribute
	int32_t ___currentAttribute_8;
	// System.Int32 Mono.Xml2.XmlTextReader::currentAttributeValue
	int32_t ___currentAttributeValue_9;
	// System.Int32 Mono.Xml2.XmlTextReader::attributeCount
	int32_t ___attributeCount_10;
	// System.Xml.XmlParserContext Mono.Xml2.XmlTextReader::parserContext
	XmlParserContext_t2728039553 * ___parserContext_11;
	// System.Xml.XmlNameTable Mono.Xml2.XmlTextReader::nameTable
	XmlNameTable_t1345805268 * ___nameTable_12;
	// System.Xml.XmlNamespaceManager Mono.Xml2.XmlTextReader::nsmgr
	XmlNamespaceManager_t486731501 * ___nsmgr_13;
	// System.Xml.ReadState Mono.Xml2.XmlTextReader::readState
	int32_t ___readState_14;
	// System.Boolean Mono.Xml2.XmlTextReader::disallowReset
	bool ___disallowReset_15;
	// System.Int32 Mono.Xml2.XmlTextReader::depth
	int32_t ___depth_16;
	// System.Int32 Mono.Xml2.XmlTextReader::elementDepth
	int32_t ___elementDepth_17;
	// System.Boolean Mono.Xml2.XmlTextReader::depthUp
	bool ___depthUp_18;
	// System.Boolean Mono.Xml2.XmlTextReader::popScope
	bool ___popScope_19;
	// Mono.Xml2.XmlTextReader/TagName[] Mono.Xml2.XmlTextReader::elementNames
	TagNameU5BU5D_t3429625476* ___elementNames_20;
	// System.Int32 Mono.Xml2.XmlTextReader::elementNameStackPos
	int32_t ___elementNameStackPos_21;
	// System.Boolean Mono.Xml2.XmlTextReader::allowMultipleRoot
	bool ___allowMultipleRoot_22;
	// System.Boolean Mono.Xml2.XmlTextReader::isStandalone
	bool ___isStandalone_23;
	// System.Boolean Mono.Xml2.XmlTextReader::returnEntityReference
	bool ___returnEntityReference_24;
	// System.String Mono.Xml2.XmlTextReader::entityReferenceName
	String_t* ___entityReferenceName_25;
	// System.Text.StringBuilder Mono.Xml2.XmlTextReader::valueBuffer
	StringBuilder_t1221177846 * ___valueBuffer_26;
	// System.IO.TextReader Mono.Xml2.XmlTextReader::reader
	TextReader_t1561828458 * ___reader_27;
	// System.Char[] Mono.Xml2.XmlTextReader::peekChars
	CharU5BU5D_t1328083999* ___peekChars_28;
	// System.Int32 Mono.Xml2.XmlTextReader::peekCharsIndex
	int32_t ___peekCharsIndex_29;
	// System.Int32 Mono.Xml2.XmlTextReader::peekCharsLength
	int32_t ___peekCharsLength_30;
	// System.Int32 Mono.Xml2.XmlTextReader::curNodePeekIndex
	int32_t ___curNodePeekIndex_31;
	// System.Boolean Mono.Xml2.XmlTextReader::preserveCurrentTag
	bool ___preserveCurrentTag_32;
	// System.Int32 Mono.Xml2.XmlTextReader::line
	int32_t ___line_33;
	// System.Int32 Mono.Xml2.XmlTextReader::column
	int32_t ___column_34;
	// System.Int32 Mono.Xml2.XmlTextReader::currentLinkedNodeLineNumber
	int32_t ___currentLinkedNodeLineNumber_35;
	// System.Int32 Mono.Xml2.XmlTextReader::currentLinkedNodeLinePosition
	int32_t ___currentLinkedNodeLinePosition_36;
	// System.Boolean Mono.Xml2.XmlTextReader::useProceedingLineInfo
	bool ___useProceedingLineInfo_37;
	// System.Xml.XmlNodeType Mono.Xml2.XmlTextReader::startNodeType
	int32_t ___startNodeType_38;
	// System.Xml.XmlNodeType Mono.Xml2.XmlTextReader::currentState
	int32_t ___currentState_39;
	// System.Int32 Mono.Xml2.XmlTextReader::nestLevel
	int32_t ___nestLevel_40;
	// System.Boolean Mono.Xml2.XmlTextReader::readCharsInProgress
	bool ___readCharsInProgress_41;
	// System.Xml.XmlReaderBinarySupport/CharGetter Mono.Xml2.XmlTextReader::binaryCharGetter
	CharGetter_t1955031820 * ___binaryCharGetter_42;
	// System.Boolean Mono.Xml2.XmlTextReader::namespaces
	bool ___namespaces_43;
	// System.Xml.WhitespaceHandling Mono.Xml2.XmlTextReader::whitespaceHandling
	int32_t ___whitespaceHandling_44;
	// System.Xml.XmlResolver Mono.Xml2.XmlTextReader::resolver
	XmlResolver_t2024571559 * ___resolver_45;
	// System.Boolean Mono.Xml2.XmlTextReader::normalization
	bool ___normalization_46;
	// System.Boolean Mono.Xml2.XmlTextReader::checkCharacters
	bool ___checkCharacters_47;
	// System.Boolean Mono.Xml2.XmlTextReader::prohibitDtd
	bool ___prohibitDtd_48;
	// System.Boolean Mono.Xml2.XmlTextReader::closeInput
	bool ___closeInput_49;
	// System.Xml.EntityHandling Mono.Xml2.XmlTextReader::entityHandling
	int32_t ___entityHandling_50;
	// System.Xml.NameTable Mono.Xml2.XmlTextReader::whitespacePool
	NameTable_t594386929 * ___whitespacePool_51;
	// System.Char[] Mono.Xml2.XmlTextReader::whitespaceCache
	CharU5BU5D_t1328083999* ___whitespaceCache_52;
	// Mono.Xml2.XmlTextReader/DtdInputStateStack Mono.Xml2.XmlTextReader::stateStack
	DtdInputStateStack_t3023928423 * ___stateStack_53;

public:
	inline static int32_t get_offset_of_cursorToken_2() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___cursorToken_2)); }
	inline XmlTokenInfo_t254587324 * get_cursorToken_2() const { return ___cursorToken_2; }
	inline XmlTokenInfo_t254587324 ** get_address_of_cursorToken_2() { return &___cursorToken_2; }
	inline void set_cursorToken_2(XmlTokenInfo_t254587324 * value)
	{
		___cursorToken_2 = value;
		Il2CppCodeGenWriteBarrier(&___cursorToken_2, value);
	}

	inline static int32_t get_offset_of_currentToken_3() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentToken_3)); }
	inline XmlTokenInfo_t254587324 * get_currentToken_3() const { return ___currentToken_3; }
	inline XmlTokenInfo_t254587324 ** get_address_of_currentToken_3() { return &___currentToken_3; }
	inline void set_currentToken_3(XmlTokenInfo_t254587324 * value)
	{
		___currentToken_3 = value;
		Il2CppCodeGenWriteBarrier(&___currentToken_3, value);
	}

	inline static int32_t get_offset_of_currentAttributeToken_4() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentAttributeToken_4)); }
	inline XmlAttributeTokenInfo_t3353594030 * get_currentAttributeToken_4() const { return ___currentAttributeToken_4; }
	inline XmlAttributeTokenInfo_t3353594030 ** get_address_of_currentAttributeToken_4() { return &___currentAttributeToken_4; }
	inline void set_currentAttributeToken_4(XmlAttributeTokenInfo_t3353594030 * value)
	{
		___currentAttributeToken_4 = value;
		Il2CppCodeGenWriteBarrier(&___currentAttributeToken_4, value);
	}

	inline static int32_t get_offset_of_currentAttributeValueToken_5() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentAttributeValueToken_5)); }
	inline XmlTokenInfo_t254587324 * get_currentAttributeValueToken_5() const { return ___currentAttributeValueToken_5; }
	inline XmlTokenInfo_t254587324 ** get_address_of_currentAttributeValueToken_5() { return &___currentAttributeValueToken_5; }
	inline void set_currentAttributeValueToken_5(XmlTokenInfo_t254587324 * value)
	{
		___currentAttributeValueToken_5 = value;
		Il2CppCodeGenWriteBarrier(&___currentAttributeValueToken_5, value);
	}

	inline static int32_t get_offset_of_attributeTokens_6() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___attributeTokens_6)); }
	inline XmlAttributeTokenInfoU5BU5D_t650561755* get_attributeTokens_6() const { return ___attributeTokens_6; }
	inline XmlAttributeTokenInfoU5BU5D_t650561755** get_address_of_attributeTokens_6() { return &___attributeTokens_6; }
	inline void set_attributeTokens_6(XmlAttributeTokenInfoU5BU5D_t650561755* value)
	{
		___attributeTokens_6 = value;
		Il2CppCodeGenWriteBarrier(&___attributeTokens_6, value);
	}

	inline static int32_t get_offset_of_attributeValueTokens_7() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___attributeValueTokens_7)); }
	inline XmlTokenInfoU5BU5D_t1699546069* get_attributeValueTokens_7() const { return ___attributeValueTokens_7; }
	inline XmlTokenInfoU5BU5D_t1699546069** get_address_of_attributeValueTokens_7() { return &___attributeValueTokens_7; }
	inline void set_attributeValueTokens_7(XmlTokenInfoU5BU5D_t1699546069* value)
	{
		___attributeValueTokens_7 = value;
		Il2CppCodeGenWriteBarrier(&___attributeValueTokens_7, value);
	}

	inline static int32_t get_offset_of_currentAttribute_8() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentAttribute_8)); }
	inline int32_t get_currentAttribute_8() const { return ___currentAttribute_8; }
	inline int32_t* get_address_of_currentAttribute_8() { return &___currentAttribute_8; }
	inline void set_currentAttribute_8(int32_t value)
	{
		___currentAttribute_8 = value;
	}

	inline static int32_t get_offset_of_currentAttributeValue_9() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentAttributeValue_9)); }
	inline int32_t get_currentAttributeValue_9() const { return ___currentAttributeValue_9; }
	inline int32_t* get_address_of_currentAttributeValue_9() { return &___currentAttributeValue_9; }
	inline void set_currentAttributeValue_9(int32_t value)
	{
		___currentAttributeValue_9 = value;
	}

	inline static int32_t get_offset_of_attributeCount_10() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___attributeCount_10)); }
	inline int32_t get_attributeCount_10() const { return ___attributeCount_10; }
	inline int32_t* get_address_of_attributeCount_10() { return &___attributeCount_10; }
	inline void set_attributeCount_10(int32_t value)
	{
		___attributeCount_10 = value;
	}

	inline static int32_t get_offset_of_parserContext_11() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___parserContext_11)); }
	inline XmlParserContext_t2728039553 * get_parserContext_11() const { return ___parserContext_11; }
	inline XmlParserContext_t2728039553 ** get_address_of_parserContext_11() { return &___parserContext_11; }
	inline void set_parserContext_11(XmlParserContext_t2728039553 * value)
	{
		___parserContext_11 = value;
		Il2CppCodeGenWriteBarrier(&___parserContext_11, value);
	}

	inline static int32_t get_offset_of_nameTable_12() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___nameTable_12)); }
	inline XmlNameTable_t1345805268 * get_nameTable_12() const { return ___nameTable_12; }
	inline XmlNameTable_t1345805268 ** get_address_of_nameTable_12() { return &___nameTable_12; }
	inline void set_nameTable_12(XmlNameTable_t1345805268 * value)
	{
		___nameTable_12 = value;
		Il2CppCodeGenWriteBarrier(&___nameTable_12, value);
	}

	inline static int32_t get_offset_of_nsmgr_13() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___nsmgr_13)); }
	inline XmlNamespaceManager_t486731501 * get_nsmgr_13() const { return ___nsmgr_13; }
	inline XmlNamespaceManager_t486731501 ** get_address_of_nsmgr_13() { return &___nsmgr_13; }
	inline void set_nsmgr_13(XmlNamespaceManager_t486731501 * value)
	{
		___nsmgr_13 = value;
		Il2CppCodeGenWriteBarrier(&___nsmgr_13, value);
	}

	inline static int32_t get_offset_of_readState_14() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___readState_14)); }
	inline int32_t get_readState_14() const { return ___readState_14; }
	inline int32_t* get_address_of_readState_14() { return &___readState_14; }
	inline void set_readState_14(int32_t value)
	{
		___readState_14 = value;
	}

	inline static int32_t get_offset_of_disallowReset_15() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___disallowReset_15)); }
	inline bool get_disallowReset_15() const { return ___disallowReset_15; }
	inline bool* get_address_of_disallowReset_15() { return &___disallowReset_15; }
	inline void set_disallowReset_15(bool value)
	{
		___disallowReset_15 = value;
	}

	inline static int32_t get_offset_of_depth_16() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___depth_16)); }
	inline int32_t get_depth_16() const { return ___depth_16; }
	inline int32_t* get_address_of_depth_16() { return &___depth_16; }
	inline void set_depth_16(int32_t value)
	{
		___depth_16 = value;
	}

	inline static int32_t get_offset_of_elementDepth_17() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___elementDepth_17)); }
	inline int32_t get_elementDepth_17() const { return ___elementDepth_17; }
	inline int32_t* get_address_of_elementDepth_17() { return &___elementDepth_17; }
	inline void set_elementDepth_17(int32_t value)
	{
		___elementDepth_17 = value;
	}

	inline static int32_t get_offset_of_depthUp_18() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___depthUp_18)); }
	inline bool get_depthUp_18() const { return ___depthUp_18; }
	inline bool* get_address_of_depthUp_18() { return &___depthUp_18; }
	inline void set_depthUp_18(bool value)
	{
		___depthUp_18 = value;
	}

	inline static int32_t get_offset_of_popScope_19() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___popScope_19)); }
	inline bool get_popScope_19() const { return ___popScope_19; }
	inline bool* get_address_of_popScope_19() { return &___popScope_19; }
	inline void set_popScope_19(bool value)
	{
		___popScope_19 = value;
	}

	inline static int32_t get_offset_of_elementNames_20() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___elementNames_20)); }
	inline TagNameU5BU5D_t3429625476* get_elementNames_20() const { return ___elementNames_20; }
	inline TagNameU5BU5D_t3429625476** get_address_of_elementNames_20() { return &___elementNames_20; }
	inline void set_elementNames_20(TagNameU5BU5D_t3429625476* value)
	{
		___elementNames_20 = value;
		Il2CppCodeGenWriteBarrier(&___elementNames_20, value);
	}

	inline static int32_t get_offset_of_elementNameStackPos_21() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___elementNameStackPos_21)); }
	inline int32_t get_elementNameStackPos_21() const { return ___elementNameStackPos_21; }
	inline int32_t* get_address_of_elementNameStackPos_21() { return &___elementNameStackPos_21; }
	inline void set_elementNameStackPos_21(int32_t value)
	{
		___elementNameStackPos_21 = value;
	}

	inline static int32_t get_offset_of_allowMultipleRoot_22() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___allowMultipleRoot_22)); }
	inline bool get_allowMultipleRoot_22() const { return ___allowMultipleRoot_22; }
	inline bool* get_address_of_allowMultipleRoot_22() { return &___allowMultipleRoot_22; }
	inline void set_allowMultipleRoot_22(bool value)
	{
		___allowMultipleRoot_22 = value;
	}

	inline static int32_t get_offset_of_isStandalone_23() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___isStandalone_23)); }
	inline bool get_isStandalone_23() const { return ___isStandalone_23; }
	inline bool* get_address_of_isStandalone_23() { return &___isStandalone_23; }
	inline void set_isStandalone_23(bool value)
	{
		___isStandalone_23 = value;
	}

	inline static int32_t get_offset_of_returnEntityReference_24() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___returnEntityReference_24)); }
	inline bool get_returnEntityReference_24() const { return ___returnEntityReference_24; }
	inline bool* get_address_of_returnEntityReference_24() { return &___returnEntityReference_24; }
	inline void set_returnEntityReference_24(bool value)
	{
		___returnEntityReference_24 = value;
	}

	inline static int32_t get_offset_of_entityReferenceName_25() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___entityReferenceName_25)); }
	inline String_t* get_entityReferenceName_25() const { return ___entityReferenceName_25; }
	inline String_t** get_address_of_entityReferenceName_25() { return &___entityReferenceName_25; }
	inline void set_entityReferenceName_25(String_t* value)
	{
		___entityReferenceName_25 = value;
		Il2CppCodeGenWriteBarrier(&___entityReferenceName_25, value);
	}

	inline static int32_t get_offset_of_valueBuffer_26() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___valueBuffer_26)); }
	inline StringBuilder_t1221177846 * get_valueBuffer_26() const { return ___valueBuffer_26; }
	inline StringBuilder_t1221177846 ** get_address_of_valueBuffer_26() { return &___valueBuffer_26; }
	inline void set_valueBuffer_26(StringBuilder_t1221177846 * value)
	{
		___valueBuffer_26 = value;
		Il2CppCodeGenWriteBarrier(&___valueBuffer_26, value);
	}

	inline static int32_t get_offset_of_reader_27() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___reader_27)); }
	inline TextReader_t1561828458 * get_reader_27() const { return ___reader_27; }
	inline TextReader_t1561828458 ** get_address_of_reader_27() { return &___reader_27; }
	inline void set_reader_27(TextReader_t1561828458 * value)
	{
		___reader_27 = value;
		Il2CppCodeGenWriteBarrier(&___reader_27, value);
	}

	inline static int32_t get_offset_of_peekChars_28() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___peekChars_28)); }
	inline CharU5BU5D_t1328083999* get_peekChars_28() const { return ___peekChars_28; }
	inline CharU5BU5D_t1328083999** get_address_of_peekChars_28() { return &___peekChars_28; }
	inline void set_peekChars_28(CharU5BU5D_t1328083999* value)
	{
		___peekChars_28 = value;
		Il2CppCodeGenWriteBarrier(&___peekChars_28, value);
	}

	inline static int32_t get_offset_of_peekCharsIndex_29() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___peekCharsIndex_29)); }
	inline int32_t get_peekCharsIndex_29() const { return ___peekCharsIndex_29; }
	inline int32_t* get_address_of_peekCharsIndex_29() { return &___peekCharsIndex_29; }
	inline void set_peekCharsIndex_29(int32_t value)
	{
		___peekCharsIndex_29 = value;
	}

	inline static int32_t get_offset_of_peekCharsLength_30() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___peekCharsLength_30)); }
	inline int32_t get_peekCharsLength_30() const { return ___peekCharsLength_30; }
	inline int32_t* get_address_of_peekCharsLength_30() { return &___peekCharsLength_30; }
	inline void set_peekCharsLength_30(int32_t value)
	{
		___peekCharsLength_30 = value;
	}

	inline static int32_t get_offset_of_curNodePeekIndex_31() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___curNodePeekIndex_31)); }
	inline int32_t get_curNodePeekIndex_31() const { return ___curNodePeekIndex_31; }
	inline int32_t* get_address_of_curNodePeekIndex_31() { return &___curNodePeekIndex_31; }
	inline void set_curNodePeekIndex_31(int32_t value)
	{
		___curNodePeekIndex_31 = value;
	}

	inline static int32_t get_offset_of_preserveCurrentTag_32() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___preserveCurrentTag_32)); }
	inline bool get_preserveCurrentTag_32() const { return ___preserveCurrentTag_32; }
	inline bool* get_address_of_preserveCurrentTag_32() { return &___preserveCurrentTag_32; }
	inline void set_preserveCurrentTag_32(bool value)
	{
		___preserveCurrentTag_32 = value;
	}

	inline static int32_t get_offset_of_line_33() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___line_33)); }
	inline int32_t get_line_33() const { return ___line_33; }
	inline int32_t* get_address_of_line_33() { return &___line_33; }
	inline void set_line_33(int32_t value)
	{
		___line_33 = value;
	}

	inline static int32_t get_offset_of_column_34() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___column_34)); }
	inline int32_t get_column_34() const { return ___column_34; }
	inline int32_t* get_address_of_column_34() { return &___column_34; }
	inline void set_column_34(int32_t value)
	{
		___column_34 = value;
	}

	inline static int32_t get_offset_of_currentLinkedNodeLineNumber_35() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentLinkedNodeLineNumber_35)); }
	inline int32_t get_currentLinkedNodeLineNumber_35() const { return ___currentLinkedNodeLineNumber_35; }
	inline int32_t* get_address_of_currentLinkedNodeLineNumber_35() { return &___currentLinkedNodeLineNumber_35; }
	inline void set_currentLinkedNodeLineNumber_35(int32_t value)
	{
		___currentLinkedNodeLineNumber_35 = value;
	}

	inline static int32_t get_offset_of_currentLinkedNodeLinePosition_36() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentLinkedNodeLinePosition_36)); }
	inline int32_t get_currentLinkedNodeLinePosition_36() const { return ___currentLinkedNodeLinePosition_36; }
	inline int32_t* get_address_of_currentLinkedNodeLinePosition_36() { return &___currentLinkedNodeLinePosition_36; }
	inline void set_currentLinkedNodeLinePosition_36(int32_t value)
	{
		___currentLinkedNodeLinePosition_36 = value;
	}

	inline static int32_t get_offset_of_useProceedingLineInfo_37() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___useProceedingLineInfo_37)); }
	inline bool get_useProceedingLineInfo_37() const { return ___useProceedingLineInfo_37; }
	inline bool* get_address_of_useProceedingLineInfo_37() { return &___useProceedingLineInfo_37; }
	inline void set_useProceedingLineInfo_37(bool value)
	{
		___useProceedingLineInfo_37 = value;
	}

	inline static int32_t get_offset_of_startNodeType_38() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___startNodeType_38)); }
	inline int32_t get_startNodeType_38() const { return ___startNodeType_38; }
	inline int32_t* get_address_of_startNodeType_38() { return &___startNodeType_38; }
	inline void set_startNodeType_38(int32_t value)
	{
		___startNodeType_38 = value;
	}

	inline static int32_t get_offset_of_currentState_39() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___currentState_39)); }
	inline int32_t get_currentState_39() const { return ___currentState_39; }
	inline int32_t* get_address_of_currentState_39() { return &___currentState_39; }
	inline void set_currentState_39(int32_t value)
	{
		___currentState_39 = value;
	}

	inline static int32_t get_offset_of_nestLevel_40() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___nestLevel_40)); }
	inline int32_t get_nestLevel_40() const { return ___nestLevel_40; }
	inline int32_t* get_address_of_nestLevel_40() { return &___nestLevel_40; }
	inline void set_nestLevel_40(int32_t value)
	{
		___nestLevel_40 = value;
	}

	inline static int32_t get_offset_of_readCharsInProgress_41() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___readCharsInProgress_41)); }
	inline bool get_readCharsInProgress_41() const { return ___readCharsInProgress_41; }
	inline bool* get_address_of_readCharsInProgress_41() { return &___readCharsInProgress_41; }
	inline void set_readCharsInProgress_41(bool value)
	{
		___readCharsInProgress_41 = value;
	}

	inline static int32_t get_offset_of_binaryCharGetter_42() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___binaryCharGetter_42)); }
	inline CharGetter_t1955031820 * get_binaryCharGetter_42() const { return ___binaryCharGetter_42; }
	inline CharGetter_t1955031820 ** get_address_of_binaryCharGetter_42() { return &___binaryCharGetter_42; }
	inline void set_binaryCharGetter_42(CharGetter_t1955031820 * value)
	{
		___binaryCharGetter_42 = value;
		Il2CppCodeGenWriteBarrier(&___binaryCharGetter_42, value);
	}

	inline static int32_t get_offset_of_namespaces_43() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___namespaces_43)); }
	inline bool get_namespaces_43() const { return ___namespaces_43; }
	inline bool* get_address_of_namespaces_43() { return &___namespaces_43; }
	inline void set_namespaces_43(bool value)
	{
		___namespaces_43 = value;
	}

	inline static int32_t get_offset_of_whitespaceHandling_44() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___whitespaceHandling_44)); }
	inline int32_t get_whitespaceHandling_44() const { return ___whitespaceHandling_44; }
	inline int32_t* get_address_of_whitespaceHandling_44() { return &___whitespaceHandling_44; }
	inline void set_whitespaceHandling_44(int32_t value)
	{
		___whitespaceHandling_44 = value;
	}

	inline static int32_t get_offset_of_resolver_45() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___resolver_45)); }
	inline XmlResolver_t2024571559 * get_resolver_45() const { return ___resolver_45; }
	inline XmlResolver_t2024571559 ** get_address_of_resolver_45() { return &___resolver_45; }
	inline void set_resolver_45(XmlResolver_t2024571559 * value)
	{
		___resolver_45 = value;
		Il2CppCodeGenWriteBarrier(&___resolver_45, value);
	}

	inline static int32_t get_offset_of_normalization_46() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___normalization_46)); }
	inline bool get_normalization_46() const { return ___normalization_46; }
	inline bool* get_address_of_normalization_46() { return &___normalization_46; }
	inline void set_normalization_46(bool value)
	{
		___normalization_46 = value;
	}

	inline static int32_t get_offset_of_checkCharacters_47() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___checkCharacters_47)); }
	inline bool get_checkCharacters_47() const { return ___checkCharacters_47; }
	inline bool* get_address_of_checkCharacters_47() { return &___checkCharacters_47; }
	inline void set_checkCharacters_47(bool value)
	{
		___checkCharacters_47 = value;
	}

	inline static int32_t get_offset_of_prohibitDtd_48() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___prohibitDtd_48)); }
	inline bool get_prohibitDtd_48() const { return ___prohibitDtd_48; }
	inline bool* get_address_of_prohibitDtd_48() { return &___prohibitDtd_48; }
	inline void set_prohibitDtd_48(bool value)
	{
		___prohibitDtd_48 = value;
	}

	inline static int32_t get_offset_of_closeInput_49() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___closeInput_49)); }
	inline bool get_closeInput_49() const { return ___closeInput_49; }
	inline bool* get_address_of_closeInput_49() { return &___closeInput_49; }
	inline void set_closeInput_49(bool value)
	{
		___closeInput_49 = value;
	}

	inline static int32_t get_offset_of_entityHandling_50() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___entityHandling_50)); }
	inline int32_t get_entityHandling_50() const { return ___entityHandling_50; }
	inline int32_t* get_address_of_entityHandling_50() { return &___entityHandling_50; }
	inline void set_entityHandling_50(int32_t value)
	{
		___entityHandling_50 = value;
	}

	inline static int32_t get_offset_of_whitespacePool_51() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___whitespacePool_51)); }
	inline NameTable_t594386929 * get_whitespacePool_51() const { return ___whitespacePool_51; }
	inline NameTable_t594386929 ** get_address_of_whitespacePool_51() { return &___whitespacePool_51; }
	inline void set_whitespacePool_51(NameTable_t594386929 * value)
	{
		___whitespacePool_51 = value;
		Il2CppCodeGenWriteBarrier(&___whitespacePool_51, value);
	}

	inline static int32_t get_offset_of_whitespaceCache_52() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___whitespaceCache_52)); }
	inline CharU5BU5D_t1328083999* get_whitespaceCache_52() const { return ___whitespaceCache_52; }
	inline CharU5BU5D_t1328083999** get_address_of_whitespaceCache_52() { return &___whitespaceCache_52; }
	inline void set_whitespaceCache_52(CharU5BU5D_t1328083999* value)
	{
		___whitespaceCache_52 = value;
		Il2CppCodeGenWriteBarrier(&___whitespaceCache_52, value);
	}

	inline static int32_t get_offset_of_stateStack_53() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973, ___stateStack_53)); }
	inline DtdInputStateStack_t3023928423 * get_stateStack_53() const { return ___stateStack_53; }
	inline DtdInputStateStack_t3023928423 ** get_address_of_stateStack_53() { return &___stateStack_53; }
	inline void set_stateStack_53(DtdInputStateStack_t3023928423 * value)
	{
		___stateStack_53 = value;
		Il2CppCodeGenWriteBarrier(&___stateStack_53, value);
	}
};

struct XmlTextReader_t511376973_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Xml2.XmlTextReader::<>f__switch$map38
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map38_54;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Xml2.XmlTextReader::<>f__switch$map39
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map39_55;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map38_54() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973_StaticFields, ___U3CU3Ef__switchU24map38_54)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map38_54() const { return ___U3CU3Ef__switchU24map38_54; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map38_54() { return &___U3CU3Ef__switchU24map38_54; }
	inline void set_U3CU3Ef__switchU24map38_54(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map38_54 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map38_54, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map39_55() { return static_cast<int32_t>(offsetof(XmlTextReader_t511376973_StaticFields, ___U3CU3Ef__switchU24map39_55)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map39_55() const { return ___U3CU3Ef__switchU24map39_55; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map39_55() { return &___U3CU3Ef__switchU24map39_55; }
	inline void set_U3CU3Ef__switchU24map39_55(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map39_55 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map39_55, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
