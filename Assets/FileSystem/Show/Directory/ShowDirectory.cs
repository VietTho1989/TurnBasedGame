using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class ShowDirectory : Data
    {

        #region State

        public enum State
        {
            Load,
            Normal,
            Fail
        }

        public VP<State> state;

        #endregion

        public VP<DirectoryInfo> directory;

        public VP<DirectoryHistory> directoryHistory;

        public LP<FileSystemInfo> files;

        #region Constructor

        public enum Property
        {
            state,
            directory,
            directoryHistory,
            files
        }

        public ShowDirectory() : base()
        {
            this.state = new VP<State>(this, (byte)Property.state, State.Load);
            // directory
            {
                string path = Application.persistentDataPath;
                {
                    string saveFolderPath = Path.Combine(Application.persistentDataPath, FileSystemBrowser.SaveFolder);
                    if (new DirectoryInfo(saveFolderPath).Exists)
                    {
                        path = saveFolderPath;
                    }
                }
                this.directory = new VP<DirectoryInfo>(this, (byte)Property.directory, new DirectoryInfo(path));
            }
            this.directoryHistory = new VP<DirectoryHistory>(this, (byte)Property.directoryHistory, new DirectoryHistory());
            this.files = new LP<FileSystemInfo>(this, (byte)Property.files);
        }

        #endregion

        public void refresh()
        {
            DirectoryInfo directory = this.directory.v;
            if (directory != null)
            {
                if (directory.Exists)
                {
                    try
                    {
                        // Find sub file
                        List<FileSystemInfo> files = new List<FileSystemInfo>();
                        {
                            // Directory
                            {
                                DirectoryInfo[] directories = directory.GetDirectories();
                                for (int i = 0; i < directories.Length; i++)
                                {
                                    files.Add(directories[i]);
                                }
                            }
                            // File
                            {
                                FileInfo[] fileInfos = directory.GetFiles();
                                for (int i = 0; i < fileInfos.Length; i++)
                                {
                                    files.Add(fileInfos[i]);
                                }
                            }
                        }
                        // Debug.LogError("find files: "+files.Count);
                        // Update
                        {
                            this.state.v = State.Normal;
                            IdentityUtils.refresh(this.files, files);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Error: " + e);
                        this.state.v = State.Fail;
                        this.files.clear();
                    }
                }
                else
                {
                    this.state.v = State.Fail;
                    this.files.clear();
                }
            }
            else
            {
                Debug.LogError("directory null: " + this);
                this.state.v = State.Fail;
                this.files.clear();
            }
        }

    }
}