/*
 * @(#)FileX.cs        1.0.0    2016-01-18
 *
 * You may use this software under the condition of "Simplified BSD License"
 *
 * Copyright 2016 MARIUSZ GROMADA. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 *
 *    1. Redistributions of source code must retain the above copyright notice, this list of
 *       conditions and the following disclaimer.
 *
 *    2. Redistributions in binary form must reproduce the above copyright notice, this list
 *       of conditions and the following disclaimer in the documentation and/or other materials
 *       provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY MARIUSZ GROMADA ``AS IS'' AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of MARIUSZ GROMADA.
 *
 * If you have any questions/bugs feel free to contact:
 *
 *     Mariusz Gromada
 *     mariuszgromada.org@gmail.com
 *     http://janetsudoku.mariuszgromada.org
 *     http://mathparser.org
 *     http://mathspace.pl
 *     http://github.com/mariuszgromada/Janet-Sudoku
 *     http://janetsudoku.codeplex.com
 *     http://sourceforge.net/projects/janetsudoku
 *     http://bitbucket.org/mariuszgromada/janet-sudoku
 *     http://github.com/mariuszgromada/MathParser.org-mXparser
 *
 *
 *                              Asked if he believes in one God, a mathematician answered:
 *                              "Yes, up to isomorphism."
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace org.mariuszgromada.math.janetsudoku.utils {
	/**
	 * Class implements general purpose methods
	 * helping to work File object.
	 *
	 *
	 * @author         <b>Mariusz Gromada</b><br>
	 *                 <a href="mailto:mariuszgromada.org@gmail.com">mariuszgromada.org@gmail.com</a><br>
	 *                 <a href="http://janetsudoku.mariuszgromada.org" target="_blank">Janet Sudoku - project web page</a><br>
	 *                 <a href="http://mathspace.pl" target="_blank">MathSpace.pl</a><br>
	 *                 <a href="http://mathparser.org" target="_blank">MathParser.org - mXparser project page</a><br>
	 *                 <a href="http://github.com/mariuszgromada/Janet-Sudoku" target="_blank">Janet Sudoku on GitHub</a><br>
	 *                 <a href="http://janetsudoku.codeplex.com" target="_blank">Janet Sudoku on CodePlex</a><br>
	 *                 <a href="http://sourceforge.net/projects/janetsudoku" target="_blank">Janet Sudoku on SourceForge</a><br>
	 *                 <a href="http://bitbucket.org/mariuszgromada/janet-sudoku" target="_blank">Janet Sudoku on BitBucket</a><br>
	 *                 <a href="http://github.com/mariuszgromada/MathParser.org-mXparser" target="_blank">mXparser-MathParser.org on GitHub</a><br>
	 *
	 * @version        1.0.0
	 */
	// [CLSCompliant(true)]
	public sealed class FileX {
		/**
		 * Reads file lines into separate strings stored in List.
		 *
		 * @param filePath        Full path to the file.
		 * @return                If file reading was successful returns
		 *                        List<String> containing each lines
		 *                        from the file content, otherwise
		 *                        returns null. Method do not throws
		 *                        IOException.
		 */
		public static List<String> readFileLines2ArraList(String filePath) {
			List<String> fileContent = null;
			try {
				StreamReader sr = new StreamReader(filePath);
				try {
					fileContent = new List<String>();
					String line = null;
					while ((line = sr.ReadLine()) != null) {
						fileContent.Add(line);
					}
					sr.Close();
				} catch (Exception e) {
					Console.WriteLine(e.StackTrace);
				}
			} catch (Exception e) {
				Console.WriteLine(e.StackTrace);
			}
			return fileContent;
		}
		/**
		 * Writes the given string into the the given file, previous file
		 * content will be overwritten.
		 *
		 * @param file            File object containing file definition.
		 * @param content         String containing content to be written.
		 * @return                True if write was successful, otherwise
		 *                        returns false. Method do not throws
		 *                        IOException.
		 */
		public static bool writeFile(String filePath, String content) {
			StreamWriter sw;
			try {
				sw = new StreamWriter(filePath);
				sw.Write(content);
				sw.Close();
				return true;
			} catch (Exception e) {
				Console.WriteLine(e.StackTrace);
				return false;
			}
		}
		/**
		 * Removes file denoted as file path.
		 *
		 * @param filePath         File pathname.
		 * @return                 True if file was removed, false otherwise.
		 */
		public static bool removeFile(String filePath) {
			if (filePath == null) return false;
			if (filePath.Length == 0) return false;
			if (Directory.Exists(filePath) == true) return false;
			if (File.Exists(filePath) == false) return false;
			FileInfo file = new FileInfo(filePath);
			if (file.IsReadOnly == true) return false;
			try {
				file.Delete();
				return true;
			} catch(Exception e) {
				Console.WriteLine(e.StackTrace);
				return false;
			}
		}
		/**
		 * Returns temporary directory location.
		 * @return Temporary directory location.
		 */
		public static String getTmpDir() {
			return Path.GetTempPath();
		}
		/**
		 * Generates random file name.
		 * @param length    File name length (without extension).
		 * @param fileExt   File extension.
		 * @return          Random file name containing a-zA-Z0-9.
		 */
		public static String genRndFileName(int length, String fileExt) {
			if (length <= 0) return null;
			if (fileExt == null) return null;
			return randomString(length) + "." + fileExt;
		}
		/**
		 * Random string generator.
		 * @param length    Length of random string.
		 * @return          Random string containing a-zA-Z0-9.
		 */
		public static String randomString(int length) {
			if (length < 1) return "";
			char[] chars = {
							'z','x','c','v','b','n','m','a','s','d','f','g','h','j','k','l','q','w','e','r','t','y','u','i','o','p',
							'Z','X','C','V','B','N','M','A','S','D','F','G','H','J','K','L','Q','W','E','R','T','Y','U','I','O','P',
							'0','1','2','3','4','5','6','7','8','9'
				};
			String rndStr = "";
			for (int i = 0; i < length; i++)
				rndStr = rndStr + chars[SudokuStore.randomIndex(chars.Length)];
			return rndStr;
		}
	}
}