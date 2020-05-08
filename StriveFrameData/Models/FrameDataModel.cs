using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriveFrameData.Models
{
    /// <summary>
    /// Bundle of Frame Data Parameters
    /// </summary>
    internal class FrameDataModel
    {
        private const string PLACE_HOLDER = "Select One";
        const string LARGE_ADVANTAGE = "Large Advantage";
        const string SLIGHT_ADVANTAGE = "Slight Advantage";
        const string NEUTRAL_EVEN = "Neutral\\Even";
        const string SLIGHT_DISADVANTAGE = "Slight Disadvantage";
        const string LARGE_DISADVANTAGE = "Large Disadvantage";

        /// <summary>
        /// Property for place holder constant
        /// </summary>
        public string PlaceHolderConstant
        {
            get { return PLACE_HOLDER; }
        }
        
        /// <summary>
        /// Property for large advantage constant
        /// </summary>
        public string LargeAdvantageConst
        {
            get { return LARGE_ADVANTAGE; }
        }

        /// <summary>
        /// Property for slight advantage constant
        /// </summary>
        public string SlightAdvantageConst
        {
            get { return SLIGHT_ADVANTAGE; }
        }

        /// <summary>
        /// Property for neutral / even constant
        /// </summary>
        public string NeutralEvenConst
        {
            get { return NEUTRAL_EVEN; }
        }

        /// <summary>
        /// Property for slight disadvantage constant
        /// </summary>
        public string SlightDisadvantageConst
        {
            get { return SLIGHT_DISADVANTAGE; }
        }

        /// <summary>
        /// Property for large disadvantage constant
        /// </summary>
        public string LargeDisadvantageConst
        {
            get { return LARGE_DISADVANTAGE; }
        }
    }
}
