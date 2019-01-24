#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Xml_System_Xml_ConformanceLevel3761201363.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaValidationFla910489930.h"

// System.Xml.Schema.XmlSchemaSet
struct XmlSchemaSet_t313318308;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlReaderSettings
struct  XmlReaderSettings_t1578612233  : public Il2CppObject
{
public:
	// System.Boolean System.Xml.XmlReaderSettings::checkCharacters
	bool ___checkCharacters_0;
	// System.Xml.ConformanceLevel System.Xml.XmlReaderSettings::conformance
	int32_t ___conformance_1;
	// System.Xml.Schema.XmlSchemaSet System.Xml.XmlReaderSettings::schemas
	XmlSchemaSet_t313318308 * ___schemas_2;
	// System.Boolean System.Xml.XmlReaderSettings::schemasNeedsInitialization
	bool ___schemasNeedsInitialization_3;
	// System.Xml.Schema.XmlSchemaValidationFlags System.Xml.XmlReaderSettings::validationFlags
	int32_t ___validationFlags_4;

public:
	inline static int32_t get_offset_of_checkCharacters_0() { return static_cast<int32_t>(offsetof(XmlReaderSettings_t1578612233, ___checkCharacters_0)); }
	inline bool get_checkCharacters_0() const { return ___checkCharacters_0; }
	inline bool* get_address_of_checkCharacters_0() { return &___checkCharacters_0; }
	inline void set_checkCharacters_0(bool value)
	{
		___checkCharacters_0 = value;
	}

	inline static int32_t get_offset_of_conformance_1() { return static_cast<int32_t>(offsetof(XmlReaderSettings_t1578612233, ___conformance_1)); }
	inline int32_t get_conformance_1() const { return ___conformance_1; }
	inline int32_t* get_address_of_conformance_1() { return &___conformance_1; }
	inline void set_conformance_1(int32_t value)
	{
		___conformance_1 = value;
	}

	inline static int32_t get_offset_of_schemas_2() { return static_cast<int32_t>(offsetof(XmlReaderSettings_t1578612233, ___schemas_2)); }
	inline XmlSchemaSet_t313318308 * get_schemas_2() const { return ___schemas_2; }
	inline XmlSchemaSet_t313318308 ** get_address_of_schemas_2() { return &___schemas_2; }
	inline void set_schemas_2(XmlSchemaSet_t313318308 * value)
	{
		___schemas_2 = value;
		Il2CppCodeGenWriteBarrier(&___schemas_2, value);
	}

	inline static int32_t get_offset_of_schemasNeedsInitialization_3() { return static_cast<int32_t>(offsetof(XmlReaderSettings_t1578612233, ___schemasNeedsInitialization_3)); }
	inline bool get_schemasNeedsInitialization_3() const { return ___schemasNeedsInitialization_3; }
	inline bool* get_address_of_schemasNeedsInitialization_3() { return &___schemasNeedsInitialization_3; }
	inline void set_schemasNeedsInitialization_3(bool value)
	{
		___schemasNeedsInitialization_3 = value;
	}

	inline static int32_t get_offset_of_validationFlags_4() { return static_cast<int32_t>(offsetof(XmlReaderSettings_t1578612233, ___validationFlags_4)); }
	inline int32_t get_validationFlags_4() const { return ___validationFlags_4; }
	inline int32_t* get_address_of_validationFlags_4() { return &___validationFlags_4; }
	inline void set_validationFlags_4(int32_t value)
	{
		___validationFlags_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
