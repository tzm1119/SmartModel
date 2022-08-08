using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    public partial class PropertyNameConst
    {
        #region common

        public const string Name = "Name";
        public const string DisplayName = "DisplayName";
        public const string _Guid = "Guid";
        public const string _int = "int";
        public const string _string = "string";
        public const string Description = "Description";
        public const string Id = "Id";
        public const string Identity = "Identity";
        public const string Weights = "Weights";
        public const string ScoreRange = "ScoreRange";
        public const string Score = "Score";
        public const string ParentId = "ParentId";
        public const string Birthday = "Birthday";
        public const string JoinTime = "JoinTime";
        public const string GraduationTime = "GraduationTime";
        public const string Education = "Education";
        public const string Schools = "Schools";
        public const string ResumeAttachment = "ResumeAttachment";
        public const string IsHeroJoinUs = "IsHeroJoinUs";
        public const string FailReason = "FailReason";
        public const string OverallEvaluation = "OverallEvaluation";
        #endregion

        #region masa auth

        #region one

       
        public const string Operator = "Operator";
        public const string OperatorName = "OperatorName";
        public const string OperationType = "OperationType";
        public const string OperationTime = "OperationTime";
        public const string OperationDescription = "OperationDescription";


        public const string Address = "Address";
        public const string ProvinceCode = "ProvinceCode";
        public const string CityCode = "CityCode";
        public const string DistrictCode = "DistrictCode";

        public const string Url = "Url";
        public const string Color = "Color";

        public const string Search = "Search";
        public const string StartTime = "StartTime";
        public const string EndTime = "EndTime";

        public const string Enabled = "Enabled";
        public const string StaffIds = "StaffIds";
        public const string Staffs = "Staffs";

        public const string MigrateStaff = "MigrateStaff";
        public const string SourceId = "SourceId";

        public const string SecondLevel = "SecondLevel";
        public const string ThirdLevel = "ThirdLevel";
        public const string FourthLevel = "FourthLevel";
        public const string StaffList = "StaffList";
        public const string DepartmentStaffs = "DepartmentStaffs";


        public const string Children = "Children";
        public const string IsRoot = "IsRoot";

        public const string Gender = "Gender";

        public const string Region = "Region";
        public const string AccessKeyId = "AccessKeyId";
        public const string AccessKeySecret = "AccessKeySecret";
        public const string StsToken = "StsToken";
        public const string Bucket = "Bucket";

        public const string Limit = "Limit";
        public const string Permissions = "Permissions";
        public const string ChildrenRoles = "ChildrenRoles";
        public const string CreateUser = "CreateUser";
        public const string ModifyUser = "ModifyUser";


        public const string Code = "Code";
        public const string _Type = "Type";
        public const string SystemId = "SystemId";
        public const string AppId = "AppId";
        public const string Icon = "Icon";
        public const string Order = "Order";

        public const string PermissionId = "PermissionId";
        public const string PermissionName = "PermissionName";
        public const string ChildPermissionRelations = "ChildPermissionRelations";
        public const string ParentPermissionRelations = "ParentPermissionRelations";
        public const string UserPermissions = "UserPermissions";
        public const string RolePermissions = "RolePermissions";
        public const string TeamPermissions = "TeamPermissions";
        public const string ChildPermissionId = "ChildPermissionId";
        public const string ParentPermissionId = "ParentPermissionId";
        public const string ChildPermission = "ChildPermission";
        public const string ParentPermission = "ParentPermission";

        public const string Roles = "Roles";
        public const string RoleId = "RoleId";
        public const string ParentRole = "ParentRole";
        public const string Users = "Users";
        public const string Teams = "Teams";
        public const string ApiPermissions = "ApiPermissions";

        public const string CreationTime = "CreationTime";
        public const string ModificationTime = "ModificationTime";
        public const string Creator = "Creator";
        public const string Modifier = "Modifier";
        public const string Effect = "Effect";


        public const string ParentRoles = "ParentRoles";
        public const string AvailableQuantity = "AvailableQuantity";


        public const string Tag = "Tag";
        public const string ProjectId = "ProjectId";
        public const string Navs = "Navs";
        public const string AppIdentity = "AppIdentity";
        public const string PermissionType = "PermissionType";
        public const string Apps = "Apps";
      
        
        
        public const string DepartmentId = "DepartmentId";
        public const string StaffId = "StaffId";
        public const string Level = "Level";
        public const string Sort = "Sort";
        public const string ChildPermissions = "ChildPermissions";
        public const string ParentPermissions = "ParentPermissions";


        #endregion
    
        // sso 
        public const string AllowedAccessTokenSigningAlgorithms = "AllowedAccessTokenSigningAlgorithms";
        public const string ShowInDiscoveryDocument = "ShowInDiscoveryDocument";
        public const string LastAccessed = "LastAccessed";
        public const string NonEditable = "NonEditable";
        public const string ApiScopes = "ApiScopes";
        public const string UserClaims = "UserClaims";
        public const string Properties = "Properties";
        public const string Secrets = "Secrets";
        public const string Required = "Required";
        public const string Emphasize = "Emphasize";
        public const string ClientType = "ClientType";
        public const string ClientId = "ClientId";
        public const string ClientName = "ClientName";
        public const string AllowedGrantTypes = "AllowedGrantTypes";
        public const string RequirePkce = "RequirePkce";
        public const string RedirectUris = "RedirectUris";
        public const string PostLogoutRedirectUris = "PostLogoutRedirectUris";
        public const string ClientUri = "ClientUri";
        public const string LogoUri = "LogoUri";
        public const string RequireConsent = "RequireConsent";
        public const string RequireClientSecret = "RequireClientSecret";
        public const string AllowedScopes = "AllowedScopes";
        public const string Title = "Title";
        public const string ThirdPartyIdps = "ThirdPartyIdps";
        public const string RegisterFields = "RegisterFields";
        public const string ThirdPartyIdpId = "ThirdPartyIdpId";
        public const string CustomLoginId = "CustomLoginId";
        public const string RegisterFieldType = "RegisterFieldType";
        public const string IdentificationType = "IdentificationType";
        public const string ThirdPartyUsers = "ThirdPartyUsers";
       
        public const string ServerAddress = "ServerAddress";
        public const string ServerPort = "ServerPort";
        public const string BaseDn = "BaseDn";
        public const string IsSSL = "IsSSL";
        public const string UserSearchBaseDn = "UserSearchBaseDn";
        public const string GroupSearchBaseDn = "GroupSearchBaseDn";
        public const string RootUserDn = "RootUserDn";
        public const string RootUserPassword = "RootUserPassword";
        public const string TeamStaffs = "TeamStaffs";
        public const string UserId = "UserId";
        public const string Avatar = "Avatar";
        public const string IdCard = "IdCard";
        public const string Account = "Account";
        public const string Password = "Password";
        public const string CompanyName = "CompanyName";
        public const string PhoneNumber = "PhoneNumber";
        public const string Email = "Email";
        public const string JobNumber = "JobNumber";
        public const string PositionId = "PositionId";
        public const string StaffType = "StaffType";
        public const string TeamType = "TeamType";
        public const string TeamRoles = "TeamRoles";
        public const string TeamId = "TeamId";
        public const string TeamMemberType = "TeamMemberType";
        public const string ClientSecret = "ClientSecret";
        public const string VerifyFile = "VerifyFile";
        public const string VerifyType = "VerifyType";
        public const string ThridPartyIdentity = "ThridPartyIdentity";
        public const string ExtendedData = "ExtendedData";
        public const string GenderType = "GenderType";
        public const string Data = "Data";
        public const string Landline = "Landline";
        public const string CannotUpdate = "CannotUpdate";
        public const string MemberCount = "MemberCount";
        public const string AdminAvatar = "AdminAvatar";






        #endregion
    }
}
