#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_Text356221433.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// System.Collections.Generic.List`1<UnityEngine.UI.Image>
struct List_1_t1411648341;
// System.Collections.Generic.List`1<UnityEngine.GameObject>
struct List_1_t1125654279;
// UnityEngine.Object
struct Object_t1021602117;
// System.Collections.Generic.List`1<System.Int32>
struct List_1_t1440998580;
// System.Text.RegularExpressions.Regex
struct Regex_t1803876613;
// System.String
struct String_t;
// UnityEngine.UI.Extensions.TextPic/IconName[]
struct IconNameU5BU5D_t3827230366;
// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.Sprite>
struct Dictionary_2_t2224373045;
// UnityEngine.UI.Button
struct Button_t2872111280;
// System.Collections.Generic.List`1<UnityEngine.Vector2>
struct List_1_t1612828711;
// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.TextPic/HrefInfo>
struct List_1_t1717420812;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;
// UnityEngine.UI.Extensions.TextPic/HrefClickEvent
struct HrefClickEvent_t1044804460;
// System.Predicate`1<UnityEngine.UI.Image>
struct Predicate_1_t485497324;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.TextPic
struct  TextPic_t1856600851  : public Text_t356221433
{
public:
	// System.Collections.Generic.List`1<UnityEngine.UI.Image> UnityEngine.UI.Extensions.TextPic::m_ImagesPool
	List_1_t1411648341 * ___m_ImagesPool_35;
	// System.Collections.Generic.List`1<UnityEngine.GameObject> UnityEngine.UI.Extensions.TextPic::culled_ImagesPool
	List_1_t1125654279 * ___culled_ImagesPool_36;
	// System.Boolean UnityEngine.UI.Extensions.TextPic::clearImages
	bool ___clearImages_37;
	// UnityEngine.Object UnityEngine.UI.Extensions.TextPic::thisLock
	Object_t1021602117 * ___thisLock_38;
	// System.Collections.Generic.List`1<System.Int32> UnityEngine.UI.Extensions.TextPic::m_ImagesVertexIndex
	List_1_t1440998580 * ___m_ImagesVertexIndex_39;
	// System.String UnityEngine.UI.Extensions.TextPic::fixedString
	String_t* ___fixedString_41;
	// System.String UnityEngine.UI.Extensions.TextPic::m_OutputText
	String_t* ___m_OutputText_42;
	// UnityEngine.UI.Extensions.TextPic/IconName[] UnityEngine.UI.Extensions.TextPic::inspectorIconList
	IconNameU5BU5D_t3827230366* ___inspectorIconList_43;
	// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.Sprite> UnityEngine.UI.Extensions.TextPic::iconList
	Dictionary_2_t2224373045 * ___iconList_44;
	// System.Single UnityEngine.UI.Extensions.TextPic::ImageScalingFactor
	float ___ImageScalingFactor_45;
	// System.String UnityEngine.UI.Extensions.TextPic::hyperlinkColor
	String_t* ___hyperlinkColor_46;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.TextPic::imageOffset
	Vector2_t2243707579  ___imageOffset_47;
	// UnityEngine.UI.Button UnityEngine.UI.Extensions.TextPic::button
	Button_t2872111280 * ___button_48;
	// System.Collections.Generic.List`1<UnityEngine.Vector2> UnityEngine.UI.Extensions.TextPic::positions
	List_1_t1612828711 * ___positions_49;
	// System.String UnityEngine.UI.Extensions.TextPic::previousText
	String_t* ___previousText_50;
	// System.Boolean UnityEngine.UI.Extensions.TextPic::isCreating_m_HrefInfos
	bool ___isCreating_m_HrefInfos_51;
	// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.TextPic/HrefInfo> UnityEngine.UI.Extensions.TextPic::m_HrefInfos
	List_1_t1717420812 * ___m_HrefInfos_52;
	// UnityEngine.UI.Extensions.TextPic/HrefClickEvent UnityEngine.UI.Extensions.TextPic::m_OnHrefClick
	HrefClickEvent_t1044804460 * ___m_OnHrefClick_55;

public:
	inline static int32_t get_offset_of_m_ImagesPool_35() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___m_ImagesPool_35)); }
	inline List_1_t1411648341 * get_m_ImagesPool_35() const { return ___m_ImagesPool_35; }
	inline List_1_t1411648341 ** get_address_of_m_ImagesPool_35() { return &___m_ImagesPool_35; }
	inline void set_m_ImagesPool_35(List_1_t1411648341 * value)
	{
		___m_ImagesPool_35 = value;
		Il2CppCodeGenWriteBarrier(&___m_ImagesPool_35, value);
	}

	inline static int32_t get_offset_of_culled_ImagesPool_36() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___culled_ImagesPool_36)); }
	inline List_1_t1125654279 * get_culled_ImagesPool_36() const { return ___culled_ImagesPool_36; }
	inline List_1_t1125654279 ** get_address_of_culled_ImagesPool_36() { return &___culled_ImagesPool_36; }
	inline void set_culled_ImagesPool_36(List_1_t1125654279 * value)
	{
		___culled_ImagesPool_36 = value;
		Il2CppCodeGenWriteBarrier(&___culled_ImagesPool_36, value);
	}

	inline static int32_t get_offset_of_clearImages_37() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___clearImages_37)); }
	inline bool get_clearImages_37() const { return ___clearImages_37; }
	inline bool* get_address_of_clearImages_37() { return &___clearImages_37; }
	inline void set_clearImages_37(bool value)
	{
		___clearImages_37 = value;
	}

	inline static int32_t get_offset_of_thisLock_38() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___thisLock_38)); }
	inline Object_t1021602117 * get_thisLock_38() const { return ___thisLock_38; }
	inline Object_t1021602117 ** get_address_of_thisLock_38() { return &___thisLock_38; }
	inline void set_thisLock_38(Object_t1021602117 * value)
	{
		___thisLock_38 = value;
		Il2CppCodeGenWriteBarrier(&___thisLock_38, value);
	}

	inline static int32_t get_offset_of_m_ImagesVertexIndex_39() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___m_ImagesVertexIndex_39)); }
	inline List_1_t1440998580 * get_m_ImagesVertexIndex_39() const { return ___m_ImagesVertexIndex_39; }
	inline List_1_t1440998580 ** get_address_of_m_ImagesVertexIndex_39() { return &___m_ImagesVertexIndex_39; }
	inline void set_m_ImagesVertexIndex_39(List_1_t1440998580 * value)
	{
		___m_ImagesVertexIndex_39 = value;
		Il2CppCodeGenWriteBarrier(&___m_ImagesVertexIndex_39, value);
	}

	inline static int32_t get_offset_of_fixedString_41() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___fixedString_41)); }
	inline String_t* get_fixedString_41() const { return ___fixedString_41; }
	inline String_t** get_address_of_fixedString_41() { return &___fixedString_41; }
	inline void set_fixedString_41(String_t* value)
	{
		___fixedString_41 = value;
		Il2CppCodeGenWriteBarrier(&___fixedString_41, value);
	}

	inline static int32_t get_offset_of_m_OutputText_42() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___m_OutputText_42)); }
	inline String_t* get_m_OutputText_42() const { return ___m_OutputText_42; }
	inline String_t** get_address_of_m_OutputText_42() { return &___m_OutputText_42; }
	inline void set_m_OutputText_42(String_t* value)
	{
		___m_OutputText_42 = value;
		Il2CppCodeGenWriteBarrier(&___m_OutputText_42, value);
	}

	inline static int32_t get_offset_of_inspectorIconList_43() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___inspectorIconList_43)); }
	inline IconNameU5BU5D_t3827230366* get_inspectorIconList_43() const { return ___inspectorIconList_43; }
	inline IconNameU5BU5D_t3827230366** get_address_of_inspectorIconList_43() { return &___inspectorIconList_43; }
	inline void set_inspectorIconList_43(IconNameU5BU5D_t3827230366* value)
	{
		___inspectorIconList_43 = value;
		Il2CppCodeGenWriteBarrier(&___inspectorIconList_43, value);
	}

	inline static int32_t get_offset_of_iconList_44() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___iconList_44)); }
	inline Dictionary_2_t2224373045 * get_iconList_44() const { return ___iconList_44; }
	inline Dictionary_2_t2224373045 ** get_address_of_iconList_44() { return &___iconList_44; }
	inline void set_iconList_44(Dictionary_2_t2224373045 * value)
	{
		___iconList_44 = value;
		Il2CppCodeGenWriteBarrier(&___iconList_44, value);
	}

	inline static int32_t get_offset_of_ImageScalingFactor_45() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___ImageScalingFactor_45)); }
	inline float get_ImageScalingFactor_45() const { return ___ImageScalingFactor_45; }
	inline float* get_address_of_ImageScalingFactor_45() { return &___ImageScalingFactor_45; }
	inline void set_ImageScalingFactor_45(float value)
	{
		___ImageScalingFactor_45 = value;
	}

	inline static int32_t get_offset_of_hyperlinkColor_46() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___hyperlinkColor_46)); }
	inline String_t* get_hyperlinkColor_46() const { return ___hyperlinkColor_46; }
	inline String_t** get_address_of_hyperlinkColor_46() { return &___hyperlinkColor_46; }
	inline void set_hyperlinkColor_46(String_t* value)
	{
		___hyperlinkColor_46 = value;
		Il2CppCodeGenWriteBarrier(&___hyperlinkColor_46, value);
	}

	inline static int32_t get_offset_of_imageOffset_47() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___imageOffset_47)); }
	inline Vector2_t2243707579  get_imageOffset_47() const { return ___imageOffset_47; }
	inline Vector2_t2243707579 * get_address_of_imageOffset_47() { return &___imageOffset_47; }
	inline void set_imageOffset_47(Vector2_t2243707579  value)
	{
		___imageOffset_47 = value;
	}

	inline static int32_t get_offset_of_button_48() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___button_48)); }
	inline Button_t2872111280 * get_button_48() const { return ___button_48; }
	inline Button_t2872111280 ** get_address_of_button_48() { return &___button_48; }
	inline void set_button_48(Button_t2872111280 * value)
	{
		___button_48 = value;
		Il2CppCodeGenWriteBarrier(&___button_48, value);
	}

	inline static int32_t get_offset_of_positions_49() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___positions_49)); }
	inline List_1_t1612828711 * get_positions_49() const { return ___positions_49; }
	inline List_1_t1612828711 ** get_address_of_positions_49() { return &___positions_49; }
	inline void set_positions_49(List_1_t1612828711 * value)
	{
		___positions_49 = value;
		Il2CppCodeGenWriteBarrier(&___positions_49, value);
	}

	inline static int32_t get_offset_of_previousText_50() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___previousText_50)); }
	inline String_t* get_previousText_50() const { return ___previousText_50; }
	inline String_t** get_address_of_previousText_50() { return &___previousText_50; }
	inline void set_previousText_50(String_t* value)
	{
		___previousText_50 = value;
		Il2CppCodeGenWriteBarrier(&___previousText_50, value);
	}

	inline static int32_t get_offset_of_isCreating_m_HrefInfos_51() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___isCreating_m_HrefInfos_51)); }
	inline bool get_isCreating_m_HrefInfos_51() const { return ___isCreating_m_HrefInfos_51; }
	inline bool* get_address_of_isCreating_m_HrefInfos_51() { return &___isCreating_m_HrefInfos_51; }
	inline void set_isCreating_m_HrefInfos_51(bool value)
	{
		___isCreating_m_HrefInfos_51 = value;
	}

	inline static int32_t get_offset_of_m_HrefInfos_52() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___m_HrefInfos_52)); }
	inline List_1_t1717420812 * get_m_HrefInfos_52() const { return ___m_HrefInfos_52; }
	inline List_1_t1717420812 ** get_address_of_m_HrefInfos_52() { return &___m_HrefInfos_52; }
	inline void set_m_HrefInfos_52(List_1_t1717420812 * value)
	{
		___m_HrefInfos_52 = value;
		Il2CppCodeGenWriteBarrier(&___m_HrefInfos_52, value);
	}

	inline static int32_t get_offset_of_m_OnHrefClick_55() { return static_cast<int32_t>(offsetof(TextPic_t1856600851, ___m_OnHrefClick_55)); }
	inline HrefClickEvent_t1044804460 * get_m_OnHrefClick_55() const { return ___m_OnHrefClick_55; }
	inline HrefClickEvent_t1044804460 ** get_address_of_m_OnHrefClick_55() { return &___m_OnHrefClick_55; }
	inline void set_m_OnHrefClick_55(HrefClickEvent_t1044804460 * value)
	{
		___m_OnHrefClick_55 = value;
		Il2CppCodeGenWriteBarrier(&___m_OnHrefClick_55, value);
	}
};

