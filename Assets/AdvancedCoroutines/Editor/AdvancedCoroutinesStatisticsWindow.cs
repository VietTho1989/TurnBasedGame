// <copyright file="AdvancedCoroutinesStatisticsWindow.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

#if(ADVANCED_COROUTINES_STAT)
using System;
using System.Collections.Generic;
using AdvancedCoroutines.Statistics;
#endif
using UnityEditor;
using UnityEngine;

namespace AdvancedCoroutines.Editor
{
    public class AdvancedCoroutinesStatisticsWindow : EditorWindow
    {
    #if(ADVANCED_COROUTINES_STAT)
        private Dictionary<Routine, string[]> _routinesStatistics;

        private Routine _selectedRoutine;
    
        private Vector2 _scrollViewPosition;
    
        private int _workingCoroutinesCount;
        private int _pausedCoroutinesCount;
    #endif
       
    	[MenuItem("Window/Advanced Coroutines/Statistics")]
        static void Init()
        {
            AdvancedCoroutinesStatisticsWindow window = GetWindow<AdvancedCoroutinesStatisticsWindow>();
            window.Show();
        }
    
        public void OnInspectorUpdate()
        {
    #if(ADVANCED_COROUTINES_STAT)
            _routinesStatistics = AdvancedCoroutinesStatistics.GetStatistics();
    #endif
            Repaint();
        }
    
        private void OnGUI()
        {
    #if(!ADVANCED_COROUTINES_STAT)
            EditorGUILayout.HelpBox("To use AdvanedCoroutine's statistics enable 'Debug mode'. " +
                                "You can enable it by pressing 'Window->Advanced Coroutines->Debug Mode->Enable'", 
                                MessageType.Warning);
    #else
            if(!Application.isPlaying) 
            {
                EditorGUILayout.HelpBox("Application must be in 'play mode'",
                                    MessageType.Warning);
                return;
            }
    
            DrawEraseDataBtn();
            EditorGUILayout.Space();
            DrawTotalWorkInfo();
            EditorGUILayout.Space();

            _scrollViewPosition = EditorGUILayout.BeginScrollView(_scrollViewPosition, false, false);
            _workingCoroutinesCount = 0;
            _pausedCoroutinesCount = 0;
            
            DrawRoutinesStatisticsPanel();
            EditorGUILayout.EndScrollView();
#endif
        }
    
    #if(ADVANCED_COROUTINES_STAT)
        private void DrawEraseDataBtn()
        {
            GUI.color = Color.red;
            if(GUILayout.Button("Erase statistics"))
            {
                EditorUtility.DisplayDialog("Warning!", "Do you want to erase statistics?", "Ok", "Cancel");
                {
                    AdvancedCoroutinesStatistics.Erase();
                }
            }
            GUI.color = Color.white;
        }
    
        private void DrawTotalWorkInfo()
        {
            EditorGUILayout.BeginHorizontal("Box");
            {
                DrawTotalInfoUnit(Color.blue, "Started: " + AdvancedCoroutinesStatistics.TotalCoroutinesStarts);
                DrawTotalInfoUnit(Color.red, "Stopped: " + AdvancedCoroutinesStatistics.TotalCoroutinesStops);
                DrawTotalInfoUnit(Color.green, "Working: " + _workingCoroutinesCount);
                DrawTotalInfoUnit(Color.white, "Paused: " + _pausedCoroutinesCount);
                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }
    
        private void DrawTotalInfoUnit(Color color, string label)
        {
            GUI.color = color;
            EditorGUILayout.BeginVertical("Button");
            {
                GUI.color = Color.white;
                EditorGUILayout.LabelField(label, GUILayout.MinWidth(60), GUILayout.MaxWidth(100));
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawRoutinesStatisticsPanel()
        {
            if(_routinesStatistics == null || _routinesStatistics.Count == 0) return;
    
            foreach (var statData in _routinesStatistics)
            {
                if (!statData.Key.IsPaused())
                    _workingCoroutinesCount++;
                else
                    _pausedCoroutinesCount++;

                Color mainColor = statData.Key.IsStandalone ? Color.cyan : Color.yellow;
                DrawStatDataElement(statData.Key, statData.Value, mainColor);
            }
        }
    
        private void DrawStatDataElement(Routine routine, string[] stackTrace, Color mainColor)
        {
            if(stackTrace == null)
                throw new NullReferenceException();
    
            string stackTraceHeader = GetCallHeader(stackTrace);
    
            if(string.IsNullOrEmpty(stackTraceHeader))
                throw new ArgumentException();
    
            if(routine.IsPaused())
            {
                stackTraceHeader = "[PAUSED] " + stackTraceHeader;
            }
            else
            {
                stackTraceHeader = "[WORKING] " + stackTraceHeader;
            }

            if (Routine.IsNull(routine))
                return;

            bool isEquals = routine.Equals(_selectedRoutine);

            if(isEquals)
            {
                DrawExtendedTrace(stackTraceHeader, stackTrace);
            }
            else
            {
                DrawTraceCallHeader(stackTraceHeader, routine, mainColor);
            }
        }
    
        private void DrawExtendedTrace(string stackTraceHeader, string[] stackTrace)
        {
            GUI.color = Color.green;
            var r = EditorGUILayout.BeginVertical("Button");
            {
                if(GUI.Button(r, GUIContent.none))
                {
                    _selectedRoutine = null;
                }
    
                EditorGUILayout.BeginVertical("Box");
                {
                    GUI.color = Color.green;
                    {
                        EditorGUILayout.LabelField(stackTraceHeader);
                    }
                }
                EditorGUILayout.EndVertical();
    
                for(int i = 0; i < stackTrace.Length - 1; i++)
                {
                    SwithColors(i, Color.black, Color.white);
                    {
                        EditorGUILayout.BeginVertical("Box");
                        {
                            GUI.color = Color.white;
                            {
                                EditorGUILayout.LabelField(stackTrace[i]);
                            }
                        }
                        EditorGUILayout.EndVertical();
                    }
                    GUI.color = Color.white;
                }
                
            }
            EditorGUILayout.EndVertical();
            GUI.color = Color.white;
        }
    
        private void SwithColors(int index, Color color1, Color color2)
        {
            if(index % 2 == 0)
                GUI.color = color1;
            else 
                GUI.color = color2;
        }
    
        private void DrawTraceCallHeader(string stackTraceHeader, Routine routine, Color mainColor)
        {
            if(stackTraceHeader == null)
                throw new NullReferenceException();
            
            GUI.color = routine.IsPaused() ? Color.gray : mainColor;
            var r = EditorGUILayout.BeginVertical("Button");
            {
                if(GUI.Button(r, GUIContent.none))
                {
                    _selectedRoutine = routine;
                }
                EditorGUILayout.LabelField(stackTraceHeader);
            }
            EditorGUILayout.EndVertical();
            GUI.color = Color.white;
        }
    
        private string GetCallHeader(string[] stackTrace)
        {
            if(stackTrace.Length >= 2)
                return stackTrace[1];
            return null;
        }
    #endif
    }
}