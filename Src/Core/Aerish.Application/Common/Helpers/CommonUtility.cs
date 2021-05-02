using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Common;
using Aerish.Domain.Common.Utilities;

namespace Aerish.Application
{
    public static class CommonUtility
    {
        private static DateTimeUtility dateTimeUtility;
        public static DateTimeUtility DateTimeUtility
        {
            get
            {
                if (dateTimeUtility == null)
                {
                    dateTimeUtility = new DateTimeUtility();
                }

                return dateTimeUtility;
            }
        }

        private static EnumUtility enumUtility;
        public static EnumUtility EnumUtility
        {
            get
            {
                if (enumUtility == null)
                {
                    enumUtility = new EnumUtility();
                }

                return enumUtility;
            }
        }

        private static NumberUtility numberUtility;
        public static NumberUtility NumberUtility
        {
            get
            {
                if (numberUtility == null)
                {
                    numberUtility = new NumberUtility();
                }

                return numberUtility;
            }
        }
    }
}