struct TextPic_t1856600851_StaticFields
{
public:
	// System.Text.RegularExpressions.Regex UnityEngine.UI.Extensions.TextPic::s_Regex
	Regex_t1803876613 * ___s_Regex_40;
	// System.Text.StringBuilder UnityEngine.UI.Extensions.TextPic::s_TextBuilder
	StringBuilder_t1221177846 * ___s_TextBuilder_53;
	// System.Text.RegularExpressions.Regex UnityEngine.UI.Extensions.TextPic::s_HrefRegex
	Regex_t1803876613 * ___s_HrefRegex_54;
	// System.Predicate`1<UnityEngine.UI.Image> UnityEngine.UI.Extensions.TextPic::<>f__am$cache0
	Predicate_1_t485497324 * ___U3CU3Ef__amU24cache0_56;

public:
	inline static int32_t get_offset_of_s_Regex_40() { return static_cast<int32_t>(offsetof(TextPic_t1856600851_StaticFields, ___s_Regex_40)); }
	inline Regex_t1803876613 * get_s_Regex_40() const { return ___s_Regex_40; }
	inline Regex_t1803876613 ** get_address_of_s_Regex_40() { return &___s_Regex_40; }
	inline void set_s_Regex_40(Regex_t1803876613 * value)
	{
		___s_Regex_40 = value;
		Il2CppCodeGenWriteBarrier(&___s_Regex_40, value);
	}

