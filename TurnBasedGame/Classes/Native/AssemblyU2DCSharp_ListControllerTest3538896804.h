#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// AddComponent.List
struct List_t1060718126;
// AddComponent.ListItemBase
struct ListItemBase_t563494060;
// ListItemCountry
struct ListItemCountry_t4253324273;
// System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.String,Country>>
struct List_1_t480772998;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ListControllerTest
struct  ListControllerTest_t3538896804  : public MonoBehaviour_t1158329972
{
public:
	// AddComponent.List ListControllerTest::_list
	List_t1060718126 * ____list_2;
	// AddComponent.ListItemBase ListControllerTest::_listItem
	ListItemBase_t563494060 * ____listItem_3;
	// System.Int32 ListControllerTest::_selectedIndex
	int32_t ____selectedIndex_4;
	// ListItemCountry ListControllerTest::_selectedItem
	ListItemCountry_t4253324273 * ____selectedItem_5;
	// System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.String,Country>> ListControllerTest::_countries
	List_1_t480772998 * ____countries_6;

public:
	inline static int32_t get_offset_of__list_2() { return static_cast<int32_t>(offsetof(ListControllerTest_t3538896804, ____list_2)); }
	inline List_t1060718126 * get__list_2() const { return ____list_2; }
	inline List_t1060718126 ** get_address_of__list_2() { return &____list_2; }
	inline void set__list_2(List_t1060718126 * value)
	{
		____list_2 = value;
		Il2CppCodeGenWriteBarrier(&____list_2, value);
	}

	inline static int32_t get_offset_of__listItem_3() { return static_cast<int32_t>(offsetof(ListControllerTest_t3538896804, ____listItem_3)); }
	inline ListItemBase_t563494060 * get__listItem_3() const { return ____listItem_3; }
	inline ListItemBase_t563494060 ** get_address_of__listItem_3() { return &____listItem_3; }
	inline void set__listItem_3(ListItemBase_t563494060 * value)
	{
		____listItem_3 = value;
		Il2CppCodeGenWriteBarrier(&____listItem_3, value);
	}

	inline static int32_t get_offset_of__selectedIndex_4() { return static_cast<int32_t>(offsetof(ListControllerTest_t3538896804, ____selectedIndex_4)); }
	inline int32_t get__selectedIndex_4() const { return ____selectedIndex_4; }
	inline int32_t* get_address_of__selectedIndex_4() { return &____selectedIndex_4; }
	inline void set__selectedIndex_4(int32_t value)
	{
		____selectedIndex_4 = value;
	}

	inline static int32_t get_offset_of__selectedItem_5() { return static_cast<int32_t>(offsetof(ListControllerTest_t3538896804, ____selectedItem_5)); }
	inline ListItemCountry_t4253324273 * get__selectedItem_5() const { return ____selectedItem_5; }
	inline ListItemCountry_t4253324273 ** get_address_of__selectedItem_5() { return &____selectedItem_5; }
	inline void set__selectedItem_5(ListItemCountry_t4253324273 * value)
	{
		____selectedItem_5 = value;
		Il2CppCodeGenWriteBarrier(&____selectedItem_5, value);
	}

	inline static int32_t get_offset_of__countries_6() { return static_cast<int32_t>(offsetof(ListControllerTest_t3538896804, ____countries_6)); }
	inline List_1_t480772998 * get__countries_6() const { return ____countries_6; }
	inline List_1_t480772998 ** get_address_of__countries_6() { return &____countries_6; }
	inline void set__countries_6(List_1_t480772998 * value)
	{
		____countries_6 = value;
		Il2CppCodeGenWriteBarrier(&____countries_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
