using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthGen
{
    public partial class MASAAuthModuleNameConst
    {
        public const string Logs = "Logs";
        public const string Organizations = "Organizations";
        public const string M_Permissions = "Permissions";
        public const string Projects = "Projects";
        public const string Sso = "Sso";
        public const string Subjects = "Subjects";
        public const string Infrastructure = "Infrastructure";
    }
    /// <summary>
    /// 实体类的类型
    /// </summary>
    public partial class MASAAuthTypeNameConst
    {
        #region one

      
        //基类
        public const string BaseUpsertDto_Guid = "BaseUpsertDto<Guid>";
        

        //Logs
        public const string OperationLog = "OperationLog";
        public const string GetOperationLogs = "GetOperationLogs";
        public const string OperationLogDetail = "OperationLogDetail";

        // Infrastructure
        public const string AddressValue = "AddressValue";
        public const string AvatarValue = "AvatarValue";
        //Organizations
        public const string AddPosition = "AddPosition";
        public const string UpsertDepartment = "UpsertDepartment";
        public const string Staff = "Staff";
        public const string DepartmentChildrenCount = "DepartmentChildrenCount";
        public const string DepartmentDetail = "DepartmentDetail";
        public const string Department = "Department";
        public const string DepartmentStaff = "DepartmentStaff";
        public const string DepartmentSelect = "DepartmentSelect";
        public const string Position = "Position";
        public const string PositionDetail = "PositionDetail";
        public const string PositionSelect = "PositionSelect";
        public const string RemovePosition = "RemovePosition";
        public const string UpdatePosition = "UpdatePosition";
        public const string UpsertPosition = "UpsertPosition";

        // Permissions
        public const string SubjectPermissionRelation = "SubjectPermissionRelation";
        public const string PermissionDetail = "PermissionDetail";
        public const string ApiPermissionDetail = "ApiPermissionDetail";
        public const string AppPermission = "AppPermission";
        public const string GetRoles = "GetRoles";
        public const string RemoveRole = "RemoveRole";
        public const string AddRole = "AddRole";
        public const string UpdateRole = "UpdateRole";
        public const string Role = "Role";
        public const string RoleDetail = "RoleDetail";
        public const string Menu = "Menu";
        public const string MenuPermissionDetail = "MenuPermissionDetail";
        public const string RoleSelect = "RoleSelect";
        public const string UserSelect = "UserSelect";
        public const string TeamSelect = "TeamSelect";
        public const string Permission = "Permission";
        public const string RoleOwner = "RoleOwner";
        public const string PermissionRelation = "PermissionRelation";
        public const string UserPermission = "UserPermission";
        public const string RolePermission = "RolePermission";
        public const string TeamPermission = "TeamPermission";
        public const string User = "User";
        public const string RoleRelation = "RoleRelation";
        public const string UserRole = "UserRole";
        public const string TeamRole = "TeamRole";

        // Projects
        public const string App = "App";
        public const string AppNavigationTag = "AppNavigationTag";
        public const string Project = "Project";
        public const string PermissionNav = "PermissionNav";
        public const string AppTagDetail = "AppTagDetail";
       
        // Sso
        public const string AddApiResource = "AddApiResource";
        public const string AddApiScope = "AddApiScope";
        public const string AddClient = "AddClient";
        public const string Client = "Client";
        public const string AddCustomLogin = "AddCustomLogin";
        public const string CustomLoginThirdPartyIdp = "CustomLoginThirdPartyIdp";
        public const string RegisterField = "RegisterField";
        public const string AddIdentityResource = "AddIdentityResource";
        public const string AddUserClaim = "AddUserClaim";
        public const string ApiResource = "ApiResource";
        public const string ApiResourceDetail = "ApiResourceDetail";
        public const string ApiResourceSelect = "ApiResourceSelect";
        public const string ApiScopeDetail = "ApiScopeDetail";
        public const string ApiScope = "ApiScope";
        #endregion

        public const string CustomLogin = "CustomLogin";
        public const string ThirdPartyIdp = "ThirdPartyIdp";
        public const string ThirdPartyUser = "ThirdPartyUser";
        public const string LdapIdp = "LdapIdp";
        public const string IdentityProvider = "IdentityProvider";
        public const string TeamStaff = "TeamStaff";
        public const string Team = "Team";
        public const string UserSystemBusinessData = "UserSystemBusinessData";
        public const string ClientModel = "ClientModel";
        
    }
    /// <summary>
    /// 枚举类型
    /// </summary>
    public partial class MASAAuthEnumTypeNameConst
    {
        public const string OperationTypes = "OperationTypes";
        public const string AuthenticationTypes = "AuthenticationTypes";
        public const string IdentificationTypes = "IdentificationTypes";
        public const string PermissionRelationTypes = "PermissionRelationTypes";
        public const string PermissionTypes = "PermissionTypes";
        public const string RegisterFieldTypes = "RegisterFieldTypes";
        public const string RegisterFieldValueTypes = "RegisterFieldValueTypes";
        public const string TeamMemberTypes = "TeamMemberTypes";
        public const string UserClaimType = "UserClaimType";
        public const string GenderTypes = "GenderTypes";
        public const string ClientTypes = "ClientTypes";
        public const string StaffTypes = "StaffTypes";
        public const string TeamTypes = "TeamTypes";

    }
}