	inline static int32_t get_offset_of_s_TextBuilder_53() { return static_cast<int32_t>(offsetof(TextPic_t1856600851_StaticFields, ___s_TextBuilder_53)); }
	inline StringBuilder_t1221177846 * get_s_TextBuilder_53() const { return ___s_TextBuilder_53; }
	inline StringBuilder_t1221177846 ** get_address_of_s_TextBuilder_53() { return &___s_TextBuilder_53; }
	inline void set_s_TextBuilder_53(StringBuilder_t1221177846 * value)
	{
		___s_TextBuilder_53 = value;
		Il2CppCodeGenWriteBarrier(&___s_TextBuilder_53, value);
	}

	inline static int32_t get_offset_of_s_HrefRegex_54() { return static_cast<int32_t>(offsetof(TextPic_t1856600851_StaticFields, ___s_HrefRegex_54)); }
	inline Regex_t1803876613 * get_s_HrefRegex_54() const { return ___s_HrefRegex_54; }
	inline Regex_t1803876613 ** get_address_of_s_HrefRegex_54() { return &___s_HrefRegex_54; }
	inline void set_s_HrefRegex_54(Regex_t1803876613 * value)
	{
		___s_HrefRegex_54 = value;
		Il2CppCodeGenWriteBarrier(&___s_HrefRegex_54, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_56() { return static_cast<int32_t>(offsetof(TextPic_t1856600851_StaticFields, ___U3CU3Ef__amU24cache0_56)); }
	inline Predicate_1_t485497324 * get_U3CU3Ef__amU24cache0_56() const { return ___U3CU3Ef__amU24cache0_56; }
	inline Predicate_1_t485497324 ** get_address_of_U3CU3Ef__amU24cache0_56() { return &___U3CU3Ef__amU24cache0_56; }
	inline void set_U3CU3Ef__amU24cache0_56(Predicate_1_t485497324 * value)
	{
		___U3CU3Ef__amU24cache0_56 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_56, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
