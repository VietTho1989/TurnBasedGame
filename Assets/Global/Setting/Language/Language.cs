using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : Data
{

	public enum Type
	{
		af,
		af_rNA,
		af_rZA,
		agq,
		agq_rCM,
		ak,
		ak_rGH,
		am,
		am_rET,
		ar,
		ar_r001,
		ar_rAE,
		ar_rBH,
		ar_rDJ,
		ar_rDZ,
		ar_rEG,
		ar_rEH,
		ar_rER,
		ar_rIL,
		ar_rIQ,
		ar_rJO,
		ar_rKM,
		ar_rKW,
		ar_rLB,
		ar_rLY,
		ar_rMA,
		ar_rMR,
		ar_rOM,
		ar_rPS,
		ar_rQA,
		ar_rSA,
		ar_rSD,
		ar_rSO,
		ar_rSS,
		ar_rSY,
		ar_rTD,
		ar_rTN,
		ar_rYE,
		/** as*/
		as_,
		as_rIN,
		asa,
		asa_rTZ,
		az,
		az_r__Cyrl,
		az_rAZ__Cyrl,
		az_r__Latn,
		az_rAZ__Latn,
		bas,
		bas_rCM,
		be,
		be_rBY,
		bem,
		bem_rZM,
		bez,
		bez_rTZ,
		bg,
		bg_rBG,
		bm,
		bm_rML,
		bn,
		bn_rBD,
		bn_rIN,
		bo,
		bo_rCN,
		bo_rIN,
		br,
		br_rFR,
		brx,
		brx_rIN,
		bs,
		bs_r__Cyrl,
		bs_rBA__Cyrl,
		bs_r__Latn,
		bs_rBA__Latn,
		ca,
		ca_rAD,
		ca_rES,
		ca_rFR,
		ca_rIT,
		cgg,
		cgg_rUG,
		chr,
		chr_rUS,
		cs,
		cs_rCZ,
		cy,
		cy_rGB,
		da,
		da_rDK,
		da_rGL,
		dav,
		dav_rKE,
		de,
		de_rAT,
		de_rBE,
		de_rCH,
		de_rDE,
		de_rLI,
		de_rLU,
		dje,
		dje_rNE,
		dua,
		dua_rCM,
		dyo,
		dyo_rSN,
		dz,
		dz_rBT,
		ebu,
		ebu_rKE,
		ee,
		ee_rGH,
		ee_rTG,
		el,
		el_rCY,
		el_rGR,
		en,
		en_r001,
		en_r150,
		en_rAG,
		en_rAI,
		en_rAS,
		en_rAU,
		en_rBB,
		en_rBE,
		en_rBM,
		en_rBS,
		en_rBW,
		en_rBZ,
		en_rCA,
		en_rCC,
		en_rCK,
		en_rCM,
		en_rCX,
		en_rDG,
		en_rDM,
		en_rER,
		en_rFJ,
		en_rFK,
		en_rFM,
		en_rGB,
		en_rGD,
		en_rGG,
		en_rGH,
		en_rGI,
		en_rGM,
		en_rGU,
		en_rGY,
		en_rHK,
		en_rIE,
		en_rIM,
		en_rIN,
		en_rIO,
		en_rJE,
		en_rJM,
		en_rKE,
		en_rKI,
		en_rKN,
		en_rKY,
		en_rLC,
		en_rLR,
		en_rLS,
		en_rMG,
		en_rMH,
		en_rMO,
		en_rMP,
		en_rMS,
		en_rMT,
		en_rMU,
		en_rMW,
		en_rNA,
		en_rNF,
		en_rNG,
		en_rNR,
		en_rNU,
		en_rNZ,
		en_rPG,
		en_rPH,
		en_rPK,
		en_rPN,
		en_rPR,
		en_rPW,
		en_rRW,
		en_rSB,
		en_rSC,
		en_rSD,
		en_rSG,
		en_rSH,
		en_rSL,
		en_rSS,
		en_rSX,
		en_rSZ,
		en_rTC,
		en_rTK,
		en_rTO,
		en_rTT,
		en_rTV,
		en_rTZ,
		en_rUG,
		en_rUM,
		en_rUS,
		en_rUS_POSIX,
		en_rVC,
		en_rVG,
		en_rVI,
		en_rVU,
		en_rWS,
		en_rZA,
		en_rZM,
		en_rZW,
		eo,
		es,
		es_r419,
		es_rAR,
		es_rBO,
		es_rCL,
		es_rCO,
		es_rCR,
		es_rCU,
		es_rDO,
		es_rEA,
		es_rEC,
		es_rES,
		es_rGQ,
		es_rGT,
		es_rHN,
		es_rIC,
		es_rMX,
		es_rNI,
		es_rPA,
		es_rPE,
		es_rPH,
		es_rPR,
		es_rPY,
		es_rSV,
		es_rUS,
		es_rUY,
		es_rVE,
		et,
		et_rEE,
		eu,
		eu_rES,
		ewo,
		ewo_rCM,
		fa,
		fa_rAF,
		fa_rIR,
		ff,
		ff_rSN,
		fi,
		fi_rFI,
		fil,
		fil_rPH,
		fo,
		fo_rFO,
		fr,
		fr_rBE,
		fr_rBF,
		fr_rBI,
		fr_rBJ,
		fr_rBL,
		fr_rCA,
		fr_rCD,
		fr_rCF,
		fr_rCG,
		fr_rCH,
		fr_rCI,
		fr_rCM,
		fr_rDJ,
		fr_rDZ,
		fr_rFR,
		fr_rGA,
		fr_rGF,
		fr_rGN,
		fr_rGP,
		fr_rGQ,
		fr_rHT,
		fr_rKM,
		fr_rLU,
		fr_rMA,
		fr_rMC,
		fr_rMF,
		fr_rMG,
		fr_rML,
		fr_rMQ,
		fr_rMR,
		fr_rMU,
		fr_rNC,
		fr_rNE,
		fr_rPF,
		fr_rPM,
		fr_rRE,
		fr_rRW,
		fr_rSC,
		fr_rSN,
		fr_rSY,
		fr_rTD,
		fr_rTG,
		fr_rTN,
		fr_rVU,
		fr_rWF,
		fr_rYT,
		ga,
		ga_rIE,
		gl,
		gl_rES,
		gsw,
		gsw_rCH,
		gsw_rLI,
		gu,
		gu_rIN,
		guz,
		guz_rKE,
		gv,
		gv_rIM,
		ha,
		ha_r__Latn,
		ha_rGH__Latn,
		ha_rNE__Latn,
		ha_rNG__Latn,
		haw,
		haw_rUS,
		iw,
		iw_rIL,
		hi,
		hi_rIN,
		hr,
		hr_rBA,
		hr_rHR,
		hu,
		hu_rHU,
		hy,
		hy_rAM,
		/** in*/
		in_,
		in_rID,
		ig,
		ig_rNG,
		ii,
		ii_rCN,
		/** is*/
		is_,
		is_rIS,
		it,
		it_rCH,
		it_rIT,
		it_rSM,
		ja,
		ja_rJP,
		jgo,
		jgo_rCM,
		kk_rKZ__Cyrl,
		kkj,
		kkj_rCM,
		kl,
		kl_rGL,
		kln,
		kln_rKE,
		km,
		km_rKH,
		kn,
		kn_rIN,
		ko,
		ko_rKP,
		ko_rKR,
		kok,
		kok_rIN,
		ks,
		ks_r__Arab,
		ks_rIN__Arab,
		ksb,
		ksb_rTZ,
		ksf,
		ksf_rCM,
		kw,
		kw_rGB,
		ky,
		ky_r__Cyrl,
		ky_rKG__Cyrl,
		lag,
		lag_rTZ,
		lg,
		lg_rUG,
		lkt,
		lkt_rUS,
		ln,
		ln_rAO,
		ln_rCD,
		ln_rCF,
		ln_rCG,
		lo,
		lo_rLA,
		lt,
		lt_rLT,
		lu,
		lu_rCD,
		luo,
		luo_rKE,
		luy,
		luy_rKE,
		lv,
		lv_rLV,
		mas,
		mas_rKE,
		mas_rTZ,
		mer,
		mer_rKE,
		mfe,
		mfe_rMU,
		mg,
		mg_rMG,
		mgh,
		mgh_rMZ,
		mgo,
		mgo_rCM,
		mk,
		mk_rMK,
		ml,
		ml_rIN,
		mn,
		mn_r__Cyrl,
		mn_rMN__Cyrl,
		mr,
		mr_rIN,
		ms,
		ms_r__Latn,
		ms_rBN__Latn,
		ms_rMY__Latn,
		ms_rSG__Latn,
		mt,
		mt_rMT,
		mua,
		mua_rCM,
		my,
		my_rMM,
		naq,
		naq_rNA,
		nb,
		nb_rNO,
		nb_rSJ,
		nd,
		nd_rZW,
		ne,
		ne_rIN,
		ne_rNP,
		nl,
		nl_rAW,
		nl_rBE,
		nl_rBQ,
		nl_rCW,
		nl_rNL,
		nl_rSR,
		nl_rSX,
		nmg,
		nmg_rCM,
		nn,
		nn_rNO,
		nnh,
		nnh_rCM,
		nus,
		nus_rSD,
		nyn,
		nyn_rUG,
		om,
		om_rET,
		om_rKE,
		or,
		or_rIN,
		pa,
		pa_r__Arab,
		pa_rPK__Arab,
		pa_r__Guru,
		pa_rIN__Guru,
		pl,
		pl_rPL,
		ps,
		ps_rAF,
		pt,
		pt_rAO,
		pt_rBR,
		pt_rCV,
		pt_rGW,
		pt_rMO,
		pt_rMZ,
		pt_rPT,
		pt_rST,
		pt_rTL,
		rm,
		rm_rCH,
		rn,
		rn_rBI,
		ro,
		ro_rMD,
		ro_rRO,
		rof,
		rof_rTZ,
		ru,
		ru_rBY,
		ru_rKG,
		ru_rKZ,
		ru_rMD,
		ru_rRU,
		ru_rUA,
		rw,
		rw_rRW,
		rwk,
		rwk_rTZ,
		saq,
		saq_rKE,
		sbp,
		sbp_rTZ,
		seh,
		seh_rMZ,
		ses,
		ses_rML,
		sg,
		sg_rCF,
		shi,
		shi_r__Latn,
		shi_rMA__Latn,
		shi_r__Tfng,
		shi_rMA__Tfng,
		si,
		si_rLK,
		sk,
		sk_rSK,
		sl,
		sl_rSI,
		sn,
		sn_rZW,
		so,
		so_rDJ,
		so_rET,
		so_rKE,
		so_rSO,
		sq,
		sq_rAL,
		sq_rMK,
		sq_rXK,
		sr,
		sr_r__Cyrl,
		sr_rBA__Cyrl,
		sr_rME__Cyrl,
		sr_rRS__Cyrl,
		sr_rXK__Cyrl,
		sr_r__Latn,
		sr_rBA__Latn,
		sr_rME__Latn,
		sr_rRS__Latn,
		sr_rXK__Latn,
		sv,
		sv_rAX,
		sv_rFI,
		sv_rSE,
		sw,
		sw_rKE,
		sw_rTZ,
		sw_rUG,
		swc,
		swc_rCD,
		ta,
		ta_rIN,
		ta_rLK,
		ta_rMY,
		ta_rSG,
		te,
		te_rIN,
		teo,
		teo_rKE,
		teo_rUG,
		th,
		th_rTH,
		ti,
		ti_rER,
		ti_rET,
		to,
		to_rTO,
		tr,
		tr_rCY,
		tr_rTR,
		twq,
		twq_rNE,
		tzm,
		tzm_r__Latn,
		tzm_rMA__Latn,
		ug,
		ug_r__Arab,
		ug_rCN__Arab,
		uk,
		uk_rUA,
		ur,
		ur_rIN,
		ur_rPK,
		uz,
		uz_r__Arab,
		uz_rAF__Arab,
		uz_r__Cyrl,
		uz_rUZ__Cyrl,
		uz_r__Latn,
		uz_rUZ__Latn,
		vai,
		vai_r__Latn,
		vai_rLR__Latn,
		vai_r__Vaii,
		vai_rLR__Vaii,
		vi,
		vi_rVN,
		vun,
		vun_rTZ,
		xog,
		xog_rUG,
		yav,
		yav_rCM,
		yo,
		yo_rBJ,
		yo_rNG,
		zgh,
		zgh_rMA,
		zh,
		zh_r__Hans,
		zh_rCN__Hans,
		zh_rHK__Hans,
		zh_rMO__Hans,
		zh_rSG__Hans,
		zh_r__Hant,
		zh_rHK__Hant,
		zh_rMO__Hant,
		zh_rTW__Hant,
		zu,
		zu_rZA
	}

	public static readonly Dictionary<Type, string> dict = new Dictionary<Type, string>();

	static Language()
	{
		dict.Add (Type.af, "Afrikaans");
		dict.Add (Type.af_rNA, "Afrikaans (Namibia)");
		dict.Add (Type.af_rZA, "Afrikaans (South Africa)");
		dict.Add (Type.agq, "Aghem");
		dict.Add (Type.agq_rCM, "Aghem (Cameroon)");
		dict.Add (Type.ak, "Akan");
		dict.Add (Type.ak_rGH, "Akan (Ghana)");
		dict.Add (Type.am, "Amharic");
		dict.Add (Type.am_rET, "Amharic (Ethiopia)");
		dict.Add (Type.ar, "Arabic");
		dict.Add (Type.ar_r001, "Arabic (World)");
		dict.Add (Type.ar_rAE, "Arabic (United Arab Emirates)");
		dict.Add (Type.ar_rBH, "Arabic (Bahrain)");
		dict.Add (Type.ar_rDJ, "Arabic (Djibouti)");
		dict.Add (Type.ar_rDZ, "Arabic (Algeria)");
		dict.Add (Type.ar_rEG, "Arabic (Egypt)");
		dict.Add (Type.ar_rEH, "Arabic (Western Sahara)");
		dict.Add (Type.ar_rER, "Arabic (Eritrea)");
		dict.Add (Type.ar_rIL, "Arabic (Israel)");
		dict.Add (Type.ar_rIQ, "Arabic (Iraq)");
		dict.Add (Type.ar_rJO, "Arabic (Jordan)");
		dict.Add (Type.ar_rKM, "Arabic (Comoros)");
		dict.Add (Type.ar_rKW, "Arabic (Kuwait)");
		dict.Add (Type.ar_rLB, "Arabic (Lebanon)");
		dict.Add (Type.ar_rLY, "Arabic (Libya)");
		dict.Add (Type.ar_rMA, "Arabic (Morocco)");
		dict.Add (Type.ar_rMR, "Arabic (Mauritania)");
		dict.Add (Type.ar_rOM, "Arabic (Oman)");
		dict.Add (Type.ar_rPS, "Arabic (Palestine)");
		dict.Add (Type.ar_rQA, "Arabic (Qatar)");
		dict.Add (Type.ar_rSA, "Arabic (Saudi Arabia)");
		dict.Add (Type.ar_rSD, "Arabic (Sudan)");
		dict.Add (Type.ar_rSO, "Arabic (Somalia)");
		dict.Add (Type.ar_rSS, "Arabic (South Sudan)");
		dict.Add (Type.ar_rSY, "Arabic (Syria)");
		dict.Add (Type.ar_rTD, "Arabic (Chad)");
		dict.Add (Type.ar_rTN, "Arabic (Tunisia)");
		dict.Add (Type.ar_rYE, "Arabic (Yemen)");
		dict.Add (Type.as_, "Assamese");
		dict.Add (Type.as_rIN, "Assamese (India)");
		dict.Add (Type.asa, "Asu");
		dict.Add (Type.asa_rTZ, "Asu (Tanzania)");
		dict.Add (Type.az, "Azerbaijani");
		dict.Add (Type.az_r__Cyrl, "Azerbaijani (Cyrillic)");
		dict.Add (Type.az_rAZ__Cyrl, "Azerbaijani (Cyrillic,Azerbaijan)");
		dict.Add (Type.az_r__Latn, "Azerbaijani (Latin)");
		dict.Add (Type.az_rAZ__Latn, "Azerbaijani (Latin,Azerbaijan)");
		dict.Add (Type.bas, "Basaa");
		dict.Add (Type.bas_rCM, "Basaa (Cameroon)");
		dict.Add (Type.be, "Belarusian");
		dict.Add (Type.be_rBY, "Belarusian (Belarus)");
		dict.Add (Type.bem, "Bemba");
		dict.Add (Type.bem_rZM, "Bemba (Zambia)");
		dict.Add (Type.bez, "Bena");
		dict.Add (Type.bez_rTZ, "Bena (Tanzania)");
		dict.Add (Type.bg, "Bulgarian");
		dict.Add (Type.bg_rBG, "Bulgarian (Bulgaria)");
		dict.Add (Type.bm, "Bambara");
		dict.Add (Type.bm_rML, "Bambara (Mali)");
		dict.Add (Type.bn, "Bengali");
		dict.Add (Type.bn_rBD, "Bengali (Bangladesh)");
		dict.Add (Type.bn_rIN, "Bengali (India)");
		dict.Add (Type.bo, "Tibetan");
		dict.Add (Type.bo_rCN, "Tibetan (China)");
		dict.Add (Type.bo_rIN, "Tibetan (India)");
		dict.Add (Type.br, "Breton");
		dict.Add (Type.br_rFR, "Breton (France)");
		dict.Add (Type.brx, "Bodo");
		dict.Add (Type.brx_rIN, "Bodo (India)");
		dict.Add (Type.bs, "Bosnian");
		dict.Add (Type.bs_r__Cyrl, "Bosnian (Cyrillic)");
		dict.Add (Type.bs_rBA__Cyrl, "Bosnian (Cyrillic,Bosnia and Herzegovina)");
		dict.Add (Type.bs_r__Latn, "Bosnian (Latin)");
		dict.Add (Type.bs_rBA__Latn, "Bosnian (Latin,Bosnia and Herzegovina)");
		dict.Add (Type.ca, "Catalan");
		dict.Add (Type.ca_rAD, "Catalan (Andorra)");
		dict.Add (Type.ca_rES, "Catalan (Spain)");
		dict.Add (Type.ca_rFR, "Catalan (France)");
		dict.Add (Type.ca_rIT, "Catalan (Italy)");
		dict.Add (Type.cgg, "Chiga");
		dict.Add (Type.cgg_rUG, "Chiga (Uganda)");
		dict.Add (Type.chr, "Cherokee");
		dict.Add (Type.chr_rUS, "Cherokee (United States)");
		dict.Add (Type.cs, "Czech");
		dict.Add (Type.cs_rCZ, "Czech (Czech Republic)");
		dict.Add (Type.cy, "Welsh");
		dict.Add (Type.cy_rGB, "Welsh (United Kingdom)");
		dict.Add (Type.da, "Danish");
		dict.Add (Type.da_rDK, "Danish (Denmark)");
		dict.Add (Type.da_rGL, "Danish (Greenland)");
		dict.Add (Type.dav, "Taita");
		dict.Add (Type.dav_rKE, "Taita (Kenya)");
		dict.Add (Type.de, "German");
		dict.Add (Type.de_rAT, "German (Austria)");
		dict.Add (Type.de_rBE, "German (Belgium)");
		dict.Add (Type.de_rCH, "German (Switzerland)");
		dict.Add (Type.de_rDE, "German (Germany)");
		dict.Add (Type.de_rLI, "German (Liechtenstein)");
		dict.Add (Type.de_rLU, "German (Luxembourg)");
		dict.Add (Type.dje, "Zarma");
		dict.Add (Type.dje_rNE, "Zarma (Niger)");
		dict.Add (Type.dua, "Duala");
		dict.Add (Type.dua_rCM, "Duala (Cameroon)");
		dict.Add (Type.dyo, "Jola-Fonyi");
		dict.Add (Type.dyo_rSN, "Jola-Fonyi (Senegal)");
		dict.Add (Type.dz, "Dzongkha");
		dict.Add (Type.dz_rBT, "Dzongkha (Bhutan)");
		dict.Add (Type.ebu, "Embu");
		dict.Add (Type.ebu_rKE, "Embu (Kenya)");
		dict.Add (Type.ee, "Ewe");
		dict.Add (Type.ee_rGH, "Ewe (Ghana)");
		dict.Add (Type.ee_rTG, "Ewe (Togo)");
		dict.Add (Type.el, "Greek");
		dict.Add (Type.el_rCY, "Greek (Cyprus)");
		dict.Add (Type.el_rGR, "Greek (Greece)");
		dict.Add (Type.en, "English");
		dict.Add (Type.en_r001, "English (World)");
		dict.Add (Type.en_r150, "English (Europe)");
		dict.Add (Type.en_rAG, "English (Antigua and Barbuda)");
		dict.Add (Type.en_rAI, "English (Anguilla)");
		dict.Add (Type.en_rAS, "English (American Samoa)");
		dict.Add (Type.en_rAU, "English (Australia)");
		dict.Add (Type.en_rBB, "English (Barbados)");
		dict.Add (Type.en_rBE, "English (Belgium)");
		dict.Add (Type.en_rBM, "English (Bermuda)");
		dict.Add (Type.en_rBS, "English (Bahamas)");
		dict.Add (Type.en_rBW, "English (Botswana)");
		dict.Add (Type.en_rBZ, "English (Belize)");
		dict.Add (Type.en_rCA, "English (Canada)");
		dict.Add (Type.en_rCC, "English (Cocos (Keeling) Islands)");
		dict.Add (Type.en_rCK, "English (Cook Islands)");
		dict.Add (Type.en_rCM, "English (Cameroon)");
		dict.Add (Type.en_rCX, "English (Christmas Island)");
		dict.Add (Type.en_rDG, "English (Diego Garcia)");
		dict.Add (Type.en_rDM, "English (Dominica)");
		dict.Add (Type.en_rER, "English (Eritrea)");
		dict.Add (Type.en_rFJ, "English (Fiji)");
		dict.Add (Type.en_rFK, "English (Falkland Islands (Islas Malvinas))");
		dict.Add (Type.en_rFM, "English (Micronesia)");
		dict.Add (Type.en_rGB, "English (United Kingdom)");
		dict.Add (Type.en_rGD, "English (Grenada)");
		dict.Add (Type.en_rGG, "English (Guernsey)");
		dict.Add (Type.en_rGH, "English (Ghana)");
		dict.Add (Type.en_rGI, "English (Gibraltar)");
		dict.Add (Type.en_rGM, "English (Gambia)");
		dict.Add (Type.en_rGU, "English (Guam)");
		dict.Add (Type.en_rGY, "English (Guyana)");
		dict.Add (Type.en_rHK, "English (Hong Kong)");
		dict.Add (Type.en_rIE, "English (Ireland)");
		dict.Add (Type.en_rIM, "English (Isle of Man)");
		dict.Add (Type.en_rIN, "English (India)");
		dict.Add (Type.en_rIO, "English (British Indian Ocean Territory)");
		dict.Add (Type.en_rJE, "English (Jersey)");
		dict.Add (Type.en_rJM, "English (Jamaica)");
		dict.Add (Type.en_rKE, "English (Kenya)");
		dict.Add (Type.en_rKI, "English (Kiribati)");
		dict.Add (Type.en_rKN, "English (Saint Kitts and Nevis)");
		dict.Add (Type.en_rKY, "English (Cayman Islands)");
		dict.Add (Type.en_rLC, "English (Saint Lucia)");
		dict.Add (Type.en_rLR, "English (Liberia)");
		dict.Add (Type.en_rLS, "English (Lesotho)");
		dict.Add (Type.en_rMG, "English (Madagascar)");
		dict.Add (Type.en_rMH, "English (Marshall Islands)");
		dict.Add (Type.en_rMO, "English (Macau)");
		dict.Add (Type.en_rMP, "English (Northern Mariana Islands)");
		dict.Add (Type.en_rMS, "English (Montserrat)");
		dict.Add (Type.en_rMT, "English (Malta)");
		dict.Add (Type.en_rMU, "English (Mauritius)");
		dict.Add (Type.en_rMW, "English (Malawi)");
		dict.Add (Type.en_rNA, "English (Namibia)");
		dict.Add (Type.en_rNF, "English (Norfolk Island)");
		dict.Add (Type.en_rNG, "English (Nigeria)");
		dict.Add (Type.en_rNR, "English (Nauru)");
		dict.Add (Type.en_rNU, "English (Niue)");
		dict.Add (Type.en_rNZ, "English (New Zealand)");
		dict.Add (Type.en_rPG, "English (Papua New Guinea)");
		dict.Add (Type.en_rPH, "English (Philippines)");
		dict.Add (Type.en_rPK, "English (Pakistan)");
		dict.Add (Type.en_rPN, "English (Pitcairn Islands)");
		dict.Add (Type.en_rPR, "English (Puerto Rico)");
		dict.Add (Type.en_rPW, "English (Palau)");
		dict.Add (Type.en_rRW, "English (Rwanda)");
		dict.Add (Type.en_rSB, "English (Solomon Islands)");
		dict.Add (Type.en_rSC, "English (Seychelles)");
		dict.Add (Type.en_rSD, "English (Sudan)");
		dict.Add (Type.en_rSG, "English (Singapore)");
		dict.Add (Type.en_rSH, "English (Saint Helena)");
		dict.Add (Type.en_rSL, "English (Sierra Leone)");
		dict.Add (Type.en_rSS, "English (South Sudan)");
		dict.Add (Type.en_rSX, "English (Sint Maarten)");
		dict.Add (Type.en_rSZ, "English (Swaziland)");
		dict.Add (Type.en_rTC, "English (Turks and Caicos Islands)");
		dict.Add (Type.en_rTK, "English (Tokelau)");
		dict.Add (Type.en_rTO, "English (Tonga)");
		dict.Add (Type.en_rTT, "English (Trinidad and Tobago)");
		dict.Add (Type.en_rTV, "English (Tuvalu)");
		dict.Add (Type.en_rTZ, "English (Tanzania)");
		dict.Add (Type.en_rUG, "English (Uganda)");
		dict.Add (Type.en_rUM, "English (U.S. Outlying Islands)");
		dict.Add (Type.en_rUS, "English (United States)");
		dict.Add (Type.en_rUS_POSIX, "English (United States,Computer)");
		dict.Add (Type.en_rVC, "English (St. Vincent & Grenadines)");
		dict.Add (Type.en_rVG, "English (British Virgin Islands)");
		dict.Add (Type.en_rVI, "English (U.S. Virgin Islands)");
		dict.Add (Type.en_rVU, "English (Vanuatu)");
		dict.Add (Type.en_rWS, "English (Samoa)");
		dict.Add (Type.en_rZA, "English (South Africa)");
		dict.Add (Type.en_rZM, "English (Zambia)");
		dict.Add (Type.en_rZW, "English (Zimbabwe)");
		dict.Add (Type.eo, "Esperanto");
		dict.Add (Type.es,	"Spanish");
		dict.Add (Type.es_r419, "Spanish (Latin America)");
		dict.Add (Type.es_rAR, "Spanish (Argentina)");
		dict.Add (Type.es_rBO, "Spanish (Bolivia)");
		dict.Add (Type.es_rCL, "Spanish (Chile)");
		dict.Add (Type.es_rCO, "Spanish (Colombia)");
		dict.Add (Type.es_rCR, "Spanish (Costa Rica)");
		dict.Add (Type.es_rCU, "Spanish (Cuba)");
		dict.Add (Type.es_rDO, "Spanish (Dominican Republic)");
		dict.Add (Type.es_rEA, "Spanish (Ceuta and Melilla)");
		dict.Add (Type.es_rEC, "Spanish (Ecuador)");
		dict.Add (Type.es_rES, "Spanish (Spain)");
		dict.Add (Type.es_rGQ, "Spanish (Equatorial Guinea)");
		dict.Add (Type.es_rGT, "Spanish (Guatemala)");
		dict.Add (Type.es_rHN, "Spanish (Honduras)");
		dict.Add (Type.es_rIC, "Spanish (Canary Islands)");
		dict.Add (Type.es_rMX, "Spanish (Mexico)");
		dict.Add (Type.es_rNI, "Spanish (Nicaragua)");
		dict.Add (Type.es_rPA, "Spanish (Panama)");
		dict.Add (Type.es_rPE, "Spanish (Peru)");
		dict.Add (Type.es_rPH, "Spanish (Philippines)");
		dict.Add (Type.es_rPR, "Spanish (Puerto Rico)");
		dict.Add (Type.es_rPY, "Spanish (Paraguay)");
		dict.Add (Type.es_rSV, "Spanish (El Salvador)");
		dict.Add (Type.es_rUS, "Spanish (United States)");
		dict.Add (Type.es_rUY, "Spanish (Uruguay)");
		dict.Add (Type.es_rVE, "Spanish (Venezuela)");
		dict.Add (Type.et, "Estonian");
		dict.Add (Type.et_rEE, "Estonian (Estonia)");
		dict.Add (Type.eu, "Basque");
		dict.Add (Type.eu_rES, "Basque (Spain)");
		dict.Add (Type.ewo, "Ewondo");
		dict.Add (Type.ewo_rCM, "Ewondo (Cameroon)");
		dict.Add (Type.fa, "Persian");
		dict.Add (Type.fa_rAF, "Persian (Afghanistan)");
		dict.Add (Type.fa_rIR, "Persian (Iran)");
		dict.Add (Type.ff, "Fulah");
		dict.Add (Type.ff_rSN, "Fulah (Senegal)");
		dict.Add (Type.fi, "Finnish");
		dict.Add (Type.fi_rFI, "Finnish (Finland)");
		dict.Add (Type.fil, "Filipino");
		dict.Add (Type.fil_rPH, "Filipino (Philippines)");
		dict.Add (Type.fo, "Faroese");
		dict.Add (Type.fo_rFO, "Faroese (Faroe Islands)");
		dict.Add (Type.fr, "French");
		dict.Add (Type.fr_rBE, "French (Belgium)");
		dict.Add (Type.fr_rBF, "French (Burkina Faso)");
		dict.Add (Type.fr_rBI, "French (Burundi)");
		dict.Add (Type.fr_rBJ, "French (Benin)");
		dict.Add (Type.fr_rBL, "French (Saint Barthélemy)");
		dict.Add (Type.fr_rCA, "French (Canada)");
		dict.Add (Type.fr_rCD, "French (Congo (DRC))");
		dict.Add (Type.fr_rCF, "French (Central African Republic)");
		dict.Add (Type.fr_rCG, "French (Congo (Republic))");
		dict.Add (Type.fr_rCH, "French (Switzerland)");
		dict.Add (Type.fr_rCI, "French (Côte d’Ivoire)");
		dict.Add (Type.fr_rCM, "French (Cameroon)");
		dict.Add (Type.fr_rDJ, "French (Djibouti)");
		dict.Add (Type.fr_rDZ, "French (Algeria)");
		dict.Add (Type.fr_rFR, "French (France)");
		dict.Add (Type.fr_rGA, "French (Gabon)");
		dict.Add (Type.fr_rGF, "French (French Guiana)");
		dict.Add (Type.fr_rGN, "French (Guinea)");
		dict.Add (Type.fr_rGP, "French (Guadeloupe)");
		dict.Add (Type.fr_rGQ, "French (Equatorial Guinea)");
		dict.Add (Type.fr_rHT, "French (Haiti)");
		dict.Add (Type.fr_rKM, "French (Comoros)");
		dict.Add (Type.fr_rLU, "French (Luxembourg)");
		dict.Add (Type.fr_rMA, "French (Morocco)");
		dict.Add (Type.fr_rMC, "French (Monaco)");
		dict.Add (Type.fr_rMF, "French (Saint Martin)");
		dict.Add (Type.fr_rMG, "French (Madagascar)");
		dict.Add (Type.fr_rML, "French (Mali)");
		dict.Add (Type.fr_rMQ, "French (Martinique)");
		dict.Add (Type.fr_rMR, "French (Mauritania)");
		dict.Add (Type.fr_rMU, "French (Mauritius)");
		dict.Add (Type.fr_rNC, "French (New Caledonia)");
		dict.Add (Type.fr_rNE, "French (Niger)");
		dict.Add (Type.fr_rPF, "French (French Polynesia)");
		dict.Add (Type.fr_rPM, "French (Saint Pierre and Miquelon)");
		dict.Add (Type.fr_rRE, "French (Réunion)");
		dict.Add (Type.fr_rRW, "French (Rwanda)");
		dict.Add (Type.fr_rSC, "French (Seychelles)");
		dict.Add (Type.fr_rSN, "French (Senegal)");
		dict.Add (Type.fr_rSY, "French (Syria)");
		dict.Add (Type.fr_rTD, "French (Chad)");
		dict.Add (Type.fr_rTG, "French (Togo)");
		dict.Add (Type.fr_rTN, "French (Tunisia)");
		dict.Add (Type.fr_rVU, "French (Vanuatu)");
		dict.Add (Type.fr_rWF, "French (Wallis and Futuna)");
		dict.Add (Type.fr_rYT, "French (Mayotte)");
		dict.Add (Type.ga, "Irish");
		dict.Add (Type.ga_rIE, "Irish (Ireland)");
		dict.Add (Type.gl, "Galician");
		dict.Add (Type.gl_rES, "Galician (Spain)");
		dict.Add (Type.gsw, "Swiss German");
		dict.Add (Type.gsw_rCH, "Swiss German (Switzerland)");
		dict.Add (Type.gsw_rLI, "Swiss German (Liechtenstein)");
		dict.Add (Type.gu, "Gujarati");
		dict.Add (Type.gu_rIN, "Gujarati (India)");
		dict.Add (Type.guz, "Gusii");
		dict.Add (Type.guz_rKE, "Gusii (Kenya)");
		dict.Add (Type.gv, "Manx");
		dict.Add (Type.gv_rIM, "Manx (Isle of Man)");
		dict.Add (Type.ha, "Hausa");
		dict.Add (Type.ha_r__Latn, "Hausa (Latin)");
		dict.Add (Type.ha_rGH__Latn, "Hausa (Latin,Ghana)");
		dict.Add (Type.ha_rNE__Latn, "Hausa (Latin,Niger)");
		dict.Add (Type.ha_rNG__Latn, "Hausa (Latin,Nigeria)");
		dict.Add (Type.haw, "Hawaiian");
		dict.Add (Type.haw_rUS, "Hawaiian (United States)");
		dict.Add (Type.iw, "Hebrew");
		dict.Add (Type.iw_rIL, "Hebrew (Israel)");
		dict.Add (Type.hi, "Hindi");
		dict.Add (Type.hi_rIN, "Hindi (India)");
		dict.Add (Type.hr, "Croatian");
		dict.Add (Type.hr_rBA, "Croatian (Bosnia and Herzegovina)");
		dict.Add (Type.hr_rHR, "Croatian (Croatia)");
		dict.Add (Type.hu, "Hungarian");
		dict.Add (Type.hu_rHU, "Hungarian (Hungary)");
		dict.Add (Type.hy, "Armenian");
		dict.Add (Type.hy_rAM, "Armenian (Armenia)");
		dict.Add (Type.in_, "Indonesian");
		dict.Add (Type.in_rID, "Indonesian (Indonesia)");
		dict.Add (Type.ig, "Igbo");
		dict.Add (Type.ig_rNG, "Igbo (Nigeria)");
		dict.Add (Type.ii, "Sichuan Yi");
		dict.Add (Type.ii_rCN, "Sichuan Yi (China)");
		dict.Add (Type.is_, "Icelandic");
		dict.Add (Type.is_rIS, "Icelandic (Iceland)");
		dict.Add (Type.it, "Italian");
		dict.Add (Type.it_rCH, "Italian (Switzerland)");
		dict.Add (Type.it_rIT, "Italian (Italy)");
		dict.Add (Type.it_rSM, "Italian (San Marino)");
		dict.Add (Type.ja, "Japanese");
		dict.Add (Type.ja_rJP, "Japanese (Japan)");
		dict.Add (Type.jgo, "Ngomba");
		dict.Add (Type.jgo_rCM, "Ngomba (Cameroon)");
		dict.Add (Type.kk_rKZ__Cyrl, "Kazakh (Cyrillic,Kazakhstan)");
		dict.Add (Type.kkj, "Kako");
		dict.Add (Type.kkj_rCM, "Kako (Cameroon)");
		dict.Add (Type.kl, "Kalaallisut");
		dict.Add (Type.kl_rGL, "Kalaallisut (Greenland)");
		dict.Add (Type.kln, "Kalenjin");
		dict.Add (Type.kln_rKE, "Kalenjin (Kenya)");
		dict.Add (Type.km, "Khmer");
		dict.Add (Type.km_rKH, "Khmer (Cambodia)");
		dict.Add (Type.kn, "Kannada");
		dict.Add (Type.kn_rIN, "Kannada (India)");
		dict.Add (Type.ko, "Korean");
		dict.Add (Type.ko_rKP, "Korean (North Korea)");
		dict.Add (Type.ko_rKR, "Korean (South Korea)");
		dict.Add (Type.kok, "Konkani");
		dict.Add (Type.kok_rIN, "Konkani (India)");
		dict.Add (Type.ks, "Kashmiri");
		dict.Add (Type.ks_r__Arab, "Kashmiri (Arabic)");
		dict.Add (Type.ks_rIN__Arab, "Kashmiri (Arabic,India)");
		dict.Add (Type.ksb, "Shambala");
		dict.Add (Type.ksb_rTZ, "Shambala (Tanzania)");
		dict.Add (Type.ksf, "Bafia");
		dict.Add (Type.ksf_rCM, "Bafia (Cameroon)");
		dict.Add (Type.kw, "Cornish");
		dict.Add (Type.kw_rGB, "Cornish (United Kingdom)");
		dict.Add (Type.ky, "Kyrgyz");
		dict.Add (Type.ky_r__Cyrl, "Kyrgyz (Cyrillic)");
		dict.Add (Type.ky_rKG__Cyrl, "Kyrgyz (Cyrillic,Kyrgyzstan)");
		dict.Add (Type.lag, "Langi");
		dict.Add (Type.lag_rTZ, "Langi (Tanzania)");
		dict.Add (Type.lg, "Ganda");
		dict.Add (Type.lg_rUG, "Ganda (Uganda)");
		dict.Add (Type.lkt, "Lakota");
		dict.Add (Type.lkt_rUS, "Lakota (United States)");
		dict.Add (Type.ln, "Lingala");
		dict.Add (Type.ln_rAO, "Lingala (Angola)");
		dict.Add (Type.ln_rCD, "Lingala (Congo (DRC))");
		dict.Add (Type.ln_rCF, "Lingala (Central African Republic)");
		dict.Add (Type.ln_rCG, "Lingala (Congo (Republic))");
		dict.Add (Type.lo, "Lao");
		dict.Add (Type.lo_rLA, "Lao (Laos)");
		dict.Add (Type.lt, "Lithuanian");
		dict.Add (Type.lt_rLT, "Lithuanian (Lithuania)");
		dict.Add (Type.lu, "Luba-Katanga");
		dict.Add (Type.lu_rCD, "Luba-Katanga (Congo (DRC))");
		dict.Add (Type.luo, "Luo");
		dict.Add (Type.luo_rKE, "Luo (Kenya)");
		dict.Add (Type.luy, "Luyia");
		dict.Add (Type.luy_rKE, "Luyia (Kenya)");
		dict.Add (Type.lv, "Latvian");
		dict.Add (Type.lv_rLV, "Latvian (Latvia)");
		dict.Add (Type.mas, "Masai");
		dict.Add (Type.mas_rKE, "Masai (Kenya)");
		dict.Add (Type.mas_rTZ, "Masai (Tanzania)");
		dict.Add (Type.mer, "Meru");
		dict.Add (Type.mer_rKE, "Meru (Kenya)");
		dict.Add (Type.mfe, "Morisyen");
		dict.Add (Type.mfe_rMU, "Morisyen (Mauritius)");
		dict.Add (Type.mg, "Malagasy");
		dict.Add (Type.mg_rMG, "Malagasy (Madagascar)");
		dict.Add (Type.mgh, "Makhuwa-Meetto");
		dict.Add (Type.mgh_rMZ, "Makhuwa-Meetto (Mozambique)");
		dict.Add (Type.mgo, "Meta'");
		dict.Add (Type.mgo_rCM, "Meta' (Cameroon)");
		dict.Add (Type.mk, "Macedonian");
		dict.Add (Type.mk_rMK, "Macedonian (Macedonia (FYROM))");
		dict.Add (Type.ml, "Malayalam");
		dict.Add (Type.ml_rIN, "Malayalam (India)");
		dict.Add (Type.mn, "Mongolian");
		dict.Add (Type.mn_r__Cyrl, "Mongolian (Cyrillic)");
		dict.Add (Type.mn_rMN__Cyrl, "Mongolian (Cyrillic,Mongolia)");
		dict.Add (Type.mr, "Marathi");
		dict.Add (Type.mr_rIN, "Marathi (India)");
		dict.Add (Type.ms, "Malay");
		dict.Add (Type.ms_r__Latn, "Malay (Latin)");
		dict.Add (Type.ms_rBN__Latn, "Malay (Latin,Brunei)");
		dict.Add (Type.ms_rMY__Latn, "Malay (Latin,Malaysia)");
		dict.Add (Type.ms_rSG__Latn, "Malay (Latin,Singapore)");
		dict.Add (Type.mt, "Maltese");
		dict.Add (Type.mt_rMT, "Maltese (Malta)");
		dict.Add (Type.mua, "Mundang");
		dict.Add (Type.mua_rCM, "Mundang (Cameroon)");
		dict.Add (Type.my, "Burmese");
		dict.Add (Type.my_rMM, "Burmese (Myanmar (Burma))");
		dict.Add (Type.naq, "Nama");
		dict.Add (Type.naq_rNA, "Nama (Namibia)");
		dict.Add (Type.nb, "Norwegian Bokmål");
		dict.Add (Type.nb_rNO, "Norwegian Bokmål (Norway)");
		dict.Add (Type.nb_rSJ, "Norwegian Bokmål (Svalbard and Jan Mayen)");
		dict.Add (Type.nd, "North Ndebele");
		dict.Add (Type.nd_rZW, "North Ndebele (Zimbabwe)");
		dict.Add (Type.ne, "Nepali");
		dict.Add (Type.ne_rIN, "Nepali (India)");
		dict.Add (Type.ne_rNP, "Nepali (Nepal)");
		dict.Add (Type.nl, "Dutch");
		dict.Add (Type.nl_rAW, "Dutch (Aruba)");
		dict.Add (Type.nl_rBE, "Dutch (Belgium)");
		dict.Add (Type.nl_rBQ, "Dutch (Caribbean Netherlands)");
		dict.Add (Type.nl_rCW, "Dutch (Curaçao)");
		dict.Add (Type.nl_rNL, "Dutch (Netherlands)");
		dict.Add (Type.nl_rSR, "Dutch (Suriname)");
		dict.Add (Type.nl_rSX, "Dutch (Sint Maarten)");
		dict.Add (Type.nmg, "Kwasio");
		dict.Add (Type.nmg_rCM, "Kwasio (Cameroon)");
		dict.Add (Type.nn, "Norwegian Nynorsk");
		dict.Add (Type.nn_rNO, "Norwegian Nynorsk (Norway)");
		dict.Add (Type.nnh, "Ngiemboon");
		dict.Add (Type.nnh_rCM, "Ngiemboon (Cameroon)");
		dict.Add (Type.nus, "Nuer");
		dict.Add (Type.nus_rSD, "Nuer (Sudan)");
		dict.Add (Type.nyn, "Nyankole");
		dict.Add (Type.nyn_rUG, "Nyankole (Uganda)");
		dict.Add (Type.om, "Oromo");
		dict.Add (Type.om_rET, "Oromo (Ethiopia)");
		dict.Add (Type.om_rKE, "Oromo (Kenya)");
		dict.Add (Type.or, "Oriya");
		dict.Add (Type.or_rIN, "Oriya (India)");
		dict.Add (Type.pa, "Punjabi");
		dict.Add (Type.pa_r__Arab, "Punjabi (Arabic)");
		dict.Add (Type.pa_rPK__Arab, "Punjabi (Arabic,Pakistan)");
		dict.Add (Type.pa_r__Guru, "Punjabi (Gurmukhi)");
		dict.Add (Type.pa_rIN__Guru, "Punjabi (Gurmukhi,India)");
		dict.Add (Type.pl, "Polish");
		dict.Add (Type.pl_rPL, "Polish (Poland)");
		dict.Add (Type.ps, "Pashto");
		dict.Add (Type.ps_rAF, "Pashto (Afghanistan)");
		dict.Add (Type.pt, "Portuguese");
		dict.Add (Type.pt_rAO, "Portuguese (Angola)");
		dict.Add (Type.pt_rBR, "Portuguese (Brazil)");
		dict.Add (Type.pt_rCV, "Portuguese (Cape Verde)");
		dict.Add (Type.pt_rGW, "Portuguese (Guinea-Bissau)");
		dict.Add (Type.pt_rMO, "Portuguese (Macau)");
		dict.Add (Type.pt_rMZ, "Portuguese (Mozambique)");
		dict.Add (Type.pt_rPT, "Portuguese (Portugal)");
		dict.Add (Type.pt_rST, "Portuguese (São Tomé and Príncipe)");
		dict.Add (Type.pt_rTL, "Portuguese (Timor-Leste)");
		dict.Add (Type.rm, "Romansh");
		dict.Add (Type.rm_rCH, "Romansh (Switzerland)");
		dict.Add (Type.rn, "Rundi");
		dict.Add (Type.rn_rBI, "Rundi (Burundi)");
		dict.Add (Type.ro, "Romanian");
		dict.Add (Type.ro_rMD, "Romanian (Moldova)");
		dict.Add (Type.ro_rRO, "Romanian (Romania)");
		dict.Add (Type.rof, "Rombo");
		dict.Add (Type.rof_rTZ, "Rombo (Tanzania)");
		dict.Add (Type.ru, "Russian");
		dict.Add (Type.ru_rBY, "Russian (Belarus)");
		dict.Add (Type.ru_rKG, "Russian (Kyrgyzstan)");
		dict.Add (Type.ru_rKZ, "Russian (Kazakhstan)");
		dict.Add (Type.ru_rMD, "Russian (Moldova)");
		dict.Add (Type.ru_rRU, "Russian (Russia)");
		dict.Add (Type.ru_rUA, "Russian (Ukraine)");
		dict.Add (Type.rw, "Kinyarwanda");
		dict.Add (Type.rw_rRW, "Kinyarwanda (Rwanda)");
		dict.Add (Type.rwk, "Rwa");
		dict.Add (Type.rwk_rTZ, "Rwa (Tanzania)");
		dict.Add (Type.saq, "Samburu");
		dict.Add (Type.saq_rKE, "Samburu (Kenya)");
		dict.Add (Type.sbp, "Sangu");
		dict.Add (Type.sbp_rTZ, "Sangu (Tanzania)");
		dict.Add (Type.seh, "Sena");
		dict.Add (Type.seh_rMZ, "Sena (Mozambique)");
		dict.Add (Type.ses, "Koyraboro Senni");
		dict.Add (Type.ses_rML, "Koyraboro Senni (Mali)");
		dict.Add (Type.sg, "Sango");
		dict.Add (Type.sg_rCF, "Sango (Central African Republic)");
		dict.Add (Type.shi, "Tachelhit");
		dict.Add (Type.shi_r__Latn, "Tachelhit (Latin)");
		dict.Add (Type.shi_rMA__Latn, "Tachelhit (Latin,Morocco)");
		dict.Add (Type.shi_r__Tfng, "Tachelhit (Tifinagh)");
		dict.Add (Type.shi_rMA__Tfng, "Tachelhit (Tifinagh,Morocco)");
		dict.Add (Type.si, "Sinhala");
		dict.Add (Type.si_rLK, "Sinhala (Sri Lanka)");
		dict.Add (Type.sk, "Slovak");
		dict.Add (Type.sk_rSK, "Slovak (Slovakia)");
		dict.Add (Type.sl, "Slovenian");
		dict.Add (Type.sl_rSI, "Slovenian (Slovenia)");
		dict.Add (Type.sn, "Shona");
		dict.Add (Type.sn_rZW, "Shona (Zimbabwe)");
		dict.Add (Type.so, "Somali");
		dict.Add (Type.so_rDJ, "Somali (Djibouti)");
		dict.Add (Type.so_rET, "Somali (Ethiopia)");
		dict.Add (Type.so_rKE, "Somali (Kenya)");
		dict.Add (Type.so_rSO, "Somali (Somalia)");
		dict.Add (Type.sq, "Albanian");
		dict.Add (Type.sq_rAL, "Albanian (Albania)");
		dict.Add (Type.sq_rMK, "Albanian (Macedonia (FYROM))");
		dict.Add (Type.sq_rXK, "Albanian (Kosovo)");
		dict.Add (Type.sr, "Serbian");
		dict.Add (Type.sr_r__Cyrl, "Serbian (Cyrillic)");
		dict.Add (Type.sr_rBA__Cyrl, "Serbian (Cyrillic,Bosnia and Herzegovina)");
		dict.Add (Type.sr_rME__Cyrl, "Serbian (Cyrillic,Montenegro)");
		dict.Add (Type.sr_rRS__Cyrl, "Serbian (Cyrillic,Serbia)");
		dict.Add (Type.sr_rXK__Cyrl, "Serbian (Cyrillic,Kosovo)");
		dict.Add (Type.sr_r__Latn, "Serbian (Latin)");
		dict.Add (Type.sr_rBA__Latn, "Serbian (Latin,Bosnia and Herzegovina)");
		dict.Add (Type.sr_rME__Latn, "Serbian (Latin,Montenegro)");
		dict.Add (Type.sr_rRS__Latn, "Serbian (Latin,Serbia)");
		dict.Add (Type.sr_rXK__Latn, "Serbian (Latin,Kosovo)");
		dict.Add (Type.sv, "Swedish");
		dict.Add (Type.sv_rAX, "Swedish (Åland Islands)");
		dict.Add (Type.sv_rFI, "Swedish (Finland)");
		dict.Add (Type.sv_rSE, "Swedish (Sweden)");
		dict.Add (Type.sw, "Swahili");
		dict.Add (Type.sw_rKE, "Swahili (Kenya)");
		dict.Add (Type.sw_rTZ, "Swahili (Tanzania)");
		dict.Add (Type.sw_rUG, "Swahili (Uganda)");
		dict.Add (Type.swc, "Congo Swahili");
		dict.Add (Type.swc_rCD, "Congo Swahili (Congo (DRC))");
		dict.Add (Type.ta, "Tamil");
		dict.Add (Type.ta_rIN, "Tamil (India)");
		dict.Add (Type.ta_rLK, "Tamil (Sri Lanka)");
		dict.Add (Type.ta_rMY, "Tamil (Malaysia)");
		dict.Add (Type.ta_rSG, "Tamil (Singapore)");
		dict.Add (Type.te, "Telugu");
		dict.Add (Type.te_rIN, "Telugu (India)");
		dict.Add (Type.teo, "Teso");
		dict.Add (Type.teo_rKE, "Teso (Kenya)");
		dict.Add (Type.teo_rUG, "Teso (Uganda)");
		dict.Add (Type.th, "Thai");
		dict.Add (Type.th_rTH, "Thai (Thailand)");
		dict.Add (Type.ti, "Tigrinya");
		dict.Add (Type.ti_rER, "Tigrinya (Eritrea)");
		dict.Add (Type.ti_rET, "Tigrinya (Ethiopia)");
		dict.Add (Type.to, "Tongan");
		dict.Add (Type.to_rTO, "Tongan (Tonga)");
		dict.Add (Type.tr, "Turkish");
		dict.Add (Type.tr_rCY, "Turkish (Cyprus)");
		dict.Add (Type.tr_rTR, "Turkish (Turkey)");
		dict.Add (Type.twq, "Tasawaq");
		dict.Add (Type.twq_rNE, "Tasawaq (Niger)");
		dict.Add (Type.tzm, "Central Atlas Tamazight");
		dict.Add (Type.tzm_r__Latn, "Central Atlas Tamazight (Latin)");
		dict.Add (Type.tzm_rMA__Latn, "Central Atlas Tamazight (Latin,Morocco)");
		dict.Add (Type.ug, "Uyghur");
		dict.Add (Type.ug_r__Arab, "Uyghur (Arabic)");
		dict.Add (Type.ug_rCN__Arab, "Uyghur (Arabic,China)");
		dict.Add (Type.uk, "Ukrainian");
		dict.Add (Type.uk_rUA, "Ukrainian (Ukraine)");
		dict.Add (Type.ur, "Urdu");
		dict.Add (Type.ur_rIN, "Urdu (India)");
		dict.Add (Type.ur_rPK, "Urdu (Pakistan)");
		dict.Add (Type.uz, "Uzbek");
		dict.Add (Type.uz_r__Arab, "Uzbek (Arabic)");
		dict.Add (Type.uz_rAF__Arab, "Uzbek (Arabic,Afghanistan)");
		dict.Add (Type.uz_r__Cyrl, "Uzbek (Cyrillic)");
		dict.Add (Type.uz_rUZ__Cyrl, "Uzbek (Cyrillic,Uzbekistan)");
		dict.Add (Type.uz_r__Latn, "Uzbek (Latin)");
		dict.Add (Type.uz_rUZ__Latn, "Uzbek (Latin,Uzbekistan)");
		dict.Add (Type.vai, "Vai");
		dict.Add (Type.vai_r__Latn, "Vai (Latin)");
		dict.Add (Type.vai_rLR__Latn, "Vai (Latin,Liberia)");
		dict.Add (Type.vai_r__Vaii, "Vai (Vai)");
		dict.Add (Type.vai_rLR__Vaii, "Vai (Vai,Liberia)");
		dict.Add (Type.vi, "Vietnamese");
		dict.Add (Type.vi_rVN, "Vietnamese (Vietnam)");
		dict.Add (Type.vun, "Vunjo");
		dict.Add (Type.vun_rTZ, "Vunjo (Tanzania)");
		dict.Add (Type.xog, "Soga");
		dict.Add (Type.xog_rUG, "Soga (Uganda)");
		dict.Add (Type.yav, "Yangben");
		dict.Add (Type.yav_rCM, "Yangben (Cameroon)");
		dict.Add (Type.yo, "Yoruba");
		dict.Add (Type.yo_rBJ, "Yoruba (Benin)");
		dict.Add (Type.yo_rNG, "Yoruba (Nigeria)");
		dict.Add (Type.zgh, "Standard Moroccan Tamazight");
		dict.Add (Type.zgh_rMA, "Standard Moroccan Tamazight (Morocco)");
		dict.Add (Type.zh, "Chinese");
		dict.Add (Type.zh_r__Hans, "Chinese (Simplified Han)");
		dict.Add (Type.zh_rCN__Hans, "Chinese (Simplified Han,China)");
		dict.Add (Type.zh_rHK__Hans, "Chinese (Simplified Han,Hong Kong)");
		dict.Add (Type.zh_rMO__Hans, "Chinese (Simplified Han,Macau)");
		dict.Add (Type.zh_rSG__Hans, "Chinese (Simplified Han,Singapore)");
		dict.Add (Type.zh_r__Hant, "Chinese (Traditional Han)");
		dict.Add (Type.zh_rHK__Hant, "Chinese (Traditional Han,Hong Kong)");
		dict.Add (Type.zh_rMO__Hant, "Chinese (Traditional Han,Macau)");
		dict.Add (Type.zh_rTW__Hant, "Chinese (Traditional Han,Taiwan)");
		dict.Add (Type.zu, "Zulu");
		dict.Add (Type.zu_rZA, "Zulu (South Africa)");
	}

	public static readonly Type[] SupportTypes = {
		Type.en,
		Type.vi
	};

	public static int GetSupportIndex(Type type)
	{
		for (int i = 0; i < SupportTypes.Length; i++) {
			if (SupportTypes [i] == type) {
				return i;
			}
		}
		return 0;
	}

	public static Language.Type GetSupportType(int index)
	{
		if (index >= 0 && index < SupportTypes.Length) {
			return SupportTypes [index];
		} else {
			Debug.LogError ("index error: " + index);
			return Type.en;
		}
	}

}