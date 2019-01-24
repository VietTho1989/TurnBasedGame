using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rule;

namespace CoTuongUp
{
	public class RuleList : AbstractRuleList
	{

		public static Rules PawnRule;

		public static Rules PromotedPawnRule;

		public static Rules KnightRule;

		public static Rules BishopRule;

		public static Rules AdvisorRule;

		public static Rules CannonRule;

		public static Rules RookRule;

		public static Rules KingRule;

		static RuleList()
		{
			Debug.LogError ("RuleList init");
			// PawnRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					RuleSet ruleSet = new RuleSet ();
					{
						// matrix
						{
							byte[] array = new byte[] {
								d,
								x
							};
							ruleSet.matrix = new byte[1, 2];
							for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
								for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
									ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
								}
						}
						ruleSet.x = 0;
						ruleSet.y = 1;
					}
					rules.ruleSets.Add (ruleSet);
				}
				PawnRule = rules;
			}
			// PromotedPawnRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					RuleSet ruleSet = new RuleSet ();
					{
						// matrix
						{
							byte[] array = new byte[] {
								0, d, 0 ,
								d, x, d
							};
							ruleSet.matrix = new byte[3, 2];
							for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
								for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
									ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
								}
						}
						ruleSet.x = 1;
						ruleSet.y = 1;
					}
					rules.ruleSets.Add (ruleSet);
				}
				PromotedPawnRule = rules;
			}
			// KnightRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					{
						// Left
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										d, 0, 0 ,
										0, p, x ,
										d, 0, 0 
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 2;
								ruleSet.y = 1;
							}
							rules.ruleSets.Add (ruleSet);
						}
						// Right
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										0, 0, d ,
										x, p, 0 ,
										0, 0, d  
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 0;
								ruleSet.y = 1;
							}
							rules.ruleSets.Add (ruleSet);
						}
						// Top
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										d, 0, d ,
										0, p, 0 ,
										0, x, 0 
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 1;
								ruleSet.y = 2;
							}
							rules.ruleSets.Add (ruleSet);
						}
						// Bottom
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										0, x, 0 ,
										0, p, 0 ,
										d, 0, d 
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 1;
								ruleSet.y = 0;
							}
							rules.ruleSets.Add (ruleSet);
						}
					}
				}
				KnightRule = rules;
			}
			// BishopRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					{
						// Left Top
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										d, 0, 0,
										0, p, 0,
										0, 0, x
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 2;
								ruleSet.y = 2;
							}
							rules.ruleSets.Add (ruleSet);
						}
						// Right Top
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										0, 0, d,
										0, p, 0,
										x, 0, 0
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 0;
								ruleSet.y = 2;
							}
							rules.ruleSets.Add (ruleSet);
						}
						// Left Bottom
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										0, 0, x,
										0, p, 0,
										d, 0, 0
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 2;
								ruleSet.y = 0;
							}
							rules.ruleSets.Add (ruleSet);
						}
						// Right Bottom
						{
							RuleSet ruleSet = new RuleSet ();
							{
								// matrix
								{
									byte[] array = new byte[] {
										x, 0, 0,
										0, p, 0,
										0, 0, d
									};
									ruleSet.matrix = new byte[3, 3];
									for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
										for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
											ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
										}
								}
								ruleSet.x = 0;
								ruleSet.y = 0;
							}
							rules.ruleSets.Add (ruleSet);
						}
					}
				}
				BishopRule = rules;
			}
			// AdvisorRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					RuleSet ruleSet = new RuleSet ();
					{
						// matrix
						{
							byte[] array = new byte[] {
								d, 0, d,
								0, x, 0,
								d, 0, d
							};
							ruleSet.matrix = new byte[3, 3];
							for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
								for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
									ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
								}
						}
						ruleSet.x = 1;
						ruleSet.y = 1;
					}
					rules.ruleSets.Add (ruleSet);
				}
				AdvisorRule = rules;
			}
			// CannonRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					RuleSet ruleSet = new RuleSet ();
					{
						// matrix
						{
							byte[] array = new byte[] {
								0, c, 0,
								c, x, c,
								0, c, 0
							};
							ruleSet.matrix = new byte[3, 3];
							for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
								for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
									ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
								}
						}
						ruleSet.x = 1;
						ruleSet.y = 1;
					}
					rules.ruleSets.Add (ruleSet);
				}
				CannonRule = rules;
			}
			// RookRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					RuleSet ruleSet = new RuleSet ();
					{
						// matrix
						{
							byte[] array = new byte[] {
								0, r, 0,
								r, x, r,
								0, r, 0
							};
							ruleSet.matrix = new byte[3, 3];
							for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
								for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
									ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
								}
						}
						ruleSet.x = 1;
						ruleSet.y = 1;
					}
					rules.ruleSets.Add (ruleSet);
				}
				RookRule = rules;
			}
			// KingRule
			{
				Rules rules = new Rules ();
				{
					// RuleSet
					{
						RuleSet ruleSet = new RuleSet ();
						{
							// matrix
							{
								byte[] array = new byte[] {
									0, k, 0,
									d, x, d,
									0, d, 0
								};
								ruleSet.matrix = new byte[3, 3];
								for (int x = 0; x < ruleSet.matrix.GetLength (0); x++)
									for (int y = 0; y < ruleSet.matrix.GetLength (1); y++) {
										ruleSet.matrix [x, y] = array [x + y * ruleSet.matrix.GetLength (0)];
									}
							}
							ruleSet.x = 1;
							ruleSet.y = 1;
							ruleSet.otherKing = Common.k;
						}
						rules.ruleSets.Add (ruleSet);
					}
					// Restrict
					{
						bool[] array = new bool[] {
							false, false, false, true , true , true , false, false, false,
							false, false, false, true , true , true , false, false, false,
							false, false, false, true , true , true , false, false, false,
							false, false, false, false, false, false, false, false, false,
							false, false, false, false, false, false, false, false, false,
							false, false, false, false, false, false, false, false, false,
							false, false, false, false, false, false, false, false, false,
							false, false, false, true , true , true , false, false, false,
							false, false, false, true , true , true , false, false, false,
							false, false, false, true , true , true , false, false, false
						};
						rules.restrict = new bool[9, 10];
						for (int x = 0; x < rules.restrict.GetLength (0); x++)
							for (int y = 0; y < rules.restrict.GetLength (1); y++) {
								rules.restrict [x, y] = array [x + y * rules.restrict.GetLength (0)];
							}
					}
				}
				KingRule = rules;
			}
		}

	}
}