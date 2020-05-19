using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriveFrameData.Helper
{
    public class FileImportHelper
    {
        /// <summary>
        /// Determines if user selected xml file is a valid xml by checking for "<MainFrameData>" tags.
        /// </summary>
        /// <param name="fileNameAndPath">The file name and path the user has selected.</param>
        /// <returns></returns>
        public bool DetermineIfSelectedXmlIsValid(string fileNameAndPath)
        {
            if (string.IsNullOrEmpty(fileNameAndPath)) return false;

            // todo do work. 
            
            
            
            return false;
        }
    }
}
