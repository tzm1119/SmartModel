using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    public partial class Keyword
    {
        public const string partial = "partial";
    }

    public partial class Config
    {
        public static string Domain = "Domain";
        public static string Infrastructure = "Infrastructure";
        public static string EntityConfigurations = "EntityConfigurations";
        public static string Repositories = "Repositories";
        public static string BackendDir="";
        public static string FrontendDir="";
        public static string Batch= "Batch";
        public static string ModelDirecotryName = "Models";
        public static string EnumDirecotryName = "Enums";
        public static string CmdDirecotryName = "Cmd";
        public static string ServiceDirecotryName = "Service";

        #region MASA Propject
        public static string ContractsDir = ""; 
        public static string ServicesDir = ""; 
        #endregion
    }

}
