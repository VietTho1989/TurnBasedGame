#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Mono.Xml.DTDAutomataFactory
struct DTDAutomataFactory_t3605390810;
// Mono.Xml.DTDElementAutomata
struct DTDElementAutomata_t2864881036;
// Mono.Xml.DTDEmptyAutomata
struct DTDEmptyAutomata_t411530619;
// Mono.Xml.DTDAnyAutomata
struct DTDAnyAutomata_t146446906;
// Mono.Xml.DTDInvalidAutomata
struct DTDInvalidAutomata_t247674167;
// Mono.Xml.DTDElementDeclarationCollection
struct DTDElementDeclarationCollection_t2224069626;
// Mono.Xml.DTDAttListDeclarationCollection
struct DTDAttListDeclarationCollection_t243645429;
// Mono.Xml.DTDParameterEntityDeclarationCollection
struct DTDParameterEntityDeclarationCollection_t3496720022;
// Mono.Xml.DTDEntityDeclarationCollection
struct DTDEntityDeclarationCollection_t1212505713;
// Mono.Xml.DTDNotationDeclarationCollection
struct DTDNotationDeclarationCollection_t228085060;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Xml.XmlResolver
struct XmlResolver_t2024571559;
// System.Xml.XmlNameTable
struct XmlNameTable_t1345805268;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.DTDObjectModel
struct  DTDObjectModel_t1113953282  : public Il2CppObject
{
public:
	// Mono.Xml.DTDAutomataFactory Mono.Xml.DTDObjectModel::factory
	DTDAutomataFactory_t3605390810 * ___factory_0;
	// Mono.Xml.DTDElementAutomata Mono.Xml.DTDObjectModel::rootAutomata
	DTDElementAutomata_t2864881036 * ___rootAutomata_1;
	// Mono.Xml.DTDEmptyAutomata Mono.Xml.DTDObjectModel::emptyAutomata
	DTDEmptyAutomata_t411530619 * ___emptyAutomata_2;
	// Mono.Xml.DTDAnyAutomata Mono.Xml.DTDObjectModel::anyAutomata
	DTDAnyAutomata_t146446906 * ___anyAutomata_3;
	// Mono.Xml.DTDInvalidAutomata Mono.Xml.DTDObjectModel::invalidAutomata
	DTDInvalidAutomata_t247674167 * ___invalidAutomata_4;
	// Mono.Xml.DTDElementDeclarationCollection Mono.Xml.DTDObjectModel::elementDecls
	DTDElementDeclarationCollection_t2224069626 * ___elementDecls_5;
	// Mono.Xml.DTDAttListDeclarationCollection Mono.Xml.DTDObjectModel::attListDecls
	DTDAttListDeclarationCollection_t243645429 * ___attListDecls_6;
	// Mono.Xml.DTDParameterEntityDeclarationCollection Mono.Xml.DTDObjectModel::peDecls
	DTDParameterEntityDeclarationCollection_t3496720022 * ___peDecls_7;
	// Mono.Xml.DTDEntityDeclarationCollection Mono.Xml.DTDObjectModel::entityDecls
	DTDEntityDeclarationCollection_t1212505713 * ___entityDecls_8;
	// Mono.Xml.DTDNotationDeclarationCollection Mono.Xml.DTDObjectModel::notationDecls
	DTDNotationDeclarationCollection_t228085060 * ___notationDecls_9;
	// System.Collections.ArrayList Mono.Xml.DTDObjectModel::validationErrors
	ArrayList_t4252133567 * ___validationErrors_10;
	// System.Xml.XmlResolver Mono.Xml.DTDObjectModel::resolver
	XmlResolver_t2024571559 * ___resolver_11;
	// System.Xml.XmlNameTable Mono.Xml.DTDObjectModel::nameTable
	XmlNameTable_t1345805268 * ___nameTable_12;
	// System.Collections.Hashtable Mono.Xml.DTDObjectModel::externalResources
	Hashtable_t909839986 * ___externalResources_13;
	// System.String Mono.Xml.DTDObjectModel::baseURI
	String_t* ___baseURI_14;
	// System.String Mono.Xml.DTDObjectModel::name
	String_t* ___name_15;
	// System.String Mono.Xml.DTDObjectModel::publicId
	String_t* ___publicId_16;
	// System.String Mono.Xml.DTDObjectModel::systemId
	String_t* ___systemId_17;
	// System.String Mono.Xml.DTDObjectModel::intSubset
	String_t* ___intSubset_18;
	// System.Boolean Mono.Xml.DTDObjectModel::intSubsetHasPERef
	bool ___intSubsetHasPERef_19;
	// System.Boolean Mono.Xml.DTDObjectModel::isStandalone
	bool ___isStandalone_20;
	// System.Int32 Mono.Xml.DTDObjectModel::lineNumber
	int32_t ___lineNumber_21;
	// System.Int32 Mono.Xml.DTDObjectModel::linePosition
	int32_t ___linePosition_22;

public:
	inline static int32_t get_offset_of_factory_0() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___factory_0)); }
	inline DTDAutomataFactory_t3605390810 * get_factory_0() const { return ___factory_0; }
	inline DTDAutomataFactory_t3605390810 ** get_address_of_factory_0() { return &___factory_0; }
	inline void set_factory_0(DTDAutomataFactory_t3605390810 * value)
	{
		___factory_0 = value;
		Il2CppCodeGenWriteBarrier(&___factory_0, value);
	}

	inline static int32_t get_offset_of_rootAutomata_1() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___rootAutomata_1)); }
	inline DTDElementAutomata_t2864881036 * get_rootAutomata_1() const { return ___rootAutomata_1; }
	inline DTDElementAutomata_t2864881036 ** get_address_of_rootAutomata_1() { return &___rootAutomata_1; }
	inline void set_rootAutomata_1(DTDElementAutomata_t2864881036 * value)
	{
		___rootAutomata_1 = value;
		Il2CppCodeGenWriteBarrier(&___rootAutomata_1, value);
	}

	inline static int32_t get_offset_of_emptyAutomata_2() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___emptyAutomata_2)); }
	inline DTDEmptyAutomata_t411530619 * get_emptyAutomata_2() const { return ___emptyAutomata_2; }
	inline DTDEmptyAutomata_t411530619 ** get_address_of_emptyAutomata_2() { return &___emptyAutomata_2; }
	inline void set_emptyAutomata_2(DTDEmptyAutomata_t411530619 * value)
	{
		___emptyAutomata_2 = value;
		Il2CppCodeGenWriteBarrier(&___emptyAutomata_2, value);
	}

	inline static int32_t get_offset_of_anyAutomata_3() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___anyAutomata_3)); }
	inline DTDAnyAutomata_t146446906 * get_anyAutomata_3() const { return ___anyAutomata_3; }
	inline DTDAnyAutomata_t146446906 ** get_address_of_anyAutomata_3() { return &___anyAutomata_3; }
	inline void set_anyAutomata_3(DTDAnyAutomata_t146446906 * value)
	{
		___anyAutomata_3 = value;
		Il2CppCodeGenWriteBarrier(&___anyAutomata_3, value);
	}

	inline static int32_t get_offset_of_invalidAutomata_4() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___invalidAutomata_4)); }
	inline DTDInvalidAutomata_t247674167 * get_invalidAutomata_4() const { return ___invalidAutomata_4; }
	inline DTDInvalidAutomata_t247674167 ** get_address_of_invalidAutomata_4() { return &___invalidAutomata_4; }
	inline void set_invalidAutomata_4(DTDInvalidAutomata_t247674167 * value)
	{
		___invalidAutomata_4 = value;
		Il2CppCodeGenWriteBarrier(&___invalidAutomata_4, value);
	}

	inline static int32_t get_offset_of_elementDecls_5() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___elementDecls_5)); }
	inline DTDElementDeclarationCollection_t2224069626 * get_elementDecls_5() const { return ___elementDecls_5; }
	inline DTDElementDeclarationCollection_t2224069626 ** get_address_of_elementDecls_5() { return &___elementDecls_5; }
	inline void set_elementDecls_5(DTDElementDeclarationCollection_t2224069626 * value)
	{
		___elementDecls_5 = value;
		Il2CppCodeGenWriteBarrier(&___elementDecls_5, value);
	}

	inline static int32_t get_offset_of_attListDecls_6() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___attListDecls_6)); }
	inline DTDAttListDeclarationCollection_t243645429 * get_attListDecls_6() const { return ___attListDecls_6; }
	inline DTDAttListDeclarationCollection_t243645429 ** get_address_of_attListDecls_6() { return &___attListDecls_6; }
	inline void set_attListDecls_6(DTDAttListDeclarationCollection_t243645429 * value)
	{
		___attListDecls_6 = value;
		Il2CppCodeGenWriteBarrier(&___attListDecls_6, value);
	}

	inline static int32_t get_offset_of_peDecls_7() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___peDecls_7)); }
	inline DTDParameterEntityDeclarationCollection_t3496720022 * get_peDecls_7() const { return ___peDecls_7; }
	inline DTDParameterEntityDeclarationCollection_t3496720022 ** get_address_of_peDecls_7() { return &___peDecls_7; }
	inline void set_peDecls_7(DTDParameterEntityDeclarationCollection_t3496720022 * value)
	{
		___peDecls_7 = value;
		Il2CppCodeGenWriteBarrier(&___peDecls_7, value);
	}

	inline static int32_t get_offset_of_entityDecls_8() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___entityDecls_8)); }
	inline DTDEntityDeclarationCollection_t1212505713 * get_entityDecls_8() const { return ___entityDecls_8; }
	inline DTDEntityDeclarationCollection_t1212505713 ** get_address_of_entityDecls_8() { return &___entityDecls_8; }
	inline void set_entityDecls_8(DTDEntityDeclarationCollection_t1212505713 * value)
	{
		___entityDecls_8 = value;
		Il2CppCodeGenWriteBarrier(&___entityDecls_8, value);
	}

	inline static int32_t get_offset_of_notationDecls_9() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___notationDecls_9)); }
	inline DTDNotationDeclarationCollection_t228085060 * get_notationDecls_9() const { return ___notationDecls_9; }
	inline DTDNotationDeclarationCollection_t228085060 ** get_address_of_notationDecls_9() { return &___notationDecls_9; }
	inline void set_notationDecls_9(DTDNotationDeclarationCollection_t228085060 * value)
	{
		___notationDecls_9 = value;
		Il2CppCodeGenWriteBarrier(&___notationDecls_9, value);
	}

	inline static int32_t get_offset_of_validationErrors_10() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___validationErrors_10)); }
	inline ArrayList_t4252133567 * get_validationErrors_10() const { return ___validationErrors_10; }
	inline ArrayList_t4252133567 ** get_address_of_validationErrors_10() { return &___validationErrors_10; }
	inline void set_validationErrors_10(ArrayList_t4252133567 * value)
	{
		___validationErrors_10 = value;
		Il2CppCodeGenWriteBarrier(&___validationErrors_10, value);
	}

	inline static int32_t get_offset_of_resolver_11() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___resolver_11)); }
	inline XmlResolver_t2024571559 * get_resolver_11() const { return ___resolver_11; }
	inline XmlResolver_t2024571559 ** get_address_of_resolver_11() { return &___resolver_11; }
	inline void set_resolver_11(XmlResolver_t2024571559 * value)
	{
		___resolver_11 = value;
		Il2CppCodeGenWriteBarrier(&___resolver_11, value);
	}

	inline static int32_t get_offset_of_nameTable_12() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___nameTable_12)); }
	inline XmlNameTable_t1345805268 * get_nameTable_12() const { return ___nameTable_12; }
	inline XmlNameTable_t1345805268 ** get_address_of_nameTable_12() { return &___nameTable_12; }
	inline void set_nameTable_12(XmlNameTable_t1345805268 * value)
	{
		___nameTable_12 = value;
		Il2CppCodeGenWriteBarrier(&___nameTable_12, value);
	}

	inline static int32_t get_offset_of_externalResources_13() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___externalResources_13)); }
	inline Hashtable_t909839986 * get_externalResources_13() const { return ___externalResources_13; }
	inline Hashtable_t909839986 ** get_address_of_externalResources_13() { return &___externalResources_13; }
	inline void set_externalResources_13(Hashtable_t909839986 * value)
	{
		___externalResources_13 = value;
		Il2CppCodeGenWriteBarrier(&___externalResources_13, value);
	}

	inline static int32_t get_offset_of_baseURI_14() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___baseURI_14)); }
	inline String_t* get_baseURI_14() const { return ___baseURI_14; }
	inline String_t** get_address_of_baseURI_14() { return &___baseURI_14; }
	inline void set_baseURI_14(String_t* value)
	{
		___baseURI_14 = value;
		Il2CppCodeGenWriteBarrier(&___baseURI_14, value);
	}

	inline static int32_t get_offset_of_name_15() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___name_15)); }
	inline String_t* get_name_15() const { return ___name_15; }
	inline String_t** get_address_of_name_15() { return &___name_15; }
	inline void set_name_15(String_t* value)
	{
		___name_15 = value;
		Il2CppCodeGenWriteBarrier(&___name_15, value);
	}

	inline static int32_t get_offset_of_publicId_16() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___publicId_16)); }
	inline String_t* get_publicId_16() const { return ___publicId_16; }
	inline String_t** get_address_of_publicId_16() { return &___publicId_16; }
	inline void set_publicId_16(String_t* value)
	{
		___publicId_16 = value;
		Il2CppCodeGenWriteBarrier(&___publicId_16, value);
	}

	inline static int32_t get_offset_of_systemId_17() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___systemId_17)); }
	inline String_t* get_systemId_17() const { return ___systemId_17; }
	inline String_t** get_address_of_systemId_17() { return &___systemId_17; }
	inline void set_systemId_17(String_t* value)
	{
		___systemId_17 = value;
		Il2CppCodeGenWriteBarrier(&___systemId_17, value);
	}

	inline static int32_t get_offset_of_intSubset_18() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___intSubset_18)); }
	inline String_t* get_intSubset_18() const { return ___intSubset_18; }
	inline String_t** get_address_of_intSubset_18() { return &___intSubset_18; }
	inline void set_intSubset_18(String_t* value)
	{
		___intSubset_18 = value;
		Il2CppCodeGenWriteBarrier(&___intSubset_18, value);
	}

	inline static int32_t get_offset_of_intSubsetHasPERef_19() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___intSubsetHasPERef_19)); }
	inline bool get_intSubsetHasPERef_19() const { return ___intSubsetHasPERef_19; }
	inline bool* get_address_of_intSubsetHasPERef_19() { return &___intSubsetHasPERef_19; }
	inline void set_intSubsetHasPERef_19(bool value)
	{
		___intSubsetHasPERef_19 = value;
	}

	inline static int32_t get_offset_of_isStandalone_20() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___isStandalone_20)); }
	inline bool get_isStandalone_20() const { return ___isStandalone_20; }
	inline bool* get_address_of_isStandalone_20() { return &___isStandalone_20; }
	inline void set_isStandalone_20(bool value)
	{
		___isStandalone_20 = value;
	}

	inline static int32_t get_offset_of_lineNumber_21() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___lineNumber_21)); }
	inline int32_t get_lineNumber_21() const { return ___lineNumber_21; }
	inline int32_t* get_address_of_lineNumber_21() { return &___lineNumber_21; }
	inline void set_lineNumber_21(int32_t value)
	{
		___lineNumber_21 = value;
	}

	inline static int32_t get_offset_of_linePosition_22() { return static_cast<int32_t>(offsetof(DTDObjectModel_t1113953282, ___linePosition_22)); }
	inline int32_t get_linePosition_22() const { return ___linePosition_22; }
	inline int32_t* get_address_of_linePosition_22() { return &___linePosition_22; }
	inline void set_linePosition_22(int32_t value)
	{
		___linePosition_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
