#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Extensions.ReorderableList
struct ReorderableList_t970849249;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct
struct  ReorderableListEventStruct_t1615631671 
{
public:
	// UnityEngine.GameObject UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct::DroppedObject
	GameObject_t1756533147 * ___DroppedObject_0;
	// System.Int32 UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct::FromIndex
	int32_t ___FromIndex_1;
	// UnityEngine.UI.Extensions.ReorderableList UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct::FromList
	ReorderableList_t970849249 * ___FromList_2;
	// System.Boolean UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct::IsAClone
	bool ___IsAClone_3;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct::SourceObject
	GameObject_t1756533147 * ___SourceObject_4;
	// System.Int32 UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct::ToIndex
	int32_t ___ToIndex_5;
	// UnityEngine.UI.Extensions.ReorderableList UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct::ToList
	ReorderableList_t970849249 * ___ToList_6;

public:
	inline static int32_t get_offset_of_DroppedObject_0() { return static_cast<int32_t>(offsetof(ReorderableListEventStruct_t1615631671, ___DroppedObject_0)); }
	inline GameObject_t1756533147 * get_DroppedObject_0() const { return ___DroppedObject_0; }
	inline GameObject_t1756533147 ** get_address_of_DroppedObject_0() { return &___DroppedObject_0; }
	inline void set_DroppedObject_0(GameObject_t1756533147 * value)
	{
		___DroppedObject_0 = value;
		Il2CppCodeGenWriteBarrier(&___DroppedObject_0, value);
	}

	inline static int32_t get_offset_of_FromIndex_1() { return static_cast<int32_t>(offsetof(ReorderableListEventStruct_t1615631671, ___FromIndex_1)); }
	inline int32_t get_FromIndex_1() const { return ___FromIndex_1; }
	inline int32_t* get_address_of_FromIndex_1() { return &___FromIndex_1; }
	inline void set_FromIndex_1(int32_t value)
	{
		___FromIndex_1 = value;
	}

	inline static int32_t get_offset_of_FromList_2() { return static_cast<int32_t>(offsetof(ReorderableListEventStruct_t1615631671, ___FromList_2)); }
	inline ReorderableList_t970849249 * get_FromList_2() const { return ___FromList_2; }
	inline ReorderableList_t970849249 ** get_address_of_FromList_2() { return &___FromList_2; }
	inline void set_FromList_2(ReorderableList_t970849249 * value)
	{
		___FromList_2 = value;
		Il2CppCodeGenWriteBarrier(&___FromList_2, value);
	}

	inline static int32_t get_offset_of_IsAClone_3() { return static_cast<int32_t>(offsetof(ReorderableListEventStruct_t1615631671, ___IsAClone_3)); }
	inline bool get_IsAClone_3() const { return ___IsAClone_3; }
	inline bool* get_address_of_IsAClone_3() { return &___IsAClone_3; }
	inline void set_IsAClone_3(bool value)
	{
		___IsAClone_3 = value;
	}

	inline static int32_t get_offset_of_SourceObject_4() { return static_cast<int32_t>(offsetof(ReorderableListEventStruct_t1615631671, ___SourceObject_4)); }
	inline GameObject_t1756533147 * get_SourceObject_4() const { return ___SourceObject_4; }
	inline GameObject_t1756533147 ** get_address_of_SourceObject_4() { return &___SourceObject_4; }
	inline void set_SourceObject_4(GameObject_t1756533147 * value)
	{
		___SourceObject_4 = value;
		Il2CppCodeGenWriteBarrier(&___SourceObject_4, value);
	}

	inline static int32_t get_offset_of_ToIndex_5() { return static_cast<int32_t>(offsetof(ReorderableListEventStruct_t1615631671, ___ToIndex_5)); }
	inline int32_t get_ToIndex_5() const { return ___ToIndex_5; }
	inline int32_t* get_address_of_ToIndex_5() { return &___ToIndex_5; }
	inline void set_ToIndex_5(int32_t value)
	{
		___ToIndex_5 = value;
	}

	inline static int32_t get_offset_of_ToList_6() { return static_cast<int32_t>(offsetof(ReorderableListEventStruct_t1615631671, ___ToList_6)); }
	inline ReorderableList_t970849249 * get_ToList_6() const { return ___ToList_6; }
	inline ReorderableList_t970849249 ** get_address_of_ToList_6() { return &___ToList_6; }
	inline void set_ToList_6(ReorderableList_t970849249 * value)
	{
		___ToList_6 = value;
		Il2CppCodeGenWriteBarrier(&___ToList_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct
struct ReorderableListEventStruct_t1615631671_marshaled_pinvoke
{
	GameObject_t1756533147 * ___DroppedObject_0;
	int32_t ___FromIndex_1;
	ReorderableList_t970849249 * ___FromList_2;
	int32_t ___IsAClone_3;
	GameObject_t1756533147 * ___SourceObject_4;
	int32_t ___ToIndex_5;
	ReorderableList_t970849249 * ___ToList_6;
};
// Native definition for COM marshalling of UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct
struct ReorderableListEventStruct_t1615631671_marshaled_com
{
	GameObject_t1756533147 * ___DroppedObject_0;
	int32_t ___FromIndex_1;
	ReorderableList_t970849249 * ___FromList_2;
	int32_t ___IsAClone_3;
	GameObject_t1756533147 * ___SourceObject_4;
	int32_t ___ToIndex_5;
	ReorderableList_t970849249 * ___ToList_6;
};
