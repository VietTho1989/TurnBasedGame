//
//  Countries.cs
//
//  Author:
//       Tomaz Saraiva <tomaz.saraiva@gmail.com>
//
//  Copyright (c) 2017 Tomaz Saraiva
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CountryName
{
	public int Id
	{
		get;
		set;
	}

	public Dictionary<string,string> Names
	{
		get;
		set;
	}
		
	public CountryName(int id, JSONObject json)
	{
		Id = id;
		Names = new Dictionary<string, string> ();

		if(json.keys.Count > 0)
		{
			for (int i = 0; i < json.keys.Count; i++)
			{
				Names.Add (json.keys [i], json.GetField (json.keys [i]).str);
			}
		}
	}
}

public class Country
{
	private const string KEY_ID = "id";
	private const string KEY_CODE_ALPHA_2 = "code-alpha-2";
	private const string KEY_CODE_ALPHA_3 = "code-alpha-3";


	public int Id
	{
		get;
		set;
	}

	public string CodeAlpha2
	{
		get;
		set;
	}

	public string CodeAlpha3
	{
		get;
		set;
	}

	public string Name;


	public Country(JSONObject json)
	{
		Id = (int)json.GetField(KEY_ID).i;
		CodeAlpha2 = json.GetField(KEY_CODE_ALPHA_2).str;
		CodeAlpha3 = json.GetField(KEY_CODE_ALPHA_3).str;
	}


	public override string ToString ()
	{
		return string.Format ("[Country: Id={0}, CodeAlpha2={1}, CodeAlpha3={2}, Name={3}]", Id, CodeAlpha2, CodeAlpha3, Name);
	}
}

public class Countries
{
	private const string COUNTRY_NAMES_JSON_FILEPATH = "countries-names";

	private const string COUNTRIES_JSON_FILEPATH = "countries";
	private const string COUNTRIES_JSON_ROOT = "countries";


	public static Dictionary<string, Country> Dictionary
	{
		get
		{
			if(_countriesDic == null)
			{
				_countriesDic = GetDictionary ();
			}

			return _countriesDic;
		}
	}


	private static Dictionary<string, Country> _countriesDic;


	public static string GetCountryName(string code)
	{
		string result = "";

		if(!string.IsNullOrEmpty (code) && Dictionary.ContainsKey (code))
		{
			result = Dictionary[code].Name;
		}

		return result;
	}

	public static void Clear()
	{
		if(_countriesDic != null)
		{
			_countriesDic.Clear ();
			_countriesDic = null;
		}
	}


	private static Dictionary<string, Country> GetDictionary()
	{
		Dictionary<string, Country> result = new Dictionary<string, Country> ();

		Dictionary<int, CountryName> names = LoadCountryNames ();

		JSONObject json = new JSONObject (Resources.Load<TextAsset> (COUNTRIES_JSON_FILEPATH).text).GetField (COUNTRIES_JSON_ROOT);

		for (int i = 0; i < json.list.Count; i++)
		{
			Country country = new Country (json.list [i]);
			country.Name = names [country.Id].Names ["EN"];

			result.Add (country.CodeAlpha2, country);
		}

		result = result.Select(c => c.Value).OrderBy (x => x.Name).ToDictionary (c => c.CodeAlpha2, c => c);

		return result;
	}

	private static Dictionary<int, CountryName> LoadCountryNames()
	{
		Dictionary<int, CountryName> countryNames = new Dictionary<int, CountryName> ();

		JSONObject jsonNames = new JSONObject (Resources.Load<TextAsset> (COUNTRY_NAMES_JSON_FILEPATH).text);

		for (int i = 0; i < jsonNames.keys.Count; i++)
		{
			int id = int.Parse (jsonNames.keys [i]);

			countryNames.Add (id, new CountryName(id, jsonNames.GetField(id.ToString ())));
		}

		return countryNames;
	}
}